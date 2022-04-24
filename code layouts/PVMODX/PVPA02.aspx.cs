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

namespace PV
{
	/// <summary>
	/// Summary description for PVPA02.
	/// </summary>
	public class PVPA02 : System.Web.UI.Page
	{
		protected string NSNs;
		protected System.Web.UI.WebControls.Button cmdBack;
		protected string SUPs;
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected string SUPName;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{

				DBLayer dal = new DBLayer();
				//dal.getPVPAnalysis_DS(NSNs,SUPs,SUPName);
				DataSet dsAnalysis = dal.getPVPAnalysis_DS(NSNs,SUPs,SUPName);
				dgResults.DataSource = dsAnalysis.Tables["tblPVAnalysis"].DefaultView;
				dgResults.DataBind();

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
			this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdBack_Click(object sender, System.EventArgs e)
		{
			// Response.Write("<script language='javascript'>window.history.back();</script>");
			//Server.Transfer("~/PVPA01.aspx");
		}

		private void populateAnalysis()
		{
			DBLayer dal = new DBLayer();

			//lblTotalRecords.Text = "Listed " + dsAnalysis.Tables[0].Rows.Count + " Products";
			//if(Convert.ToUInt32(dsAnalysis.Tables[0].Rows.Count) >0)
			//{
			//	cmdContinueTop.Visible = true;
			//	cmdContinueBottom.Visible = true;
			//}
			//DataGrid2.DataBind();

		}
	}
}
