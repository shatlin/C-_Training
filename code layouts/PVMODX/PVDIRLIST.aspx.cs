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




namespace PVMODX
{
	/// <summary>
	/// Summary description for PVDIRLIST.
	/// </summary>
	public class directories : System.Web.UI.Page

	{
		public string asnindir   = "";
		public string asnintmdir = "";
		public string asnerrdir  = "";
		public string asnoutdir  = "";

		public string cstindir   = "";
		public string cstintmdir = "";
		public string csterrdir  = "";
		public string cstoutdir  = "";

		public string splindir   = "";
		public string splintmdir = "";
		public string splerrdir  = "";
		public string sploutdir  = "";

		public string rfindir   = "";
		public string rfintmdir = "";
		public string rferrdir  = "";
		public string rfoutdir  = "";


		public directories()
		{
		 //server path
		string rootdir="D:\\BMMIDEV\\PVMODX\\DATA\\";
		//local machine path
		//string rootdir="C:\\BMMIDEV\\PVMODX\\DATA\\";
		 asnindir   = rootdir+"ASN\\IN\\";
		 asnintmdir = rootdir+"ASN\\INTM\\ASN.XLS";
		 asnerrdir  = rootdir+"ASN\\ERR\\";
		 asnoutdir  = rootdir+"ASN\\OUT\\";

		 cstindir   = rootdir+"COST\\IN\\";
		 cstintmdir = rootdir+"COST\\INTM\\COST.XLS";
		 csterrdir  = rootdir+"COST\\ERR\\";
		 cstoutdir  = rootdir+"COST\\OUT\\";

		 splindir   = rootdir+"SHPLAN\\IN\\";
		 splintmdir = rootdir+"SHPLAN\\INTM\\SHPL.XLS";
		 splerrdir  = rootdir+"SHPLAN\\ERR\\";
		 sploutdir  = rootdir+"SHPLAN\\OUT\\";

		 rfindir   = rootdir+"RF\\IN\\";
		 rfintmdir = rootdir+"RF\\INTM\\RF.XLS";
		 rferrdir  = rootdir+"RF\\ERR\\";
		 rfoutdir  = rootdir+"RF\\OUT\\";

		}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
