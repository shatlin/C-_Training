<%@ Page language="c#" Codebehind="PVLogin.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVLogin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVLogin</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">		
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="theForm" method="post" runat="server">
			<table border="0" width="230" align="center">
				<tr>
					<td width="90">
						<asp:Label id="lblUsername" runat="server" CssClass="FormLabels">Username</asp:Label></td>
					<td>
						<asp:TextBox id="txtUserName" runat="server" CssClass="FormTextboxes" Width="110px" AutoPostBack="True"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
							Display="Dynamic" ControlToValidate="txtUserName"></asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td width="90">
						<asp:Label id="lblPassword" runat="server" CssClass="FormLabels">Password</asp:Label></td>
					<td>
						<asp:TextBox id="txtPassword" runat="server" CssClass="FormTextboxes" TextMode="Password" Width="110px"></asp:TextBox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" CssClass="FormErrorMessages" ErrorMessage="*"
							Display="Dynamic" ControlToValidate="txtPassword"></asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td width="90">
						<asp:Label id="lblWarehouse" runat="server" CssClass="FormLabels">Warehouse</asp:Label></td>
					<td>
						<asp:DropDownList id="cboWarehouse" runat="server"></asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblErrorMessage" runat="server" CssClass="FormErrorMessages"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="right">
						<asp:Button id="cmdLogin" runat="server" Text="Login" CssClass="FormButtons"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
