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
	/// Summary description for NISSubRrt.
	/// </summary>
	public class NISSubRrt : System.Web.UI.Page
	{
		protected string order_no;
		protected System.Web.UI.WebControls.LinkButton lnkBack;
		protected System.Web.UI.WebControls.LinkButton lnkExport;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.Label lblSep;
		DBLayer dal = new DBLayer();
	


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
			this.lnkExport.Click += new System.EventHandler(this.lnkExport_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			order_no=Request.Params["order_no"]; 
			//if(!this.IsPostBack)
			doViewNIS(order_no);

		}


		private void doViewNIS(string order_no)
		{
			DataSet dsNISSub = dal.getNISSubReport_DS(order_no);
			DataTable objDataTable = new DataTable();
			objDataTable = dsNISSub.Tables[0];
			rptNISSubList objReport = new rptNISSubList();
			objReport.SetDataSource(objDataTable);  //dbDataSet
			objReport.SetDatabaseLogon("bmmi","secret");
			CrystalReportViewer1.DataBind();
			CrystalReportViewer1.ReportSource = objReport;
		}


		private void ExportReport(string order_no)
		{
			DataSet dsNISSub = dal.getNISSubReport_DS(order_no);
			//Get the table
			DataTable objDataTable = new DataTable();
			objDataTable = dsNISSub.Tables[0];
			rptNISSubList objReport = new rptNISSubList();
			objReport.SetDataSource(objDataTable);
			objReport.SetDatabaseLogon("bmmi","secret");
			ExportOptions objExportOpts = new ExportOptions();
			objExportOpts = objReport.ExportOptions;
			objExportOpts.ExportFormatType = ExportFormatType.Excel;
			objExportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
			string cstrOutputPath = "output/";
			string cfileName = cstrOutputPath + "{0}.xls";
			string strFileName = System.String.Format(cfileName, DateTime.Now.ToString("yyyMMddHHmmss"));
			//HttpServerUtility objServer = HttpServerUtility;
			string strFilePath = Server.MapPath(strFileName);
			DiskFileDestinationOptions objDiskOpts = new DiskFileDestinationOptions();
			objDiskOpts.DiskFileName = strFilePath;
			objExportOpts.DestinationOptions = objDiskOpts;
			objReport.Export();

			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/vnd.ms-excel"; // application/xls";
			Response.WriteFile(strFileName);
			Response.Flush();
			Response.Close();
			File.Delete(Server.MapPath(strFileName));
		}

		private void cmdView_Click(object sender, System.EventArgs e)
		{
			ExportReport(order_no);
		}

		private void cmdBack_Click(object sender, System.EventArgs e)
		{
			// Response.Write("<script language='javascript'>window.history.back();</script>");
			Response.Redirect("PVOPNISList.aspx?order_no="+order_no);
		}


		private void lnkExport_Click(object sender, System.EventArgs e)
		{
			ExportReport(order_no);
		}



	}
}
