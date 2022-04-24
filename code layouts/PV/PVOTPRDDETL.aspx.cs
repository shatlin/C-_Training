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
	/// this class is used to present shipping plan, ASN and GRN details of a product
	/// </summary>
	public class PVOTPRDDETL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboProducts;
		protected System.Web.UI.WebControls.Button cmdContinue;
		protected System.Web.UI.WebControls.DataGrid DataGrid;
		protected System.Web.UI.WebControls.DataGrid Datagrid5;
		protected System.Web.UI.WebControls.DataGrid Datagrid3;
		protected System.Web.UI.WebControls.DataGrid Datagrid4;
		protected System.Web.UI.WebControls.Panel pnlPrdDetl;
		protected System.Web.UI.WebControls.Panel pnlNIS;
		protected System.Web.UI.WebControls.Label lblTotalGRN;
		protected System.Web.UI.WebControls.Label lblTotalASN;
		protected System.Web.UI.WebControls.Label lblTotalShipping;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Panel pnlposel;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			//			if(!this.IsPostBack)
			//			{
			//				populateOTProducts();
			//			}

			if(!this.IsPostBack)
			{
				string pono=Request.Params["pono"];
				string product=Request.Params["product"];
				string nsn=Request.Params["nsn"];
				string dFlag=Request.Params["dFlag"];
				if (dFlag != null)
					pnlNIS.Visible = false;
				else
					pnlNIS.Visible = true;
				if(pono == null)
				{
					pnlposel.Visible =true;
					populateOTProducts();
								
				}
				if(pono != null)
				{
					
					pnlPrdDetl.Visible=true;
					bindGrnProduct(pono,nsn);
					bindASNProduct(pono,nsn);
					bindShplanProduct(pono,nsn);
					getProductdetls(product,pono);
				}
					
			}

		}
		/// <summary>
		/// This function returns the general product details such as NSN, product
		/// and description
		/// </summary>
		/// <param name="product"></param>
		/// <param name="pono"></param>
		private void getProductdetls(string product,string pono)
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			DataSet dsOTProducts = dal.OTgetproductdetls_DS(product,pono);
			Datagrid4.DataSource = dsOTProducts.Tables["pvtb"].DefaultView;
			Datagrid4.DataBind();
		}

		/// <summary>
		/// Returns the GRN details of a product and binds it with a datagrid
		/// </summary>
		/// <param name="selpo"></param>
		/// <param name="nsn"></param>
		private void bindGrnProduct(string selpo,string nsn)
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			DataSet dsOTProducts = dal.OTPrdDetlGrn_DS(selpo,nsn);
			DataGrid.DataSource = dsOTProducts.Tables["pvtblprdetls"].DefaultView;
			lblTotalGRN.Text = "Total GRN (" + dsOTProducts.Tables["pvtblprdetls"].Rows.Count + ")";
			DataGrid.DataBind();
			
		}

		/// <summary>
		/// Returns the ASN details of a product and binds it with a datagrid
		/// </summary>
		/// <param name="selpo"></param>
		/// <param name="nsn"></param>
		private void bindASNProduct(string selpo,string nsn)
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			DataSet dsOTProducts = dal.OTPrdDetlASN_DS(selpo,nsn);
			Datagrid5.DataSource = dsOTProducts.Tables["pvtblpr"].DefaultView;
			lblTotalASN.Text = "Total ASN (" + dsOTProducts.Tables["pvtblpr"].Rows.Count + ")";
			Datagrid5.DataBind();

		}

		/// <summary>
		/// Returns the shipping plan details of a product and binds it with a datagrid
		/// </summary>
		/// <param name="selpo"></param>
		/// <param name="nsn"></param>
		private void bindShplanProduct(string selpo,string nsn)
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			DataSet dsOTProducts = dal.OTPrdDetlPlan_DS(selpo,nsn);
			Datagrid3.DataSource = dsOTProducts.Tables["pvtbl"].DefaultView;
			lblTotalShipping.Text = "Total Shipping (" + dsOTProducts.Tables["pvtbl"].Rows.Count + ")";
			Datagrid3.DataBind();
		}

		/// <summary>
		/// When this page is used as a standalone page the user selects a product
		/// and sees the shipping  plan,asn and grn details
		/// </summary>
		private void populateOTProducts()
		{
			dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
			
			System.Data.DataSet dsTitle = dal.OTProduct_DS();
			cboProducts.DataSource = dsTitle.Tables["tblProducts"];
			cboProducts.DataTextField = "PO_NO";
			cboProducts.DataValueField = "PO_NO";
			cboProducts.DataBind();
		}
		

		private void cmdContinue_Click(object sender, System.EventArgs e)
		{
			string selpo=cboProducts.SelectedValue.ToString();
			pnlPrdDetl.Visible=true;
			
			//	bindGrnProduct(selpo);
			//	bindASNProduct(selpo);
			//	bindShplanProduct(selpo);

		
		}

		protected void Datagrid5_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			
		}

		protected void Datagrid5_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{				
				string asnno=e.Item.Cells[0].Text;
				
				LinkButton btnDetl=(LinkButton) e.Item.Cells[5].Controls[0];
				//btnDetl.Attributes.Add("onclick", "javascript:window.open(\"PVVIEWASN.aspx?asnno="+asnno+"\", null, \"top =300, left=300,height=275,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = yes, scrollbars=yes\")");
				btnDetl.Attributes.Add("onclick", "javascript:window.open(\"PVVIEWASN.aspx?asnno=" +asnno+ " \",'page',\" top =300 , left=0,height=200,width=1000,toolbar=no, menubar=no, location=no, directories=no, resizable = yes, scrollbars=yes\")");
				//btnDetl.Attributes.Add("onclick", "javascript:window.open(\"PVVIEWASN.aspx?pono="+pono+"&product="+product+"\")");
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
			this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
