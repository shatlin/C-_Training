<%@ Page language="c#" Codebehind="PVCASEADD.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVCASEADD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML> 
	<HEAD>
		<TITLE>Add Case</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_outbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" RUNAT="server">
			<H2 class="h2head">Add Case</H2>
			<BR>
			<TABLE class="sofT" style="HEIGHT: 144px" cellSpacing="0" cellPadding="0" width="800" align="center"
				border="0">
				<TR>
					<TD class="helpHed" align="left" colSpan="4">Case&nbsp;Details</TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD colSpan="4">&nbsp;</TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD style="WIDTH: 175px; HEIGHT: 8px" align="right" width="175"><ASP:LABEL id="lblPalletteType" RUNAT="server" CSSCLASS="FormLabels">Type</ASP:LABEL></TD>
					<TD style="WIDTH: 522px; HEIGHT: 8px" align="left" width="522">&nbsp;<span class="FormTextBoxes">&nbsp;
							<ASP:DROPDOWNLIST id="CboPalletteType" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px">
								<ASP:LISTITEM VALUE="E">Export</ASP:LISTITEM>
								<ASP:LISTITEM VALUE="L">Local</ASP:LISTITEM>
							</ASP:DROPDOWNLIST></span></TD>
					<TD style="WIDTH: 199px; HEIGHT: 8px" align="right" width="199"><ASP:LABEL id="lblDodaacSpl" RUNAT="server" CSSCLASS="FormLabels">DODAAC Spl	</ASP:LABEL></TD>
					<TD style="HEIGHT: 8px" align="left" width="150">&nbsp;
						<ASP:DROPDOWNLIST id="CboDodaacSpl" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px">
							<ASP:LISTITEM VALUE="N">Normal</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="K">Kandahaar</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD></TR>
				<TR bgColor="#d2e4fc">
					<TD style="WIDTH: 175px; HEIGHT: 18px" align="right" width="175"><ASP:LABEL id="lblCntrSize" RUNAT="server" CSSCLASS="FormLabels">Container Size</ASP:LABEL></TD>
					<TD style="WIDTH: 522px; HEIGHT: 18px" align="left" width="522">&nbsp;
						<ASP:DROPDOWNLIST id="CboCntrSize" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px" AutoPostBack="True">
							<asp:ListItem Value="20">20</asp:ListItem>
							<asp:ListItem Value="40">40</asp:ListItem>
							<asp:ListItem Value="O">Other</asp:ListItem>
						</ASP:DROPDOWNLIST><ASP:TEXTBOX id="txtOther" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" Visible="False"></ASP:TEXTBOX></TD>
					<TD style="WIDTH: 199px; HEIGHT: 18px" align="right" width="199"><ASP:LABEL id="lblCntrType" RUNAT="server" CSSCLASS="FormLabels">Container Type</ASP:LABEL></TD>
					<TD style="HEIGHT: 18px" align="left" width="150">&nbsp;
						<ASP:DROPDOWNLIST id="CboCntrType" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px">
							<ASP:LISTITEM VALUE="F">Frozen</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="D">Dry</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="C">Chilled</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD></TR>
				<TR bgColor="#d2e4fc">
					<TD style="WIDTH: 175px; HEIGHT: 1px" align="right" width="175"><ASP:LABEL id="lblMaxPallettes" RUNAT="server" CSSCLASS="FormLabels">Maximum Cases</ASP:LABEL></TD>
					<TD style="WIDTH: 522px; HEIGHT: 1px" align="left" width="522">&nbsp;&nbsp;<ASP:TEXTBOX id="txtMaxCases" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX>
						<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator6" RUNAT="server" CSSCLASS="FormErrorMessages" CONTROLTOVALIDATE="txtMaxCases"
							DISPLAY="Dynamic" ERRORMESSAGE="*"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD style="WIDTH: 199px; HEIGHT: 1px" align="right" width="199"><ASP:LABEL id="lblStatus" RUNAT="server" CSSCLASS="FormLabels">Status</ASP:LABEL></TD>
					<TD style="HEIGHT: 1px" align="left" width="150">&nbsp;
						<ASP:DROPDOWNLIST id="CboStatus" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px">
							<ASP:LISTITEM VALUE="O">Active</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="C">Inactive</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD></TR>
				<TR bgColor="#d2e4fc">
					<TD style="WIDTH: 175px; HEIGHT: 20px" align="right" width="175"><ASP:LABEL id="lblPalLength" RUNAT="server" CSSCLASS="FormLabels">Pal_Length</ASP:LABEL></TD>
					<TD style="WIDTH: 522px; HEIGHT: 20px" align="left" width="522">&nbsp;
						<ASP:TEXTBOX id="txtPalLength" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX>&nbsp;<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator1" RUNAT="server" CSSCLASS="FormErrorMessages" CONTROLTOVALIDATE="txtPalLength"
							DISPLAY="Dynamic" ERRORMESSAGE="*"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD style="HEIGHT: 20px" align="right" width="450"><ASP:LABEL id="lblPalWidth" RUNAT="server" CSSCLASS="FormLabels">Pal_Width</ASP:LABEL></TD>
					<TD style="HEIGHT: 20px" align="left" width="450" colSpan="3">&nbsp;
						<ASP:TEXTBOX id="txtPalWidth" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX>&nbsp;
						<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator2" RUNAT="server" CSSCLASS="FormErrorMessages" CONTROLTOVALIDATE="txtPalWidth"
							DISPLAY="Dynamic" ERRORMESSAGE="*"></ASP:REQUIREDFIELDVALIDATOR></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD style="WIDTH: 175px; HEIGHT: 20px" align="right" width="175"><ASP:LABEL id="lblPalHeight" RUNAT="server" CSSCLASS="FormLabels">Pal_Height</ASP:LABEL></TD>
					<TD style="WIDTH: 522px; HEIGHT: 20px" align="left" width="522">&nbsp;
						<ASP:TEXTBOX id="txtPalHeight" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX>&nbsp;
						<ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator3" RUNAT="server" CSSCLASS="FormErrorMessages" CONTROLTOVALIDATE="txtPalHeight"
							DISPLAY="Dynamic" ERRORMESSAGE="*"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD style="HEIGHT: 20px" align="left" width="450"></TD>
					<TD style="HEIGHT: 20px" align="left" width="450" colSpan="3"></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD style="HEIGHT: 19px" align="center" colSpan="4"><ASP:BUTTON id="cmdSave" RUNAT="server" CSSCLASS="FormButtons" TEXT="Save"></ASP:BUTTON>&nbsp;
						<ASP:BUTTON id="cmdCancel" RUNAT="server" CSSCLASS="FormButtons" TEXT="Cancel" CausesValidation =False ></ASP:BUTTON></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="left" colSpan="4"><ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages" WIDTH="350px"></ASP:LABEL></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
