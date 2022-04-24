config["tab_width"] = 70;
config["tab_height"] = 25; 
config["tab_panel_width"] = 385; 
config["tab_panel_height"] = 56;

// define how to display each tab panel
var EMiniMallTabs =
{
	product:
	{
		render: function( data )
		{
			var product = data["product"];
			var vendors = data["vendors"];
			var vendorCount = vendors ? vendors.length : 0;
			
			var tabContainer = document.createElement( "div" );
			var nameLink = document.createElement( "div" );
			nameLink.id = "mmProductTitle";
			nameLink.className = "mmProductTitle";
			nameLink.innerHTML = product["name"];
			var toolTip = product["name"];
			if( vendorCount > 0 ) {
				var vendor = vendors[0];
				toolTip += " -- Available at " + vendor["name"] + " for " + vendor["price"];
			}
			nameLink.title = toolTip;
			tabContainer.appendChild( nameLink );

			if ( vendorCount > 0 ) {
				var vendor = vendors[0];

				var productLabel = document.createElement( "div" );
				productLabel.id = "mmProductLabel";
				productLabel.className = "mmProductLabel";
				productLabel.innerHTML = "Best Deal At:";
				tabContainer.appendChild( productLabel );

				var vendorNameElement = document.createElement( "a" );
				vendorNameElement.id = "mmProductVendor";
				vendorNameElement.className = "mmProductVendor";
				vendorNameElement.innerHTML = "Best Deal at " + vendor["name"];
				vendorNameElement.title = "Available at " + vendor["name"] + " for " + vendor["price"];
				vendorNameElement.target = "_blank";
				vendorNameElement.href = vendor["url"] + "&linkid=mmProductVendor";
				vendorNameElement.onmouseover = 'window.status="' + vendor["display_url"] + '";return true;'
				vendorNameElement.onmouseout = "window.status='';return true;"
				tabContainer.appendChild( vendorNameElement );
			}

			return ContentUtil.getOuterHTML( tabContainer );
		},
		
		dependencies:
		[
			"product"
		]
	},
	
	description:
	{
		render: function( data )
		{
			var product = data["product"];
			var vendors = data["vendors"];
			var vendorCount = vendors ? vendors.length : 0;
			var desctext = "";
			var desc = product["description"];
			var offerdesc = (vendorCount > 0 ) ? vendors[0]["offer_details"] : "";
			if( desc && desc != "" ) {
				desctext = desc;
			} else if( offerdesc && offerdesc != "" ) {
				desctext = offerdesc;
			}

			if( desctext != "" ) {
				var tabContainer = document.createElement( "div" );

				var descContainer = document.createElement( "div" );
				descContainer.id = "mmDescriptionText";
				descContainer.className = "mmDescriptionText";
				descContainer.innerHTML = desctext;
				tabContainer.appendChild( descContainer );

				var nameLink = document.createElement( "a" );
				nameLink.id = "mmDescriptionReadMore";
				nameLink.className = "mmDescriptionReadMore";
				nameLink.innerHTML = "Read More";
				nameLink.target = "_blank";
				nameLink.href  = vendorCount > 0 ? (vendors[0]["url"] + "&linkid=mmDescriptionReadMore") : (product["url"] + "&linkid=mmDescriptionReadMore");
				nameLink.onmouseover = "window.status='" + product["display_url"] + "';return true;";
				nameLink.onmouseout = "window.status='';return true;";
				
				var toolTip = product["name"];
				if( vendorCount > 0 ) {
					var vendor = vendors[0];
					toolTip = "Read More at: " + vendor["name"];
				}
				nameLink.title = toolTip;
				tabContainer.appendChild( nameLink );

				return ContentUtil.getOuterHTML( tabContainer );
			} else {
				// Dont show the tab
				return null;
			}
		},
		
		dependencies:
		[
			"product"
		]
	},

	prices:
	{
		render: function( data )
		{
			var product = data["product"];
			var vendors = data["vendors"];
			var vendorCount = vendors ? vendors.length : 0;
			var vendorsContainer = document.createElement( "div" );
			vendorsContainer.className = "mmVendors";
			vendorsContainer.id = "mmVendors";

			var logoUrl = null;
			if( vendors ) {
				if( vendors.length == 0 ) { return; }

				var vendor = vendors[0];
				var offerdesc = vendor["offer_details"];
				logoUrl = vendor["logo"];
				if( logoUrl ) {
					if( offerdesc && offerdesc != "" ) {
						var vendorOfferText = document.createElement( "div" );
						vendorOfferText.innerHTML = offerdesc;
						vendorOfferText.id = "mmVendorOfferText";
						vendorOfferText.className = "mmVendorOfferText";
						vendorsContainer.appendChild( vendorOfferText );
					}

					var tooltip = product["name"] + " -- Available at " + vendor["name"] + " for " + vendor["price"];
					var a = document.createElement( "a" );
					a.target = "_blank";
					a.href = vendor["url"] + "&linkid=mmVendorLogo";
					a.onmouseover = function(){ window.status=vendor["display_url"];return true; };
					a.onmouseout = function(){ window.status='';return true; };
					a.title = tooltip;

					var img = document.createElement( "img" );
					img.border = "0";
					img.id = "mmVendorLogo";
					img.src = logoUrl;
					img.className = "mmVendorLogo";
					img.title = tooltip;
					a.appendChild( img );
					vendorsContainer.appendChild( a );

					var vendorNameElement = document.createElement( "a" );
					vendorNameElement.innerHTML = vendor["name"];
					vendorNameElement.className = "mmVendorName1";
					vendorNameElement.title = "This vendor is rated " + vendor["rating_score"] + " stars";
					vendorNameElement.target = "_blank";
					vendorNameElement.href = vendor["url"] + "&linkid=mmVendorName1";
					vendorNameElement.onmouseover = 'window.status="' + vendor["display_url"] + '";return true;'
					vendorNameElement.onmouseout = "window.status='';return true;"


					var vendorPriceElement = document.createElement( "a" );
					vendorPriceElement.innerHTML = vendor["price"];
					vendorPriceElement.className = "mmVendorPrice1";
					vendorPriceElement.target = "_blank";
					vendorPriceElement.href = vendor["url"] + "&linkid=mmVendorPrice1";
					vendorPriceElement.onmouseover = function(){ window.status=vendor["display_url"];return true; };
					vendorPriceElement.onmouseout = function(){ window.status='';return true; };
						
					var vendorPriceDiv = document.createElement( "div" );
					vendorPriceDiv.appendChild( vendorNameElement );
					vendorPriceDiv.appendChild( vendorPriceElement );

					vendorsContainer.appendChild( vendorPriceDiv );
				} else {
					// we have only 1 vendor and no image--
					// let's bail and not display the "prices" tab.
					return null;
				}
			}
			return ContentUtil.getOuterHTML( vendorsContainer );
		},
		
		dependencies:
		[
			"product"
		]
	},

	best_deals:
	{
		render: function( data )
		{
			return EMiniMallTabs["prices"].render( data );
		},
		
		dependencies:
		[
			"product"
		]
	},

	search:
	{
		render: function( data )
		{
			var searchContainer = document.createElement( "div" );
			searchContainer.className = "mmSearch";
			searchContainer.id = "mmSearch";

			var title = document.createElement( "div" );
			title.id = "mmSearchTitle";
			title.className = "mmSearchTitle";
			title.innerHTML = "Search: ";
			
			var formhtml = "<form action='" + data["search_url"] + "' class='mmSearchForm' id='mmSearchForm'>";
			formhtml += "<input name='query' type='text' value='" + ( formfields["query"] ? formfields["query"] : "" ) + "' id='mmSearchTextBox' class='mmSearchTextBox'>";
			formhtml += "<input name='submit' type='submit' value='Find It' id='mmSearchSubmit' class='mmSearchSubmit'>";
	
			var excludeList = [ "query", "submit" ]; 
                	for( var name in formfields ) { 
				var excludeField = false; 
				for( var i = 0; i < excludeList.length; i++ ) { 
					if( name == excludeList[i] ) { 
						excludeField = true; 
					} 
				} 
  
				if( excludeField != true ) { 
					formhtml += "<input type='hidden' name='" + name + "' value='" + formfields[name] + "'>"; 
				} 
			} 
			formhtml += "</form>";

			searchContainer.innerHTML = formhtml;
			searchContainer.appendChild( title );

			var outputContainer = document.createElement( "span" );
			outputContainer.appendChild( searchContainer );
			return ContentUtil.getOuterHTML( outputContainer );
		},

		dependencies:
		[
		]
	},
	
	more_items:
	{
		render: function( data )
		{
			return EMiniMallTabs["search"].render( data );
		},
		
		dependencies:
		[
			"suggested_items"
		]
	},
	
	reviews:
	{
		render: function( data )
		{
			var review = data["review"];			
			var tabContainer = document.createElement( "div" );
			tabContainer.className = "mmReviews";
			tabContainer.id = "mmReviews";	

			var titleElement = document.createElement( "a" );
			titleElement.className = "mmReviewTitle";
			titleElement.innerHTML = review["title"];
			titleElement.target = "_blank";
			titleElement.href = review["url"] + "&linkid=mmReviewTitle";
			titleElement.title = "Click to view the complete review";
			titleElement.onmouseover = "window.status='" + review["display_url"] + "';return true;";
			titleElement.onmouseout = "window.status='';return true;";
			
			tabContainer.appendChild( titleElement );
			return ContentUtil.getOuterHTML( tabContainer );
		},	
		
		dependencies:
		[
			"review"
		]
	}
	
}
