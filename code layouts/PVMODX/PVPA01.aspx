<%@ Page language="c#" Codebehind="PVPA01.aspx.cs" AutoEventWireup="false" Inherits="PV.PVPA01" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVPA01</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_array.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="javascript">
			function select_deselectAll(chkVal, idVal) 
			{ 
				var frm = document.forms[0];
			    
				// Loop through all elements
				for (i=0; i<frm.length; i++) 
				{
					var val1 = frm.elements[i].name;
					// Look for our Header Template's Checkbox
					if (idVal.indexOf ('CheckAll') != -1) 
					{
						// Check if main checkbox is checked, then select or deselect datagrid checkboxes 
						if (val1.indexOf ('SendThis') != -1)
						{
							if(chkVal == true) 
							{
								frm.elements[i].checked = true;
							} 
							else 
							{
								frm.elements[i].checked = false;
							}
						}
							// Work here with the Item Template's multiple checkboxes
					} 
					else if (idVal.indexOf ('DeleteThis') != -1) 
					{
						// Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
						if(frm.elements[i].checked == false) 
						{
							frm.elements[1].checked = false; //Uncheck main select all checkbox
						}
					}
				}

			}
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 class="h2head">Purchase Analysis Tool</H2>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="300" align="center"
				border="0">
				<TR>
					<TD align="left"><ASP:LABEL id="lblSupplier" RUNAT="server" CSSCLASS="FormLabels">Supplier</ASP:LABEL></TD>
					<td align="left"><ASP:LABEL id="lblWarehouse" RUNAT="server" CSSCLASS="FormLabels">Warehouse</ASP:LABEL></td>
					<td align="left"></td>
				</TR>
				<tr vAlign="bottom">
					<td align="right"><asp:listbox id="lstSupplier" runat="server" SelectionMode="Multiple" Width="150px" Height="110px"
							CssClass="FormListBoxes"></asp:listbox></td>
					<td align="left"><asp:listbox id="lstWarehouse" runat="server" SelectionMode="Multiple" Width="150px" Height="110px"
							CssClass="FormListBoxes"></asp:listbox></td>
					<td vAlign="middle" align="left"><ASP:LABEL id="lblNSN" RUNAT="server" CSSCLASS="FormLabels">NSN</ASP:LABEL><BR>
						<ASP:TEXTBOX id="txtNSN" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX><BR>
					</td>
				</tr>
				<tr>
					<td align="left"><asp:checkbox id="chkProduct" runat="server" TextAlign="Left" Text="Product" Visible="False"></asp:checkbox></td>
					<td align="right"><ASP:BUTTON id="cmdClear" RUNAT="server" CSSCLASS="FormButtons" Width="110px" TEXT="Clear Selection"></ASP:BUTTON></td>
					<td align="left"><ASP:BUTTON id="cmdView" RUNAT="server" CSSCLASS="FormButtons" TEXT="View"></ASP:BUTTON></td>
				</tr>
				<tr>
					<td align="left" colSpan="3"><ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages"></ASP:LABEL></td>
				</tr>
			</TABLE>
			<hr>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
				<tr>
					<td vAlign="baseline" align="center"><ASP:BUTTON id="cmdContinueTop" RUNAT="server" CSSCLASS="FormButtons" Visible="False" TEXT="Continue"></ASP:BUTTON></td>
				</tr>
				<tr>
					<td align="left"><ASP:LABEL id="lblTotalRecords" RUNAT="server" CSSCLASS="FormLabels"></ASP:LABEL></td>
				</tr>
				<TR>
					<TD><asp:datagrid id="DataGrid2" runat="server" Width="100%" Height="23px" CssClass="FormDataGrids"
							Visible="True" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
							GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="stock_number" ReadOnly="True" HeaderText="stock_number">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="warehouse" ReadOnly="True" HeaderText="warehouse">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="product" ReadOnly="True" HeaderText="product">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemStyle VerticalAlign="Top"></ItemStyle>
									<HeaderTemplate>
										<asp:CheckBox ID="CheckAll" Checked="false" OnClick="javascript: return select_deselectAll (this.checked, this.id);"
											runat="server"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="SendThis" CssClass="FormCheckBoxes" Checked="false" runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="WH">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "warehouse") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="product">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "product") %>
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
								<asp:TemplateColumn HeaderText="Purchase Unit">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "purchase_unit") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td align="center"><ASP:BUTTON id="cmdContinueBottom" RUNAT="server" CSSCLASS="FormButtons" Visible="False" TEXT="Continue"></ASP:BUTTON></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
