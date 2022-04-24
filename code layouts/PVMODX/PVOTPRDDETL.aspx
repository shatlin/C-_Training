<%@ Page language="c#" Codebehind="PVOTPRDDETL.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVOTPRDDETL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PRODUCT DETAILS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		
			<form id="Form1" method="post" runat="server" >
				<asp:panel id="pnlposel" runat="server" Visible="False" Width="800">
					<TABLE class="sofT" align="center" border="0">
						<TR>
							<TD class="helpHed" colSpan="3">Select the product</TD>
						</TR>
						<TR>
							<TD class="innertitle" colSpan="3">&nbsp;</TD>
						</TR>
						<TR>
							<TD class="innertitle" height="1">Product</TD>
							<TD class="innertitle" width="10" bgColor="#99ccff" height="1">
								<asp:dropdownlist id="cboProducts" runat="server" Visible="True" Width="150px" CssClass="FormComboBoxes"></asp:dropdownlist></TD>
							<TD class="innertitle" width="10" height="1"></TD>
						</TR>
						<TR>
							<TD class="innertitle" align="center" colSpan="3">
								<CENTER>
									<ASP:BUTTON id="cmdContinue" RUNAT="server" TEXT="Continue" CSSCLASS="FormButtons"></ASP:BUTTON></CENTER>
							</TD>
						</TR>
					</TABLE>
				</asp:panel><br>
				<asp:panel id="pnlPrdDetl" runat="server" Visible="False" Width="800">
					<TABLE class="sofT" id="detailtables" cellSpacing="0" cellPadding="0" width="800" align="center"
						border="0">
						<TR>
							<TD>
								<asp:datagrid id="Datagrid4" runat="server" Visible="True" Width="800" CssClass="FormDataGrids"
									Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
									GridLines="Both" AutoGenerateColumns="False">
									<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
									<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
									<HeaderStyle CssClass="gridHeader"></HeaderStyle>
									<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="product" ReadOnly="True" HeaderText="product">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderStyle-BackColor="#6699cc" HeaderText="Product Details" HeaderStyle-ForeColor="White"
											ItemStyle-Width="30%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="14px" ItemStyle-BackColor="#6699cc"
											ItemStyle-ForeColor="White" ItemStyle-Font-Bold="True" ItemStyle-Font-Size="10px" ItemStyle-HorizontalAlign="Center">
											<ItemTemplate>
												PO#:
												<%# DataBinder.Eval(Container.DataItem, "pono") %>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product:<%# DataBinder.Eval(Container.DataItem, "warehouse") %>-
												<%# DataBinder.Eval(Container.DataItem, "product") %>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NSN:<%# DataBinder.Eval(Container.DataItem, "nsn") %>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DESC:<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid>
								<asp:panel id="pnlNIS" runat="server" Visible="False" Width="800">
									<asp:datagrid id="DataGrid" runat="server" Visible="True" Width="800" CssClass="FormDataGrids"
										Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
										GridLines="Both" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
										<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
										<HeaderStyle CssClass="gridHeader"></HeaderStyle>
										<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="GRN_NO" ReadOnly="True" HeaderText="GRN_NO">
												<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="GRN_NO" ItemStyle-Width="200" HeaderStyle-Width="200">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "GRN_NO") %>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="GRNDATE" ItemStyle-Width="300" HeaderStyle-Width="300">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "grndate") %>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="RCVD QTY" ItemStyle-Width="300" HeaderStyle-Width="300">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "RCVD_QTY") %>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
									<ASP:LABEL id="lblTotalGRN" Width="120px" RUNAT="server" CSSCLASS="FormLabels"></ASP:LABEL>
								</asp:panel></TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD>
								<asp:datagrid id="Datagrid5" runat="server" Visible="True" Width="800" CssClass="FormDataGrids"
									Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
									GridLines="Both" AutoGenerateColumns="False" AllowPaging="false" OnItemDataBound="Datagrid5_ItemDataBound"
									OnEditCommand="Datagrid5_OnEditCommand">
									<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
									<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
									<HeaderStyle CssClass="gridHeader"></HeaderStyle>
									<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="ASN_NO" ReadOnly="True" HeaderText="ASN_NO">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="ASN_NO" ItemStyle-Width="200" HeaderStyle-Width="200">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "ASN_NO") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="ASNDATE" ItemStyle-Width="100" HeaderStyle-Width="100">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "asndate") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="ETA" ItemStyle-Width="200" HeaderStyle-Width="200">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "eta") %>
												&nbsp; to &nbsp;
												<%# DataBinder.Eval(Container.DataItem, "maxeta") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="SHIPPED QTY" ItemStyle-Width="200" HeaderStyle-Width="200">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "QTY_SHIPPED") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:EditCommandColumn ButtonType="LinkButton" EditText="Detail" ItemStyle-Width="95" HeaderStyle-Width="95">
											<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
										</asp:EditCommandColumn>
									</Columns>
								</asp:datagrid>
								<ASP:LABEL id="lblTotalASN" Width="120px" RUNAT="server" CSSCLASS="FormLabels"></ASP:LABEL></TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD>
								<asp:datagrid id="Datagrid3" runat="server" Visible="True" Width="800" CssClass="FormDataGrids"
									Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
									GridLines="Both" AutoGenerateColumns="False">
									<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
									<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
									<HeaderStyle CssClass="gridHeader"></HeaderStyle>
									<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="SHPLANNO" ReadOnly="True" HeaderText="SHPLANNO">
											<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="SHPLANNO" ItemStyle-Width="200" HeaderStyle-Width="200">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "SHPLANNO") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="PLANDATE" ItemStyle-Width="100" HeaderStyle-Width="100">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "plandate") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="ETA" ItemStyle-Width="200" HeaderStyle-Width="200">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "eta") %>
												&nbsp; to &nbsp;
												<%# DataBinder.Eval(Container.DataItem, "maxeta") %>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="PLANNED QTY" ItemStyle-Width="300" HeaderStyle-Width="300">
											<ItemTemplate>
												<%# DataBinder.Eval(Container.DataItem, "PLAN_QTY") %>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid>
								<ASP:LABEL id="lblTotalShipping" Width="120px" RUNAT="server" CSSCLASS="FormLabels"></ASP:LABEL></TD>
						</TR>
					</TABLE>
				</asp:panel></form>
	
	</body>
</HTML>
