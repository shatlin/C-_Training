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
	/// to call pvgrn_pop proceducre.
	/// This procedure loads all letest grns from CS3
	/// </summary>
	public class PVGRNEXTREFRESH : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdRefresh;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// Clicking refresh button calls this function to refresh the
		/// GRN extraction
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdRefresh_Click(object sender, System.EventArgs e)
		{
			dbRefresh  dal=new dbRefresh();
			string errorDetl=dal.Refresh("bmmi.pvgrn_pop");
			if (errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				dal.rollbackTrans ();
			}
			else
			{
				lblError.Text ="GRN Extraction Refreshed";
				dal.commitTrans ();
	
			}
			dal.closedBConnection ();
		}
	}
}
