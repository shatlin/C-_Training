<%@ Page language="c#" Codebehind="ModifySupplier.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.ModifySupplier" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ModifySupplier</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT LANGUAGE="JavaScript" SRC="mmenu.js" TYPE="text/javascript"></SCRIPT>
		<LINK HREF="PVMODSTYLES.CSS" TYPE="text/css" REL="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H2 CLASS="h2head">View/Update Supplier</H2>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
				border="0">
				<TR bgcolor="#d2e4fc">
					<TD>
						<ASP:LABEL id="lblOrder" RUNAT="server" CSSCLASS="FormLabels">Type</ASP:LABEL>&nbsp;&nbsp;
						<asp:DropDownList id="cboSupplierType" runat="server" Width="90px" CssClass="FormComboBoxes">
							<asp:ListItem Value="A" Selected="True">Auto</asp:ListItem>
							<asp:ListItem Value="M">Manual</asp:ListItem>
						</asp:DropDownList>&nbsp;
						<ASP:BUTTON id="cmdView" RUNAT="server" CSSCLASS="FormButtons" TEXT="View"></ASP:BUTTON>
					</TD>
				</TR>
			</TABLE>
			<TABLE CLASS="sofT" CELLSPACING="0" CELLPADDING="0" WIDTH="100%" ALIGN="center" BORDER="0">
				<TR>
					<TD CLASS="helpHed" ALIGN="left" COLSPAN="4">Supplier Details</TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="DataGrid2" runat="server" CssClass="FormDataGrids" Width="100%" OnUpdateCommand="DataGrid2_OnUpdateCommand"
							OnCancelCommand="DataGrid2_OnCancelCommand" OnEditCommand="DataGrid2_OnEditCommand" AllowPaging="false"
							AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px"
							BorderStyle="None" BorderColor="Gray" Height="23px" Visible="True">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="vendor_ID" ReadOnly="True" HeaderText="vendor_ID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Code">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vendor_code") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Type">
									<ItemTemplate>
										<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "vendor_Type")).Equals("A")?"Auto":"Manual" %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Name">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vendor_Name") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Display Name">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vendor_DispName") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtVendorDispName" RUNAT="server" MAXLENGTH="10" WIDTH="82px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "vendor_DispName"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lead Time">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Lead_Time") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtLeadTime" RUNAT="server" MAXLENGTH="10" WIDTH="55px" CSSCLASS="FormTextBoxes" Text='<%# DataBinder.Eval(Container.DataItem, "Lead_Time") %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lead Time Var">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Lead_Time_Var") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtLeadTimeVar" RUNAT="server" MAXLENGTH="10" WIDTH="55px" CSSCLASS="FormTextBoxes" Text='<%# DataBinder.Eval(Container.DataItem, "Lead_Time_Var") %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ship Plan Accuracy">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Shp_Plan_Accuracy") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtShpPlanAccuracy" RUNAT="server" MAXLENGTH="10" WIDTH="55px" CSSCLASS="FormTextBoxes" Text='<%# DataBinder.Eval(Container.DataItem, "Shp_Plan_Accuracy") %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ETA Accuracy">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "ETA_Accuracy") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtETAAccuracy" RUNAT="server" MAXLENGTH="10" WIDTH="55px" CSSCLASS="FormTextBoxes" Text='<%# DataBinder.Eval(Container.DataItem, "ETA_Accuracy") %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Status") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:DROPDOWNLIST ID="cboStatus" RUNAT="server" WIDTH="40px" CSSCLASS="FormComboBoxes">
												<ASP:LISTITEM VALUE="O">O</ASP:LISTITEM>
												<ASP:LISTITEM VALUE="C">C</ASP:LISTITEM>
											</ASP:DROPDOWNLIST>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Remarks">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Remarks") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtRemarks" RUNAT="server" MAXLENGTH="40" WIDTH="120px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "Remarks"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Contact">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vendor_contact") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtContact" RUNAT="server" MAXLENGTH="40" WIDTH="120px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "vendor_contact"))) %>'>
											</ASP:TEXTBOX>
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>		
								<asp:TemplateColumn HeaderText="Fax">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vendor_fax") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ASP:TEXTBOX ID="txtContactFax" RUNAT="server" MAXLENGTH="10" WIDTH="82px" CSSCLASS="FormTextBoxes" Text='<%# formatValue(Convert.ToString(DataBinder.Eval(Container.DataItem, "vendor_fax"))) %>'>
											</ASP:TEXTBOX>
										</span>
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
					<td>
						<asp:Label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:Label>
					</td>
				</TR>
				<TR>
					<td align="left">
						<a href="SupMaster.aspx">Click here to add new Supplier </a>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
