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
	/// Viewing and/or deleting selected cost records
	/// </summary>
	public class PVCOSTVIEWSEL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlResult;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Panel pnlCrystal;
	
		public static string vendorid="";
		public static string updatedate="";


		/// <summary>
		/// When page is loaded get the vendor id and update date from the calling page
		/// The calling page is pvcostview.aspx.Then view the cost records with the given vendorid
		/// and with the given cost update date
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			//		if(!this.IsPostBack)
		{
			vendorid=Request.Params["vendorid"];
			updatedate=Request.Params["updatedate"];
			
		}
			//		else
		{
			//		asnno="";
		}
			ViewCost();
			
			
			// Put user code to initialize the page here
			
		}
		/// <summary>
		/// load rptCostDetails report. This report shows all cost records
		/// with the given vendorid
		/// and with the given cost update date
		/// </summary>
		private void ViewCost()
		{
			DBLayer dal = new DBLayer();
			
			DataSet dsViewCost = dal.getcostDetails_DS(vendorid,updatedate);
			DataTable objDataTable = new DataTable();
			objDataTable = dsViewCost.Tables[0];
			
			rptCostDetails costrpt = new rptCostDetails();
			costrpt.SetDataSource(objDataTable);  
			costrpt.SetDatabaseLogon("bmmi","secret");
			string paramDate = Convert.ToDateTime(updatedate).Year + "," + Convert.ToDateTime(updatedate).Month + "," + Convert.ToDateTime(updatedate).Day;
			costrpt.RecordSelectionFormula ="{pvsupcost.vendor_id}="+vendorid + " and {pvsupcost.update_date} in Date('"+paramDate+"')  ";
			CrystalReportViewer1.DataBind();
			CrystalReportViewer1.ReportSource = costrpt;
			

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// Deletes the cost records with the given vendorid
		/// and with the given cost update date
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			dbcostUplLayer  dal=new dbcostUplLayer();
			string errorDetl=dal.delCost(vendorid,updatedate);
			errorDetl+=dal.recreatesupcscurr ();
			if (errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				dal.rollbackTrans ();
			}
			else
			{
				lblError.Text ="Selected Cost Records Deleted";
				
				dal.commitTrans ();
				CrystalReportViewer1.Visible =false;
				pnlCrystal.Visible =false;
				pnlResult.Visible =true;
			}
			dal.closedBConnection ();
			

		}
	}
}
