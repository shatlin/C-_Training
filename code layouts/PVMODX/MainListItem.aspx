<%@ Page language="c#" Codebehind="MainListItem.aspx.cs" AutoEventWireup="false" Inherits="PV.MainListItem" %>
<%@ Register TagPrefix="DNJ" TagName="products" Src="Temp/DetailList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainListItem</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="JavaScript" src="menu_array.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGrid2" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Visible="True" Width="100%" OnEditCommand="DataGrid2_OnEditCommand" OnItemDataBound="DataGrid2_ItemDataBound"
				AllowPaging="false" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BackColor="White"
				BorderWidth="1px" BorderStyle="None" BorderColor="Gray" Height="23px" CssClass="FormDataGrids">
				<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
				<ItemStyle CssClass="gridItem" BackColor="white" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle CssClass="gridHeader"></HeaderStyle>
				<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="warehouse" ReadOnly="True" HeaderText="warehouse">
						<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="product" ReadOnly="True" HeaderText="product">
						<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Product">
						<ItemTemplate>
							<asp:linkbutton RUNAT="server" 
 TEXT='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>' 
 COMMANDNAME="Edit" ID="Linkbutton1" >
							</asp:linkbutton>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="NSN">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "stock_number") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Unit Sale">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "unit_of_sale") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Price">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "trans_price") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Ordered Qty">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "order_qty") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Allocated Qty">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "a_qty") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Balance Qty">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "balance_qty") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Physical Qty">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "physical_qty") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Allocated Qty">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "all_qty") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="On Order Qty">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "on_order_qty") %>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="DSCP Description">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
						</ItemTemplate>
						<edititemtemplate>
							<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
							<DNJ:products ID="Products" Product='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>' RUNAT="server">
							</DNJ:products>
						</edititemtemplate>
					</asp:TemplateColumn>
					<asp:EditCommandColumn ButtonType="LinkButton" EditText="">
						<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
					</asp:EditCommandColumn>
				</Columns>
			</asp:datagrid>
		</form>
	</body>
</HTML>
