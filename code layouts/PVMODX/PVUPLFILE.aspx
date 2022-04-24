<%@ Page language="c#" Codebehind="PVFILEUPL.aspx.cs" AutoEventWireup="false" Inherits="PV.PVFILEUPL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>File upload</title>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
			<SCRIPT language="JavaScript" src="menu_array.js" type="text/javascript"></SCRIPT>
			<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" encType="multipart/form-data" runat="server">
			<TABLE class="sofT" align="center" border="0">
				<TR>
					<TD class="helpHed" colSpan="3">cost upload form-select the file</TD>
				</TR>
				<tr>
					<TD class="innertitle">Select file:</TD>
					<TD class="innertitle"><INPUT id="uplTheFile" type="file" name="uplTheFile" runat="server">
					</TD>
				</tr>
				<TR>
					<td class="innertitle" colSpan="2"><input id="btnUploadTheFile" type="button" value="Upload" name="btnUploadTheFile" runat="server"
							OnServerClick="btnUploadTheFile_ServerClick">
					</td>
				</TR>
			</TABLE>
			<span id="txtOutput" style="FONT: 8pt verdana" runat="server"></span>
			<H2 class="h2head">View/Update Supplier</H2>
			<BR>
			<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="helpHed" align="left" colSpan="4">Supplier Details</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DataGrid" runat="server" CssClass="FormDataGrids" Width="100%" AllowPaging="True"
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
								<asp:BoundColumn Visible="False" DataField="age" ReadOnly="True" HeaderText="age">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Place">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "place") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="age">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "age") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Name">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "name") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<td><asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></td>
				</TR>
				<TR>
					<td align="left"><A href="SupMaster.aspx">Click here to add new Supplier </A>
					</td>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="center" colSpan="4" height="19"><ASP:BUTTON id="cmdSave" RUNAT="server" TEXT="Save" CSSCLASS="FormButtons"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
