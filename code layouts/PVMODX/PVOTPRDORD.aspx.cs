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
using System.Text;

namespace PVMODX
{
	/// <summary>
	///  Order Tracking by a purchase order
	/// </summary>
	public class PVOTPRDORD : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdContinue;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Panel pnlPrdDetl;
		protected MetaBuilders.WebControls.ComboBox cboOrders;
		
		/// <summary>
		/// All active purchase orderes are loaded into combobox cboOrders
		/// When the page is loaded 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				populateOTOrders();
			}
		}
		/// <summary>
		/// records the selected purchase order
		/// are bound to datagrid2.
		/// </summary>
		/// <param name="selOrder"></param>
		private void bindOTOrder(string selOrder)
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			DataSet dsOTProducts = dal.OTOrderdetails_DS(selOrder);
			DataGrid2.DataSource = dsOTProducts.Tables["pvordetls"].DefaultView;
			DataGrid2.DataBind();
		}



		/// <summary>
		/// All active purchase orderes are loaded into combobox cboOrders
		/// </summary>
		private void populateOTOrders()
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			
			System.Data.DataSet dsTitle = dal.OTOrder_DS();
			cboOrders.DataSource = dsTitle.Tables["tblOrder"];
			cboOrders.DataTextField = "ord";
			cboOrders.DataValueField = "PO_NO";
			cboOrders.DataBind();
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
			this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
			this.DataGrid2.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_OnEditCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// User selects a PO and presses continue button.
		/// The PO selected is passed as a parameter to
		/// the function bindOTOrder that binds PO details with datagrid2
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdContinue_Click(object sender, System.EventArgs e)
		{
			string selorder=cboOrders.Text;
			selorder=selorder.Substring(0,selorder.IndexOf ("-")-1);
			
			pnlPrdDetl.Visible=true;
			bindOTOrder(selorder);
		
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			
		}
		/// <summary>
		/// collect po number,nsn and product from the selected row and 
		/// pass it to pvotprddetl.aspx page that lists the asn,grn and shipping plan
		/// for the given product in the given po
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{				
				string pono=e.Item.Cells[0].Text.Trim ();
				string nsn =e.Item.Cells[4].Text.Trim ();
				string product = e.Item.Cells[6].Text.Trim ();
				
				LinkButton btnDetails=(LinkButton) e.Item.Cells[17].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVOTPRDDETL.aspx?pono="+pono+"&nsn="+nsn+"&product="+product+"\", null, \"top =0, left=0,height=275,width=900,toolbar=no, menubar=no, location=no, directories=no, resizable = yes, scrollbars=yes\")");
			}
		}

		
	}
}
