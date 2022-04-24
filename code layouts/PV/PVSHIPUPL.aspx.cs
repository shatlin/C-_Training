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
using System.IO ;


namespace PVMODX
{
	/// <summary>
	/// Uploading a shipping plan file
	/// </summary>
	public class PVSHIPUPL : System.Web.UI.Page
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

		/// <summary>
		/// invokes the saveshipfile 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			string process=	saveshipfile();
		}


		/// <summary>
		/// Saves the shipping plan excel file into database
		/// </summary>
		/// <returns></returns>
		public string saveshipfile()
		{
			if (filepath.Length ==0)
			{
				lblError.Text ="Please upload a file to process";
				return "";
			}
			xlLayer xl=new xlLayer (filepath);
			directories shipdirectories=new directories ();
			Utilities utl=new Utilities ();
			string sheetname="Sheet1";
			string errorDetl="";
			string []errorArray=null;
			string [,] headerfields=new string[,] {
													{ " SUPPLIER CODE "  ,"B2:B3","L","20"},
													{ " SUPPLIER CODE "  ,"B2:B3","E","0"},
													{ " SHIP PLAN DATE " ,"B4:B5","D","0"},
													{ " SHIP PLAN DATE " ,"B4:B5","E","0"}	
												  };

			string [,] detailfields=new string[,] {
													{" NSN","C","E","0"},
													{" NSN","C","L","20"},	
													{" PURCHASE ORDER","B","E","0"},
													{" PURCHASE ORDER","B","L","20"},
													{" PURCHASE UNIT","F","E","0"},
													{" PURCHASE UNIT","F","L","10"},
													{" PLANNED QTY","G","E","0"},
													{" PLANNED QTY","G","N","0"},
													{" PLANNED DATE ","A","E","0"},
													{" PLANNED DATE ","A","D","0"}
												  };

			errorDetl=xl.checksheet(sheetname,"");
			if(errorDetl.Length >0)
			{
				lblError.Text =errorDetl;
				return "";
			}
			errorDetl=xl.chkxlheaderFields (sheetname,headerfields);
			errorDetl+=xl.chkxldetailFields (sheetname,detailfields,8,0);
		
			if(errorDetl.Trim ().Length >0)
			{
				errorArray=errorDetl.Split ('!');
				lblError.Text ="Errors in Excel file Uploaded.Please correct and upload again";
				bindErrorGrid(errorArray);
				xl.closeXLconnection();
				utl.moveToErr(filepath,shipdirectories.splerrdir  +filename);
			
			}
			
			else
			{

				dbshipUplLayer shiplayer=new dbshipUplLayer ();	
				errorDetl =shiplayer.saveshipXl(sheetname,filepath);

				if(errorDetl.Length ==0)
					errorDetl+=shiplayer.updatefilestatus(filename);
			
				if(errorDetl.Trim ().Length >0)
				{
					lblError.Text ="Error saving data. "+errorDetl;
					shiplayer.rollbackTrans ();
					shiplayer.closedBConnection ();
					xl.closeXLconnection ();
					utl.moveToErr(filepath,shipdirectories.splerrdir +filename);
					
				}
				else
				{
					lblError.Text ="Shipping Records successfully saved into database";
					shiplayer.commitTrans(); 
					shiplayer.closedBConnection ();
					xl.closeXLconnection ();
					utl.moveToOut(filepath,shipdirectories.sploutdir+filename);
				}

				
			}
			
		
			return "";
		}



		private void uploadFile_Click(object sender, System.EventArgs e)
		{
			upload();
		}

		/// <summary>
		/// Uploading the file
		/// </summary>
		protected void upload()
		{
			//Uploading files
			dbshipUplLayer  shiplayer=new dbshipUplLayer ();
			directories shipdirectories=new directories ();
			pnlErr.Visible =false;
			
			string strFileNameOnServer   = uplTheFile.Value ;
			
			string strBaseLocation	     = shipdirectories.splindir;
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
					lblError.Text = "File " +strFileNameOnServer+" uploaded successfully ";
					string errDetl=shiplayer.insertfilestatus(filename,"SHIP");
					shiplayer.commitTrans ();
							
				}
				catch (Exception ex) 
				{
					string error=ex.Message ;
					lblError.Text = "Error Uploading " + strFileNameOnServer+" Please Upload the file again";
					shiplayer.rollbackTrans ();
				}
				finally
				{
					shiplayer.closedBConnection ();
				}
				if (filetype!="xls") 
				{
					lblError.Text = "Error - Please Upload an excel file";
					filepath="";
					return;
				}

			}
  
	
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
