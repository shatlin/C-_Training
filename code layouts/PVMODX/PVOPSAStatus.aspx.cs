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
	/// Summary description for PVOPSAStatus.
	/// </summary>
	public class PVOPSAStatus : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOrderNo;
		protected System.Web.UI.WebControls.TextBox txtOrderNo;
		protected System.Web.UI.WebControls.RadioButton rdbAllProducts;
		protected System.Web.UI.WebControls.RadioButton rdbBackorderProducts;
		protected System.Web.UI.WebControls.RadioButton rdbSingleProduct;
		protected System.Web.UI.WebControls.DropDownList cboProducts;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.HtmlControls.HtmlForm thisForm;
		protected System.Web.UI.WebControls.Panel pnlStatus;
		protected System.Web.UI.WebControls.Label lblOrder;
		protected System.Web.UI.WebControls.Label txtOrder;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label txtStatus;
		protected System.Web.UI.WebControls.Label lblDateReceived;
		protected System.Web.UI.WebControls.Label txtDateReceived;
		protected System.Web.UI.WebControls.Label lblAddress2;
		protected System.Web.UI.WebControls.Label txtAddress2;
		protected System.Web.UI.WebControls.Label lblCustomerCode;
		protected System.Web.UI.WebControls.Label txtCustomerCode;
		protected System.Web.UI.WebControls.Label lblAddress1;
		protected System.Web.UI.WebControls.Label txtAddress1;
		protected System.Web.UI.WebControls.Label lblRDD;
		protected System.Web.UI.WebControls.Label txtRDD;
		protected System.Web.UI.WebControls.Label lblDateEntered;
		protected System.Web.UI.WebControls.Label txtDateEntered;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Button cmdPrint;
		protected System.Web.UI.WebControls.TextBox txtProductName;
		protected System.Web.UI.WebControls.Label txtStatusAlert;
		protected System.Web.UI.WebControls.Label lblTotalProduct;
		protected System.Web.UI.WebControls.Label lblError;
		

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
			this.txtOrderNo.TextChanged += new System.EventHandler(this.txtOrderNo_TextChanged);
			this.rdbAllProducts.CheckedChanged += new System.EventHandler(this.rdbAllProducts_CheckedChanged);
			this.rdbBackorderProducts.CheckedChanged += new System.EventHandler(this.rdbBackorderProducts_CheckedChanged);
			this.rdbSingleProduct.CheckedChanged += new System.EventHandler(this.rdbSingleProduct_CheckedChanged);
			this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.DataGrid2.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_OnEditCommand);
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rdbSingleProduct_CheckedChanged(object sender, System.EventArgs e)
		{
			populateProducts();
			/*
			if (rdbSingleProduct.Checked == true)
			{
				populateProducts();
				cboProducts.Visible = true;
			}
			else
				cboProducts.Visible = false;
			*/
		}

		private void rdbBackorderProducts_CheckedChanged(object sender, System.EventArgs e)
		{
			populateProducts();
			// cboProducts.Visible = false;
		}

		private void rdbAllProducts_CheckedChanged(object sender, System.EventArgs e)
		{
			populateProducts();
			// cboProducts.Visible = false;
		}

		private void populateProducts()
		{
			if(txtOrderNo.Text.Length > 0)
			{
				if (rdbSingleProduct.Checked == true)
				{
					DBLayer dal = new DBLayer();
					System.Data.DataSet dsProduct = dal.Products_DS(txtOrderNo.Text.Trim().ToUpper()); // dal.Products_DS();
					cboProducts.DataSource = dsProduct.Tables["tblProducts"];
					cboProducts.DataTextField = "ProdName";
					cboProducts.DataValueField = "ProdName";
					cboProducts.DataBind();
					cboProducts.Visible = true;
					txtProductName.Visible =true;
					txtProductName.Text = "";
				}
				else
				{
					cboProducts.Visible = false;
					txtProductName.Visible = false;
				}
			}
		}



		private void txtOrderNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOrderNo.Text.Length > 0)
			{
				if (rdbSingleProduct.Checked == true)
				{
					populateProducts();
					cboProducts.Visible = true;
				}
				else
					cboProducts.Visible = false;
			}
		}

		private void cmdView_Click(object sender, System.EventArgs e)
		{
			if (txtOrderNo.Text.Trim().Length > 0)
			{
				DBLayer dal = new DBLayer();
				DataSet dsOrder = dal.orderList_DS(txtOrderNo.Text.Trim().ToUpper());		
				if(dsOrder.Tables["tblOrder"].Rows.Count > 0) 
				{
					lblError.Text = "";
					pnlStatus.Visible=true;
					txtOrder.Text = dsOrder.Tables["tblOrder"].Rows[0]["Order_No"].ToString().Trim();
					Utilities utl = new Utilities();
					txtStatus.Text = utl.getStatus(dsOrder.Tables["tblOrder"].Rows[0]["Status"].ToString().Trim());
					if(dsOrder.Tables["tblOrder"].Rows[0]["Status"].ToString().Trim() == "8" || dsOrder.Tables["tblOrder"].Rows[0]["Status"].ToString().Trim() == "9")
						txtStatusAlert.Text = "Alert !!!!!!!!!!!!!";
					else
						txtStatusAlert.Text = "";
					txtDateReceived.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Received"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtDateEntered.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Entered"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtRDD.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Required"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtCustomerCode.Text = dsOrder.Tables["tblOrder"].Rows[0]["Customer"].ToString().Trim();
					txtAddress1.Text = dsOrder.Tables["tblOrder"].Rows[0]["Address1"].ToString().Trim();
					txtAddress2.Text = dsOrder.Tables["tblOrder"].Rows[0]["Address2"].ToString().Trim();

					string whVal="", prodVal="";
					if(cboProducts.SelectedIndex >= 0)
					{
						whVal = cboProducts.SelectedItem.Text.Remove(2,(cboProducts.SelectedItem.ToString().Length - 2)).Trim();
						prodVal = cboProducts.SelectedItem.Text.Remove(0, 2).Trim();
					}
					if(txtProductName.Text.Length > 0)
					{
						whVal = txtProductName.Text.Remove(2,(txtProductName.Text.Length - 2)).Trim();
						prodVal = txtProductName.Text.Remove(0, 2).Trim();
					}

				
					DataSet dsOrderDetail = new DataSet();
					if (rdbAllProducts.Checked == true)
						dsOrderDetail = dal.getOrderDetail_DS(txtOrderNo.Text.Trim().ToUpper(),"","","");

					if (rdbBackorderProducts.Checked == true)
						dsOrderDetail = dal.getOrderDetail_DS(txtOrderNo.Text.Trim().ToUpper(),"","", "BackOrder");
				
				
					if (rdbSingleProduct.Checked == true)
						dsOrderDetail = dal.getOrderDetail_DS(txtOrderNo.Text.Trim().ToUpper(),whVal.ToUpper(),prodVal, "");

					if (rdbAllProducts.Checked == false && rdbBackorderProducts.Checked == false && rdbSingleProduct.Checked == false)
					{
						lblError.Text = "Please select the criteria type";
						return;
					}
					DataGrid2.DataSource = dsOrderDetail.Tables["tblOrderDetail"].DefaultView;
					lblTotalProduct.Text = "Total Product (" + dsOrderDetail.Tables["tblOrderDetail"].Rows.Count + ")";
					DataGrid2.DataBind();
				}
				else
					lblError.Text = "Invalid Order #";

			}
			else
				lblError.Text = "Order # should not be empty";
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			txtOrderNo.Text = "";
			rdbSingleProduct.Checked = false;
			rdbBackorderProducts.Checked = false;
			rdbAllProducts.Checked = true;
			cboProducts.Items.Clear();
			cboProducts.Visible = false;
			txtOrder.Text = "";
			txtDateReceived.Text = "";
			txtDateEntered.Text = "";
			txtRDD.Text = "";
			txtCustomerCode.Text = "";
			txtAddress1.Text = "";
			txtAddress2.Text = "";
			txtStatus.Text = "";
			pnlStatus.Visible = false;
			lblError.Text = "";
			txtProductName.Text = "";
			txtProductName.Visible = false;
		}




		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			//<PagerStyle Mode="NextPrev" HorizontalAlign="right" Font-Size="11px" Font-Names="Verdana" ForeColor="Black"
			//BackColor="White" NextPageText="Next " PrevPageText=" Prev" Position="bottom"></PagerStyle>
		}

		protected void DataGrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{				
				string warehouse=e.Item.Cells[0].Text;
				string product=e.Item.Cells[1].Text;
				LinkButton btnDetails=(LinkButton) e.Item.Cells[13].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVOPSAStatusDetail.aspx?warehouse="+warehouse+"&product="+product+"\", null, \"top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes\")");
			}
		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.print();</script>");
		}

	}
}
