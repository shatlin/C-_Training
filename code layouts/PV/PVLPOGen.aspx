<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="PVLPOGen.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVLPOGen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PVLPOGen</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="theForm" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="25%">
				<tr>
					<td class="smallheader" height="15">Supplier List</td>
				</tr>
				<tr align="center">
					<td height="200"><asp:listbox id="lstSupplier" runat="server" Width="150px" Height="200px" CssClass="FormListBoxes"></asp:listbox></td>
				</tr>
				<tr align="center">
					<td><ASP:BUTTON id="cmdGenerate" Width="96px" RUNAT="server" CSSCLASS="FormButtons" TEXT="Generate LPO"></ASP:BUTTON></td>
				</tr>
				<tr align="left">
					<td><ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages"></ASP:LABEL></td>
				</tr>
			</table>
			<hr>
			<asp:panel id="pnlLPOGen" runat="server" Width="100%" Visible="False">
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<TR align="left">
						<TD>
							<CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" DisplayGroupTree="False"
								HasGotoPageButton="False" HasSearchButton="False" HasZoomFactorList="False" EnableDrillDown="False"
								HasDrillUpButton="False"></CR:CrystalReportViewer></TD>
					</TR>
					<TR align="left">
						<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:LinkButton id="lnkExport" runat="server" CssClass="FormLinkButtons">Export</asp:LinkButton>&nbsp;
							<ASP:LABEL id="lblSep" RUNAT="server" CSSCLASS="FormTextBoxes">|</ASP:LABEL>&nbsp;
							<A class="FormLinkButtons" href="javascript:window.history.back()">Back</A>
						</TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
