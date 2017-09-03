//Start subscribe-newsletter Scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===

function subNewsletter()
{
var emailId = document.getElementById("textfield").value;
//alert(emailId);
var url = "subscribe-newsletter.aspx?emailId=" + emailId + "&strip=strip&test=test";
document.getElementById("textfield").value = "";
//alert(url);
ajaxRequest(null,'true','GET','',url,'subdiv')
}

//End subscribe-newsletter Scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===


//Start inner tab Scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===
$(document).ready(function()
{
	//slides the element with class "menu_body" when paragraph with class "menu_head" is clicked 
	$("#firstpane p.menu_head").click(function()
    {
		$(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
       	$(this).siblings().css({backgroundImage:"url(images/left.png)"});
	});
	//slides the element with class "menu_body" when mouse is over the paragraph
	$("#secondpane p.menu_head").mouseover(function()
    {
	     $(this).css({backgroundImage:"url(images/down.png)"}).next("div.menu_body").slideDown(500).siblings("div.menu_body").slideUp("slow");
         $(this).siblings().css({backgroundImage:"url(images/left.png)"});
	});
});
//End inner tab Scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===


//Start tata left simpletreemenu scripts @@@@@@@@@@@@@@@@@@@@@@@@@@@===

var ddtreemenu = new Object();
ddtreemenu.highlightedClass = "testClass" // set highlighted className
ddtreemenu.closefolder="http://www.tatateleservices.com/beta/Theme/default/images/closed.gif" //set image path to "closed" folder image
ddtreemenu.openfolder="http://www.tatateleservices.com/beta/Theme/default/images/open.gif" //set image path to "open" folder image

ddtreemenu.createTree = function ( treeid ) {
   this.root = document.getElementById( treeid );
   this.root.style.backgroundImage = "";
   ddtreemenu.hideAll();
   ddtreemenu.checkLinks();
}

ddtreemenu.checkLinks = function() {
    var links = ddtreemenu.root.getElementsByTagName( "a" );
    for ( var i = 0; i < links.length; i++ ) {
        if ( links[i].href != "#" && links[i].href == location.href ) {
            ddtreemenu.expandItem( links[i] );
            return;
        }
    }
    
    
    var cookie = ddtreemenu.getCookie( "ddmenu" );    
    for ( var i = 0; i < links.length; i++ ) {
        if ( links[i].href != "#" && links[i].href == cookie ) {
            ddtreemenu.expandItem( links[i] );
            return;  
        }
    }
    
    ddtreemenu.setCookie( "ddmenu", location.href, 365 ); 
    
}


ddtreemenu.expandItem = function( elem ) {

    if ( elem.className != ddtreemenu.highlightedClass && elem.className != "-" ) {
        ddtreemenu.hideAll();; 
        elem.className = ddtreemenu.highlightedClass;
        if ( null != elem.parentNode.getElementsByTagName("ul")[0] ) {
            elem.parentNode.getElementsByTagName("ul")[0].style.display = "block"; 
            elem.parentNode.style.background = "url(" + ddtreemenu.openfolder + ") top left no-repeat";
        }
                
        
        while ( true ) {
            if ( elem.parentNode.parentNode == ddtreemenu.root ) return;
            elem = elem.parentNode.parentNode.parentNode.getElementsByTagName("a")[0];
            elem.className = "-";
            elem.parentNode.getElementsByTagName("ul")[0].style.display = "block";
            elem.parentNode.style.background = "url(" + ddtreemenu.openfolder + ") top left no-repeat";            
        }
        
    }
    else
    {
        elem.className = "";
        if ( null != elem.parentNode.getElementsByTagName("ul")[0] ) {
            elem.parentNode.getElementsByTagName("ul")[0].style.display = "none";
            elem.parentNode.style.background = "url(" + ddtreemenu.closefolder + ") top left no-repeat";
        }
    }
    
}

ddtreemenu.hideAllLinks = function () {
    var links = ddtreemenu.root.getElementsByTagName( "a" );
    for ( var i = 0; i < links.length; i++ ) {
        if ( links[i].className != "-" ) links[i].className = "";
    }
}

ddtreemenu.hideAll = function () {
    var links = ddtreemenu.root.getElementsByTagName( "a" );
    var uls = ddtreemenu.root.getElementsByTagName( "ul" );
    var lis = ddtreemenu.root.getElementsByTagName( "li" );
    for ( var i = 0; i < links.length; i++ ) {
        links[i].className = "";
        links[i].onclick = function() { ddtreemenu.expandItem( this ) };
    }
    for ( var i = 0; i < uls.length; i++ ) {
        uls[i].style.display = "none";
        uls[i].parentNode.className = "submenu";        
    }
    for ( var i = 0; i < lis.length; i++ ) {
        if ( null != lis[i].getElementsByTagName("a")[0] ) {
            if( lis[i].className == "submenu" ) lis[i].style.background = "url(" + ddtreemenu.closefolder + ") top left no-repeat";
            lis[i].onclick = function ( e ) { 
                ddtreemenu.expandItem( this.getElementsByTagName("a")[0] ); 
                if ( typeof e != "undefined" ) e.stopPropagation();
                if ( typeof event != "undefined" ) event.cancelBubble = true;
            }
        }
    }

}


ddtreemenu.getCookie=function(Name){ //get cookie value
    var re=new RegExp(Name+"=[^;]+", "i"); //construct RE to search for target name/value pair
    if (document.cookie.match(re)) //if cookie found
    return document.cookie.match(re)[0].split("=")[1] //return its value
    return ""
}

ddtreemenu.setCookie=function(name, value, days){ //set cookei value
    var expireDate = new Date()
    //set "expstring" to either future or past date, to set or delete cookie, respectively
    var expstring=expireDate.setDate(expireDate.getDate()+parseInt(days))
    document.cookie = name+"="+value+"; expires="+expireDate.toGMTString()+"; path=/";
}

//End tata left simpletreemenu scripts @@@@@@@@@@@@@@@@@@@@@@@@@@@===




//Start Strech boxes scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===

$(document).ready(function() {
	lastDiv = "";
	temp = "";

	$('.expanding_box img').hover(function() {
		$(this).css('cursor','pointer');
	}, function() {
		$(this).css('cursor','auto');
	})

	$('.expanding_box img').click(function() {
		var divpath = $(this).parent().parent().parent();
		if ($(divpath).attr('id') == $(lastDiv).attr('id')) {
			$(divpath).find('.hidden',this).hide();
			$(divpath).find('.closeBtn').hide();
			$(divpath).addClass('animating');
			$(divpath).animate({width:"186"},300);

			lastDiv = "";
			$('.expanding_box:not(.animating)').each(function() {
				$(this).animate({width:"186"},400);

				var src = $('img',this).attr('src');
				var start = src.lastIndexOf('/');
				var end = src.lastIndexOf('_');
				var substr = src.substring(start+1,end);

				var imgBasePath = src.substring(0, start)+'/';

				var imgpath = imgBasePath + substr+".jpg";

				$('.img img',this).attr('src',imgpath);

				$('.img img', this).animate({width:"186"},300);
				$('.hidden',this).fadeOut('fast');
				$('.closeBtn',this).fadeOut('fast');
			})

			$('.expanding_box').removeClass('animating');
		}else{
			var divpath = $(this).parent().parent().parent();
			$(divpath).addClass('animating');

			$('.expanding_box:not(.animating)').each(function() {
				var src = $('img',this).attr('src');
				var start = src.lastIndexOf('/');
				var end = src.lastIndexOf('.');
				var substr = src.substring(start+1,end);

				var imgBasePath = src.substring(0, start)+'/';

				if (src.lastIndexOf('_') < 0) {
					var imgpath = imgBasePath +substr+"_small.jpg";
				}else{
					var imgpath = imgBasePath +substr+".jpg";
				}
				$('.img img',this).attr('src',imgpath).animate({width:"133", height:"134"},300);
				$(this).animate({width:"133"},300);
				$('.hidden',this).fadeOut('fast');
				$('.closeBtn',this).fadeOut('fast');
			})

			$(divpath).animate({width: "345"}, 300 );

			var src = $(this).attr('src');
			var start = src.lastIndexOf('/');
			if (src.lastIndexOf('_') > 0) {
				var end = src.lastIndexOf('_');
			}else{
				var end = src.lastIndexOf('.');
			}

			var substr = src.substring(start+1,end);

			var imgBasePath = src.substring(0, start)+'/';

			var imgpath = imgBasePath+substr+".jpg";
			$(this).attr('src',imgpath);
			$(this).animate({width:"186"});

			temp = $(divpath).find('.hidden');
			var closeBtn = $(divpath).find('.closeBtn');
			var t = setTimeout(fadeinplease,300);

			lastDiv = divpath;

			$('.expanding_box').removeClass('animating');
		}
		return false;
		function fadeinplease() {
			$(temp).fadeIn('fast');
			$(closeBtn).fadeIn('fast');
		}
	})
});

//End Strech boxes scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===





//Start ddsmoothmenu Top menu scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===



var ddsmoothmenu={

//Specify full URL to down and right arrow images (23 is padding-right added to top level LIs with drop downs):
arrowimages: {down:['downarrowclass', 'images/down.gif', 12], right:['rightarrowclass', 'images/right.gif']},

transition: {overtime:300, outtime:300}, //duration of slide in/ out animation, in milliseconds
shadow: {enabled:true, offsetx:5, offsety:5},

///////Stop configuring beyond here///////////////////////////

detectwebkit: navigator.userAgent.toLowerCase().indexOf("applewebkit")!=-1, //detect WebKit browsers (Safari, Chrome etc)

getajaxmenu:function($, setting){ //function to fetch external page containing the panel DIVs
	var $menucontainer=$('#'+setting.contentsource[0]) //reference empty div on page that will hold menu
	$menucontainer.html("Loading Menu...")
	$.ajax({
		url: setting.contentsource[1], //path to external menu file
		async: true,
		error:function(ajaxrequest){
			$menucontainer.html('Error fetching content. Server Response: '+ajaxrequest.responseText)
		},
		success:function(content){
			$menucontainer.html(content)
			ddsmoothmenu.buildmenu($, setting)
		}
	})
},

buildshadow:function($, $subul){
	
},

buildmenu:function($, setting){
	var smoothmenu=ddsmoothmenu
	var $mainmenu=$("#"+setting.mainmenuid+">ul") //reference main menu UL
	var $headers=$mainmenu.find("ul").parent()
	$headers.each(function(i){
		var $curobj=$(this).css({zIndex: 100-i}) //reference current LI header
		var $subul=$(this).find('ul:eq(0)').css({display:'block'})
		this._dimensions={w:this.offsetWidth, h:this.offsetHeight, subulw:$subul.outerWidth(), subulh:$subul.outerHeight()}
		this.istopheader=$curobj.parents("ul").length==1? true : false //is top level header?
		$subul.css({top:this.istopheader? this._dimensions.h+"px" : 0})
		$curobj.children("a:eq(0)").css(this.istopheader? {paddingRight: smoothmenu.arrowimages.down[2]} : {}).append( //add arrow images
			'<img src="'+ (this.istopheader? smoothmenu.arrowimages.down[1] : smoothmenu.arrowimages.right[1])
			+'" class="' + (this.istopheader? smoothmenu.arrowimages.down[0] : smoothmenu.arrowimages.right[0])
			+ '" style="border:0;" />'
		)
		if (smoothmenu.shadow.enabled){
			this._shadowoffset={x:(this.istopheader?$subul.offset().left+smoothmenu.shadow.offsetx : this._dimensions.w), y:(this.istopheader? $subul.offset().top+smoothmenu.shadow.offsety : $curobj.position().top)} //store this shadow's offsets
			if (this.istopheader)
				$parentshadow=$(document.body)
			else{
				var $parentLi=$curobj.parents("li:eq(0)")
				$parentshadow=$parentLi.get(0).$shadow
			}
			this.$shadow=$('<div class="ddshadow'+(this.istopheader? ' toplevelshadow' : '')+'"></div>').prependTo($parentshadow).css({left:this._shadowoffset.x+'px', top:this._shadowoffset.y+'px'})  //insert shadow DIV and set it to parent node for the next shadow div
		}
		$curobj.hover(
			function(e){
				var $targetul=$(this).children("ul:eq(0)")
				this._offsets={left:$(this).offset().left, top:$(this).offset().top}
				var menuleft=this.istopheader? 0 : this._dimensions.w
				menuleft=(this._offsets.left+menuleft+this._dimensions.subulw>$(window).width())? (this.istopheader? -this._dimensions.subulw+this._dimensions.w : -this._dimensions.w) : menuleft //calculate this sub menu's offsets from its parent
				if ($targetul.queue().length<=1){ //if 1 or less queued animations
					$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).animate({height:'show',opacity:'show'}, ddsmoothmenu.transition.overtime)
					if (smoothmenu.shadow.enabled){
						var shadowleft=this.istopheader? $targetul.offset().left+ddsmoothmenu.shadow.offsetx : menuleft
						var shadowtop=this.istopheader?$targetul.offset().top+smoothmenu.shadow.offsety : this._shadowoffset.y
						if (!this.istopheader && ddsmoothmenu.detectwebkit){ //in WebKit browsers, restore shadow's opacity to full
							this.$shadow.css({opacity:1})
						}
						this.$shadow.css({overflow:'', width:this._dimensions.subulw+'px', left:shadowleft+'px', top:shadowtop+'px'}).animate({height:this._dimensions.subulh+'px'}, ddsmoothmenu.transition.overtime)
					}
				}
			},
			function(e){
				var $targetul=$(this).children("ul:eq(0)")
				$targetul.animate({height:'hide', opacity:'hide'}, ddsmoothmenu.transition.outtime)
				if (smoothmenu.shadow.enabled){
					if (ddsmoothmenu.detectwebkit){ //in WebKit browsers, set first child shadow's opacity to 0, as "overflow:hidden" doesn't work in them
						this.$shadow.children('div:eq(0)').css({opacity:0})
					}
					this.$shadow.css({overflow:'hidden'}).animate({height:0}, ddsmoothmenu.transition.outtime)
				}
			}
		) //end hover
	}) //end $headers.each()
	$mainmenu.find("ul").css({display:'none', visibility:'visible'})
},

init:function(setting){
	if (typeof setting.customtheme=="object" && setting.customtheme.length==2){
		var mainmenuid='#'+setting.mainmenuid
		document.write('<style type="text/css">\n'
			+mainmenuid+', '+mainmenuid+' ul li a {background:'+setting.customtheme[0]+';}\n'
			+mainmenuid+' ul li a:hover {background:'+setting.customtheme[1]+';}\n'
		+'</style>')
	}
	jQuery(document).ready(function($){ //override default menu colors (default/hover) with custom set?
		if (typeof setting.contentsource=="object"){ //if external ajax menu
			ddsmoothmenu.getajaxmenu($, setting)
		}
		else{ //else if markup menu
			ddsmoothmenu.buildmenu($, setting)
		}
	})
}

} //end ddsmoothmenu variable

