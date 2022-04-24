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
	/// Summary description for ModifyPallette.
	/// </summary>
	public class ModifyPallette : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
			{
				biindPallette();
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

		private void biindPallette()
		{
			DBLayer dal = new DBLayer();
			DataSet dsPallette = dal.pallette_DS();
			DataGrid2.DataSource = dsPallette.Tables["pvpaletcntr"].DefaultView;
			DataGrid2.DataBind();
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			biindPallette();
			string palcntrid = e.Item.Cells[0].Text;
			//lblpalcntrid.Text = palcntrid;
		}

		protected void DataGrid2_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{
			
			int palcntrid = Convert.ToInt32 (e.Item.Cells[0].Text);
			TextBox txtPalletteType = (TextBox) e.Item.FindControl("txtPalletteType");
			string PalletteType = txtPalletteType.Text;
			
			DropDownList CboDodaacSpl = (DropDownList) e.Item.FindControl("CboDodaacSpl");
			string DodaacSpl = CboDodaacSpl.SelectedValue.ToString();
			
			DropDownList CboCntrSize = (DropDownList) e.Item.FindControl("CboCntrSize");
			string CntrSize = CboCntrSize.SelectedValue.ToString();
			
			DropDownList CboCntrType = (DropDownList) e.Item.FindControl("CboCntrType");
			string CntrType		= CboCntrType.SelectedValue.ToString();
			
			TextBox txtMaxPallettes = (TextBox) e.Item.FindControl("txtMaxPallettes");
			string MaxPallettes = txtMaxPallettes.Text;
			
			DropDownList CboStatus = (DropDownList) e.Item.FindControl("CboStatus");
			string status = CboStatus.SelectedValue.ToString();
				
			Utilities utl = new Utilities();
			
			if(!utl.ValidateNumber(CntrSize.Trim()))
			{
				lblError.Text = "Container Size should be number";
				return;
			}

			if(!utl.ValidateNumber(MaxPallettes.Trim()))
			{
				lblError.Text = "Maximum pallettes should be number";
				return;
			}

						
			DBLayer dal = new DBLayer();
		
			int retVal = dal.updatePallette(palcntrid,PalletteType,DodaacSpl,CntrSize,CntrType,MaxPallettes,status);
			if (retVal == 0)
				lblError.Text = "Please check the update information.Pallette info not updated";
			else
			{
				lblError.Text = "Pallette updated successfuly.";
				((DataGrid)sender).EditItemIndex = -1;
				biindPallette();
			}
		}

		protected void DataGrid2_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = -1;
			biindPallette();
			lblError.Text = "";
		}

		protected void DataGrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}

		
		protected string formatValue(string strValue)
		{
			string retVal = strValue.Trim();
			return retVal;
		}


	}
}
