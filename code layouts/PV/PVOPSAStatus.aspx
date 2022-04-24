<%@ Page language="c#" Codebehind="PVOPSAStatus.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOPSAStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVOPSAStatus</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 class="h2head">Stock Allocation Status</H2>
			<P>
				<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="350" align="center" border="0">
					<TR>
						<TD class="helpHed" align="left" colSpan="4">Criteria</TD>
					</TR>
					<TR bgColor="#d2e4fc">
						<TD colSpan="4">&nbsp;</TD>
					</TR>
					<TR bgColor="#d2e4fc">
						<TD align="left" width="350">&nbsp;
							<ASP:LABEL id="lblOrderNo" RUNAT="server" CSSCLASS="FormLabels">Order #</ASP:LABEL>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;
							<ASP:TEXTBOX id="txtOrderNo" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="150px" MAXLENGTH="10"></ASP:TEXTBOX></TD>
					</TR>
					<TR bgColor="#d2e4fc">
						<TD align="left" width="350"><asp:radiobutton id="rdbAllProducts" runat="server" Text="AllProducts" CssClass="FormRadioButtons"
								GroupName="grpOrder" AutoPostBack="True"></asp:radiobutton></TD>
					</TR>
					<TR bgColor="#d2e4fc">
						<TD align="left" width="350"><asp:radiobutton id="rdbBackorderProducts" runat="server" Text="Back Order Products" CssClass="FormRadioButtons"
								GroupName="grpOrder" AutoPostBack="True"></asp:radiobutton></TD>
					</TR>
					<TR bgColor="#d2e4fc">
						<TD align="left" width="350"><asp:radiobutton id="rdbSingleProduct" runat="server" Text="Single Product" CssClass="FormRadioButtons"
								GroupName="grpOrder" AutoPostBack="True"></asp:radiobutton><asp:dropdownlist id="cboProducts" runat="server" CssClass="FormComboBoxes" Width="110px" Visible="False"></asp:dropdownlist>&nbsp;
							<ASP:TEXTBOX id="txtProductName" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="100px" MAXLENGTH="10"
								Visible="False"></ASP:TEXTBOX></TD>
					</TR>
					<TR align="center" bgColor="#d2e4fc">
						<TD align="center" width="350"><ASP:BUTTON id="cmdView" RUNAT="server" CSSCLASS="FormButtons" TEXT="View"></ASP:BUTTON><ASP:BUTTON id="cmdCancel" RUNAT="server" CSSCLASS="FormButtons" TEXT="Cancel"></ASP:BUTTON></TD>
					</TR>
					<tr align="left" bgColor="#d2e4fc">
						<td><ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages"></ASP:LABEL></td>
					</tr>
				</TABLE>
			</P>
			<asp:panel id="pnlStatus" runat="server" Width="100%" Visible="False">
				<TABLE class="sofT" id="tblMain" cellSpacing="0" cellPadding="0" width="100%" align="left"
					border="0">
					<TR>
						<TD bgColor="#f3f8fe">
							<TABLE id="tblMaster" cellSpacing="0" cellPadding="3" width="700" align="left" border="0">
								<TR align="left" bgColor="#f3f8fe">
									<TD>
										<ASP:LABEL id="lblOrder" CSSCLASS="FormLabels" RUNAT="server">Order #</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtOrder" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="lblStatus" CSSCLASS="FormLabels" RUNAT="server">Status</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtStatus" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL>&nbsp;&nbsp;&nbsp;
										<ASP:LABEL id="txtStatusAlert" RUNAT="server" BackColor="Red"></ASP:LABEL></TD>
								</TR>
								<TR align="left" bgColor="#f3f8fe">
									<TD>
										<ASP:LABEL id="lblDateReceived" CSSCLASS="FormLabels" RUNAT="server">Date Received</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtDateReceived" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="lblCustomerCode" CSSCLASS="FormLabels" RUNAT="server">Customer</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtCustomerCode" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
								</TR>
								<TR align="left" bgColor="#f3f8fe">
									<TD>
										<ASP:LABEL id="lblDateEntered" CSSCLASS="FormLabels" RUNAT="server">Date Entered</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtDateEntered" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="lblAddress1" CSSCLASS="FormLabels" RUNAT="server">Name</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtAddress1" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
								</TR>
								<TR align="left" bgColor="#f3f8fe">
									<TD>
										<ASP:LABEL id="lblRDD" CSSCLASS="FormLabels" RUNAT="server">RDD</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtRDD" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="lblAddress2" CSSCLASS="FormLabels" RUNAT="server">Address</ASP:LABEL></TD>
									<TD>
										<ASP:LABEL id="txtAddress2" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
								</TR>
								<TR bgColor="#f3f8fe">
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
								<TR>
									<TD>
										<asp:datagrid id="DataGrid2" runat="server" CssClass="FormDataGrids" Visible="True" Width="100%"
											BackColor="White" Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" CellPadding="3"
											GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false" OnItemDataBound="DataGrid2_ItemDataBound"
											OnEditCommand="DataGrid2_OnEditCommand">
											<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
											<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
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
														<%# DataBinder.Eval(Container.DataItem, "ProductName") %>
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
												<asp:TemplateColumn HeaderText="Ordered Qty" ItemStyle-HorizontalAlign="Center">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "order_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Allocated Qty" ItemStyle-HorizontalAlign="Center">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "a_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Balance Qty" ItemStyle-HorizontalAlign="Center">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "balance_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Physical Qty" ItemStyle-HorizontalAlign="Center">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "physical_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Allocated Qty" ItemStyle-HorizontalAlign="Center">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "all_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="On Order Qty" ItemStyle-HorizontalAlign="Center">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "on_order_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="DSCP Description">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:EditCommandColumn ButtonType="LinkButton" EditText="Detail">
													<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
												</asp:EditCommandColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 12px" align="left">
							<ASP:LABEL id="lblTotalProduct" CSSCLASS="FormLabels" RUNAT="server" Width="120px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD align="center">&nbsp;
							<ASP:BUTTON id="cmdPrint" CSSCLASS="FormButtons" RUNAT="server" TEXT="Print"></ASP:BUTTON></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