//Initialize Menu instance(s):

ddsmoothmenu.init({
	mainmenuid: "smoothmenu1", //menu DIV id
	//customtheme: ["#1c5a80", "#18374a"], //override default menu CSS background values? Uncomment: ["normal_background", "hover_background"]
	contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
})


//End ddsmoothmenu Top menu scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===








//Start Validation scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===

function hideDefaultText(element, defaultVal)
{
	if(element.value == defaultVal){
		element.value =	'';
	}
}

function showDefaultText(element, defaultVal)
{
	if(element.value == ''){
		element.value =	defaultVal;
	}
}

function IsEmpty(aTextField) {

	var regexp = /^(\s)*$/

	if(regexp.test(aTextField.value)){
		return true;

	}else{
		return false;
	}

}

//End Validation scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===



//Start slide upside tab (my account share on popups)@@@@@@@@@@@@@@@@@@@@@@@@@@@===
$(document).ready(function(){

	$('#tt1 ul').hide();
	$('#tt2 ul').hide();
	$('#tt3 ul').hide();

	$('#afc').hover(function() {
				$('#afc #tt1 ul').slideDown(1700);
				return false;
			},function() {
			});
				
				$("#close").click(function () { 
    			  $('#afc #tt1 ul').slideUp(700); 
				  return false;
   			 });

			
			$('#nfc').hover(function() {
				$('#nfc #tt2 ul').slideDown(700);
				return false;
			},function() {
			});
			
			$("#close1").click(function () {  
    			  $('#nfc #tt2 ul').slideUp(700); 
				  return false;
   			 });
			
			
			$('#ad').hover(function() {
				$('#ad #tt3 ul').slideDown(700);
				return false;
			},function() {
			});
			
			$("#close2").click(function () { 
    			  $('#ad #tt3 ul').slideUp(700); 
				  return false;
   			 });
			
			
})




