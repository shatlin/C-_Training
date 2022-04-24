using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PVMODX
{
	/// <summary>
	/// Summary description for ExecuteBatFile.
	/// </summary>
	public class ExecuteBatFile : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button cmdExecute;
		protected System.IO.DirectoryInfo dirInfo;
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
			this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdExecute_Click(object sender, System.EventArgs e)
		{

			try
			{
				// get the source and destination directory into the variable.
				string sourcePath = "c:\\test1\\";
				string destPath = "c:\\test2\\";
				// Copy the file from test1 to test2 and 
				// Delete the copied files.
				DirectoryInfo dInfo1  =  new DirectoryInfo(sourcePath);
				FileInfo [] fd2 = dInfo1.GetFiles();
				Array.Sort(fd2, new CompareFileInfoEntries());
				foreach(System.IO.FileInfo fInfo in fd2)
				{
					string sourceFile = fInfo.Name;
					File.Copy(sourcePath + sourceFile, destPath + sourceFile,true);
					File.Delete(sourcePath + sourceFile);
				}



				// Get the full file path and execute the batch file through command prompt
				string strFilePath = "c:\\test\\test.bat";
				// string strFilePath = "C:\\Inetpub\\wwwroot\\PVMODX\\output\\test.bat";

				// Create the ProcessInfo object
				System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
				psi.UseShellExecute = false; 
				psi.RedirectStandardOutput = true;
				psi.RedirectStandardInput = true;
				psi.RedirectStandardError = true;
				//psi.WorkingDirectory = "C:\\Inetpub\\wwwroot\\PVMODX\\output\\";
				psi.WorkingDirectory = "C:\\test\\";
				// Start the process
				System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);

				// Open the batch file for reading
				System.IO.StreamReader strm = System.IO.File.OpenText(strFilePath); 

				// Attach the output for reading
				System.IO.StreamReader sOut = proc.StandardOutput;

				// Attach the in for writing
				System.IO.StreamWriter sIn = proc.StandardInput;


				// Write each line of the batch file to standard input
				while(strm.Peek() != -1)
				{
					sIn.WriteLine(strm.ReadLine());
				}

				strm.Close();

				// Exit CMD.EXE
				string stEchoFmt = "# {0} run successfully. Exiting";

				sIn.WriteLine(String.Format(stEchoFmt, strFilePath));
				sIn.WriteLine("EXIT");

				// Close the process
				proc.Close();

				// Read the sOut to a string.
				string results = sOut.ReadToEnd().Trim();


				// Close the io Streams;
				sIn.Close(); 
				sOut.Close();


				// Write out the results.
				string fmtStdOut = "<font face=courier size=0>{0}</font>";
				this.Response.Write(String.Format(fmtStdOut,results.Replace(System.Environment.NewLine, "<br>")));
			}
			catch (Exception ex)
			{
				lblError.Text = ex.Message;
			}
		}
	}


	public class CompareDirInfoEntries:IComparer
	{
		public CompareDirInfoEntries()
		{
		}


		public int Compare(Object file1, Object file2)
		{
			DirectoryInfo f1= (DirectoryInfo) file1;
			DirectoryInfo f2= (DirectoryInfo) file2;

		
			return String.Compare(f1.Name, f2.Name);
		}
	}


	public class CompareFileInfoEntries:IComparer
	{
		public CompareFileInfoEntries()
		{
		}


		public int Compare(Object file1, Object file2)
		{
			FileInfo f1= (FileInfo) file1;
			FileInfo f2= (FileInfo) file2;

		
			return String.Compare(f1.Name, f2.Name);
		}
	}


}
