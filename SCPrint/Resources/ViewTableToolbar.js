// Used to persist the row expansion state
var g_rowVisibilityStore;
var g_configuredViewKey;

//
// Initialize the row states from the persistent store
//
function InitializeViewTableToolbarStore(rowVisibiltyStore, scorecardId, configuredViewId)
{
	g_rowVisibilityStore = document.getElementById(rowVisibiltyStore);
	g_configuredViewKey = "(" + scorecardId + ":" + configuredViewId + ")";
	if (g_rowVisibilityStore.value == null || g_rowVisibilityStore.value.length < 1)
	{
		SaveRowExpansionState();
	}
	else
	{
		if (g_rowVisibilityStore.value.indexOf(g_configuredViewKey) < 0)
		{
			// The configuredView / scorecard has changed, so don't carry on the row expansion state
			SaveRowExpansionState();
		}
		else
		{
			RestoreRowExpansionState();
			UpdateTableVisibility();
			UpdateTableExpansionImages();
		}
	}
}

//
// Save the current row expansion state into a persistent variable
//
function SaveRowExpansionState()
{
	var newState = g_configuredViewKey + ",";
	var trs = document.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++)
	{
		var row = trs[i];

		if (IsScorecardRow(row))
		{
			newState += row.rowId;
			if (row.filtered == "true")
				newState += ":1";
			else
				newState += ":0";

			if (row.showing == "true")
				newState += ":1";
			else
				newState += ":0";

			if (row.expanded == "true")
				newState += ":1";
			else
				newState += ":0";

			newState += ",";
		}
	}
	
	g_rowVisibilityStore.value = newState;
}

//
// Update the row states from the persistent store
//
function RestoreRowExpansionState()
{
	var state = g_rowVisibilityStore.value;

	var trs = document.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++)
	{
		var row = trs[i];

		if (IsScorecardRow(row))
		{
			var pos = state.indexOf("," + row.rowId + ":");
			if (pos > -1)
			{
				var endPos = state.indexOf(",", pos+1);
				var token = state.substring(pos+1, endPos);
				var tokens = token.split(":");
				if (tokens.length >= 4)
				{
					// The zero-index token is the rowId
//					if (tokens[1] == "1")
//						row.filtered = "true";
//					else
//						row.filtered = "false";
						
					if (tokens[2] == "1")
						row.showing = "true";
					else
						row.showing = "false";

					if (tokens[3] == "1")
						row.expanded = "true";
					else
						row.expanded = "false";
				}
			}
		}
	}
}

//
// Collapse all rows
//
function CollapseAll(tableId)
{
	var tableElement = document.getElementById(tableId);
	var trs = tableElement.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++)
	{
		var row = trs[i];

		if (IsScorecardRow(row))
		{
			var plusMinusImage = GetPlusMinusImage(row);
			if (null != plusMinusImage)
				plusMinusImage.src = g_resFolder + "plus.gif";
			row.expanded = "false";
			if (row.parentRowId != "0")
			{
				row.showing = "false";
			}
		}
	}		

	SaveRowExpansionState();
	UpdateTableVisibility();
}

//
// Expand all rows
//
function ExpandAll(tableId)
{
	var tableElement = document.getElementById(tableId);
	var trs = tableElement.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++)
	{
		var row = trs[i];

		if (IsScorecardRow(row))
		{
			var plusMinusImage = GetPlusMinusImage(row);
			if (null != plusMinusImage)
				plusMinusImage.src = g_resFolder + "minus.gif";
			row.expanded = "true";
			row.showing = "true";
		}
	}

	SaveRowExpansionState();
	UpdateTableVisibility();
}

//
// Returns the plus-minus image of a row
//
function GetPlusMinusImage(src)
{
	var imgs = src.getElementsByTagName("img");
	if (imgs && imgs.length > 0)
	{
		if (imgs[0].type && imgs[0].type == "plusminusimg")
		{
			return imgs[0];
		}
	}
	
	return null;
}


