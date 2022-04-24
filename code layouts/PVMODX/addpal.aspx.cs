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
using System.Data.OleDb;

namespace PV
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class addpal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.TextBox txtPalletteType;
		protected System.Web.UI.WebControls.Label lblPalletteType;
		protected System.Web.UI.WebControls.Label lblDodaacSpl;
		protected System.Web.UI.WebControls.DropDownList CboDodaacSpl;
		protected System.Web.UI.WebControls.DropDownList CboCntrSize;
		protected System.Web.UI.WebControls.DropDownList CboCntrType;
		protected System.Web.UI.WebControls.Label lblCntrSize;
		protected System.Web.UI.WebControls.Label lblCntrType;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DropDownList CboStatus;
		protected System.Web.UI.WebControls.TextBox txtMaxPallettes;
		protected System.Web.UI.WebControls.Button cmdSavePal;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Label lblMaxPallettes;
		
 
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			// bindGrid();
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
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			
			
			Utilities utl = new Utilities();


			if(!utl.ValidateNumber(txtMaxPallettes.Text))
			{
				lblError.Text = "Maximum Pallettes should be number";
				return;
			}

			DBLayer dal = new DBLayer();
			int iRetVal = dal.addpallette(txtPalletteType.Text, CboDodaacSpl.SelectedValue.ToString(), CboCntrSize.SelectedValue.ToString(),  CboCntrType.SelectedValue.ToString(), txtMaxPallettes.Text, CboStatus.SelectedValue.ToString());
			if (iRetVal == 0)
				lblError.Text = "Records are not inserted properly";
			else
				lblError.Text = "Pallette successfuly added.";

			clearAll();
		}


		private void clearAll()
		{
			
			txtPalletteType.Text = "";
			txtMaxPallettes.Text = "";
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			clearAll();
			lblError.Text = "";
		}

		


	}
}
