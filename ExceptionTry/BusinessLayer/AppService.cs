using System;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AppService
	{
		public AppService()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private void ProcessC()
		{
			// Assume operation failed due to authentication. Get current
			// user's identity information.

			//Get the current identity and put it into an identity object.
			WindowsIdentity myIdentity = WindowsIdentity.GetCurrent();

			//Put the previous identity into a principal object.
			WindowsPrincipal myPrincipal = new WindowsPrincipal(myIdentity);

			//Principal values.
			string principalName = myPrincipal.Identity.Name;
			string principalType = myPrincipal.Identity.AuthenticationType;
			string principalAuth = myPrincipal.Identity.IsAuthenticated.ToString();

			//Identity values.
			string identName = myIdentity.Name;
			string identType = myIdentity.AuthenticationType;
			string identToken = myIdentity.Token.ToString();

			//Print the values.
			string identityInfo = String.Format("Principal Values for current thread:" + 
				"\n\nPrincipal Name: {0}" +
				"Principal Type: {1}" + 
				"Principal IsAuthenticated: {2}" + 
				"\n\nIdentity Values for current thread:"  +
				"Identity Name: {3}" + 
				"Identity Type: {4}" + 
				"Identity Token: {5}", 
				principalName, principalType, principalAuth, 
				identName, identType, identToken);

			throw new System.Security.SecurityException(identityInfo);
		}



		public void ProcessWithReplace()
		{
			try
			{
				ProcessC();
			}
			catch(Exception ex)
			{
				// Invoke our policy that is responsible for making sure no secure information
				// gets out of our layer.
				bool rethrow = ExceptionPolicy.HandleException(ex, "Replace Policy");

				if (rethrow)
				{
					throw;			
				}			
			}
		}

	}
}
