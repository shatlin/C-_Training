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
	/// Adds a case record
	/// </summary>
	public class PVCASEADD : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblPalletteType;
		protected System.Web.UI.WebControls.DropDownList CboPalletteType;
		protected System.Web.UI.WebControls.Label lblDodaacSpl;
		protected System.Web.UI.WebControls.DropDownList CboDodaacSpl;
		protected System.Web.UI.WebControls.Label lblCntrSize;
		protected System.Web.UI.WebControls.DropDownList CboCntrSize;
		protected System.Web.UI.WebControls.TextBox txtOther;
		protected System.Web.UI.WebControls.Label lblCntrType;
		protected System.Web.UI.WebControls.DropDownList CboCntrType;
		protected System.Web.UI.WebControls.Label lblMaxPallettes;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DropDownList CboStatus;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.TextBox txtMaxCases;
		protected System.Web.UI.WebControls.Label lblPalLength;
		protected System.Web.UI.WebControls.TextBox txtPalLength;
		protected System.Web.UI.WebControls.Label lblPalWidth;
		protected System.Web.UI.WebControls.TextBox txtPalWidth;
		protected System.Web.UI.WebControls.Label lblPalHeight;
		protected System.Web.UI.WebControls.TextBox txtPalHeight;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.Label lblError;
	
	
 
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//populateDodaacspl();
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
			this.CboCntrSize.SelectedIndexChanged += new System.EventHandler(this.CboCntrSize_SelectedIndexChanged);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
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

			if(!utl.ValidateNumber(txtMaxCases.Text))
			{
				lblError.Text = "Maximum Cases should be number";
				return;
			}
			
			if(txtOther.Visible==true && !utl.ValidateNumber(txtOther.Text))
			{
				lblError.Text = "container size  must be a  number and non empty";
				return;
			}

			if(!utl.ValidateNumber(txtPalLength.Text))
			{
				lblError.Text = "Pallette Length must be number";
				return;
			}
			if(!utl.ValidateNumber(txtPalWidth.Text))
			{
				lblError.Text = "Pallette Width must be number";
				return;
			}
			if(!utl.ValidateNumber(txtPalHeight.Text))
			{
				lblError.Text = "Pallette Height must be number";
				return;
			}

			if (CboCntrSize.SelectedValue=="O")
				CntrSize=Convert.ToInt32(txtOther.Text); 
			else
				CntrSize=Convert.ToInt32(CboCntrSize.SelectedValue); 

			DBLayer dal = new DBLayer();
			int iRetVal = dal.addcase(
				CboPalletteType.SelectedValue.ToString(), 
				CboDodaacSpl.SelectedValue.ToString(),
				CntrSize,
				CboCntrType.SelectedValue.ToString(),
				Convert.ToInt32(txtPalLength.Text), 
				Convert.ToInt32(txtPalWidth.Text), 
				Convert.ToInt32(txtPalHeight.Text), 
				Convert.ToInt32(txtMaxCases.Text), 
				CboStatus.SelectedValue.ToString()
				);
			if (iRetVal == 0)
				lblError.Text = "Records are not inserted properly";
			else
				lblError.Text = "Cases successfuly added.";

			clearAll();
		}

		/// <summary>
		/// Sets the textboxes' values to empty string
		/// </summary>
		private void clearAll()
		{
			txtMaxCases.Text  = "";
			txtPalLength.Text = "";
			txtPalWidth.Text  = "";
			txtPalHeight.Text = "";
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
		/// <summary>
		/// The combo box CboDodaacSpl is loaded with values from 
		/// the tablel pvpaletdodac
		/// </summary>
		private void populateDodaacspl()
		{
			DBLayer dal = new DBLayer();
			System.Data.DataSet dsTitle = dal.Dodaac_DS();
			CboDodaacSpl.DataSource = dsTitle.Tables["PVPALETDODAC"];
			CboDodaacSpl.DataTextField = "DISP_NAME";
			CboDodaacSpl.DataValueField = "DODAAC_SPECIAL";
			CboDodaacSpl.DataBind();
		}
	
	}
}
