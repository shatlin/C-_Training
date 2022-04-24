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
	/// Summary description for PVOPSAStatusDetail.
	/// </summary>
	public class PVOPSAStatusDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblProduct;
		protected System.Web.UI.WebControls.Label txtProduct;
		protected System.Web.UI.WebControls.Label lblProdName;
		protected System.Web.UI.WebControls.Label txtProdName;
		protected System.Web.UI.WebControls.Button cmdPrint;
		protected System.Web.UI.WebControls.Panel pnlStatus;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtProductName;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.WebControls.Panel pnlStatusDetail;
		protected System.Web.UI.WebControls.Panel pnlMenu;
		protected System.Web.UI.WebControls.Label lblTotalProduct;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdClose;
		protected System.Web.UI.WebControls.Label lblProductName;
		protected MetaBuilders.WebControls.ComboBox cboProductName;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		DBLayer dal = new DBLayer();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				string warehouse=Request.Params["warehouse"];
				string product=Request.Params["product"];
				
				if(warehouse == null && product == null)
				{
					pnlMenu.Visible = true;
					pnlStatus.Visible = true;
					cmdClose.Visible = false;
					bindProducts();
				}
				if(warehouse != null && product != null)
				{
					bindOrderDetails(warehouse, product);
					pnlStatusDetail.Visible = true;
				}
					
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
			this.cboProductName.TextChanged += new System.EventHandler(this.cboProductName_TextChanged);
			this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.cboProductName_SelectedIndexChanged);
			this.cmdView.Click += new System.EventHandler(this.cmdView_Click);
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void bindProducts()
		{
			DataSet dsProducts = dal.getProductList_DS();
			foreach(DataRow dRow in dsProducts.Tables["tblProductList"].Rows)
			{
				string prodID = (string) dRow["products"].ToString();
				string prodDesc = (string) dRow["dscp_desc"].ToString().Trim() + "=>" + prodID.Trim();
				cboProductName.Items.Add(new ListItem(prodDesc.Trim(), prodID.Trim()));
			}

		}

		private void bindOrderDetails(string warehouse, string product)
		{
			DBLayer dal = new DBLayer();
			DataSet dsProducts = dal.getProductList_DS(warehouse, product);
			if(dsProducts.Tables["tblProductList"].Rows.Count > 0) 
			{
				lblError.Text = "";
				//pnlMenu.Visible = true;
				//pnlStatus.Visible = true;
				pnlStatusDetail.Visible = true;
				//cmdClose.Visible = false;
				txtProduct.Text = warehouse + product;
				txtProdName.Text = dsProducts.Tables["tblProductList"].Rows[0]["dscp_desc"].ToString().Trim();
				DataSet dsOrderDetail = dal.getOrderDetail_DS(warehouse, product);
				DataGrid2.DataSource = dsOrderDetail.Tables["tblOrderDetail"].DefaultView;
				lblTotalProduct.Text = "Total Product (" + dsOrderDetail.Tables["tblOrderDetail"].Rows.Count + ")";
				DataGrid2.DataBind();
			}
			else
			{
				lblError.Text = "Invalid Product";
				//pnlMenu.Visible = false;
				//pnlStatus.Visible = false;
				pnlStatusDetail.Visible = false;
				cmdClose.Visible = true;
			}
		}
//getStatus(Convert.ToString(DataBinder.Eval(Container.DataItem, "status")))

		protected string getStatus(string statusNo)
		{
			Utilities utl = new Utilities();
			return utl.getStatus(statusNo);
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.close();</script>");
		}

		protected void DataGrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid2.CurrentPageIndex = e.NewPageIndex;
			string warehouse=Request.Params["warehouse"];
			string product=Request.Params["product"];
			bindOrderDetails(warehouse, product);

		}
		
		
		private void PrintToExcel()
		{
			Response.Clear();
			Response.Buffer=true;
			Response.Charset="";
			Response.ContentType="application/vnd.ms-excel";
			System.IO.StringWriter strExcel=new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlExcel=new System.Web.UI.HtmlTextWriter(strExcel);
			DataGrid dgExcel=DataGrid2; //dgResults;
			dgExcel.GridLines=GridLines.None;
			dgExcel.HeaderStyle.Font.Bold=true;
			dgExcel.HeaderStyle.Font.Size=FontUnit.Parse("14px");
			dgExcel.HeaderStyle.BackColor=Color.Black;
			dgExcel.ItemStyle.BackColor=Color.LightGray;
			dgExcel.AlternatingItemStyle.BackColor=Color.White;

			// ClearControls(dgExcel);

			dgExcel.RenderControl(htmlExcel);
			
			Response.Write(strExcel.ToString());
			Response.End();
		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			// <PagerStyle Mode="NextPrev" HorizontalAlign="right" Font-Size="11px" Font-Names="Verdana" ForeColor="Black"
			// BackColor="White" NextPageText="Next " PrevPageText=" Prev" Position="bottom"></PagerStyle>
			// Response.Write("<script language='javascript'>window.print();</script>");
			// printCReport();
			string warehouse, product;
			if (pnlStatus.Visible == true)
			{
				warehouse = txtProductName.Text.Remove(2,(txtProductName.Text.Length - 2)).Trim();
				product = txtProductName.Text.Remove(0, 2).Trim();
			}
			else
			{
				warehouse=Request.Params["warehouse"];
				product=Request.Params["product"];
			}
			string strVal = "<script language='javascript'>";
			strVal += "window.open('";
			strVal += "PVOPSAStatusDetailRpt.aspx?warehouse="+warehouse+"&product="+product; 
			strVal += "');";
//, null, top =35, left=50,height=600,width=800,toolbar=no, menubar=no, location=no, directories=no, resizable = no, scrollbars=yes";
			strVal += "</script>";
			Response.Write(strVal);
			// PrintToExcel();
		}


		private void cmdView_Click(object sender, System.EventArgs e)
		{
			string warehouse="", product="";
			if(txtProductName.Text.Length > 0)
			{
				cboProductName.SelectedValue = txtProductName.Text;
				cboProductName.Text = cboProductName.SelectedItem.ToString();
				warehouse = txtProductName.Text.Remove(2,(txtProductName.Text.Length - 2)).Trim();
				product = txtProductName.Text.Remove(0, 2).Trim();
				bindOrderDetails(warehouse.ToUpper(), product);
			//	pnlStatusDetail.Visible = true;
			//	cmdClose.Visible = false;

			}
			else
			{
				//pnlStatusDetail.Visible = false;
			//	cmdClose.Visible = true;
			}
		}


		
		private void cboProductName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtProductName.Text = cboProductName.SelectedValue;
		}

		private void cboProductName_TextChanged(object sender, System.EventArgs e)
		{
			txtProductName.Text = cboProductName.SelectedValue;
		}

	}
}
