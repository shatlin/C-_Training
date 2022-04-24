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
	/// Summary description for PVUPLFILE.
	/// </summary>
	public class PVUPLFILE : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.HtmlControls.HtmlInputFile uplTheFile;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnUploadTheFile;
		protected System.Web.UI.HtmlControls.HtmlGenericControl txtOutput;
		private Excel.Application ExcelObj=null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				biindRF();
			}
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
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.btnUploadTheFile.ServerClick += new System.EventHandler(this.btnUploadTheFile_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
				"C:\\inetpub\\wwwroot\\example.xls", 0, true, 5,
				"", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
				0, true);

			int a=theWorkbook.Sheets.Count;	
		}

		private void biindRF()
		{
			ExcelObj=new Excel.Application();
			int i=5;
			if (ExcelObj == null)
			{
				i=6;
			}

			else
			{
				i=7;
			}
			
			ExcelObj.Visible = true;

			Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
				"C:\\inetpub\\wwwroot\\example.xls", 0, true, 5,
				"", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
				0, true);

			int a=theWorkbook.Sheets.Count;	
			

			DBLayer dal = new DBLayer();
			DataSet dsCase = dal.RF_DS();
			DataGrid.DataSource = dsCase.Tables["Sheet1$A1:C20"].DefaultView;
			DataGrid.DataBind();
		}


		private void btnUploadTheFile_ServerClick(object sender, System.EventArgs e)
		{
			//Uploading files
			string strFileNameOnServer   = uplTheFile.Value ;
			string strBaseLocation = "c:\\PVDATA\\INBOUND\\COST\\IN\\";
			int filenameindex=strFileNameOnServer.LastIndexOf("\\");
			strFileNameOnServer=strFileNameOnServer.Substring(filenameindex+1);
  
 
 
			if ("" == strFileNameOnServer) 
			{
				txtOutput.InnerHtml = "Error - a file name must be specified.";
				return;
			}

			if (null != uplTheFile.PostedFile) 
			{
				try 
				{
					uplTheFile.PostedFile.SaveAs(strBaseLocation+strFileNameOnServer);
					txtOutput.InnerHtml = "File <b>" + 
						strBaseLocation+strFileNameOnServer+"</b> uploaded successfully";
				}
				catch (Exception ex) 
				{
					txtOutput.InnerHtml = "Error saving <b>" + 
						strBaseLocation+strFileNameOnServer+"</b><br>"+ e.ToString();
				}
			}
		}
	}
}
