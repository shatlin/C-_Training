<%@ Page language="c#" Codebehind="PVPOEXTREFRESH.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPOEXTREFRESH" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>PO Extraction</TITLE>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
</HEAD>
	<body>
		<H2 class="h2head">
			Refresh PO Extraction</H2>
		<FORM name="Form1" runat="server" ID="Form2">
			<P>
				<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
					border="0">
						<TR>
					<TD class="helpHed">PO Refresh</TD>
				</TR>
					<TR bgcolor=#d2e4fc>
						<TD>&nbsp;</TD>
					</TR>
					<TR bgcolor=#d2e4fc>
						<TD>&nbsp;&nbsp;&nbsp;
							<ASP:BUTTON id="cmdRefresh" CSSCLASS="FormButtons" TEXT="Refresh" RUNAT="server"></ASP:BUTTON></TD>
					</TR>
					<TR bgcolor=#d2e4fc>
						<TD align="left">
							<ASP:LABEL id="lblError" Width="350px" CSSCLASS="FormErrorMessages" RUNAT="server"></ASP:LABEL></TD>
					</TR>
				</TABLE>
			</P>
			<P>&nbsp;</P>
		</FORM>
	</body>
</HTML>
