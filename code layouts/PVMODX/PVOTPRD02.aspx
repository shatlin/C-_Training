<%@ Page language="c#" Codebehind="PVOTPRD02.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOTPRD02" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVOTPRD02</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_array.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK HREF="PVMODSTYLES.CSS" TYPE="text/css" REL="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		
		
			<table CLASS="sofT" CELLSPACING="0" CELLPADDING="0" WIDTH="100%" ALIGN="center" BORDER="0">
				<tr>
					<TD CLASS="helpHed" COLSPAN="3">Select the product</TD>
				</tr>
				<tr>
					<td>
						<asp:datagrid id="DataGrid" runat="server" CssClass="FormDataGrids" Width="100%" AllowPaging="True"
							PageSize="20" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BackColor="White"
							BorderWidth="1px" BorderStyle="None" BorderColor="Gray" Height="23px" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<PagerStyle Mode="NextPrev" HorizontalAlign="right" Font-Size="11px" Font-Names="Verdana" ForeColor="Black"
								BackColor="White" NextPageText="Next " PrevPageText=" Prev" Position="bottom"></PagerStyle>
						</asp:datagrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
