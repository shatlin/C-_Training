//using System;
using System.Text.RegularExpressions;
using System.IO;
//using System.Web;


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
	/// All generally usable functions are defined in Utilities class
	/// </summary>
	public class Utilities
	{
		public Utilities()
		{

		}


		/// <summary>
		/// Checks if the given string can be converted to an integer
		/// </summary>
		/// <param name="iVal"></param>
		/// <returns>true if the string is a number ,false if the string is not a number</returns>
		public bool ValidateNumber(string iVal)
		{
		

			Regex objNotNaturalPattern=new Regex("[^0-9]");
			Regex objNaturalPattern=new Regex("0*[1-9][0-9]*");

			return  !objNotNaturalPattern.IsMatch(iVal) &&
				objNaturalPattern.IsMatch(iVal);


		}
		
		/// <summary>
		/// checks if the given string exists in another string
		/// </summary>
		/// <param name="excelvalue">the string to check</param>
		/// <param name="fieldname">name given to the cell</param>
		/// <param name="specificvalues">the full string in which excelvalue is checked</param>
		/// <param name="cell">the cell name</param>
		/// <returns></returns>
		public string ValidateSpecific(string excelvalue,string fieldname,string specificvalues,string cell)
		{
			if(specificvalues.IndexOf (excelvalue)==-1)
			{
				return  cell+" => "+fieldname+" VALUE"+" "+excelvalue+ " "+" IS NOT A VALID ENTRY !"; 
			}
			return "";
		}


		/// <summary>
		/// gets a string and checks if it is in date format
		/// </summary>
		/// <param name="excelvalue">value taken from an excel sheet</param>
		/// <param name="fieldname">name given to the cell</param>
		/// <param name="cell">cell range C1:C2</param>
		/// <returns></returns>
		public string ValidateDate(string excelvalue,string fieldname,string cell)
		{
					
			Utilities utl= new Utilities ();
			string datepart=getdatepart(excelvalue);
			string errorDetl=utl.checkDateFormat(datepart);
			if (errorDetl.Length >0)
			{
				return cell+"=> "+errorDetl;
			}
					
			return "";
					

		}

		/// <summary>
		/// gets the date part of a string which is in datetime format
		/// </summary>
		/// <param name="datetime"></param>
		/// <returns></returns>
		public string getdatepart(string datetime)
		{
			int datepart=datetime.IndexOf (' ');
			if (datepart !=-1)
			{
				return(datetime.Substring (0,datepart));
			}
			else 
			{
				return datetime;
			}
		}


		/// <summary>
		/// checks if the string datepart is in date format
		/// </summary>
		/// <param name="datepart"></param>
		/// <returns></returns>
		public string checkDateFormat(string datepart)
		{
			datepart=datepart.Replace ("-","/");
			DateTime dt=new DateTime ();
			string[] datearray=null;
			int datecheck;
			

			try
			{
				
				dt=Convert.ToDateTime (datepart);
			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "  "+datepart+" IS NOT IN CORRECT DATE FORMAT(MM/DD/RRRR) !";
			}
			try
			{
				datearray=datepart.Split ('/');
				for(int i=0;i<datearray.Length;i++)
				{
					datecheck=Convert.ToInt32 (datearray[i]);
				}

			}
			catch(Exception ex)
			{
				string error=ex.Message ;
				return "  "+datepart+" IS NOT IN CORRECT DATE FORMAT(MM/DD/RRRR) !";
			}

			return "";
		}


		/// <summary>
		/// generates a number as year+month+day+000
		/// </summary>
		/// <returns></returns>
		public string generateAutoNumber()
		{
			DateTime datedetail = DateTime.Now;
					
			string yearpart = datedetail.Year.ToString();
			string monthpart= datedetail.Month.ToString() ;
			string daypart  = datedetail.Day.ToString(); 
					
			if (Convert.ToInt32 (monthpart) <10)
				monthpart="0"+monthpart;
			if (Convert.ToInt32 (daypart) <10)
				daypart="0"+daypart;
					
			return(yearpart+monthpart+daypart+"000");
				
		}

		/// <summary>
		/// checks if the given string is in number format
		/// </summary>
		/// <param name="sheet">sheet name</param>
		/// <param name="excelvalue">the string taken from excelsheet</param>
		/// <param name="fieldname">name given to the cell</param>
		/// <param name="cell">cell range C1:C2</param>
		/// <returns></returns>
		public string ValidateExcelNumber(string sheet,string excelvalue,string fieldname,string cell)
		{

			Regex objNotNumberPattern=new Regex("[^0-9.-]");
			Regex objTwoDotPattern=new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			Regex objTwoMinusPattern=new Regex("[0-9]*[-][0-9]*[-][0-9]*");
			String strValidRealPattern="^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
			String strValidIntegerPattern="^([-]|[0-9])[0-9]*$";
			Regex objNumberPattern =new Regex("(" + strValidRealPattern +")|(" + strValidIntegerPattern + ")");

							
				

			if( !objNotNumberPattern.IsMatch(excelvalue) &&
				!objTwoDotPattern.IsMatch(excelvalue) &&
				!objTwoMinusPattern.IsMatch(excelvalue) &&
				objNumberPattern.IsMatch(excelvalue)
				)
			{
				return "";
			}
			else
			{
				return  sheet+"-"+cell+" => "+fieldname+" VALUE"+" "+excelvalue+ " "+" MUST BE A NUMBER !"; 
			}
					
					
		}


		/// <summary>
		/// checks if the given string is in number format
		/// </summary>
		/// <param name="sheet">sheet name</param>
		/// <param name="excelvalue">the string taken from excelsheet</param>
		/// <param name="fieldname">name given to the cell</param>
		/// <param name="cell">cell range C1:C2</param>
		/// <returns></returns>
		public string ValidateExcelInteger(string sheet,string excelvalue,string fieldname,string cell)
		{
			Regex objNotIntPattern=new Regex("[^0-9-]");
			Regex objIntPattern=new Regex("^-[0-9]+$|^[0-9]+$");

			if( !objNotIntPattern.IsMatch(excelvalue) &&
				objIntPattern.IsMatch(excelvalue))
			{
				return "";
			}
			else
			{
				return  sheet+"-"+cell+" => "+fieldname+" VALUE"+" "+excelvalue+ " "+" CANNOT BE A DECIMAL NUMBER !"; 
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sheet">sheet name</param>
		/// <param name="excelvalue">the string taken from excelsheet</param>
		/// <param name="fieldname">name given to the cell</param>
		/// <param name="size">length of the cell</param>
		/// <param name="cell">cell range C1:C2</param>
		/// <returns></returns>
		public string checkXLEmpty(string sheet,string excelvalue,string fieldname,int size,string cell)
		{
			if(excelvalue.Length ==0)
			{
				return  sheet+"-"+cell+" => "+fieldname+"CAN NOT BE EMPTY !"; 
			}
			return "";
			
		}


		/// <summary>
		/// checks if the given string is greater than the expected length
		/// </summary>
		/// <param name="sheet">sheet name</param>
		/// <param name="excelvalue">the string taken from excelsheet</param>
		/// <param name="fieldname">name given to the cell</param>
		/// <param name="size">length of the cell</param>
		/// <param name="cell">cell range C1:C2</param>
		/// <returns></returns>
		public string checkMaxLength(string sheet,string excelvalue,string fieldname,int size,string cell)
		{
			string errorDetl="";
			if (excelvalue.Length == 0)
			{
				errorDetl= sheet+"-"+cell+" => "+fieldname+" "+excelvalue+" "
					+" CANNOT BE EMPTY ! " ; 
			}
			if (excelvalue.Length > size)
			{
				errorDetl+=sheet+"-"+cell+" => "+fieldname+" "+excelvalue+" "
					+" LENGTH CAN NOT BE GREATER THAN "+size+"!" ; 
			}
			return errorDetl;
					
		}

	
	
		/// <summary>
		/// Function to test for Positive Integers with zero inclusive
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns></returns>
		public bool IsWholeNumber(string strNumber)
		{
			Regex objNotWholePattern=new Regex("[^0-9]");

			return !objNotWholePattern.IsMatch(strNumber);
		}


		
		/// <summary>
		/// Function to Test for Integers both Positive & Negative
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns></returns>
		public bool IsInteger(string strNumber)
		{
			Regex objNotIntPattern=new Regex("[^0-9-]");
			Regex objIntPattern=new Regex("^-[0-9]+$|^[0-9]+$");

			return  !objNotIntPattern.IsMatch(strNumber) &&
				objIntPattern.IsMatch(strNumber);
		}

		

		/// <summary>
		/// Function to Test for Positive Number both Integer & Real
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns></returns>
		public bool IsPositiveNumber(string strNumber)
		{
			Regex objNotPositivePattern=new Regex("[^0-9.]");
			Regex objPositivePattern=new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
			Regex objTwoDotPattern=new Regex("[0-9]*[.][0-9]*[.][0-9]*");

			return !objNotPositivePattern.IsMatch(strNumber) &&
				objPositivePattern.IsMatch(strNumber)  &&
				!objTwoDotPattern.IsMatch(strNumber);
		}

		
		/// <summary>
		/// Function to test whether the string is valid number or not
		/// </summary>
		/// <param name="strNumber"></param>
		/// <returns></returns>
		public bool IsNumber(string strNumber)
		{
			Regex objNotNumberPattern=new Regex("[^0-9.-]");
			Regex objTwoDotPattern=new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			Regex objTwoMinusPattern=new Regex("[0-9]*[-][0-9]*[-][0-9]*");
			String strValidRealPattern="^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
			String strValidIntegerPattern="^([-]|[0-9])[0-9]*$";
			Regex objNumberPattern =new Regex("(" + strValidRealPattern +")|(" + strValidIntegerPattern + ")");

			return !objNotNumberPattern.IsMatch(strNumber) &&
				!objTwoDotPattern.IsMatch(strNumber) &&
				!objTwoMinusPattern.IsMatch(strNumber) &&
				objNumberPattern.IsMatch(strNumber);
		}




		/// <summary>
		/// Function To test for Alphabets. 
		/// </summary>
		/// <param name="strToCheck"></param>
		/// <returns></returns>
		public bool IsAlpha(string strToCheck)
		{
			Regex objAlphaPattern=new Regex("[^a-zA-Z]");

			return !objAlphaPattern.IsMatch(strToCheck);
		}


		
		/// <summary>
		/// Function to Check for AlphaNumeric.
		/// </summary>
		/// <param name="strToCheck"></param>
		/// <returns></returns>
		public bool IsAlphaNumeric(string strToCheck)
		{
			Regex objAlphaNumericPattern=new Regex("[^a-zA-Z0-9]");

			return !objAlphaNumericPattern.IsMatch(strToCheck);    
		}

		
		/// <summary>
		/// moves the indirfile to errdirfile
		/// </summary>
		/// <param name="indirfile"></param>
		/// <param name="errdirfile"></param>
		public void moveToErr(string indirfile,string errdirfile)
		{
			FileInfo errorfile     = new FileInfo(errdirfile);
			FileInfo uploadedfile  = new FileInfo(indirfile);
			errorfile.Delete();
			try
			{
				uploadedfile.MoveTo(errdirfile);
			}
			catch(Exception ex)
			{
				string ss=ex.Message ;
			}
		}

		
		/// <summary>
		/// moves the indirfile to outdirfile
		/// </summary>
		/// <param name="indirfile"></param>
		/// <param name="outdirfile"></param>
		public void moveToOut(string indirfile,string outdirfile)
		{
			
			FileInfo outfile       = new FileInfo(outdirfile);
			FileInfo uploadedfile  = new FileInfo(indirfile);
			outfile.Delete();
			try
			{
				uploadedfile.MoveTo (outdirfile);
			}
			catch(Exception ex)
			{
				string ss=ex.Message ;
			}
			
		}		 

				
		/// <summary>
		/// This function returns status names
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		public string getStatus(string status)
		{
			string retStatus="";
			switch (status.Trim())
			{
				case "1":
					retStatus = "Forward Order";
					break;
				case "2":
					retStatus = "Credit Stopped";
					break;
				case "3":
					retStatus = "Credit Stopped & Back order";
					break;
				case "4":
					retStatus = "Back order";
					break;
				case "5":
					retStatus = "Awaiting Dispatch";
					break;
				case "6":
					retStatus = "Dispatch Note Printed";
					break;
				case "7":
					retStatus = "Dispatch Confirmed";
					break;
				case "8":
					retStatus = "Invoiced";
					break;
				case "9":
					retStatus = "Deleted";
					break;
				default:
					break;
			}
				
			return retStatus;
		}



		/// <summary>
		/// This function returns the selected list value with the formated output 
		/// </summary>
		/// <param name="theListBox"></param>
		/// <returns></returns>
		public static string GetListSelections(System.Web.UI.WebControls.ListBox theListBox)
		{
			System.Text.StringBuilder outList=new System.Text.StringBuilder();

			foreach(System.Web.UI.WebControls.ListItem lvItem in theListBox.Items)
			{
				if(lvItem.Selected)
				{
					outList.Append("'").Append(lvItem.Value.Trim()).Append("', ");

				}
			}
					

			if(outList.Length>0)
				return outList.Remove(outList.Length-2, 2).ToString();
			else
				return "";
		}

		
		
		/// <summary>
		/// This function returns the selected list text with the formated output  
		/// </summary>
		/// <param name="theListBox"></param>
		/// <returns></returns>
		public static string GetListSelections1(System.Web.UI.WebControls.ListBox theListBox)
		{
			System.Text.StringBuilder outList=new System.Text.StringBuilder();

			foreach(System.Web.UI.WebControls.ListItem lvItem in theListBox.Items)
			{
				if(lvItem.Selected)
				{
					outList.Append("'").Append(lvItem.Text.Trim()).Append("', ");

				}
			}
					

			if(outList.Length>0)
				return outList.Remove(outList.Length-2, 2).ToString();
			else
				return "";
		}

	
		
		/// <summary>
		/// This function returns the formated value starting with uppercase 
		/// </summary>
		/// <param name="inputStr"></param>
		/// <returns></returns>
		public static string capString(string inputStr)
		{
			System.Text.StringBuilder newStr=new System.Text.StringBuilder(inputStr);

			for(int i=0; i<newStr.Length; i++)
			{
				if(i==0)
					newStr.Replace(newStr[0], char.ToUpper(newStr[0]), 0, 1);
				else if(newStr[i-1].CompareTo(' ')==0)
					newStr.Replace(newStr[i], char.ToUpper(newStr[i]), i, 1);
			}

			return newStr.ToString();
		}


		// function returns the decoded password.
		public static string hashPassword(string inputStr)
		{
			string newStr=System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(inputStr, "SHA1");

			return newStr;
		}

		// function returns the username who loged on to the system.
		public static string UserName()
		{
			//try
			//{
			string [] outStr =  HttpContext.Current.User.Identity.Name.Replace("-", "±").Split('±');			
			return outStr[0].ToString();
			//}
			//catch (Exception ex)
			//{
			//	return null;
			//}
		}

		public static string Warehouse()
		{
			string [] outStr =  HttpContext.Current.User.Identity.Name.Replace("-", "±").Split('±');			
			return outStr[1].ToString();
			//return HttpContext.Current.User.Identity.Name;
		}

	}
}
