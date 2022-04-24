using System;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Web.Security;
namespace gS
{
	/// <summary>
	/// Summary description for Datalayer.
	/// </summary>
	public class Datalayer
	{

		  
		protected SqlCommand sqlComm;	
		protected SqlConnection sqlConn;
		protected SqlTransaction sqlTrans;
		protected SqlDataReader sqlDReader;
		protected SqlDataAdapter sqlDAdapter;
		protected SqlParameter sqlParam1;
		protected SqlParameter sqlParam2;
		protected int retErr;
		protected string connStr;
		protected string strSql;
		protected bool bConnOpen=false;
			

		public Datalayer()
		{
//			connStr				  = "Provider=msdaora;Data Source=CS3;User Id=bmmi;Password=secret;";
//			sqlConn			      = new SqlConnection(connStr);
//			retErr				  = 0;
//			strSql				  =	"";
//			sqlDAdapter			  = new SqlDataAdapter();
//			if(opendBConn())
//			{
//				sqlTrans			  = sqlConn.BeginTransaction();
//				sqlComm			      = sqlConn.CreateCommand();
//				sqlComm.Connection	  = sqlConn;
//				sqlComm.Transaction   = sqlTrans;
//				bConnOpen=true;
//				
//			}
//			else
//			{
//				bConnOpen=false;
//			}

		}
		
		private bool closedBConn()
		{
			try
			{
				if(sqlConn.State.ToString() !="Closed")
					sqlConn.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}
		
		private bool opendBConn()
		{
			try
			{
				if(sqlConn.State.ToString()!="Open")
					sqlConn.Open();
			}
			catch
			{
				return false;
			}
			return true;
		}

		public void StoreAccountDetails( string userName, string passwordHash, string salt, 
										 string FullName, char Sex, string Country,
										 string state, string city, string phone,
										string Address1,string Address2)
		{
			
			SqlConnection conn =		  
				new SqlConnection( "Server=(local);" + "user=sa;password=password;" +
				"database=gShare");
			SqlCommand cmd = new SqlCommand("RegisterUser", conn );
			cmd.CommandType = CommandType.StoredProcedure;
			SqlParameter sqlParam = null;

			sqlParam = cmd.Parameters.Add("@userName", SqlDbType.VarChar,100);
			sqlParam.Value = userName;

			sqlParam = cmd.Parameters.Add("@passwordHash ", SqlDbType.VarChar,40);
			sqlParam.Value = passwordHash;

			sqlParam = cmd.Parameters.Add("@salt", SqlDbType.VarChar, 10);
			sqlParam.Value = salt;

			sqlParam = cmd.Parameters.Add("@FullName", SqlDbType.VarChar,255);
			sqlParam.Value = FullName;

			sqlParam = cmd.Parameters.Add("@Sex", SqlDbType.Char,1);
			sqlParam.Value = Sex;

			sqlParam = cmd.Parameters.Add("@Country", SqlDbType.VarChar,50);
			sqlParam.Value = Country;

			sqlParam = cmd.Parameters.Add("@state", SqlDbType.VarChar,50);
			sqlParam.Value = state;

			sqlParam = cmd.Parameters.Add("@city", SqlDbType.VarChar,50);
			sqlParam.Value = city;

			sqlParam = cmd.Parameters.Add("@phone", SqlDbType.VarChar,50);
			sqlParam.Value = phone;

			sqlParam = cmd.Parameters.Add("@Address1", SqlDbType.VarChar,255);
			sqlParam.Value = Address1;

			sqlParam = cmd.Parameters.Add("@Address2", SqlDbType.VarChar,255);
			sqlParam.Value = Address2;


			try
			{
				conn.Open();
				cmd.ExecuteNonQuery();
			}
			catch( Exception ex )
			{
				// Code to check for primary key violation (duplicate account name)
				// or other database errors omitted for clarity
				throw new Exception("Exception adding account. " + ex.Message);
			}
			finally
			{
				conn.Close();
			} 
		}

		public bool VerifyPassword(string suppliedUserName, string suppliedPassword )
		{ 
			bool passwordMatch = false;
			
			SqlConnection conn = new SqlConnection( "Server=(local);" +
				"Integrated Security=SSPI;" +
				"database=gShare");
			SqlCommand cmd = new SqlCommand( "LookupUser", conn );
			cmd.CommandType = CommandType.StoredProcedure;
			
			SqlParameter sqlParam = cmd.Parameters.Add("@userName",SqlDbType.VarChar,255);
			sqlParam.Value = suppliedUserName;
			try
			{
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				reader.Read(); // Advance to the one and only row
				// Return output parameters from returned data stream
				string dbPasswordHash = reader.GetString(0);
				string salt = reader.GetString(1);
				reader.Close();
				// Now take the salt and the password entered by the user
				// and concatenate them together.
				string passwordAndSalt = String.Concat(suppliedPassword, salt);
				// Now hash them
				string hashedPasswordAndSalt =       
					FormsAuthentication.HashPasswordForStoringInConfigFile( passwordAndSalt,"SHA1");
				// Now verify them.
				passwordMatch = hashedPasswordAndSalt.Equals(dbPasswordHash);
			}
		  
			catch (Exception ex)
		  
			{
				throw new Exception("Execption verifying password. " +
					ex.Message);
			}
		  
			finally
	  
			{
				conn.Close();
			}
			return passwordMatch;
		}
	}
}
