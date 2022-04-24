function CheckMaxLength(field, maxlimit) 
{
	if (field.value.length > maxlimit)
	{
		field.value = field.value.substring(0, maxlimit);
	}
}

function MapImagePath(sitePath, imageName) 
{
	return sitePath + imageName;
}

function MapPath(sitePath, url) 
{
	return sitePath + url;
}

function HelpPopUp(sitePath, url) 
{
	var wndHelp = window.open(MapPath(sitePath, url), "SCORECARDHELP", "width=400,height=700,menubar,scrollbars,toolbar,resizable");
    wndHelp.focus();
}

function ScorecardTableCollapseAll(sitePath, beginWithId, rootId) 
{
	var trs = document.getElementsByTagName('tr');
	for (i = 0; i < trs.length; i++) 
	{
		if (ScorecardPreivewIsElement(trs[i]) && trs[i].KpiId.indexOf(beginWithId) > -1) 
		{	
			if (trs[i].KpiId != beginWithId + rootId) 
			{
				var image = ScorecardPreviewGetImage(trs[i]);	
				if (image != null)			
					image.src = MapImagePath(sitePath,'Plus.gif');
				trs[i].Expanded = 'false';		
				trs[i].style.display = 'none';				
			}
			else 
			{
				trs[i].Expanded = 'false';
				ScorecardPreviewGetImage(trs[i]).src = MapImagePath(sitePath, 'Plus.gif');	
			}
		}
	}
}

function ScorecardTableExpandAll(sitePath, beginWithId, rootId) {
	var trs = document.getElementsByTagName('tr');
	for (i = 0; i < trs.length; i++) 
	{
		if (ScorecardPreivewIsElement(trs[i]) && trs[i].KpiId.indexOf(beginWithId) > -1) 
		{	
			if (trs[i].KpiId != beginWithId + rootId) 
			{
				var image = ScorecardPreviewGetImage(trs[i]);
				if (image != null)				
					image.src = MapImagePath(sitePath, 'Minus.gif');
				trs[i].Expanded = 'true';
				trs[i].style.display = 'inline';				
			}
			else 
			{
				trs[i].Expanded = 'true';
				ScorecardPreviewGetImage(trs[i]).src = MapImagePath(sitePath, 'Minus.gif');	
			}
		}
	}
}

function ScorecardPreviewToggle(imagePath) 
{
	var toggle_icon = window.event.srcElement;
	var toggle_src = ScorecardPreivewGetElement(toggle_icon);
	ScorecardPreviewToggleParams(imagePath, toggle_icon, toggle_src);
}

function ScorecardPreviewToggleParams(imagePath, toggle_icon, toggle_src) 
{
	var trs = document.getElementsByTagName('tr');
	for (i = 0; i < trs.length; i++) 
	{
		if (trs[i].KpiParentId) 
		{
			if (trs[i].KpiParentId == toggle_src.KpiId) 
			{
				if (toggle_src.Expanded == 'false') 
				{
					trs[i].style.display = 'inline';
					ScorecardPreivewShowChildren(trs[i], trs);
				}
				else 
				{
					trs[i].style.display = 'none';
					ScorecardPreivewHideChildren(trs[i], trs);
				}
			}
		}
	}

	if (toggle_src.Expanded == 'false') 
	{
		toggle_icon.src = imagePath + 'Minus.gif';
		toggle_src.Expanded = 'true';
	}
	else 
	{
		toggle_icon.src = imagePath + 'Plus.gif';
		toggle_src.Expanded = 'false';
	}
}

function  ScorecardPreivewHideChildren(src, trs) 
{
	var j = 0;
	for (j = 0; j < trs.length; j++) 
	{
		if (trs[j].KpiParentId) 
		{
			if (trs[j].KpiParentId == src.KpiId) 
			{
				trs[j].style.display = 'none';
				ScorecardPreivewHideChildren(trs[j], trs);
			}
		}
	}
}

function ScorecardPreivewShowChildren(src, trs) 
{
	if (src.Expanded == 'false') 
	{
		return;
	}	
	
	var j = 0;
	for (j = 0; j < trs.length; j++) 
	{
		if (trs[j].KpiParentId) 
		{
			if (trs[j].KpiParentId == src.KpiId) 
			{
				trs[j].style.display = 'inline';
				ScorecardPreivewShowChildren(trs[j], trs);
			}
		}
	}
}

function ScorecardPreivewGetElement(src) 
{
	var parentSrc = src;
	while (parentSrc != null && !ScorecardPreivewIsElement(parentSrc))
	{
		parentSrc = parentSrc.parentElement;
	}
	
	return parentSrc;
}

function ScorecardPreivewIsElement(src) 
{
	if (src.KpiId) 
		return true;
	else
		return false;
}

function ScorecardPreviewGetImage(src) 
{
	var imageSrc = src;
	
	while (imageSrc != null && imageSrc.tagName != "IMG") {
		imageSrc = imageSrc.firstChild;
	}
	
	return imageSrc;
}

function ToggleFoldablePanel(sitePath, id) 
{
	var divTag = document.getElementById(id + '_div');
	var hiddenDivTag = document.getElementById(id + '_hidden');
	var imageTag = document.getElementById(id + '_img');
	if (divTag.style.display == 'none')
	{
		imageTag.src= MapPath(sitePath, 'TPMin1.gif');
		divTag.style.display = '';
		hiddenDivTag.style.display = 'none';
		SetCookie(id, 'false');
	}
	else
	{
		imageTag.src= MapPath(sitePath, 'TPMax1.gif');
		divTag.style.display = 'none';
		hiddenDivTag.style.display = '';
		SetCookie(id, 'true');
	}
}

