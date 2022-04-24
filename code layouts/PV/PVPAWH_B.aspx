<%@ Page language="c#" Codebehind="PVPAWH_B.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPAWH" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVPAWH</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="STYLESHEET" TYPE="text/css" HREF="PVMODSTYLES.CSS">
		<script language="javascript">
		function doSection (secNum)
		{
			if (secNum.style.display=="none")
			{
				secNum.style.display=""
			}
			else
			{
				secNum.style.display="none"
			}
		}
		
		function noSection (secNum)
		{
			if (secNum.style.display=="")
			{
				secNum.style.display="none"
			}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel ID="pnlCriteria" Runat="server" Visible="True">
				<TABLE class="sofT" id="Table2" cellSpacing="0" width="300" align="center" bgColor="#a5c7e7"
					border="0">
					<TR>
						<TD class="helpHed" colSpan="2">Select the Criteria</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" align="left" colSpan="2">&nbsp;&nbsp;&nbsp; <INPUT id="Radio1" type="radio" value="LEADTIME" name="ANALYSEBY">BY 
							LEADTIME</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" align="left" colSpan="2"><INPUT id="Radio2" type="radio" value="MARGIN" name="ANALYSEBY">BY 
							MARGIN</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" bgColor="#99ccff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
				</TABLE>
				<BR>
				<TABLE border="5">
					<TR>
						<% 
				string[] ss=testdata();
					for(int i=0;i<ss.Length;i++)
					{
				%>
						<TD class="sup" height="16"><A onclick="doSection(div<%=i%>)" 
      href="#sec<%=i%>"><%= ss[i]%></A><A name="sec<%=i%>"></A>
							<H2></H2>
							<DIV class=divclass id="div<%=i%>" style="DISPLAY: none">
								<TABLE class="sofT" border="3">
									<TR>
										<TD><%=ss[i]%></TD>
										<TD><%=ss[i]%></TD>
										<%
					if(ss[i]!="data2")
					{
					 %>
										<TD><%=ss[i]%></TD>
										<%}
					else
					{
					%>
										<TD><FONT color="red"><%=ss[i]%></FONT></TD>
										<%}%>
										<TD><%=ss[i]%></TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
						<%}%>
					</TR>
				</TABLE>
			</asp:Panel>&nbsp;
		</form>
	</body>
</HTML>
