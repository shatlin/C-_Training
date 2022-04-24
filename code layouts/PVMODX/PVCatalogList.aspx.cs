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
using System.Threading;

namespace PVMODX
{
	/// <summary>
	/// Summary description for PVCatalogList.
	/// </summary>
	public class PVCatalogList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdPrint;
		protected System.Web.UI.WebControls.Button cmdProceed;
		protected System.Web.UI.WebControls.Label lblTotalProduct;
		protected System.Web.UI.WebControls.Button cmdPgExport;
		DBLayer dal = new DBLayer();
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
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.cmdProceed.Click += new System.EventHandler(this.cmdProceed_Click);
			this.cmdPgExport.Click += new System.EventHandler(this.cmdPgExport_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				//lnkDatabaseBackup.Attributes.Add("onclick", "return confirm('Are you sure you want to backup the database?');");
				bindProductCataloge();
			}

		}


		private void bindProductCataloge()
		{
			// string warehosue = "V";
			string warehosue = Utilities.Warehouse();
			DataSet dsProducts = dal.getProductListByDate_DS(warehosue);
			dgResults.DataSource = dsProducts.Tables[0].DefaultView;
			lblTotalProduct.Text = "Total Product (" + dsProducts.Tables["tblProducts"].Rows.Count + ")";
			dgResults.DataBind();
			if (dsProducts.Tables["tblProducts"].Rows.Count > 0)
			{
				cmdPrint.Visible = true;
				cmdPgExport.Visible = true;
				cmdProceed.Visible = true;
				displayFlagColor(dsProducts.Tables["tblProducts"].Rows.Count);
			}
		}

		protected string getFlagColor(string flag)
		{
			//<%# getFlagColor(Convert.ToString(DataBinder.Eval(Container.DataItem, "updateflag"))) %>
			//ItemsGrid.ItemStyle.BackColor = 
			//	System.Drawing.Color.FromName(ItemBackColorList.SelectedItem.Value);
			//if(flag == "C")
			//	dgResults.ItemStyle.ForeColor = System.Drawing.Color.FromName("green"); 
			//System.Web.UI.WebControls.DataGridItemEventArgs e;
			int i = 1;
			DataGridItem dgItem= dgResults.Items[i]; //Convert.ToInt32(iRow)];  //iRow

			if(flag == "Z")
				dgItem.Cells[5].ForeColor = System.Drawing.Color.FromName("Red");
				// e.Item.Cells[5].ForeColor = System.Drawing.Color.FromName("Red");
				// dgResults.Items[5].ForeColor = System.Drawing.Color.FromName("Red");
				// dgResults.ItemStyle.ForeColor = System.Drawing.Color.FromName("Red");

			if(flag == "A")
				dgItem.Cells[5].ForeColor = System.Drawing.Color.FromName("black");
				// dgResults.Items[5].ForeColor = System.Drawing.Color.FromName("black");
				// dgResults.ItemStyle.ForeColor = System.Drawing.Color.FromName("black");
			return flag;
		}


		protected void displayFlagColor(int iTotal)
		{
			for (int i = 0; i <= iTotal - 1; i++)
			{
				DataGridItem dgItem= dgResults.Items[i];
				// dgItem.Cells[6].ForeColor = System.Drawing.Color.FromName("Red");
				//CheckBox SendThis = (CheckBox) dgItem.FindControl("SendThis");
				dgResults.Items[i].ForeColor = System.Drawing.Color.FromName("green");
				if (dgItem.Cells[2].Text == "Z")
				{
					dgResults.Items[i].ForeColor = System.Drawing.Color.FromName("Red");
				//	SendThis.Enabled = false;
				}
				if(dgItem.Cells[2].Text == "Y")
				{
					dgResults.Items[i].ForeColor = System.Drawing.Color.FromName("orange");
				//	SendThis.Enabled = false;
				}
			}

		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			//DataSet dsCatalog = dal.getCatalogList_DS();

			//DataTable objDataTable = new DataTable();
			//objDataTable = dsNISSub.Tables[0];
			//rptCatalogDifferenceList objReport = new rptCatalogDifferenceList();
			//objReport.SetDataSource(objDataTable);  //dbDataSet
			//objReport.SetDatabaseLogon("bmmi","secret");
			//CrystalReportViewer1.DataBind();
			//CrystalReportViewer1.ReportSource = objReport;
			Response.Redirect("MisMatchList.aspx");
		}



		private void cmdProceed_Click(object sender, System.EventArgs e)
		{
			int iTotal = Convert.ToInt32(lblTotalProduct.Text.ToString().Replace("Total Product (","").Replace(")","").Trim()); // + dsProducts.Tables["tblProducts"].Rows.Count + ")"
			DataSet dsCatalogList = dal.getMismatchCount_DS(); //  catalogAnalyse_DS();
			int iAnalyseTotal = dsCatalogList.Tables["pvCatalogAnalyse"].Rows.Count;
			if (iTotal != iAnalyseTotal)
			{
				Response.Write("<script language='javascript'>alert('Unable to proceed due Total count mismatch. Please check your updated dates.');</script>");
				return;
			}

			
			
			// System.Text.StringBuilder theStr=new System.Text.StringBuilder();
			string retVal, warehouse, product;

			retVal = dal.ProcessCatalogUpdation(dgResults);	
			if (retVal.Length > 0)
			{
				lblError.Text =  retVal;
			}
			return;


			// Take a backup before do any modification.
	
			//retVal = dal.stockmBackup();
			if (retVal.Length > 0)
			{
				lblError.Text = "Backup failed due to : " + retVal;
				dal.rollbackTrans();
				return;
			}

			foreach(DataGridItem dgItem in dgResults.Items)
			{
				warehouse = dgItem.Cells[0].Text.ToString();
				product = dgItem.Cells[1].Text.ToString();
				CheckBox SendThis=(CheckBox) dgItem.FindControl("SendThis");
				// if check box is checked call force update procedure directly
				if(SendThis.Checked)
					{
					// Call direct Insert
					retVal = dal.catalogForce2Insert(warehouse, product);
					if(retVal.Length > 0)
						{
							lblError.Text = "Force to Insert Process terminated due to : " + retVal;
							dal.rollbackTrans();
							return;
						}
					} 
				else
				{
					// call routing procedure..
					retVal = dal.catalogUpdate(warehouse, product);
					if(retVal.Length > 0)
					{
						lblError.Text = "Catalog update Process terminated due to : " + retVal;
						dal.rollbackTrans();
						return;
					}
				}
			}
			// call catalog recreation procedure.
			retVal = dal.catCurrRecreate();
			if(retVal.Length > 0)
			{
				lblError.Text = "Catalog recreation error due to : " + retVal;
				dal.rollbackTrans();
			}
			dal.commitTrans();
		}

		private void cmdPgExport_Click(object sender, System.EventArgs e)
		{
			// PrintToExcel();
			Response.Write("<script language='javascript'>window.print();</script>");
		}



		private void PrintToExcel()
		{
			Response.Clear();
			Response.Buffer=true;
			Response.Charset="";
			Response.ContentType="application/vnd.ms-excel";
			System.IO.StringWriter strExcel=new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlExcel=new System.Web.UI.HtmlTextWriter(strExcel);
			DataGrid dgExcel=dgResults; 
			dgExcel.GridLines=GridLines.None;
			dgExcel.HeaderStyle.Font.Bold=true;
			dgExcel.HeaderStyle.Font.Size=FontUnit.Parse("14px");
			dgExcel.HeaderStyle.ForeColor=Color.Black;
			//dgExcel.HeaderStyle.BackColor=Color.Black;
			dgExcel.ItemStyle.BackColor=Color.LightGray;
			dgExcel.AlternatingItemStyle.BackColor=Color.White;

			ClearControls(dgExcel);

			dgExcel.RenderControl(htmlExcel);
			
			Response.Write(strExcel.ToString());
			Response.End();
		}

		private void ClearControls(System.Web.UI.Control aControl)
		{
			for(int i=aControl.Controls.Count-1; i>=0; i--)
			{
				ClearControls(aControl.Controls[i]);
			}

			if(aControl is Button)
				aControl.Parent.Controls.Remove(aControl);
			else if (!(aControl is TableCell))
			{
				if (aControl.GetType().GetProperty("SelectedItem") != null)
				{
					System.Web.UI.LiteralControl literal = new System.Web.UI.LiteralControl();
					aControl.Parent.Controls.Add(literal);
					try
					{
						literal.Text = (string)aControl.GetType().GetProperty("SelectedItem").GetValue(aControl,null);
					}
					catch
					{
					}
					aControl.Parent.Controls.Remove(aControl);
				}
				else
					if (aControl.GetType().GetProperty("Text") != null)
				{
					System.Web.UI.LiteralControl literal = new System.Web.UI.LiteralControl();
					aControl.Parent.Controls.Add(literal);
					literal.Text = (string)aControl.GetType().GetProperty("Text").GetValue(aControl,null);
					aControl.Parent.Controls.Remove(aControl);
				}
			}
		}
	}
}