function InitializeFoldablePanel(id) 
{
	var isFolded = GetCookie(id);
	if ('true' == isFolded) ToggleFoldablePanel(id);
}

function SetCookie(attr, value)
{
	document.cookie = attr + '=' + value;
}

function GetCookie(attrToFind)
{
	var allcookies = document.cookie;
	var elementName = attrToFind + '=';
	var pos = allcookies.indexOf(elementName);
	var value = '';

	if (pos != -1)
	{
		var start = pos + attrToFind.length + 1;
		var end = allcookies.indexOf(';', start);
		value = allcookies.substring(start, end);
	}
	
	return value;
}

function BITreeNodeToggle(sitePath) 
{
	var toggle_icon = window.event.srcElement;
	var toggle_src = BITreeNodeGetElement(toggle_icon)
	BITreeNodeToggleParams(sitePath, toggle_icon, toggle_src);
}

function BITreeNodeToggleParams(sitePath, toggle_icon, toggle_src_orgin) 
{
	var toggle_src = toggle_src_orgin.nextSibling;
	if (toggle_src.style.display == 'none')
	{
		toggle_src.style.display = 'inline';
		toggle_icon.src = MapImagePath(sitePath, 'Minus.gif');
		SetCookie(toggle_src_orgin.BITreeId + '_' + toggle_src_orgin.BITreeNodeId, 'true')
	}
	else
	{
		toggle_src.style.display = 'none';
		toggle_icon.src = MapImagePath(sitePath, 'Plus.gif');
		SetCookie(toggle_src_orgin.BITreeId + '_' + toggle_src_orgin.BITreeNodeId, 'false')
	}
}

function  BITreeNodeGetElement(src) 
{
	var parentSrc = src;
	while (parentSrc != null && !BITreeNodeIsElement(parentSrc))
	{
		parentSrc = parentSrc.parentElement;
	}
	
	return parentSrc;
}

function BITreeNodeIsElement(src) 
{
	if (src.BITreeNode) 
		return true;
	else
		return false;
}

function  BITreeNodeGetImage(src) 
{
	return src.children[0].children[0].children[0].children[0].children[0];
}

function InitializeBITree(sitePath, treeId) 
{
	var treeElement = document.getElementById(treeId);
	var divs = treeElement.getElementsByTagName('div');
	for (i = 0; i < divs.length; i++) 
	{
		if (BITreeNodeIsElement(divs[i])) 
		{
			if (('true' == GetCookie(divs[i].BITreeId + '_' + divs[i].BITreeNodeId)) &&  ('false' == divs[i].BITreeNodeExpaneded)) 
			{
				BITreeNodeToggleParams(sitePath, BITreeNodeGetImage(divs[i]), divs[i]);
			}
		}
	}
}

function DimensionSlicerPopup(sitePath, hiddenUniqueBox, hiddenNameBox, labelBox, dataSourceId, dimensionName, sliceUniqueName, sliceName, loadingText) 
{
	if (document.getElementById(hiddenUniqueBox).value != "")
	{
		sliceUniqueName = document.getElementById(hiddenUniqueBox).value;
	}

	var _props = "dialogWidth: 300px; dialogHeight: 420px; resizable:yes; center:yes; scroll:no; status: no; help: no;";
	var _dialogParams = new Object();
	_dialogParams.url = MapPath(sitePath, 'PageFilterPopup.aspx?DataSourceId=' + dataSourceId + '&DimensionName=' + dimensionName + '&SliceSelected=' + sliceUniqueName);
	_dialogParams.opener = window;
	_dialogParams.DimensionName = dimensionName;
	_dialogParams.LoadingText = loadingText;
	
	var returnValue = window.showModalDialog(MapPath(sitePath, 'popup.aspx'), _dialogParams, _props);	
	
	if (!(returnValue == null || returnValue.length == 0)) 
	{		
		document.getElementById(hiddenUniqueBox).value = encodeURIComponent(unescape(returnValue.SliceUniqueName));
		document.getElementById(hiddenNameBox).value = encodeURIComponent(DimensionSlicerTruncate(unescape(returnValue.SliceName)));	
		document.getElementById(labelBox).innerText = DimensionSlicerTruncate(unescape(returnValue.SliceName));	
	}
	
	return returnValue;
}

function DimensionSlicerPopup2(sitePath, ahref, hiddenUniqueBox, hiddenNameBox, labelBox, dataSourceId, dimensionName, sliceUniqueName, sliceName, loadingText)
{
	var returnValue = DimensionSlicerPopup(sitePath, hiddenUniqueBox, hiddenNameBox, labelBox, dataSourceId, dimensionName, sliceUniqueName, sliceName, loadingText)
	
	if (!(returnValue == null || returnValue.length == 0)) 
	{
		var linkButton = ahref.nextSibling;
		linkButton.click();
	}
}

function DimensionSlicerSelect(atag) 
{
	var parentTag = DimensionSliceGetSlice(atag);
	var myTables = document.getElementsByTagName('table');
	
	if (parentTag.SliceSelected && parentTag.SliceSelected == "true") 
	{
		parentTag.SliceSelected = "false";
		parentTag.className = "";
	}	
	else 
	{	
		for (i = 0; i < myTables.length; i++) 
		{	
			if (DimensionSlicerIsSlice(myTables[i])) 
			{
				myTables[i].className = "";		
				myTables[i].SliceSelected = "false";		
			}
		}					
	
		parentTag.SliceSelected = "true";
		parentTag.className = "UserCellSelected";
	}			
}

