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
using System.Web.Mail;

namespace PVMODX
{
	/// <summary>
	/// Summary description for sendmail.
	/// </summary>
	public class sendmail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button Button1;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			sendemail();
		}

		public void sendemail()
		{
			
			try
			{
				
				MailMessage Message = new MailMessage();
				Message.To = "shatlin@hotmail.com";
				Message.From = "shatlin@bmmi.com.bh";
				SmtpMail.SmtpServer ="25.1.1.223";
				Message.Subject = "Test";
				Message.Body ="test mail sent";	
				SmtpMail.Send(Message);
				lblError.Text ="The message has been sent";
			}
			catch(Exception ex)
			{
				string ss=ex.Message;
				lblError.Text ="The message could not be sent";
			}

		}
	}
}
