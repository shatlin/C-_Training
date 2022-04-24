<%@ Page language="c#" Codebehind="PVPALDODADD.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPALDODADD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD> 
		<TITLE>ADD Dodaac Pallette</TITLE>
		<META CONTENT="Microsoft Visual Studio .NET 7.1" NAME="GENERATOR">
		<META CONTENT="C#" NAME="CODE_LANGUAGE">
		<META CONTENT="JavaScript" NAME="vs_defaultClientScript">
		<META CONTENT="http://schemas.microsoft.com/intellisense/ie5" NAME="vs_targetSchema">
		<SCRIPT LANGUAGE="JavaScript" SRC="menu_outbound.js" TYPE="text/javascript"></SCRIPT>
		<SCRIPT LANGUAGE="JavaScript" SRC="mmenu.js" TYPE="text/javascript"></SCRIPT>
		<LINK HREF="PVMODSTYLES.CSS" TYPE="text/css" REL="STYLESHEET">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM ID="Form1" METHOD="post" RUNAT="server">
			<H2 CLASS="h2head">ADD Dodaac Pallette</H2>
			<BR>
			<TABLE CLASS="sofT" CELLSPACING="0" CELLPADDING="0" WIDTH="747" ALIGN="center" BORDER="0"
				style="WIDTH: 747px; HEIGHT: 144px">
				<TR>
					<TD CLASS="helpHed" ALIGN="left" COLSPAN="4">Dodaac&nbsp;Special&nbsp;Details</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD COLSPAN="4">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="123" style="WIDTH: 123px; HEIGHT: 20px">
						<ASP:LABEL ID="lblDodaacName" RUNAT="server" CSSCLASS="FormLabels">Dodaac Name</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="266" style="WIDTH: 266px; HEIGHT: 20px">&nbsp; <span class="FormTextBoxes">
							<ASP:TEXTBOX id="txtDodaacName" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MaxLength="10"></ASP:TEXTBOX>&nbsp;
						</span>
						<ASP:REQUIREDFIELDVALIDATOR ID="Requiredfieldvalidator6" RUNAT="server" CONTROLTOVALIDATE="txtDodaacName" DISPLAY="Dynamic"
							ERRORMESSAGE="*" CSSCLASS="FormErrorMessages"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD ALIGN="right" WIDTH="199" style="WIDTH: 199px; HEIGHT: 20px"><ASP:LABEL ID="lblDodaacSpl" RUNAT="server" CSSCLASS="FormLabels">DODAAC Spl	</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 20px">&nbsp;
						<ASP:TEXTBOX id="txtDodaacSpl" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MaxLength="1"></ASP:TEXTBOX>&nbsp;
						<ASP:REQUIREDFIELDVALIDATOR ID="Requiredfieldvalidator1" RUNAT="server" CONTROLTOVALIDATE="txtDodaacSpl" DISPLAY="Dynamic"
							ERRORMESSAGE="*" CSSCLASS="FormErrorMessages"></ASP:REQUIREDFIELDVALIDATOR>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="123" style="WIDTH: 123px; HEIGHT: 18px">
						<ASP:LABEL id="lblDisplayName" RUNAT="server" CSSCLASS="FormLabels"> Display Name</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="266" style="WIDTH: 266px; HEIGHT: 18px">&nbsp;
						<ASP:TEXTBOX id="txtDodaacDispName" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MaxLength="20"></ASP:TEXTBOX>&nbsp;
						<ASP:REQUIREDFIELDVALIDATOR ID="Requiredfieldvalidator2" RUNAT="server" CONTROLTOVALIDATE="txtDodaacDispName"
							DISPLAY="Dynamic" ERRORMESSAGE="*" CSSCLASS="FormErrorMessages"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD ALIGN="right" WIDTH="199" style="WIDTH: 199px; HEIGHT: 18px">
						<ASP:LABEL id="lblStatus" RUNAT="server" CSSCLASS="FormLabels">Status</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 18px">&nbsp;
						<ASP:DROPDOWNLIST id="CboStatus" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px">
							<ASP:LISTITEM VALUE="O">Active</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="C">Inactive</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD STYLE="WIDTH: 123px; HEIGHT: 20px" ALIGN="right" WIDTH="123"></TD>
					<TD STYLE="HEIGHT: 20px" ALIGN="left" WIDTH="450" COLSPAN="3">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="center" COLSPAN="4" style="HEIGHT: 19px">
					<ASP:BUTTON ID="cmdSave" RUNAT="server" TEXT="Save" CSSCLASS="FormButtons"></ASP:BUTTON>&nbsp;
					<ASP:BUTTON ID="cmdCancel" RUNAT="server" TEXT="Cancel" CSSCLASS="FormButtons" CausesValidation =False ></ASP:BUTTON></TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="left" COLSPAN="4"><ASP:LABEL ID="lblError" RUNAT="server" WIDTH="350px" CSSCLASS="FormErrorMessages"></ASP:LABEL></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
