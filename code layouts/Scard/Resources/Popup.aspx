<%@ Page %>
<html dir="ltr" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta http-equiv="Expires" content="0">
		<link rel="stylesheet" type="text/css" href="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/styles/ows.css">
		<meta Name="Microsoft Theme" content="default">
		<meta Name="Microsoft Border" content="none">
		
		<title>Business Scorecard Manager</title>
		<script language="javascript">
		function LoadFrame()
		{
			document.all.waitMessageDiv.innerText = window.dialogArguments.LoadingText;
			document.all.innerFrame.src = window.dialogArguments.url;
		}
		
		function ready()
		{
			if( document.all.innerFrame.document.readyState == "complete")
			{
				document.all.innerFrame.style.visibility ="visible";
				document.all.waitMessageDiv.style.visibility = "hidden";
			}
		}
		</script>
	</head>
	<body id="popupFrame" leftmargin=0 topmargin=0 bottommargin=0 rightmargin=0 scroll=no onload="LoadFrame()"> 
		<div id="waitMessageDiv" class="ms-toolbar" align="center"></div>
		<iframe id="innerFrame" src="" style="visibility:hidden" width="100%" height="100%" onreadystatechange="ready()"></iframe>
	</body>
</html>
