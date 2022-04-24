<%@ Page language="c#" Codebehind="sendmail.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.sendmail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>sendmail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 336px; POSITION: absolute; TOP: 168px" runat="server"
				Text="Send Mail"></asp:Button>
			<asp:label id="lblError" runat="server" CssClass="FormErrorMessages"></asp:label>
		</form>
	</body>
</HTML>
