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
using eWorld.UI;


namespace PVMODX
{
	/// <summary>
	/// Summary description for PVASNETA.
	/// </summary>
	public class PVASNETA : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected System.Web.UI.WebControls.Label lblTotalASN;
		protected System.Web.UI.WebControls.Label lblError;
		DBLayer dal = new DBLayer();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
				bindASNETA();
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

		private void bindASNETA()
		{
			
			DataSet dsASNETA = new DataSet();
			dsASNETA = dal.getASNETA_DS();
			lblTotalASN.Text = "Total ASN (" + dsASNETA.Tables["pvasneta"].Rows.Count + ")";
			dgResults.DataSource = dsASNETA.Tables["pvasneta"].DefaultView;
			dgResults.DataBind();

		}

		protected void dgResults_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			bindASNETA();
		}

		protected void dgResults_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = -1;
			bindASNETA();
		}

		protected void dgResults_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{

			string asnNo =  e.Item.Cells[0].Text;
			DateTime sailDate = Convert.ToDateTime(e.Item.Cells[1].Text);
			eWorld.UI.CalendarPopup etaDate = (eWorld.UI.CalendarPopup) e.Item.FindControl("etaDate");

			if (etaDate.SelectedDate < sailDate)
			{
				lblError.Text = "ETA should not be less than Sail date";
				return;
			}

			
			string retVal = dal.updateASNETA(asnNo, etaDate.SelectedDate.ToString());
			lblError.Text = "";
			if (retVal.Length > 0)
			{
				lblError.Text = retVal;
				return;
			}

			((DataGrid)sender).EditItemIndex = -1;
			bindASNETA();

		}
	}
}
