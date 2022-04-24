<%@ Control Language="c#" AutoEventWireup="false" Codebehind="time.ascx.cs" Inherits="caching.time" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ OutputCache Duration="20" VaryByParam="none" %>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<table border="5" cellpadding="5" rules="none" bgcolor="lightyellow" bordercolor="orange"
	style="WIDTH: 343px; HEIGHT: 40px" align="center">
	<tr valign="middle">
		<td><h3>Last time the user control was loaded from server</h3>
		</td>
		<td><h3><asp:Label id="lblDateTime" runat="server" /></h3>
		</td>
	</tr>
</table>
