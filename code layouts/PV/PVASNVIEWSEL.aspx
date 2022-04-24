<%@ Page language="c#" Codebehind="PVASNVIEWSEL.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVASNVIEWSEL" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVASNVIEWSEL</title>
	</HEAD>
	<BODY>
		<h2 class="h2head">Selected ASN Records</h2>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlResult" runat="server" Visible="False">
				<TABLE class="sofT" align="center">
					<TR>
						<TD class="helphed">Selected ASN Records
						</TD>
					</TR>
					<TR>
						<TD class="innertitle">The selected asn Records were deleted</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="pnlCrystal" runat="server">
				<TABLE id="Table1" width="300" align="center" border="3">
					<TR>
						<TD>
							<cr:CrystalReportViewer id="CrystalReportViewer1" runat="server" EnableDrillDown="False" DisplayGroupTree="False"
								Height="50px" Width="350px"></cr:CrystalReportViewer></TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" align="center">
							<asp:Button id="cmdPrint" runat="server" Width="64px" CssClass="btn" Text="Print"></asp:Button>&nbsp;
							<asp:Button id="btnDelete" runat="server" Width="64px" CssClass="btn" Text="Delete"></asp:Button></TD>
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
