//The following line is critical for menu operation, and MUST APPEAR ONLY ONCE. 
//If you have more than one menu_array.js file rem out this line in subsequent files
menunum=0;menus=new Array();_d=document;
function addmenu(){menunum++;menus[menunum]=menu;}
function dumpmenus(){
document.write("<BR>")
	mt="<script language=javascript>";
	for(a=1;a<menus.length;a++)
		{
			mt+=" menu"+a+"=menus["+a+"];"
		}
	mt+="<\/script>";_d.write(mt)
	}
//Please leave the above line intact. The above also needs to be enabled 
//if it not already enabled unless this file is part of a multi pack.

////////////////////////////////////
// Editable properties START here //
////////////////////////////////////

if(navigator.appVersion.indexOf("MSIE 6.0")>0)
{
	effect = "Fade(duration=0.2);Alpha(style=0,opacity=88);Shadow(color='#777777', Direction=135, Strength=5)"
}
else
{
	effect = "Shadow(color='#777777', Direction=135, Strength=5)" // Stop IE5.5 bug when using more than one filter
}


timegap=500								// The time delay for menus to remain visible
followspeed=5							// Follow Scrolling speed
followrate=40							// Follow Scrolling Rate
suboffset_top=10;						// Sub menu offset Top position 
suboffset_left=10;						// Sub menu offset Left position

style1=[						
		"navy",							// Mouse Off Font Color
		"ccccff",						// Mouse Off Background Color
		"ffebdc",						// Mouse On Font Color
		"4b0082",						// Mouse On Background Color
		"ffffff",						// Menu Border Color 
		12,								// Font Size in pixels
		"normal",						// Font Style (italic or normal)
		"normal",						// Font Weight (bold or normal)
		"Arial, Helvetica, sans-serif",	// Font Name
		3,								// Menu Item Padding
		"images/arrow.gif",				// Sub Menu Image (Leave this blank if not needed)
		,								// 3D Border & Separator bar
		"666666",						// 3D High Color
		"000099",						// 3D Low Color
		"Purple",						// Current Page Item Font Color (leave this blank to disable)
		"pink",							// Current Page Item Background Color (leave this blank to disable)
		"images/arrowdn.gif",			// Top Bar image (Leave this blank to disable)
		"ffffff",						// Menu Header Font Color (Leave blank if headers are not needed)
		"000099",						// Menu Header Background Color (Leave blank if headers are not needed)
		]

style2=[								// style1 is an array of properties.
		"navy",							// Mouse Off Font Color
		"EDD5ED",						// Mouse Off Background Color
		"ffebdc",						// Mouse On Font Color
		"996699",						// Mouse On Background Color
		"ffffff",						// Menu Border Color 
		12,								// Font Size in pixels
		"normal",						// Font Style (italic or normal)
		"normal",						// Font Weight (bold or normal)
		"Arial, Helvetica, sans-serif",	// Font Name
		3,								// Menu Item Padding
		"images/arrow.gif",				// Sub Menu Image (Leave this blank if not needed)
		,								// 3D Border & Separator bar
		"666666",						// 3D High Color
		"000099",						// 3D Low Color
		"Purple",						// Current Page Item Font Color (leave this blank to disable)
		"pink",							// Current Page Item Background Color (leave this blank to disable)
		"images/arrowdn.gif",			// Top Bar image (Leave this blank to disable)
		"ffffff",						// Menu Header Font Color (Leave blank if headers are not needed)
		"000099",						// Menu Header Background Color (Leave blank if headers are not needed)
		]

style3=[								// style1 is an array of properties.
		"navy",							// Mouse Off Font Color
		"FFDCC4",						// Mouse Off Background Color
		"ffebdc",						// Mouse On Font Color
		"EFA470",						// Mouse On Background Color
		"ffffff",						// Menu Border Color 
		12,								// Font Size in pixels
		"normal",						// Font Style (italic or normal)
		"normal",						// Font Weight (bold or normal)
		"Arial, Helvetica, sans-serif",	// Font Name
		3,								// Menu Item Padding
		"images/arrow.gif",				// Sub Menu Image (Leave this blank if not needed)
		,								// 3D Border & Separator bar
		"666666",						// 3D High Color
		"000099",						// 3D Low Color
		"Purple",						// Current Page Item Font Color (leave this blank to disable)
		"pink",							// Current Page Item Background Color (leave this blank to disable)
		"images/arrowdn.gif",			// Top Bar image (Leave this blank to disable)
		"ffffff",						// Menu Header Font Color (Leave blank if headers are not needed)
		"000099",						// Menu Header Background Color (Leave blank if headers are not needed)
		]

style4=[								// style1 is an array of properties.by shatlin
		"000000",						// Mouse Off Font Color
		"A5C7E7",						// Mouse Off Background ColorA5C7E7
		"ffffff",						// Mouse On Font Color
		"31659C",						// Mouse On Background Color
		"ffffff",						// Menu Border Color 
		10,								// Font Size in pixels
		"normal",						// Font Style (italic or normal)
		"bold",							// Font Weight (bold or normal)
		"Verdana",						// Font Name
		2,								// Menu Item Padding
		"images/arrow.gif",				// Sub Menu Image (Leave this blank if not needed)
		,								// 3D Border & Separator bar
		"111111",						// 3D High Color
		"cccccc",						// 3D Low Color
		,								// Current Page Item Font Color (leave this blank to disable)
		,								// Current Page Item Background Color (leave this blank to disable)
		"images/arrowdn.gif",			// Top Bar image (Leave this blank to disable)
		"000000",						// Menu Header Font Color (Leave blank if headers are not needed)
		"000099",						// Menu Header Background Color (Leave blank if headers are not needed)
		]


		
