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
	/// Summary description for WebForm1.
	/// </summary>
	public class SupMaster : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblShPlanAccuracy;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.TextBox txtShPlanAccuracy;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
		protected System.Web.UI.WebControls.Label lblVendorCode;
		protected System.Web.UI.WebControls.Label lblVendorType;
		protected System.Web.UI.WebControls.DropDownList cboVendorType;
		protected System.Web.UI.WebControls.TextBox txtVendorDispName;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label lblVendorDispName;
		protected System.Web.UI.WebControls.Label lblVendorName;
		protected System.Web.UI.WebControls.TextBox txtVendorName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label lblRemarks;
		protected System.Web.UI.WebControls.TextBox txtRemarks;
		protected System.Web.UI.WebControls.Label lblLeadTime;
		protected System.Web.UI.WebControls.TextBox txtLeadTime;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.Label lblLeadTimeVar;
		protected System.Web.UI.WebControls.TextBox txtLeadTimeVar;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.Label lblETAAccuracy;
		protected System.Web.UI.WebControls.TextBox txtETAAccuracy;
		protected System.Web.UI.WebControls.DropDownList cboVendorCode;
		protected System.Web.UI.WebControls.TextBox txtVendorCode;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblContact;
		protected System.Web.UI.WebControls.TextBox txtContact;
		protected System.Web.UI.WebControls.Label lblContactFax;
		protected System.Web.UI.WebControls.TextBox txtContactFax;
		DBLayer dal = new DBLayer();

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			// bindGrid();
			if(!this.IsPostBack)
				populateVendorCode();
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
			this.cboVendorCode.SelectedIndexChanged += new System.EventHandler(this.cboVendorCode_SelectedIndexChanged);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			
			Utilities utl = new Utilities();


			if(!utl.ValidateNumber(txtETAAccuracy.Text))
			{
				lblError.Text = "ETA Accuracy should be number";
				return;
			}
			
			if(!utl.ValidateNumber(txtShPlanAccuracy.Text))
			{
				lblError.Text = "Ship plan Accuracy should be number";
				return;
			}

			if(!utl.ValidateNumber(txtLeadTime.Text))
			{
				lblError.Text = "Lead time should be number";
				return;
			}

			if(!utl.ValidateNumber(txtLeadTimeVar.Text))
			{
				lblError.Text = "Lead time variance should be number";
				return;
			}
			string x = txtVendorName.Text.Replace("'","");
			int iRetVal = dal.addSupplier(txtVendorCode.Text, cboVendorType.SelectedValue.ToString(), txtVendorName.Text.Replace("'",""), txtVendorDispName.Text.Replace("'",""), txtLeadTime.Text, txtLeadTimeVar.Text, txtShPlanAccuracy.Text,txtETAAccuracy.Text, txtRemarks.Text, txtContact.Text, txtContactFax.Text);
			if (iRetVal == 0)
				lblError.Text = "Records are not inserted properly";
			else
				lblError.Text = "supplier successfuly added.";

			clearAll();
		}

		private void clearAll()
		{
			txtVendorCode.Text = "";
			txtVendorName.Text = "";
			txtVendorDispName.Text = "";
			txtLeadTime.Text = "";
			txtLeadTimeVar.Text = "";
			txtShPlanAccuracy.Text = "";
			txtETAAccuracy.Text = "";
			txtRemarks.Text = "";
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			clearAll();
			lblError.Text = "";
		}

		private void cboVendorType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		private void populateVendorCode()
		{
			// getCS3Supplier_DS --pvcs3mast
			string warehouse = "V";
			DataSet dsCS3Supplier = dal.getCS3Supplier_DS(warehouse);
			cboVendorCode.DataSource = dsCS3Supplier.Tables["pvcs3mast"];
			cboVendorCode.DataTextField = "Sup_name";
			cboVendorCode.DataValueField = "Supplier";
			cboVendorCode.DataBind();
		}

		private void cboVendorCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string [] outStr=cboVendorCode.SelectedItem.Text.Replace("--", "±").Split('±');
			for(int i=0; i<outStr.Length; i++)
			{
				outStr[i]=outStr[i].Substring(0, outStr[i].Length-2);
				//outStr=str.Substring(1, str.Length-2);
			}

			txtVendorCode.Text = outStr[0].Trim();
			txtVendorName.Text = outStr[1].Trim();

		}




	}
}
