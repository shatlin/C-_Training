<%@ Page language="c#" Codebehind="gShare.aspx.cs" AutoEventWireup="false" Inherits="gS.gShare" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Global Sharing</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta name="description" content="">
		<meta name="keywords" content="">
		<link href="styles.css" rel="stylesheet" type="text/css">
			<script language="javascript" src="images/main.js" type="text/javascript"></script>
			<script>function editor_generate() { return false; }</script>
			<script language="javascript">
/*
urlparams = top.document.location.search;
if(urlparams != '')
    document.write("<img src='affiliate/scripts/t2.aspx"+urlparams+"&referrer="+escape(top.document.referrer)+"' border='0' width='1' height='1'>");
*/
			</script>
	</HEAD>
	<body leftmargin="2" topmargin="2" marginheight="2" marginwidth="2">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tbody>
					<tr>
						<td>
							<table border="0" cellpadding="2" cellspacing="2" width="100%">
								<tbody>
									<tr height="65">
										<td><a href="index.aspx"></a></td>
										<td align="right" width="100%">
											<a href="click.aspx?refid=10016" target="new"><img src="images/logo2.jpg" alt="" border="0"><br>
											</a>
										</td>
									</tr>
								</tbody>
							</table>
							<table style="BORDER-TOP: black 1px solid" border="0" cellpadding="2" cellspacing="2" height="25"
								width="100%">
								<tbody>
									<tr style="BORDER-TOP: black 1px solid" align="center" height="40">
										<td background="images/menubg.gif" width="9%"><a href="index.aspx"><img src="images/i_home.gif" border="0"></a></td>
										<td background="images/menubg.gif" width="9%"><a href="login.aspx?redirect=sell"><img src="images/i_sell.gif" border="0"></a></td>
										<td background="images/menubg.gif" width="9%"><a href="register.aspx"><img src="images/i_register.gif" border="0"></a></td>
										<td background="images/menubg.gif" width="9%"><a href="login.aspx"><img src="images/i_login.gif" border="0"></a></td>
										<td background="images/menubg.gif" width="9%"><a href="stores.aspx"><img src="images/i_store.gif" border="0"></a></td>
										<td background="images/menubg.gif" nowrap width="10%"><a href="wanted.categories.aspx"><img src="images/i_ads.gif" border="0"></a></td>
										<td background="images/menubg.gif" width="9%"><a href="help.aspx"><img src="images/i_help.gif" border="0"></a></td>
										<td background="images/menubg.gif" width="9%"><a href="faq.aspx"><img src="images/i_faq.gif" border="0"></a></td>
										<td background="images/menubg.gif" nowrap width="9%"><a href="sitefees.aspx"><img src="images/i_fees.gif" border="0"></a></td>
										<td background="images/menubg.gif" nowrap width="9%"><a href="aboutus.aspx"><img src="images/i_about.gif" border="0"></a></td>
										<td background="images/menubg.gif" nowrap width="9%"><a href="contactus.aspx"><img src="images/i_contact.gif" border="0"></a></td>
										<td background="images/menubg.gif">&nbsp;</td>
									</tr>
									<tr class="mainmenu" align="center" bgcolor="#1863bd">
										<td>&nbsp;<a href="index.aspx">HOME</a>&nbsp;</td>
										<td>&nbsp;<a href="login.aspx?redirect=sell">SELL</a>&nbsp;</td>
										<td>&nbsp;<a href="register.aspx"> REGISTER </a>&nbsp;</td>
										<td>&nbsp;<a href="login.aspx"> LOGIN </a>&nbsp;</td>
										<td>&nbsp;<a href="stores.aspx">STORES</a>&nbsp;</td>
										<td>&nbsp;<a href="wanted.categories.aspx">WANTED ADS</a>&nbsp;</td>
										<td>&nbsp;<a href="help.aspx">HELP</a>&nbsp;</td>
										<td>&nbsp;<a href="faq.aspx">FAQ</a>&nbsp;</td>
										<td>&nbsp;<a href="sitefees.aspx">SITE FEES</a>&nbsp;</td>
										<td>&nbsp;<a href="aboutus.aspx">ABOUT US</a>&nbsp;</td>
										<td>&nbsp;<a href="contactus.aspx">CONTACT US</a>&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
								</tbody>
							</table>
							<table border="0" cellpadding="0" cellspacing="2" width="100%">
								<tbody>
									<tr>
										<td bgcolor="#e9e9eb">
											<input name="show" value="subcats" type="hidden">
											<table border="0" cellpadding="0" cellspacing="0" height="31" width="100%">
												<tbody>
													<tr>
														<td class="search" align="center" nowrap width="194">&nbsp;&nbsp;&nbsp; 21 Apr. 
															2006 07:34:30 &nbsp;&nbsp;&nbsp;</td>
														<form action="auctionsearch.aspx" method="post">
														</form>
														<td><img src="images/sep.gif"></td>
														<td class="search" nowrap>&nbsp;&nbsp;&nbsp;<a href="search.aspx">SEARCH</a>&nbsp;&nbsp;&nbsp;</td>
														<td class="search" nowrap><input size="25" name="basicsearch">&nbsp;&nbsp;&nbsp;</td>
														<td class="search" nowrap><input name="searchok" value="Search" type="submit">&nbsp;&nbsp;&nbsp;</td>
														<td><img src="images/sep.gif"></td>
														<td class="search" nowrap>&nbsp;&nbsp;&nbsp;BROWSE&nbsp;&nbsp;</td>
														<form name="catbrowse" method="post" action="categories.aspx">
														</form>
														<td class="search" width="100%"><select name="parent" onchange="javascript:catbrowse.submit()"><option value="" selected>
																	Choose a Category
																</option>
																<option value="1819">
																	Adults Only
																</option>
																<option value="215">
																	Antiques &amp; Art
																</option>
																<option value="263">
																	Automobiles
																</option>
																<option value="355">
																	Books
																</option>
																<option value="887">
																	Businesses For Sale
																</option>
																<option value="474">
																	Clothing &amp; Accessories
																</option>
																<option value="634">
																	Coins
																</option>
																<option value="669">
																	Collectables
																</option>
																<option value="877">
																	Computing
																</option>
																<option value="1117">
																	Dolls &amp; Dolls Houses
																</option>
																<option value="1040">
																	Electronics
																</option>
																<option value="1777">
																	Everything Else
																</option>
																<option value="57">
																	Gaming
																</option>
																<option value="1211">
																	Jewellery &amp; Watches
																</option>
																<option value="1243">
																	Music
																</option>
																<option value="1311">
																	Photopgraphy
																</option>
																<option value="1351">
																	Pottery &amp; Glass
																</option>
																<option value="890">
																	Properties
																</option>
																<option value="878">
																	Services
																</option>
																<option value="1404">
																	Sports
																</option>
																<option value="1554">
																	Stamps
																</option>
																<option value="1588">
																	Tickets &amp; Travel
																</option>
																<option value="1628">
																	Toys &amp; Games
																</option>
																<option value="1139">
																	TV &amp; Movies
																</option>
																<option value="1723">
																	Wholesale Items
																</option>
																<option value="1837">
																	Health &amp; Beauty
																</option>
																<option value="">------------------------</option>
																<option value="0">All Categories</option>
															</select>
														</td>
														<td nowrap><!-- ADD THE FOLLOWING CODE WHEREEVER YOU WANT YOUR LANGUAGE OPTIONS TO SHOW-->
															<div align="center"><a href="lang.aspx?lang=german"><img src="images/german.gif" alt="german" border="0"></a>&nbsp;&nbsp;<a href="lang.aspx?lang=russian"><img src="images/russian.gif" alt="russian" border="0"></a>&nbsp;&nbsp;<a href="lang.aspx?lang=english"><img src="images/english.gif" alt="english" border="0"></a>&nbsp;&nbsp;</div>
															<!-- END ADDITION -->
														</td>
													</tr>
												</tbody>
											</table>
										</td>
									</tr>
								</tbody>
							</table>
							<table border="0" cellpadding="0" cellspacing="2" width="100%">
								<tbody>
									<tr valign="top">
										<td width="175">
											<script language="javascript">
