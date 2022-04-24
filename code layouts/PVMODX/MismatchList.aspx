<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="MismatchList.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.MismatchList" %>
<%@ Register TagPrefix="uc1" TagName="DetailList" Src="Temp/DetailList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MismatchList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="PVMODSTYLES.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table align="left">
				<tr align="center">
					<td>
					</td>
				</tr>
				<tr>
					<td>
						<CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" EnableDrillDown="False"
							DisplayGroupTree="False" HasSearchButton="False" HasGotoPageButton="False" HasDrillUpButton="False"></CR:CrystalReportViewer>
					</td>
				</tr>
				<tr align="center">
					<td>
						<asp:LinkButton id="lnkExport" runat="server" CssClass="FormLinkButtons">Export</asp:LinkButton>&nbsp;
						<ASP:LABEL id="lblSep" RUNAT="server" CSSCLASS="FormTextBoxes">|</ASP:LABEL>&nbsp;
						<a href="javascript:window.history.back()" class="FormLinkButtons">Back</a>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
