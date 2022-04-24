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
	/// Summary description for AddNewUser.
	/// </summary>
	public class AddNewUser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUserID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox txtConfirm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.Label lblConfirm;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.CheckBox chkIsAdmin;
		protected System.Web.UI.WebControls.Label lblUserDetails;
		protected System.Web.UI.WebControls.Label lblPrivileges;
		protected System.Web.UI.WebControls.ListBox lstWarehouse;
		protected System.Web.UI.WebControls.Label lblWarehouse;
		protected System.Web.UI.WebControls.Label lblPages;
		protected System.Web.UI.WebControls.TextBox txtUserID;
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.ListBox lstPages;
		protected System.Web.UI.WebControls.Label lblEmail;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.Label lblGroup;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.DropDownList cboGroup;
		userDBLayer dal = new userDBLayer();

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
			this.chkIsAdmin.CheckedChanged += new System.EventHandler(this.chkIsAdmin_CheckedChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.cboGroup.SelectedIndexChanged += new System.EventHandler(this.cboGroup_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string userName = Utilities.UserName(); // HttpContext.Current.User.Identity.Name;
			string wareHouse = Utilities.Warehouse();
			if (!this.IsPostBack)
			{
				bindWarehouse();
				bindGroupList();
			}

		}


		private void bindWarehouse()
		{
			lstWarehouse.Items.Clear();
			DataSet dsWarehouse =  dal.getWarehouse();
			lstWarehouse.DataSource = dsWarehouse.Tables[0].DefaultView;
			lstWarehouse.DataValueField = "wh";
			lstWarehouse.DataTextField = "wh";
			lstWarehouse.DataBind();
		}



		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(txtPassword.Text.Equals(txtConfirm.Text))
			{
				System.Collections.ArrayList arrPages=new System.Collections.ArrayList();
				string whList="";
				// string pageList;
				foreach(ListItem lvItem in lstWarehouse.Items)
				{
					if(lvItem.Selected)
					{
						// arrRoles.Add(lvItem.Text);
						whList += lvItem.Text + ",";
					}
				}
				if (whList.Length > 0)
					whList = whList.Remove(whList.Length-1, 1).ToString();
				
				foreach(ListItem lvItem in lstPages.Items)
				{
					if(lvItem.Selected)
					{
						arrPages.Add(lvItem.Text);
					}
				}

				string retVal = dal.AddNewUser(txtUserID.Text, txtUserName.Text, txtPassword.Text,  whList, arrPages, chkIsAdmin.Checked, txtEmail.Text, cboGroup.SelectedValue);
				if (retVal.Length > 0) lblErrorMessage.Text = retVal;
				else {lblErrorMessage.Text="User Added Successfully."; clearUserList();}
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			clearUserList();
		}

		private void chkIsAdmin_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkIsAdmin.Checked)
			{
				foreach(ListItem lvItem in lstWarehouse.Items)
				{
					lvItem.Selected = true;
				}
				foreach(ListItem lvItem in lstPages.Items)
				{
					lvItem.Selected = true;
				}
			}
			else
			{
				foreach(ListItem lvItem in lstWarehouse.Items)
				{
					lvItem.Selected = false;
				}		
				foreach(ListItem lvItem in lstPages.Items)
				{
					lvItem.Selected = false;
				}	
			}

		}

		private void cboGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void bindGroupList()
		{
			cboGroup.Items.Clear();
			DataSet dsGroup =  dal.getGroupList();
			cboGroup.DataSource = dsGroup.Tables[0].DefaultView;
			cboGroup.DataValueField = "groupID";
			cboGroup.DataTextField = "gname";
			cboGroup.DataBind();
		}

		private void clearUserList()
		{
			lstWarehouse.ClearSelection();
			lstPages.ClearSelection();
			txtUserID.Text = "";
			txtPassword.Text = "";
			txtConfirm.Text = "";
			txtUserName.Text = "";
			chkIsAdmin.Checked = false;
		}

	}
}
