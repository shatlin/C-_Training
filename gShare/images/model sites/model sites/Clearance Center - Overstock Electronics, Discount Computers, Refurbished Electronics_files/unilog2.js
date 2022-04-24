// $Id: ulogin.js,v 1.14 2006/03/25 00:53:48 sujitp Exp $
// $Source: /cvs/main/flat/html/js/unilog/unilog2.js,v $
function refreshComponent() {
//    alert(getBrowser())
//    if (getBrowser() == 'MSIE') {
        var uloginRequester;
        try {
            uloginRequester = new XMLHttpRequest();
        } catch (error) {
            try {
                uloginRequester = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (error) {
                return false;
            }
        }
        uloginRequester.open("GET", location.href, false);
        uloginRequester.onReadyStateChange = function() {
            if (uloginRequester.readyState >= 4) {
                //if (uloginRequester.status == 200) {
                logged_in = uloginRequester.getResponseHeader("CNET-Logged-In");
                user_name = uloginRequester.getResponseHeader("CNET-URS-DISPNAME");
                //}
            }
        }
        uloginRequester.send(null);
//    } else {
        location.reload();
//    }
}

// start state for universal login. just check the header and either
// go to state uloginOut (logged out) or uloginIn (logged in)
function uniloginStart() {
    if (location.href.indexOf('/13') > -1) {
        Element.hide('ulogin');
        return;
    }
    document.uloginform.setAttribute("autocomplete", "off");

    var welcome_string = ''
    Element.hide('uloginForm');
    //    savedForm = removeLoginForm();
    if (isLoggedIn()) {
        user_name = unescape(user_name.replace(/^\s+/g, "").replace(/\s+$/g, "").replace(/\+/g, ' '));
        if (user_name.length == 0) {
            welcome_string = '<b class="v1">Welcome</b>';
        } else {
            welcome_string = '<b class="v1">Welcome, <a href="' + getProfileUrl() + '">' + user_name + '</a></b>';
        }
        $('welcomeString').innerHTML = welcome_string;
        Element.show('uloginIn');
        Element.hide('uloginOut');
    } else {
        Element.hide('uloginIn');
        Element.show('uloginOut');
    }
    setupUrls();
    return false;
}

function isLoggedIn() {

    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
    // ssa
        case 1:
        case 7:
        case 9:
        case 28:
        case 92:
            return (urs_reg_id != '' && (logged_in == '1' || remember_me == '1'));

        default:
        // first, do they have the session cookie...
            var ursSesCookie = getCookie("surs_1");
            if (ursSesCookie) {
                // ah, ok, check the other stuff too then...
                return (urs_reg_id != '' && (logged_in == '1' || remember_me == '1'));
            }
            // no... ok, just check for the existance of the userName...
            return (null != user_name && user_name.length > 0 && user_name != ' ');
    }
}

function getCookie(name) {
    var dc = document.cookie;
    var prefix = name + "=";
    var begin = dc.indexOf("; " + prefix);
    if (begin == -1) {
        begin = dc.indexOf(prefix);
        if (begin != 0) return null;
    } else {
        begin += 2;
    }
    var end = document.cookie.indexOf(";", begin);
    if (end == -1) {
        end = dc.length;
    }
    return unescape(dc.substring(begin + prefix.length, end));
}

function setupUrls() {
    // setup our
    if ($('uniloginShowForm')) $('uniloginShowForm').onclick = showForm;
    if ($('uniloginSignup')) $('uniloginSignup').href = getSignupUrl();
    if ($('uniloginForgotPassword')) $('uniloginForgotPassword').href = getForgotPasswordUrl();
    if ($('uniloginWhyJoin1')) $('uniloginWhyJoin1').href = getSeeBenefitsUrl();
    if ($('uniloginProfile')) $('uniloginProfile').href = getProfileUrl();
    if ($('uniloginLogout')) $('uniloginLogout').onclick = goToLogout;
    if ($('uniloginCancel')) $('uniloginCancel').onclick = uniloginStart;
    if ($('uniloginWhyJoin2')) $('uniloginWhyJoin2').href = getSeeBenefitsUrl();
    if ($('uniloginSignup2')) $('uniloginSignup2').href = getSignupUrl();
}

