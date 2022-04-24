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

namespace PVMODX
{
	/// <summary>
	/// Summary description for PVChangePassword.
	/// </summary>
	public class PVChangePassword : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtOldPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNewPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtConfirmPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Button cmdChangePwd;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary;
		userDBLayer dal = new userDBLayer();

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
			this.cmdChangePwd.Click += new System.EventHandler(this.cmdChangePwd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdChangePwd_Click(object sender, System.EventArgs e)
		{
			if(txtNewPassword.Text.Equals(txtConfirmPassword.Text))
			{
				if(txtNewPassword.Text.IndexOf(" ")==-1)
				{
					if(txtNewPassword.Text.Length>=6)
					{
						int changeStatus=dal.ChangePassword(txtOldPassword.Text, txtNewPassword.Text);

						switch(changeStatus)
						{
							case 0:
								lblErrorMessage.Text="Password changed successfuly.";
								break;
							case 1:
								lblErrorMessage.Text="Old password is not correct.";
								break;
						}
					}
					else
					{
						lblErrorMessage.Text="Minimum password length is 6 charachters.";
					}
				}
				else
				{
					lblErrorMessage.Text="Password cannot contain spaces.";
				}
			}
			else
			{
				lblErrorMessage.Text="The new passwords do not match.";
			}

		}

	}
}
