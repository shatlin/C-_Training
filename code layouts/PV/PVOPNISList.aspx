<%@ Register TagPrefix="uc1" TagName="DetailList" Src="Temp/DetailList.ascx" %>
<%@ Page language="c#" Codebehind="PVOPNISList.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOPNISList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVOPNISList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="javascript">
			function disableGen() 
			{ 
				// var frm = document.forms[0];
				// document.forms1.address2.disabled=false;
				document.forms[0].cmdGenerate.disabled = false;
		
			}
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 class="h2head">NIS List</H2>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
				border="0">
				<TR>
					<TD>
						<ASP:LABEL id="lblOrder" RUNAT="server" CSSCLASS="FormLabels">Order #</ASP:LABEL>&nbsp;
						<ASP:TEXTBOX id="txtOrderNo" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="100px" MAXLENGTH="10"></ASP:TEXTBOX>&nbsp;
						<ASP:BUTTON id="cmdView" RUNAT="server" CSSCLASS="FormButtons" TEXT="View"></ASP:BUTTON>
					</TD>
				</TR>
				<tr>
					<td align="left">
						<ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages" Width="350px"></ASP:LABEL>
					</td>
				</tr>
			</TABLE>
			<p>
				<asp:panel id="pnlStatus" runat="server" Visible="False" Width="100%">
					<TABLE class="sofT" id="tblMain" cellSpacing="0" cellPadding="0" width="100%" align="left"
						border="0">
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
											<asp:datagrid id="DataGrid2" runat="server" Width="100%" Visible="True" Height="23px" BorderColor="Gray"
												BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal"
												AutoGenerateColumns="False" AllowPaging="false" OnEditCommand="DataGrid2_OnEditCommand" OnItemDataBound="DataGrid2_ItemDataBound"
												CssClass="FormDataGrids">
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
													<asp:BoundColumn Visible="False" DataField="order_qty" ReadOnly="True" HeaderText="ord">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="a_qty" ReadOnly="True" HeaderText="all">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="balance_qty" ReadOnly="True" HeaderText="bal">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="dscp_desc" ReadOnly="True" HeaderText="dscp_desc">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="unit_code" ReadOnly="True" HeaderText="unit_code">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="ratio_numerator" ReadOnly="True" HeaderText="ratio_numerator">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="stock_number" ReadOnly="True" HeaderText="NSN">
														<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Product">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "ProductName") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Unit">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "unit_code") %>
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
													<asp:TemplateColumn HeaderText="On Order Qty" ItemStyle-HorizontalAlign="Center">
														<ItemTemplate>
															<asp:HyperLink Runat =server Target=_blank NavigateUrl ='<%# getNavigationURL(Convert.ToString(DataBinder.Eval(Container.DataItem, "stock_number")), Convert.ToString(DataBinder.Eval(Container.DataItem, "product"))) %>' ID="Hyperlink1">
																<%# DataBinder.Eval(Container.DataItem, "on_order_qty") %>
															</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="DSCP Description">
														<ItemTemplate>
															<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:EditCommandColumn ButtonType="LinkButton" EditText="Substitue">
														<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
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
							<TD align="center">&nbsp;
								<ASP:BUTTON id="cmdPrint" CSSCLASS="FormButtons" RUNAT="server" TEXT="View" Visible="true"></ASP:BUTTON>
								<ASP:BUTTON id="cmdGenerate" CSSCLASS="FormButtons" RUNAT="server" TEXT="Generate" Visible="true"></ASP:BUTTON></TD>
						</TR>
					</TABLE>
				</asp:panel>
			</p>
		</form>
	</body>
</HTML>
