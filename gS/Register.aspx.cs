using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace gS
{
	/// <summary>
	/// Summary description for Register.
	/// </summary>
	public class Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButton rbMale;
		protected System.Web.UI.WebControls.RadioButton rbFemale;
		protected System.Web.UI.WebControls.Panel pnlSex;
		protected System.Web.UI.WebControls.Label lblMale;
		protected System.Web.UI.WebControls.Label lblFemale;
		protected System.Web.UI.WebControls.TextBox txtFullName;
		protected System.Web.UI.WebControls.TextBox txtUser;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtPasswordVerify;
		protected System.Web.UI.WebControls.DropDownList drpCountry;
		protected System.Web.UI.WebControls.DropDownList drpState;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.TextBox txtAddress2;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnRegister;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRegister_Click(object sender, System.EventArgs e)
		{
			string salt = Utilities.CreateSalt(5);
			char sex='\0';
			Datalayer datalayer=new Datalayer(); 
			if(rbMale.Checked)
			{
				sex='M';
			}
			else
			{
				sex='F';
			}

			string passwordHash = Utilities.CreatePasswordHash(txtPassword.Text,salt);
			try
			{
				datalayer.StoreAccountDetails( txtUser.Text, passwordHash, salt,txtFullName.Text,
											   sex,drpCountry.SelectedValue.ToString(),drpState.SelectedValue.ToString(),
											   txtCity.Text,txtPhone.Text,txtAddress1.Text,txtAddress2.Text  
											  );

			}
			catch(Exception ex)
			{
				lblMessage.Text = ex.Message;
			}
		}
	}
}
