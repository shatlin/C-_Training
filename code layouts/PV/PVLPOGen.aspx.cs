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
using CrystalDecisions.Web.Design;
using CrystalDecisions.Shared;


namespace PVMODX
{
	/// <summary>
	/// Summary description for PVLPOGen.
	/// </summary>
	public class PVLPOGen : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lstSupplier;
		protected string orderNo;
		protected System.Web.UI.WebControls.Button cmdGenerate;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.Panel pnlLPOGen;
		protected System.Web.UI.WebControls.LinkButton lnkExport;
		protected System.Web.UI.WebControls.Label lblSep;
		protected System.Web.UI.WebControls.Label lblError;
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
			this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			this.lnkExport.Click += new System.EventHandler(this.lnkExport_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			orderNo = Request.Params["orderNo"];
			if(!this.IsPostBack)
			{
				bindSupplier();
			}
			//generateLPO();
		}


		private void bindSupplier()
		{
			DataSet dsSupplier = dal.getLPOSupplier_DS(orderNo);
			lstSupplier.DataSource = dsSupplier.Tables["tblLPOSupplier"].DefaultView;
			lstSupplier.DataTextField = "vendor_dispname";
			lstSupplier.DataValueField = "vendor_id";
			lstSupplier.DataBind();
		}

		private void cmdGenerate_Click(object sender, System.EventArgs e)
		{
			generateLPO();
		}

		private void generateLPO()
		{
			string vendorList = lstSupplier.SelectedValue.Trim();  //Utilities.GetListSelections(lstSupplier);
			if (vendorList.Length >0)
			{
				DataSet dsLPOGen = dal.getLPOGen_DS(orderNo, vendorList.Replace("'",""));
				//DataSet dsLPOGen = dal.getLPOGen_DS(orderNo, vendorList.Trim());
				DataTable objDataTable = new DataTable();
				objDataTable = dsLPOGen.Tables[0];
				rptGenerateLPO objReport = new rptGenerateLPO();
				// CrystalReport1 objReport = new CrystalReport1();
			
				objReport.SetDataSource(objDataTable); 
				objReport.SetDatabaseLogon("bmmi","secret");
				// objReport.SetParameterValue("VENDID",vendorList);
				CrystalReportViewer1.DataBind();
				CrystalReportViewer1.ReportSource = objReport;
				pnlLPOGen.Visible = true;
			}
		}


		private void ExportReport()
		{
			string vendorList = lstSupplier.SelectedValue.Trim();
			if (vendorList.Length >0)
			{
				DataSet dsLPOGen = dal.getLPOGen_DS(orderNo, vendorList.Replace("'",""));
				//Get the table
				DataTable objDataTable = new DataTable();
				objDataTable = dsLPOGen.Tables[0];
				rptGenerateLPO objReport = new rptGenerateLPO();
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
				// updating print count (if not updated, export fails)
				string retVal = updatePrintCount(vendorList);
				if (retVal.Length > 0)
				{
					lblError.Text = retVal;
					return;
				}
				else
					lblError.Text = "";
				
				objReport.Export();

				Response.ClearContent();
				Response.ClearHeaders();
				Response.ContentType = "application/pdf";  
				Response.WriteFile(strFileName);
				Response.Flush();
				Response.Close();
				File.Delete(Server.MapPath(strFileName));

			}
		}

		private void lnkExport_Click(object sender, System.EventArgs e)
		{
			ExportReport();
		}



		private string updatePrintCount(string vendorList)
		{
			string retVal = dal.updatePrintCount(orderNo, vendorList);
			return retVal ;
		}


	}
}
