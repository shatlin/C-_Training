<%@ Page language="c#" Codebehind="PVFTPStatus.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVFTPStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVFTPStatus</title>
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
			<H2 class="h2head">FTP Transmission Details</H2>
			<table id="tblError" cellSpacing="0" cellPadding="0" width="50%" align="center" border="0">
				<tr>
					<td align="left"><ASP:LABEL id="lblError" Width="100px" CSSCLASS="FormErrorMessages" RUNAT="server"></ASP:LABEL></td>
				</tr>
			</table>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
				border="0">
				<TR>
					<TD align="left"><ASP:LABEL id="lblPending" Width="190px" CSSCLASS="FormLabels" RUNAT="server">Pending Transmission</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgResults" runat="server" Width="100%" OnEditCommand="dgResults_OnEditCommand"
							Visible="True" Height="23px" BorderColor="Gray" BorderStyle="none" BorderWidth="1px" BackColor="White"
							CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false" CssClass="FormDataGrids">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="INFILENAME" ReadOnly="True" HeaderText="INFILENAME">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="OUTFILENAME" ReadOnly="True" HeaderText="OUTFILENAME">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="USERID" ReadOnly="True" HeaderText="USERID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PASSWORD" ReadOnly="True" HeaderText="PASSWORD">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ADDRESS" ReadOnly="True" HeaderText="ADDRESS">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="INDIRECTORY" ReadOnly="True" HeaderText="INDIRECTORY">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="txn_type" ReadOnly="True" HeaderText="txn_type">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="STATUS" ReadOnly="True" HeaderText="STATUS">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="File Name">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "INFILENAME") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Date">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "UPLOAD_DATE") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "STATUS") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" EditText="Transmit" UpdateText="" CancelText="">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="left"><ASP:LABEL id="lblTotalTrxn" Width="120px" CSSCLASS="FormLabels" RUNAT="server"></ASP:LABEL></TD>
				</TR>
			</TABLE>
			<br>
			<TABLE class="sofT" id="tblErrorTrxn" cellSpacing="0" cellPadding="0" width="50%" align="center"
				border="0">
				<TR>
					<TD align="left"><ASP:LABEL id="lblErrorHead" Width="120px" CSSCLASS="FormLabels" RUNAT="server">Error Transmission</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="dgResults1" runat="server" Width="100%" OnEditCommand="dgResults1_OnEditCommand"
							Visible="True" Height="23px" BorderColor="Gray" BorderStyle="none" BorderWidth="1px" BackColor="White"
							CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false" CssClass="FormDataGrids">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="INFILENAME" ReadOnly="True" HeaderText="INFILENAME">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="OUTFILENAME" ReadOnly="True" HeaderText="OUTFILENAME">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="USERID" ReadOnly="True" HeaderText="USERID">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PASSWORD" ReadOnly="True" HeaderText="PASSWORD">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ADDRESS" ReadOnly="True" HeaderText="ADDRESS">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="INDIRECTORY" ReadOnly="True" HeaderText="INDIRECTORY">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="txn_type" ReadOnly="True" HeaderText="txn_type">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="STATUS" ReadOnly="True" HeaderText="STATUS">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="File Name">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "INFILENAME") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Date">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "UPLOAD_DATE") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "STATUS") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" EditText="Resend" UpdateText="" CancelText="">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<asp:button id="cmdFTP" style="Z-INDEX: 101; LEFT: 376px; POSITION: absolute; TOP: 440px" runat="server"
				Visible="False" Text="FTP"></asp:button></form>
	</body>
</HTML>
