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
	/// Viewing and/or deleting selected shipping plan records
	/// </summary>
	public class PVSHPLANVIEWSEL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlResult;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Panel pnlCrystal;
		public static string shplanno="";

		/// <summary>
		/// When page is loaded get shipping plan number from the calling page
		/// The calling page is pvshplanview.aspx.Then view shipping plan records with the shplanno
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			shplanno=Request.Params["shplanno"];
			ViewShplan();
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
		/// load rptShplanDetails report. This report shows all shplan records
		/// with the given shplanno
		/// </summary>
		private void ViewShplan()
		{
			DBLayer dal = new DBLayer();
			
			DataSet dsViewShplan = dal.getShplanDetails_DS(shplanno);
			DataTable objDataTable = new DataTable();
			objDataTable = dsViewShplan.Tables[0];
			
			rptShplanDetails Shplanrpt = new rptShplanDetails();
			Shplanrpt.SetDataSource(objDataTable);  
			Shplanrpt.SetDatabaseLogon("bmmi","secret");
			CrystalReportViewer1.DataBind();
			CrystalReportViewer1.ReportSource = Shplanrpt;
			

		}
	

		/// <summary>
		/// Deletes the shplan records with the given shplanno
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			dbshipUplLayer  dal=new dbshipUplLayer();
			string errorDetl=dal.delShplan(shplanno);
			
			if (errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				dal.rollbackTrans ();
			}
			else
			{
				lblError.Text ="Selected Shipping plan Records Deleted";
				
				dal.commitTrans ();
				CrystalReportViewer1.Visible =false;
				pnlCrystal.Visible =false;
				pnlResult.Visible =true;
			}
			dal.closedBConnection ();
			

		}
	}
}
