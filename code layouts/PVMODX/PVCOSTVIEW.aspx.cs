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
	/// Summary description for PVCOSTVIEW.
	/// </summary>
	public class PVCOSTVIEW : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDateFrom;
		protected eWorld.UI.CalendarPopup calendarPopup1;
		protected System.Web.UI.WebControls.Label lblDateTo;
		protected eWorld.UI.CalendarPopup CalendarPopup2;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Button btnViewCost;
		protected System.Web.UI.WebControls.Panel costpnl;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnViewCost.Click += new System.EventHandler(this.btnViewCost_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Get all costs updated between fromdate and todate
		/// </summary>
		/// <param name="fromdate"></param>
		/// <param name="todate"></param>
		private void bindcost(string fromdate,string todate)
		{
			DBLayer dal = new  DBLayer ();
			DataSet dsCost = dal.viewCost_DS(fromdate,todate);
			DataGrid2.DataSource = dsCost.Tables["pvcost"].DefaultView;
			lblTotal.Text = "Total Cost Uploads (" + dsCost.Tables["pvcost"].Rows.Count + ")";
			DataGrid2.DataBind();
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
		}
		/// <summary>
		/// When user clicks a particular cost record the details of the selected cost records are
		/// loaded in a new window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Utilities utl=new Utilities ();
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
				string vendorid=e.Item.Cells[0].Text;
				string updatedate=e.Item.Cells[3].Text;
				updatedate=utl.getdatepart (updatedate);

				LinkButton btnDetails=(LinkButton) e.Item.Cells[5].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVCOSTVIEWSEL.aspx?vendorid="+vendorid+"&updatedate="+updatedate+"\")");
	
			}
		}

		/// <summary>
		/// When view button is clicked the cost records
		/// in the given date range is bound to the datagrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewCost_Click(object sender, System.EventArgs e)
		{
			string fromdate=calendarPopup1.SelectedDate.ToString ("dd-MMM-yy");
			string todate=CalendarPopup2.SelectedDate.ToString ("dd-MMM-yy");
			costpnl.Visible =true;
			bindcost(fromdate,todate);
		}

		
	
	}
}
