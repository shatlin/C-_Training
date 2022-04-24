<%@ Page language="c#" Codebehind="PVCOSTVIEW.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVCOSTVIEW" %>
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
	</HEAD>
	<BODY>
		<h2 class="h2head">View/Delete Cost</h2>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<form id="Form1" runat="server">
			<TABLE class="sofT" id="Table1" width="300" align="center" border="0">
				<TR>
					<TD class="helphed" colSpan="2">Select&nbsp;Cost Updated Date</TD>
				</TR>
				<TR>
					<TD class="borderlesstitle" style="WIDTH: 124px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblDateFrom" runat="server">From</asp:label></TD>
					<TD class="borderlesstitle" align="left" height="25">
						<P align="left"><ew:calendarpopup id="calendarPopup1" runat="server" Text="..." ControlDisplay="TextboxImage" Width="104px"
								ImageUrl="IMAGES/cal.gif" Culture="English (United Kingdom)" DayNameFormat="Short">
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
						<P align="left"><ew:calendarpopup id="CalendarPopup2" runat="server" Text="..." ControlDisplay="TextboxImage" Width="104px"
								ImageUrl="IMAGES/cal.gif" Culture="English (United Kingdom)" DayNameFormat="Short">
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
						<P align="left"><asp:button id="btnViewCost" runat="server" Text="View" CssClass="FormButtons"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
			<br>
			<asp:panel id="costpnl" runat="server" Visible="False">
				<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD class="helpHed" align="left" colSpan="4" height="15">Cost&nbsp;Details</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:datagrid id="DataGrid2" runat="server" Width="100%" CssClass="FormDataGrids" Visible="True"
								Height="23px" BorderColor="Gray" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"
								AutoGenerateColumns="False" AllowPaging="false" OnItemDataBound="DataGrid2_ItemDataBound"
								OnEditCommand="DataGrid2_OnEditCommand" BackColor="White">
								<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
								<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
								<HeaderStyle CssClass="gridHeader"></HeaderStyle>
								<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="vendor_id" ReadOnly="True" HeaderText="id">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Supplier Code">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "vendor_code") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Supplier Name">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "vendor_name") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="update_date" ReadOnly="True" HeaderText="updatedate">
										<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Cost Update Date">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "update_date") %>
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
