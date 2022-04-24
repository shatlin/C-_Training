<%@ Page language="c#" Codebehind="StkAllocationStatus.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.StkAllocationStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>StkAllocationStatus</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT LANGUAGE="JavaScript" SRC="menu_array.js" TYPE="text/javascript"></SCRIPT>
		<SCRIPT LANGUAGE="JavaScript" SRC="mmenu.js" TYPE="text/javascript"></SCRIPT>
		<LINK HREF="PVMODSTYLES.CSS" TYPE="text/css" REL="STYLESHEET">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="thisForm" method="post" runat="server">
			<H2 CLASS="h2head">Stock Allocation Status</H2>
			<BR>
			<TABLE CLASS="sofT" CELLSPACING="0" CELLPADDING="0" WIDTH="350" ALIGN="center" BORDER="0">
				<TR>
					<TD CLASS="helpHed" ALIGN="left" COLSPAN="4">Criteria</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD COLSPAN="4">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="left" colspan="2" WIDTH="300">&nbsp;
						<ASP:LABEL ID="lblOrderNo" RUNAT="server" CSSCLASS="FormLabels">Order #</ASP:LABEL>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;
						<ASP:TEXTBOX id="txtOrderNo" CSSCLASS="FormTextBoxes" RUNAT="server" WIDTH="150px" MAXLENGTH="10"></ASP:TEXTBOX>
					</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="left" WIDTH="150">
						<asp:RadioButton id="rdbAllProducts" runat="server" Text="AllProducts" CssClass="FormRadioButtons"
							GroupName="grpOrder" Checked="True" AutoPostBack="True"></asp:RadioButton></TD>
					<TD ALIGN="left" WIDTH="150">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD ALIGN="left" WIDTH="150">
						<asp:RadioButton id="rdbBackorderProducts" runat="server" Text="Back Order Products" CssClass="FormRadioButtons"
							GroupName="grpOrder" AutoPostBack="True"></asp:RadioButton></TD>
					<TD ALIGN="left" WIDTH="150">&nbsp;</TD>
				</TR>
				<TR bgcolor="#d2e4fc">
					<TD align="left" width="300" colSpan="2">
						<asp:RadioButton id="rdbSingleProduct" runat="server" Text="Single Product" CssClass="FormRadioButtons"
							GroupName="grpOrder" AutoPostBack="True"></asp:RadioButton>&nbsp;
						<asp:DropDownList id="cboProducts" runat="server" CssClass="FormComboBoxes" Width="150px" Visible="False"></asp:DropDownList>
					</TD>
				</TR>
				<TR bgColor="#d2e4fc">
					<TD ALIGN="right" WIDTH="300" colspan=2>
						<ASP:BUTTON id="cmdView" CSSCLASS="FormButtons" RUNAT="server" TEXT="View"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
