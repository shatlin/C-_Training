<%@ Page language="c#" Codebehind="PVPALADD.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPALADD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Add Pallette</TITLE>
		<META CONTENT="Microsoft Visual Studio .NET 7.1" NAME="GENERATOR">
		<META CONTENT="C#" NAME="CODE_LANGUAGE">
		<META CONTENT="JavaScript" NAME="vs_defaultClientScript">
		<META CONTENT="http://schemas.microsoft.com/intellisense/ie5" NAME="vs_targetSchema">
		<SCRIPT LANGUAGE="JavaScript" SRC="MENU_OUTBOUND.js" TYPE="text/javascript"></SCRIPT>
		<SCRIPT LANGUAGE="JavaScript" SRC="mmenu.js" TYPE="text/javascript"></SCRIPT>
		<LINK HREF="PVMODSTYLES.CSS" TYPE="text/css" REL="STYLESHEET">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM ID="Form1" METHOD="post" RUNAT="server">
			<H2 CLASS="h2head">Add Pallette</H2>
			<BR>
			<TABLE CLASS="sofT" CELLSPACING="0" CELLPADDING="0" WIDTH="747" ALIGN="center" BORDER="0"
				style="WIDTH: 747px; HEIGHT: 144px">
				<TR>
					<TD CLASS="helpHed" ALIGN="left" COLSPAN="4">Pallette Details</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD COLSPAN="4">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="123" style="WIDTH: 123px; HEIGHT: 16px">
						<ASP:LABEL ID="lblPalletteType" RUNAT="server" CSSCLASS="FormLabels">Type</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="266" style="WIDTH: 266px; HEIGHT: 16px">&nbsp;<span class="FormTextBoxes">&nbsp;
							<ASP:DROPDOWNLIST ID="CboPalletteType" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
								<ASP:LISTITEM VALUE="E">Export</ASP:LISTITEM>
								<ASP:LISTITEM VALUE="L">Local</ASP:LISTITEM>
							</ASP:DROPDOWNLIST></span>
					</TD>
					<TD ALIGN="right" WIDTH="199" style="WIDTH: 199px; HEIGHT: 16px"><ASP:LABEL ID="lblDodaacSpl" RUNAT="server" CSSCLASS="FormLabels">DODAAC Spl	</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 16px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboDodaacSpl" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
							
						</ASP:DROPDOWNLIST></TD>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="123" style="WIDTH: 123px; HEIGHT: 18px"><ASP:LABEL ID="lblCntrSize" RUNAT="server" CSSCLASS="FormLabels">Container Size</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="266" style="WIDTH: 266px; HEIGHT: 18px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboCntrSize" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes" AutoPostBack="True">
							<asp:ListItem Value="20">20</asp:ListItem>
							<asp:ListItem Value="40">40</asp:ListItem>
							<asp:ListItem Value="O">Other</asp:ListItem>
						</ASP:DROPDOWNLIST>
						<ASP:TEXTBOX id="txtOther" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" Visible="False"></ASP:TEXTBOX></TD>
					<TD ALIGN="right" WIDTH="199" style="WIDTH: 199px; HEIGHT: 18px"><ASP:LABEL ID="lblCntrType" RUNAT="server" CSSCLASS="FormLabels">Container Type</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 18px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboCntrType" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
							<ASP:LISTITEM VALUE="F">Frozen</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="D">Dry</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="C">Chilled</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="123" style="WIDTH: 123px; HEIGHT: 1px"><ASP:LABEL ID="lblMaxPallettes" RUNAT="server" CSSCLASS="FormLabels">Maximum Pallettes</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="266" style="WIDTH: 266px; HEIGHT: 1px">&nbsp;&nbsp;<ASP:TEXTBOX ID="txtMaxPallettes" RUNAT="server" WIDTH="120px" CSSCLASS="FormTextBoxes"></ASP:TEXTBOX>
					<ASP:REQUIREDFIELDVALIDATOR ID="Requiredfieldvalidator6" RUNAT="server" CONTROLTOVALIDATE="txtMaxPallettes"
							DISPLAY="Dynamic" ERRORMESSAGE="*" CSSCLASS="FormErrorMessages"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD ALIGN="right" WIDTH="199" style="WIDTH: 199px; HEIGHT: 1px">
						<ASP:LABEL ID="lblStatus" RUNAT="server" CSSCLASS="FormLabels">Status</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 1px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboStatus" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
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
					<TD ALIGN="center" COLSPAN="4" style="HEIGHT: 19px"><ASP:BUTTON ID="cmdSave" RUNAT="server" TEXT="Save" CSSCLASS="FormButtons"></ASP:BUTTON>&nbsp;
						<ASP:BUTTON ID="cmdCancel" RUNAT="server" TEXT="Cancel" CSSCLASS="FormButtons" CausesValidation=False ></ASP:BUTTON></TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="left" COLSPAN="4"><ASP:LABEL ID="lblError" RUNAT="server" WIDTH="350px" CSSCLASS="FormErrorMessages"></ASP:LABEL></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
