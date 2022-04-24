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
using System.Data.OleDb;

namespace PVMODX
{
	/// <summary>
	/// Summary description for ModifySupplier.
	/// </summary>
	public class ModifySupplier : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblOrder;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.WebControls.DropDownList cboSupplierType;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				bindSupplier();
			}
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
			this.cboSupplierType.SelectedIndexChanged += new System.EventHandler(this.cboSupplierType_SelectedIndexChanged);
			this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
			this.DataGrid2.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid2_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bindSupplier()
		{
			DBLayer dal = new DBLayer();
			DataSet dsSupplier = dal.supplier_DS(cboSupplierType.SelectedValue);
			// DataSet dsSupplier = supplier_DS(cboSupplierType.SelectedValue);
			DataGrid2.DataSource = dsSupplier.Tables["pvsupmast"].DefaultView;
			DataGrid2.DataBind();
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			bindSupplier();
			string venderID = e.Item.Cells[0].Text;
		}

		protected void DataGrid2_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{
			string venderID = e.Item.Cells[0].Text;
			TextBox txtVendorDispName = (TextBox) e.Item.FindControl("txtVendorDispName");
			string vendorDispName = txtVendorDispName.Text;
			TextBox txtLeadTime = (TextBox) e.Item.FindControl("txtLeadTime");
			string vendLeadTime = txtLeadTime.Text;
			TextBox txtLeadTimeVar = (TextBox) e.Item.FindControl("txtLeadTimeVar");
			string vendLeadTimeVar = txtLeadTimeVar.Text;
			TextBox txtShpPlanAccuracy = (TextBox) e.Item.FindControl("txtShpPlanAccuracy");
			string vendShPlanAccuracy = txtShpPlanAccuracy.Text;
			TextBox txtETAAccuracy = (TextBox) e.Item.FindControl("txtETAAccuracy");
			string vendETAAccuracy = txtETAAccuracy.Text;
			DropDownList cboStatus = (DropDownList) e.Item.FindControl("cboStatus");
			string vendStatus = cboStatus.SelectedValue.ToString();
			TextBox txtRemarks = (TextBox) e.Item.FindControl("txtRemarks");
			string vendRemarks = txtRemarks.Text;

			TextBox txtContact = (TextBox) e.Item.FindControl("txtContact");
			string Contact = txtContact.Text;
			TextBox txtContactFax = (TextBox) e.Item.FindControl("txtContactFax");
			string ContactFax = txtContactFax.Text;

	
			Utilities utl = new Utilities();
			if(!utl.ValidateNumber(vendLeadTime.Trim()))
			{
				lblError.Text = "Lead time should be number";
				return;
			}

			if(!utl.ValidateNumber(vendLeadTimeVar.Trim()))
			{
				lblError.Text = "Lead time variance should be number";
				return;
			}

			if(!utl.ValidateNumber(vendShPlanAccuracy.Trim()))
			{
				lblError.Text = "Ship plan Accuracy should be number";
				return;
			}

			if(!utl.ValidateNumber(vendETAAccuracy.Trim()))
			{
				lblError.Text = "ETA Accuracy should be number";
				return;
			}
			
			DBLayer dal = new DBLayer();

			int retVal = dal.updateSupplier(venderID,vendorDispName,vendLeadTime,vendLeadTimeVar,vendShPlanAccuracy,vendETAAccuracy,vendStatus,vendRemarks,Contact,ContactFax);
			if (retVal == 0)
				lblError.Text = "Please check the update information";
			else
			{
				lblError.Text = "Supplier updated successfuly.";
				((DataGrid)sender).EditItemIndex = -1;
				bindSupplier();
			}
		}

		protected void DataGrid2_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = -1;
			bindSupplier();
			lblError.Text = "";
		}

		protected void DataGrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}

		
		protected string formatValue(string strValue)
		{
			string retVal = strValue.Trim();
			return retVal;
		}


		private void cmdView_Click(object sender, System.EventArgs e)
		{
			bindSupplier();
		}

		private void cboSupplierType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
