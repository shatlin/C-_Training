<%@ Page language="c#" Codebehind="PVPA02.aspx.cs" AutoEventWireup="false" Inherits="PV.PVPA02" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVPA02</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_array.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 class="h2head">Purchase Analysis Tool - Selected Products</H2>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="300" align="center"
				border="0">
				<TR>
					<TD align="center">
						<ASP:BUTTON id="cmdBack" RUNAT="server" CSSCLASS="FormButtons" TEXT="Back" Visible="False"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
			<table class="sofT" id="Analysis" cellpadding="0" cellspacing="0" width="100%" align="center">
				<tr>
					<td>
						<asp:datagrid id="dgResults" runat="server" Visible="True" AllowPaging="false" AutoGenerateColumns="true"
							GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None"
							BorderColor="Gray" CssClass="FormDataGrids" Height="23px" Width="100%">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
						</asp:datagrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
