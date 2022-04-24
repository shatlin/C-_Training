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
	/// Summary description for PVOPNISAlternatives.
	/// </summary>
	public class PVOPNISAlternatives : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtProductName;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.WebControls.Label lblProduct;
		protected System.Web.UI.WebControls.Label txtProduct;
		protected System.Web.UI.WebControls.Label lblProdName;
		protected System.Web.UI.WebControls.Label txtProdName;
		protected System.Web.UI.WebControls.Panel pnlStatusDetail;
		protected System.Web.UI.WebControls.Label lblOrderedQty;
		protected System.Web.UI.WebControls.Label lblAllocatedQty;
		protected System.Web.UI.WebControls.Label lblBalanceQty;
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected System.Web.UI.WebControls.Panel pnlStatus;
		protected string ordNo;
		protected string warehouse;
		protected System.Web.UI.WebControls.Button cmdPrint;
		protected System.Web.UI.WebControls.Button cmdClose;
		protected string product;
		protected System.Web.UI.WebControls.Label txtBalanceQty;
		protected System.Web.UI.WebControls.Label txtAllocatedQty;
		protected System.Web.UI.WebControls.Label txtOrderedQty;
		protected System.Web.UI.WebControls.Label lblUnit;
		protected System.Web.UI.WebControls.Label txtUnit;
		protected System.Web.UI.WebControls.Label lblRatio;
		protected System.Web.UI.WebControls.Label txtRatio;
		protected System.Web.UI.WebControls.Label lblTotalProduct;
		protected System.Web.UI.WebControls.Label lblError;
		DBLayer dal = new DBLayer();
		private void Page_Load(object sender, System.EventArgs e)
		{
			warehouse=Request.Params["warehouse"];
			product=Request.Params["product"];
			string ord=Request.Params["ord"];
			string all=Request.Params["all"];
			string bal=Request.Params["bal"];
			string pName=Request.Params["pName"];
			string unit=Request.Params["unit"];
			string ratio=Request.Params["ratio"];
			ordNo=Request.Params["ordNo"];
			txtProduct.Text = warehouse + product;
			txtProdName.Text = pName;
			txtOrderedQty.Text = ord;
			txtAllocatedQty.Text = all;
			txtBalanceQty.Text = bal;
			txtUnit.Text = unit;
			txtRatio.Text = ratio;
			if(!this.IsPostBack)
			{
				bindSubstitutions();
			}
			//dgResults.DataBind();

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
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		protected void dgResults_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			bindSubstitutions();
		}

		protected void dgResults_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{
			string altWarehouse = e.Item.Cells[0].Text;
			string altProduct = e.Item.Cells[1].Text;
			TextBox txtOfferQty = (TextBox) e.Item.FindControl("txtOfferQty");
			string offeredQty = txtOfferQty.Text.Trim();
			updateSubstitution(altWarehouse.ToUpper(),altProduct.ToUpper().Trim(),offeredQty.Trim());
			((DataGrid)sender).EditItemIndex = -1;
			bindSubstitutions();
		}

		protected void dgResults_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = -1;
			bindSubstitutions();
			lblError.Text = "";
		}


		private void bindSubstitutions()
		{
			DataSet dsNISDetail = new DataSet();
			dsNISDetail = dal.getSubstitution_DS(ordNo.ToUpper(),warehouse.ToUpper(), product.ToUpper());
			lblTotalProduct.Text = "Total Product (" + dsNISDetail.Tables["tblNISSub"].Rows.Count + ")";
			dgResults.DataSource = dsNISDetail.Tables["tblNISSub"].DefaultView;
			dgResults.DataBind();
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.close();</script>");
		}


		private void updateSubstitution(string altWarehouse, string altProduct, string offeredQty)
		{
			
			string retErr = dal.updateSubstitution(ordNo.ToUpper(), altWarehouse, altProduct, offeredQty, warehouse, product);
			if(retErr.Length > 0)
				lblError.Text = retErr.Trim();
			else
				lblError.Text = "";

		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.print();</script>");
		}


		protected string getNavigationURL(string nsn, string product)
		{
			return "PVOTPRDDETL.aspx?pono="+ordNo+"&nsn="+nsn.Trim()+"&product="+product.Trim()+"&dFlag=1";
		}

		protected string getFreeQty(string physicalQty, string allocQty)
		{
			return Convert.ToString(Convert.ToDouble(physicalQty) - Convert.ToDouble(allocQty));
		}
	}
}
