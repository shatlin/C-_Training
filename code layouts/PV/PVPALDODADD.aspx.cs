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
	/// Adds a dodaac palette record
	/// </summary>
	public class PVPALDODADD : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblDodaacName;
		protected System.Web.UI.WebControls.TextBox txtDodaacName;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.Label lblDodaacSpl;
		protected System.Web.UI.WebControls.TextBox txtDodaacSpl;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Label lblDisplayName;
		protected System.Web.UI.WebControls.TextBox txtDodaacDispName;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DropDownList CboStatus;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
	
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
		private void InitializeComponent()
		{
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
			
			DBLayer dal = new DBLayer();
			int iRetVal = dal.addDodaacPallette(txtDodaacName.Text,txtDodaacSpl.Text,txtDodaacDispName.Text,CboStatus.SelectedValue.ToString());
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
			txtDodaacName.Text = "";
			txtDodaacSpl.Text = "";
			txtDodaacDispName.Text = "";
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


	}
}
