<%@ Page language="c#" Codebehind="PVCASEMOD.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.ModifyCase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Modify Case</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H2 class="h2head">View/Update Case</H2>
			<BR>
			<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="helpHed" style="HEIGHT: 15px" align="left" colSpan="4">Case Details</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DataGrid2" runat="server" Visible="True" Height="23px" BorderColor="Gray" BorderStyle="None"
							BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
							PageSize="20" AllowPaging="True" OnEditCommand="DataGrid2_OnEditCommand" OnCancelCommand="DataGrid2_OnCancelCommand"
							OnUpdateCommand="DataGrid2_OnUpdateCommand" Width="100%" CssClass="FormDataGrids">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<PagerStyle Mode="NextPrev" HorizontalAlign="right" Font-Size="11px" Font-Names="Verdana" ForeColor="Black"
								BackColor="White" NextPageText="Next " PrevPageText=" Prev" Position="bottom"></PagerStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="caspal_id" ReadOnly="True" HeaderText="ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="No">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "caspal_id") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Type">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "pallet_type") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST ID="CboPalletteType" RUNAT="server" WIDTH="100px" CSSCLASS="FormComboBoxes">
												<ASP:LISTITEM VALUE="E">Export</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="L">Local</ASP:LISTITEM>
											</ASP:DROPDOWNLIST>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Dodaac Spl">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "dodaac_special") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST ID="CboDodaacSpl" RUNAT="server" WIDTH="100px" CSSCLASS="FormComboBoxes">
												<ASP:LISTITEM VALUE="N">Normal</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="K">Kandahaar</ASP:LISTITEM>
											</ASP:DROPDOWNLIST>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Size">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem,"cntr_size")%>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST Autopostback="True" ID="CboCntrSize" RUNAT="server" WIDTH="50px" CSSCLASS="FormComboBoxes"
												OnSelectedIndexChanged="CboCntrSize_SelectedIndexChanged">
												<ASP:LISTITEM VALUE="20">20</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="40">40</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="O">Other</ASP:LISTITEM>
											</ASP:DROPDOWNLIST>
											<ASP:TEXTBOX id="txtOther" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="60px" Visible="false"></ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Container Type">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "cntr_type") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST ID="CboCntrType" RUNAT="server" WIDTH="100px" CSSCLASS="FormComboBoxes">
												<ASP:LISTITEM VALUE="F">Frozen</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="D">Dry</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="C">Chilled</ASP:LISTITEM>
											</ASP:DROPDOWNLIST></span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Pal_Length">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "pallet_length") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtPalLength" RUNAT="server" WIDTH="50px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "pallet_length"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Pal_Width ">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "pallet_width") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtPalWidth" RUNAT="server" WIDTH="50px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "pallet_width"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Pal_Height">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "pallet_height") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtPalHeight" RUNAT="server" WIDTH="50px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "pallet_height"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Max Cases">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "max_cases") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtMaxCases" RUNAT="server" WIDTH="50px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "max_cases"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "status") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST ID="CboStatus" RUNAT="server" WIDTH="100px" CSSCLASS="FormComboBoxes">
												<ASP:LISTITEM VALUE="O">Active</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="C">Inactive</ASP:LISTITEM>
											</ASP:DROPDOWNLIST></span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" EditText="Edit" UpdateText="Update" CancelText="Cancel">
									<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<td><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></td>
				</TR>
				<TR>
					<td align="left">
						<a href="PVCASEADD.aspx">Click here to add new Case </a>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
