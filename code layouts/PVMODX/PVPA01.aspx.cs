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

namespace PV
{
	/// <summary>
	/// Summary description for PVPA01.
	/// </summary>
	public class PVPA01 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSupplier;
		protected System.Web.UI.WebControls.ListBox lstSupplier;
		protected System.Web.UI.WebControls.ListBox lstWarehouse;
		protected System.Web.UI.WebControls.Label lblWarehouse;
		protected System.Web.UI.WebControls.CheckBox chkProduct;
		protected System.Web.UI.WebControls.TextBox txtNSN;
		protected System.Web.UI.WebControls.Button cmdClear;
		protected System.Web.UI.WebControls.Label lblNSN;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblTotalRecords;
		protected System.Web.UI.WebControls.Button cmdContinueTop;
		protected System.Web.UI.WebControls.Button cmdContinueBottom;
		protected System.Web.UI.WebControls.Button cmdView;




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
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
			this.cmdContinueTop.Click += new System.EventHandler(this.cmdContinueTop_Click);
			this.cmdContinueBottom.Click += new System.EventHandler(this.cmdContinueBottom_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				populateSupplier();
				populateWarehouse();
			}

		}


		private void populateSupplier()
		{
			DBLayer dal = new DBLayer();
			DataSet dsSupplier = dal.supplier_DS();
			lstSupplier.DataSource = dsSupplier.Tables["pvsupmast"].DefaultView;
			lstSupplier.DataTextField = "vendor_dispname";
			lstSupplier.DataValueField = "vendor_id";
			lstSupplier.DataBind();
		}

		private void populateWarehouse()
		{
			DBLayer dal = new DBLayer();
			DataSet dsWarehouse = dal.warehouse_DS();
			lstWarehouse.DataSource = dsWarehouse.Tables["pvwhmast"].DefaultView;
			lstWarehouse.DataTextField = "warehouse";
			lstWarehouse.DataValueField = "warehouse";
			lstWarehouse.DataBind();

		}

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			lstSupplier.ClearSelection();
			lstWarehouse.ClearSelection();
			txtNSN.Text = "";
			chkProduct.Checked = false;
			lblTotalRecords.Text = "";
			cmdContinueTop.Visible = false;
			cmdContinueBottom.Visible = false;
			DataGrid2.DataBind();
		}

		private void cmdView_Click(object sender, System.EventArgs e)
		{
			string supplierList = Utilities.GetListSelections(lstSupplier);
			string warehouseList = Utilities.GetListSelections(lstWarehouse);
			string strNSN = txtNSN.Text.Trim();
			if(txtNSN.Text.Length > 0 && supplierList.Length == 0)
			{
				lblError.Text = "Please select supplier";
				DataGrid2.DataBind();
				return;
			}
			
			if(txtNSN.Text.Length > 0 && supplierList.Length > 0)
			{
				warehouseList = "";
				viewAnalysis(warehouseList, supplierList, strNSN);
				return;
			}

			if (supplierList.Length > 0 || warehouseList.Length > 0)
				viewAnalysis(warehouseList, supplierList, "");

		}

		private void viewAnalysis(string warehouseList, string supplierList, string strNSN)
		{
			string conditionType="and";
			DBLayer dal = new DBLayer();
			DataSet dsAnalysis = dal.getPVPAnalysis_DS(warehouseList, supplierList, conditionType, strNSN);
			DataGrid2.DataSource = dsAnalysis.Tables["tblPVAnalysis"].DefaultView;
			lblTotalRecords.Text = "Listed " + dsAnalysis.Tables[0].Rows.Count + " Products";
			if(Convert.ToUInt32(dsAnalysis.Tables[0].Rows.Count) >0)
			{
				cmdContinueTop.Visible = true;
				cmdContinueBottom.Visible = true;
			}
			DataGrid2.DataBind();
			
		}
		
		private void viewNSN()
		{

		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
		}


		protected void DataGrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{				
				string warehouse=e.Item.Cells[0].Text;
				string product=e.Item.Cells[1].Text;
				LinkButton btnDetails=(LinkButton) e.Item.Cells[8].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVOPSAStatusDetail.aspx?warehouse="+warehouse+"&product="+product+"\", null, \"top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes\")");
			}
		}


		private string BuildNSN()
		{
			System.Text.StringBuilder theStr=new System.Text.StringBuilder();
			
			foreach(DataGridItem dgItem in DataGrid2.Items)
			{
				CheckBox chkSend=(CheckBox) dgItem.FindControl("SendThis");

				if(chkSend.Checked)
					theStr.Append("'").Append(dgItem.Cells[0].Text.ToString()).Append("',");
			}

			if(theStr.Length>0)
				return Server.UrlEncode(theStr.Remove(theStr.Length-1, 1).ToString());
			else
				return "";
			
		}

		private string BuildSupplier()
		{
			System.Text.StringBuilder theStr = new System.Text.StringBuilder();
			foreach(System.Web.UI.WebControls.ListItem lvItem in lstSupplier.Items)
			{
				if(lvItem.Selected)
					theStr.Append(lvItem.Value.Trim()).Append(",");
			}
			

			if(theStr.Length>0)
				return Server.UrlEncode(theStr.Remove(theStr.Length-1, 1).ToString());
			else
				return "";

		}


		private string BuildSuppName()
		{
			System.Text.StringBuilder theStr = new System.Text.StringBuilder();
			foreach(System.Web.UI.WebControls.ListItem lvItem in lstSupplier.Items)
			{
				if(lvItem.Selected)
					theStr.Append(lvItem.Text.Trim()).Append(",");
			}
			

			if(theStr.Length>0)
				return Server.UrlEncode(theStr.Remove(theStr.Length-1, 1).ToString());
			else
				return "";
		}


		private void cmdContinueTop_Click(object sender, System.EventArgs e)
		{
			redirectDetail();
		}



		private void cmdContinueBottom_Click(object sender, System.EventArgs e)
		{
			redirectDetail();
		}


	}
}
