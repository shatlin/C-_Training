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
	/// Modifying a dodaac palette.
	/// </summary>
	public class PVPALDODMOD : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				biindPalletteDodaac();
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
		/// binds datagrid2 to all records from pvpaletdodaac table
		/// </summary>
		private void biindPalletteDodaac()
		{
			DBLayer dal = new DBLayer();
			DataSet dsDodaac = dal.Dodaac_DS();
			DataGrid2.DataSource = dsDodaac.Tables["PVPALETDODAC"].DefaultView;
			DataGrid2.DataBind();
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

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
			((DataGrid)sender).EditItemIndex = e.Item.ItemIndex;
			biindPalletteDodaac();
			string paletdodacid = e.Item.Cells[0].Text;
			//lblcaspalid.Text = caspalid;
		}

		/// <summary>
		/// When the update  link button is pressed the data
		/// entered by the user is validated and then saved
		/// into the table pvpaletdodaac
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid2_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{
			int paletdodacid = Convert.ToInt32 (e.Item.Cells[0].Text);
			
			
			
			DropDownList CboDodaacSpl = (DropDownList) e.Item.FindControl("CboDodaacSpl");
			string DodaacSpl = CboDodaacSpl.SelectedValue.ToString();

			TextBox txtDodaacName = (TextBox) e.Item.FindControl("txtDodaacName");
			string DodaacName = txtDodaacName.Text;

			TextBox txtDodaacDispName = (TextBox) e.Item.FindControl("txtDodaacDispName");
			string DodaacDispName = txtDodaacDispName.Text;

			DropDownList CboStatus = (DropDownList) e.Item.FindControl("CboStatus");
			string status = CboStatus.SelectedValue.ToString();

			Utilities utl = new Utilities();
			DBLayer dal = new DBLayer();
		
			int retVal = dal.updatePalletteDodaac(paletdodacid,DodaacName,DodaacSpl,DodaacDispName,status);
			if (retVal == 0)
				lblError.Text = "Please check the update information.Case info not updated";
			else
			{
				lblError.Text = "Case updated successfuly.";
				((DataGrid)sender).EditItemIndex = -1;
				biindPalletteDodaac();
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
			biindPalletteDodaac();
			lblError.Text = "";
			//txtDodaacName.Text  = "";
			//txtDodaacSpl.Text = "";
			//txtDodaacDispName.Text  = "";
			
		}

		protected void DataGrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}

	


	}
}
