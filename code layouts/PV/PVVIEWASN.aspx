<%@ Page language="c#" Codebehind="PVVIEWASN.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVVIEWASN" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ASN DETAILS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="sofT" id="detailtables" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD><asp:datagrid id="Datagrid2" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="3"
							BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray" Height="23px" CssClass="FormDataGrids"
							Width="100%" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ASN_NO" ReadOnly="True" HeaderText="ASN_NO">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="ASN NO" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "ASN_NO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="VESSEL" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "VESSEL") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="TCN_NO" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "TCN_NO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="CNTR NO" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "CNTR_NO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="TYPE" ItemStyle-Width="5%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "CNTR_TYPE") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="INVOICE" ItemStyle-Width="5%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "INV_NO") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="INV DATE" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "invdate") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="PORT_DISP" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "PORT_DISP") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="PORT_ARRV" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "PORT_ARRV") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="ETA" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "ETA") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-BackColor="#6699cc" ItemStyle-ForeColor="White" HeaderStyle-BackColor="#6699cc"
									HeaderStyle-ForeColor="White" HeaderText="SUPPLIER" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "VENDOR_DISPNAME") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid><asp:datagrid id="Datagrid3" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="3"
							BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="Gray" Height="23px" CssClass="FormDataGrids"
							Width="100%" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ASN_NO" ReadOnly="True" HeaderText="ASN_NO">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="NSN" ItemStyle-Width="20%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "NSN") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="PO_NUMBER" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "PO_NUMBER") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="PURCHASE UNIT" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "PACKAGING_CODE") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="BRAND" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "BRAND") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="QTY " ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "QTY_SHIPPED") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MFG COST" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "VENDOR_COST") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="NAPA" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "NAPA_DISCOUNT") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="VDISTFEE" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "TOTAL_WT") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="BMCOST" ItemStyle-Width="10%">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "BMMI_PRICE") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
