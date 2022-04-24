using System;
using System.Security.Cryptography;
using System.Web.Security;
//comments
namespace gS
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class Utilities
	{
		public Utilities()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static string CreateSalt(int size)
		{
			// Generate a cryptographic random number using the cryptographic
			// service provider
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] buff = new byte[size];
			rng.GetBytes(buff);
			// Return a Base64 string representation of the random number
			return Convert.ToBase64String(buff);
		}


		public static string CreatePasswordHash(string pwd, string salt)
		{
			string saltAndPwd = String.Concat(pwd, salt);
			string hashedPwd =  FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
			return hashedPwd;
		}


	}
}
