using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace PVMODX
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

			// Application["machineName"]=ConfigurationSettings.AppSettings["MachineName"];

			//Application["IsLicensed"]=false;
			
			//string licenseKey=ConfigurationSettings.AppSettings["LicenseKey"];

		//	ManagementObject logicalDisk=new ManagementObject("Win32_Logicaldisk=\"C:\"");
		//	string diskSerial=logicalDisk.Properties["VolumeSerialNumber"].Value.ToString();

		//	int serialKey=Convert.ToInt32(diskSerial, 16);

		//	int serialKey1=serialKey / 2240;
		//	int serialKey2=serialKey % 2240;

		//	string requiredSerialKey=FormsAuthentication.HashPasswordForStoringInConfigFile(serialKey1.ToString()+"-"+serialKey2.ToString(), "JVE1");

			//string obtainedSerialKey=licenseKey;

			//if(requiredSerialKey.Equals(obtainedSerialKey))
			Application["IsLicensed"]=true;

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

