<%@ Page language="c#" Codebehind="PVPAMOD.aspx.cs" AutoEventWireup="false" Inherits="PVMODX.PVPAMOD" %>
<%@ Register TagPrefix="mbcbb" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.ComboBox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PVPAMOD</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="PVMODSTYLES.CSS" type="text/css" rel="STYLESHEET">
		 <SCRIPT language="JavaScript" src="menu_inbound.js" type="text/javascript"></SCRIPT>
		<SCRIPT language="JavaScript" src="mmenu.js" type="text/javascript"></SCRIPT>
		
		<script language="javascript">
		function selclrAll(btnname,chkvals)
		{
		var p=0
		
		
		if(document.frmPA.elements[btnname].value=="All")
		{
			for(p=0;p<document.frmPA.elements.length;++p)
			{
				if (document.frmPA.elements[p].name.indexOf(chkvals) != -1) 
				{
					if(document.frmPA.elements[p].disabled==false)
						{
						document.frmPA.elements[p].checked = true 
						}
					
				}
			}
			document.frmPA.elements[btnname].value="Clr"
		}
		else
		{
		for(p=0;p<document.frmPA.elements.length;++p)
			{
				if (document.frmPA.elements[p].name.indexOf(chkvals) != -1) 
				{
					document.frmPA.elements[p].checked = false 
					
				}
			}
			document.frmPA.elements[btnname].value="All"
		}
		
		}
		//collects the remarks for supplier change from the Analysis table
		function collectVendorsRemarks()
		{
		var pslist=""
		var remlist=""
		var p=0
		
		//pvalues is preferred supplier dropdown box  of Analysis table(PS0,PS1 and so on)
		//rvalues is remarks dropdown box  of Analysis table (REM0,REM1 and so on)
		document.frmPA.PVALUES.value = ""
		document.frmPA.RVALUES.value = ""
		
		//collect all values from the two drop down boxes into two variables pslist and remlist
		for(p=0;p<document.frmPA.elements.length;++p)
		{
			if (document.frmPA.elements[p].name.substring(0,2) == 'PS') 
			{
				pslist=pslist+document.frmPA.elements[p].value+"!"
			}
			
			if (document.frmPA.elements[p].name.substring(0,3) == 'REM') 
			{
				
				remlist=remlist+document.frmPA.elements[p].value+"!"
				
			}
		}
		document.frmPA.PVALUES.value = pslist
		document.frmPA.RVALUES.value = remlist
		}
		</script>
		
		
		<script language="javascript">
		//showing and hiding table in a division
		function showhidetbl (div)
		{
			if (div.style.display=="none")
			{
				div.style.display=""
			}
			else
			{
				div.style.display="none"
			}
		}
		
		function showremarks (div,i)
		{
		
			if (div.style.display=="none")
			{
				div.style.display=""
				
			}
		}
		</script>
		
	</HEAD>
	
	<body MS_POSITIONING="GridLayout">
	<H2 class="h2head">Purchase Analysis</H2>
	
		<form id="frmPA"  runat=server >
			<asp:linkbutton id="lnkChoice" text="View Choice" Visible="false" Runat="server" CssClass="FormLinkButtons"></asp:linkbutton>
			<asp:linkbutton id="lnkProducts" text="View Products" Visible="false" Runat="server" CssClass="FormLinkButtons"></asp:linkbutton>
			<asp:linkbutton id="lnkAnalysis" text="View Analysis" Visible="false" Runat="server" CssClass="FormLinkButtons"></asp:linkbutton>
			
