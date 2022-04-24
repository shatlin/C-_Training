<%@ Page language="c#" Codebehind="Register.aspx.cs" AutoEventWireup="false" Inherits="gS.Register" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Register</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<link href="styles.css" rel="stylesheet" type="text/css">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form3" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD>
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR height="65">
									<TD><A href="http://www.auctionscape.com/index.php"></A></TD>
									<TD align="right" width="100%"><A href="http://www.auctionscape.com/click.php?refid=10016" target="new"><BR>
										</A>
									</TD>
								</TR>
							</TABLE>
							<TABLE id="Table3" style="BORDER-TOP: black 1px solid" height="25" cellSpacing="2" cellPadding="2"
								width="100%" border="0">
								<TR style="BORDER-TOP: black 1px solid" align="center" height="40">
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/index.php"><IMG src="images/i_home.gif" border="0"></A></TD>
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/login.php?redirect=sell"><IMG src="images/i_sell.gif" border="0"></A></TD>
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/register.php"><IMG src="images/i_register.gif" border="0"></A></TD>
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/login.php"><IMG src="images/i_login.gif" border="0"></A></TD>
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/stores.php"><IMG src="images/i_store.gif" border="0"></A></TD>
									<TD noWrap width="10%" background="images/menubg.gif"><A href="http://www.auctionscape.com/wanted.categories.php"><IMG src="images/i_ads.gif" border="0"></A></TD>
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/help.php"><IMG src="images/i_help.gif" border="0"></A></TD>
									<TD width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/faq.php"><IMG src="images/i_faq.gif" border="0"></A></TD>
									<TD noWrap width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/sitefees.php"><IMG src="images/i_fees.gif" border="0"></A></TD>
									<TD noWrap width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/aboutus.php"><IMG src="images/i_about.gif" border="0"></A></TD>
									<TD noWrap width="9%" background="images/menubg.gif"><A href="http://www.auctionscape.com/contactus.php"><IMG src="images/i_contact.gif" border="0"></A></TD>
									<TD background="images/menubg.gif">&nbsp;</TD>
								</TR>
								<TR class="mainmenu" align="center" bgColor="#1863bd">
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/index.php"><FONT size="1">HOME</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/login.php?redirect=sell"><FONT size="1">SELL</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/register.php"><FONT size="1">
												REGISTER </FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/login.php"><FONT size="1">
												LOGIN </FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/stores.php"><FONT size="1">STORES</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/wanted.categories.php"><FONT size="1">WANTED 
												ADS</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/help.php"><FONT size="1">HELP</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/faq.php"><FONT size="1">FAQ</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/sitefees.php"><FONT size="1">SITE 
												FEES</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/aboutus.php"><FONT size="1">ABOUT 
												US</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;<A href="http://www.auctionscape.com/contactus.php"><FONT size="1">CONTACT 
												US</FONT></A>&nbsp;</TD>
									<TD style="BORDER-BOTTOM: rgb(0,60,133) 2px solid">&nbsp;</TD>
								</TR>
							</TABLE>
							<TABLE id="Table6" cellSpacing="2" cellPadding="0" width="100%" border="0">
								<TBODY>
									<TR vAlign="top">
										<TD width="175">
											<SCRIPT language="javascript">
