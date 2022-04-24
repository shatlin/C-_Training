<%@ Page language="c#" Codebehind="PVChangePassword.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVChangePassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVChangePassword</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="PVMODSTYLES.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="theForm" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="3" width="240" border="0">
				<TR>
					<TD class="TDStyle1">
						<asp:Label id="Label4" runat="server" CssClass="TableHeader">Password Details</asp:Label></TD>
				</TR>
				<TR>
					<TD class="TDStyle2">
						<TABLE width="250" border="0">
							<TR>
								<TD width="110">
									<asp:Label id="Label1" runat="server" CssClass="FormLabels">Old Password</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtOldPassword" runat="server" CssClass="FormTextboxes" Width="110px" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD width="110">
									<asp:Label id="Label2" runat="server" CssClass="FormLabels">New Password</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtNewPassword" runat="server" CssClass="FormTextboxes" Width="110px" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator2" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD width="110">
									<asp:Label id="Label3" runat="server" CssClass="FormLabels">Confirm</asp:Label></TD>
								<TD>
									<asp:TextBox id="txtConfirmPassword" runat="server" CssClass="FormTextboxes" Width="110px" TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
										Display="Dynamic" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD colSpan="2">
									<asp:Label id="lblErrorMessage" runat="server" CssClass="FormErrorMessages"></asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<asp:ValidationSummary ID="ValidationSummary" Runat="server" CssClass="FormErrorMessages" ShowSummary="True"
							DisplayMode="SingleParagraph" HeaderText="Please check all the fields marked with "></asp:ValidationSummary>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<asp:Button id="cmdChangePwd" runat="server" CssClass="FormButtons" Text="Change Password" Width="128px"></asp:Button>&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
