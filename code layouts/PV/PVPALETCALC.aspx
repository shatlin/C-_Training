<%@ Page language="c#" Codebehind="PVPALETCALC.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPALETCALC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Select Orders</TITLE>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
			<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
			<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
	</HEAD>
	<body>
		<H2 class="h2head">
			Pallette Calculation</H2>
		<FORM name="Form1" runat="server" ID="Form1">
			<P>
				<TABLE class="sofT" id="tblOrder" cellSpacing="0" cellPadding="0" width="50%" align="center"
					border="1">
					<TR>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>
							<ASP:LABEL id="lblOrder" CSSCLASS="FormLabels" RUNAT="server">Order #</ASP:LABEL>&nbsp;
							<ASP:TEXTBOX id="txtOrderNo" CSSCLASS="FormTextBoxes" RUNAT="server" WIDTH="100px" MAXLENGTH="10"></ASP:TEXTBOX>&nbsp;
							<ASP:BUTTON id="cmdView" CSSCLASS="FormButtons" TEXT="View" RUNAT="server"></ASP:BUTTON></TD>
					</TR>
					<TR>
						<TD align="left">
							<ASP:LABEL id="lblError" Width="350px" CSSCLASS="FormErrorMessages" RUNAT="server"></ASP:LABEL></TD>
					</TR>
				</TABLE>
			</P>
			<P>&nbsp;</P>
			<P>
				<TABLE id="tblMaster" cellSpacing="0" cellPadding="3" width="846" align="center" border="0"
					style="WIDTH: 846px; HEIGHT: 120px">
					<TR align="left" bgColor="#f3f8fe">
						<TD width="143">
							<ASP:LABEL id="lblOrderNo" CSSCLASS="FormLabels" RUNAT="server">Order #</ASP:LABEL></TD>
						<TD width="379">
							<ASP:LABEL id="OrderNo" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
						<TD width="99">
							<ASP:LABEL id="lblCustomer" CSSCLASS="FormLabels" RUNAT="server">Customer</ASP:LABEL></TD>
						<TD width="379">
							<ASP:LABEL id="Customer" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
					</TR>
					<TR align="left" bgColor="#f3f8fe">
						<TD width="143" height="22">
							<ASP:LABEL id="lblTotalWeight" CSSCLASS="FormLabels" RUNAT="server">Total Weight  [ LB ]</ASP:LABEL></TD>
						<TD width="379" height="22">
							<ASP:LABEL id="Weight" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
						<TD width="99" height="22">
							<ASP:LABEL id="lblDateEntered" CSSCLASS="FormLabels" RUNAT="server">Date Entered</ASP:LABEL></TD>
						<TD width="379" height="22">
							<ASP:LABEL id="DateEntered" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
					</TR>
					<TR align="left" bgColor="#f3f8fe">
						<TD width="143" height="22">
							<ASP:LABEL id="lblDateReceived" CSSCLASS="FormLabels" RUNAT="server">Total Cases</ASP:LABEL></TD>
						<TD width="379" height="22">
							<ASP:LABEL id="TotalCases" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
						<TD width="99" height="22">
							<ASP:LABEL id="lblDateRequired" CSSCLASS="FormLabels" RUNAT="server">Date Required</ASP:LABEL></TD>
						<TD width="379" height="22">
							<ASP:LABEL id="DateRequired" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
					</TR>
					<TR align="left" bgColor="#f3f8fe">
						<TD width="143" height="25">
							<ASP:LABEL id="lblPallettesRequired" CSSCLASS="FormLabels" RUNAT="server">Total Pallettes</ASP:LABEL></TD>
						<TD width="379" height="25">
							<ASP:LABEL id="TotalPallettes" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
						<TD width="99" height="25"></TD>
						<TD width="379" height="25"></TD>
					</TR>
					<TR align="left" bgColor="#f3f8fe">
						<TD width="143">
							<ASP:LABEL id="lblContainersRequired" CSSCLASS="FormLabels" RUNAT="server">Total Containers</ASP:LABEL></TD>
						<TD width="379">
							<ASP:LABEL id="totalcontainers" CSSCLASS="FormTextBoxes" RUNAT="server"></ASP:LABEL></TD>
						<TD width="99"></TD>
						<TD width="379"></TD>
					</TR>
					<TR bgColor="#f3f8fe">
						<TD width="143"></TD>
						<TD width="379"></TD>
						<TD width="99"></TD>
						<TD width="379"></TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#f3f8fe" colspan="4">&nbsp;
							<ASP:BUTTON id="cmdPrint" Visible="true" CSSCLASS="FormButtons" TEXT="Print" RUNAT="server"></ASP:BUTTON></TD>
					</TR>
				</TABLE>
			</P>
		</FORM>
	</body>
</HTML>
