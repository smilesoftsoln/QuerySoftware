// JavaScript Document
function textCounter(field,counter,maxlimit,linecounter)
{
	var fieldWidth =  parseInt(field.offsetWidth);
	var charcnt = field.value.length; 
	if (charcnt > maxlimit) 
	{ 
		field.value = field.value.substring(0, maxlimit);
	}
	else
	{ 
	var percentage = parseInt(100 - (( maxlimit - charcnt) * 100)/maxlimit) ;
	document.getElementById(counter).style.width =  parseInt((fieldWidth*percentage)/100)+"px";
	document.getElementById(counter).innerHTML=""+percentage+"%"
	setcolor(document.getElementById(counter),percentage,"background-color");
	}
}

function setcolor(obj,percentage,prop)
{
	obj.style[prop] = "rgb(80%,"+(100-percentage)+"%,"+(100-percentage)+"%)";
}

Drupal.extend({ settings: { "googleanalytics": { "trackOutgoing": 1, "trackMailto": 1, "trackDownload": 1, "trackDownloadExtensions": "7z|aac|avi|csv|doc|exe|flv|gif|gz|jpe?g|js|mp(3|4|e?g)|mov|pdf|phps|png|ppt|rar|sit|tar|torrent|txt|wma|wmv|xls|xml|zip", "LegacyVersion": 0 } } });

function dontclickme() 
{
	aPopUp= window.open('slider2/slider2.htm','Note','toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no,width=400,height=300')
	
}

function disable_enable(){

//if the surfer is using IE 4 or above

if (document.all){

if (document.accessform.accesstext.disabled==true)

document.accessform.accesstext.disabled=false

else

document.accessform.accesstext.disabled=true

}

}

if (window.Event) 

document.captureEvents(Event.MOUSEUP); 

function nocontextmenu()  

{

event.cancelBubble = true

event.returnValue = false;

return false;

}

function norightclick(e)	

{

if (window.Event)	

{

if (e.which == 2 || e.which == 3)

return false;

}

else

if (event.button == 2 || event.button == 3)

{

event.cancelBubble = true

event.returnValue = false;

return false;

}	

}

document.oncontextmenu = nocontextmenu;		

document.onmousedown = norightclick;