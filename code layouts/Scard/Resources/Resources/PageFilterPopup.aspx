<%@ Page Inherits="Microsoft.PerformanceManagement.Scorecards.WebControls.PageFilterPopup, Microsoft.PerformanceManagement.Scorecards.WebControls, Version=2.0.0.0, Culture=Neutral, PublicKeyToken=31BF3856AD364E35" %>
<HTML dir="ltr" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office">
	<HEAD>
		<Title>&nbsp;</Title>
		<META Name="ProgId" Content="Microsoft.PerformanceManagement.Scorecards.WebControls">
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<META HTTP-EQUIV="Expires" content="0">
		<script src="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/owsbrows.js"></script>
		<script language='javascript' src='ScorecardScript.js'></script>
		<Link REL="stylesheet" Type="text/css" HREF="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/styles/ows.css">
		<META Name="Microsoft Theme" Content="default">
		<META Name="Microsoft Border" Content="none">

		<style type="text/css">
		<!--
		div.scrollarea {
			height: 321px;
			overflow: auto;
			border: 1px solid #95B7F3;
			background-color: #ffffff;
			padding: 2px;
		}
		-->
		</style>
	</HEAD>
	
	<body scroll="no" id="PageBody" runat="server">
		<form runat="server">
			<table class="ms-WPHeader" cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
				<tr valign="middle">
					<td valign="top">
						<table cellpadding="0" cellspacing="0" border="0" width="100%">
							<tr>
								<td height=8 colspan=3></td>
							</tr>
							<tr valign=top>
								<td width=5></td>
								<td class="ms-calQuarterHour" valign="top">
									<b><asp:Label id="titleLabel" runat="Server"/></b>
									<br/>
									<div class="scrollarea">
										<table class="ms-WPBody" cellpadding="0" cellspacing="0" border="0" width="100%" height="200">
											<tr valign="top">
												<td class="ms-formbody" valign="top" width="100%"><asp:PlaceHolder id="treePlaceHolder" runat="Server"/></td>
											</tr>
											<tr valign="top">
												<td class="ms-formbody" valign="top" width="100%"><asp:PlaceHolder id="errorPanel" runat="Server"/></td>
											</tr>			
										</table>
									</div>
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr height=7>
											<td colspan=5></td>
										</tr>
										<tr>
											<td nowrap=true>
												<input type=button value="<%=NoneButtonText%>" accesskey="<%=NoneButtonAccessKey%>" onClick="DimensionSlicerSetEmptyReturnValue(); window.close();" />
											</td>
											<td width="100%"></td>
											<td nowrap=true>
												<input type=button value="<%=OkButtonText%>" accesskey="<%=OkButtonAccessKey%>" onClick="DimensionSlicerSetReturnValue(); window.close();" />
											</td>
											<td width="10" nowrap=true>&nbsp;</td>
											<td nowrap=true>
												<input type=button value="<%=CancelButtonText%>" accesskey="<%=CancelButtonAccessKey%>" onClick="window.close();" />
											</td>
										</tr>
										<tr height=7>
											<td colspan=5></td>
										</tr>
									</table>
								</td>
								<td width=5></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
