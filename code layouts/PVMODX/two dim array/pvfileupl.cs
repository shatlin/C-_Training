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
using Excel;
using System.Text;
using System.IO;

namespace PV
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
		protected System.Web.UI.HtmlControls.HtmlInputButton btnUploadTheFile;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnViewFileDet;
		protected System.Web.UI.WebControls.Panel pnlUpl;
		protected System.Web.UI.WebControls.Panel pnlErr;
		public static string filepath="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}
		public PVFILEUPL()
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
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.btnUploadTheFile.ServerClick += new System.EventHandler(this.btnUploadTheFile_ServerClick);
			this.btnViewFileDet.ServerClick += new System.EventHandler(this.btnViewFileDet_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void biindRF()
		{
			DBLayer dal = new DBLayer();
			DataSet dsRF = RF_DS();
			

			try
			{
				
				DataGrid.DataSource = dsRF.Tables["DATA$"].DefaultView;
				DataGrid.DataBind();
				pnlUpl.Visible =true;
			}

			catch(Exception ex)
			{
				txtOutput.InnerHtml = "Please Upload the RF file with correct format"; 
				
			}
			finally
			{
				
			}

		}

		private void bindErrorGrid(string[] errorArray)
		{
			DBLayer dal = new DBLayer();
			string[,] arr = new string[4,2];
			for(int i=0;i<4;i++)
				for(int j=0;j<2;j++)
					arr[i,j]=i+"_"+j;
			
			try
			{
				
				Datagrid2.DataSource = new Mommo.Data.ArrayDataView(errorArray);
				Datagrid2.DataBind();
				pnlErr.Visible =true;

			}

			catch(Exception ex)
			{
				txtOutput.InnerHtml =ex.Message ;
				
			}
			finally
			{
				
			}

		}




		public DataSet RF_DS()
		{
			StringBuilder sbConn = new StringBuilder();
			sbConn.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+filepath);
			sbConn.Append(";Extended Properties=");
			sbConn.Append(Convert.ToChar(34));
			sbConn.Append("Excel 8.0;HDR=Yes;IMEX=1");
			sbConn.Append(Convert.ToChar(34));
			string strConn=sbConn.ToString();
			OleDbConnection objConn=new OleDbConnection(strConn); 

			try
			{
				OleDbDataAdapter oAdapter=new OleDbDataAdapter("SELECT * FROM [DATA$]",objConn);
				DataSet dbDataSet = new DataSet();
				oAdapter.Fill(dbDataSet,"DATA$");
				objConn.Close();
				return dbDataSet;
			}

			catch(Exception ex)
			{
				txtOutput.InnerHtml = "Please Upload the RF file with correct format"; 
				return null;
			}
			finally
			{
				objConn.Close ();
			}
			
		}

		protected void btnUploadTheFile_ServerClick(object sender, System.EventArgs e)
		{
			//Uploading files
			string strFileNameOnServer   = uplTheFile.Value ;
			string strBaseLocation	     = "c:\\project\\pvmodx\\RF\\IN\\";
			int filenameindex			 =strFileNameOnServer.LastIndexOf("\\");
			strFileNameOnServer			 =strFileNameOnServer.Substring(filenameindex+1);
  
 
 
			if ("" == strFileNameOnServer) 
			{
				txtOutput.InnerHtml = "Error - Please select a file and then press upload.";
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
					txtOutput.InnerHtml = "File <b>" +strFileNameOnServer+"</b> uploaded successfully";
					pnlUpl.Visible =false;
					
				
				}
				catch (Exception ex) 
				{
					txtOutput.InnerHtml = "Error saving <b>" + 
					strFileNameOnServer+"</b><br>"+ e.ToString();
				}
			}
  
	
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			if( filepath.Length !=0)
			{
					
				string strConn ="Provider=Microsoft.Jet.OLEDB.4.0;" +
								"Data Source="+filepath+"; Jet OLEDB:Engine Type=5;"+
								"Extended Properties=Excel 8.0;";

				int [] dry=null;
				int [] chl=null;
				int [] frz=null;
				int [] drypallets=null;
				int [] drytrprio=null;
				int [] chlpallets=null;
				int [] chltrprio=null;
				int [] frzpallets=null;
				int [] frztrprio=null;
				int [] errordetl=null;
				int [] errorArray=null;
				
				ArrayList errorArrayList=new ArrayList();

				OleDbConnection objConn=new OleDbConnection(strConn);
				objConn.Open(); 
			
				OleDbCommand oCommand = new OleDbCommand();
				oCommand.Connection = objConn;
				oCommand.CommandText = "SELECT * FROM [DATA$]";
				

				OleDbDataReader dataReader;
				dataReader = oCommand.ExecuteReader();

				
				Utilities utl = new Utilities();
				
				/* collecting the count of the rows */			
//				int rowCount=0;
//				while (dataReader.Read())
//				{
//					
//
//				}
//			

				/* check dry  sheets for errors */
				int rowCount=-1;
				while (dataReader.Read())
				{
					rowCount++;
		
					/* 
					 * Solution for creating two dimensional ARRAYLIST should be found out to proceed
					 * this single dimensional arrays are created to read the excel file once and then do
					 * all processing from the arrays
					 */
 
					dry[rowCount]		=	dataReader[0].ToString();
					drypallets[rowCount]=	dataReader[1].ToString();
					drytrprio[rowCount]	=	dataReader[2].ToString();
					chl[rowCount]		=	dataReader[3].ToString();
					chlpallets[rowCount]=	dataReader[4].ToString();
					chltrprio[rowCount]	=	dataReader[5].ToString();
					frz	[rowCount]		=	dataReader[6].ToString();
					frzpallets[rowCount]=	dataReader[7].ToString();
					frztrprio[rowCount]	=	dataReader[8].ToString();


					if((dry.Length >0) && !utl.ValidateNumber(dry.Trim()))
					{
						lblError.Text = "Dry entries in [DATA] of excel file should be number";
						return;
					}
					if(dry.Length >0)
					{
						dry="DRY "+Convert.ToInt32(dry);
						errordetl=chkRF(dry,drypallets,drytrprio);
						if (errordetl.Length!=0) 
						{

							errorArray=errordetl.Split ('!');
							for(int j=0;j<(errorArray.Length-1);j++)
							{
								if(j==0)
								{
									errorArrayList.Add (dry+"    "+ errorArray[0]);
								}
								else
								{
									errorArrayList.Add ("        "+errorArray[j]);
								}

							}
						}
					
					}
				}
				
				
				dataReader.Close ();		
				oCommand.Cancel(); 
				dataReader = oCommand.ExecuteReader();
			
				/* check chilled  sheets for errors */
				while (dataReader.Read())
				{
					chl			=	dataReader[3].ToString();
					chlpallets	=	dataReader[4].ToString();
					chltrprio	=	dataReader[5].ToString();
					if((chl.Length >0) && !utl.ValidateNumber(chl.Trim()))
					{
						lblError.Text = "Chilled entries in [DATA] of excel file  should be number";
						return;
					}
					if(chl.Length >0)
					{
										
						chl="CHILLED "+Convert.ToInt32(chl);
						errordetl=chkRF(chl,chlpallets,chltrprio);
						if (errordetl.Length!=0) 
						{

							errorArray=errordetl.Split ('!');
							for(int j=0;j<(errorArray.Length-1);j++)
							{
								if(j==0)
								{
									errorArrayList.Add (chl+"    "+ errorArray[0]);
								}
								else
								{
									errorArrayList.Add ("        "+errorArray[j]);
								}

							}
						}
					
					}

				}
				
				dataReader.Close ();		
				oCommand.Cancel(); 
				dataReader = oCommand.ExecuteReader();
				
				/* check Frozen sheets for errors */
				while (dataReader.Read())
				{
					frz			=	dataReader[6].ToString();
					frzpallets	=	dataReader[7].ToString();
					frztrprio	=	dataReader[8].ToString();
					if((frz.Length >0)&& !utl.ValidateNumber(frz.Trim()))
					{
						lblError.Text = "Frozen entries in [DATA] of excel file  should be number";
						return;
					}
					if(frz.Length >0)
					{
						frz="FROZEN "+Convert.ToInt32(frz);
						errordetl=chkRF(frz,frzpallets,frztrprio);

						if (errordetl.Length!=0) 
						{

							errorArray=errordetl.Split ('!');

							for(int j=0;j<(errorArray.Length-1);j++)
							{
								if(j==0)
								{
									errorArrayList.Add (frz+"    "+ errorArray[0]);
								}
								else
								{
									errorArrayList.Add ("        "+errorArray[j]);
								}

							}
						}

										
					}//if(frz.Length >0)

				}//while (dataReader.Read()) for frozen

				int dd=errorArrayList.Count ;
				errorArray=(String[])errorArrayList.ToArray(typeof(String));
				bindErrorGrid(errorArray);
				dataReader.Close ();		
				oCommand.Cancel(); 
				objConn.Close();
				
/* If the checking of the xls file is successful then save the records into database */

				if(txtOutput.InnerHtml.IndexOf ("cell")==-1 )
				{
					
					
					objConn.Open ();
					dataReader = oCommand.ExecuteReader();
					while (dataReader.Read())
					{
				
						dry			=	dataReader[0].ToString();
						drypallets	=	dataReader[1].ToString();
						drytrprio	=	dataReader[2].ToString();
						if((dry.Length >0) && !utl.ValidateNumber(dry.Trim()))
						{
							lblError.Text = "Dry entries in [DATA] of excel file should be number";
							return;
						}
						if(dry.Length >0)
						{
					
							dry="DRY "+Convert.ToInt32(dry);
							addRF(dry,drypallets,drytrprio);
						}
					}
					dataReader.Close ();		
					oCommand.Cancel(); 
				
					dataReader = oCommand.ExecuteReader();
	
					while (dataReader.Read())
					{
						chl			=	dataReader[3].ToString();
						chlpallets	=	dataReader[4].ToString();
						chltrprio	=	dataReader[5].ToString();
						if((chl.Length >0) && !utl.ValidateNumber(chl.Trim()))
						{
							lblError.Text = "Chilled entries in [DATA] of excel file  should be number";
							return;
						}
						if(chl.Length >0)
						{
							chl="CHILLED "+Convert.ToInt32(chl);
					
							addRF(chl,chlpallets,chltrprio);
						}

					}
					dataReader.Close ();		
					oCommand.Cancel(); 
				
					dataReader = oCommand.ExecuteReader();

					while (dataReader.Read())
					{
						frz			=	dataReader[6].ToString();
						frzpallets	=	dataReader[7].ToString();
						frztrprio	=	dataReader[8].ToString();
						if((frz.Length >0)&& !utl.ValidateNumber(frz.Trim()))
						{
							lblError.Text = "Frozen entries in [DATA] of excel file  should be number";
							return;
						}
						if(frz.Length >0)
						{
							frz="FROZEN "+Convert.ToInt32(frz);
							addRF(frz,frzpallets,frztrprio);
						}

					}

					txtOutput.InnerHtml+=".Excel Records saved into Database<BR>";
					dataReader.Close(); 
				}//if(txtOutput.InnerHtml.IndexOf ("cell")==-1 )
			}//if filepath.length!=0
			else
			{
			txtOutput.InnerHtml="Please Upload a file and then click save";
			}
		}

		public string chkRF(string cntrtype,string pallets,string trpriority)
		{
		
			Utilities utl=new Utilities();
			string errordetl="";	

			string tcn			=getExcelValue(cntrtype,"C19:C20");
			string container	=getExcelValue(cntrtype,"G10:G11");
			string carriercode	=getExcelValue(cntrtype,"G15:G16");
			int	   itemcnt		=0;
			string poe			=getExcelValue(cntrtype,"G16:G17");			
			string pod			=getExcelValue(cntrtype,"G17:G18");			
			string dodaac		=getExcelValue(cntrtype,"C9:C10");			
			string pvdodaac		=tcn.Substring (0,6);
			string jshipdate	=getExcelValue(cntrtype,"C18:C19");
			string stuffdate	=getExcelValue(cntrtype,"G9:G10");
			
			int datepart=stuffdate.IndexOf (' ');
			if (datepart !=-1)
			{
				stuffdate=stuffdate.Substring (0,datepart);
			}

			string shipdate		=stuffdate;
			string dlvrdate		=stuffdate;
			string pieces		="";
			string weight		=getExcelValue(cntrtype,"G11:G12");	
			string cube			="";
			string sealno		=getExcelValue(cntrtype,"G13:G14");	
			string dscp_ord_num	=getExcelValue(cntrtype,"G12:G13");
			string po_number	=getExcelValue(cntrtype,"G12:G13").Substring (0,6);
			string nsn			="";	
			string uom			="";
			string qty			="";
			string clin			="";
			string ctype		="";
					
			switch(cntrtype.Substring(0,3))
			{
				case "DRY":
					ctype="DRY";
					break;
				case "CHI":
					ctype="CHILLED";
					break;
				case "FRO":
					ctype="FROZEN";
					break;
				default:
					return "";
			}
			
			
			int i=22;

			errordetl +=utl.checkMaxLength(dodaac,"DODAAC",8,"C10");
			errordetl +=utl.ValidateExcelNumber(jshipdate,"RDD","C19");
			errordetl +=utl.checkMaxLength(tcn,"CONTAINER TCN",20,"C20");
			errordetl +=utl.checkMaxLength(container,"CONTAINER #",15,"G11");
			errordetl +=utl.ValidateExcelNumber(weight,"GROSS WEIGHT(LBS)","G12");
			errordetl +=utl.checkMaxLength(sealno,"SEALNO",20,"G14");
			errordetl +=utl.checkMaxLength(carriercode,"SCAC",10,"G16");
			errordetl +=utl.checkMaxLength(poe,"POE",5,"G17");
			errordetl +=utl.checkMaxLength(pod,"POD",5,"G18");

			
			try
			{
				do 
				{
					clin			=getExcelValue(cntrtype,"A"+i+":A"+(i+1));	
					nsn				=getExcelValue(cntrtype,"B"+i+":B"+(i+1));	
					nsn				=nsn.Replace("-","");
					uom				=getExcelValue(cntrtype,"E"+i+":E"+(i+1));	
					qty				=getExcelValue(cntrtype,"F"+i+":F"+(i+1));
					qty				=qty.Replace (",","");

					if (nsn!="")
					{
						itemcnt++;

						/*			Validating values received from excel	 */		
						errordetl +=utl.ValidateExcelNumber(clin,"SI#","A"+(i));
						errordetl +=utl.checkMaxLength(nsn,"NSN#",15,"B"+(i));
						errordetl +=utl.checkMaxLength(uom,"UNIT",15,"E"+(i));
						errordetl +=utl.ValidateExcelNumber(qty,"QUANTITY","F"+(i));
						
					}// end of if (nsn!="")
					i++;
				}
				while (nsn!="");

				cube	  =	getExcelValue(cntrtype,"D"+i+":D"+(++i));
				pieces	  =	getExcelValue(cntrtype,"D"+i+":D"+(i+1));
				
				errordetl +=utl.ValidateExcelNumber(cube,"CUBIC FEET","D"+(i+1));
				errordetl +=utl.ValidateExcelNumber(pieces,"TOTAL NUMBER OF UNIT(S):","D"+(i+1));
				
			}

			catch (Exception ex)
			{
				
				string errorMsg = ex.Message;
				txtOutput.InnerHtml  = "Error."+errorMsg+" in page "+cntrtype;

			}
			
			return errordetl;

		}	


		public int addRF(string cntrtype,string pallets,string trpriority)
		{
		
			int reterr = 0;
		
			//PVRFheader table variables 

			//jver		=	"",		pallets got from the calling function
			//tcnstatus	=	"H",	freetext	=""  tcmdcount =	0,		
			//trpriority got from calling function hazmat	=	"";

			string tcn			=getExcelValue(cntrtype,"C19:C20");
			string container	=getExcelValue(cntrtype,"G10:G11");
			string carriercode	=getExcelValue(cntrtype,"G15:G16");
			int	   itemcnt		=0;
			string poe			=getExcelValue(cntrtype,"G16:G17");			
			string pod			=getExcelValue(cntrtype,"G17:G18");			
			string dodaac		=getExcelValue(cntrtype,"C9:C10");			
			string pvdodaac		=tcn.Substring (0,6);
			string jshipdate	=getExcelValue(cntrtype,"C18:C19");
			string stuffdate	=getExcelValue(cntrtype,"G9:G10");
			Utilities utl=new Utilities();
			int datepart=stuffdate.IndexOf (' ');
			if (datepart !=-1)
			{
				stuffdate=stuffdate.Substring (0,datepart);
			}

			string shipdate		=stuffdate;
			string dlvrdate		=stuffdate;
			string pieces		="";
			string weight		=getExcelValue(cntrtype,"G11:G12");	
			string cube			="";
			string ctype		="";
			string sealno		=getExcelValue(cntrtype,"G13:G14");	
				
			//PVRFdetl table variables 
			
			// the excel line from which the detail info starts
			//lin="",ric="",pallets,weight,cube,condcode,intmtcn in detail table is 0
			// misc1,misc2,ctg_desc,inv_no,linestatus	="I";
			//tcn,container from the header part
			string dscp_ord_num	=getExcelValue(cntrtype,"G12:G13");
			string po_number	=getExcelValue(cntrtype,"G12:G13").Substring (0,6);
			string warehouse	="";
			string product		="";
			string nsn			="";	
			string uom			="";
			string qty			="";
			string dscp_desc	="";
			string clin			="";

			string connStr ="Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction CaseTrans = dbConn.BeginTransaction();
			OleDbCommand oCommand = dbConn.CreateCommand();
			OleDbDataReader dataReader;
			oCommand.Transaction = CaseTrans;

		
			switch(cntrtype.Substring(0,3))
			{
				case "DRY":
					ctype="DRY";
					break;
				case "CHI":
					ctype="CHILLED";
					break;
				case "FRO":
					ctype="FROZEN";
					break;
				default:
					return 0;
			}
			
			
			int i=22;
			
			try
			{
				do 
				{
					clin			=getExcelValue(cntrtype,"A"+i+":A"+(i+1));	
					nsn				=getExcelValue(cntrtype,"B"+i+":B"+(i+1));	
					nsn				=nsn.Replace("-","");
					uom				=getExcelValue(cntrtype,"E"+i+":E"+(i+1));	
					qty				=getExcelValue(cntrtype,"F"+i+":F"+(i+1));
					qty				=qty.Replace (",","");

				
					if (nsn!="")
					{
						itemcnt++;

						StringBuilder sbConn = new StringBuilder();
						sbConn.Append( "select WAREHOUSE,PRODUCT,DSCP_DESC from bmmi.pvcatcurr " );
						sbConn.Append( "where STOCK_NUMBER=");
						sbConn.Append("'"+nsn+"'" );
						oCommand.CommandText = sbConn.ToString();
						dataReader = oCommand.ExecuteReader(CommandBehavior.Default);
						dataReader.Read();

						warehouse = dataReader[0].ToString();
						product	  =	dataReader[1].ToString();
						dscp_desc = dataReader[2].ToString();
				
						dataReader.Close(); 
					/*			Validating values received from excel	 */		
		
										
						reterr= RF_addDetl(tcn,container,dscp_ord_num,po_number,warehouse,
								product,nsn,"","",uom,Convert.ToInt32(qty),
								0,0,0,"","",dscp_desc,"","","","",
								Convert.ToInt32 (clin),"I");		
					

					}// end of if (nsn!="")
					i++;
				}
				while (nsn!="");

				cube=getExcelValue(cntrtype,"D"+i+":D"+(i+1));
				i++;
				pieces=getExcelValue(cntrtype,"D"+i+":D"+(i+1));
				
				
					reterr= RF_addHeader(tcn,container,carriercode,itemcnt,0,poe, pod,
							dodaac,pvdodaac,Convert.ToInt32 (jshipdate),
							stuffdate,shipdate,dlvrdate,Convert.ToInt32 (pieces),
							Convert.ToInt32(weight),Convert.ToInt32 (cube),
							trpriority,"",ctype,sealno,"",
							Convert.ToInt32 (pallets),"H","");
	
				
				CaseTrans.Commit();

			}

			catch (Exception ex)
			{
				CaseTrans.Rollback();
				string errorMsg = ex.Message;
				txtOutput.InnerHtml = "Error Saving database files."+errorMsg+" in page "+cntrtype;

			}
			
			finally
			{
			dbConn.Close ();
			}

			return 0;

		}	

		public ArrayList test()
		{
			
			ArrayList myList = new ArrayList();
			int i;
        
			for(i=0; i<5; i++)
				myList.Add(i);
			return myList;	
			 
			
		}

		public int RF_addHeader(string tcn,string container,string carriercode,int itemcnt,
			int tcmdcount,string poe,string  pod,string dodaac,
			string pvdodaac,int jshipdate,string stuffdate,
			string shipdate,string dlvrdate,int pieces,
			int weight,int cube,string trpriority,string hazmat,
			string cntrtype,string sealno,string jver,
			int pallets,string tcnstatus,string freetext
			)	
			
			{
			
			int retErr = 0;
			string connStr = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction CaseTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = CaseTrans;
	
			try
			{
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append( "INSERT INTO bmmifsv.rfhead" );
				sbConn.Append( " values( '" );
				sbConn.Append( tcn );
				sbConn.Append( "','" );
				sbConn.Append( container );
				sbConn.Append( "','" );
				sbConn.Append( carriercode );
				sbConn.Append( "'," );
				sbConn.Append( itemcnt );
				sbConn.Append( "," );
				sbConn.Append( tcmdcount );
				sbConn.Append( ",'" );
				sbConn.Append( poe );
				sbConn.Append( "','" );
				sbConn.Append( pod );
				sbConn.Append( "','" );
				sbConn.Append( dodaac );
				sbConn.Append( "','" );
				sbConn.Append( pvdodaac );
				sbConn.Append( "'," );
				sbConn.Append( jshipdate );
				sbConn.Append( ",to_date('");
				sbConn.Append( stuffdate );
				sbConn.Append( "','mm/dd/rrrr'),to_date('");
				sbConn.Append( shipdate );
				sbConn.Append( "','mm/dd/rrrr'),to_date(' ");
				sbConn.Append( dlvrdate );
				sbConn.Append( "','mm/dd/rrrr'),");
				sbConn.Append( pieces );
				sbConn.Append( "," );
				sbConn.Append( weight );
				sbConn.Append( "," );
				sbConn.Append( cube );
				sbConn.Append( ",'" );
				sbConn.Append( trpriority );
				sbConn.Append( "','" );
				sbConn.Append( hazmat );
				sbConn.Append( "','" );
				sbConn.Append( cntrtype );
				sbConn.Append( "','" );
				sbConn.Append( sealno );
				sbConn.Append( "','" );
				sbConn.Append( jver );
				sbConn.Append( "'," );
				sbConn.Append( pallets );
				sbConn.Append( ",'" );
				sbConn.Append( tcnstatus );
				sbConn.Append( "','" );
				sbConn.Append( freetext );
				sbConn.Append( "')" );
			
				dbCommand.CommandText = sbConn.ToString();
				retErr = dbCommand.ExecuteNonQuery();
				CaseTrans.Commit();
			}
			catch (Exception ex)
			{
				CaseTrans.Rollback();
				string errorMsg = ex.Message;
				txtOutput.InnerHtml = "Error Saving database files."+errorMsg+" in page "+cntrtype;
			}

			finally
			{
				dbConn.Close();
			}

			return retErr;
		}


		public int RF_addDetl(string tcn,string container,string dscp_ord_num,
			string po_number,string warehouse,string product,
			string nsn,string lin,string ric,string uom,
			int qty,int pallets,int weight,int cube,
			string condcode,string intmtcn,string dscp_desc,
			string misc1,string misc2,string ctg_desc,
			string inv_no,int clin,string linestatus)

		{
			int retErr = 0;
			string connStr = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
					
			OleDbConnection dbConn = new OleDbConnection(connStr);
			dbConn.Open();
			OleDbTransaction CaseTrans = dbConn.BeginTransaction();
			OleDbCommand dbCommand = dbConn.CreateCommand();
			dbCommand.Transaction = CaseTrans;
	
			try
			{
				
				StringBuilder sbConn = new StringBuilder();
				sbConn.Append( "INSERT INTO bmmifsv.rfdetl" );
				sbConn.Append( " values( '" );
				sbConn.Append( tcn );
				sbConn.Append( "','" );
				sbConn.Append( container );
				sbConn.Append( "','" );
				sbConn.Append( dscp_ord_num );
				sbConn.Append( "','" );
				sbConn.Append( po_number );
				sbConn.Append( "','" );
				sbConn.Append( warehouse );
				sbConn.Append( "','" );
				sbConn.Append( product );
				sbConn.Append( "','" );
				sbConn.Append( nsn );
				sbConn.Append( "','" );
				sbConn.Append( lin );
				sbConn.Append( "','" );
				sbConn.Append( ric );
				sbConn.Append( "','" );
				sbConn.Append( uom );
				sbConn.Append( "'," );
				sbConn.Append( qty );
				sbConn.Append( "," );
				sbConn.Append( pallets );
				sbConn.Append( "," );
				sbConn.Append( weight );
				sbConn.Append( "," );
				sbConn.Append( cube );
				sbConn.Append( ",'" );
				sbConn.Append( condcode );
				sbConn.Append( "','" );
				sbConn.Append( intmtcn );
				sbConn.Append( "',trim('" );
				sbConn.Append( dscp_desc );
				sbConn.Append( "'),'" );
				sbConn.Append( misc1 );
				sbConn.Append( "','" );
				sbConn.Append( misc2 );
				sbConn.Append( "','" );
				sbConn.Append( ctg_desc );
				sbConn.Append( "','" );
				sbConn.Append( inv_no );
				sbConn.Append( "','" );
				sbConn.Append( clin );
				sbConn.Append( "','" );
				sbConn.Append( linestatus );
				sbConn.Append( "')" );
			
				dbCommand.CommandText = sbConn.ToString();
				retErr = dbCommand.ExecuteNonQuery();
				CaseTrans.Commit();
			}
			catch (Exception ex)
			{
				CaseTrans.Rollback();
				string errorMsg = ex.Message;
			}

			finally
			{
				dbConn.Close();
			}

			return retErr;
		}

		public string getExcelValue(string cntrtype,string range)
		{
				
			StringBuilder sbConn = new StringBuilder();
			sbConn.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+filepath);
			sbConn.Append(";Extended Properties=");
			sbConn.Append(Convert.ToChar(34));
			sbConn.Append("Excel 8.0;Hdr=No;IMEX=1");
			sbConn.Append(Convert.ToChar(34));
			
			string strConn=sbConn.ToString();
			string excelvalue="";
			
			OleDbConnection objConn=new OleDbConnection(strConn);
			objConn.Open(); 
			OleDbCommand oCommand = new OleDbCommand();
			
			oCommand.Connection = objConn;
			oCommand.CommandText = "SELECT * FROM ["+cntrtype+"$"+range+"]";
			
			OleDbDataReader dataReader;
			dataReader = oCommand.ExecuteReader(CommandBehavior.Default);
			dataReader.Read();

			while (dataReader.Read())
			{
				excelvalue = dataReader[0].ToString();
			}
			dataReader.Close(); 
			objConn.Close ();
			return excelvalue.Trim();
		}

		private void btnViewFileDet_ServerClick(object sender, System.EventArgs e)
		{
			
			if(filepath.Length ==0)
			{
				txtOutput.InnerHtml = "Please select a file to upload and view";
			}
			
			else if(filepath.EndsWith("xls"))
			{
				biindRF();
			}
			else
			{
				txtOutput.InnerHtml = "The file uploaded must be an excel file";
			}
		}


	}
}
