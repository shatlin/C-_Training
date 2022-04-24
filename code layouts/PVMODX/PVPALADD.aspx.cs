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

namespace PVMODX
{
	
	/// <summary>
	/// Adds a palette record
	/// </summary>
	public class PVPALADD : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList CboPalletteType;
		protected System.Web.UI.WebControls.TextBox txtOther;
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
			this.CboCntrSize.SelectedIndexChanged += new System.EventHandler(this.CboCntrSize_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		
		/// <summary>
		/// When user presses save button all data entered is validated
		/// and if validation is successful the data is inserted into the database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			
			
			Utilities utl = new Utilities();
			int CntrSize=0;

			if(!utl.ValidateNumber(txtMaxPallettes.Text))
			{
				lblError.Text = "Maximum Pallettes should be number";
				return;
			}
			
			if(!utl.ValidateNumber(txtOther.Text))
			{
				lblError.Text = "The size of the container must be number";
				return;
			}

			if (CboCntrSize.SelectedValue=="O")
				CntrSize=Convert.ToInt32(txtOther.Text); 
			else
				CntrSize=Convert.ToInt32(CboCntrSize.SelectedValue); 

			DBLayer dal = new DBLayer();
			int iRetVal = dal.addpallette(
				CboPalletteType.SelectedValue.ToString(), 
				CboDodaacSpl.SelectedValue.ToString(),
				CntrSize,
				CboCntrType.SelectedValue.ToString(),
				Convert.ToInt32( txtMaxPallettes.Text), 
				CboStatus.SelectedValue.ToString()
				);
			if (iRetVal == 0)
				lblError.Text = "Records are not inserted properly";
			else
				lblError.Text = "Pallette successfuly added.";

			clearAll();
		}



		/// <summary>
		/// Sets the textboxes' values to empty string
		/// </summary>
		private void clearAll()
		{
			txtMaxPallettes.Text = "";
		}

		/// <summary>
		///  if cancel button is pressed then the values entered are cleared
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			clearAll();
			lblError.Text = "";
		}

		/// <summary>
		/// if container size is other than 20 or 40 then a text box is shown
		/// so that user can enter the size manually
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CboCntrSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (CboCntrSize.SelectedValue == "O")
			{
				txtOther.Visible = true;
				txtOther.Text ="";
			}
			else
			{
				txtOther.Visible = false;
				txtOther.Text ="";
			}
		}

	
	}
}
