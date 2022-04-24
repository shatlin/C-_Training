<%@ Page language="c#" Codebehind="Modifypa.aspx.cs" AutoEventWireup="false" Inherits="PV.ModifyPallette" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>

	<HEAD>
		<title>ModifyPallette</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_array.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H2 class="h2head">View/Update Pallette</H2>
			<BR>
			<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="helpHed" align="left" colSpan="4">Pallette Details</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="DataGrid2" runat="server" CssClass="FormDataGrids" Width="100%" OnUpdateCommand="DataGrid2_OnUpdateCommand"
							OnCancelCommand="DataGrid2_OnCancelCommand" OnEditCommand="DataGrid2_OnEditCommand" AllowPaging="True"
							PageSize="20" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BackColor="White"
							BorderWidth="1px" BorderStyle="None" BorderColor="Gray" Height="23px" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<PagerStyle Mode="NextPrev" HorizontalAlign="right" Font-Size="11px" Font-Names="Verdana" ForeColor="Black"
								BackColor="White" NextPageText="Next " PrevPageText=" Prev" Position="bottom"></PagerStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="palcntr_id" ReadOnly="True" HeaderText="ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="No">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "palcntr_id") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Type">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "pallet_type") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtPalletteType" RUNAT="server" MAXLENGTH="10" WIDTH="82px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "pallet_type"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Dodaac Spl">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "dodaac_special") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST ID="cboDodaacSpl" RUNAT="server" WIDTH="40px" CSSCLASS="FormComboBoxes">
												<ASP:LISTITEM VALUE="E">Export</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="L">Local</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="N">Normal</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="K">Kandahaar</ASP:LISTITEM>
											</ASP:DROPDOWNLIST>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								
							<asp:TemplateColumn HeaderText="Size">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "cntr_size") %>
								</ItemTemplate>
								<EditItemTemplate>
									<span class="FormTextBoxes">
										<ASP:DROPDOWNLIST ID="CboCntrSize" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
											<ASP:LISTITEM VALUE="20">20 ft</ASP:LISTITEM>
											<ASP:LISTITEM VALUE="40">40 ft</ASP:LISTITEM>
											<ASP:LISTITEM VALUE="N">Other</ASP:LISTITEM>
										</ASP:DROPDOWNLIST>
									</span>
								</EditItemTemplate>
							</asp:TemplateColumn>
												
					<asp:TemplateColumn HeaderText="Container Type">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "cntr_type") %>
						</ItemTemplate>
						<EditItemTemplate>
							<span class="FormTextBoxes">
								<ASP:DROPDOWNLIST ID="CboCntrType" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
									<ASP:LISTITEM VALUE="F">Frozen</ASP:LISTITEM>
									<ASP:LISTITEM VALUE="D">Dry</ASP:LISTITEM>
									<ASP:LISTITEM VALUE="C">Chilled</ASP:LISTITEM>
								</ASP:DROPDOWNLIST></span>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Maximum Pallettes">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem, "max_pallets") %>
						</ItemTemplate>
						<EditItemTemplate>
							<span class="FormTextBoxes">
								<ASP:TEXTBOX ID="txtMaxPallettes" RUNAT="server" WIDTH="150px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "max_pallets"))) %>'>
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
								<ASP:DROPDOWNLIST ID="CboStatus" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
									<ASP:LISTITEM VALUE="O">Active</ASP:LISTITEM>
									<ASP:LISTITEM VALUE="C">Inactive</ASP:LISTITEM>
								</ASP:DROPDOWNLIST></span>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:EditCommandColumn ButtonType="LinkButton" EditText="Edit" UpdateText="Update" CancelText="Cancel">
						<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
					</asp:EditCommandColumn>
					</Columns> 
					</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<td><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
