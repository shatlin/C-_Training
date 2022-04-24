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
	/// Viewing all ASNs Uploaded with the given date range
	/// </summary>
	public class PVASNVIEW : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDateTo;
		protected System.Web.UI.WebControls.Label lblDateFrom;
		protected eWorld.UI.CalendarPopup calendarPopup1;
		protected eWorld.UI.CalendarPopup CalendarPopup2;
		protected System.Web.UI.WebControls.Button btnViewAsn;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Panel asnpnl;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
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
			this.btnViewAsn.Click += new System.EventHandler(this.btnViewAsn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Get all asns uploaded between fromdate and todate
		/// </summary>
		/// <param name="fromdate"></param>
		/// <param name="todate"></param>
		private void bindasn(string fromdate,string todate)
		{
			DBLayer dal = new  DBLayer ();
			DataSet dsAsn = dal.viewasn_DS(fromdate,todate);
			DataGrid2.DataSource = dsAsn.Tables["pvasn"].DefaultView;
			lblTotal.Text = "Total ASNs (" + dsAsn.Tables["pvasn"].Rows.Count + ")";
			DataGrid2.DataBind();
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
		}

		/// <summary>
		/// When user clicks a particular asn record the details of the selected ASNs
		/// are loaded in a new window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
				string asnno=e.Item.Cells[0].Text;

				LinkButton btnDetails=(LinkButton) e.Item.Cells[11].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVASNVIEWSEL.aspx?asnno="+asnno+"\")");
	
			}
		}


		/// <summary>
		/// When view button is clicked the asn records
		/// in the given date range is bound to the datagrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewAsn_Click(object sender, System.EventArgs e)
		{
			string fromdate=calendarPopup1.SelectedDate.ToString ("dd-MMM-yy");
			string todate=CalendarPopup2.SelectedDate.ToString ("dd-MMM-yy");
			asnpnl.Visible =true;
			bindasn(fromdate,todate);
		}

	}
}
