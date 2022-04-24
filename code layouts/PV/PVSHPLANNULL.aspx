<%@ Page language="c#" Codebehind="PVSHPLANNULL.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVSHPLANNULL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVSHPLANNULL</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h2 class="h2head">Close Shipping Plan Records</h2>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" class="sofT" width="954" border="0" style="WIDTH: 954px">
				<tr>
					<td class="helpHed" colspan="2">Select Records to Close</td>
				</tr>
				<TR>
					<TD vAlign="top" style="WIDTH: 251px">
						<asp:datagrid id="shplanGrid" runat="server" CssClass="FormDataGrids" Width="504px" OnUpdateCommand="shplanGrid_OnUpdateCommand"
							OnCancelCommand="shplanGrid_OnCancelCommand" OnEditCommand="shplanGrid_OnEditCommand" AutoGenerateColumns="False"
							GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None"
							BorderColor="Gray" Height="23px" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white" Height="30"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SHPLANNO" ReadOnly="True" HeaderText="SHPLANNO">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="PLAN&nbsp;NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "SHPLANNO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="VENDOR_ID" ReadOnly="True" HeaderText="VENDOR_ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="SUPPLIER">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "VENDOR_DISPNAME") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="shplandate" ReadOnly="True" HeaderText="shplandate">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="PLAN&nbsp;DATE">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "shplandate") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CLOSE">
									<ItemTemplate>
										<asp:CheckBox ID="chkShplan" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
					<TD vAlign="top">
						<asp:datagrid id="asnGrid" runat="server" Width="458px" Height="23px" Visible="True" BorderColor="Gray"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal"
							AutoGenerateColumns="False" OnEditCommand="asnGrid_OnEditCommand" OnCancelCommand="asnGrid_OnCancelCommand"
							OnUpdateCommand="asnGrid_OnUpdateCommand" CssClass="FormDataGrids">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white" Height="30"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="asndate" ReadOnly="True" HeaderText="asndate">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ASN&nbsp;DATE">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "asndate") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="VENDOR_ID" ReadOnly="True" HeaderText="VENDOR_ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="SUPPLIER">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "VENDOR_DISPNAME") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="asn_no" ReadOnly="True" HeaderText="ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ASN NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "asn_no") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CNTR NO">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "CNTR_NO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ETA">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "eta") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<td colspan =2 align =left><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></td>
				</TR>
				<TR>
					<TD colspan="2" class="sup" style="TEXT-ALIGN:center" vAlign="top">
						<asp:button id="CloseASN" runat="server" Text="Close" cssclass="FormButtons"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
