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
	/// Uploading a text ASN file
	/// </summary>
	public class PVASNTXTUPL : System.Web.UI.Page
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

		private void uploadFile_Click(object sender, System.EventArgs e)
		{
			//Uploading files
			dbAsnUplLayer  asnlayer=new dbAsnUplLayer ();
			directories asndirectories=new directories ();
			pnlErr.Visible =false;
			string filetype="";
			string strFileNameOnServer   = uplTheFile.Value ;
			
			string strBaseLocation	     = asndirectories.asnindir;
			int filenameindex			 = strFileNameOnServer.LastIndexOf("\\");
			strFileNameOnServer			 = strFileNameOnServer.Substring(filenameindex+1);
			
			lblError.Text				 = "";
			filetype					 = strFileNameOnServer.Substring(strFileNameOnServer.LastIndexOf (".")+1);
			filename					 = strFileNameOnServer;
			
			//if no file uploaded
			if ("" == strFileNameOnServer) 
			{
				lblError.Text = "Error - Please select a file and then press upload.";
				return;
			}
			//if a file is uploaded
			if (null != uplTheFile.PostedFile) 
			{
				try 
				{
					
					filepath=strBaseLocation+strFileNameOnServer;
					FileInfo fi1 = new FileInfo(filepath);
					fi1.Delete();
					uplTheFile.PostedFile.SaveAs(strBaseLocation+strFileNameOnServer);
					lblError.Text = "File " +strFileNameOnServer+" uploaded successfully";
					string errDetl=asnlayer.insertfilestatus (filename,"ASN");
					asnlayer.commitTrans ();
							
				}
				catch (Exception ex) 
				{
					string error=ex.Message ;
					lblError.Text = "Error Uploading " + strFileNameOnServer+" Please Upload the file again";
					asnlayer.rollbackTrans ();
				}
				finally
				{
					asnlayer.closedBConnection ();
				}
				//if uploaded file is not a text file
				if (filetype!="txt") 
				{
					lblError.Text = "Error - Please Upload a text file";
					filepath="";
					return;
				}

			}
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{

			savetxtasn();
		}

		public string savetxtasn()
		{
			dbAsnUplLayer  asnlayer=new dbAsnUplLayer ();
			directories asndirectories=new directories ();
			Utilities utl=new Utilities ();
			StreamReader sr = new StreamReader(filepath);
		
			try
			{
				
			
				
				int recordno=0;
				string warehouse	= "";
				string product		= "";
				string whproduct	= "";

				string HDR  = "";
				string DTL1 = "";
				string DTL2 = "";
				string DTL3 = "";
				string DTL4 = "";

				string asn_no         ="";
				string asn_date       ="";
				string cntr_no        ="";
				string cntr_type      ="";
				string seal_no        ="";
				string vessel         ="";
				string port_disp      ="";
				string sail_date      ="";
				string eta            ="";
				string tot_pallets    ="";
				string tot_cases      ="";
				string inv_no         ="";
				string inv_date       ="";
				string freight        ="";
				string tot_lines      ="";



				string po_number      ="";
				string vp_no          ="";
				string nsn            ="";

				string desc           ="";


				string qty_ordered    ="";
				string qty_shipped    ="";
				string vendor_cost    ="";
			
				string candf          ="";
				string bmmi_price     ="";
				string napa_discount  ="";
				string net_price      ="";
				string brand          ="";
				string mfgid          ="";
				string pkg            ="";
				string purch_unit     ="";


				string len            ="";
				string wth            ="";
				string hgt            ="";
				string cube           ="";
				string ti             ="";
				string hi             ="";
				string wt             ="";
				string twt            ="";
				string pack_date      ="";
				string expiry_date    ="";

				string prd			  ="";
				string errorDetl	  ="";	

				HDR =sr.ReadLine();

				//	asn_no         = HDR.Substring(5,20).Trim();
				asn_no		   = asnlayer.generateAutoNo("ASNNO");
				asn_date       = HDR.Substring(26,8).Trim();
				cntr_no        = HDR.Substring(35,20).Trim();
				cntr_type      = HDR.Substring(56,3).Trim();
				seal_no        = HDR.Substring(60,20).Trim();
				vessel         = HDR.Substring(81,25).Trim();
				port_disp      = HDR.Substring(107,20).Trim();
				sail_date      = HDR.Substring(128,8).Trim();
				eta            = HDR.Substring(137,8).Trim();
				tot_pallets    = HDR.Substring(146,3).Trim();
				tot_cases      = HDR.Substring(150,5).Trim();
				inv_no         = HDR.Substring(156,20).Trim();
				inv_date       = HDR.Substring(177,8).Trim();
				freight        = HDR.Substring(186,8).Trim();
				tot_lines      = HDR.Substring(195,4).Trim();

			
				errorDetl=asnlayer.saveasnTxtHeader( asn_no,asn_date,cntr_no,cntr_type,seal_no,vessel,
					port_disp,sail_date,eta,tot_pallets,inv_no,
					inv_date,freight,tot_cases,filename);

				// if any errors whiel inserting into the asnheader
				if (errorDetl.Length >0)
				{
					lblError.Text =errorDetl;
					sr.Close ();
					asnlayer.rollbackTrans ();
					asnlayer.closedBConnection ();
					utl.moveToErr(filepath,asndirectories.asnerrdir+filename);
					return "";
				}
			
				do
				{
				
					DTL1=sr.ReadLine();
					if (DTL1==null)
						break;
					DTL2=sr.ReadLine();
					DTL3=sr.ReadLine();
					DTL4=sr.ReadLine();
				
					recordno++;

					po_number      = DTL1.Substring(5,20);
					//if po_number starts with "pv" remove "pv"
					if(po_number.Substring(0,2).ToUpper()=="PV")
						po_number=po_number.Substring(2,18).Trim ();
					vp_no          = DTL1.Substring(29,20).Trim();
					nsn            = DTL1.Substring(50,13).Trim();

					desc           = DTL2.Substring(5,80).Trim();

					// actual qty ordered is fetched from podetm.
					qty_ordered    = DTL3.Substring(5,8).Trim(); 
					qty_shipped    = DTL3.Substring(14,8).Trim();
					vendor_cost    = DTL3.Substring(23,8).Trim();
					freight        = DTL3.Substring(32,8).Trim();
					candf          = DTL3.Substring(41,8).Trim();
					bmmi_price     = DTL3.Substring(50,8).Trim();
					napa_discount  = DTL3.Substring(59,8).Trim();
					net_price      = DTL3.Substring(68,8).Trim(); 
					brand          = DTL3.Substring(88,10).Trim();  
					mfgid          = DTL3.Substring(129,15).Trim();
					pkg            = DTL3.Substring(145,14).Trim();
					purch_unit     = DTL3.Substring(186,2).Trim();


					len            = DTL4.Substring(5,8).Trim();
					wth            = DTL4.Substring(14,8).Trim();
					hgt            = DTL4.Substring(23,8).Trim();
					cube           = DTL4.Substring(32,10).Trim();
					ti             = DTL4.Substring(43,3).Trim();
					hi             = DTL4.Substring(47,3).Trim();
					wt             = DTL4.Substring(51,8).Trim();
					twt            = DTL4.Substring(60,8).Trim();
					pack_date      = DTL4.Substring(69,8).Trim();
					expiry_date    = DTL4.Substring(78,8).Trim();

					prd			   = nsn.Substring(0,4)+nsn.Substring(9,4).Trim();

					whproduct = asnlayer.getwhproduct(nsn);
					if (whproduct == "") 
					{ 
						lblError.Text = filename+" =>Error in record "+recordno +
							" Lines from "+(recordno*4-2)+" To "+(recordno*4+1)+"- NSN not found";
						return "";
					}
					warehouse = whproduct.Substring (0,2);
					product  = whproduct.Substring (2,whproduct.Length -2);

					qty_ordered = asnlayer.getPoQty(po_number,warehouse,product);
					if (qty_ordered == "") 
					{
						lblError.Text =  filename+" =>Error in record  "+recordno +
							" Lines from "+(recordno*4-2)+" To "+(recordno*4+1)+"- PO_Number not found";
						return "";
					}

					errorDetl=asnlayer.saveasnTxtDetail( asn_no,po_number,nsn,warehouse,product,qty_ordered,qty_shipped,
						vendor_cost,bmmi_price,napa_discount,brand,pack_date,
						expiry_date,cube,ti,hi,wt,recordno,filename
						);

					if (errorDetl.Length >0)
					{
						lblError.Text =errorDetl;
						sr.Close ();
						asnlayer.rollbackTrans ();
						asnlayer.closedBConnection ();
						utl.moveToErr(filepath,asndirectories.asnerrdir+filename);
						return "";
					}

				}while (DTL1 != null); 
			
				
				lblError.Text =" Records successfully saved into database";
				errorDetl+=asnlayer.updatefilestatus(filename);
				asnlayer.saveasnstat (asn_no,"EDIASN",po_number);
				asnlayer.updateAutoNo(asn_no,"ASNNO");
				asnlayer.updatefilestatus (filename);
				asnlayer.commitTrans ();
						
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				asnlayer.rollbackTrans ();
				lblError.Text ="Error with uploading.Make sure the correct file is uploaded";
				return "";
			}
			finally
			{
				sr.Close();
				asnlayer.closedBConnection ();
			}
			
			utl.moveToOut(filepath,asndirectories.asnoutdir+filename);
			return "";
			
		}

	

	
	}//class end
}
