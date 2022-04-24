using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;                     
using Microsoft.PerformanceManagement.Scorecards.Client;
using Microsoft.PerformanceManagement.Scorecards.Server;
using System.Diagnostics;
 
namespace SCPrint
{
	public class ViewScorecard : System.Web.UI.Page
	{
 
		private IBpm server;
		private Microsoft.PerformanceManagement.Scorecards.WebControls.ScorecardCtrl scorecardControl = null;
		//private Microsoft.PerformanceManagement.Scorecards.WebControls.ReportViewImgPage reportviewImage = null;
		protected System.Web.UI.WebControls.PlaceHolder rptViewHolder;

		protected PlaceHolder mainPlaceHolder;
	//	protected PlaceHolder rptViewHolder;
 
                        
                        
		public ViewScorecard()
		{
			this.server = Microsoft.PerformanceManagement.Scorecards.Client.PmService.CreateInstance("http://localhost:46786/PmService.asmx");
		}
 
		private void Page_Load(object sender, System.EventArgs e)
		{
		}
 
 
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
                        
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
 
			try
			{
				string scorecardIdString = null;   
				if (Request.QueryString["scId"] != null)  scorecardIdString = Request.QueryString["scId"];
                                                
				string configuredViewIdString = null;
				if (Request.QueryString["cvId"] != null)  configuredViewIdString= Request.QueryString["cvId"];
 
				if (scorecardIdString == null || scorecardIdString.Length < 1 ||
					configuredViewIdString == null || configuredViewIdString.Length < 1)
				{
					throw new BpmException("Scorecard or Scorecard View is invalid!!!");
				}
 
				Guid scorecardId = new Guid(scorecardIdString);
				Guid configuredViewId = new Guid(configuredViewIdString);
 
				Microsoft.PerformanceManagement.Scorecards.Client.Scorecard scorecard = this.server.GetScorecard(scorecardId);
 
				if (this.scorecardControl == null)
				{
					this.scorecardControl = new Microsoft.PerformanceManagement.Scorecards.WebControls.ScorecardCtrl();
				}

//				if (this.reportviewImage  == null)
//				{
//					this.reportviewImage = new Microsoft.PerformanceManagement.Scorecards.WebControls.ReportViewImgPage();
//				}

				this.scorecardControl.ID = "scorecardCtrl";
				Panel scPanel = new Panel();
				scPanel.CssClass = "ms-WPBody";
				scPanel.Controls.Add(this.scorecardControl);
				this.mainPlaceHolder.Controls.Add(scPanel);


//				this.reportviewImage.ID = "imagectl1";
//				Panel rptPanel = new Panel();
//				rptPanel.CssClass = "ms-WPBody";
//				rptPanel.Controls.Add(this.reportviewImage);
//				this.rptViewHolder.Controls.Add(rptPanel);


 
				
			}
			catch (Exception ex)
			{
				throw(ex);
			}
		}
                        
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
 
	}
}