var ie4 = false; if(document.all) { ie4 = true; }
function getObject(id) { if (ie4) { return document.all[id]; } else { return document.getElementById(id); } }
function toggle(link, divId) { var lText = link.innerHTML; var d = getObject(divId);
 if (lText == '+') { link.innerHTML = '&#8211;'; d.style.display = 'block'; }
 else { link.innerHTML = '+'; d.style.display = 'none'; } }
											</SCRIPT>
											<TABLE id="Table7" height="22" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR bgColor="#003c85">
												</TR>
												<TR bgColor="#ffffff">
												</TR>
												<TR bgColor="#0b3c61">
												</TR>
											</TABLE> <!-- flooble Expandable Content box end  -->
											<TABLE id="Table9" height="22" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR bgColor="#003c85">
													<TD><IMG height="2" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR bgColor="#ffffff">
													<TD><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR bgColor="#1a8ce4" height="21">
													<TD width="100%"><IMG height="9" hspace="6" src="images/arr_part.gif" width="9" align="middle"><B style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">CATEGORIES 
															[<A class="hidelayer" id="exp1102170166_link" title="show/hide" onclick="toggle(this, 'exp1102170166');"
																href="javascript: void(0);"><FONT color="#ffffff" size="3">–</FONT></A>]</B></TD>
												</TR>
												<TR bgColor="#0b3c61">
													<TD><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
											</TABLE>
											<DIV id="exp1102170166">
												<TABLE id="Table10" cellSpacing="0" cellPadding="3" width="100%" border="0">
													<TR class="c2">
														<TD class="categories"><IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A title="Please note that this area contains sexually oriented adult material intended for individuals 18 years of age or older, and of legal age to view and purchase sexual material as determined by the local and national laws of the region in which you reside. I"
																href="http://www.auctionscape.com/categories.php?parent=1819&amp;show=subcats">Adults 
																Only</A> (<STRONG>4</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=215&amp;show=subcats">Antiques 
																&amp; Art</A> (0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=263&amp;show=subcats">Automobiles</A>
															(<STRONG>-2</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=355&amp;show=subcats">Books</A>
															(<STRONG>6</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=887&amp;show=subcats">Businesses 
																For Sale</A> (<STRONG>-8</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=474&amp;show=subcats">Clothing 
																&amp; Accessories</A> (0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=634&amp;show=subcats">Coins</A>
															(0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=669&amp;show=subcats">Collectables</A>
															(<STRONG>-2</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=877&amp;show=subcats">Computing</A>
															(<STRONG>34</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1117&amp;show=subcats">Dolls 
																&amp; Dolls Houses</A> (0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1040&amp;show=subcats">Electronics</A>
															(<STRONG>-122</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1777&amp;show=subcats">Everything 
																Else</A> (<STRONG>-2</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=57&amp;show=subcats">Gaming</A>
															(<STRONG>-6</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1211&amp;show=subcats">Jewellery 
																&amp; Watches</A> (<STRONG>12</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1243&amp;show=subcats">Music</A>
															(<STRONG>-5</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1311&amp;show=subcats">Photopgraphy</A>
															(0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1351&amp;show=subcats">Pottery 
																&amp; Glass</A> (0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=890&amp;show=subcats">Properties</A>
															(0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=878&amp;show=subcats">Services</A>
															(0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1404&amp;show=subcats">Sports</A>
															(0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1554&amp;show=subcats">Stamps</A>
															(0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1588&amp;show=subcats">Tickets 
																&amp; Travel</A> (0)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1628&amp;show=subcats">Toys 
																&amp; Games</A> (<STRONG>-3</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1139&amp;show=subcats">TV 
																&amp; Movies</A> (<STRONG>-5</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1723&amp;show=subcats">Wholesale 
																Items</A> (<STRONG>-16</STRONG>)<BR>
															<IMG height="9" hspace="4" src="images/arrow.gif" width="9" align="middle" vspace="3"><A href="http://www.auctionscape.com/categories.php?parent=1837&amp;show=subcats">Health 
																&amp; Beauty</A> (0)<BR>
														</TD>
													</TR>
												</TABLE>
											</DIV>
											<NOSCRIPT>
												JS not supported
											</NOSCRIPT>
											<DIV><IMG height="1" src="images/pixel.gif" width="175"></DIV>
										</TD>
										<TD background="images/vline.gif"><IMG height="1" src="images/pixel.gif" width="7"></TD>
										<TD width="100%">
											<TABLE id="Table11" height="22" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR bgColor="#003c85">
													<TD><IMG height="2" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR bgColor="#ffffff">
													<TD><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR bgColor="#1a8ce4" height="21">
													<TD width="100%"></TD>
												</TR>
												<TR bgColor="#0b3c61">
													<TD><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
											</TABLE>
											<DIV><IMG height="5" src="images/pixel.gif" width="1"></DIV>
											<TABLE id="Table27" cellSpacing="1" cellPadding="3" width="100%" border="0">
												<TR class="c2" height="15">
													<TD class="smallfont" width="76" style="WIDTH: 76px; HEIGHT: 19px" align="right">Full 
														Name</TD>
													<TD class="smallfont" noWrap style="WIDTH: 229px; HEIGHT: 19px" colSpan="3">
														<asp:TextBox id="txtFullName" runat="server" Width="192px" MaxLength="255"></asp:TextBox>&nbsp;<FONT color="blue">*</FONT>
													</TD>
												</TR>
												<TR class="c4" height="15">
													<TD class="smallfont" style="WIDTH: 76px; HEIGHT: 28px" align="right">UserName</TD>
													<TD class="smallfont" noWrap style="WIDTH: 229px; HEIGHT: 28px">
														<asp:TextBox id="txtUser" runat="server" MaxLength="100"></asp:TextBox><FONT color="blue">*</FONT>
													</TD>
													<TD class="smallfont" noWrap style="WIDTH: 123px; HEIGHT: 28px" align="right">
														Sex
													</TD>
													<TD class="smallfont" width="100%" style="HEIGHT: 28px">
														<asp:Panel id="pnlSex" runat="server" Width="224px" Height="8px">
															<asp:Label id="lblMale" runat="server">Male</asp:Label>
															<asp:RadioButton id="rbMale" runat="server" GroupName="rbSexGrp" Checked="True"></asp:RadioButton>
															<asp:Label id="lblFemale" runat="server">Female</asp:Label>
															<asp:RadioButton id="rbFemale" runat="server" GroupName="rbSexGrp"></asp:RadioButton>
														</asp:Panel><FONT color="blue">*</FONT>
													</TD>
												</TR>
												<TR class="c2" height="15">
													<TD class="smallfont" width="76" style="WIDTH: 76px; HEIGHT: 19px" align="right">Password</TD>
													<TD class="smallfont" noWrap style="WIDTH: 229px; HEIGHT: 19px">
														<asp:TextBox id="txtPassword" runat="server" MaxLength="40"></asp:TextBox><FONT color="blue">*</FONT>
													</TD>
													<TD class="smallfont" noWrap style="WIDTH: 123px; HEIGHT: 19px" align="right">Re-enter 
														Password</TD>
													<TD class="item" width="100%" style="HEIGHT: 19px">
														<asp:TextBox id="txtPasswordVerify" runat="server" MaxLength="40"></asp:TextBox><FONT color="blue">*</FONT>
													</TD>
												</TR>
												<TR class="c3" height="15">
													<TD class="smallfont" width="76" style="WIDTH: 76px" align="right">Country</TD>
													<TD class="smallfont" noWrap style="WIDTH: 229px">
														<asp:DropDownList id="drpCountry" runat="server">
															<asp:ListItem Value="India">India</asp:ListItem>
															<asp:ListItem Value="USA">USA</asp:ListItem>
														</asp:DropDownList><FONT color="blue">*</FONT>
													</TD>
													<TD class="smallfont" noWrap style="WIDTH: 123px" align="right">State</TD>
													<TD class="item" width="100%">
														<asp:DropDownList id="drpState" runat="server">
															<asp:ListItem Value="Pune">Pune</asp:ListItem>
															<asp:ListItem Value="Mumbai">Mumbai</asp:ListItem>
														</asp:DropDownList><FONT color="blue">*</FONT>
													</TD>
												</TR>
												<TR class="c2" height="15">
													<TD class="smallfont" width="76" style="WIDTH: 76px" align="right">City</TD>
													<TD class="smallfont" noWrap style="WIDTH: 229px">
														<asp:TextBox id="txtCity" runat="server" MaxLength="50"></asp:TextBox>
													</TD>
													<TD class="smallfont" noWrap style="WIDTH: 123px" align="right">Phone</TD>
													<TD class="item" width="100%">
														<asp:TextBox id="txtPhone" runat="server" MaxLength="50"></asp:TextBox>
													</TD>
												</TR>
												<TR class="c3" height="15">
													<TD class="smallfont" width="76" style="WIDTH: 76px; HEIGHT: 18px" align="right">Address 
														1</TD>
													<TD class="smallfont" noWrap style="WIDTH: 229px; HEIGHT: 18px">
														<asp:TextBox id="txtAddress1" runat="server" Width="232px" MaxLength="255"></asp:TextBox>
													</TD>
													<TD class="smallfont" noWrap style="WIDTH: 123px; HEIGHT: 18px" align="right">Address 
														2</TD>
													<TD class="item" width="100%" style="HEIGHT: 18px">
														<asp:TextBox id="txtAddress2" runat="server" Width="224px" MaxLength="255"></asp:TextBox>
													</TD>
												</TR>
												<TR>
													<TD align="center" class="smallfont" style="WIDTH: 76px; HEIGHT: 18px" width="76" colSpan="4">&nbsp;
														<asp:Button id="btnRegister" runat="server" Text="Register"></asp:Button>
														<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
												</TR>
											</TABLE>
										</TD>
										<TD><IMG height="1" src="images/pixel.gif" width="5"></TD>
										<TD>
											<DIV><A href="http://www.auctionscape.com/register.php"></A></DIV>
											<DIV><IMG height="5" src="images/pixel.gif" width="1"></DIV>
											<TABLE id="Table29" height="22" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR bgColor="#993300">
													<TD><IMG height="2" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR bgColor="#ffffff">
													<TD><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR bgColor="#ff9900" height="21">
													<TD width="100%"><IMG height="9" hspace="6" src="images/arr_part.gif" width="9" align="middle"><B style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">SITE 
															NEWS</B></TD>
												</TR>
												<TR bgColor="#993300">
													<TD><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
											</TABLE>
											<TABLE id="Table30" cellSpacing="0" cellPadding="3" width="100%" border="0">
												<TR>
													<TD class="c4"><IMG height="1" src="images/pixel.gif" width="1"></TD>
													<TD class="c3"><IMG height="1" src="images/pixel.gif" width="1"></TD>
												</TR>
												<TR>
													<TD class="c3"><IMG height="8" hspace="4" src="images/arrow.gif" width="8"></TD>
													<TD class="c2 smallfont" width="100%"><B>01 Oct. 2005 </B>
													</TD>
												</TR>
												<TR class="contentfont">
													<TD class="c4"></TD>
													<TD class="c3 smallfont"><A href="http://www.auctionscape.com/displaynews.php?id=23"><FONT color="#000000" size="2">ALERT: 
																FAKE MONEY ORDER SCAM </FONT></A>
													</TD>
												</TR>
												<TR>
													<TD class="c3"><FONT size="2"><IMG height="8" hspace="4" src="images/arrow.gif" width="8"></FONT></TD>
													<TD class="c2 smallfont" width="100%"><B>11 Sep. 2005 </B>
													</TD>
												</TR>
												<TR class="contentfont">
													<TD class="c4"></TD>
													<TD class="c3 smallfont"><A href="http://www.auctionscape.com/displaynews.php?id=22"><FONT color="#000000" size="2">Looking 
																for powersellers </FONT></A>
													</TD>
												</TR>
												<TR>
													<TD class="c3"><FONT size="2"><IMG height="8" hspace="4" src="images/arrow.gif" width="8"></FONT></TD>
													<TD class="c2 smallfont" width="100%"><B>21 Jul. 2005 </B>
													</TD>
												</TR>
												<TR class="contentfont">
													<TD class="c4"></TD>
													<TD class="c3 smallfont"><A href="http://www.auctionscape.com/displaynews.php?id=21"><FONT color="#000000" size="2">10 
																MORE DAYS! $50 CASH </FONT></A>
													</TD>
												</TR>
												<TR>
													<TD class="c3"><FONT size="2"><IMG height="8" hspace="4" src="images/arrow.gif" width="8"></FONT></TD>
													<TD class="c2 smallfont" width="100%"><B>13 Jul. 2005 </B>
													</TD>
												</TR>
												<TR class="contentfont">
													<TD class="c4"></TD>
													<TD class="c3 smallfont"><A href="http://www.auctionscape.com/displaynews.php?id=20"><FONT color="#000000" size="2">Awsome 
																Work! </FONT></A>
													</TD>
												</TR>
												<TR>
													<TD class="c3"><FONT size="2"><IMG height="8" hspace="4" src="images/arrow.gif" width="8"></FONT></TD>
													<TD class="c2 smallfont" width="100%"><B>04 Jul. 2005 </B>
													</TD>
												</TR>
												<TR class="contentfont">
													<TD class="c4"></TD>
													<TD class="c3 smallfont"><A href="http://www.auctionscape.com/displaynews.php?id=19"><FONT color="#000000" size="2">Tell 
																A Friend! </FONT></A>
													</TD>
												</TR>
											</TABLE>
											<DIV><FONT size="2"><IMG height="1" src="images/pixel.gif" width="178"></FONT></DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE id="Table31" cellSpacing="2" cellPadding="1" width="100%" border="0">
								<TR>
									<TD bgColor="#333333"><FONT size="2"><IMG height="1" src="images/pixel.gif" width="178"></FONT></TD>
									<TD width="100%" bgColor="#333333"><FONT size="2"><IMG height="1" src="images/pixel.gif" width="1"></FONT></TD>
								</TR>
								<TR bgColor="#f1f1f5">
									<TD class="footerfont1" align="center" bgColor="#888888" height="40"><FONT face="Arial, Helvetica, sans-serif" size="2"><A href="http://www.heavydatahosting.com/"></A></FONT></TD>
									<TD class="footerfont" width="100%" height="40">&nbsp;&nbsp;<A href="http://www.auctionscape.com/index.php">Home</A>
										• <A href="http://www.auctionscape.com/login.php?redirect=sell">Sell</A> • <A href="http://www.auctionscape.com/register.php">
											REGISTER</A> • <A href="http://www.auctionscape.com/login.php">LOGIN</A> • <A href="http://www.auctionscape.com/help.php">
											Help</A>&nbsp;<B>|</B>&nbsp; <A href="http://www.auctionscape.com/aboutus.php">About 
											Us</A> • <A href="http://www.auctionscape.com/contactus.php">Contact Us</A> 
										• <A href="http://www.auctionscape.com/faq.php">FAQ</A> • <A href="http://www.auctionscape.com/pp.php">
											Privacy Policy</A> • <A href="http://www.auctionscape.com/terms.php">Terms 
											&amp; Conditions</A> • <A href="http://www.auctionscape.com/sitefees.php">Site 
											Fees</A></TD>
								</TR>
							</TABLE>
							<CENTER><FONT style="COLOR: rgb(102,102,102)">Page loaded in 1.53451013565 seconds.</FONT></CENTER>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</body>
</HTML>
