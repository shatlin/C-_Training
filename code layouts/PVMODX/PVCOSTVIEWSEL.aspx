<%@ Page language="c#" Codebehind="PVCOSTVIEWSEL.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVCOSTVIEWSEL" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVCOSTVIEWSEL</title>
	</HEAD>
	<BODY>
		<h2 class="h2head">Selected&nbsp;Cost Records</h2>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlResult" runat="server" Visible="False">
				<TABLE class="sofT" align="center">
					<TR>
						<TD class="helphed">Selected&nbsp;Cost Records
						</TD>
					</TR>
					<TR>
						<TD class="innertitle">The selected&nbsp;cost Records&nbsp;are deleted</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="pnlCrystal" runat="server">
				<TABLE id="Table1" width="300" align="center" border="3">
					<TR>
						<TD>
							<cr:CrystalReportViewer id="CrystalReportViewer1" runat="server" Width="350px" Height="50px" DisplayGroupTree="False"
								EnableDrillDown="False"></cr:CrystalReportViewer></TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" align="center">&nbsp;
							<asp:Button id="btnDelete" runat="server" Text="Delete" CssClass="btn"></asp:Button></TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" colSpan="3">
							<asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</BODY>
</HTML>
