<%@ Page language="c#" Codebehind="PVFILEUPL.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVFILEUPL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RF File upload</title>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<BODY>
		<br>
		<H2 class="h2head">Upload RF</H2>
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<form id="Form1" runat="server">
			<TABLE class="sofT" align="center" border="0" height="80">
				<TR>
					<TD class="helpHed" colSpan="3" height="9">Select&nbsp;RF file</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" colSpan="2" height="8"></TD>
				</TR>
				<tr>
					<TD class="borderlesstitle" colSpan="2" height="17">&nbsp;&nbsp;&nbsp; &nbsp;<INPUT id="uplTheFile" style="WIDTH: 358px; HEIGHT: 22px" type="file" size="40" name="uplTheFile"
							runat="server">&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
					</TD>
				</tr>
				<TR>
					<TD class="borderlesstitle" align="right" colSpan="3" height="8">
						<ASP:BUTTON id="uploadFile" CSSCLASS="FormButtons" TEXT="Select" RUNAT="server" Width="75px"></ASP:BUTTON>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<ASP:BUTTON id="cmdSave" CSSCLASS="FormButtons" TEXT="Upload" RUNAT="server" Width="75px"></ASP:BUTTON></TD>
				</TR>
				<tr>
					<TD class="borderlesstitle" colSpan="3">
						<P align="left"><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></P>
					</TD>
				</tr>
			</TABLE>
			<asp:panel id="pnlErr" runat="server" Visible="False">
				<BR>
				<SPAN id="txtOutput" style="FONT: 8pt verdana" runat="server"></SPAN>
				<BR>
				<TABLE class="sofT" width="600" align="center">
					<TR>
						<TD class="helpHed">Result</TD>
					</TR>
					<TR>
						<TD>
							<asp:datagrid id="Datagrid2" runat="server" CssClass="FormDataGrids" Visible="True" Height="23px"
								BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
								GridLines="Horizontal" width="600" ShowHeader="False">
								<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
								<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
								<HeaderStyle CssClass="gridHeader"></HeaderStyle>
								<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</BODY>
</HTML>
