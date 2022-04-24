<%@ Page language="c#" Codebehind="PVOPNISAlternatives.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOPNISAlternatives" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVOPNISAlternatives</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 class="h2head">NIS Substitutions</H2>
			<ASP:LABEL id="lblError" Width="500px" CSSCLASS="FormErrorMessages" RUNAT="server"></ASP:LABEL>
			<asp:panel id="pnlStatusDetail" runat="server" Width="100%" Visible="true">
				<TABLE class="sofT" id="tblMain" cellSpacing="0" cellPadding="0" width="100%" align="left"
					border="0">
					<TR bgColor="#f3f8fe">
						<TD>
							<TABLE id="tblMaster" cellSpacing="0" cellPadding="3" width="700" align="left" border="0">
								<TR align="left" bgColor="#f3f8fe">
									<TD width="100">
										<ASP:LABEL id="lblProduct" RUNAT="server" CSSCLASS="FormLabels">Product</ASP:LABEL></TD>
									<TD width="82">
										<ASP:LABEL id="txtProduct" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="lblUnit" RUNAT="server" CSSCLASS="FormLabels">Unit Code</ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="txtUnit" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="lblRatio" RUNAT="server" CSSCLASS="FormLabels">Ratio</ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="txtRatio" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
								</TR>
								<TR align="left" bgColor="#f3f8fe">
									<TD width="100">
										<ASP:LABEL id="lblProdName" RUNAT="server" CSSCLASS="FormLabels">Name</ASP:LABEL></TD>
									<TD width="600" colSpan="5">
										<ASP:LABEL id="txtProdName" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
								</TR>
								<TR bgColor="#f3f8fe">
									<TD align="left" width="100">
										<ASP:LABEL id="lblOrderedQty" RUNAT="server" CSSCLASS="FormLabels">Ordered Qty</ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="txtOrderedQty" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="lblAllocatedQty" RUNAT="server" CSSCLASS="FormLabels">Allocated Qty</ASP:LABEL></TD>
									<TD align="left" width="100">
										<ASP:LABEL id="txtAllocatedQty" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="lblBalanceQty" RUNAT="server" CSSCLASS="FormLabels">Balance Qty</ASP:LABEL></TD>
									<TD align="left" width="82">
										<ASP:LABEL id="txtBalanceQty" RUNAT="server" CSSCLASS="FormTextBoxes"></ASP:LABEL></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
								<TR>
									<TD>
										<asp:datagrid id="dgResults" runat="server" Width="100%" Visible="True" OnCancelCommand="dgResults_OnCancelCommand"
											OnUpdateCommand="dgResults_OnUpdateCommand" Height="23px" BorderColor="Gray" BorderStyle="None"
											BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
											AllowPaging="false" OnEditCommand="dgResults_OnEditCommand" CssClass="FormDataGrids">
											<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
											<ItemStyle CssClass="gridItem" BackColor="White"></ItemStyle>
											<HeaderStyle CssClass="gridHeader"></HeaderStyle>
											<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="alt_wh" ReadOnly="True" HeaderText="alt_wh">
													<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="alt_Product" ReadOnly="True" HeaderText="alt_Product">
													<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Product">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "alt_wh") %>
														<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "alt_Product")).Trim() %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="NSN">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "stock_number") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Description">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Unit">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "alt_uom") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Physical Qty">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "ALT_PHYSICAL_QTY") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Allocated Qty">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "ALT_ALLOC_QTY") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Free Qty">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<%# getFreeQty(Convert.ToString(DataBinder.Eval(Container.DataItem, "ALT_PHYSICAL_QTY")), Convert.ToString(DataBinder.Eval(Container.DataItem, "ALT_ALLOC_QTY"))) %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="On Order Qty">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink Runat =server Target=_blank NavigateUrl ='<%# getNavigationURL(Convert.ToString(DataBinder.Eval(Container.DataItem, "stock_number")), Convert.ToString(DataBinder.Eval(Container.DataItem, "alt_Product"))) %>' ID="Hyperlink1">
															<%# DataBinder.Eval(Container.DataItem, "ALT_ONORDER_QTY") %>
														</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Sugg. Qty">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "SUGG_QTY") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Offer Qty">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "ALT_OFFER_QTY") %>
													</ItemTemplate>
													<EditItemTemplate>
														<span class="FormTextBoxes">
															<ASP:TEXTBOX ID="txtOfferQty" RUNAT="server" MAXLENGTH="10" WIDTH="55px" CSSCLASS="FormTextBoxes" Text='<%# DataBinder.Eval(Container.DataItem, "ALT_OFFER_QTY") %>'>
															</ASP:TEXTBOX>
														</span>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
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
							<ASP:LABEL id="lblTotalProduct" RUNAT="server" CSSCLASS="FormLabels" Width="120px"></ASP:LABEL></TD>
					</TR>
					<TR>
						<TD align="center">&nbsp;
							<ASP:BUTTON id="cmdPrint" RUNAT="server" CSSCLASS="FormButtons" TEXT="Print"></ASP:BUTTON>
							<ASP:BUTTON id="cmdClose" RUNAT="server" CSSCLASS="FormButtons" TEXT="Close"></ASP:BUTTON></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</body>
</HTML>
