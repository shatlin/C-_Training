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
	/// Calculates cases,pallettes and containers required for an Order
	/// </summary>
	public class PVPALETCALC : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdView;
		protected System.Web.UI.WebControls.TextBox txtOrderNo;
		protected System.Web.UI.WebControls.Button cmdPrint;
		protected System.Web.UI.WebControls.Label lblContainersRequired;
		protected System.Web.UI.WebControls.Label lblPallettesRequired;
		protected System.Web.UI.WebControls.Label lblDateReceived;
		protected System.Web.UI.WebControls.Label OrderNo;
		protected System.Web.UI.WebControls.Label lblOrderNo;
		protected System.Web.UI.WebControls.Label lblTotalWeight;
		protected System.Web.UI.WebControls.Label Weight;
		protected System.Web.UI.WebControls.Label TotalCases;
		protected System.Web.UI.WebControls.Label TotalPallettes;
		protected System.Web.UI.WebControls.Label totalcontainers;
		protected System.Web.UI.WebControls.Label lblCustomer;
		protected System.Web.UI.WebControls.Label lblDateEntered;
		protected System.Web.UI.WebControls.Label lblDateRequired;
		protected System.Web.UI.WebControls.Label Customer;
		protected System.Web.UI.WebControls.Label DateEntered;
		protected System.Web.UI.WebControls.Label DateRequired;
		protected System.Web.UI.WebControls.Label lblOrder;

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdView_Click(object sender, System.EventArgs e)
		{
			palletteCalc();
		}

		/// <summary>
		/// Calculates cases,pallettes and containers required for an Order
		/// </summary>
		/// <returns></returns>
		public string palletteCalc()
		{
			string errorDetl="";
			string totalcases="";
			string orderNo=txtOrderNo.Text.Trim();
			
			
			//check if order number is entered and order number entered is valid
			if (orderNo.Length ==0)
			{
				lblError.Text ="Please Enter Order Number";
				return "";
			}

			dbPalletteCalc pCal=new dbPalletteCalc ();
			errorDetl=pCal.checkOrderNo(orderNo);
			
			if (errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				pCal.rollbackTrans ();
				pCal.closedBConnection ();
				return "";
			}

			//calculate the total cases

			
			totalcases=pCal.getTotalCases(orderNo);
			TotalCases.Text =totalcases;
			return "";
		
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
