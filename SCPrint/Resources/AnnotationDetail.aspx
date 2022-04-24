<%@ Page Inherits="Microsoft.PerformanceManagement.Scorecards.WebControls.AnnotationDetailPage, Microsoft.PerformanceManagement.Scorecards.WebControls, Version=2.0.0.0, Culture=Neutral, PublicKeyToken=31BF3856AD364E35" %>
<%@ Register TagPrefix="bpm" Namespace="Microsoft.PerformanceManagement.Scorecards.WebControls" Assembly="Microsoft.PerformanceManagement.Scorecards.WebControls, Version=2.0.0.0, Culture=Neutral, PublicKeyToken=31BF3856AD364E35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AnnotationDetail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link REL="stylesheet" Type="text/css" HREF="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/styles/ows.css">
		<META Name="Microsoft Theme" Content="default">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<bpm:AnnotationCtrl id="AnnotationCtrl1" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 20px"
				runat="server"></bpm:AnnotationCtrl>
		</form>
	</body>
</HTML>