function DimensionSlicerIsSlice(src) 
{
	if (src.Slice) 
		return true;
	else
		return false;
}

function  DimensionSliceGetSlice(src) 
{
	var parentSrc = src;
	while (parentSrc != null && !DimensionSlicerIsSlice(parentSrc))
	{
		parentSrc = parentSrc.parentElement;
	}
	
	return parentSrc;
}

function DecodeSingleQuote(inStr) 
{
	return inStr.replace("&apos;", "'");
}	

function DimensionSlicerSetReturnValue()
{
	var myTables = document.getElementsByTagName('table');
	for (i = 0; i < myTables.length; i++) 
	{	
		if (DimensionSlicerIsSlice(myTables[i]) && myTables[i].SliceSelected == "true") 
		{		
			var returnParams = new Object();
			returnParams.SliceUniqueName = escape(DecodeSingleQuote(myTables[i].Slice));
			returnParams.SliceName = escape(DecodeSingleQuote(myTables[i].SliceName));
			window.returnValue = returnParams;
			return;
		}		
	}
	
	var returnParams = new Object();
	returnParams.SliceUniqueName = "";
	returnParams.SliceName = "";
	window.returnValue = returnParams;			
}

function DimensionSlicerSetEmptyReturnValue()
{
	var returnParams = new Object();
	returnParams.SliceUniqueName = "";
	returnParams.SliceName = "";
	window.returnValue = returnParams;			
}

function DimensionSlicerToggle(sitePath, paramString) 
{
	var toggle_icon = window.event.srcElement;
	var toggle_src1 = BITreeNodeGetElement(toggle_icon)	
	var child_src = toggle_src1.nextSibling;
	
	if (child_src.style.display == "none") 
	{
		if (child_src.getAttribute("loaded") == "false") 
		{
			child_src.innerHTML = "<div error=\"true\" class=\"ms-forminput\" style=\"MARGIN-LEFT:20px;\">Loading...</div>";
			var xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
			var strUrl = MapPath(sitePath, "PageFilterPopupPartial.aspx?" + paramString);									
			xmlHttp.open("GET", strUrl, false);			
			xmlHttp.send();			
			child_src.innerHTML = xmlHttp.responseText;

			child_src.setAttribute("loaded", "true");						
		}
	}
	
	BITreeNodeToggleParams(sitePath, toggle_icon, toggle_src1);
}

function DimensionSlicerTruncate(dimStr) 
{	
	var truncateDimStr = "";
					
	if (dimStr == null || dimStr.length == 0) 
	{
		truncateDimStr = " ";
	}	
	else
	{
		var periodPos = dimStr.lastIndexOf(".");
		if (periodPos >= 0 && periodPos < dimStr.length -1)
		{
			truncateDimStr = dimStr.substring(periodPos+1);
		}
		else
		{
			truncateDimStr = dimStr;
		}
	}
	
	if (truncateDimStr.length >= 25) 
	{
		truncateDimStr = "..." + truncateDimStr.substring(truncateDimStr.length - 24);
	}
	
	return truncateDimStr;
}

function CustomViewDesignToggle(sitePath, paramString) 
{
	var toggle_icon = window.event.srcElement;
	var toggle_src1 = BITreeNodeGetElement(toggle_icon)	
	var child_src = toggle_src1.nextSibling;
	
	if (child_src.style.display == "none") 
	{
		if (child_src.getAttribute("loaded") == "false") 
		{
			child_src.innerHTML = "<div error=\"true\" class=\"ms-forminput\" style=\"MARGIN-LEFT:20px;\">Loading...</div>";
			var xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
			var strUrl = MapPath(sitePath, "DimensionValuesPartial.aspx?" + paramString);									
			xmlHttp.open("GET", strUrl, false);			
			xmlHttp.send();			
			child_src.innerHTML = xmlHttp.responseText;

			child_src.setAttribute("loaded", "true");						
		}
	}
	
	BITreeNodeToggleParams(sitePath, toggle_icon, toggle_src1);
}

function CustomViewDesignFindImage(src) 
{	
	var childSrc = src;
	while (childSrc != null && childSrc.tagName != "IMG")
	{	
		childSrc = childSrc.firstChild;
	}
	
	return childSrc;
}

function CustomViewDimensionChecked(sitePath, atag) 
{
	var sliceTag = DimensionSliceGetSlice(atag);
	var imageTag = CustomViewDesignFindImage(atag.previousSibling.previousSibling);
	var myTables = document.getElementsByTagName('table');
	
	if (sliceTag.SliceSelected == "true") 
	{
		sliceTag.SliceSelected = "false";		
		imageTag.src = MapImagePath(sitePath, "CheckOpen.gif");
				
		var parnetTag = CustomViewGetParent(myTables, sliceTag);
		
		// run up the tree seeing if each level has other selected
		while (parnetTag != null) 
		{															
			if (CustomViewHasChildrenChecked(myTables, parnetTag))
				break; 
				
			parnetTag.SliceSelected = "false";		
			CustomViewDesignFindImage(parnetTag).src = MapImagePath(sitePath, "CheckOpen.gif");	
			
			parnetTag = CustomViewGetParent(myTables, parnetTag);
		}	
	}	
	else if (sliceTag.SliceSelected == "partial") 
	{	
		CustomViewUnCheckChildren(sitePath, myTables, sliceTag);
		
		sliceTag.SliceSelected = "true";		
		imageTag.src = MapImagePath(sitePath, "Check.gif");	
	}
	else 
	{				
		CustomViewCheck(sitePath, myTables, sliceTag, imageTag);
	}
}

