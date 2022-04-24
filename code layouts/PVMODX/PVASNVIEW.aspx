<%@ Page language="c#" Codebehind="PVASNVIEW.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVASNVIEW" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<BODY>
		<h2 class="h2head">View/Delete ASN</h2>
		<form id="Form1" runat="server">
			<TABLE class="sofT" id="Table1" width="300" align="center" border="0">
				<TR>
					<TD class="helphed" colSpan="2">Select&nbsp;The ASN Uploaded Date</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblDateFrom" runat="server">From</asp:label></TD>
					<TD class="borderlesstitle" align="left">
						<P align="left"><ew:calendarpopup id="calendarPopup1" runat="server" DayNameFormat="Short" Culture="English (United Kingdom)"
								ImageUrl="IMAGES/cal.gif" Width="104px" ControlDisplay="TextboxImage" Text="...">
								<WeekdayStyle Font-Size="8pt" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="#F3F8FE"></WeekdayStyle>
								<MonthHeaderStyle Font-Size="11pt" Font-Bold="True" ForeColor="White" BackColor="#6699CC"></MonthHeaderStyle>
								<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black" BackColor="Linen"></OffMonthStyle>
								<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></GoToTodayStyle>
								<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BorderColor="Red" BackColor="#99CCFF"></TodayDayStyle>
								<DayHeaderStyle ForeColor="Black" CssClass="caldays" BackColor="#D2E4FC"></DayHeaderStyle>
								<WeekendStyle Font-Size="8pt" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="#F3F8FE"></WeekendStyle>
								<SelectedDateStyle Font-Size="XX-Small" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="#99CCFF"></SelectedDateStyle>
								<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></ClearDateStyle>
								<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></HolidayStyle>
							</ew:calendarpopup></P>
					</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px" align="right" width="124">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblDateTo" runat="server">To</asp:label></TD>
					<TD class="borderlesstitle" align="left">
						<P align="left"><ew:calendarpopup id="CalendarPopup2" runat="server" DayNameFormat="Short" Culture="English (United Kingdom)"
								ImageUrl="IMAGES/cal.gif" Width="104px" ControlDisplay="TextboxImage" Text="...">
								<WeekdayStyle Font-Size="8pt" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="#F3F8FE"></WeekdayStyle>
								<MonthHeaderStyle Font-Size="11pt" Font-Bold="True" ForeColor="White" BackColor="#6699CC"></MonthHeaderStyle>
								<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black" BackColor="Linen"></OffMonthStyle>
								<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></GoToTodayStyle>
								<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BorderColor="Red" BackColor="#99CCFF"></TodayDayStyle>
								<DayHeaderStyle ForeColor="Black" CssClass="caldays" BackColor="#D2E4FC"></DayHeaderStyle>
								<WeekendStyle Font-Size="8pt" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="#F3F8FE"></WeekendStyle>
								<SelectedDateStyle Font-Size="XX-Small" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black" BackColor="#99CCFF"></SelectedDateStyle>
								<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></ClearDateStyle>
								<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
									BackColor="White"></HolidayStyle>
							</ew:calendarpopup></P>
					</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px" width="124"></TD>
					<TD class="borderlesstitle" align="center">
						<P align="left"><asp:button id="btnViewAsn" runat="server" Text="View" CssClass="FormButtons"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
			<br>
			<asp:panel id="asnpnl" runat="server" Visible="False">
				<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD class="helpHed" align="left" colSpan="4" height="15">ASN Details</TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:datagrid id="DataGrid2" runat="server" Width="100%" CssClass="FormDataGrids" Visible="True"
								BackColor="White" OnEditCommand="DataGrid2_OnEditCommand" OnItemDataBound="DataGrid2_ItemDataBound"
								AllowPaging="false" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BorderWidth="1px"
								BorderStyle="None" BorderColor="Gray" Height="23px">
								<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
								<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
								<HeaderStyle CssClass="gridHeader"></HeaderStyle>
								<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ASN_NO" ReadOnly="True" HeaderText="ID">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="DATE">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "ASN_DATE") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="ASN NO">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "ASN_NO") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="TCN">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "tcn_no") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="CONTAINER">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "CNTR_NO") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="CNTR TYPE">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "CNTR_TYPE") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="VESSEL">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "VESSEL") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="SAIL DATE">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "SAIL_DATE") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="ETA">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "ETA") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="INVOICE">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "INV_NO") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="INVOICE DATE">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "INV_DATE") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" EditText="View">
										<ItemStyle VerticalAlign="Bottom" HorizontalAlign="Right"></ItemStyle>
									</asp:EditCommandColumn>
								</Columns>
							</asp:datagrid>
							<asp:label id="lblTotal" runat="server" CssClass="FormMessages" Font-Bold="True"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</BODY>
</HTML>
