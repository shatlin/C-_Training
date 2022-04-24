<%@ Register TagPrefix="mbcbb" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.ComboBox" %>
<%@ Page language="c#" Codebehind="LocalPurchaseOrder.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.LocalPurchaseOrder" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LocalPurchaseOrder</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="theForm" method="post" runat="server">
			<H2 class="h2head">Local Purchase Order</H2>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
				border="0">
				<TR>
					<TD><ASP:LABEL id="lblOrder" CSSCLASS="FormLabels" RUNAT="server">Order #</ASP:LABEL>&nbsp;
						<ASP:TEXTBOX id="txtOrderNo" CSSCLASS="FormTextBoxes" RUNAT="server" MAXLENGTH="10" WIDTH="100px"></ASP:TEXTBOX>&nbsp;
						<ASP:BUTTON id="cmdView" CSSCLASS="FormButtons" RUNAT="server" TEXT="View"></ASP:BUTTON></TD>
				</TR>
				<tr>
					<td align="left"><ASP:LABEL id="lblError" CSSCLASS="FormErrorMessages" RUNAT="server" Width="350px"></ASP:LABEL></td>
				</tr>
			</TABLE>
			<p><asp:panel id="pnlStatus" runat="server" Width="100%" Visible="False">
					<TABLE class="sofT" id="tblMain" cellSpacing="0" cellPadding="0" width="100%" align="left"
						border="0">
						<TR>
							<TD align="center">
								<ASP:BUTTON id="cmdProceed1" CSSCLASS="FormButtons" RUNAT="server" TEXT="Proceed"></ASP:BUTTON></TD>
						</TR>
						<TR>
							<TD bgColor="#f3f8fe">
								<TABLE id="tblMaster" cellSpacing="0" cellPadding="3" width="700" align="left" border="0">
									<TR align="left" bgColor="#f3f8fe">
										<TD>
											<ASP:LABEL id="Label1" CSSCLASS="FormLabels" RUNAT="server">Order #</ASP:LABEL></TD>
										<TD>
											<ASP:LABEL id="txtOrder" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
										<TD>
											<ASP:LABEL id="lblStatus" CSSCLASS="FormLabels" RUNAT="server">Status</ASP:LABEL></TD>
										<TD>
											<ASP:LABEL id="txtStatus" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
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
											<asp:datagrid id="dgResults" runat="server" Width="100%" Visible="True" CssClass="FormDataGrids"
												AllowPaging="false" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BackColor="White"
												BorderWidth="1px" BorderStyle="None" BorderColor="Gray" Height="23px" OnEditCommand="dgResults_OnEditCommand"
												OnCancelCommand="dgResults_OnCancelCommand" OnUpdateCommand="dgResults_OnUpdateCommand">
												<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
												<ItemStyle CssClass="gridItem" BackColor="White"></ItemStyle>
												<HeaderStyle CssClass="gridHeader"></HeaderStyle>
												<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="warehouse" ReadOnly="True" HeaderText="warehouse">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="product" ReadOnly="True" HeaderText="product">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="ord_qty" ReadOnly="True" HeaderText="ord_qty">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="alloc_qty" ReadOnly="True" HeaderText="alloc_qty">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="stock_number" ReadOnly="True" HeaderText="NSN">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="Vendor_DispName" ReadOnly="True" HeaderText="Vendor_DispName">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Product">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "ProductName") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="DSCP Description">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Unit">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "PURCH_UNIT") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Org Supplier">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "Org_Vendor_DispName") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Org Price">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "org_bmmi_cost") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Supplier">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "Vendor_DispName") %>
														</ItemTemplate>
														<EditItemTemplate>
															<asp:DropDownList id="cboSupplier" Width="100px" DataSource='<%# PopulateVendor(Convert.ToString(DataBinder.Eval(Container.DataItem, "warehouse")), Convert.ToString(DataBinder.Eval(Container.DataItem, "Product"))) %>' OnPreRender="SetDropDownIndex" DataTextField="Vendor_DispName" DataValueField="vendor_ID" runat="server" AutoPostBack=True CssClass="FormComboBoxes" OnSelectedIndexChanged="cboSupplier_SelectedIndexChanged" />
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Price">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "bmmi_cost") %>
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox ID="txtBMMICost" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bmmi_cost") %>' ReadOnly=True CssClass="FormTextBoxes" MaxLength="15" Width="50px">
															</asp:TextBox>
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Ord Qty">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "ord_qty") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Alloc Qty">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "alloc_qty") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Bal Qty">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "qty_calculated") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Suggested Qty">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "qty_suggested") %>
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox ID="txtSuggestedQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "qty_suggested") %>' CssClass="FormTextBoxes" MaxLength="15" Width="50px">
															</asp:TextBox>
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Print Status">
														<ItemTemplate>
															<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "PRINT_COUNT")).Equals("0")?"Not Printed":"Printed" %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Change">
														<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
													</asp:EditCommandColumn>
												</Columns>
											</asp:datagrid></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD align="left">
								<ASP:LABEL id="lblTotalProduct" CSSCLASS="FormLabels" RUNAT="server" Width="120px"></ASP:LABEL></TD>
						</TR>
						<TR>
							<TD align="center">
								<ASP:BUTTON id="cmdProceed2" CSSCLASS="FormButtons" RUNAT="server" TEXT="Proceed"></ASP:BUTTON></TD>
						</TR>
					</TABLE>
				</asp:panel></p>
		</form>
	</body>
</HTML>
