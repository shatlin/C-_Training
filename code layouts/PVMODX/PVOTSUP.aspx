<%@ Page language="c#" Codebehind="PVOTSUP.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOTSUP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Select Supplier</TITLE>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body>
		<H2 class="h2head">Order tracking by Supplier</H2>
		<FORM id="Form1" name="frmLogin" action="PVOTPRD02.aspx" method="post" runat="server">
			<TABLE class="sofT" align="center" border="0">
				<TR>
					<TD class="helpHed" colSpan="3">Select the Supplier</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" colSpan="3">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" height="1">Supplier</TD>
					<TD class="borderlesstitle" width="10" bgColor="#99ccff" height="1"><asp:dropdownlist id="cboVendor" runat="server" CssClass="FormComboBoxes" Width="150px" Visible="True"></asp:dropdownlist></TD>
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
				<TABLE class="sofT" id="detailtables" cellSpacing="0" cellPadding="0" width="100%" align="center"
					border="0">
					<TR>
						<TD class="helpHed" colSpan="3" height="17">Product Details</TD>
					</TR>
					<TR>
						<TD>
							<asp:datagrid id="DataGrid2" runat="server" Visible="True" Width="100%" CssClass="FormDataGrids"
								BackColor="White" OnEditCommand="DataGrid2_OnEditCommand" OnItemDataBound="DataGrid2_ItemDataBound"
								AllowPaging="false" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BorderWidth="1px"
								BorderStyle="None" BorderColor="Gray" Height="23px">
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
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</asp:Panel></FORM>
	</body>
</HTML>
