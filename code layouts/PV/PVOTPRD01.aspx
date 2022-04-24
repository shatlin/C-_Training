<%@ Register TagPrefix="mbcbb" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.ComboBox" %>
<%@ Page language="c#" Codebehind="PVOTPRD01.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOTPRD01" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>Select Product</TITLE>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
			<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
			<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
</HEAD>
	<body>
		<H2 class="h2head">Order tracking by product</H2>
		<center>
			<FORM name="frmLogin" action="PVOTPRD02.aspx" method="post" runat="server">
				<TABLE class="sofT" align="center" border="0" height="79" width="600">
					<TR>
						<TD class="helpHed" colSpan="3">Select the product</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" colSpan="3" height="3">&nbsp;</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" height="1" width="97">Product</TD>
						<TD class="borderlesstitle" width="10" bgColor="#99ccff" height="1"> <mbcbb:combobox id="cboProducts" AutoPostBack="true"  runat="server" CssClass="FormComboBoxes" Width="454px" Visible="True" DataValueField="product"></mbcbb:combobox> </TD>
						<TD class="borderlesstitle" width="10" height="1"></TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" align="center" colSpan="3">
							<CENTER><ASP:BUTTON id="cmdContinue" RUNAT="server" TEXT="View" CSSCLASS="FormButtons"></ASP:BUTTON></CENTER>
						</TD>
					</TR>
				</TABLE>
				<br>
				<br>
				<br>
				<asp:Panel ID="pnlPrdDetl" runat="server" Visible="False" Width="100%">
<TABLE class=sofT id=detailtables cellSpacing=0 cellPadding=0 width="100%" 
align=center border=0>
  <TR>
    <TD class=helpHed colSpan=3 height=17>Product Details</TD></TR>
  <TR>
    <TD>
<asp:datagrid id=DataGrid2 runat="server" Visible="True" Width="100%" CssClass="FormDataGrids" Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false" OnItemDataBound="DataGrid2_ItemDataBound" OnEditCommand="DataGrid2_OnEditCommand" BackColor="White">
									<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
									<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
									<HeaderStyle CssClass="gridHeader"></HeaderStyle>
									<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="po_no" ReadOnly="True" HeaderText="po_no">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="po_no">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "po_no") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Order_Date">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "po_date") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Supplier">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "vendor_code") %>
												-
												<%# DataBinder.Eval(Container.DataItem, "vendor_name") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="nsn" ReadOnly="True" HeaderText="nsn">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="NSN">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "NSN") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="product" ReadOnly="True" HeaderText="nsn">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Product">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "product") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Desc">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Ordered">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "order_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Rcvd">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "rcvd_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Shipped">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "shipd_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Bal">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "balance_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Plan">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "plan_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Phy">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "physical_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Allo">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "allocated_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Free">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "free_qty") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:EditCommandColumn ButtonType="LinkButton" EditText="Detail">
											<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
										</asp:EditCommandColumn>
									</Columns>
								</asp:datagrid>
<ASP:LABEL id=lblTotal Width="120px" CSSCLASS="FormLabels" RUNAT="server"></ASP:LABEL></TD></TR></TABLE>
				</asp:Panel>
			</FORM>
		</center>
	</body>
</HTML>
