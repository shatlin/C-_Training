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
	/// Summary description for MainListItem.
	/// </summary>
	public class MainListItem : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				bindProduct();
			}
		}


		private void bindProduct()
		{
			DBLayer dal = new DBLayer();
			DataSet dsOrderDetail = new DataSet();
			dsOrderDetail = dal.getOrderDetail_DS("E06797","","","");
			DataGrid2.DataSource = dsOrderDetail.Tables["tblOrderDetail"].DefaultView;
			DataGrid2.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			//if (DataGrid2.EditItemIndex != -1)
			//{
			//	((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			//	bindProduct();
			//}
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


	}
}
