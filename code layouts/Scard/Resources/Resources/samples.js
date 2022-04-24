
function closeMe()
{
	window.close();
}

function ViewSampleSource(name)
{
	// variables
	var wConfig;
	var wWindow;
	var oSelectBox = document.all.item(name);
	var url;
	var sIndex;
	
	// Get the selectedIndex
	sIndex = oSelectBox.selectedIndex;
	
	if (sIndex >= 0)
	{
		// Get the URL to the file
		url = oSelectBox.options[sIndex].value;

		// Set the configuration
		wConfig += 'directories=0,';
		wConfig += 'location=0,';
		wConfig += 'menubar=0,';
		wConfig += 'resizable=1,';
		wConfig += 'scrollbars=1,';
		wConfig += 'status=0,';
		wConfig += 'toolbar=0';

		// Launch the window
		wWindow = window.open(url, 'ViewSampleSource', wConfig);
		wWindow.focus();
	}
}