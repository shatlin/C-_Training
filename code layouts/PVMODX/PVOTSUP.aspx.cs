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
	///  Order Tracking by a supplier
	/// </summary>
	public class PVOTSUP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdContinue;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Panel pnlPrdDetl;
		protected System.Web.UI.WebControls.DropDownList cboVendor;
		
	
		/// <summary>
		/// All supplier names are loaded into combobox cboVendor
		/// When the page is loaded 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				populateOTSupplier();
			}
		}
		/// <summary>
		/// records of all  purchase orders related with the selected supplier
		/// are bound to datagrid2.If the given supplier is not related with
		/// any PO, then no records are shown
		/// </summary>
		/// <param name="selSupplier">the supplier selected</param>
		private void bindOTSupplier(string selSupplier)
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			DataSet dsOTSupplier   = dal.OTSupdetails_DS(selSupplier);
			DataGrid2.DataSource   = dsOTSupplier.Tables["pvtblSupplier"].DefaultView;
			DataGrid2.DataBind();
		}


		/// <summary>
		/// All supplier names are loaded into combobox cboVendor
		/// When the page is loaded 
		/// </summary>
		private void populateOTSupplier()
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			
			System.Data.DataSet dsTitle = dal.OTSupplier_DS();
			cboVendor.DataSource = dsTitle.Tables["pvtblSupplier"];
			cboVendor.DataTextField = "vendor_dispname";
			cboVendor.DataValueField = "vendor_id";
			cboVendor.DataBind();
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
		/// User selects a supplier and presses continue button.
		/// The supplier selected is passed as a parameter to
		/// the function bindOTSupplier that binds POs of 
		/// with datagrid2
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdContinue_Click(object sender, System.EventArgs e)
		{
			string selSupplier=cboVendor.SelectedValue.ToString();
			pnlPrdDetl.Visible=true;
			bindOTSupplier(selSupplier);
		
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