function CustomViewUnCheckChildren(sitePath, myTables, sliceTagIn) 
{	
	var stack = new Array();
	stack.push(sliceTagIn);
	
	while (stack.length > 0) 
	{
		var sliceTag = stack.pop();
	
		for (i = 0; i < myTables.length; i++) 
		{	
			if (DimensionSlicerIsSlice(myTables[i]) && sliceTag.Slice == myTables[i].SliceParent) 
			{
				if (myTables[i].SliceSelected == "true" || myTables[i].SliceSelected == "partial")
				{			
					myTables[i].SliceSelected = "false";	
					var childImageTag = CustomViewDesignFindImage(myTables[i]);
					childImageTag.src = MapImagePath(sitePath, "CheckOpen.gif");		
					stack.push(myTables[i]);		
				}
			}		
		}
	}			
}

function CustomViewGetParent(myTables, itemTag) 
{
	var parentTag;
	var parentSlice = "";

	for (i = 0; i < myTables.length; i++) 
	{	
		if (DimensionSlicerIsSlice(myTables[i]) && itemTag.SliceParent == myTables[i].Slice) 
		{							
			parentTag = myTables[i];
			break;
		}		
	}
	
	return parentTag;	
}

function CustomViewHasChildrenChecked(myTables, itemTag) 
{
	for (i = 0; i < myTables.length; i++) 
	{	
		if (DimensionSlicerIsSlice(myTables[i]) && itemTag.Slice == myTables[i].SliceParent) 
		{		
			if (myTables[i].SliceSelected == "true" || myTables[i].SliceSelected == "partial")
				return true;					
		}
	}
	
	return false;	
}

function CustomViewCheck(sitePath, myTables, sliceTag, imageTag) 
{
	var parnetTag = CustomViewGetParent(myTables, sliceTag);

	while (parnetTag != null) 
	{																				
		parnetTag.SliceSelected = "partial";	
		var parentImageTag = CustomViewDesignFindImage(parnetTag);
		parentImageTag.src = MapImagePath(sitePath, "CheckGray.gif");	
		
		parnetTag = CustomViewGetParent(myTables, parnetTag);
	}			
	
	sliceTag.SliceSelected = "true";		
	imageTag.src = MapImagePath(sitePath, "Check.gif");	
}

function CustomViewGetDimensionValues(dimensionValues, dimensionDisplayValues, dimensionParentValues) 
{
	var returnValues = "";
	var returnDisplayValues = "";
	var returnParentValues = "";
	var myTables = document.getElementsByTagName('table');
	
	for (i = 0; i < myTables.length; i++) 
	{	
		if (DimensionSlicerIsSlice(myTables[i]) && (myTables[i].SliceSelected == "partial" || myTables[i].SliceSelected == "true")) 
		{			
			if (returnValues.length > 0) {
				returnValues += "|";
				returnDisplayValues += "|";
				returnParentValues += "|";
			}
			
			returnValues += myTables[i].Slice;
			returnDisplayValues += myTables[i].SliceDisplayName;
			returnParentValues += myTables[i].SliceParent;
		}
	}
	
	dimensionValues.value = returnValues;
	dimensionDisplayValues.value = returnDisplayValues;	
	dimensionParentValues.value = returnParentValues;
}


function SetFocusOnFirstInputElement() 
{
	var inputs = document.getElementsByTagName("input");
	if ( inputs )
	{
		var inputElement;
		for ( var i=0; i < inputs.length; i++ )
		{
			inputElement = inputs[i];
			if ( (inputElement.type != "hidden") && !inputElement.disabled )
			{	
				inputElement.focus();
				break;
			}
		}
	}
}