//End slide upside Tab (my account share on popups)@@@@@@@@@@@@@@@@@@@@@@@@@@@===





//Start main tab flow scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===

$(document).ready(function() {

	//Default Action
	$(".tab_content").hide(); //Hide all content
	$("ul.tabs li:first").addClass("active").show(); //Activate first tab
	$(".tab_content:first").show(); //Show first tab content
	
	//On Click Event
	$("ul.tabs li").click(function() {
		$("ul.tabs li").removeClass("active"); 
		//Remove any "active" class
		
		$(this).addClass("active"); //Add "active" class to selected tab
		$(".tab_content").hide(); //Hide all tab content
		var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active content
		return false;
	});

});


var globalclick=0;
var imgid;



$(document).ready(function() {

	//Default Action
	$(".tab_content2").hide(); //Hide all content
	$("ul.tabs2 li:first").addClass("active").show(); //Activate first tab
	$(".tab_content2:first").show(); //Show first tab content
	globalclick=0
	//On Click Event
	$("ul.tabs2 li").click(function() {

		//Remove any "active" class
			
			var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
			//alert($(this).attr('class'));
			$(".tab_content2").hide();
			imgid="imgcomment-"+activeTab.substring(1,activeTab.length);	
			var tabid=activeTab.substring(1,activeTab.length);
			document.getElementById("imgcomment-tab2").src="Theme/default/images/user-comment.gif";
			document.getElementById("imgcomment-tab3").src="Theme/default/images/community-speak.gif";
			if($(this).attr('class')=="active")
			{
				globalclick=0;
				$(activeTab).fadeIn();
				$("ul.tabs2 li").removeClass("active");				
				if(tabid=="tab2")
				{
				document.getElementById(imgid).src="Theme/default/images/user-comment-up.gif";
				}
				else if(tabid=="tab3")
				{
				document.getElementById(imgid).src="Theme/default/images/community-speak-up.gif";
				}
				
			}
			else
			{			
				globalclick=1;
				$(this).addClass("active"); 
				$(activeTab).hide();

				if(tabid=="tab2")
				{
				document.getElementById(imgid).src="Theme/default/images/user-comment.gif";
				}
				else if(tabid=="tab3")
				{
				document.getElementById(imgid).src="Theme/default/images/community-speak.gif";
				}
			}
			


		//Add "active" class to selected tab
	//	$(".tab_content2").hide(); //Hide all tab content
		 //Fade in the active content
		return false;
	});

});

