using System;
using System.Collections;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;


namespace PVMODX
{
	/// <summary>
	/// Summary description for PVFILEUPL.
	/// </summary>
	public class PVFILEUPL : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile uplTheFile;
		protected System.Web.UI.HtmlControls.HtmlGenericControl txtOutput;
		protected System.Web.UI.WebControls.DataGrid DataGrid;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Panel pnlErr;
		protected System.Web.UI.WebControls.Button uploadFile;
		public static string filepath="";
		public static string filename="";

		private void Page_Load(object sender, System.EventArgs e)
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
			this.uploadFile.Click += new System.EventHandler(this.uploadFile_Click);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
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

		protected void btnUploadTheFile_ServerClick(object sender, System.EventArgs e)
		{
			//Uploading files
	
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			string errDetl=savexlfile();
		}

		public string savexlfile()
		{

			
			if( filepath.Length ==0)
			{
				lblError.Text ="Please upload a file to process";
				return "";
			}

				dBRFLayer rfLayer=new dBRFLayer();
			
				directories rfdirectories=new directories();
				Utilities utl=new Utilities ();
				ArrayList errorArrayList=new ArrayList();
				xlLayer xl=new xlLayer(filepath);

				string [] errorArray=null;
				string errorDetl="";
				string sheetssaved="";
				

				errorDetl=xl.checksheet ("DATA","");
				xl.closeXL();
			

				if(errorDetl.Length >0)
				{
					lblError.Text =errorDetl;
					return "";
				}

				rfLayer.openXLConnection (filepath);
	
				errorDetl = rfLayer.checkXLErrors("DRY");
				errorDetl+= rfLayer.checkXLErrors("CHILLED");	
				errorDetl+= rfLayer.checkXLErrors("FROZEN");	

				if (errorDetl.Length >0)
				{
					errorDetl="<B>ERRORS IN FILE "+ filename +"</B> ! "+ "&nbsp;!"+errorDetl;
					errorArray=errorDetl.Split ('!');
					lblError.Text ="ERRORS IN FILE "+ filename+ " NO RECORDS UPLOADED.PLEASE CORRECT FILE AND UPLOAD AGAIN";
					bindErrorGrid(errorArray);
					rfLayer.closedBConnection ();
					rfLayer.closeXLconnection();
					utl.moveToErr(filepath,rfdirectories.rferrdir+filename);
								
				}

				else
				{
					errorDetl= rfLayer.SaveXLData("DRY",ref sheetssaved);
					errorDetl+= rfLayer.SaveXLData("CHILLED",ref sheetssaved);	
					errorDetl+= rfLayer.SaveXLData("FROZEN",ref sheetssaved);

					if (errorDetl.Trim().Length >0)
					{
						errorDetl=" ERRORS IN FILE <B> "+ filename +"</B> ! "+ "&nbsp;!"+errorDetl;
						errorArray=errorDetl.Split ('!');
						lblError.Text ="ERRORS IN FILE "+ filename+ ".NO RECORDS UPLOADED.PLEASE CORRECT FILE AND UPLOAD AGAIN";
						bindErrorGrid(errorArray);
						rfLayer.rollbackTrans();
						rfLayer.closedBConnection ();
						rfLayer.closeXLconnection();
						utl.moveToErr(filepath,rfdirectories.rferrdir+filename);
					}
					else 
					{
						lblError.Text="Records successfully saved into database";
						errorDetl=" Following sheets in <B>"+ filename +"</B> Uploaded successfully on  "+DateTime.Now+ " ! &nbsp;! "+sheetssaved;
						errorArray=errorDetl.Split ('!');
						bindErrorGrid(errorArray);
						rfLayer.updatefilestatus(filename);
						rfLayer.commitTrans();
						rfLayer.closedBConnection ();
						rfLayer.closeXLconnection();
						utl.moveToOut (filepath,rfdirectories.rfoutdir+filename);
					}

				
					
				}
					
	
			return "";
		}

		private void uploadFile_Click(object sender, System.EventArgs e)
		{
			dBRFLayer  rfLayer=new dBRFLayer ();
			directories rfdirectories=new directories ();
			pnlErr.Visible =false;
			string strFileNameOnServer   = uplTheFile.Value ;
			string strBaseLocation	     = rfdirectories.rfindir;
			int filenameindex			 =strFileNameOnServer.LastIndexOf("\\");
			strFileNameOnServer			 =strFileNameOnServer.Substring(filenameindex+1);
			filename					 =strFileNameOnServer;
			string filetype				 = strFileNameOnServer.Substring(strFileNameOnServer.LastIndexOf (".")+1);
 			lblError.Text				 = "";
			
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
					lblError.Text = "File <b>" +strFileNameOnServer+"</b> selected.Press Upload to save Records";
					string errDetl=rfLayer.insertfilestatus(filename,"RF");
					rfLayer.commitTrans ();
					pnlErr.Visible =false;
					
				
				}
				catch (Exception ex) 
				{
					string error=ex.Message ;
					lblError.Text = "Error Selecting " + strFileNameOnServer+" Please Upload the file again";
					rfLayer.rollbackTrans ();
				}
				finally
				{
					rfLayer.closedBConnection ();
				}
			}

			if (filetype!="xls") 
			{
				lblError.Text = "Error - Please Select an excel file";
				filepath="";
				return;
			}
  
	
		}//savexlfile

	}
}
