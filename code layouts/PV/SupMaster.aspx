<%@ Page language="c#" Codebehind="SupMaster.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.SupMaster" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>WebForm1</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" RUNAT="server">
			<H2 class="h2head">Add Supplier</H2>
			<TABLE class="sofT" cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TR>
					<TD class="helpHed" align="left" colSpan="4">Enter Supplier Details</TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD colSpan="4">&nbsp;</TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="right" width="150"><ASP:LABEL id="Label1" RUNAT="server" CSSCLASS="FormLabels">Vendor</ASP:LABEL></TD>
					<TD align="left" width="450" colSpan="3">&nbsp;<ASP:DROPDOWNLIST id="cboVendorCode" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="420px" AutoPostBack="True"></ASP:DROPDOWNLIST></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="right" width="150"><ASP:LABEL id="lblVendorCode" RUNAT="server" CSSCLASS="FormLabels">Code</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtVendorCode" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MAXLENGTH="10"
							ReadOnly="True"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator7" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtVendorCode"></ASP:REQUIREDFIELDVALIDATOR>
					</TD>
					</TD>
					<TD align="right" width="150"><ASP:LABEL id="lblVendorType" RUNAT="server" CSSCLASS="FormLabels">Type</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:DROPDOWNLIST id="cboVendorType" RUNAT="server" CSSCLASS="FormComboBoxes" WIDTH="120px">
							<ASP:LISTITEM VALUE="A">Automatic</ASP:LISTITEM>
							<ASP:LISTITEM VALUE="M">Manual</ASP:LISTITEM>
						</ASP:DROPDOWNLIST></TD>
					</TD></TR>
				<TR bgColor="#d2e4fc">
					<TD align="right" width="150"><ASP:LABEL id="lblVendorName" RUNAT="server" CSSCLASS="FormLabels">Name</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtVendorName" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MAXLENGTH="40"
							ReadOnly="True"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="RequiredFieldValidator1" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtVendorName"></ASP:REQUIREDFIELDVALIDATOR></TD>
					</TD>
					<TD align="right" width="150"><ASP:LABEL id="lblVendorDispName" RUNAT="server" CSSCLASS="FormLabels" WIDTH="102px">Display Name</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtVendorDispName" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MAXLENGTH="10"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator2" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtVendorDispName"></ASP:REQUIREDFIELDVALIDATOR></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="right" width="150"><ASP:LABEL id="lblETAAccuracy" RUNAT="server" CSSCLASS="FormLabels">ETA Accuracy</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtETAAccuracy" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator6" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtETAAccuracy"></ASP:REQUIREDFIELDVALIDATOR></TD>
					<TD align="right" width="150"><ASP:LABEL id="lblShPlanAccuracy" RUNAT="server" CSSCLASS="FormLabels" WIDTH="130px">Shipping Plan Accuracy</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtShPlanAccuracy" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator5" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtShPlanAccuracy"></ASP:REQUIREDFIELDVALIDATOR></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="right" width="150"><ASP:LABEL id="lblLeadTime" RUNAT="server" CSSCLASS="FormLabels">Lead Time</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtLeadTime" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator3" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtLeadTime"></ASP:REQUIREDFIELDVALIDATOR>
					</TD>
					<TD align="right" width="150"><ASP:LABEL id="lblLeadTimeVar" RUNAT="server" CSSCLASS="FormLabels" WIDTH="110px">Lead Time Variance</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtLeadTimeVar" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px"></ASP:TEXTBOX><ASP:REQUIREDFIELDVALIDATOR id="Requiredfieldvalidator4" RUNAT="server" CSSCLASS="FormErrorMessages" ERRORMESSAGE="*"
							DISPLAY="Dynamic" CONTROLTOVALIDATE="txtLeadTimeVar"></ASP:REQUIREDFIELDVALIDATOR>
					</TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="right" width="150"><ASP:LABEL id="lblContact" RUNAT="server" CSSCLASS="FormLabels">Contact Name</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtContact" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MAXLENGTH="40"></ASP:TEXTBOX></TD>
					</TD>
					<TD align="right" width="150"><ASP:LABEL id="lblContactFax" RUNAT="server" CSSCLASS="FormLabels" WIDTH="102px">Contact Fax</ASP:LABEL></TD>
					<TD align="left" width="150">&nbsp;<ASP:TEXTBOX id="txtContactFax" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="120px" MAXLENGTH="10"></ASP:TEXTBOX></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD style="HEIGHT: 20px" align="right" width="150"><ASP:LABEL id="lblRemarks" RUNAT="server" CSSCLASS="FormLabels">Remarks</ASP:LABEL></TD>
					<TD style="HEIGHT: 20px" align="left" width="450" colSpan="3">&nbsp;<ASP:TEXTBOX id="txtRemarks" RUNAT="server" CSSCLASS="FormTextBoxes" WIDTH="420px" MAXLENGTH="40"></ASP:TEXTBOX></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="center" colSpan="4"><ASP:BUTTON id="cmdSave" RUNAT="server" CSSCLASS="FormButtons" TEXT="Save"></ASP:BUTTON>&nbsp;
						<ASP:BUTTON id="cmdCancel" RUNAT="server" CSSCLASS="FormButtons" TEXT="Cancel" CausesValidation="False"></ASP:BUTTON></TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD align="left" colSpan="4"><ASP:LABEL id="lblError" RUNAT="server" CSSCLASS="FormErrorMessages" WIDTH="350px"></ASP:LABEL></TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
