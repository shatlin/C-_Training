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
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList2;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected eWorld.UI.CalendarPopup calendarPopup1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			doViewSupplier();
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
			this.RadioButtonList2.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList2_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void doViewSupplier()
		{
//			DBLayer dal = new DBLayer();
//			DataSet dsNISSub = dal.supplier_DS();
//			DataTable objDataTable = new DataTable();
//			objDataTable = dsNISSub.Tables[0];
//			SupplierListRpt objReport = new SupplierListRpt();
//			objReport.SetDataSource(objDataTable);  //dbDataSet
//			objReport.SetDatabaseLogon("bmmi","secret");
//			CrystalReportViewer1.DataBind();
//			CrystalReportViewer1.ReportSource = objReport;

		}

		private void RadioButtonList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