//End main tab flow scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===




//Start myaccount validation scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===


function ivalidatenewTest(){

		//alert(formsubmission.eprofile.value);
		//alert("your number : " + eval(i_var).telephoneNumber.value);
		
		try
		{
	
		
		
		

		    if (document.forms['formsubmission'].elements['telephoneNumber'].value.length >=9 && document.forms['formsubmission'].elements['telephoneNumber'].value.length <=21  ){
			    var chars="0123456789";
			    for(var i=0; i < document.forms['formsubmission'].elements['telephoneNumber'].value.length; i++)
			    {
				    istemp3= document.forms['formsubmission'].elements['telephoneNumber'].value.length.substring(i,i+1);
				    if((chars.indexOf(istemp3) == -1) ){
						    alert("The Tata Indicom Number can have only Digits.");
						    document.forms['formsubmission'].elements['password'].value="";
						    document.forms['formsubmission'].elements['telephoneNumber'].value="";
						    //eval(i_var).telephoneNumber.focus();
						    return false;
				    }
			    }
		    } else {
				    alert("Please enter valid Tata Indicom number along with area code.");
				    document.forms['formsubmission'].elements['password'].value="";
				    //eval(i_var).telephoneNumber.focus();
				    return false;
		    }
		    // password validation
		    if (document.forms['formsubmission'].elements['password'].value.length <4  | document.forms['formsubmission'].elements['password'].value.length >16  ){
				    alert("Please enter valid Password to proceed.");
				    document.forms['formsubmission'].elements['password'].value="";
				    //eval(i_var).password.focus();
				    return false;
		    }
		}
		catch(err)
		{
		}
}



