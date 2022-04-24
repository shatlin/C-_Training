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
	/// Closing shipping plan records when respective ASNs are received
	/// </summary>
	public class PVSHPLANNULL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid shplanGrid;
		protected System.Web.UI.WebControls.DataGrid asnGrid;
		protected System.Web.UI.WebControls.Button  CloseASN;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				bindshplanGrid();
				bindasnGrid();
			}
		}



		/// <summary>
		/// gets all active shipping plan records and binds them with shplangrid
		/// </summary>
		private void bindshplanGrid()
		{
			closeShplanLayer dal	 = new closeShplanLayer();
			DataSet dscloseShplan	 = dal.closeShplan_DS();
			shplanGrid.DataSource	 = dscloseShplan.Tables["closeShplan"].DefaultView;
			shplanGrid.DataBind();
			dal.commitTrans ();
			dal.closedBConnection ();
		}

		/// <summary>
		/// Gets all asn records whose dates are later than the maximum date of active shipping plan date
		/// </summary>
		private void bindasnGrid()
		{
			closeShplanLayer dal     = new closeShplanLayer();
			DataSet dscloseShplanasn = dal.closeShplanASN_DS();
			asnGrid.DataSource       = dscloseShplanasn.Tables["closeShplanasn"].DefaultView;
			asnGrid.DataBind();
			dal.commitTrans ();
			dal.closedBConnection ();
		}


		
		protected void asnGrid_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{

		}

		protected void asnGrid_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{

		}


		protected void asnGrid_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
		
			
		}

		protected void asnGrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
		}

		protected void shplanGrid_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{

		}

		protected void shplanGrid_OnUpdateCommand(object sender, DataGridCommandEventArgs e)
		{

		}


		protected void shplanGrid_OnCancelCommand(object sender, DataGridCommandEventArgs e)
		{
		
			
		}

		protected void shplanGrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.CloseASN.Click += new System.EventHandler(this.closeShplan_Click);

		}
		#endregion

		
		/// <summary>
		/// clicking the close button sets the status of all seleted shipping plans to 'C'
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeShplan_Click(object sender, System.EventArgs e)
		{
			string errordetl="";
			string shplanno="";
			closeShplanLayer dal=new closeShplanLayer();
			foreach (DataGridItem i in shplanGrid.Items) 
			{
							
				CheckBox chkShplan = (CheckBox) i.FindControl ("chkShplan");
				if (chkShplan.Checked) 
				{
					shplanno=i.Cells[0].Text.Trim();
					errordetl+=dal.closeShplan(shplanno);
					
				}
			}
			if (errordetl.Length >0)
			{
				lblError.Text ="Error closing Shipping Plan.";
				dal.rollbackTrans ();
				dal.closedBConnection ();
			}
			else
			{
				lblError.Text ="Selected Shipping Plans closed.";
				dal.commitTrans ();
				dal.closedBConnection ();
				bindasnGrid();
				bindshplanGrid();
			
			}
		}

	}
}
