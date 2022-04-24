<%@ Register TagPrefix="ew" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" %>
<%@ Page language="c#" Codebehind="PVASNETA.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVASNETA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVASNETA</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H2 class="h2head">ASN ETA Update</H2>
			<ASP:LABEL id="lblError" Width="500px" CSSCLASS="FormErrorMessages" RUNAT="server"></ASP:LABEL>
			<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD style="HEIGHT: 22px"><asp:datagrid id="dgResults" runat="server" Width="100%" Visible="True" Height="23px" BorderColor="Gray"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
							AllowPaging="false" OnEditCommand="dgResults_OnEditCommand" CssClass="FormDataGrids" OnUpdateCommand="dgResults_OnUpdateCommand"
							OnCancelCommand="dgResults_OnCancelCommand">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="asn_no" ReadOnly="True" HeaderText="asn_no">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="sail_date" ReadOnly="True" HeaderText="sail_date">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ASN #">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "asn_no") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Supplier">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vendor_dispname") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Container #">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "cntr_no") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Container Type">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "cntr_type") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Vessel">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "vessel") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Port of Departure">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "port_disp") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Port of Arrival">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "port_arrv") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sail Date">
									<ItemTemplate>
										<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "sail_date")).ToString("dd-MMM-yyyy") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ETA">
									<ItemTemplate>
										<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "eta")).ToString("dd-MMM-yyyy") %>
									</ItemTemplate>
									<EditItemTemplate>
										<span class="FormTextBoxes">
											<ew:CalendarPopup id="etaDate" runat="server" ControlDisplay="TextboxImage" Text="..." Width="88px" ImageUrl="IMAGES/cal.gif" Height="19px" Culture="English (United Kingdom)" SelectedDate='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "eta")) %>'>
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
										</span>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Inv #">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "inv_no") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" EditText="Edit" UpdateText="Update" CancelText="Cancel">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Bottom"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td align="left">
						<ASP:LABEL id="lblTotalASN" Width="120px" RUNAT="server" CSSCLASS="FormLabels"></ASP:LABEL></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