var ie4 = false; if(document.all) { ie4 = true; }
function getObject(id) { if (ie4) { return document.all[id]; } else { return document.getElementById(id); } }
function toggle(link, divId) { var lText = link.innerHTML; var d = getObject(divId);
 if (lText == '+') { link.innerHTML = '&#8211;'; d.style.display = 'block'; }
 else { link.innerHTML = '+'; d.style.display = 'none'; } }
											</script>
											<table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#003c85">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#1a8ce4" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">MEMBERS 
																AREA [<a title="show/hide" class="hidelayer" id="exp1102170142_link" href="javascript: void(0);"
																	onclick="toggle(this, 'exp1102170142');">-</a>]</b></td>
													</tr>
													<tr bgcolor="#0b3c61">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<div id="exp1102170142">
												<table class="c4" border="0" cellpadding="2" cellspacing="2" width="100%">
													<form action="login.aspx" method="post" name="loginbox">
													</form>
													<tbody>
														<tr class="c2">
															<td class="user" align="right">Username&nbsp;</td>
															<td class="user" nowrap>
																<asp:textbox id="txtUser" runat="server" Width="150px">shatlin</asp:textbox>
															</td>
														</tr>
														<tr class="c2">
															<td class="user" align="right" nowrap>Password&nbsp;</td>
															<td class="user" nowrap>
																<asp:textbox id="txtPassword" runat="server" Width="150px" TextMode="Password">denistan</asp:textbox></td>
														</tr>
														<tr>
															<td colspan="2" align="center">
																<P align="left">
																	<asp:linkbutton id="lnkRegister" runat="server">New User? Register here</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																	&nbsp;&nbsp;
																	<asp:linkbutton id="lnkLogin" runat="server">login</asp:linkbutton></P>
															</td>
														</tr>
														<TR>
															<TD align="center" colSpan="2">
																<P align="left">
																	<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></P>
															</TD>
														</TR>
													</tbody>
												</table>
												<DIV><img src="images/pixel.gif" height="5" width="1"></DIV>
											</div>
											<noscript>
												JS not supported
											</noscript>
											<!-- flooble Expandable Content box end  -->
											<table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#003c85">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#1a8ce4" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">CATEGORIES 
																[<a title="show/hide" class="hidelayer" id="exp1102170166_link" href="javascript: void(0);"
																	onclick="toggle(this, 'exp1102170166');">-</a>]</b></td>
													</tr>
													<tr bgcolor="#0b3c61">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<div id="exp1102170166">
												<table border="0" cellpadding="3" cellspacing="0" width="100%">
													<tbody>
														<tr class="c2">
															<td class="categories">
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1819&amp;show=subcats" title="Please note that this area contains sexually oriented adult material intended for individuals 18 years of age or older, and of legal age to view and purchase sexual material as determined by the local and national laws of the region in which you reside. I">Adults 
																	Only</a> (<strong>4</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=215&amp;show=subcats">Antiques 
																	&amp; Art</a> (0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=263&amp;show=subcats">Automobiles</a>
																(<strong>-2</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=355&amp;show=subcats">Books</a>
																(<strong>6</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=887&amp;show=subcats">Businesses 
																	For Sale</a> (<strong>-8</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=474&amp;show=subcats">Clothing 
																	&amp; Accessories</a> (0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=634&amp;show=subcats">Coins</a>
																(0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=669&amp;show=subcats">Collectables</a>
																(<strong>-2</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=877&amp;show=subcats">Computing</a>
																(<strong>34</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1117&amp;show=subcats">Dolls 
																	&amp; Dolls Houses</a> (0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1040&amp;show=subcats">Electronics</a>
																(<strong>-122</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1777&amp;show=subcats">Everything 
																	Else</a> (<strong>-2</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=57&amp;show=subcats">Gaming</a>
																(<strong>-6</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1211&amp;show=subcats">Jewellery 
																	&amp; Watches</a> (<strong>12</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1243&amp;show=subcats">Music</a>
																(<strong>-5</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1311&amp;show=subcats">Photopgraphy</a>
																(0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1351&amp;show=subcats">Pottery 
																	&amp; Glass</a> (0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=890&amp;show=subcats">Properties</a>
																(0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=878&amp;show=subcats">Services</a>
																(0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1404&amp;show=subcats">Sports</a>
																(0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1554&amp;show=subcats">Stamps</a>
																(0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1588&amp;show=subcats">Tickets 
																	&amp; Travel</a> (0)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1628&amp;show=subcats">Toys 
																	&amp; Games</a> (<strong>-3</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1139&amp;show=subcats">TV 
																	&amp; Movies</a> (<strong>-5</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1723&amp;show=subcats">Wholesale 
																	Items</a> (<strong>-16</strong>)<br>
																<img src="images/arrow.gif" align="middle" height="9" hspace="4" vspace="3" width="9"><a href="categories.aspx?parent=1837&amp;show=subcats">Health 
																	&amp; Beauty</a> (0)<br>
															</td>
														</tr>
													</tbody>
												</table>
											</div>
											<noscript>
												JS not supported
											</noscript>
											<div><img src="images/pixel.gif" height="1" width="175"></div>
										</td>
										<td background="images/vline.gif"><img src="images/pixel.gif" height="1" width="7"></td>
										<td width="100%"><table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#003c85">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#1a8ce4" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">Featured 
																Auctions [
																<span class="sell">
																	<a href="auctions.show.aspx?option=featured">View All</a></span>
																]</b></td>
													</tr>
													<tr bgcolor="#0b3c61">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<table border="0" cellpadding="0" cellspacing="4" width="100%">
												<tbody>
													<tr>
														<td class="border" align="center" valign="top" width="33%">
															<table border="0" cellpadding="3" cellspacing="1" width="100%">
																<tbody>
																	<tr>
																		<td class="feat1" nowrap>START BID</td>
																		<td class="feat2" nowrap>
																			196.00 USD
																		</td>
																	</tr>
																	<tr>
																		<td colspan="2" class="feat3"><a href="auctiondetails.aspx?id=108697">Apple Ipod 15 G </a>
																		</td>
																	</tr>
																	<tr valign="top">
																		<td colspan="2">
																			<table border="0" cellpadding="2" cellspacing="1" width="100%">
																				<tbody>
																					<tr>
																						<td class="gradient" align="center" height="85" width="85">
																							<a href="auctiondetails.aspx?id=108697"><img src="images/makethumb.jpg" alt="Apple Ipod 15 G" border="0"></a></td>
																						<td valign="top">
																							<table border="0" cellpadding="3" cellspacing="1" width="100%">
																								<tbody>
																									<tr valign="top">
																										<td colspan="2" class="smallfont">
																											<a href="auctiondetails.aspx?id=108697">&gt;&gt; View Details </a>
																										</td>
																									</tr>
																									<tr valign="top">
																										<td colspan="2" class="smallfont"><b> Ends :</b> 30 Apr. 2006 23:31:49
																										</td>
																									</tr>
																								</tbody>
																							</table>
																						</td>
																						<td>
																						</td>
																					</tr>
																					<tr>
																						<td class="feat3" align="right"><a href="auctiondetails.aspx?id=108697"> BID NOW <img src="images/bidnow.gif" align="middle" border="0" hspace="5"></a></td>
																						<td class="feat2"><b> Current bid :</b> No Bids</td>
																					</tr>
																				</tbody>
																			</table>
																		</td>
																	</tr>
																</tbody>
															</table>
														</td>
														<td class="border" align="center" valign="top" width="33%">
															<table border="0" cellpadding="3" cellspacing="1" width="100%">
																<tbody>
																	<tr>
																		<td class="feat1" nowrap>START BID</td>
																		<td class="feat2" nowrap>
																			196.00 USD
																		</td>
																	</tr>
																	<tr>
																		<td colspan="2" class="feat3"><a href="auctiondetails.aspx?id=108678">Apple Ipod 15 G </a>
																		</td>
																	</tr>
																	<tr valign="top">
																		<td colspan="2">
																			<table border="0" cellpadding="2" cellspacing="1" width="100%">
																				<tbody>
																					<tr>
																						<td class="gradient" align="center" height="85" width="85">
																							<a href="auctiondetails.aspx?id=108678"><img src="images/makethumb_002.jpg" alt="Apple Ipod 15 G" border="0"></a></td>
																						<td valign="top">
																							<table border="0" cellpadding="3" cellspacing="1" width="100%">
																								<tbody>
																									<tr valign="top">
																										<td colspan="2" class="smallfont">
																											<a href="auctiondetails.aspx?id=108678">&gt;&gt; View Details </a>
																										</td>
																									</tr>
																									<tr valign="top">
																										<td colspan="2" class="smallfont"><b> Ends :</b> 30 Apr. 2006 23:30:40
																										</td>
																									</tr>
																								</tbody>
																							</table>
																						</td>
																						<td>
																						</td>
																					</tr>
																					<tr>
																						<td class="feat3" align="right"><a href="auctiondetails.aspx?id=108678"> BID NOW <img src="images/bidnow.gif" align="middle" border="0" hspace="5"></a></td>
																						<td class="feat2"><b> Current bid :</b> No Bids</td>
																					</tr>
																				</tbody>
																			</table>
																		</td>
																	</tr>
																</tbody>
															</table>
														</td>
														<td class="border" align="center" valign="top" width="33%">
															<table border="0" cellpadding="3" cellspacing="1" width="100%">
																<tbody>
																	<tr>
																		<td class="feat1" nowrap>START BID</td>
																		<td class="feat2" nowrap>
																			12.99 USD
																		</td>
																	</tr>
																	<tr>
																		<td colspan="2" class="feat3"><a href="auctiondetails.aspx?id=108681">Motorola OEM 
																				Travel Charger - MPx200 V3 RAZR SPN51 </a>
																		</td>
																	</tr>
																	<tr valign="top">
																		<td colspan="2">
																			<table border="0" cellpadding="2" cellspacing="1" width="100%">
																				<tbody>
																					<tr>
																						<td class="gradient" align="center" height="85" width="85">
																							<a href="auctiondetails.aspx?id=108681"><img src="images/noimg.gif" alt="Motorola OEM Travel Charger - MPx200 V3 RAZR SPN51"
																									border="0"></a></td>
																						<td valign="top">
																							<table border="0" cellpadding="3" cellspacing="1" width="100%">
																								<tbody>
																									<tr valign="top">
																										<td colspan="2" class="smallfont">
																											<a href="auctiondetails.aspx?id=108681">&gt;&gt; View Details </a>
																										</td>
																									</tr>
																									<tr valign="top">
																										<td colspan="2" class="smallfont"><b> Ends :</b> 30 Apr. 2006 23:30:41
																										</td>
																									</tr>
																								</tbody>
																							</table>
																						</td>
																						<td>
																						</td>
																					</tr>
																					<tr>
																						<td class="feat3" align="right"><a href="auctiondetails.aspx?id=108681"> BID NOW <img src="images/bidnow.gif" align="middle" border="0" hspace="5"></a></td>
																						<td class="feat2"><b> Current bid :</b> No Bids</td>
																					</tr>
																				</tbody>
																			</table>
																		</td>
																	</tr>
																</tbody>
															</table>
														</td>
													</tr>
													<tr>
														<td class="border" align="center" valign="top" width="33%">
														</td>
														<td class="border" align="center" valign="top" width="33%">
														</td>
														<td class="border" align="center" valign="top" width="33%">
														</td>
													</tr>
												</tbody>
											</table>
											<div><img src="images/pixel.gif" height="5" width="1"></div>
											<table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#003c85">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#1a8ce4" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">Recently 
																Listed Auctions [
																<span class="sell">
																	<a href="auctions.show.aspx?option=recent">View All</a></span>
																]</b></td>
													</tr>
													<tr bgcolor="#0b3c61">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<table border="0" cellpadding="3" cellspacing="1" width="100%">
												<tbody>
													<tr class="c4" height="15">
														<td>
														</td>
														<td class="smallfont" nowrap>&nbsp;<b> Start Date </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;<b> Start Bid </b>
														</td>
														<td class="smallfont" width="100%">&nbsp;<b> Auction Title <b></b></b>
														</td>
														<td class="smallfont" nowrap>&nbsp;</td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>17 Apr. 2006 21:19:49</b></td>
														<td class="smallfont" nowrap>&nbsp;No Bids</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109036"> Olympus Stylus 
																500 + P-10 DIGITAL PHOTO PRINTER </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109036">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c3" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>17 Apr. 2006 21:07:33</b></td>
														<td class="smallfont" nowrap>&nbsp;No Bids</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109035"> Coby 3 CD 
																Vertical CD Player with Digital AM/F </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109035">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>16 Apr. 2006 22:53:18</b></td>
														<td class="smallfont" nowrap>&nbsp;59.95 USD</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109034"> WINDOWS XP PRO 
																LATEST SP2 OEM VERSION </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109034">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c3" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>16 Apr. 2006 22:53:17</b></td>
														<td class="smallfont" nowrap>&nbsp;4.00 USD</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109033"> Book COLD HIT by 
																Stephen J. Cannell </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109033">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>16 Apr. 2006 22:53:16</b></td>
														<td class="smallfont" nowrap>&nbsp;9.95 USD</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109032"> CYBERLINK 
																POWERDVD </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109032">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c3" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>16 Apr. 2006 22:53:14</b></td>
														<td class="smallfont" nowrap>&nbsp;49.95 USD</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109031"> THINKPAD MEMORY 
																512 MB T40 A30 A31 A31P ETC. </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109031">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>12 Apr. 2006 14:40:44</b></td>
														<td class="smallfont" nowrap>&nbsp;59.95 USD</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109030"> WINDOWS XP PRO 
																LATEST SP2 OEM VERSION </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109030">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c3" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b>12 Apr. 2006 14:40:44</b></td>
														<td class="smallfont" nowrap>&nbsp;4.00 USD</td>
														<td class="item" width="100%"><a href="auctiondetails.aspx?id=109029"> Book COLD HIT by 
																Stephen J. Cannell </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=109029">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
												</tbody>
											</table>
											<br>
											<table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#003c85">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#1a8ce4" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">Recently 
																Bid On [
																<span class="sell">
																	<a href="auctions.show.aspx?option=highbid">View All</a></span>
																]</b></td>
													</tr>
													<tr bgcolor="#0b3c61">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<table border="0" cellpadding="3" cellspacing="1" width="100%">
												<tbody>
													<tr class="c4" height="15">
														<td>
														</td>
														<td class="smallfont">&nbsp;<b> Max. Bid </b>
														</td>
														<td class="smallfont">&nbsp;<b> Auction Title <b></b></b>
														</td>
														<td class="smallfont">&nbsp;</td>
													</tr>
												</tbody>
											</table>
											<br>
											<table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#003c85">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#1a8ce4" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">Ending 
																Soon [
																<span class="sell">
																	<a href="auctions.show.aspx?option=ending">View All</a></span>
																]</b></td>
													</tr>
													<tr bgcolor="#0b3c61">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<table border="0" cellpadding="3" cellspacing="1" width="100%">
												<tbody>
													<tr class="c4" height="15">
														<td>
														</td>
														<td class="smallfont" nowrap>&nbsp;<b> Time Left </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;<b> Start Bid </b>
														</td>
														<td class="smallfont" width="100%">&nbsp;<b> Auction Title </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;</td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b> 15h 54m </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;1.00 USD</td>
														<td class="item" width="100%">&nbsp;<a href="auctiondetails.aspx?id=108595">GOLDEN 
																CITRINE ROUNDS </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=108595">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c3" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b> 15h 58m </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;1.00 USD</td>
														<td class="item" width="100%">&nbsp;<a href="auctiondetails.aspx?id=108596">AQUAMARINE 
																OVALS </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=108596">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b> 16h 04m </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;1.00 USD</td>
														<td class="item" width="100%">&nbsp;<a href="auctiondetails.aspx?id=108597">GARNET 
																ROUNDS </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=108597">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c3" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b> 16h 10m </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;1.00 USD</td>
														<td class="item" width="100%">&nbsp;<a href="auctiondetails.aspx?id=108598">AMETHYST 
																PEARS </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=108598">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
													<tr class="c2" height="15">
														<td width="11"><img src="images/arr_it.gif" height="11" hspace="4" width="11"></td>
														<td class="smallfont" nowrap>&nbsp;<b> 16h 19m </b>
														</td>
														<td class="smallfont" nowrap>&nbsp;1.00 USD</td>
														<td class="item" width="100%">&nbsp;<a href="auctiondetails.aspx?id=108599">AMETHYST 
																OVALS </a>
														</td>
														<td nowrap><img src="images/camera1.gif" alt="Picture" align="middle" border="0"> <a href="buynow.aspx?id=108599">
																<img src="images/buyitnow25.gif" alt="BUY NOW" align="middle" border="0"></a></td>
													</tr>
												</tbody>
											</table>
										</td>
										<td><img src="images/pixel.gif" height="1" width="5"></td>
										<td>
											<div><a href="register.aspx"><img src="images/tips.gif" border="0" height="107" width="178"></a></div>
											<table style="FONT-WEIGHT: bold; COLOR: rgb(24,99,189)" bgcolor="#0a57ad" border="0" cellpadding="2"
												cellspacing="1" width="100%">
												<tbody>
													<tr>
														<td align="center" bgcolor="#c7e3ff" width="20%"><b>4023</b></td>
														<td bgcolor="#c7e3ff" width="80%">&nbsp;<font style="FONT-SIZE: 10px">registered users</font></td>
													</tr>
													<tr>
														<td align="center" bgcolor="#c7e3ff" width="20%"><b>126</b></td>
														<td bgcolor="#c7e3ff" width="80%">&nbsp;<font style="FONT-SIZE: 10px">live auctions</font></td>
													</tr>
													<tr>
														<td align="center" bgcolor="#c7e3ff" width="20%"><b>1</b></td>
														<td bgcolor="#c7e3ff" width="80%">&nbsp;<font style="FONT-SIZE: 10px">visitors online</font></td>
													</tr>
												</tbody>
											</table>
											<div><img src="images/pixel.gif" height="5" width="1"></div>
											<table border="0" cellpadding="0" cellspacing="0" height="22" width="100%">
												<tbody>
													<tr bgcolor="#993300">
														<td><img src="images/pixel.gif" height="2" width="1"></td>
													</tr>
													<tr bgcolor="#ffffff">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr bgcolor="#ff9900" height="21">
														<td width="100%"><img src="images/arr_part.gif" align="middle" height="9" hspace="6" width="9"><b style="FONT-SIZE: 10px; COLOR: rgb(255,255,255)">SITE 
																NEWS</b></td>
													</tr>
													<tr bgcolor="#993300">
														<td><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
												</tbody>
											</table>
											<table border="0" cellpadding="3" cellspacing="0" width="100%">
												<tbody>
													<tr>
														<td class="c4"><img src="images/pixel.gif" height="1" width="1"></td>
														<td class="c3"><img src="images/pixel.gif" height="1" width="1"></td>
													</tr>
													<tr>
														<td class="c3"><img src="images/arrow.gif" height="8" hspace="4" width="8"></td>
														<td class="c2 smallfont" width="100%"><b>01 Oct. 2005 </b>
														</td>
													</tr>
													<tr class="contentfont">
														<td class="c4">
														</td>
														<td class="c3 smallfont"><a href="displaynews.aspx?id=23"> ALERT: FAKE MONEY ORDER SCAM </a>
														</td>
													</tr>
													<tr>
														<td class="c3"><img src="images/arrow.gif" height="8" hspace="4" width="8"></td>
														<td class="c2 smallfont" width="100%"><b>11 Sep. 2005 </b>
														</td>
													</tr>
													<tr class="contentfont">
														<td class="c4">
														</td>
														<td class="c3 smallfont"><a href="displaynews.aspx?id=22"> Looking for powersellers </a>
														</td>
													</tr>
													<tr>
														<td class="c3"><img src="images/arrow.gif" height="8" hspace="4" width="8"></td>
														<td class="c2 smallfont" width="100%"><b>21 Jul. 2005 </b>
														</td>
													</tr>
													<tr class="contentfont">
														<td class="c4">
														</td>
														<td class="c3 smallfont"><a href="displaynews.aspx?id=21"> 10 MORE DAYS! $50 CASH </a>
														</td>
													</tr>
													<tr>
														<td class="c3"><img src="images/arrow.gif" height="8" hspace="4" width="8"></td>
														<td class="c2 smallfont" width="100%"><b>13 Jul. 2005 </b>
														</td>
													</tr>
													<tr class="contentfont">
														<td class="c4">
														</td>
														<td class="c3 smallfont"><a href="displaynews.aspx?id=20"> Awsome Work! </a>
														</td>
													</tr>
													<tr>
														<td class="c3"><img src="images/arrow.gif" height="8" hspace="4" width="8"></td>
														<td class="c2 smallfont" width="100%"><b>04 Jul. 2005 </b>
														</td>
													</tr>
													<tr class="contentfont">
														<td class="c4">
														</td>
														<td class="c3 smallfont"><a href="displaynews.aspx?id=19"> Tell A Friend! </a>
														</td>
													</tr>
												</tbody>
											</table>
											<div><img src="images/pixel.gif" height="1" width="178"></div>
										</td>
									</tr>
								</tbody>
							</table>
							<table border="0" cellpadding="1" cellspacing="2" width="100%">
								<tbody>
									<tr>
										<td bgcolor="#333333"><img src="images/pixel.gif" height="1" width="178"></td>
										<td bgcolor="#333333" width="100%"><img src="images/pixel.gif" height="1" width="1"></td>
									</tr>
									<tr bgcolor="#f1f1f5">
										<td class="footerfont1" align="center" bgcolor="#888888" height="40"><font face="Arial, Helvetica, sans-serif" size="2">
												<a href="http://www.heavydatahosting.com/"></a></font>
										</td>
										<td class="footerfont" height="40" width="100%">&nbsp;&nbsp;<a href="index.aspx">Home</a>
											. <a href="login.aspx?redirect=sell">Sell</a> . <a href="register.aspx">REGISTER</a>
											. <a href="login.aspx">LOGIN</a> . <a href="help.aspx">Help</a>&nbsp;<b>|</b>&nbsp;
											<a href="aboutus.aspx">About Us</a> . <a href="contactus.aspx">Contact Us</a> . <a href="faq.aspx">
												FAQ</a> . <a href="pp.aspx">Privacy Policy</a> . <a href="terms.aspx">Terms 
												&amp; Conditions</a> . <a href="sitefees.aspx">Site Fees</a></td>
									</tr>
								</tbody>
							</table>
							<center><font style="COLOR: rgb(102,102,102)">Page loaded in 1.53451013565 seconds.</font></center>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