// go to show login form state
function showForm() {
    document.uloginform.action = getLoginUrl();
    Element.hide('uloginIn');
    Element.hide('uloginOut');
    Element.show('uloginForm');
    document.uloginform.path.value = location.href;
    document.uloginform.setAttribute("autocomplete", "on");
    return false;
}

// go to login state if CR pressed
function goToLoginIfCR(event) {
    if (window.event) {
        if (window.event.keyCode == 13) {
            goToLogin();
        }
    } else {
        return false;
    }
}

// go to login state
function goToLogin() {
    if (document.uloginform.EMAILADDR.value=='Email') document.uloginform.EMAILADDR.value = '';
    var myAjax = new Ajax.Request(getLoginUrl(), {
        method: 'post',
        parameters: Form.serialize(document.uloginform),
        asynchronous:false,
        onSuccess: refreshComponent
//        ,
//        onComplete: refreshComponent
    });
        //    document.uloginform.action = getLoginUrl();
        //    this.form.submit();
        document.uloginform.submit();
//        refreshComponent();
}

// go to logout state
function goToLogout() {

    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
    // news...
        case 3:
            window.location = getLogoutUrl() + '?path=' + urlEncode(location.href);
            break;
        // download...
        case 4:
        case 53:
        case 54:
            location.href = getLogoutUrl() + '?tag=dhd_lout';
            break;
        // music...
        case 32:
            location.href = getLogoutUrl() + '?tag=mhd_lout';
            break;

        // ssa
        case 1:
        case 7:
        case 9:
        case 28:
        case 92:
        default:
            var myAjax = new Ajax.Request(getLogoutUrl(),
            {
                method: 'get',
                parameters: 'path=' + urlEncode(location.href),
                onComplete: switchLogout
            });
            break;
    }
    return false;
}

function getLoginInfo() {
    var myAjax = new Ajax.Request(
            '/1330-4' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html',
    {
        method: 'get',
        parameters: 'path=' + urlEncode(location.href),
        onComplete: switchLogout
    });

    return false;
}


function switchLogout() {
    Element.hide('uloginIn');
    Element.show('uloginOut');
}

// changes the location to the signup URL
function goToSignupUrl() {
    window.location = getSignupUrl();
}

function getSignupUrl() {
    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
    // news...
        case 3:
            return '/1300-12' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?tag=ne_su&path=' + urlEncode(location.href);

        // download...
        case 4:
        case 53:
        case 54:
            return '/1300-20' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?tag=dhd_su&path=' + urlEncode(location.href);
        // music...
        case 32:
            return '/1300-1' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?tag=mhd_su&path=' + urlEncode(location.href);

        // ssa
        case 1:
        case 7:
        case 9:
        case 28:
        case 92:
        default:
            return '/1301-4' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?tag=unilogin&path=' + urlEncode(location.href);
    }
}

function getLogoutUrl() {

    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
    // news...
        case 3:
            return '/1398-12' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';

        // download...
        case 4:
        case 53:
        case 54:
            return '/1398-20' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';
        // music...
        case 32:
            return '/1398-1' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';

        // ssa
        case 1:
        case 7:
        case 9:
        case 28:
        case 92:
        default:
            return '/1330-4' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';
    }
}

// changes the location to the user's profile page
function goToProfileUrl() {
    window.location = getProfileUrl();
}

// changes the location to the forgot password urs page
function goToForgotPasswordUrl() {
    window.location = getForgotPasswordUrl();
}

// changes the location to a boilerplate 'see benefits' page
function goToSeeBenefitsUrl() {
    window.location = getSeeBenefitsUrl();
}

function getForgotPasswordUrl() {
    return '/1328-4' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?path=' + urlEncode(location.href);
}

