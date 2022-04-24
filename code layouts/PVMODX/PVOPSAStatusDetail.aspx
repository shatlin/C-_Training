<%@ Page language="c#" Codebehind="PVOPSAStatusDetail.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOPSAStatusDetail" %>
<%@ Register TagPrefix="mbcbb" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.ComboBox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVOPSAStatusDetail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<asp:panel id="pnlMenu" runat="server" Visible="False" Width="100%">
			<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
			<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		</asp:panel>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 class="h2head">Stock Allocation Status Detail</H2>
			<asp:panel id="pnlStatus" runat="server" Visible="False" Width="100%">
				<TABLE class="sofT" id="tblProduct" cellSpacing="0" cellPadding="0" width="60%" align="center"
					border="0">
					<TR>
						<TD align="left" width="50">
							<ASP:LABEL id="lblProductName" CSSCLASS="FormLabels" RUNAT="server">Name</ASP:LABEL></TD>
						<TD align="left" width="500">
							<mbcbb:combobox id="cboProductName" Width="530px" Visible="true" runat="server" AutoPostBack="True"
								Rows="15" CssClass="FormComboBoxes"></mbcbb:combobox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<ASP:LABEL id="Label1" CSSCLASS="FormLabels" RUNAT="server">Product</ASP:LABEL>&nbsp;
							<ASP:TEXTBOX id="txtProductName" CSSCLASS="FormTextBoxes" RUNAT="server" MAXLENGTH="10" WIDTH="100px"></ASP:TEXTBOX>&nbsp;
							<ASP:BUTTON id="cmdView" CSSCLASS="FormButtons" RUNAT="server" TEXT="View"></ASP:BUTTON></TD>
					</TR>
					<TR>
						<TD align="left">
							<ASP:LABEL id="lblError" CSSCLASS="FormErrorMessages" RUNAT="server"></ASP:LABEL></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="pnlStatusDetail" runat="server" Visible="False" Width="100%">
				<TABLE class="sofT" id="tblMain" cellSpacing="0" cellPadding="0" width="100%" align="left"
					border="0">
					<TR bgColor="#f3f8fe">
						<TD>
							<TABLE id="tblMaster" cellSpacing="0" cellPadding="3" width="700" align="left" border="0">
								<TR align="left" bgColor="#f3f8fe">
									<TD width="100">
										<ASP:LABEL id="lblProduct" CSSCLASS="FormLabels" RUNAT="server">Product</ASP:LABEL></TD>
									<TD width="600">
										<ASP:LABEL id="txtProduct" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
								</TR>
								<TR align="left" bgColor="#f3f8fe">
									<TD width="100">
										<ASP:LABEL id="lblProdName" CSSCLASS="FormLabels" RUNAT="server">Name</ASP:LABEL></TD>
									<TD width="600">
										<ASP:LABEL id="txtProdName" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
								</TR>
								<TR bgColor="#f3f8fe">
									<TD width="100"></TD>
									<TD width="600"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
								<TR>
									<TD>
										<asp:datagrid id="DataGrid2" Width="100%" Visible="True" runat="server" CssClass="FormDataGrids"
											Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
											GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false" OnPageIndexChanged="DataGrid2_PageIndexChanged">
											<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
											<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
											<HeaderStyle CssClass="gridHeader"></HeaderStyle>
											<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="order_no" ReadOnly="True" HeaderText="order_no">
													<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Order #">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "order_no") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Customer">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "customer") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Name">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "address1") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="RDD">
													<ItemTemplate>
														<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "date_required")).ToString("dd-MMM-yyyy") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Ordered Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="25">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "order_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Allocated Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="25">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "allocated_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Balance Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="25">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "balance_qty") %>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Status">
													<ItemTemplate>
														<%# DataBinder.Eval(Container.DataItem, "description") %>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD align="left">
										<ASP:LABEL id="lblTotalProduct" Width="120px" CSSCLASS="FormLabels" RUNAT="server"></ASP:LABEL></TD>
								</TR>
								<TR>
									<TD align="center">&nbsp;
										<ASP:BUTTON id="cmdPrint" CSSCLASS="FormButtons" RUNAT="server" TEXT="View"></ASP:BUTTON>&nbsp;
										<ASP:BUTTON id="cmdClose" CSSCLASS="FormButtons" RUNAT="server" TEXT="Close"></ASP:BUTTON></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
	</body>
</HTML>
