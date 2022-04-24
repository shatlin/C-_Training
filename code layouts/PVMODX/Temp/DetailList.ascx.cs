namespace PVMODX.Temp
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Threading;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for DetailList.
	/// </summary>
	public class DetailList : System.Web.UI.UserControl
	{

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Write div tag to the page that will contain the text for the progress bar.
			Response.Write("<div id='mydiv' >");
			Response.Write("_");
			Response.Write("</div>");
			Response.Write("<script>mydiv.innerText = '';</script>");

			// Javascript to do the work of the progress bar.
			// There are three functions.
			// 1. ShowWait: Sets text of the div tag to "Loading" followed by 10 periods ".........."
			// 2. StartShowWait: Calls the ShowWait function every second and make the div tag visible.
			// 3. HideWait: Hides the div tag when the page is done loading. It is called from a script block
			// that you need to add to the HTML page as the last element.
			Response.Write("<script language=javascript>;");
			Response.Write("var dots = 0;var dotmax = 10;function ShowWait()");
			Response.Write("{var output; output = 'Loading';dots++;if(dots>=dotmax)dots=1;");
			Response.Write("for(var x = 0;x < dots;x++){output += '.';}mydiv.innerText = output;}");
			Response.Write("function StartShowWait(){mydiv.style.visibility = 'visible'; window.setInterval('ShowWait()',1000);}");
			Response.Write("function HideWait(){mydiv.style.visibility = 'hidden';window.clearInterval();}");
			Response.Write("StartShowWait();</script>");

			Response.Flush();

			// This really doesn't serve any purpose, other than to help with the sample code.  After 10 seconds, the page will stop loading and the progress bar will disappear.
			Thread.Sleep(10000);

			/*
			warehouse = txtProductName.Text.Remove(2,(txtProductName.Text.Length - 2)).Trim();
			product = txtProductName.Text.Remove(0, 2).Trim();
			bindOrderDetails(warehouse.ToUpper(), product);
			*/
		}
/*
		private void bindOrderDetails(string warehouse, string product)
		{
			DBLayer dal = new DBLayer();
			DataSet dsProducts = dal.getProductList_DS(warehouse, product);
			DataSet dsOrderDetail = dal.getOrderDetail_DS(warehouse, product);
			DataGrid2.DataSource = dsOrderDetail.Tables["tblOrderDetail"].DefaultView;
			DataGrid2.DataBind();
			
		}


		private string _productID;
		public string Product
		{
			get
			{
				return _productID;
			}
			set
			{
				_productID=value;
				string warehouse = _productID.Remove(2,(_productID.Length - 2)).Trim();
				string product = _productID.Remove(0, 2).Trim();
				bindOrderDetails(warehouse.ToUpper(), product);
			}
		}
*/
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
