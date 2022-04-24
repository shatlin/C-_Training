<%@ Page language="c#" Codebehind="addpal.aspx.cs" AutoEventWireup="false" Inherits="PV.addpal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Add Pallette</TITLE>
		<META CONTENT="Microsoft Visual Studio .NET 7.1" NAME="GENERATOR">
		<META CONTENT="C#" NAME="CODE_LANGUAGE">
		<META CONTENT="JavaScript" NAME="vs_defaultClientScript">
		<META CONTENT="http://schemas.microsoft.com/intellisense/ie5" NAME="vs_targetSchema">
		<SCRIPT LANGUAGE="JavaScript" SRC="menu_array.js" TYPE="text/javascript"></SCRIPT>
		<SCRIPT LANGUAGE="JavaScript" SRC="mmenu.js" TYPE="text/javascript"></SCRIPT>
		<LINK HREF="PVMODSTYLES.CSS" TYPE="text/css" REL="STYLESHEET">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM ID="Form1" METHOD="post" RUNAT="server">
			<H2 CLASS="h2head">Add Pallette</H2>
			<BR>
			<TABLE CLASS="sofT" CELLSPACING="0" CELLPADDING="0" WIDTH="600" ALIGN="center" BORDER="0">
				<TR>
					<TD CLASS="helpHed" ALIGN="left" COLSPAN="4">Pallette Details</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD COLSPAN="4">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="150" style="HEIGHT: 16px">
						<ASP:LABEL ID="lblPalletteType" RUNAT="server" CSSCLASS="FormLabels">
							Type
						</ASP:LABEL>
					</TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 16px">&nbsp;
						<ASP:TEXTBOX ID="txtPalletteType" RUNAT="server" MAXLENGTH="1" WIDTH="120px" CSSCLASS="FormTextBoxes"></ASP:TEXTBOX>
						<ASP:REQUIREDFIELDVALIDATOR ID="Requiredfieldvalidator7" RUNAT="server" CONTROLTOVALIDATE="txtPalletteType"
							DISPLAY="Dynamic" ERRORMESSAGE="*" CSSCLASS="FormErrorMessages"></ASP:REQUIREDFIELDVALIDATOR></TD>
					</TD>
					<TD ALIGN="right" WIDTH="150" style="HEIGHT: 16px">
						<ASP:LABEL ID="lblDodaacSpl" RUNAT="server" CSSCLASS="FormLabels">
							DODAAC Spl
						</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 16px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboDodaacSpl" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
							<ASP:LISTITEM VALUE="E">Export</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="L">Local</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="N">Normal</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="K">Kandahaar</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="150" style="HEIGHT: 20px"><ASP:LABEL ID="lblCntrSize" RUNAT="server" CSSCLASS="FormLabels">Size</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 20px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboCntrSize" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
							<ASP:LISTITEM VALUE="20">20 ft</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="40">40 ft</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="N">Other</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD>
					<TD ALIGN="right" WIDTH="150" style="HEIGHT: 20px"><ASP:LABEL ID="lblCntrType" RUNAT="server" CSSCLASS="FormLabels">Type</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 20px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboCntrType" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
							<ASP:LISTITEM VALUE="F">Frozen</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="D">Dry</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="C">Chilled</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="right" WIDTH="150" style="HEIGHT: 1px"><ASP:LABEL ID="lblMaxPallettes" RUNAT="server" CSSCLASS="FormLabels">Maximum Pallettes</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 1px">&nbsp;<ASP:TEXTBOX ID="txtMaxPallettes" RUNAT="server" WIDTH="120px" CSSCLASS="FormTextBoxes"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR ID="Requiredfieldvalidator6" RUNAT="server" CONTROLTOVALIDATE="txtMaxPallettes"
							DISPLAY="Dynamic" ERRORMESSAGE="*" CSSCLASS="FormErrorMessages"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD ALIGN="right" WIDTH="150" style="HEIGHT: 1px"><ASP:LABEL ID="lblStatus" RUNAT="server" CSSCLASS="FormLabels">Status</ASP:LABEL></TD>
					<TD ALIGN="left" WIDTH="150" style="HEIGHT: 1px">&nbsp;
						<ASP:DROPDOWNLIST ID="CboStatus" RUNAT="server" WIDTH="120px" CSSCLASS="FormComboBoxes">
							<ASP:LISTITEM VALUE="O">Active</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="C">Inactive</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD STYLE="HEIGHT: 20px" ALIGN="right" WIDTH="150"></TD>
					<TD STYLE="HEIGHT: 20px" ALIGN="left" WIDTH="450" COLSPAN="3">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="center" COLSPAN="4" style="HEIGHT: 19px"><ASP:BUTTON ID="cmdSave" RUNAT="server" TEXT="Save" CSSCLASS="FormButtons"></ASP:BUTTON>&nbsp;
						<ASP:BUTTON ID="cmdCancel" RUNAT="server" TEXT="Cancel" CSSCLASS="FormButtons"></ASP:BUTTON></TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="left" COLSPAN="4"><ASP:LABEL ID="lblError" RUNAT="server" WIDTH="350px" CSSCLASS="FormErrorMessages"></ASP:LABEL></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
