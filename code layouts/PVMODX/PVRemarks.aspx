<%@ Register TagPrefix="mbcbb" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.ComboBox" %>
<%@ Page language="c#" Codebehind="PVRemarks.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVRemarks" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVRemarks</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H2 class="h2head">Remarks</H2>
			<TABLE class="sofT" id="tblOrder" cellSpacing="2" cellPadding="2" width="300" align="center"
				border="0">
				<TR>
					<TD align="left" width="100"><ASP:LABEL id="lblRemType" RUNAT="server" CSSCLASS="FormLabels">Type</ASP:LABEL>&nbsp;
					</TD>
					<td style="HEIGHT: 13px" align="left" width="200"><mbcbb:combobox id="cboRemType" runat="server" AutoPostBack="true" CssClass="FormComboBoxes" Width="181px"
							Visible="true"></mbcbb:combobox></td>
				</TR>
				<TR>
					<TD align="left" width="100"><ASP:LABEL id="lblRemarks" RUNAT="server" CSSCLASS="FormLabels">Remarks</ASP:LABEL></TD>
					<td align="left" width="200"><mbcbb:combobox id="cboRemarks" runat="server" CssClass="FormComboBoxes" Width="181px"
							Visible="true"></mbcbb:combobox></td>
				</TR>
				<tr>
					<td colSpan="2" align="left"><ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages"></ASP:LABEL></td>
				</tr>
				<tr>
					<td colSpan="2"><ASP:BUTTON id="cmdSave" RUNAT="server" CSSCLASS="FormButtons" TEXT="Save"></ASP:BUTTON></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