//
// Toggles the expansion state of the current scorecard row
// Triggered by clicking on the expand/collapse icon
//
function ScorecardTableToggleExpansion()
{
	var thisRow = GetScorecardRowOfThisElement(window.event.srcElement);
	var rowId = thisRow.rowId;

	var parentIdsToToggle = "," + rowId + ",";
	
	var isExpanded = (thisRow.expanded == "true");
	
	var trs = document.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++) 
	{
		var row = trs[i];
		
		if (IsScorecardRow(row))
		{
			if (parentIdsToToggle.indexOf("," + row.parentRowId + ",") > -1)
			{
				// Need to toggle this row's children as well
				if (row.expanded == "true")
					parentIdsToToggle += row.rowId + ",";
				
				if (isExpanded)
				{
					row.showing = "false";
				}
				else
				{
					row.showing = "true";
				}
			}
		}
	}
	
	if (isExpanded)
	{
		thisRow.expanded = "false";
		window.event.srcElement.src = g_resFolder + "plus.gif";
	}
	else
	{
		thisRow.expanded = "true";
		window.event.srcElement.src = g_resFolder + "minus.gif";
	}

	SaveRowExpansionState();
	UpdateTableVisibility();
}

//
// Keeps on going up the parent chain until it finds a parent scorecard row
//
function GetScorecardRowOfThisElement(element) 
{
	var parentSrc = element;
	while (parentSrc != null && !IsScorecardRow(parentSrc))
	{
		parentSrc = parentSrc.parentElement;
	}
	
	return parentSrc;
}

//
// Returns true if this element is a scorecard row
//
function IsScorecardRow(element) 
{
	if (element.rowId)
		return true;
	else
		return false;
}

//
// Update Indicator filter
//
function SetIndicatorFilter(parentId, filter, indicatorFilterStoreId)
{
	var tokens = filter.split(".");
	FilterRowsByIndicator(parentId, tokens[0], tokens[1]);
	UpdateTableVisibility();

	indicatorFilterStore = document.getElementById(indicatorFilterStoreId);
	indicatorFilterStore.value = filter;
}

function FilterRowsByIndicator(parentId, indicatorId, inBand)
{
	var rowsToIgnore = ",";
	
	var parent = document.getElementById(parentId);
	var trs = parent.getElementsByTagName("tr");
	for (i = trs.length - 1; i >= 0 ; i--)
	{
		var row = trs[i];
		var isFiltered = true;
		
		if (IsScorecardRow(row))
		{
			if (indicatorId != "00000000-0000-0000-0000-000000000000")
			{
				var tds = row.getElementsByTagName("td");
				for (j = 0; j < tds.length; j++)
				{
					var td = tds[j];

					if (td.bpm_iid == indicatorId && td.bpm_ib == inBand)
					{
						isFiltered = false;
						break;
					}
				}
				
				if (isFiltered && (rowsToIgnore.indexOf("," + row.rowId + ",") < 0))
				{
					row.filtered = "true";
				}
				else
				{
					rowsToIgnore += row.parentRowId + ",";
					row.filtered = "false";
				}
			}
			else
			{
				// No indicator filter
				row.filtered = "false";
			}
		}
	}
	SaveRowExpansionState();
}



//
// Go through the scorecard tables and update the visibility of the rows
//
function UpdateTableVisibility()
{
	var trs = document.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++)
	{
		var row = trs[i];
		if (IsScorecardRow(row))
		{
			if (row.filtered != "true" && row.showing == "true")
			{
				row.style.display = "inline";
			}
			else
			{
				row.style.display = "none";
			}
		}
	}
}

//
// Go through the scorecard tables and update the plus/minus images
//
function UpdateTableExpansionImages()
{
	var trs = document.getElementsByTagName("tr");
	for (i = 0; i < trs.length; i++)
	{
		var row = trs[i];
		if (IsScorecardRow(row))
		{
			var plusMinusImage = GetPlusMinusImage(row);
			if (null != plusMinusImage)
			{
				if (row.expanded == "true")
				{
					plusMinusImage.src = g_resFolder + "minus.gif";
				}
				else
				{
					plusMinusImage.src = g_resFolder + "plus.gif";
				}
			}
		}
	}
}

