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
	/// Modifying a Case.
	/// </summary>
	public class ModifyCase : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
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
		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				biindCase();
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

			this.DataGrid2.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid2_ItemCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// binds datagrid2 to all records from pvcasepalet table
		/// </summary>
		private void biindCase()
		{
			DBLayer dal = new DBLayer();
			DataSet dsCase = dal.case_DS();
			DataGrid2.DataSource = dsCase.Tables["pvcasepalet"].DefaultView;
			DataGrid2.DataBind();
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			biindCase();
			string caspalid = e.Item.Cells[0].Text;
			//lblcaspalid.Text = caspalid;
		}
		/// <summary>
		/// When the update  link button is pressed the data
		/// entered by the user is validated and then saved
		/// into the table pvcasepalet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid2_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{
			
			int caspalid = Convert.ToInt32 (e.Item.Cells[0].Text);

			DropDownList CboPalletteType = (DropDownList) e.Item.FindControl("CboPalletteType");
			string PalletteType = CboPalletteType.SelectedValue.ToString();
			
			DropDownList CboDodaacSpl = (DropDownList) e.Item.FindControl("CboDodaacSpl");
			string DodaacSpl = CboDodaacSpl.SelectedValue.ToString();
			
			DropDownList CboCntrSize = (DropDownList) e.Item.FindControl("CboCntrSize");
			string CntrSize = CboCntrSize.SelectedValue;
			
			DropDownList CboCntrType = (DropDownList) e.Item.FindControl("CboCntrType");
			string CntrType		= CboCntrType.SelectedValue.ToString();
			
			TextBox txtMaxCases = (TextBox) e.Item.FindControl("txtMaxCases");
			string MaxCases = txtMaxCases.Text;

			TextBox txtPalLength = (TextBox) e.Item.FindControl("txtPalLength");
			string PalLength = txtPalLength.Text;

			TextBox txtPalWidth = (TextBox) e.Item.FindControl("txtPalWidth");
			string PalWidth = txtPalWidth.Text;

			TextBox txtPalHeight = (TextBox) e.Item.FindControl("txtPalHeight");
			string PalHeight = txtPalHeight.Text;
			
			DropDownList CboStatus = (DropDownList) e.Item.FindControl("CboStatus");
			string status = CboStatus.SelectedValue.ToString();

				
			TextBox txtOther = (TextBox) e.Item.FindControl("txtOther");
			string Other = txtOther.Text;
				
			Utilities utl = new Utilities();
			
			if(CboCntrSize.SelectedValue !="O" && !utl.ValidateNumber(CntrSize.Trim()))
			{
				lblError.Text = "Container Size should be number";
				return;
			}

			if(!utl.ValidateNumber(MaxCases.Trim()))
			{
				lblError.Text = "Maximum cases should be number";
				return;
			}

			if(!utl.ValidateNumber(PalLength.Trim()))
			{
				lblError.Text = "pallette length should be number";
				return;
			}
			if(!utl.ValidateNumber(PalWidth.Trim()))
			{
				lblError.Text = "pallette Width should be number";
				return;
			}
			if(!utl.ValidateNumber(PalHeight.Trim()))
			{
				lblError.Text = " pallette Height should be number";
				return;
			}

			if(txtOther.Visible==true && !utl.ValidateNumber(Other))
			{
				lblError.Text = "container size  must be a  number and non empty";
				return;
			}
						
			if (CboCntrSize.SelectedValue=="O")
				CntrSize=Other; 
			else
				CntrSize=CboCntrSize.SelectedValue; 

			DBLayer dal = new DBLayer();
		
			int retVal = dal.updateCase(
				caspalid,PalletteType,DodaacSpl,CntrSize,
				CntrType,PalLength,PalWidth,PalHeight,
				MaxCases,status
				);
			if (retVal == 0)
				lblError.Text = "Please check the update information.Case info not updated";
			else
			{
				lblError.Text = "Case updated successfuly.";
				((DataGrid)sender).EditItemIndex = -1;
				biindCase();
			}
		}

		
		/// <summary>
		/// When cancel link button is pressed, all text box values are set to blank
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid2_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = -1;
			biindCase();
			lblError.Text = "";
			txtMaxCases.Text  = "";
			txtPalLength.Text = "";
			txtPalWidth.Text  = "";
			txtPalHeight.Text = "";
		}

		protected void DataGrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}
		/// <summary>
		/// trims a given string and returns the result
		/// </summary>
		/// <param name="strValue"></param>
		/// <returns></returns>
		protected string formatValue(string strValue)
		{
			string retVal = strValue.Trim();
			return retVal;
		}
		/// <summary>
		/// if container size is other than 20 or 40 then a text box is shown
		/// so that user can enter the size manually
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void CboCntrSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//System.Web.UI.WebControls.DataGridItemEventArgs ex;
			TextBox txtOther = (TextBox) DataGrid2.Items[0].FindControl("txtOther");
			DropDownList CboCntrSize = (DropDownList) DataGrid2.Items[0].FindControl("CboCntrSize");
			
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
