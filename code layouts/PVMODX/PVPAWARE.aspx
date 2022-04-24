<%@ Page language="c#" Codebehind="PVPAWARE.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPAWARE" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVPAWARE</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="STYLESHEET" TYPE="text/css" HREF="PVMODSTYLES.CSS">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlCriteria" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" Runat="server"
				Visible="True">
				<TABLE class="sofT" id="Table2" cellSpacing="0" width="300" align="center" bgColor="#a5c7e7"
					border="0">
					<TR>
						<TD class="helpHed">Select the Criteria</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle">&nbsp;</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" align="left"><INPUT id="Radio2" type="radio" value="MARGIN" name="ANALYSEBY">BY 
							MARGIN</TD>
					</TR>
					<TR>
						<TD class="borderlesstitle" bgColor="#99ccff">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<INPUT id="Radio1" type="radio" value="LEADTIME" name="ANALYSEBY">BY 
							LEADTIME&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>