<!-- Table to make choices  like choosing suppliers,criteria-->

			<asp:table id="tblChoice" Runat="server" Width="900" HorizontalAlign="Center">
				<asp:TableRow VerticalAlign="Top">
					<asp:TableCell Width="100" HorizontalAlign="Center">
						<asp:Table ID="tblContainer" Runat="server">
							<asp:TableRow>
								<asp:TableCell>
									<asp:Table id="tblAnalyse" Runat="server" Width="150" CssClass="sofT" style="vertical-align:top; ">
										<asp:TableRow>
											<asp:TableCell cssclass="smallheader" style="HEIGHT: 18px">Analyse By</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell cssclass="smallcell" HorizontalAlign="Left">
												<asp:radiobuttonlist AutoPostBack="True" id="rdoAnalyseOn" style="font-weight: bold;font-size: 11px;font-family: Verdana;text-align:left;"
													runat="server">
													<asp:ListItem Value="nsn" Selected="True">A NSN</asp:ListItem>
													<asp:ListItem Value="productlist">Selected Products</asp:ListItem>
													<asp:ListItem Value="warehouse">WareHouse</asp:ListItem>
													<asp:ListItem Value="supplier">Supplier</asp:ListItem>
												</asp:radiobuttonlist>
											</asp:TableCell>
										</asp:TableRow>
									</asp:Table>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
			<!-- Table to choose criteria as either of leadtime and margin-->
			
									<asp:Table id="tblCriteria" Runat="server" Width="150" CssClass="sofT" style="vertical-align:top; ">
										<asp:TableRow>
											<asp:TableCell cssclass="smallheader" style="HEIGHT: 18px">Criteria</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell cssclass="smallcell" HorizontalAlign="Left">
												<asp:radiobuttonlist AutoPostBack="True" id="rdoCriteria" style="font-weight: bold;font-size: 11px;font-family: Verdana;text-align:left;"
													runat="server">
													<asp:ListItem Value="margin" Selected="True">Margin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
													<asp:ListItem Value="leadtime">Lead Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
												</asp:radiobuttonlist>
											</asp:TableCell>
										</asp:TableRow>
									</asp:Table>
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
					</asp:TableCell>
					<asp:TableCell> 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</asp:TableCell>
					
					<asp:TableCell Width="300" HorizontalAlign="Center" VerticalAlign="Middle">
					
					<asp:Table>
				
			          
			          <asp:TableRow >
			          <asp:TableCell >
									<asp:datagrid id="DataGrid1" runat="server" Width="100%" Visible="True" BackColor="White"
										AllowPaging="false" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="0"  BorderWidth="0px"
										BorderStyle="None" BorderColor="#6699cc" CssClass="FormDataGrids">
										<SelectedItemStyle BackColor="#D2E4FC"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#D2E4FC"></AlternatingItemStyle>
										<ItemStyle  CssClass =gridboldcontent></ItemStyle>
										<HeaderStyle CssClass="smallgridheader"></HeaderStyle>
										<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="vendor_id" ReadOnly="True" HeaderText="vendor id">
												<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="">
												<ItemTemplate>
													<asp:CheckBox ID="chkVendorid"  CssClass=FormSmallCheckBoxes Runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Supplier">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "vendor") %>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
									<ASP:LABEL ForeColor="red" id="lblSupplier" RUNAT="server" CSSCLASS="FormLabels"></ASP:LABEL>
					
					</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow >
						
					<asp:TableCell >
					&nbsp;
					</asp:TableCell> 
					</asp:TableRow> 
						<asp:TableRow >
						
					<asp:TableCell >
								<INPUT class="btn"  style ="width=50px"  type =button  runat =server  VALUE="All" id="selallsup" NAME=selallsup onclick =selclrAll('selallsup','chkVendorid')>					
			          </asp:TableCell>
			          </asp:TableRow> 
			          
					</asp:Table>
					
									
					</asp:TableCell>
					<asp:TableCell>&nbsp;&nbsp;&nbsp;</asp:TableCell>
					<asp:TableCell Width="700" HorizontalAlign="Center" VerticalAlign="Middle">
						<asp:Table id="tblNSN" Runat="server" Width="250" CssClass="sofT" Visible="false">
							<asp:TableRow>
								<asp:TableCell cssCLASS="helpHed" STYLE="border:5px;" ColumnSpan="2">Enter NSN</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell STYLE="border:0px;" ColumnSpan="2" WIDTH="10" cssCLASS="innertitle">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;Width:80px">
									<B>Enter&nbsp;NSN</B></asp:TableCell>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;">
									<asp:TextBox ID="txtNSN" MAXLENGTH="60" WIDTH="237" Runat="server"></asp:TextBox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;" ColumnSpan="3" HorizontalAlign="Center">
									<asp:Button Runat="server" ID="btnNSN" cssCLASS="btn" Text="Continue" />
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;" ColumnSpan="3" HorizontalAlign="Center">
									<asp:Label Runat="server" ForeColor="red" ID="lblNSN" cssCLASS="FormLabels" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
						<asp:Table id="tblWareHouse" Runat="server" Width="250" CssClass="sofT" Visible="false">
							<asp:TableRow>
								<asp:TableCell cssCLASS="helpHed" STYLE="border:5px;" ColumnSpan="2">Select WareHouse</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell STYLE="border:0px;" ColumnSpan="2" WIDTH="10" cssCLASS="innertitle">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;Width:80px">
									<B>WareHouse</B></asp:TableCell>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;">
									<mbcbb:combobox id="cboWareHouse" runat="server" CssClass="FormComboBoxes" Width="250px" Visible="True"></mbcbb:combobox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;" ColumnSpan="3" HorizontalAlign="Center">
									<asp:Button Runat="server" ID="btnWareHouse" cssCLASS="btn" Text="Continue" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
						<asp:Table id="tblSupAnalysis" Runat="server" Width="150" CssClass="sofT" Visible="false">
							<asp:TableRow>
								<asp:TableCell cssCLASS="helpHed" STYLE="border:5px;" ColumnSpan="2">Supplier</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell STYLE="border:0px;" ColumnSpan="2" WIDTH="10" cssCLASS="innertitle">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;Width:80px">
									<B>Supplier</B></asp:TableCell>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;">
									<mbcbb:combobox id="cboSupplier" runat="server" CssClass="FormComboBoxes" Width="250px" Visible="True"></mbcbb:combobox>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;" ColumnSpan="3" HorizontalAlign="Center">
									<asp:Button Runat="server" ID="btnSupplier" cssCLASS="btn" Text="Continue" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
						
						
						
						
								<asp:Table id="tblViewProducts" Runat="server" Width="300" CssClass="sofT" Visible="false">
							<asp:TableRow>
								<asp:TableCell cssCLASS="helpHed" STYLE="border:5px;" ColumnSpan="2">Products</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell STYLE="border:0px;" ColumnSpan="2" WIDTH="10" cssCLASS="innertitle">&nbsp;</asp:TableCell>
							</asp:TableRow>
							
							<asp:TableRow>
								<asp:TableCell cssCLASS="innertitle" STYLE="border:0px;" ColumnSpan="2" HorizontalAlign="Center">
									<asp:Button Runat="server" ID="btnViewProducts" cssCLASS="btn" Text="View Products" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
								</asp:TableCell>
				</asp:TableRow>
			</asp:table>
			<br>
			<asp:table id="tblError"  Width =100% HorizontalAlign =Center  Visible="false" Runat="server">
						<asp:TableRow >
						<asp:TableCell  cssclass="helpHed" HorizontalAlign =Center >Errors</asp:TableCell> 
					</asp:TableRow> 
			<asp:TableRow >
			<asp:TableCell cssclass="helpBod" HorizontalAlign =Center>
							<asp:datagrid id="DataGrid3" runat="server" CssClass="FormDataGrids" Visible="True" Height="23px"
								BorderColor="Gray" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
								GridLines="Horizontal" width="100%" ShowHeader="False">
								<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
								<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
								<HeaderStyle CssClass="gridHeader"></HeaderStyle>
								<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							</asp:datagrid>
			</asp:TableCell>
			</asp:TableRow>
			
			</asp:Table> 
			<br>
			<asp:table id="tblproductgrid"  Width =100% HorizontalAlign =Center  Visible="false" Runat="server">
				<asp:TableRow>
					
					<asp:TableCell cssclass="helpHed" style="text-align:left;" ColumnSpan="3"> <INPUT class="btn"  style ="width:35px" type =button  runat =server  VALUE="All" id="btnPrdSelectAll" NAME=btnPrdSelectAll onclick =selclrAll('btnPrdSelectAll','chkProducts')>

					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					Product Details of the Order</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>
						<asp:datagrid id="DataGrid2" runat="server" Width="100%" Visible="True" Height="23px" BackColor="White"
							AllowPaging="false"
							AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="3" BorderWidth="1px" BorderStyle="None"
							BorderColor="Gray" CssClass="FormDataGrids">
							<SelectedItemStyle CssClass="gridContent"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F3F8FE"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem" BackColor="white"></ItemStyle>
							<HeaderStyle CssClass="gridHeader"></HeaderStyle>
							<FooterStyle Font-Size="11px" Font-Names="verdana" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="stock_number" ReadOnly="True" HeaderText="po_no">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText=" ">
									<ItemTemplate>
										<asp:CheckBox ID="chkProducts" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="WAREHOUSE">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "warehouse") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="product" ReadOnly="True" HeaderText="nsn">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Product">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "product") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="stock_number" ReadOnly="True" HeaderText="nsn">
									<ItemStyle Wrap="False" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="NSN">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "stock_number") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DESCRIPTION">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "dscp_desc") %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="PURCHASE UNIT">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "purchase_unit") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow >
					<asp:TableCell cssclass="sup"  style="text-align:center" HorizontalAlign =Center >
					<asp:button id="btnproductgrid" runat="server" Text="Continue" cssclass="FormButtons"></asp:button></asp:TableCell> 
				</asp:TableRow>
			</asp:table>
		<br>
		
