var persistclose = 1
var startX = 0
var startY = 0
var verticalpos = "frombottom"

function iecompattest()
{
	return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
}

function get_cookie(Name)
{
	var search = Name + "="
	var returnvalue = "";
	if (document.cookie.length > 0)
	{
		offset = document.cookie.indexOf(search)
		if (offset != -1)
		{
			offset += search.length
			end = document.cookie.indexOf(";", offset);
			if (end == -1) end = document.cookie.length;
			returnvalue=unescape(document.cookie.substring(offset, end))
		}
	}
	return returnvalue;
}

function closebar()
{
	if (persistclose)
	document.cookie="remainclosed=1"
	document.getElementById("topbar2").style.visibility="hidden"
}

function staticbar()
{
	barheight=document.getElementById("topbar2").offsetHeight
	var ns = (navigator.appName.indexOf("Netscape") != -1) || window.opera;
	var d = document;
	function ml(id)
	{
		var el=d.getElementById(id);
		if (!persistclose || persistclose)
		el.style.visibility="visible"
		if(d.layers)el.style=el;
		
		el.sP=function(x,y){
			ys=y-0;
			this.style.right=x+"px";this.style.top=ys+"px";};
		el.x = startX;
		if (verticalpos=="fromtop")
			el.y = startY;
		else
		{
			el.y = ns ? pageYOffset + innerHeight : iecompattest().scrollTop + iecompattest().clientHeight;
			el.y -= startY;
		}
		return el;
	}
	
	window.stayTopLeft=function()
	{
		if (verticalpos=="fromtop")
		{
			var pY = ns ? pageYOffset : iecompattest().scrollTop;
			ftlObj.y += (pY + startY - ftlObj.y)/1;
		}
		else
		{
			var pY = ns ? pageYOffset + innerHeight - barheight: iecompattest().scrollTop + iecompattest().clientHeight - barheight;
			ftlObj.y += (pY - startY - ftlObj.y)/1;
		}
		ftlObj.sP(ftlObj.x, ftlObj.y);
		setTimeout("stayTopLeft()", 1);
	}
	ftlObj = ml("topbar2");
	stayTopLeft();
}

if (window.addEventListener)
	window.addEventListener("load", staticbar, false)
else if (window.attachEvent)
	window.attachEvent("onload", staticbar)
else if (document.getElementById)
	window.onload=staticbar