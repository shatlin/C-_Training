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
using System.IO;


namespace PVMODX
{
	/// <summary>
	/// Uploading cost excel files
	/// </summary>
	public class PVCOSTUPL : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button uploadFile;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Panel pnlErr;
		protected System.Web.UI.HtmlControls.HtmlInputFile uplTheFile;
		protected System.Web.UI.HtmlControls.HtmlGenericControl txtOutput;
		public static string filepath="";
		public static string filename="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		/// <summary>
		/// Uploading the file
		/// </summary>
		protected void upload()
		{
			//Uploading files
			dbcostUplLayer  costlayer=new dbcostUplLayer ();
			directories costdirectories=new directories ();
			pnlErr.Visible =false;
			
			string strFileNameOnServer   = uplTheFile.Value ;
			
			string strBaseLocation	     = costdirectories.cstindir ;
			int filenameindex			 = strFileNameOnServer.LastIndexOf("\\");
			strFileNameOnServer			 = strFileNameOnServer.Substring(filenameindex+1);
			filename					 = strFileNameOnServer;
			lblError.Text				 = "";
			string filetype				 = strFileNameOnServer.Substring(strFileNameOnServer.LastIndexOf (".")+1);
			if ("" == strFileNameOnServer) 
			{
				lblError.Text = "Error - Please select a file and then press upload.";
				return;
			}
			
			if (null != uplTheFile.PostedFile) 
			{
				try 
				{
					
					filepath=strBaseLocation+strFileNameOnServer;
					FileInfo fi1 = new FileInfo(filepath);
					fi1.Delete();
					uplTheFile.PostedFile.SaveAs(strBaseLocation+strFileNameOnServer);
					lblError.Text = "File " +strFileNameOnServer+" uploaded successfully";
					string errDetl=costlayer.insertfilestatus(filename,"COST");
					costlayer.commitTrans ();
							
				}
				catch (Exception ex) 
				{
					string error=ex.Message ;
					lblError.Text = "Error Uploading " + strFileNameOnServer+" Please Upload the file again";
					costlayer.rollbackTrans ();
				}
				finally
				{
					costlayer.closedBConnection ();
				}
				if (filetype!="xls") 
				{
					lblError.Text = "Error - Please Upload an excel file";
					filepath="";
					return;
				}

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
			this.uploadFile.Click += new System.EventHandler(this.uploadFile_Click);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void uploadFile_Click(object sender, System.EventArgs e)
		{
			upload();
		}

		protected void cmdSave_Click(object sender, System.EventArgs e)
		{
			string process=	savexlfile();
		}
		/// <summary>
		/// Saves the excel file into database
		/// </summary>
		/// <returns></returns>
		public string savexlfile()
		{
			if (filepath.Length ==0)
			{
				lblError.Text ="Please upload a file to process";
				return "";
			}
			xlLayer xl=new xlLayer (filepath);
			directories costdirectories=new directories ();
			Utilities utl=new Utilities ();
			string sheetname="Sheet1";
			string errorDetl="";
			string []errorArray=null;

			/*the format of this array is 
			 * The field name
			 * the cell that contains the value( if value is in B10  range is given as B9:B10 because b9 is treated as the field header)
			 * Type of validation.
			 * Max length.this applies only to length validation.for other validation this field is given as zero.
			 */
			string [,] headerfields=new string[,] {
													{"SUPPLIER CODE " ,"B2:B3","L","20"},
													{"COST UPDATE DATE","B4:B5","D","0"}
												
												  };
		
			/* the format of this array is 
			 * The field name
			 * the Column that contains the values
			 * Type of validation.
			 * Max length.this applies only to length validation.for other validation this field is given as zero.
			 */
			string [,] detailfields=new string[,] {
													{"NSN","A","L","20"},
													{"PURCHASE UNIT","E","L","10"},
													{"BMMI COST","I","N","0"}	
													
												  };

			errorDetl=xl.checksheet(sheetname,"");
			if(errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				return "";
			}
			errorDetl=xl.chkxlheaderFields (sheetname,headerfields);
			//errorDetl+=xl.chkUnique(sheetname,"A",8);
			errorDetl+=xl.chkxldetailFields (sheetname,detailfields,8,0);
		
			if(errorDetl.Trim ().Length >0)
			{
				errorArray=errorDetl.Split ('!');
				lblError.Text ="Errors in Excel file Uploaded.Please correct and upload again";
				bindErrorGrid(errorArray);
				xl.closeXLconnection();
				utl.moveToErr(filepath,costdirectories.csterrdir +filename);
			
			}
			
			else
			{

				dbcostUplLayer costlayer=new dbcostUplLayer ();	
				errorDetl =costlayer.savecostXl(sheetname,filepath);
				if(errorDetl.Length ==0)
					errorDetl =costlayer.updatefilestatus(filename);
				if(errorDetl.Length ==0)
					errorDetl =costlayer.recreatesupcscurr();
	
			
				if(errorDetl.Trim ().Length >0)
				{
					lblError.Text ="Error saving data. "  ;
					errorArray=errorDetl.Split ('!');
					bindErrorGrid(errorArray);
					costlayer.rollbackTrans ();
					costlayer.closedBConnection ();
					xl.closeXLconnection ();
					utl.moveToErr(filepath,costdirectories.csterrdir+filename);
					
				}
				else
				{
					lblError.Text ="Cost Records successfully saved into database";
					costlayer.commitTrans(); 
					costlayer.closedBConnection ();
					xl.closeXLconnection ();
					utl.moveToOut(filepath,costdirectories.cstoutdir+filename);
				}

				
			}
			
		
			return "";
		}
		/// <summary>
		/// if errors found,All the errors are collected in an '!' seperated array 
		/// and this array is bound to Datagrid2
		/// </summary>
		/// <param name="errorArray">The collection of errors stored in this array</param>

		private void bindErrorGrid(string[] errorArray)
		{
			
			try
			{
				
				//Datagrid2.DataSource = new Mommo.Data.ArrayDataView(arr);
				Datagrid2.DataSource = errorArray;
				Datagrid2.DataBind();
				if (errorArray.Length!=0)
					pnlErr.Visible =true;

			}
			catch(Exception ex)
			{
				lblError.Text =ex.Message ;
				
			}
			finally
			{
				
			}

		}

	}
}
