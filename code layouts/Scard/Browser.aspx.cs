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
using Microsoft.PerformanceManagement.Scorecards.Client;
using Microsoft.PerformanceManagement.Scorecards.Extensions; 
using Microsoft.PerformanceManagement.Scorecards.WebControls;

using System.Text;
 
namespace SCPrint
{
	public class SCBrowser : System.Web.UI.Page
	{
		private Microsoft.PerformanceManagement.Scorecards.Client.IBpm  server;
		protected System.Web.UI.WebControls.DropDownList scorecardList;
		protected System.Web.UI.WebControls.DropDownList configuredViewList;
		protected System.Web.UI.WebControls.Label scorecardLabel;
		protected System.Web.UI.WebControls.Label configuredViewLabel;
		protected System.Web.UI.WebControls.Label scorecardBrowserLabel;
		protected System.Web.UI.WebControls.Button Go;
            
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)GetScorecards();
		}
                        
		public SCBrowser()
		{
			this.server = Microsoft.PerformanceManagement.Scorecards.Client.PmService.CreateInstance("http://localhost:46786/PmService.asmx");
		}
 
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
                        
		private void InitializeComponent()
		{    
			this.scorecardList.SelectedIndexChanged += new System.EventHandler(this.scorecardList_SelectedIndexChanged);
			this.Go.Click += new System.EventHandler(this.Go_Click);
			this.Load += new System.EventHandler(this.Page_Load);
 
		}
                        
                        
		protected void GetScorecards()
		{
			try
			{
				ScorecardCollection scorecards = server.GetScorecards();
				if (scorecards.Count > 0)
				{
					this.scorecardList.Items.Add(new ListItem());
 
					foreach (Scorecard scorecard in scorecards)
					{
						string scorecardName = (scorecard.Name.Text);
						ListItem li = new ListItem(scorecardName, scorecard.Guid.ToString());
						this.scorecardList.Items.Add(li);
					}
				}
				else
				{
					this.Controls.Add(new LiteralControl(("NoScorecard")));
				}
 
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}
 
		protected void GetConfiguredViews()
		{
			try
			{
 
				if (scorecardList.SelectedIndex != 0)
				{
					Scorecard scorecard = this.server.GetScorecard(new Guid(scorecardList.SelectedValue));
					if (scorecard != null)
					{
						foreach (ConfiguredView configuredView in scorecard.ConfiguredViews)
						{
							string configuredViewName = (configuredView.Name.Text);
							ListItem li = new ListItem(configuredViewName, configuredView.Guid.ToString());
							this.configuredViewList.Items.Add(li);
						}
					}
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
		}
                        
 
		private void Go_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ViewScorecard.aspx?scId=" + scorecardList.SelectedValue + "&cvId=" + configuredViewList.SelectedValue);
		}
 
		private void scorecardList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			configuredViewList.Items.Clear(); 
			GetConfiguredViews();
		}
	}
}
