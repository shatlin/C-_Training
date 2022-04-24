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
using System.Security.Cryptography;
using System.Web.Security;
namespace gS
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.TextBox txtUser;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.LinkButton lnkLogin;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnkRegister;
	
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
			this.lnkLogin.Click += new System.EventHandler(this.lnkLogin_Click);
			this.lnkRegister.Click += new System.EventHandler(this.lnkRegister_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnkRegister_Click(object sender, System.EventArgs e)
		{
			
			string salt = Utilities.CreateSalt(5);
			Datalayer datalayer=new Datalayer(); 
			string passwordHash = Utilities.CreatePasswordHash(txtPassword.Text,salt);
			try
			{
			//	datalayer.StoreAccountDetails( txtUser.Text, passwordHash,salt);
			}
			catch(Exception ex)
			{
				lblMessage.Text = ex.Message;
			}

		}
		
		
		private void lnkLogin_Click(object sender, System.EventArgs e)
		{
			bool passwordVerified = false;
			Datalayer datalayer=new Datalayer(); 
			try
			{
				passwordVerified = datalayer.VerifyPassword(txtUser.Text,txtPassword.Text);
			}
			catch(Exception ex)
			{
				lblMessage.Text = ex.Message;
				return;
			}
			if (passwordVerified == true )
			{
				// The user is authenticated
				// At this point, an authentication ticket is normally created
				// This can subsequently be used to generate a GenericPrincipal
				// object for .NET authorization purposes
				lblMessage.Text = "Logon successful: User is authenticated";
			}
			else
			{
				lblMessage.Text = "Invalid username or password";
			}

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			lblMessage.Text="Button1 has been clicked";  
		}


	}
}
