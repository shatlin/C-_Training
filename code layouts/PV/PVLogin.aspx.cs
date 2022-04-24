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
using System.Web.Security;


namespace PVMODX
{
	/// <summary>
	/// Summary description for PVLogin.
	/// </summary>
	public class PVLogin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Label lblWarehouse;
		protected System.Web.UI.WebControls.DropDownList cboWarehouse;
		protected System.Web.UI.WebControls.Label lblUsername;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.Button cmdLogin;
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
			this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
			this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!this.IsPostBack)
				bindWarehouse();
		}


		private void bindWarehouse()
		{
			cboWarehouse.Items.Clear();
			DataSet dsWarehouse =  dal.getWarehouse();
			cboWarehouse.DataSource = dsWarehouse.Tables[0].DefaultView;
			cboWarehouse.DataValueField = "wh";
			cboWarehouse.DataTextField = "wh";
			cboWarehouse.DataBind();
		}

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			int loginStatus=dal.CheckLogin(txtUserName.Text, txtPassword.Text);

			switch(loginStatus)
			{
				case 0:
					FormsAuthentication.RedirectFromLoginPage(txtUserName.Text + "-" + cboWarehouse.SelectedValue, false);
					break;
				case 1:
					lblErrorMessage.Text="Invalid username.";
					break;
				case 2:
					lblErrorMessage.Text="Invalid password.";
					break;
				case 3:
					lblErrorMessage.Text="Account has been disabled.";
					break;
			}
			
		}

		private void txtUserName_TextChanged(object sender, System.EventArgs e)
		{
			if(txtUserName.Text.Trim().Length > 0)
			{
				cboWarehouse.Items.Clear();
				DataSet dsWarehouseByUser =  dal.getWarehouseByUser(txtUserName.Text.Trim());
				// productsList.Replace("'", "").Replace(", ", "±").Split('±');
				if(dsWarehouseByUser.Tables["pvuserWarehouse"].Rows.Count == 0)
				{
					lblErrorMessage.Text = "Invalid User";
					return;
				}
				else
				{
					string [] whList = dsWarehouseByUser.Tables["pvuserWarehouse"].Rows[0]["Warehouse"].ToString().Replace(",","±").Split('±');
					foreach(string wh in whList)
					{
						cboWarehouse.Items.Add(new ListItem(wh.Trim(),wh.Trim()));
					}
					// txtPassword
				}
			}

		}







	}
}
