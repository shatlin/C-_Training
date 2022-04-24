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
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Web.Design;


namespace PVMODX
{
	/// <summary>
	/// Summary description for MismatchList.
	/// </summary>
	public class MismatchList : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.LinkButton lnkExport;
		protected System.Web.UI.WebControls.Label lblSep;
		DBLayer dal = new DBLayer();
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
				 updateMismatch();
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
			this.CrystalReportViewer1.ViewZoom += new CrystalDecisions.Web.ZoomEventHandler(this.CrystalReportViewer1_ViewZoom);
			this.CrystalReportViewer1.Navigate += new CrystalDecisions.Web.NavigateEventHandler(this.CrystalReportViewer1_Navigate);
			this.lnkExport.Click += new System.EventHandler(this.lnkExport_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



// catalogAnalyse_DS(strWarehouse)

		private void viewMisMatch()
		{

			DataSet dsCatalog = dal.catalogAnalyse_DS();
			DataTable objDataTable = new DataTable();
			objDataTable = dsCatalog.Tables[0];
			rptCatalogDifferenceList objReport = new rptCatalogDifferenceList();
			objReport.SetDataSource(objDataTable);  //dbDataSet
			objReport.SetDatabaseLogon("bmmi","secret");
			CrystalReportViewer1.DataBind();
			CrystalReportViewer1.ReportSource = objReport;	
		}


		private void updateMismatch()
		{
			string strWarehouse = Utilities.Warehouse();  //"V";
			string retVal = dal.updateCatalogMismatch(strWarehouse);
			if (retVal.Length >0)
				Response.Redirect("PVCatalogList.aspx");
			else
				viewMisMatch();
		}


		private void ExportMisMatch()
		{
			// string strWarehouse = "V";
			DataSet dsCatalog = dal.catalogAnalyse_DS();
			DataTable objDataTable = new DataTable();
			objDataTable = dsCatalog.Tables[0];
			rptCatalogDifferenceList objReport = new rptCatalogDifferenceList();
			objReport.SetDataSource(objDataTable);
			objReport.SetDatabaseLogon("bmmi","secret");
			ExportOptions objExportOpts = new ExportOptions();
			objExportOpts = objReport.ExportOptions;
			objExportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;  
			objExportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
			string cstrOutputPath = "output/";
			string cfileName = cstrOutputPath + "{0}.pdf";  
			string strFileName = System.String.Format(cfileName, DateTime.Now.ToString("yyyMMddHHmmss"));

			string strFilePath = Server.MapPath(strFileName);
			DiskFileDestinationOptions objDiskOpts = new DiskFileDestinationOptions();
			objDiskOpts.DiskFileName = strFilePath;
			objExportOpts.DestinationOptions = objDiskOpts;
			objReport.Export();

			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/pdf";  
			Response.WriteFile(strFileName);
			Response.Flush();
			Response.Close();
			File.Delete(Server.MapPath(strFileName));
		}

		private void lnkExport_Click(object sender, System.EventArgs e)
		{
			ExportMisMatch();
		}

		private void CrystalReportViewer1_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
		{
			viewMisMatch();
		}

		private void CrystalReportViewer1_ViewZoom(object source, CrystalDecisions.Web.ZoomEventArgs e)
		{
			viewMisMatch();
		}


	}
}