addmenu(menu=[		// This is the array that contains your menu properties and details
"mainmenu",			// Menu Name - This is needed in order for the menu to be called
5,					// Menu Top - The Top position of the menu in pixels
10,					// Menu Left - The Left position of the menu in pixels
,					// Menu Width - Menus width in pixels
1,					// Menu Border Width 
,					// Screen Position - here you can use "center;left;right;middle;top;bottom" or a combination of "center:middle"
style4,				// Properties Array - this is set higher up, as above
1,					// Always Visible - allows the menu item to be visible at all time (1=on/0=off)
"left",				// Alignment - sets the menu elements text alignment, values valid here are: left, right or center
effect,				// Filter - Text variable for setting transitional effects on menu activation - see above for more info
,					// Follow Scrolling - Tells the menu item to follow the user down the screen (visible at all times) (1=on/0=off)
1, 					// Horizontal Menu - Tells the menu to become horizontal instead of top to bottom style (1=on/0=off)
0,					// Keep Alive - Keeps the menu visible until the user moves over another menu or clicks elsewhere on the page (1=on/0=off)
,					// Position of TOP sub image left:center:right
,					// Set the Overall Width of Horizontal Menu to 100% and height to the specified amount (Leave blank to disable)
,					// Right To Left - Used in Hebrew for example. (1=on/0=off)
,					// Open the Menus OnClick - leave blank for OnMouseover (1=on/0=off)
,					// ID of the div you want to hide on MouseOver (useful for hiding form elements)
,					// Reserved for future use
,					// Reserved for future use
,					// Reserved for future use

//,"&nbsp;&nbsp;&nbsp;Selection Methods&nbsp;&nbsp;&nbsp;"," ","","",1 // "Description Text", "URL", "Alternate URL", "Status", "Separator Bar"
,"&nbsp;&nbsp;&nbsp;&nbsp;PURCHASE ANALYSIS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","show-menu=purchase",,"",1
,"&nbsp;&nbsp;&nbsp;&nbsp;ORDER TRACKING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","show-menu=order",,"",1
,"&nbsp;&nbsp;&nbsp;&nbsp;HOUSE KEEPING&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","show-menu=housekeeping",,"",1
,"&nbsp;&nbsp;&nbsp;&nbsp;OUTBOUND&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","show-menu=Outbound",,"",1



//,"&nbsp;&nbsp;&nbsp;&nbsp;Institute&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;","show-menu=Institute",,"",1

])

	addmenu(menu=["purchase",,,145,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"&nbsp; Selection methods","show-menu=selection",,,1
	,"&nbsp; Cost ","show-menu=cost",,,1
	])
	
	addmenu(menu=["Selection",,,145,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"&nbsp; A NSN","PVPAone01.asp",,,1
	,"&nbsp;Select Product","PVPAsel01.asp",,,1
	,"&nbsp;Select By WareHouse","PVPAware01.asp",,,1
	,"&nbsp;Select By supplier","PVPAsup01.asp",,,1
	])
	
	addmenu(menu=["cost",,,145,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"&nbsp; Upload","pvcostUPL01.ASP",,,1
	,"&nbsp;Process cost details","pvcostindir.asp",,,1
	,"&nbsp;view uploaded data","PVCOSTVIEW01.asp",,,1
	,"&nbsp;delete uploaded data","PVCOSTDEL01.ASP",,,1
	
	])
	
	
	addmenu(menu=["upload",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"ASN","PVASNUPL01.asp",,,1
	
	,"SHIPPING PLAN","PVSHIPUPL01.ASP",,,1
	])		

	addmenu(menu=["order",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"Upload File","show-menu=upload",,,1
	,"Process File","show-menu=fileprocess",,,1
	,"Track Orders by","show-menu=orderchoice",,,1
	,"Close","show-menu=close",,,1
	,"View Uploaded Data","show-menu=view",,,1
	,"Delete Uploaded Data","show-menu=delete",,,1
	
	])		
	

	addmenu(menu=["orderchoice",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	," Product","PVOTPRD01.aspx",,,1
	," Order","PVOTPRDORD.aspx",,,1
	," Supplier","PVOTSUP.aspx",,,1
	])		
	
addmenu(menu=["HouseKeeping",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"Add/Modify Supplier","ModifySupplier.aspx",,,1
	,"Pallette Container ","show-menu=pallette",,,1
	,"Upload/Process RF ","PVFILEUPL.aspx",,,1
	
	])		

addmenu(menu=["pallette",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"Pallette-Case Matrix","pvcasemod.aspx",,,1
	,"Container-Pallette Matrix","pvpalmod.aspx",,,1
	,"Special Dodaac","pvpaldodmod.aspx",,,1
	])		
	
	addmenu(menu=["close",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	," ASN against GRN","PVASNNUL01.ASP",,,1
	])		

	addmenu(menu=["View",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
		
		," ASN","PVASNVIEW01.ASP",,,1
		," Shipping Plan","PVSHIPVIEW01.asp",,,1
	])		
	
	addmenu(menu=["delete",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
		
		,"ASN","PVASNDEL01.ASP",,,1
		," Shipping Plan","PVSHIPDEL01.asp",,,1
	])		
	
	
	addmenu(menu=["fileprocess",,,150,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	," ASN","pvasnindir.asp",,,1
	
	," SHIPPING PLAN","pvshipindir.asp",,,1
	])		

addmenu(menu=["Outbound",,,160,1,"",style4,,"left",effect,,,,,,,,,,,,
	
	,"Allocation Status","PVOPSAStatus.aspx",,,1
	,"Allocation Status - Product","PVOPSAStatusDetail.aspx",,,1
	,"NIS - List","PVOPNISList.aspx",,,1
	])		
	

dumpmenus()




