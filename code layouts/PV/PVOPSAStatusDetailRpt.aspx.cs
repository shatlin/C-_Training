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
	/// Summary description for PVOPSAStatusDetailRpt.
	/// </summary>
	public class PVOPSAStatusDetailRpt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSep;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.LinkButton lnkExport;
		protected DBLayer dal = new DBLayer();
		protected string warehouse, product;
		protected System.Web.UI.WebControls.LinkButton Linkbutton1; 

		private void Page_Load(object sender, System.EventArgs e)
		{
			warehouse=Request.Params["warehouse"]; 
			product=Request.Params["product"]; 
			doViewSAStatus(); //warehouse, product
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
			this.lnkExport.Click += new System.EventHandler(this.lnkExport_Click);
			this.Linkbutton1.Click += new System.EventHandler(this.Linkbutton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		
		private void doViewSAStatus() //string warehouse, string product
		{
			// DataSet dsSAStatus = dal.getSAStatusDetailRpt_DS(warehouse, product);
			DataSet dsSAStatus = dal.getOrderDetail_DS(warehouse, product);
			DataTable objDataTable = new DataTable();
			objDataTable = dsSAStatus.Tables[0];
			rptSAStatusDetail objReport = new rptSAStatusDetail();
			objReport.SetDataSource(objDataTable);  //dbDataSet
			objReport.SetDatabaseLogon("bmmi","secret");
			CrystalReportViewer1.DataBind();
			CrystalReportViewer1.ReportSource = objReport;
		}

		private void ExportReport()
		{
			DataSet dsSAStatus = dal.getOrderDetail_DS(warehouse, product);
			//Get the table
			DataTable objDataTable = new DataTable();
			objDataTable = dsSAStatus.Tables[0];
			rptSAStatusDetail objReport = new rptSAStatusDetail();
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
			ExportReport();
		}

		private void Linkbutton1_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.close();</script>");
		}


	}
}
