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
	/// Selecting the purchase Analysis performed perviously
	/// so that the user can modify an already performed purchase Analysis 
	/// </summary>
	public class PVPAVIEW : System.Web.UI.Page
	{
			
		protected System.Web.UI.WebControls.Label lblDateFrom;
		protected eWorld.UI.CalendarPopup calendarPopup1;
		protected System.Web.UI.WebControls.Label lblDateTo;
		protected eWorld.UI.CalendarPopup CalendarPopup2;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Button btnViewPA;
		protected System.Web.UI.WebControls.Panel pnlPA;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnViewPA.Click += new System.EventHandler(this.btnViewPA_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// binds datagrid2 with the purchase Analyis performed
		/// from fromdate to todate
		/// </summary>
		/// <param name="fromdate"></param>
		/// <param name="todate"></param>
		private void bindPA(string fromdate,string todate)
		{
			int paCount=0;
			string vendors_analysed="";
			string analysisbyflag="";
			string analysisby="";
			string[] arrvendors_analysed=null;
			
			string[] arrVendornames_analysed=null;
			string vendornames_commaseperated="";
			DBLayer dal = new  DBLayer ();
			dbPurAnalysis PAlayer= new dbPurAnalysis ();
			DataSet dsPA = dal.viewPA(fromdate,todate);
			DataGrid2.DataSource = dsPA.Tables["PA"].DefaultView;
			lblTotal.Text = "Total Purchase Analysis Done (" + dsPA.Tables["PA"].Rows.Count + ")";
			DataGrid2.DataBind();

			paCount=DataGrid2.Items.Count;
			
			for(int j = 0;j < paCount; j++)
			{
				
				
				vendors_analysed=DataGrid2.Items[j].Cells[4].Text;
				analysisbyflag=DataGrid2.Items[j].Cells[6].Text;
				arrvendors_analysed=vendors_analysed.Split ('!');
				arrVendornames_analysed=PAlayer.getSupplierName(arrvendors_analysed);
				for(int k=0;k<arrVendornames_analysed.Length ;k++)
				{
					vendornames_commaseperated+=arrVendornames_analysed[k]+",";
				}
				if(vendornames_commaseperated.Length >0)
				{
					vendornames_commaseperated=vendornames_commaseperated.Substring (0,vendornames_commaseperated.Length -1);
				}

				if(analysisbyflag=="m")
				{
					analysisby="Margin";
				}
				else
				{
					analysisby="Lead Time";
				}
							
				DataGrid2.Items[j].Cells[5].Text=vendornames_commaseperated ;
				DataGrid2.Items[j].Cells[7].Text=analysisby ;
				vendornames_commaseperated="";
				
			}
			PAlayer.commitTrans ();
			PAlayer.closedBConnection ();
			
		}

		protected void DataGrid2_OnEditCommand(object sender, DataGridCommandEventArgs e)
		{
		}

		protected void DataGrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Utilities utl=new Utilities ();
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
				string pano=e.Item.Cells[0].Text;
				LinkButton btnDetails=(LinkButton) e.Item.Cells[8].Controls[0];
				btnDetails.Attributes.Add("onclick", "javascript:window.open(\"PVPAMOD.aspx?pano="+pano+"\")");
	
			}
		}

		private void btnViewPA_Click(object sender, System.EventArgs e)
		{
			string fromdate=calendarPopup1.SelectedDate.ToString ("dd-MMM-yy");
			string todate=CalendarPopup2.SelectedDate.ToString ("dd-MMM-yy");
			pnlPA.Visible =true;
			bindPA(fromdate,todate);
		}

		
	}
}
