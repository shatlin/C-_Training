<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" %>
<%@ Page language="c#" Codebehind="caltest.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.caltest"  culture="en-GB"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CR:CRYSTALREPORTVIEWER id="CrystalReportViewer1" style="Z-INDEX: 101; LEFT: 88px; POSITION: absolute; TOP: 192px"
				runat="server" Width="350px" Height="50px"></CR:CRYSTALREPORTVIEWER>
			<ew:CalendarPopup id="calendarPopup1" runat="server" ControlDisplay="TextboxImage" Text="..." style="Z-INDEX: 102; LEFT: 264px; POSITION: absolute; TOP: 56px"
				Width="104px" ImageUrl="IMAGES/cal.gif">
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
			</ew:CalendarPopup>
		</form>
	</body>
</HTML>