// SIG // Begin signature block
// SIG // MIIavgYJKoZIhvcNAQcCoIIarzCCGqsCAQExCzAJBgUr
// SIG // DgMCGgUAMGcGCisGAQQBgjcCAQSgWTBXMDIGCisGAQQB
// SIG // gjcCAR4wJAIBAQQQEODJBs441BGiowAQS9NQkAIBAAIB
// SIG // AAIBAAIBAAIBADAhMAkGBSsOAwIaBQAEFJiDAe0LamNR
// SIG // qxMLpA4TErTq2a71oIIVlTCCA8QwggMtoAMCAQICEEe/
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
// SIG // lTCCBJECAQEwgbUwgaYxCzAJBgNVBAYTAlVTMRMwEQYD
// SIG // VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25k
// SIG // MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24x
// SIG // KzApBgNVBAsTIkNvcHlyaWdodCAoYykgMjAwMCBNaWNy
// SIG // b3NvZnQgQ29ycC4xIzAhBgNVBAMTGk1pY3Jvc29mdCBD
// SIG // b2RlIFNpZ25pbmcgUENBAgphBYdYAAMAAABaMAkGBSsO
// SIG // AwIaBQCggbIwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcC
// SIG // AQQwHAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUw
// SIG // IwYJKoZIhvcNAQkEMRYEFL9Ysf2kYGos+x8OQTFVKab7
// SIG // MMy2MFIGCisGAQQBgjcCAQwxRDBCoCiAJgBWAGkAZQB3
// SIG // AFQAYQBiAGwAZQBUAG8AbwBsAGIAYQByAC4AagBzoRaA
// SIG // FGh0dHA6Ly9taWNyb3NvZnQuY29tMA0GCSqGSIb3DQEB
// SIG // AQUABIIBAIGE4SYp+b/PB3GXOFBNNd4a5o7blAPKfJFG
// SIG // HaAgQaRou0zkhN2k1AAS1LsZLz0/T3IFbsmF1aDkUEfn
// SIG // 0hGp1MfvD3612iVM+FOUd6EhvHRFhE0dc3ynAOTJNcTq
// SIG // frf3TnNhbgiS4T1tIePn5UTMHRQ5HPVLxFHcM9ANJc4D
// SIG // A/dmZUgSlbuP7RT+TSRbUP5cG2C2Hbwy3bvlpplsZNg9
// SIG // VW01eACmQ56yawhQRIE2h+DyUKiq1x/S3MET/WUePi2y
// SIG // e5mrJs/2W2hRUjoNI5hLRO+prU4M8Zf5diqcZPki9/VV
// SIG // xYEoJRlkb57opVbBg4jcicv8uQbfAO+di4NHC804xz2h
// SIG // ggH/MIIB+wYJKoZIhvcNAQkGMYIB7DCCAegCAQEwZzBT
// SIG // MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s
// SIG // IEluYy4xKzApBgNVBAMTIlZlcmlTaWduIFRpbWUgU3Rh
// SIG // bXBpbmcgU2VydmljZXMgQ0ECEA3pK/DU2CmIGDIFCV6a
// SIG // dogwDAYIKoZIhvcNAgUFAKBZMBgGCSqGSIb3DQEJAzEL
// SIG // BgkqhkiG9w0BBwEwHAYJKoZIhvcNAQkFMQ8XDTA1MTAw
// SIG // MzE5MTEyNFowHwYJKoZIhvcNAQkEMRIEEFMtbKEx7lbj
// SIG // N15X7JgwHTswDQYJKoZIhvcNAQEBBQAEggEAmT7XtqNs
// SIG // MyU7g9SwGxrVtSb0GjJ35+jS4O9YYeyyR6xCGnOMBaA6
// SIG // yslcxPu/MW2rccqaic6P1ORxve14EIRh+vg2SkExw5UA
// SIG // JeG2Ab+SUzX8EMSi5M919m79LQEdopjI1wAAq6I01r0R
// SIG // /9WGpqjIM2fhcRkG5bwJV25tl53xjEIJA9j+wj3TS5bo
// SIG // EYgOW2Mfj7E6YhNSlUuI/MT4Kvj0/8KTYjoj4f+X4LfZ
// SIG // zc87qJMOpPlSuuZ9nCDnquuavIfIz1o4H+VfM9DlL7ix
// SIG // ItSdoTije2EOMe3CTz8JCl5ux/qFPyQ+WoWTFxqYzh8k
// SIG // HxFKpQD1WaGnYYqzAzjeFgn+Gg==
// SIG // End signature block