function ivalidatenewTest1(){

if (document.forms['formsubmission1'].elements['telephoneNumber'].value.length >=9 && document.forms['formsubmission1'].elements['telephoneNumber'].value.length <=21  )
		{
			var chars="0123456789";
			for(var i=0; i < document.forms['formsubmission1'].elements['telephoneNumber'].value.length; i++)
			{
				istemp3= document.forms['formsubmission1'].elements['telephoneNumber'].value.substring(i,i+1);
				if((chars.indexOf(istemp3) == -1) )
				{
						alert("The Tata Indicom Number can have only Digits.");
						document.forms['formsubmission1'].elements['telephoneNumber'].value="";
						//eval(i_var).telephoneNumber.focus();
						return false;
				}
			}
		} 
		else 
		{
				alert("Please enter valid Tata Indicom number along with area code.");
				//eval(i_var).telephoneNumber.focus();
				return false;
		}

		
		var count = 0
		for (i=0;i<document.forms['formsubmission1'].elements['emailAddress'].value.length ; i++ )
		{
			if (document.forms['formsubmission1'].elements['emailAddress'].value.charAt(i) == '@') 
			{
				count++;
				if (count > 1)
				{
					alert("Please enter valid E-mail ID to proceed!!");  // If more then one instance of @
					//eval(i_var).emailAddress.focus();
					return false;
				}
			}
			if (document.forms['formsubmission1'].elements['emailAddress'].value.charAt(i) == '.')
			{
				if (document.forms['formsubmission1'].elements['emailAddress'].value.charAt(i+1) == '.')
				{
					alert("Please enter valid E-mail ID to proceed!!"); // If 2 dots in succession
					//eval(i_var).emailAddress.focus();
					return false;
				}
			}

		}
		if (!(document.forms['formsubmission1'].elements['emailAddress'].value.substring(document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('@',0)).indexOf('.',0) >=1))
		{
			alert("Please enter valid E-mail ID to proceed!!"); // If no dot after @
			return false;
		}
		if (document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('@',0) >= 1 && document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('.',0) >= 1 && document.forms['formsubmission1'].elements['emailAddress'].value.indexOf (' ',0) == -1)
		{
			if (document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('@',0)!=document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('.',0)+1 && document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('@',0)!=document.forms['formsubmission1'].elements['emailAddress'].value.indexOf ('.',0)-1)
			{
				if ((document.forms['formsubmission1'].elements['emailAddress'].value.charAt(document.forms['formsubmission1'].elements['emailAddress'].value.length - 1) == '@') || (document.forms['formsubmission1'].elements['emailAddress'].value.charAt(document.forms['formsubmission1'].elements['emailAddress'].value.length - 1) == '.'))
				{
					alert("Please enter valid E-mail ID to proceed!!"); //If dot at the end
					//formsubmission1.emailAddress.focus();
					return false;
				}
			} 
			else 
			{
				alert("Please enter valid E-mail ID to proceed!!");
				//eval(i_var).emailAddress.focus();
				return false;
			}
		} 
		else 
		{
			alert("Please enter valid E-mail ID to proceed!");
			//eval(i_var).emailAddress.focus();
			return false;
		}
		
	// SUBMIT if all OK!!!
	//eval(i_var).action = "http://172.30.4.61:7779/myindicomdec07/EProfileAction.do"
}

