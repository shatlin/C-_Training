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
	/// Summary description for PVVIEWASN.
	/// </summary>
	public class PVVIEWASN : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.DataGrid Datagrid3;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				string asnno=Request.Params["asnno"];
			//	asnno="8";
			//	bindASNheadView(asnno);
			//	bindASNdetlView(asnno);
			}

		}

		private void bindASNheadView(string asnno)
		{
		//	dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
		//	DataSet dsOTProducts = dal.ASNheadView_DS(asnno);
		//	Datagrid2.DataSource = dsOTProducts.Tables["pvasn"].DefaultView;
		//	Datagrid2.DataBind();
		}

		private void bindASNdetlView(string asnno)
		{
		//	dbOrdTrackingLayer dal = new dbOrdTrackingLayer();
		//	DataSet dsOTProducts = dal.ASNDetlView_DS(asnno);
		//	Datagrid3.DataSource = dsOTProducts.Tables["pvasndetl"].DefaultView;
		//	Datagrid3.DataBind();
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
	}
}
