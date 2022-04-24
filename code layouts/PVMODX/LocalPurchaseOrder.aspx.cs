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
	/// Summary description for LocalPurchaseOrder.
	/// </summary>
	public class LocalPurchaseOrder : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOrder;
		protected System.Web.UI.WebControls.TextBox txtOrderNo;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected string strSupplier;
		protected int iRow;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblProductName;
		protected MetaBuilders.WebControls.ComboBox cboProductName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label txtOrder;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label txtStatus;
		protected System.Web.UI.WebControls.Label lblDateReceived;
		protected System.Web.UI.WebControls.Label txtDateReceived;
		protected System.Web.UI.WebControls.Label lblCustomerCode;
		protected System.Web.UI.WebControls.Label txtCustomerCode;
		protected System.Web.UI.WebControls.Label lblDateEntered;
		protected System.Web.UI.WebControls.Label txtDateEntered;
		protected System.Web.UI.WebControls.Label lblAddress1;
		protected System.Web.UI.WebControls.Label txtAddress1;
		protected System.Web.UI.WebControls.Label lblRDD;
		protected System.Web.UI.WebControls.Label txtRDD;
		protected System.Web.UI.WebControls.Label lblAddress2;
		protected System.Web.UI.WebControls.Label txtAddress2;
		protected System.Web.UI.WebControls.Panel pnlStatus;
		protected System.Web.UI.WebControls.Button cmdProceed1;
		protected System.Web.UI.WebControls.Button cmdProceed2;
		protected System.Web.UI.WebControls.Label lblTotalProduct;
		DBLayer dal = new DBLayer();


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// bindLPODetails("E06527");
			//dgResults.EditItemIndex = 0;
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
			this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
			this.cmdProceed1.Click += new System.EventHandler(this.cmdProceed1_Click);
			this.cmdProceed2.Click += new System.EventHandler(this.cmdProceed2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdView_Click(object sender, System.EventArgs e)
		{
			lblError.Text = "";
			if(txtOrderNo.Text.Length > 0)
			{
				DataSet dsOrder = dal.orderList_DS(txtOrderNo.Text.Trim().ToUpper());
				if(dsOrder.Tables["tblOrder"].Rows.Count > 0) 
				{
					lblError.Text = "";
					pnlStatus.Visible=true;
					txtOrder.Text = dsOrder.Tables["tblOrder"].Rows[0]["Order_No"].ToString().Trim();
					Utilities utl = new Utilities();
					txtStatus.Text = utl.getStatus(dsOrder.Tables["tblOrder"].Rows[0]["Status"].ToString().Trim());
					txtDateReceived.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Received"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtDateEntered.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Entered"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtRDD.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Required"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtCustomerCode.Text = dsOrder.Tables["tblOrder"].Rows[0]["Customer"].ToString().Trim();
					txtAddress1.Text = dsOrder.Tables["tblOrder"].Rows[0]["Address1"].ToString().Trim();
					txtAddress2.Text = dsOrder.Tables["tblOrder"].Rows[0]["Address2"].ToString().Trim();
					bindLPODetails(txtOrderNo.Text.Trim());
				}
				else
					lblError.Text = "Invalid Order #";
			}
		}


		private void bindLPODetails(string orderNo)
		{
			DataSet dsLPODetail = new DataSet();
					
			dsLPODetail = dal.getLPODetail_DS(orderNo);
			lblTotalProduct.Text = "Total Product (" + dsLPODetail.Tables["tblLPODetail"].Rows.Count + ")";
			dgResults.DataSource = dsLPODetail.Tables["tblLPODetail"].DefaultView;
			dgResults.DataBind();

		}


		protected DataSet PopulateVendor(string warehouse, string product)  
		{
			return dal.getSupplierCost_DS(warehouse, product.Trim(),"");
		}

		protected void dgResults_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			lblError.Text = ""; 
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			bindLPODetails(txtOrderNo.Text.Trim());
			strSupplier = e.Item.Cells[5].Text; // Convert.ToString(e.Item.FindControl("cboSupplier")).ToString();
			ViewState[this.ToString() + "_IRow"] =  e.Item.ItemIndex;
		}

		protected void dgResults_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
			lblError.Text = ""; 
			((DataGrid)sender).EditItemIndex = -1;
			bindLPODetails(txtOrderNo.Text.Trim());
		}


		protected void dgResults_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{
			
			string warehouse	= e.Item.Cells[0].Text;
			string product		= e.Item.Cells[1].Text.Trim();
			
			TextBox txtBMMICost = (TextBox) e.Item.FindControl("txtBMMICost");
			string strCost = txtBMMICost.Text.Trim();
			
			TextBox txtSuggestedQty = (TextBox) e.Item.FindControl("txtSuggestedQty");
			string strSuggQty = txtSuggestedQty.Text.Trim();

			DropDownList cboSupplier = (DropDownList) e.Item.FindControl("cboSupplier");
			string vendorID		= cboSupplier.SelectedValue;

			string orderNo = txtOrderNo.Text.Trim();

			string retVal = dal.updateSupplierCost(orderNo, warehouse, product, strCost, strSuggQty, vendorID); 
			lblError.Text = ""; 
			if (retVal.Length > 0)
				lblError.Text = retVal;
			else
			{
				lblError.Text = "Updated Successfully";
				((DataGrid)sender).EditItemIndex = -1;
				bindLPODetails(orderNo);
			}
		}


		protected void SetDropDownIndex(object sender, System.EventArgs e)
		{
			// System.Web.UI.WebControls.DropDownList ed;
			((DropDownList)sender).SelectedIndex = ((DropDownList)sender).Items.IndexOf(((DropDownList)sender).Items.FindByText(strSupplier));
			// ed.SelectedIndex = ed.Items.IndexOf(ed.Items.FindByText(strSupplier));
			
		}

		protected void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
		{
			//DataGridCommandEventArgs ed;
			string iRow = (string) ViewState[this.ToString() + "_IRow"].ToString();
			DataGridItem dgItem= dgResults.Items[Convert.ToInt32(iRow)];  //iRow
			string warehouse	= dgItem.Cells[0].Text;
			string product		= dgItem.Cells[1].Text.Trim();
			
			//System.Web.UI.WebControls.DropDownList dl;			
			//strSupplier =  dl.Item.FindControl("cboSupplier").ToString();
			DropDownList cboSupplier = (DropDownList) dgItem.FindControl("cboSupplier");
			strSupplier = cboSupplier.SelectedItem.ToString();
			DataSet dsSupplierCost = dal.getSupplierCost_DS(warehouse,product,cboSupplier.SelectedValue);
			TextBox txtBMMICost = (TextBox) dgItem.FindControl("txtBMMICost");
			// txtBMMICost.Text = dsSupplierCost.Tables["tblSupplierCost"].Rows[0]["bmmi_cost"].ToString();
			string cost = dsSupplierCost.Tables["tblSupplierCost"].Rows[0]["bmmi_cost"].ToString();
			txtBMMICost.Text = cost;
		}

		private void cmdProceed1_Click(object sender, System.EventArgs e)
		{
			Response.Write(getURL());
		}

		private void cmdProceed2_Click(object sender, System.EventArgs e)
		{
			Response.Write(getURL());
		}

		private string getURL()
		{
			string strVal = "<script language='javascript'>";
			strVal += "window.open('";
			strVal += "PVLPOGen.aspx?orderNo="+txtOrderNo.Text.Trim(); 
			strVal += "');";
			strVal += "</script>";
			return strVal;
		}


	}
}
