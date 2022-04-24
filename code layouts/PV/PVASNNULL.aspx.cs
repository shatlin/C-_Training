using System;
using System.Data.OleDb;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

namespace PVMODX
{
	/// <summary>
	/// Closing ASNs when respective GRNS are received
	/// </summary>
	public class PVASNNULL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Button CloseASN;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				bindcloseasn();
			}
		}

		

			
		/// <summary>
		/// Getting all ASNs and related GRNS from database
		/// and binding them with a datagrid, datagrid2.
		/// </summary>
		private void bindcloseasn()
		{
			closeAsnLayer dal=new closeAsnLayer();
			DataSet dscloseasn = dal.closeasn_DS();
			DataGrid2.DataSource = dscloseasn.Tables["closeasn"].DefaultView;
			DataGrid2.DataBind();
			dal.commitTrans ();
			dal.closedBConnection ();
		}


		
		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{

		}

		protected void DataGrid2_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{

		}


		protected void DataGrid2_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
		
			
		}

		protected void DataGrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.CloseASN.Click += new System.EventHandler(this.CloseASN_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// clicking the close button sets the status of all seleted ASNs to 'C'
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseASN_Click(object sender, System.EventArgs e)
		{
			string errordetl="";
			string asnno="";
			closeAsnLayer dal=new closeAsnLayer();
			foreach (DataGridItem i in DataGrid2.Items) 
			{
							
				CheckBox chkAsn = (CheckBox) i.FindControl ("chkAsn");
				if (chkAsn.Checked) 
				{
					asnno=i.Cells[0].Text.Trim();
					errordetl+=dal.closeasn(asnno);
					
				}
			}
			if (errordetl.Length >0)
			{
				lblError.Text ="Error closing asn.";
				dal.rollbackTrans ();
				dal.closedBConnection ();
			}
			else
			{
				lblError.Text ="ASNs closed.";
				dal.commitTrans ();
				dal.closedBConnection ();
				bindcloseasn();
			
			}
		}

	}
}
