<%@ Register TagPrefix="ew" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" %>
<%@ Page language="c#" Codebehind="PVPAVIEW.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPAVIEW" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<BODY>
		<h2 class="h2head">
			View&nbsp;Purchase Analysis</h2>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<form id="Form1" runat="server">
			<TABLE class="sofT" id="Table1" width="300" align="center" border="0">
				<TR>
					<TD class="helphed" colSpan="2">
						Select&nbsp;PA Date</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblDateFrom" runat="server">From</asp:label></TD>
					<TD class="borderlesstitle" align="left" height="25">
						<P align="left"><ew:calendarpopup id="calendarPopup1" runat="server" Text="..." ControlDisplay="TextboxImage" Width="104px"
								ImageUrl="IMAGES/cal.gif" Culture="English (United Kingdom)" DayNameFormat="Short"></ew:calendarpopup><WEEKDAYSTYLE BackColor="#F3F8FE" ForeColor="Black" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></WEEKDAYSTYLE><MONTHHEADERSTYLE BackColor="#6699CC" ForeColor="White" Font-Bold="True" Font-Size="11pt"></MONTHHEADERSTYLE><OFFMONTHSTYLE BackColor="Linen" ForeColor="Black" Font-Names="Verdana" Font-Size="XX-Small"></OFFMONTHSTYLE><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small"></GOTOTODAYSTYLE><TODAYDAYSTYLE BackColor="#99CCFF" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small" BorderColor="Red"></TODAYDAYSTYLE><DAYHEADERSTYLE BackColor="#D2E4FC" ForeColor="Black" CssClass="caldays"></DAYHEADERSTYLE><WEEKENDSTYLE BackColor="#F3F8FE" ForeColor="Black" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></WEEKENDSTYLE><SELECTEDDATESTYLE BackColor="#99CCFF" ForeColor="Black" Font-Bold="True" Font-Names="Tahoma" Font-Size="XX-Small"></SELECTEDDATESTYLE><CLEARDATESTYLE BackColor="White" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small"></CLEARDATESTYLE><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small"></HOLIDAYSTYLE></P>
					</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px" align="right" width="124">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblDateTo" runat="server">To</asp:label></TD>
					<TD class="borderlesstitle" align="left">
						<P align="left"><ew:calendarpopup id="CalendarPopup2" runat="server" Text="..." ControlDisplay="TextboxImage" Width="104px"
								ImageUrl="IMAGES/cal.gif" Culture="English (United Kingdom)" DayNameFormat="Short"></ew:calendarpopup><WEEKDAYSTYLE BackColor="#F3F8FE" ForeColor="Black" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></WEEKDAYSTYLE><MONTHHEADERSTYLE BackColor="#6699CC" ForeColor="White" Font-Bold="True" Font-Size="11pt"></MONTHHEADERSTYLE><OFFMONTHSTYLE BackColor="Linen" ForeColor="Black" Font-Names="Verdana" Font-Size="XX-Small"></OFFMONTHSTYLE><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small"></GOTOTODAYSTYLE><TODAYDAYSTYLE BackColor="#99CCFF" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small" BorderColor="Red"></TODAYDAYSTYLE><DAYHEADERSTYLE BackColor="#D2E4FC" ForeColor="Black" CssClass="caldays"></DAYHEADERSTYLE><WEEKENDSTYLE BackColor="#F3F8FE" ForeColor="Black" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"></WEEKENDSTYLE><SELECTEDDATESTYLE BackColor="#99CCFF" ForeColor="Black" Font-Bold="True" Font-Names="Tahoma" Font-Size="XX-Small"></SELECTEDDATESTYLE><CLEARDATESTYLE BackColor="White" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small"></CLEARDATESTYLE><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Names="Verdana,Helvetica,Tahoma,Arial"
								Font-Size="XX-Small"></HOLIDAYSTYLE></P>
					</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px" width="124"></TD>
					<TD class="borderlesstitle" align="center">
						<P align="left"><asp:button id="btnViewPA" runat="server" Text="View" CssClass="FormButtons"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
			<br>
			<asp:panel id="pnlPA" runat="server" Visible="False">
				<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD class="helpHed" align="left" colSpan="4" height="15">Purchase 
							Analysis&nbsp;Details</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:datagrid id="DataGrid2" runat="server" Width="100%" BackColor="White" BorderColor="Gray"
								CssClass="FormDataGrids" Visible="True" Height="23px" BorderStyle="None" BorderWidth="1px"
								CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="false" OnItemDataBound="DataGrid2_ItemDataBound"
								OnEditCommand="DataGrid2_OnEditCommand">
								<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
								<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
								<HeaderStyle CssClass="gridHeader"></HeaderStyle>
								<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
								<Columns>
								
									<asp:BoundColumn Visible="False" DataField="POPLANNO" ReadOnly="True" HeaderText="SHPLANNO">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
								
									<asp:TemplateColumn HeaderText="PLAN NO">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "POPLANNO") %>
										</ItemTemplate>
									</asp:TemplateColumn>
								
									<asp:BoundColumn Visible="False" DataField="POPLANDATE" ReadOnly="True" HeaderText="">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
								
									<asp:TemplateColumn HeaderText="PLAN DATE">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "POPLANDATE") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									<asp:BoundColumn Visible="False" DataField="VENDORS_ANALYSED" ReadOnly="True" HeaderText="">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									
									<asp:TemplateColumn HeaderText="VENDORS_ANALYSED" >
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "VENDORS_ANALYSED") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									<asp:BoundColumn Visible="False" DataField="ANALYSISBY" ReadOnly="True" HeaderText="">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									
									<asp:TemplateColumn HeaderText="ANALYSISBY">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "ANALYSISBY") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									<asp:EditCommandColumn ButtonType="LinkButton" EditText="View">
										<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
									</asp:EditCommandColumn>
								</Columns>
							</asp:datagrid>
							<asp:label id="lblTotal" runat="server" Font-Bold="True" CssClass="FormMessages"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</BODY>
</HTML>
