<%@ Page language="c#" Codebehind="PVCatalogList.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVCatalogList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVCatalogList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
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
		<form id="Form1" method="post" runat="server">
			<H2 class="h2head">List of products for Catalog update</H2>
			<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="73%" align="center" border="0">
				<TR>
					<TD><asp:datagrid id="dgResults" runat="server" CssClass="FormDataGrids" Width="100%" AllowPaging="false"
							AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px"
							BorderStyle="None" BorderColor="Gray" Height="23px" Visible="True">
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
								<asp:BoundColumn Visible="False" DataField="updateflag" ReadOnly="True" HeaderText="updateflag">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Product">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "warehouse") %>
										<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "product")).Trim() %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="NSN">
									<ItemTemplate>
										<%# (DataBinder.Eval(Container.DataItem, "stock_number"))%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Description">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "description") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Flag">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "updateflag") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Date">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "update_date") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Force update">
									<ItemStyle VerticalAlign="Top"></ItemStyle>
									<HeaderTemplate>
										<asp:CheckBox ID="CheckAll" Checked="false" OnClick="javascript: return select_deselectAll (this.checked, this.id);"
											runat="server" Text="Force update"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="SendThis" CssClass="FormCheckBoxes" Checked="false" runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" EditText="" UpdateText="" CancelText="">
									<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td align="left"><ASP:LABEL id="lblTotalProduct" Width="120px" CSSCLASS="FormLabels" RUNAT="server"></ASP:LABEL></td>
				</tr>
				<tr align="center">
					<td style="HEIGHT: 20px"><ASP:BUTTON id="cmdPrint" Width="100px" Visible="False" CSSCLASS="FormButtons" RUNAT="server"
							TEXT="View Mismatch"></ASP:BUTTON>&nbsp;
						<ASP:BUTTON id="cmdPgExport" Visible="False" CSSCLASS="FormButtons" RUNAT="server" TEXT="Print Page"></ASP:BUTTON>&nbsp;<ASP:BUTTON id="cmdProceed" Visible="False" CSSCLASS="FormButtons" RUNAT="server" TEXT="Proceed"></ASP:BUTTON></td>
					</TD></tr>
				<TR>
					<td><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
