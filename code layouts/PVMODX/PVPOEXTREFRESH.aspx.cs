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
	/// Calling a procedure to extract latest Purchase Orders.
	/// </summary>
	public class PVPOEXTREFRESH : System.Web.UI.Page
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
			//this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);

		}
		#endregion


		/// <summary>
		/// When the user clicks Refresh Button the procedure
		/// pvpo_pop is invoked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdRefresh_Click(object sender, System.EventArgs e)
		{

			dbRefresh  dal=new dbRefresh();
			string errorDetl=dal.Refresh("bmmi.pvpo_pop");
			if (errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				dal.rollbackTrans ();
			}
			else
			{
				lblError.Text ="PO Extraction Refreshed";
				dal.commitTrans ();
	
			}
			dal.closedBConnection ();

			
		}
	}
}
