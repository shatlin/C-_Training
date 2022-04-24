<%@ Page language="c#" Codebehind="PVGRNEXTREFRESH.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVGRNEXTREFRESH" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>GRN Extraction Refresh</TITLE>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
			<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
			<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
</HEAD>
	<BODY>
		<h2 class="h2head">Refresh GRN Extraction</h2>
		<FORM name="Form1" runat="server" ID="Form2">
			<P>
				<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
					border="0" bgColor=#d2e4fc>
					<TR>
					<TD class="helpHed">GRN Refresh</TD>
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
	</BODY>
</HTML>
