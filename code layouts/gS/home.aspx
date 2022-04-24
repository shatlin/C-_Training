<%@ Page language="c#" Codebehind="home.aspx.cs" AutoEventWireup="false" Inherits="gS.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<LINK href="styles.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblMessage" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 112px"
				runat="server" ForeColor="Red" Height="16px" Width="176px"></asp:label>
			<TABLE class="sofT" id="tblOrder" style="Z-INDEX: 102; LEFT: 24px; WIDTH: 231px; POSITION: absolute; TOP: 16px; HEIGHT: 80px"
				cellSpacing="0" cellPadding="0" width="231" align="center" border="0">
				<TR bgcolor="#d2e4fc">
					<TD style="WIDTH: 222px; HEIGHT: 28px; TEXT-ALIGN: right">
						<asp:label id="lblUser" runat="server" Width="75px">User Name&nbsp; </asp:label></TD>
					<td style="HEIGHT: 28px"><asp:textbox id="txtUser" runat="server" Width="150px"></asp:textbox></td>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD style="WIDTH: 222px; HEIGHT: 28px; TEXT-ALIGN: right"><asp:label id="lblPassword" runat="server">Password&nbsp;</asp:label></TD>
					<td style="HEIGHT: 28px"><asp:textbox id="txtPassword" runat="server" Width="150px" TextMode="Password"></asp:textbox></td>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD style="WIDTH: 222px"></TD>
					<TD>
						<asp:linkbutton id="lnkRegister" runat="server">Register</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="lnkLogin" runat="server">login</asp:linkbutton></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