function leftTrim(ltrimvalue)
{
	while(ltrimvalue.charAt(0)==' ')
		ltrimvalue = ltrimvalue.substr(1,ltrimvalue.length-1);
	return(ltrimvalue) ;
}
//End myaccount validation scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===


//Start combo box main scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===
 $(
			function()
			{
				_cssStyleSelectJQ1 = $("#cssStyleSelect").combobox(
				{		comboboxContainerClass: "comboboxContainer",
						comboboxValueContentContainerClass: "comboboxValueContainer",
						comboboxValueContentClass: "comboboxValueContent",
						comboboxDropDownClass: "comboboxDropDownContainer",
						comboboxDropDownButtonClass: "comboboxDropDownButton",
						comboboxDropDownItemClass: "comboboxItem",
						comboboxDropDownItemHoverClass: "comboboxItemHover",
						comboboxDropDownGroupItemHeaderClass: "comboboxGroupItemHeader",
						comboboxDropDownGroupItemContainerClass: "comboboxGroupItemContainer"
				});
				
				_cssStyleSelectJQ1.combobox.onChange = 
					function()
					{	
						//changeStyle();						
				        var cssStyleSelectJQ1 = $("#cssStyleSelect");
				        var selectedval1 = cssStyleSelectJQ1.val();
				        if(selectedval1!="0")
				        {
				           window.location.href=selectedval1;
				        }
					};
			});

            $(
			function()
			{
				_cssStyleSelectJQ2 = $("#cssStyleSelect2").combobox(
				{		comboboxContainerClass: "comboboxContainer2",
						comboboxValueContentContainerClass: "comboboxValueContainer2",
						comboboxValueContentClass: "comboboxValueContent2",
						comboboxDropDownClass: "comboboxDropDownContainer2",
						comboboxDropDownButtonClass: "comboboxDropDownButton2",
						comboboxDropDownItemClass: "comboboxItem2",
						comboboxDropDownItemHoverClass: "comboboxItemHover2",
						comboboxDropDownGroupItemHeaderClass: "comboboxGroupItemHeader2",
						comboboxDropDownGroupItemContainerClass: "comboboxGroupItemContainer2"
				});
				
				_cssStyleSelectJQ2.combobox.onChange = 
					function()
					{	
						//changeStyle();
						var cssStyleSelectJQ2 = $("#cssStyleSelect2");
				        var selectedval2 = cssStyleSelectJQ2.val();
				        if(selectedval2!="0")
				        {
				           window.location.href=selectedval2;
				        }
						//alert(selectedStyle);
					};
			});

//End combo box main scripts@@@@@@@@@@@@@@@@@@@@@@@@@@@===

