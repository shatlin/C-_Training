using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Web.Design;


namespace PVMODX
{
	/// <summary>
	/// Summary description for PVASNVIEWSEL.
	/// </summary>
	public class PVASNVIEWSEL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlCrystal;
		protected System.Web.UI.WebControls.Panel pnlResult;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.Button cmdPrint;
		public static string asnno;
		DBLayer dal = new DBLayer();
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			asnno=Request.Params["asnno"];
			doViewSupplier();
			// Put user code to initialize the page here
			
		}

		private void doViewSupplier()
		{
			
			DataSet dsNISSub = dal.getASNDetails_DS(asnno);
			DataTable objDataTable = new DataTable();
			objDataTable = dsNISSub.Tables[0];
			
			rptASNDetails asnrpt = new rptASNDetails();
			asnrpt.SetDataSource(objDataTable);  
			asnrpt.SetDatabaseLogon("bmmi","secret");
			CrystalReportViewer1.DataBind();
			CrystalReportViewer1.ReportSource = asnrpt;

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
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			dbAsnUplLayer  dal=new dbAsnUplLayer();
			string errorDetl=dal.delasn (asnno);
			if (errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				dal.rollbackTrans ();
			}
			else
			{
				lblError.Text ="Selected ASN Records Deleted";
				//commented for test purpose
				dal.commitTrans ();
				CrystalReportViewer1.Visible =false;
				pnlCrystal.Visible =false;
				pnlResult.Visible =true;
			}
			dal.closedBConnection ();
			

		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			ExportReport();
		}


		private void ExportReport()
		{
			DataSet dsNISSub = dal.getASNDetails_DS(asnno);
			//Get the table
			DataTable objDataTable = new DataTable();
			objDataTable = dsNISSub.Tables[0];
			rptASNDetails objReport = new rptASNDetails();
			objReport.SetDataSource(objDataTable);
			objReport.SetDatabaseLogon("bmmi","secret");
			ExportOptions objExportOpts = new ExportOptions();
			objExportOpts = objReport.ExportOptions;
			objExportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;  //Excel;
			objExportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
			string cstrOutputPath = "output/";
			string cfileName = cstrOutputPath + "{0}.pdf";  //xls
			string strFileName = System.String.Format(cfileName, DateTime.Now.ToString("yyyMMddHHmmss"));

			string strFilePath = Server.MapPath(strFileName);
			DiskFileDestinationOptions objDiskOpts = new DiskFileDestinationOptions();
			objDiskOpts.DiskFileName = strFilePath;
			objExportOpts.DestinationOptions = objDiskOpts;
			objReport.Export();

			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/pdf";  //vnd.ms-excel
			Response.WriteFile(strFileName);
			Response.Flush();
			Response.Close();
			File.Delete(Server.MapPath(strFileName));
		}

	}
}
