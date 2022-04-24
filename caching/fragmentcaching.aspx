<%@ Page language="c#" Codebehind="fragmentcaching.aspx.cs" AutoEventWireup="false" Inherits="caching.WebForm1" %>
<%@ Register tagprefix ="ucTime" tagname="Time" Src="time.ascx" %>
<HTML>
	<HEAD>
		<form>
	</HEAD>
	<body>
		<b>
			<P>Current time is</P>
			<P>
				<asp:Label id="Label1" runat="server">Label</asp:Label></P>
			<p>
				<ucTime:Time runat="server" ID="Time1" /><br>
				Grool<b> </FORM></b></p>
		</b>
	</body>
</HTML>
