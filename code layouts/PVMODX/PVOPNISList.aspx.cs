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
	/// Summary description for PVOPNISList.
	/// </summary>
	public class PVOPNISList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblOrder;
		protected System.Web.UI.WebControls.TextBox txtOrderNo;
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
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Panel pnlStatus;
		protected System.Web.UI.WebControls.Label lblTotalProduct;
		protected System.Web.UI.WebControls.Button cmdPrint;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.WebControls.Label lblError;
		protected string order_no;
		protected System.Web.UI.WebControls.Button cmdGenerate;

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
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void Page_Load(object sender, System.EventArgs e)
		{
			order_no = Request.Params["order_no"];
			if(!this.IsPostBack)
				if(order_no != null)
				{
					DataSet dsOrderDetail = new DataSet();
					txtOrderNo.Text = order_no;
					viewNISList();
				}
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
				string ord=e.Item.Cells[2].Text;
				string all=e.Item.Cells[3].Text;
				string bal=e.Item.Cells[4].Text;
				string pName = e.Item.Cells[5].Text;
				string unit=e.Item.Cells[6].Text;
				string ratio=e.Item.Cells[7].Text;
				string ordNo = txtOrderNo.Text.Trim();
				LinkButton btnDetails=(LinkButton) e.Item.Cells[16].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVOPNISAlternatives.aspx?warehouse="+warehouse+"&product="+product+"&ord="+ord+"&all="+all+"&bal="+bal+"&pName="+pName+"&ordNo="+ordNo+"&unit="+unit+"&ratio="+ratio+"\", null, \"top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes\")");
			}
		}

		protected string getNavigationURL(string nsn, string product)
		{
			//return "javascript:window.open(\"PVOPNISAlternatives.aspx?warehouse="+warehouse+"&product="+product+"&ord="+ord+"&all="+all+"&bal="+bal+"&pName="+pName+"&ordNo="+ordNo+"&unit="+unit+"&ratio="+ratio+"\", null, \"top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes\");
			// return "javascript:window.open(\"PVOPNISAlternatives.aspx?product="+product+"&ord="+ord+"\", yes, \"top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes\")";
			return "PVOTPRDDETL.aspx?pono="+txtOrderNo.Text+"&nsn="+nsn.Trim()+"&product="+product.Trim()+"&dFlag=1";
		}


		private void cmdView_Click(object sender, System.EventArgs e)
		{
			viewNISList();
		}


		private void viewNISList()
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
					txtDateReceived.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Received"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtDateEntered.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Entered"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtRDD.Text = Convert.ToDateTime(dsOrder.Tables["tblOrder"].Rows[0]["Date_Required"].ToString().Trim()).ToString("dd-MMM-yyyy");
					txtCustomerCode.Text = dsOrder.Tables["tblOrder"].Rows[0]["Customer"].ToString().Trim();
					txtAddress1.Text = dsOrder.Tables["tblOrder"].Rows[0]["Address1"].ToString().Trim();
					txtAddress2.Text = dsOrder.Tables["tblOrder"].Rows[0]["Address2"].ToString().Trim();

					DataSet dsOrderDetail = new DataSet();
					
					dsOrderDetail = dal.getOrderDetail_DS(txtOrderNo.Text.Trim().ToUpper(),"","", "BackOrder");
					lblTotalProduct.Text = "Total Product (" + dsOrderDetail.Tables["tblOrderDetail"].Rows.Count + ")";
					DataGrid2.DataSource = dsOrderDetail.Tables["tblOrderDetail"].DefaultView;
					ViewState[this.ToString() + "_Ds"] = dsOrderDetail;
					DataGrid2.DataBind();
					cmdGenerate.Enabled = true;
				}
				else
				{
					pnlStatus.Visible=false;
					lblError.Text = "Invalid Order #";

				}


			}

		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			// Response.Write("<script language='javascript'>window.print();</script>");
			Response.Redirect("NISSubRrt.aspx?order_no="+txtOrderNo.Text);
			//Response.Redirect("http://venkatesh/PVMODX/NISSubRrt.aspx?order_no="+txtOrderNo.Text);
			//"javascript:window.open(\"PVOPNISAlternatives.aspx?warehouse="+warehouse+"&product="+product+"&ord="+ord+"&all="+all+"&bal="+bal+"&pName="+pName+"&ordNo="+ordNo+"&unit="+unit+"&ratio="+ratio+"\", null, \"top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes\")");
		}

		private void cmdGenerate_Click(object sender, System.EventArgs e)
		{
			cmdGenerate.Enabled = false;
			lblError.Text = "It's on processing.. Please do not click any button"; 
			generateNISSubstitutes();
		}

		private void generateNISSubstitutes()
		{
			string errValue = "";
			if (txtOrderNo.Text.Trim().Length > 0)
			{
				DBLayer dal = new DBLayer();
				DataSet dsOrderDetail = (DataSet) ViewState[this.ToString() + "_Ds"];
			//	DataSet dsOrderDetail = dal.getOrderDetail_DS(txtOrderNo.Text.Trim().ToUpper(),"","", "BackOrder");
				try
				{
					foreach(DataRow dRow in dsOrderDetail.Tables["tblOrderDetail"].Rows)
					{
						string wh = dRow["warehouse"].ToString().ToUpper();
						string product = dRow["product"].ToString().ToUpper().Trim();
						DataSet dsNISDetail = new DataSet();
						dsNISDetail = dal.getSubstitution_DS(txtOrderNo.Text.ToUpper().Trim(),wh, product);
					}
				}
				catch (Exception ex)
				{	
					errValue = ex.Message;
				}
				lblError.Text = errValue;
			}

		}
/*
		private void bindSubstitutions()
		{
			DataSet dsNISDetail = new DataSet();
			dsNISDetail = dal.getSubstitution_DS(ordNo.ToUpper(),warehouse.ToUpper(), product.ToUpper());
			lblTotalProduct.Text = "Total Product (" + dsNISDetail.Tables["tblNISSub"].Rows.Count + ")";
			dgResults.DataSource = dsNISDetail.Tables["tblNISSub"].DefaultView;
			dgResults.DataBind();
		}
*/
	}
}