function getSeeBenefitsUrl() {
    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
        case 3:
            return '/1300-12' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?path=' + urlEncode(location.href);
        // download...
        case 4:
        case 53:
            return '/1300-20' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?tag=dhd_su&path=' + urlEncode(location.href);
        // music...
        case 32:
            return '/1300-1' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?tag=mhd_su&path=' + urlEncode(location.href);

        // ssa
        case 1:
        case 3:
        case 7:
        case 9:
        case 92:
        default:
            return '/1320-4' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html?path=' + urlEncode(location.href);
    }
}

// return the profile url for this user
function getProfileUrl() {
    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
        case 3:
            return '/1341-12' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';
        // download...
        case 4:
        case 53:
            return '/3656-20' + getOidSiteId() + '-' + '0.html?tag=unilogin';
        // music...
        case 32:
            return '/3656-1' + getOidSiteId() + '-' + '0.html?tag=unilogin';

        // ssa
        case 1:
        case 3:
        case 7:
        case 9:
        case 92:
        default:
            return '/5270-4_1-0-1.html?tag=unilogin';
    }
}

// return the login form action url
function getLoginUrl() {
    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
    // news...
        case 3:
            return '/1324-12' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';

        // download...
        case 4:
        case 53:
            return '/1324-20' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';
        // music...
        case 32:
            return '/1324-1' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';

        // ssa
        case 1:
        case 7:
        case 9:
        case 92:
        default:
            return '/1324-4' + getOidSiteId() + '-' + getDefaultAppIdBySite() + '.html';
    }
}

function getDefaultAppIdBySite() {
    var siteId = getSiteIdFromOid();
    switch (parseInt(siteId)) {
    // news...
        case 3:
            return 108;

        // download...
        case 4:
        case 53:
            return 133;
        // music...
        case 32:
            return 142;

        // ssa
        case 1:
        case 7:
        case 9:
        case 92:
        default:
            return 103;
    }
}

// url encode the path if not already encoded
function urlEncode(path) {
    if (path.indexOf('%') > -1) {
        return path;
    } else {
        return escape(path);
    }
}

// this call is to prevent Mozilla user's with 2 or more saved
// passwords from seeing the popup even if they are logged in.
//function removeLoginForm() {
//    var parentNode = $('ulogin');
//    var childNode = $('uloginForm');
//    var savedNode = parentNode.removeChild(childNode);
//    return savedNode;
//}

// add the form back if the client is logged out
//function addLoginForm(childNode) {
//    var parentNode = $('ulogin');
//    parentNode.appendChild(childNode);
//}

function getSiteIdFromHeaderVar() {
    return cnet_site_id;
}

function getSiteIdFromOid(def) {
    // just gonna use the one from the headers instead...
    var siteIdFromHeader = getSiteIdFromHeaderVar();
    if (siteIdFromHeader) {
        return siteIdFromHeader;
    }
    var siteId = (def) ? def : 1;
    // Gonna parse the siteId out of the oid safely.  First grab the path.
    var path = location.pathname;
    // Find the last occurrence of the underscore, so we know we are right before the siteId
    var underScoreIndex = path.lastIndexOf("_");
    if (underScoreIndex > -1) {
        // Get the chunk that starts with that underscore
        var pathChunk = path.substring(underScoreIndex, path.length);
        // Now find the index of the first dash after that underscore
        var dashIndex = pathChunk.indexOf("-");
        // Now using both indices, grab just the siteId out of the path
        siteId = parseInt(pathChunk.substring(1, dashIndex));

        // Check to see if this is a number, if not, then return invalid
        if (siteId == "NaN") {
            // If we didn't a valid siteId, return siteId 1...
            return (def) ? def : 1;
        }
    }
    return siteId;
}

/**
 * Used for putting a _<siteId> into the oid, provided we have one.
 * If not, returns blank... cuase guessing is no good...
 */
function getOidSiteId() {
    var falseDef = -25;
    var siteIdFromOid = getSiteIdFromOid(falseDef);
    if (siteIdFromOid != falseDef) {
        return "_" + siteIdFromOid;
    }
    return "";
}

function getBrowser() {
    var ua = navigator.userAgent.substring(0, 7);
    if (ua == 'Mozilla') {
        return 'W3C';
    } else {
        if (document.all) {
            return 'MSIE';
        } else {
            return 'NN4';
        }
    }
}