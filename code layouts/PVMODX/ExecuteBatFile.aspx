<%@ Page language="c#" Codebehind="ExecuteBatFile.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.ExecuteBatFile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExecuteBatFile</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="cmdExecute" style="Z-INDEX: 101; LEFT: 352px; POSITION: absolute; TOP: 168px"
				runat="server" Text="Execute"></asp:Button>
			<asp:Label id="lblError" style="Z-INDEX: 102; LEFT: 328px; POSITION: absolute; TOP: 120px"
				runat="server" Width="144px" CssClass="FormErrorMessages"></asp:Label>
		</form>
	</body>
</HTML>
