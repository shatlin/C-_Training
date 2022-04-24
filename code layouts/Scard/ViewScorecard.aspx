<%@ Page language="c#" Codebehind="ViewScorecard.aspx.cs" AutoEventWireup="false" Inherits="SCPrint.ViewScorecard" %>
 
<HTML dir="ltr" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office">
            <HEAD>
                        <Title>
                                    SC Print
                        </Title>
                        <META Name="ProgId" Content="Microsoft.PerformanceManagement.Scorecards.WebControls">
                        <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
                        <META HTTP-EQUIV="Expires" content="0">
                        <Link REL="stylesheet" Type="text/css" HREF="ows.css">
                        <META Name="Microsoft Theme" Content="default">
                        <META Name="Microsoft Border" Content="none">
            </HEAD>
            <SCRIPT LANGUAGE="JavaScript">
                        function printThis()
                        {
                                    window.print();
                        }
            </SCRIPT>
            <body marginwidth="10px" marginheight="10px" scroll="auto" style="MARGIN : 10px" id="PageBody"
                        runat="server">
                        <form runat="server" ID="Form1">
                                    <table border =0>
                                                <tr>
                                                            <td align = center style="font-family: Verdana; font-size: 12pt; color: #003399">
                                                                        Microsoft Office Business Scorecard Manager 2005
                                                            </td>
                                                </tr>
 
                                                <tr align = right>
                                                            <td>
                                                                        <asp:PlaceHolder id="mainPlaceHolder" runat="Server" />
                                                            </td>
                                                </tr>
                                                <tr>
                                                            <td align = right>
                                                                        <a href="#" style="font-family: Verdana; font-size: 8pt; color: #003399" onclick='printThis()' onmouseover="window.status='Print';return true" onmouseout="window.status=''; return true">Print</a>&nbsp;
                                                            </td>
                                                </tr>
 
                                    </table>
                        </form>
            </body>
</HTML>
