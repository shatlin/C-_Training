<%@ Page language="c#" Codebehind="AddNewUser.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.AddNewUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddNewUser</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="theForm" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="3" width="400" border="0">
				<TR>
					<TD class="helpHed"><asp:label id="lblUserDetails" runat="server" CssClass="TableHeader">User Details</asp:label></TD>
				</TR>
				<TR>
					<TD bgColor="#d2e4fc">
						<TABLE width="100%" border="0">
							<TR>
								<TD width="110"><asp:label id="lblUserID" runat="server" CssClass="FormLabels">ID</asp:label></TD>
								<TD><asp:textbox id="txtUserID" runat="server" CssClass="FormTextboxes" MaxLength="10" Width="110px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtUserID"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="110"><asp:label id="lblPassword" runat="server" CssClass="FormLabels">Password</asp:label></TD>
								<TD><asp:textbox id="txtPassword" runat="server" CssClass="FormTextboxes" Width="110px" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtPassword"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="110"><asp:label id="lblConfirm" runat="server" CssClass="FormLabels">Confirm</asp:label></TD>
								<TD><asp:textbox id="txtConfirm" runat="server" CssClass="FormTextboxes" Width="110px" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtConfirm"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="110"><asp:label id="lblName" runat="server" CssClass="FormLabels"> Name</asp:label></TD>
								<TD><asp:textbox id="txtUserName" runat="server" CssClass="FormTextboxes" Width="220px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtUserName"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="110"><asp:label id="lblEmail" runat="server" CssClass="FormLabels"> Email</asp:label></TD>
								<TD><asp:textbox id="txtEmail" runat="server" CssClass="FormTextboxes" Width="220px"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtEmail"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD width="110"><asp:label id="lblGroup" runat="server" CssClass="FormLabels">Group</asp:label></TD>
								<TD>
									<asp:DropDownList id="cboGroup" runat="server" Width="110px"></asp:DropDownList>
									<asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtUserID"></asp:requiredfieldvalidator></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<BR>
			<TABLE cellSpacing="0" cellPadding="3" width="400" border="0">
				<TR>
					<TD class="helpHed"><asp:label id="lblPrivileges" runat="server" CssClass="TableHeader">Previleges</asp:label></TD>
				</TR>
				<TR>
					<TD bgColor="#d2e4fc">
						<TABLE width="100%" border="0">
							<tr>
								<td align="left"><asp:label id="lblWarehouse" runat="server" CssClass="FormLabels">Warehouse</asp:label></td>
								<td align="left"><asp:label id="lblPages" runat="server" CssClass="FormLabels">Pages</asp:label></td>
							</tr>
							<TR>
								<TD><asp:listbox id="lstWarehouse" runat="server" CssClass="FormListBoxes" Width="176px" Height="250px"
										SelectionMode="Multiple" Rows="6" BackColor="Transparent"></asp:listbox></TD>
								<TD><asp:listbox id="lstPages" runat="server" CssClass="FormListBoxes" Width="176px" Height="250px"
										SelectionMode="Multiple" Rows="6" BackColor="Transparent"></asp:listbox></TD>
							</TR>
							<TR>
								<TD colSpan="2"><asp:checkbox id="chkIsAdmin" runat="server" CssClass="FormCheckBoxes" Text="Is Admin" AutoPostBack="True"></asp:checkbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblErrorMessage" runat="server" CssClass="FormErrorMessages"></asp:label></TD>
				</TR>
				<tr>
					<td><asp:validationsummary id="ValidationSummary" CssClass="FormErrorMessages" Runat="server" ShowSummary="True"
							DisplayMode="SingleParagraph" HeaderText="Please check all the fields marked with "></asp:validationsummary></td>
				</tr>
				<TR>
					<TD align="center"><asp:button id="btnSave" runat="server" CssClass="FormButtons" Text="Save"></asp:button>&nbsp;
						<asp:button id="btnClear" runat="server" CssClass="FormButtons" Text="Clear" CausesValidation="False"></asp:button>&nbsp;
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
