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
	/// Summary description for PVFTPStatus.
	/// </summary>
	public class PVFTPStatus : System.Web.UI.Page
	{

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
		FtpClient FTPl = new FtpClient();
		protected System.Web.UI.WebControls.Button cmdFTP;
		protected System.Web.UI.WebControls.Label lblTotalTrxn;
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected System.Web.UI.WebControls.DataGrid dgResults1;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblErrorHead;
		protected System.Web.UI.WebControls.Label lblPending;
		
		


		DBLayer dal = new DBLayer();

		public class ftp1 : FtpClient
		{

			public ftp1(){}

		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!this.IsPostBack)
			{
				bindFTPTransaction("0");
				bindFTPTransaction("1");
			}

		}



		private void bindFTPTransaction(string flag)
		{

			DataSet dsFTPTrxn = dal.getFTPTransaction_DS("832",flag);
			if (flag=="0")
			{
				dgResults.DataSource = dsFTPTrxn.Tables[0].DefaultView;
				dgResults.DataBind();
			}
			if (flag=="1")
			{
				dgResults1.DataSource = dsFTPTrxn.Tables[0].DefaultView;
				dgResults1.DataBind();
			}

		}

/*
			private void cmdFTP_Click(object sender, System.EventArgs e)
			{
			
		
				string errMessage = "";
				string strFileName = "test.bat";
				string strNewFile = "testNew.bat";
				//string strFileFolder = "test/";
				string strLocalPath =  "C:\\test\\"; // Server.MapPath(strFileFolder); //
				//string strLocalPath =   Server.MapPath("/test/");
				string strRemotePath = "Inbound\\832";

				try
				{
					Server = "cs3";
					Username = "gsbabu";
					Password = "gsbabu";
			
					Login();
					ChangeDir(strRemotePath);
					Upload(strLocalPath + strFileName);
					RenameFile(strFileName, strNewFile,true);
				}
				catch (Exception ex)
				{
					errMessage = ex.Message;
				}
				finally
				{
					Close();
				}
				if (errMessage.Length > 0)
					lblError.Text = errMessage;
				else
					lblError.Text = "File transferred and renamed successfully...";
			
			}
		*/


			protected void dgResults_OnEditCommand(object sender, DataGridCommandEventArgs e)
			{
				string errMessage="";
				string strInFile	= e.Item.Cells[0].Text.Trim();
				string strOutFile	= e.Item.Cells[1].Text.Trim();
				string userID		= e.Item.Cells[2].Text.Trim();
				string password		= e.Item.Cells[3].Text.Trim();
				string address		= e.Item.Cells[4].Text.Trim();
				string strInDir		= e.Item.Cells[5].Text.Trim();
				string strTxn       = e.Item.Cells[6].Text.Trim();
				string strStatus    = e.Item.Cells[7].Text.Trim();
				//string strRemotePath = "Inbound\\832";

				try
				{
					// updateFTPTransaction("O", strInFile, strTxn);
					dal.updateFTPStatus("O",strInFile,strTxn,"1");
					FTPl.Server = address; //"cs3";
					FTPl.Username = userID; 
					FTPl.Password = password;
			
					FTPl.Login();
					//ChangeDir(strRemotePath);
					FTPl.Upload(strInDir + strInFile);
					FTPl.RenameFile(strInFile, strOutFile,true);
				}
				catch (Exception ex)
				{
					errMessage = ex.Message;
				}
				finally
				{
					FTPl.Close();
				}
				if (errMessage.Length > 0)
				{
					lblError.Text = errMessage;

				}
				else
				{
					lblError.Text = "File transmitted successfully...";
					dal.updateFTPStatus("C",strInFile,strTxn,"1");
				}

				bindFTPTransaction("0");
				bindFTPTransaction("1");

			}

		protected void dgResults1_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			string errMessage="";
			string strInFile	= e.Item.Cells[0].Text.Trim();
			string strOutFile	= e.Item.Cells[1].Text.Trim();
			string userID		= e.Item.Cells[2].Text.Trim();
			string password		= e.Item.Cells[3].Text.Trim();
			string address		= e.Item.Cells[4].Text.Trim();
			string strInDir		= e.Item.Cells[5].Text.Trim();
			string strTxn       = e.Item.Cells[6].Text.Trim();
			string strStatus    = e.Item.Cells[7].Text.Trim();

			try
			{
				dal.updateFTPStatus("O",strInFile,strTxn,"0");
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
			}

			if (errMessage.Length > 0)
			{
				lblError.Text = errMessage;

			}
			else
			{
				lblError.Text = "File Ready to transmit...";
			}

			bindFTPTransaction("0");
			bindFTPTransaction("1");

		}





		}
}
