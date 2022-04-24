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
	/// Summary description for PVRemarks.
	/// </summary>
	public class PVRemarks : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblRemType;
		protected System.Web.UI.WebControls.Label lblRemarks;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected MetaBuilders.WebControls.ComboBox cboRemType;
		protected MetaBuilders.WebControls.ComboBox cboRemarks;
		protected System.Web.UI.WebControls.Label lblError;
		DBLayer dal = new DBLayer();
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!this.IsPostBack)
				populateRemType();

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
			this.cboRemType.SelectedIndexChanged += new System.EventHandler(this.cboRemType_SelectedIndexChanged);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void populateRemType()
		{
			dal.getRemarksType(cboRemType);
/*
			DataSet dsRemType = dal.remarksType_DS();
			cboRemType.DataSource = dsRemType.Tables["remType"].DefaultView;
			cboRemType.DataTextField = "remName"; //remName";
			cboRemType.DataValueField = "remtype"; //remtype
			cboRemType.DataBind();
			*/
		}

		private void populateRemarks()
		{
			if(cboRemType.SelectedValue.Length > 0)
			{
				dal.getremarksDesc(cboRemarks, cboRemType.SelectedValue.ToString());
				/*
				DataSet dsRemarks = dal.remarksDesc_DS(cboRemType.SelectedValue.ToString().Trim());
				cboRemarks.DataSource = dsRemarks.Tables["remarks"];
				cboRemarks.DataTextField = "remarks";
				cboRemarks.DataValueField = "remid";
				cboRemarks.DataBind();
				*/
			}
		}

		private void cboRemType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			populateRemarks();
		}

		private void cboRemType_TextChanged(object sender, System.EventArgs e)
		{
				populateRemarks();
		}

		private void cmdSelect_Click(object sender, System.EventArgs e)
		{
			populateRemarks();
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			string remType="", remName="", remID="", remarks="";

			if (cboRemType.Text.Length > 0)
			{
				if(cboRemType.SelectedValue.Length > 0)
				{
					// remType is old
					remType = cboRemType.SelectedValue.ToString();
					remName = cboRemType.SelectedItem.Text;
					if(cboRemarks.Text.Length >0)
					{
						if(cboRemarks.SelectedValue.Length >0)
						{
							remID = cboRemarks.SelectedValue.ToString();
							remarks = cboRemarks.SelectedItem.Text;
						}
						else
							remarks = cboRemarks.Text;
					}

				}
				else
				{
					// remType is new
					remName = cboRemType.Text;
					if(cboRemarks.Text.Length >0)
					{
						if(cboRemarks.SelectedValue.Length >0)
						{
							remID = cboRemarks.SelectedValue.ToString();
							remarks = cboRemarks.SelectedItem.Text;
						}
						else
							remarks = cboRemarks.Text;
					}
					
				}
			}
			else
			{
				lblError.Text = "Remarks Type should not be empty";
				return;
			}


			string retVal = dal.updateRemarks(remType, remName, remID, remarks);
			lblError.Text = "";
			if (retVal.Length > 0)
				lblError.Text = retVal;
			else
			{
				cboRemType.Text = "";
				cboRemType.Items.Clear();
				cboRemarks.Text = "";
				cboRemarks.Items.Clear();
				populateRemType();
				populateRemarks();
			}

		}



	}
}