<asp:Panel ID="pnlAnalysis"  Width =100% HorizontalAlign =Center Runat="server" Visible="false">		
<%
			
			
			
			string[] nsn=nsnlist.Split ('!');
			string[] vid=selectedSuppliers();
			string[] vdisp=getSupplierName();
			int supcount=0;

// no supplier selected	is indicated by	setting vdisp[0] as -1
			
			if(vdisp[0]!="-1")
			{
				supcount=vdisp.Length;
			}
// if suppliers are selected 		
			if (supcount >0)
			{
// if Analysis done on a supplier against a number of other suppliers
// Add the analysed supplier to the supplier lists analysed

			string cboSelectedVendorid=getcboSelectedVendorid();
			if(cboSelectedVendorid.Length >0)
			{
				ArrayList vidlist=new ArrayList();
				ArrayList vdisplist=new ArrayList();
				for(int vlist=0;vlist<vid.Length;vlist++)
				{
				vidlist.Add(vid[vlist]);
				vdisplist.Add(vdisp[vlist]);
				}
				if(findIndex(vid,cboSelectedVendorid)==-1)
				{
					vidlist.Add(cboSelectedVendorid);
					vdisplist.Add(getcboSelectedVendorName(cboSelectedVendorid));
					supcount++;
				}
// vid and vdisp contain the final supplier list for analysis
// whether the analysis is done on supplier or others.

				vid=(String[])vidlist.ToArray(typeof(String));
				vdisp=(String[])vdisplist.ToArray(typeof(String));
				
			}
			
%>

	<table id=tblAnalysis  class =sofT  width =100%>		
		<TR>
			<TD COLSPAN="<%=6+supcount%>" CLASS="helpHed">Purchase Analysis - Select Products</TD>
			</TR>
			<TR>
				<TD CLASS="helpBod" HEIGHT="16">Product</TD>
				<TD CLASS="helpBod" HEIGHT="16" ALIGN="center">NSN</TD>
				<TD CLASS="helpBod" HEIGHT="16">Description</TD>
				<TD CLASS="helpBod" HEIGHT="16" ALIGN="left">Purch<BR>&nbsp;Unit</TD>
				<TD CLASS="helpBod" HEIGHT="16" ALIGN="left">Orig<BR>&nbsp;Supplier</TD>
				<TD CLASS="helpBod" HEIGHT="16" >Suggested<BR>Supplier</TD>
<!..Collecting supplier ids and names and initalising product detail arrays ..>		
			<%
			 
			  
				ArrayList listDummy=new ArrayList();
				
				for(int count=0;count<supcount;count++)
				{
					listDummy.Add("0");
				}
				string [] bcost=null;
				string [] mcost=null;
				string [] npa=null;
				string [] vdfee=null;
				string [] bdfee=null;
				string [] bpr=null;
				string [] punit=null;
				string [] ltime=null;
				string [] ltimevar=null;
				string [] Anlcriteria=null;
			
			%>
		
<!..main table header row ..>	

				
				<%
				for(int i=0;i<vdisp.Length;i++)
				
				{
					%>
					<TD CLASS="helpBod" HEIGHT="16" ><%=vdisp[i]%></TD>
					<%	
				}
				
				%>
				</TR>
<%			
//The main loop that spreads to the end
			for(int i=0;i<nsn.Length;i++)
			{
			ArrayList productdetls=getProductdetls(nsn[i]);
			
	
%>

<!..Collecting product records into arrays..>					
				<%
				string [] product=(String[])((ArrayList)productdetls[0]).ToArray(typeof(String));
				string [] desc=(String[])((ArrayList)productdetls[1]).ToArray(typeof(String));
				string [] stocknum=(String[])((ArrayList)productdetls[2]).ToArray(typeof(String));
				string [] purchunit=(String[])((ArrayList)productdetls[3]).ToArray(typeof(String));
				string [] warehouse=(String[])((ArrayList)productdetls[4]).ToArray(typeof(String));
				Double maxmarg=0;	
				int maxindex=-1;
				
				if(stocknum.Length>0)
				{
				
					maxmarg			= 0	;	  //stores maximum bmmi margin
					maxindex		= -1;	  //stores the index of the max margin supplier id in vid array
					string divid	= "div"+i; //div name that is dynamically generated for each division
					string secname	= "sec"+i; //section name (of  div) that id dynamically vreated
					
					bcost=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					mcost=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					npa=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					vdfee=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					bdfee=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					bpr=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					punit=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					ltime=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					ltimevar=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					ltimevar=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					Anlcriteria=(String[])((ArrayList)listDummy).ToArray(typeof(String));
					
					%>
<!..The first four columns of the main table..>	
						<tr>
							<TD CLASS="sup" HEIGHT="16" ><%=product[0]%></TD>
							<TD CLASS="sup" HEIGHT="16" ><A HREF="#<%=secname%>"
								ONCLICK="showhidetbl(<%=divid%>)"><%=stocknum[0]%></A></TD>
							<TD CLASS="sup" HEIGHT="16" ><%=desc[0]%></TD>
							<TD CLASS="sup" HEIGHT="16" ><%=purchunit[0]%></TD>
							<TD CLASS="sup" HEIGHT="16" ><%=getstockmsupplier(product[0],warehouse[0])%></TD>
						
<%
							origvendorlist+=getstockmsupplierid(product[0],warehouse[0])+"!";
							ArrayList DetlTblRecords=getDetlTblRecords(nsn[i]);
							if(DetlTblRecords.Count ==0)  
							{
								%>
								<TD CLASS="sup" HEIGHT="16" >N/A</TD>
								<%	
								for(int j=0;j<supcount;j++)
								{
								%>
									<TD CLASS="sup" HEIGHT="16" >N/A</TD>
								<%
								} //end of  for(int j=0;j<supcount;j++)%>
						
								<%
							} 
							else // if DetlTblRecords.Count !=0
							{

							string [] vendorid=(String[])((ArrayList)DetlTblRecords[0]).ToArray(typeof(String));
							string [] bmmicost=(String[])((ArrayList)DetlTblRecords[1]).ToArray(typeof(String));
							string [] mfgcost=(String[])((ArrayList)DetlTblRecords[2]).ToArray(typeof(String));
							string [] napa=(String[])((ArrayList)DetlTblRecords[3]).ToArray(typeof(String));
							string [] vendordistfee=(String[])((ArrayList)DetlTblRecords[4]).ToArray(typeof(String));
							string [] bmmidistfee=(String[])((ArrayList)DetlTblRecords[5]).ToArray(typeof(String));
							string [] bmmicurrprice=(String[])((ArrayList)DetlTblRecords[6]).ToArray(typeof(String));
							string [] purchaseunit=(String[])((ArrayList)DetlTblRecords[7]).ToArray(typeof(String));
							string [] leadtime=(String[])((ArrayList)DetlTblRecords[8]).ToArray(typeof(String));
							string [] leadtimevar=(String[])((ArrayList)DetlTblRecords[9]).ToArray(typeof(String));
							
//Collecting product record arrays into distinct cells of local arrays						

							for(int j=0;j<vendorid.Length;j++)  
							{ 
								string supid	=	vendorid[j];
								int vindex		=	findIndex(vid,supid);
									
									
										if (vindex >=0) //if bmmidfee(j)>maxmarg then line 303
										{
											bcost[vindex]	=	bmmicost[j];
											mcost[vindex]	=	mfgcost[j];
											npa[vindex]		=	napa[j];
											vdfee[vindex]	=	vendordistfee[j];
											bdfee[vindex]	=   bmmidistfee[j];
											bpr[vindex]		=   bmmicurrprice[j];		
											punit[vindex]	=   purchaseunit[j];
											ltime[vindex]	=	leadtime[j];
											ltimevar[vindex]=	leadtimevar[j];
										}
	
										criteria=rdoCriteria.SelectedValue;
//if analysed by margin then choose the supplier providing highest margin										
										if(criteria=="margin")
										{
										
											bdfee.CopyTo (Anlcriteria,0);
										//	maxmarg=Convert.ToDouble(Anlcriteria[0]);
											for (int marg=0;marg<supcount;marg++)
											{
												if(Anlcriteria[marg]=="")Anlcriteria[marg]="0";
												
												if (Convert.ToDouble(Anlcriteria[marg]) >0 && Convert.ToDouble(Anlcriteria[marg])>maxmarg) 
												{
														
														maxindex=marg;
												}
												maxmarg=Convert.ToDouble(Anlcriteria[marg]);
				
											}	
									
										}
//if analysed by margin then choose the supplier providing minimum leadtime
										
										else if (criteria=="leadtime")
										{
										
										ltime.CopyTo (Anlcriteria,0);
									//	maxmarg=Convert.ToDouble(Anlcriteria[0]);
										for (int marg=0;marg<supcount;marg++)
											{
												if(Anlcriteria[marg]=="")Anlcriteria[marg]="0";
												if(maxmarg<=0) 
												{
													maxmarg=Convert.ToDouble(Anlcriteria[marg]);
												}
												if ((Convert.ToDouble(Anlcriteria[marg])>0) && Convert.ToDouble(Anlcriteria[marg])<=maxmarg) 
												{
														
														maxindex=marg;
												}
												if(Convert.ToDouble(Anlcriteria[marg])>0)
												{
													maxmarg=Convert.ToDouble(Anlcriteria[marg]);
												}
				
											}	
											
										}
									
									}
				
%>
<!..Drop down list of preferred suppliers to change (fifth cell)>							
		<TD CLASS="sup" HEIGHT ="16"> 
			<SELECT class="selectstyle" style="width:90px;" NAME="<%="PS"+i%>"  ID="<%="PS"+i%>" onchange ="showremarks (<%=divid%>,<%=i%>)" >
<%
				for(int inc=0;inc<supcount;inc++)
				{
					if(Anlcriteria[inc]=="")Anlcriteria[inc]="0";
					if (Convert.ToDouble(Anlcriteria[inc])>0)
					{
						if (inc==maxindex)
						{	
%>
							<OPTION VALUE="<%=vid[inc]%>" SELECTED><%=vdisp[inc]%></OPTION>
<%
						}
						else
						{
%>
							<OPTION VALUE="<%=vid[inc]%>"><%=vdisp[inc]%></option>
<%
						}
						
					} 
				
				}
%>
			</SELECT>
		</TD>
<!..Display remaining cells in the main table (after the drop down list)  >							
<%
					for(int n=0;n<supcount;n++)
					{
						if (maxindex==n) 
						{	
						%>
							<TD CLASS="sup" HEIGHT="16"><B><FONT COLOR =#ff0033><%=Anlcriteria[n]%></FONT></B></TD>
						<%
						}
						else
						{
						%>
							<TD CLASS="sup" HEIGHT="16"><%=Anlcriteria[n]%></TD>
						<%
						} 
				 }		
%> 
				
<!.. inner table header row..>				
				
		<TR>
		<TD CLASS="sup" STYLE="border-right:0px" COLSPAN="2" BGCOLOR="white"></TD> 
		<TD CLASS="sup" STYLE="border-left:0px" COLSPAN="<%=3+supcount%>" >
			<A NAME="<%=secname%>"></A></H2>
			<DIV CLASS="divclass" ID="<%=divid%>" STYLE="DISPLAY: none">
			<BR>
			<CENTER ><TABLE ID="Table2" CLASS="sofT" BORDER="0" CELLSPACING="0">
				<TR>
					<TD CLASS="innertitle2" HEIGHT="16">supplier</TD>
					<TD CLASS="innertitle2" HEIGHT="16">Purchase Unit</TD>
					<TD CLASS="innertitle2" HEIGHT="16">MFG cost</TD>
					<TD CLASS="innertitle2" HEIGHT="16">NAPA</TD>
					<TD CLASS="innertitle2" HEIGHT="16">Vendor dist</TD>
					<TD CLASS="innertitle2" HEIGHT="16">BMMI cost</TD>
					<TD CLASS="innertitle2" HEIGHT="16">BMMI Dist Fee</TD>
					<TD CLASS="innertitle2" HEIGHT="16">BMMI Price</TD>
					<TD CLASS="innertitle2" HEIGHT="16">Lead Time</TD>
					<TD CLASS="innertitle2" HEIGHT="16">Lead Time Var</TD>
				</TR>
				
<!..loop for the inner table detail rows.. >
				<%for (int p=0;p<supcount;p++)
				  {
					
					if (p==maxindex) 
					{
					%>
						<TR>
						
							<TD CLASS="splcell" HEIGHT="16"><%=vdisp[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=punit[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=mcost[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=npa[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=vdfee[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=bcost[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=bdfee[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=bpr[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=ltime[p]%></TD>
							<TD CLASS="splcell" HEIGHT="16"><%=ltimevar[p]%></TD>
						</TR>
					<%
					}
					else
					{
					%>
						<TR>
							<TD CLASS="incontblk" HEIGHT="16"><%=vdisp[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=punit[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=mcost[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=npa[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=vdfee[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=bcost[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=bdfee[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=bpr[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=ltime[p]%></TD>
							<TD CLASS="incontblk" HEIGHT="16"><%=ltimevar[p]%></TD>
						</TR>
					<%
					} //if p=maxindex
					%>
					<tr>
					<td></td>
					</tr>
					<%
				}   // for (int p=0;p<supcount;p++)
				%>
			</TABLE>
			</CENTER>
		<p align =center>
		<SELECT class="selectstyle" style="width:200px;" NAME="<%="REM"+i%>"  ID="<%="REM"+i%>" >
<%
ArrayList PAremarks=collectPARemarks();
string [] Remid=(String[])((ArrayList)PAremarks[0]).ToArray(typeof(String));
string [] Remarks=(String[])((ArrayList)PAremarks[1]).ToArray(typeof(String));
				
				for(int inc=-1;inc<Remid.Length;inc++)
				{
						if(inc==-1)
						{	
%>
							<OPTION VALUE="0" SELECTED>Reason for Supplier Change</OPTION>
<%
						}
						else
						{
%>
							<OPTION VALUE="<%=Remid[inc]%>"><%=Remarks[inc]%></option>
<%
						}
						
					} 
				
				
%>
		</SELECT>
		</p>




		<BR>
		</DIV>
		
		</TD>
		</tr> 
		<%
							}	//else if DetlTblRecords.Count !=0
					
				}//if(stocknum.Length>0)
		
	%>

			
		
	<%	 
		
	
	}//end of for(int insn=0;insn<nsn.Length;insn++)
	%>
		<TR>
	<TD COLSPAN="<%=5+supcount%>" class="sup">
		<CENTER >
			<INPUT class="btn" type =submit  runat =server  VALUE="Save" id=btnSave NAME=btnSave onclick =collectVendorsRemarks() onserverclick =SavePA>
			
			<input type =hidden  value="" name ="RVALUES" id="RVALUES">
			<input type =hidden value="" name ="PVALUES" id="PVALUES">
		</CENTER>
		
	</TD>
	</tr>
	<tr>
	<td COLSPAN="<%=6+supcount%>" class="sup">
	<asp:Label cssclass=FormLabels runat =server id=lblSaveResult></asp:Label>
	</td>
	</TR>
</TABLE>
<%
 } // end if (supcount >0)
			
%>
</asp:Panel>
</form>
</body>
</HTML>