// SIG // Begin signature block
// SIG // MIIavAYJKoZIhvcNAQcCoIIarTCCGqkCAQExCzAJBgUr
// SIG // DgMCGgUAMGcGCisGAQQBgjcCAQSgWTBXMDIGCisGAQQB
// SIG // gjcCAR4wJAIBAQQQEODJBs441BGiowAQS9NQkAIBAAIB
// SIG // AAIBAAIBAAIBADAhMAkGBSsOAwIaBQAEFA+O7ymL//Xo
// SIG // kEoeI3GuH6iJy6qAoIIVlTCCA8QwggMtoAMCAQICEEe/
// SIG // GZXfjVJGQ/fbbUgNMaQwDQYJKoZIhvcNAQEFBQAwgYsx
// SIG // CzAJBgNVBAYTAlpBMRUwEwYDVQQIEwxXZXN0ZXJuIENh
// SIG // cGUxFDASBgNVBAcTC0R1cmJhbnZpbGxlMQ8wDQYDVQQK
// SIG // EwZUaGF3dGUxHTAbBgNVBAsTFFRoYXd0ZSBDZXJ0aWZp
// SIG // Y2F0aW9uMR8wHQYDVQQDExZUaGF3dGUgVGltZXN0YW1w
// SIG // aW5nIENBMB4XDTAzMTIwNDAwMDAwMFoXDTEzMTIwMzIz
// SIG // NTk1OVowUzELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZl
// SIG // cmlTaWduLCBJbmMuMSswKQYDVQQDEyJWZXJpU2lnbiBU
// SIG // aW1lIFN0YW1waW5nIFNlcnZpY2VzIENBMIIBIjANBgkq
// SIG // hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqcqypMzNIK8K
// SIG // fYmsh3XwtE7x38EPv2dhvaNkHNq7+cozq4QwiVh+jNtr
// SIG // 3TaeD7/R7Hjyd6Z+bzy/k68Numj0bJTKvVItq0g99bbV
// SIG // XV8bAp/6L2sepPejmqYayALhf0xS4w5g7EAcfrkN3j/H
// SIG // tN+HvV96ajEuA5mBE6hHIM4xcw1XLc14NDOVEpkSud5o
// SIG // L6rm48KKjCrDiyGHZr2DWFdvdb88qiaHXcoQFTyfhOpU
// SIG // wQpuxP7FSt25BxGXInzbPifRHnjsnzHJ8eYiGdvEs0dD
// SIG // mhpfoB6Q5F717nzxfatiAY/1TQve0CJWqJXNroh2ru66
// SIG // DfPkTdmg+2igrhQ7s4fBuwIDAQABo4HbMIHYMDQGCCsG
// SIG // AQUFBwEBBCgwJjAkBggrBgEFBQcwAYYYaHR0cDovL29j
// SIG // c3AudmVyaXNpZ24uY29tMBIGA1UdEwEB/wQIMAYBAf8C
// SIG // AQAwQQYDVR0fBDowODA2oDSgMoYwaHR0cDovL2NybC52
// SIG // ZXJpc2lnbi5jb20vVGhhd3RlVGltZXN0YW1waW5nQ0Eu
// SIG // Y3JsMBMGA1UdJQQMMAoGCCsGAQUFBwMIMA4GA1UdDwEB
// SIG // /wQEAwIBBjAkBgNVHREEHTAbpBkwFzEVMBMGA1UEAxMM
// SIG // VFNBMjA0OC0xLTUzMA0GCSqGSIb3DQEBBQUAA4GBAEpr
// SIG // +epYwkQcMYl5mSuWv4KsAdYcTM2wilhu3wgpo17IypMT
// SIG // 5wRSDe9HJy8AOLDkyZNOmtQiYhX3PzchT3AxgPGLOIez
// SIG // 6OiXAP7PVZZOJNKpJ056rrdhQfMqzufJ2V7duyuFPrWd
// SIG // tdnhV/++tMV+9c8MnvCX/ivTO1IbGzgn9z9KMIID/zCC
// SIG // AuegAwIBAgIQDekr8NTYKYgYMgUJXpp2iDANBgkqhkiG
// SIG // 9w0BAQUFADBTMQswCQYDVQQGEwJVUzEXMBUGA1UEChMO
// SIG // VmVyaVNpZ24sIEluYy4xKzApBgNVBAMTIlZlcmlTaWdu
// SIG // IFRpbWUgU3RhbXBpbmcgU2VydmljZXMgQ0EwHhcNMDMx
// SIG // MjA0MDAwMDAwWhcNMDgxMjAzMjM1OTU5WjBXMQswCQYD
// SIG // VQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24sIEluYy4x
// SIG // LzAtBgNVBAMTJlZlcmlTaWduIFRpbWUgU3RhbXBpbmcg
// SIG // U2VydmljZXMgU2lnbmVyMIIBIjANBgkqhkiG9w0BAQEF
// SIG // AAOCAQ8AMIIBCgKCAQEAslAoSN3TaHqEGERmdV1+xLif
// SIG // Yyb/PUOcfBE4ECVVc9l1J2n9TrkgXNMK+aAbKu1VViFh
// SIG // 2B7b5Lwza8fv3aM3ZY4bkwy2Ux5cfGY1XwWKRf52Tt9T
// SIG // gKKBIJ2uiFyiCPflMPnuIjdMQgrO38YfxNZV6YE/tVKj
// SIG // LKoBevKiqo01/p/mXWoFnz1r47+WwP7MYPlA5wegROuB
// SIG // UW6lKvK2ihAo7Y/cBqCGUJp7SggNMB3KEJ5r9+lYrgSp
// SIG // QJmyKOiPFqw841NvS9M1nbVvZB2zliy7Ped56216+Rbm
// SIG // Jq2v75lTt0Aslbh5qv7UUqspdH5C7DkeomoW5lm7JGjY
// SIG // AIBDEIeAawIDAQABo4HKMIHHMDQGCCsGAQUFBwEBBCgw
// SIG // JjAkBggrBgEFBQcwAYYYaHR0cDovL29jc3AudmVyaXNp
// SIG // Z24uY29tMAwGA1UdEwEB/wQCMAAwMwYDVR0fBCwwKjAo
// SIG // oCagJIYiaHR0cDovL2NybC52ZXJpc2lnbi5jb20vdHNz
// SIG // LWNhLmNybDAWBgNVHSUBAf8EDDAKBggrBgEFBQcDCDAO
// SIG // BgNVHQ8BAf8EBAMCBsAwJAYDVR0RBB0wG6QZMBcxFTAT
// SIG // BgNVBAMTDFRTQTIwNDgtMS01NDANBgkqhkiG9w0BAQUF
// SIG // AAOCAQEAh3hw2k5SASBb4HnJgjDE/bkZlr2RAMO9zc3G
// SIG // 9A7Y//lNwDNiMBHF9XQb1JLeX5wgE7F8Rb5QzYPngBeD
// SIG // pyeTZxNG+8q4mEEDzJtRWwWLf6hv8xtQGyQu8mmNbCL3
// SIG // u8oWle0MdMBod9nrmWKHwXOQ+Il0eiOro5h7l7H3jylx
// SIG // TS51G0hB2vC1DSBU1negl4Jjaf0Jz4rwdbsJm9n5EVUm
// SIG // mmEyvnoCsHuGvqLDiyIseNE1drySc1z5ueZMFQojzOTS
// SIG // 1DQuSUAVPA9geiTGpWbvls9w6z7n9A1+3NF8o3ZxacGc
// SIG // T0cwNSGxoq8aYjwr2Y6qKgd72BizXHvinaVv/jyJrTCC
// SIG // BBIwggL6oAMCAQICDwDBAIs8PIgR0T72Y+zfQDANBgkq
// SIG // hkiG9w0BAQQFADBwMSswKQYDVQQLEyJDb3B5cmlnaHQg
// SIG // KGMpIDE5OTcgTWljcm9zb2Z0IENvcnAuMR4wHAYDVQQL
// SIG // ExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xITAfBgNVBAMT
// SIG // GE1pY3Jvc29mdCBSb290IEF1dGhvcml0eTAeFw05NzAx
// SIG // MTAwNzAwMDBaFw0yMDEyMzEwNzAwMDBaMHAxKzApBgNV
// SIG // BAsTIkNvcHlyaWdodCAoYykgMTk5NyBNaWNyb3NvZnQg
// SIG // Q29ycC4xHjAcBgNVBAsTFU1pY3Jvc29mdCBDb3Jwb3Jh
// SIG // dGlvbjEhMB8GA1UEAxMYTWljcm9zb2Z0IFJvb3QgQXV0
// SIG // aG9yaXR5MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIB
// SIG // CgKCAQEAqQK9wXDmO/JOGyifl3heMOqiqY0lX/j+lUyj
// SIG // t/6doiA+fFGim6KPYDJr0UJkee6sdslU2vLrnIYcj5+E
// SIG // ZrPFa3piI9YdPN4PAZLolsS/LWaammgmmdA6LL8MtVgm
// SIG // wUbnCj44liypKDmo7EmDQuOED7uabFVhrIJ8oWAtd0zp
// SIG // mbRkO5pQHDEIJBSfqeeRKxjmPZhjFGBYBWWfHTdSh/en
// SIG // 75QCxhvTv1VFs4mAvzrsVJROrv2nem10Tq8YzJYJKCEA
// SIG // V5BgaTe7SxIHPFb/W/ukZgoIptKBVlfvtjteFoF3BNr2
// SIG // vq6Alf6wzX/WpxpyXDzKvPAIoyIwswaFybMgdxOF3wID
// SIG // AQABo4GoMIGlMIGiBgNVHQEEgZowgZeAEFvQcO9pcp4j
// SIG // UX4Usk2O/8uhcjBwMSswKQYDVQQLEyJDb3B5cmlnaHQg
// SIG // KGMpIDE5OTcgTWljcm9zb2Z0IENvcnAuMR4wHAYDVQQL
// SIG // ExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xITAfBgNVBAMT
// SIG // GE1pY3Jvc29mdCBSb290IEF1dGhvcml0eYIPAMEAizw8
// SIG // iBHRPvZj7N9AMA0GCSqGSIb3DQEBBAUAA4IBAQCV6AvA
// SIG // jfOXGDXtuAEk2HcR81xgMp+eC8s+BZGIj8k65iHy8FeT
// SIG // LLWgR8hi7/zXzDs7Wqk2VGn+JG0/ycyq3gV83TGNPZ8Q
// SIG // cGq7/hJPGGnA/NBD4xFaIE/qYnuvqhnIKzclLb5loRKK
// SIG // JQ9jo/dUHPkhydYV81KsbkMyB/2CF/jlZ2wNUfa98VLH
// SIG // vefEMPwgMQmIHZUpGk3VHQKl8YDgA7Rb9LHdyFfuZUnH
// SIG // UlS2tAMoEv+Q1vAIj364l8WrNyzkeuSod+N2oADQaj/B
// SIG // 0jaK4EESqDVqG2rbNeHUHATkqEUEyFozOG5NHA1itwqi
// SIG // jNPVVD9GzRxVpnDbEjqHk3Wfp9KgMIIEyzCCA7OgAwIB
// SIG // AgIQaguZT8AADKsR2CLvfWx5fjANBgkqhkiG9w0BAQQF
// SIG // ADBwMSswKQYDVQQLEyJDb3B5cmlnaHQgKGMpIDE5OTcg
// SIG // TWljcm9zb2Z0IENvcnAuMR4wHAYDVQQLExVNaWNyb3Nv
// SIG // ZnQgQ29ycG9yYXRpb24xITAfBgNVBAMTGE1pY3Jvc29m
// SIG // dCBSb290IEF1dGhvcml0eTAeFw0wMjA1MjMwODAwMDBa
// SIG // Fw0xMTA5MjUwODAwMDBaMIGmMQswCQYDVQQGEwJVUzET
// SIG // MBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVk
// SIG // bW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0
// SIG // aW9uMSswKQYDVQQLEyJDb3B5cmlnaHQgKGMpIDIwMDAg
// SIG // TWljcm9zb2Z0IENvcnAuMSMwIQYDVQQDExpNaWNyb3Nv
// SIG // ZnQgQ29kZSBTaWduaW5nIFBDQTCCASAwDQYJKoZIhvcN
// SIG // AQEBBQADggENADCCAQgCggEBAMPMII283/8+UO56wtQk
// SIG // JfZ2ziH/zSpWTsqct4KyNXktAMSoCNVjybel9unBwdax
// SIG // jJaiB/oPtoJSmuuCxr0QxajA7muEjlMbu1D6ZAGJwRbU
// SIG // gmgAQHhE9RI4TvtjUeD6PbnlN7HfYwcjO3FANEf0a65G
// SIG // 9SdzHiLLQhkeUbZSmtOj0BPGGT9xBm3ylSFEX0LtwMmZ
// SIG // ZCC4wTT8okTme7IdL7im3vSh35shD/5YMUFVOH6vWOfk
// SIG // 7Fl5Jav3Ki8RPzh4PkJ/p2jkfiJoF+ZKksR4RFJHoU+E
// SIG // iZObwGd76gn7hgN99plxPCunZpjM3y3iKwIaDzRIZfU8
// SIG // Eq/xhxwdJlJvzAMCAQOjggEqMIIBJjATBgNVHSUEDDAK
// SIG // BggrBgEFBQcDAzCBogYDVR0BBIGaMIGXgBBb0HDvaXKe
// SIG // I1F+FLJNjv/LoXIwcDErMCkGA1UECxMiQ29weXJpZ2h0
// SIG // IChjKSAxOTk3IE1pY3Jvc29mdCBDb3JwLjEeMBwGA1UE
// SIG // CxMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSEwHwYDVQQD
// SIG // ExhNaWNyb3NvZnQgUm9vdCBBdXRob3JpdHmCDwDBAIs8
// SIG // PIgR0T72Y+zfQDASBgkrBgEEAYI3FQEEBQIDAwADMB0G
// SIG // A1UdDgQWBBQl+CtLXchyVK3l9qAqFxb7wflTgTAZBgkr
// SIG // BgEEAYI3FAIEDB4KAFMAdQBiAEMAQTALBgNVHQ8EBAMC
// SIG // AUYwDwYDVR0TAQH/BAUwAwEB/zANBgkqhkiG9w0BAQQF
// SIG // AAOCAQEAn2RKdOFpJ1r4BlMnl8ce0YFz0c66gfQa6pOX
// SIG // h6/cjzoCtYsQv9MudHQBO7RAE+5RXzzDMptP1ulZyigA
// SIG // lnIV63EvmJjAA+E1QukIL2Ixmfwx89xCrtxPj8w43nBB
// SIG // OGANPCCSKxicB/5Wk6nSS4i9mUoiAoVvROyR5hneK7gV
// SIG // sptw+sXrToMsOnGgMljyNVLbkYhA728b5ylCtHDNfWxv
// SIG // GsjbnPrRXor30iyaAF/Z9MKzn3vUO/5TdCpnHYEnonXo
// SIG // QJgHGIsYIAtGct/v9+w2be5ryWZTHb01quXLHWpyE0WA
// SIG // Htldh2aKHCymysthAwPeCckBsVnAsP3mZpfL+gk7fDCC
// SIG // BOEwggPJoAMCAQICCmEFh1gAAwAAAFowDQYJKoZIhvcN
// SIG // AQEFBQAwgaYxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpX
// SIG // YXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYD
// SIG // VQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKzApBgNV
// SIG // BAsTIkNvcHlyaWdodCAoYykgMjAwMCBNaWNyb3NvZnQg
// SIG // Q29ycC4xIzAhBgNVBAMTGk1pY3Jvc29mdCBDb2RlIFNp
// SIG // Z25pbmcgUENBMB4XDTA1MDEwNTIzMjAxOVoXDTA2MDQw
// SIG // NTIzMzAxOVowdDELMAkGA1UEBhMCVVMxEzARBgNVBAgT
// SIG // Cldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAc
// SIG // BgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEeMBwG
// SIG // A1UEAxMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMIIBIjAN
// SIG // BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAzzj34aQn
// SIG // XvjwzKrO+zreO2IxRgVGu/W2BRrTs6zCnw9MZwgoxEMQ
// SIG // 9Tt1eX9qkfTWM8hhv/qRkAB68HkdXWhw9pCymHe1Ax0v
// SIG // m52bdYkvSgFBfJ58y4dDm/SWdJmemMHPQFdYFvbA1ZIW
// SIG // 5SSFcY+ZSe1VfGXJHzgAI8U+qxHWKWzGnqBwW33VN9Rn
// SIG // dyDDBs6F+E40gKA1xBxTMgFX77EovWwB461AvICpCUnb
// SIG // NuM39B1Jqiqna9AZ08yOndaGRnoTStZFGaVTs+J4Ly41
// SIG // l2tMxugasNPRJJBpq878aW4+TPsCQWLcB5hdflynTCcx
// SIG // a1ZM4ZjY4NEdcY09KsB/cU3/zwIDAQABo4IBQDCCATww
// SIG // DgYDVR0PAQH/BAQDAgbAMB0GA1UdDgQWBBSSERIUNHex
// SIG // j2g04g7xMjTA6fNjMTATBgNVHSUEDDAKBggrBgEFBQcD
// SIG // AzCBqQYDVR0jBIGhMIGegBQl+CtLXchyVK3l9qAqFxb7
// SIG // wflTgaF0pHIwcDErMCkGA1UECxMiQ29weXJpZ2h0IChj
// SIG // KSAxOTk3IE1pY3Jvc29mdCBDb3JwLjEeMBwGA1UECxMV
// SIG // TWljcm9zb2Z0IENvcnBvcmF0aW9uMSEwHwYDVQQDExhN
// SIG // aWNyb3NvZnQgUm9vdCBBdXRob3JpdHmCEGoLmU/AAAyr
// SIG // Edgi731seX4wSgYDVR0fBEMwQTA/oD2gO4Y5aHR0cDov
// SIG // L2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVj
// SIG // dHMvQ29kZVNpZ25QQ0EuY3JsMA0GCSqGSIb3DQEBBQUA
// SIG // A4IBAQAMAQoN7iYewxG8xHQ8px3u9UreJ5mi96uMjkdy
// SIG // oFG/qLFL2H9C1RyPo+a4Er1RI6+xO9Nl8S2MA+lMUO04
// SIG // 9ldeOnNPM6wTLbUlwzvlkVnf0Bu40K4RBwnMBdNSHOIK
// SIG // ZHcFGBl3EnUQkxo2FozVIB9sM+9gL22v5vHU2im+itu1
// SIG // D2uVIkDyK5cyUP/66orGtuPsNoqydylUPn4Wlf5xWY2n
// SIG // yoQP4f+CEYEvGYfd50Sfje8i8v62jM/I2yGGtZeYSA2r
// SIG // 2OFjct1v5yyTK5/uthLWOllKIeWfqWJQkxV1HXZf2KDC
// SIG // +vmkrH4RyvlXv/3Siel97oyk2ge7uhTdE0PV6p3mMYIE
// SIG // kzCCBI8CAQEwgbUwgaYxCzAJBgNVBAYTAlVTMRMwEQYD
// SIG // VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25k
// SIG // MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24x
// SIG // KzApBgNVBAsTIkNvcHlyaWdodCAoYykgMjAwMCBNaWNy
// SIG // b3NvZnQgQ29ycC4xIzAhBgNVBAMTGk1pY3Jvc29mdCBD
// SIG // b2RlIFNpZ25pbmcgUENBAgphBYdYAAMAAABaMAkGBSsO
// SIG // AwIaBQCggbAwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcC
// SIG // AQQwHAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUw
// SIG // IwYJKoZIhvcNAQkEMRYEFMpECNUuCKw/IYRMjbXIvSgh
// SIG // 8SuZMFAGCisGAQQBgjcCAQwxQjBAoCaAJABTAGMAbwBy
// SIG // AGUAYwBhAHIAZABTAGMAcgBpAHAAdAAuAGoAc6EWgBRo
// SIG // dHRwOi8vbWljcm9zb2Z0LmNvbTANBgkqhkiG9w0BAQEF
// SIG // AASCAQA3773Yli4fq6uE+4M1m3SFrfqaVgCOtqcZYMa+
// SIG // n54uhZNB4n/dF5LrTyvd8XYUj+p0DZf4M6fmr+SeqT6T
// SIG // 7GJfCXiN/NVvjvoQXDcg9GWP9tCEv1mZjRe7HbBwzuWa
// SIG // zbW2+mpSaFGYA8BkTRoFLax93MnJcxuWqBRdgE8nMkK2
// SIG // g/tuYfmK98EO982xzGjSDhcCFH1VFzI6AvNQGPBx1YM7
// SIG // ncFlTHcLGDKv/nTn/32JJNVedM23EzO2dmRIxg1vNua3
// SIG // rBB9pny+mgLudTN2cvmofk4RA4UrbEV7taWH+CenQY6g
// SIG // b9TfnzgZsP6BvAN5NXzdgJ8QVuwzySWEvjJDvph5oYIB
// SIG // /zCCAfsGCSqGSIb3DQEJBjGCAewwggHoAgEBMGcwUzEL
// SIG // MAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJ
// SIG // bmMuMSswKQYDVQQDEyJWZXJpU2lnbiBUaW1lIFN0YW1w
// SIG // aW5nIFNlcnZpY2VzIENBAhAN6Svw1NgpiBgyBQlemnaI
// SIG // MAwGCCqGSIb3DQIFBQCgWTAYBgkqhkiG9w0BCQMxCwYJ
// SIG // KoZIhvcNAQcBMBwGCSqGSIb3DQEJBTEPFw0wNTEwMDMx
// SIG // OTExMjZaMB8GCSqGSIb3DQEJBDESBBBvZ9Uhqa6FsuWd
// SIG // hRPLn3TVMA0GCSqGSIb3DQEBAQUABIIBACOHeniyQROH
// SIG // RRyxCydAk/RaornpAR9s0b8ijskQw48gy+Gg/8fOyQEs
// SIG // zzk6SAXtyLmfNQUCzd8mVRntsWX1XfMeZogNBMpp1wQF
// SIG // RVhTg1Lc/CfXUDnclL8KCnqnvd+Zgms6PEa1JXFbTOvH
// SIG // vkYN0urgVGeD+wZYEvLu1HK47ZOPsZ+8L3AqCd9pH37u
// SIG // vfhgWoxtwJpFwqz5WzaEk19CF0cwrRc4SlaWvYxA7RSg
// SIG // ZOOfUhgB384tzdYbYr39wJiHMRz8THa+CBMVdjIFIiaZ
// SIG // LY/tnlx2ucWFJ4upoWWOyaPKPgo9sbhDnCTBeKPiHMrx
// SIG // +0HPXqHpi8Ag8XPfMb4yh60=
// SIG // End signature block
