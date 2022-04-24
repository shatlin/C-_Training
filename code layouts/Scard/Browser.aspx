<%@ Page language="c#" Codebehind="Browser.aspx.cs" AutoEventWireup="false" Inherits="SCPrint.SCBrowser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SC Browser</title>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE height="675" cellSpacing="0" cellPadding="0" width="207" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="207" height="675">
					<form id="Form1" method="post" runat="server">
						<TABLE height="190" cellSpacing="0" cellPadding="0" width="663" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="292" height="15"></TD>
								<TD width="371"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="175"></TD>
								<TD>
									<table align="center" height="174" width="370">
										<tr>
											<td align="center"><asp:label id="scorecardBrowserLabel" runat="server" Width="156px" Height="24px" Font-Names="Verdana"
													Font-Size="X-Small" Font-Bold="True">Scorecard Browser</asp:label></td>
										</tr>
										<tr>
											<td>
												<FIELDSET>
													<LEGEND ACCESSKEY="S">
								Select</LEGEND>
													<table>
														<tr>
															<td align="right">
																<asp:label id="scorecardLabel" runat="server" Width="104px" Height="24px" Font-Names="Verdana"
																	Font-Size="X-Small" Font-Bold="True">Scorecard</asp:label>
															</td>
															<td align="left">
																<asp:dropdownlist id="scorecardList" runat="server" width="200px" AutoPostBack="True"></asp:dropdownlist>
															</td>
														</tr>
														<tr>
															<td align="right">
																<asp:label id="configuredViewLabel" runat="server" Width="144px" Height="24px" Font-Names="Verdana"
																	Font-Size="X-Small" Font-Bold="True">Scorecard View</asp:label>
															</td>
															<td align="left">
																<asp:dropdownlist id="configuredViewList" width="200px" runat="server"></asp:dropdownlist>
															</td>
														</tr>
														<tr>
															<td colspan="2" align="center">
																<asp:button id="Go" runat="server" Text="View Scorecard" Width="139px" Font-Names="Verdana"
																	Font-Size="X-Small" Font-Bold="True"></asp:button>
															</td>
														</tr>
													</table>
												</FIELDSET>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
