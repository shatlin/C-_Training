<%@ Page Inherits="Microsoft.PerformanceManagement.Scorecards.WebControls.ScorecardWebpage, Microsoft.PerformanceManagement.Scorecards.WebControls, Version=2.0.0.0, Culture=Neutral, PublicKeyToken=31BF3856AD364E35" %>
<HTML dir="ltr" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office">
	<HEAD>
		<Title><%=PageTitle%></Title>
		<META Name="ProgId" Content="Microsoft.PerformanceManagement.Scorecards.WebControls">
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<META HTTP-EQUIV="Expires" content="0">
		<script src="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/owsbrows.js"></script>
		<Link REL="stylesheet" Type="text/css" HREF="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/styles/ows.css">
		<META Name="Microsoft Theme" Content="default">
		<META Name="Microsoft Border" Content="none">
	</HEAD>
	
	<body marginwidth="10px" marginheight="10px" scroll="auto" style="margin : 10px" id="PageBody" runat="server">
		<form runat="server">			
			<asp:PlaceHolder id="mainPlaceHolder" runat="Server"/>
		</form>
	</body>
</HTML>
