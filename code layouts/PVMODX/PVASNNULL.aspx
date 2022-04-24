<%@ Page language="c#" Codebehind="PVASNNULL.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVASNNULL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NULLIFY ASN AGAINST GRN</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H2 class="h2head">Nullify ASN Against GRN</H2>
			<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="helpHed" style="HEIGHT: 15px" align="left" colSpan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						Select The ASNs To Close&nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="DataGrid2" runat="server" CssClass="FormDataGrids" Width="100%" OnUpdateCommand="DataGrid2_OnUpdateCommand"
							OnCancelCommand="DataGrid2_OnCancelCommand" OnEditCommand="DataGrid2_OnEditCommand" AutoGenerateColumns="False"
							GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None"
							BorderColor="Gray" Height="23px" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="asnno" ReadOnly="True" HeaderText="ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ASN NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "asnno") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ASN DATE">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "asndate") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ETA">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "eta") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CNTR TYPE">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "cntrtype") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ASN CNTR NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "asncntrno") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Close">
									<ItemTemplate>
										<asp:CheckBox ID="chkAsn" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="GRN CNTR NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "grncntrno") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="GRN NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "grnno") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="GRN DATE">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "grndate") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="SUPPLIER">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "VENDOR_DISPNAME") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<td><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></td>
				</TR>
				<TR>
					<td align="center"><asp:button id="CloseASN" runat="server" Text="Close" cssclass="FormButtons"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
