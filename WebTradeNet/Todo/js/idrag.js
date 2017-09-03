/**
 * Interface Elements for jQuery
 * Draggable
 * 
 * http://interface.eyecon.ro
 * 
 * Copyright (c) 2006 Stefan Petre
 * Dual licensed under the MIT (MIT-LICENSE.txt) 
 * and GPL (GPL-LICENSE.txt) licenses.
 *   
 * $Revision: 1.22 $
 * $Log: idrag.js,v $
 * Revision 1.22  2006/09/04 18:20:00  Stef
 * *** empty log message ***
 *
 * Revision 1.21  2006/09/03 19:02:07  Stef
 * *** empty log message ***
 *
 * Revision 1.20  2006/09/02 06:46:03  Stef
 * *** empty log message ***
 *
 * Revision 1.19  2006/09/02 06:07:18  Stef
 * *** empty log message ***
 *
 * Revision 1.18  2006/09/01 21:23:16  Stef
 * Added callbacks for onStart, onStop and onDrag
 *
 * Revision 1.17  2006/08/31 18:40:45  Stef
 * Added support for floating elements
 *
 * Revision 1.16  2006/08/31 16:08:15  Stef
 * Added dual licencing
 *
 * Revision 1.15  2006/08/28 17:02:48  Stef
 * Added support for restricted sliders
 *
 * Revision 1.14  2006/08/27 19:05:55  Stef
 * *** empty log message ***
 *
 * Revision 1.13  2006/08/26 09:23:37  Stef
 * *** empty log message ***
 *
 * Revision 1.12  2006/08/26 07:53:52  Stef
 * *** empty log message ***
 *
 * Revision 1.11  2006/08/08 04:34:49  Stef
 * Sortables: bug fixed - sortserilizer was defined as a plugin for jQuery, but is just a function.
 * Slider: added end/home key events to move the indicator to 0/100% position
 *
 * Revision 1.10  2006/08/08 04:06:39  Stef
 * Slider: key control
 *
 * Revision 1.9  2006/08/07 16:11:19  Stef
 * Sortables: fixed the accuracy overlaping the dragged item over the rest of the items in the sortable
 * General: fixed the grammar verticaly and horizontaly are now vertically and horizontally :)
 *
 * Revision 1.8  2006/08/06 17:03:15  Stef
 * Added to slider onchange callbak triggered if the indicator is moved by atleast one pixel
 *
 * Revision 1.7  2006/08/06 12:54:58  Stef
 * If the dragged element is indicator for a slider then on drag start centers the element to pointer.
 * Bug fixed: on Internet explorer if the dragged element has border and padding then the element was moved with extra pixels (borderWidthLeft + paddingLeft)
 *
 * Revision 1.6  2006/08/06 11:28:38  Stef
 * Bug fixed - when axis was defined the draggeble was reverted
 *
 * Revision 1.5  2006/08/06 11:18:35  Stef
 * Draggales
 * - new method that moves the draggable element by coordonates. The new values apply to draggable's rules (grid, container, axis)
 *
 * Slider
 * - New way of defining
 * - can start with predefined values
 * - can change the values
 *
 * Revision 1.4  2006/08/05 11:19:04  Stef
 * *** empty log message ***
 *
 * Revision 1.3  2006/08/03 21:38:41  Stef
 * *** empty log message ***
 *
 * Revision 1.2  2006/08/02 17:59:24  Stef
 * *** empty log message ***
 *
 */

jQuery.iDrag =	{
	eventsAttached : false,
	tabindex : 1000,
	helper : null,
	dragged: null,
	destroy : function()
	{
		return this.each(
			function ()
			{
				if (this.isDraggable) {
					this.dragElem = null;
					jQuery(this).unbind('mousedown', jQuery.iDrag.dragstart);
				}
			}
		);
	},
	dragstart : function(e)
	{
		if (!jQuery || jQuery.iDrag.dragged != null) {
			jQuery.iDrag.dragstop(e);
		}
		elm = this.dragElem;
		elm.dragCfg.oScr = jQuery.iUtil.getScroll();
		this.focus();
		
		if (jQuery.browser.msie) {
			window.event.cancelBubble = true;
			window.event.returnValue = false;
			elm.dragCfg.sx = window.event.clientX + document.documentElement.scrollLeft + document.body.scrollLeft;
			elm.dragCfg.sy = window.event.clientY + document.documentElement.scrollTop + document.body.scrollTop;
		} else {
			e.preventDefault();
			e.stopPropagation();
			elm.dragCfg.sx = e.pageX;
			elm.dragCfg.sy = e.pageY;
		}
		
		dEs = elm.style;
		elm.dragCfg.cursx = elm.dragCfg.sx;
		elm.dragCfg.cursy = elm.dragCfg.sy;
		elm.dragCfg.oD = $.css(elm,'display');
		
		elm.dragCfg.oP = $.css(elm,'position');

		elm.dragCfg.oC = jQuery.extend(
			jQuery.iUtil.getPosition(elm),
			jQuery.iUtil.getSize(elm)
		);
		elm.dragCfg.oR = {
			x : elm.offsetLeft||0,
			y : elm.offsetTop||0
		};
		/*elm.dragCfg.dX = elm.dragCfg.sx - elm.dragCfg.oC.x;
		elm.dragCfg.dY = elm.dragCfg.sy - elm.dragCfg.oC.y;*/
		elm.dragCfg.oM = jQuery.iUtil.getMargins(elm);
		
		elm.dragCfg.diffX = -0;
		elm.dragCfg.diffY = -0;
		if (jQuery.browser.msie) {
			var oldBorder = jQuery.iUtil.getBorder(elm);
			elm.dragCfg.diffX = (parseInt(oldBorder.l)||0);
			elm.dragCfg.diffY = (parseInt(oldBorder.t)||0);
		}
		
		if (elm.dragCfg.oP != 'relative' && elm.dragCfg.oP != 'absolute') {
			dEs.position = 'relative';
		}

		dEs.marginTop = '0px';
		dEs.marginRight = '0px';
		dEs.marginBottom = '0px';
		dEs.marginLeft = '0px';
		
		//elm.dragCfg.oF = elm.style.styleFloat||elm.style.cssFloat||jQuery.css(elm, 'float');
		
		jQuery.iDrag.helper.html('');

		c = elm.cloneNode(true);
	
		jQuery(c).css(
			{
				display:	'block',
				left:		'0px',
				top: 		'0px'
			}
		);
		jQuery.iDrag.helper.append(c);
		
		dhs = jQuery.iDrag.helper.get(0).style;
		
		dhs.left = elm.dragCfg.oC.x - elm.dragCfg.diffX + 0 +  'px';
		dhs.top = elm.dragCfg.oC.y - elm.dragCfg.diffY + 0 + 'px';

		dhs.width = elm.dragCfg.oC.wb + 'px';
		dhs.height = elm.dragCfg.oC.hb + 'px';

		dhs.display = 'block';
		dhs.marginTop = '0px';
		dhs.marginRight = '0px';
		dhs.marginBottom = '0px';
		dhs.marginLeft = '0px';

		if (elm.dragCfg.ghosting == false) {
			dEs.display = 'none';
		}

		jQuery.iDrag.dragged = elm;
		jQuery.iDrag.dragged.dragCfg.prot = false;
		if (elm.dragCfg.containment) {
			if (elm.dragCfg.containment.constructor == String) {
				if (elm.dragCfg.containment == 'parent') {
					elm.dragCfg.cont = jQuery.extend(
						jQuery.iUtil.getPosition(elm.parentNode),
						jQuery.iUtil.getSize(elm.parentNode)
					);
					if (elm.dragCfg.si) {
						if (elm.SliderContainer.slideCfg.restricted ) {
							next = elm.SliderContainer.slideCfg.sliders.get(elm.SliderIteration+1);
							if (next) {
								elm.dragCfg.cont.w = parseInt($(next).css('left')) + elm.dragCfg.oC.wb;
								elm.dragCfg.cont.h = parseInt($(next).css('top')) + elm.dragCfg.oC.hb;
							}
							prev = elm.SliderContainer.slideCfg.sliders.get(elm.SliderIteration-1);
							if (prev) {
								elm.dragCfg.cont.x += parseInt($(prev).css('left'));
								elm.dragCfg.cont.y += parseInt($(prev).css('top'));
								elm.dragCfg.cont.w -= parseInt($(prev).css('left'));
								elm.dragCfg.cont.h -= parseInt($(prev).css('top'));
							}
						}
						elm.dragCfg.sx = elm.dragCfg.oC.x + elm.dragCfg.oC.wb/2;
						elm.dragCfg.sy = elm.dragCfg.oC.y + elm.dragCfg.oC.hb/2;
						elm.dragCfg.maxx = elm.dragCfg.cont.w - elm.dragCfg.oC.wb;
						elm.dragCfg.maxy = elm.dragCfg.cont.h - elm.dragCfg.oC.hb;
						if(elm.dragCfg.fractions) {
							elm.dragCfg.gx = ((elm.dragCfg.cont.w - elm.dragCfg.oC.wb)/elm.dragCfg.fractions) || 0;
							elm.dragCfg.gy = ((elm.dragCfg.cont.h - elm.dragCfg.oC.hb)/elm.dragCfg.fractions) || 0;
							elm.dragCfg.fracW = elm.dragCfg.maxx / elm.dragCfg.fractions;
							elm.dragCfg.fracH = elm.dragCfg.maxy / elm.dragCfg.fractions;
						}
						jQuery.iDrag.helper.css('cursor', 'default');
					}
				} else if (elm.dragCfg.containment == 'document') {
					clnt = jQuery.iUtil.getClient();
					elm.dragCfg.cont = {
						x : 0,
						y : 0,
						w : clnt.w,
						h : clnt.h
					};
				};
			} else if (elm.dragCfg.containment.constructor == Array && elm.dragCfg.containment.length == 4) {
				elm.dragCfg.cont = {
					x : parseInt(elm.dragCfg.containment[0]),
					y : parseInt(elm.dragCfg.containment[1]),
					w : parseInt(elm.dragCfg.containment[2]),
					h : parseInt(elm.dragCfg.containment[3])
				};
			}
			elm.dragCfg.cont.dx = elm.dragCfg.cont.x - elm.dragCfg.oC.x;
			elm.dragCfg.cont.dy = elm.dragCfg.cont.y - elm.dragCfg.oC.y;
			elm.dragCfg.onDrag.containment = jQuery.iDrag.fitToContainer;
		}
		
		if (elm.dragCfg.gx) {
			elm.dragCfg.onDrag.grid = jQuery.iDrag.snapToGrid;
		}
		if (jQuery.iDrop && jQuery.iDrop.count > 0 ){
			jQuery.iDrop.highlight();
		}
		if (elm.dragCfg.zIndex != false) {
			jQuery.iDrag.helper.css('zIndex', elm.dragCfg.zIndex);
		}
		if (elm.dragCfg.onStart)
			elm.dragCfg.onStart.apply(elm);
		if (elm.dragCfg.opacity) {
			jQuery.iDrag.helper.css('opacity', elm.dragCfg.opacity);
			if (window.ActiveXObject) {
				jQuery.iDrag.helper.css('filter', 'alpha(opacity=' + elm.dragCfg.opacity * 100 + ')');
			}
		}
		jQuery.iDrag.dragmove(e);
		return false;
	},
	
	hidehelper : function()
	{
		jQuery.iDrag.helper.empty().hide().css('opacity', 1);
		if (window.ActiveXObject) {
			jQuery.iDrag.helper.css('filter', 'alpha(opacity=100)');
		}
	},
	
	dragstop : function(e)
	{
		if (!jQuery || jQuery.iDrag.dragged == null) {
			return;
		}
		var dragged = jQuery.iDrag.dragged;
		jQuery.iDrag.dragged = null;
		if (dragged.dragCfg.so == true) {
			jQuery(dragged).css('position', dragged.dragCfg.oP);
		}
		dEs = dragged.style;
		//in dragstart the margins where reseted
		dEs.marginTop = dragged.dragCfg.oM.t;
		dEs.marginRight = dragged.dragCfg.oM.r;
		dEs.marginBottom = dragged.dragCfg.oM.b;
		dEs.marginLeft = dragged.dragCfg.oM.l;
		
		if (dragged.si) {
			jQuery.iDrag.helper.css('cursor', 'move');
		}
		
		if (dragged.dragCfg.revert == false) {
			nx = dragged.dragCfg.oR.x + ((!dragged.dragCfg.axis || dragged.dragCfg.axis == 'horizontally') ? (dragged.dragCfg.nx - dragged.dragCfg.oC.x  + dragged.dragCfg.diffX) : 1);
			ny = dragged.dragCfg.oR.y + ((!dragged.dragCfg.axis || dragged.dragCfg.axis == 'vertically') ? (dragged.dragCfg.ny - dragged.dragCfg.oC.y + dragged.dragCfg.diffY) : -2);
			if (dragged.dragCfg.fx > 0 && nx != dragged.dragCfg.oC.x && ny != dragged.dragCfg.oC.y) {
				x = new jQuery.fx(dragged,dragged.dragCfg.fx, 'left');
				y = new jQuery.fx(dragged,dragged.dragCfg.fx, 'top');
				x.custom(dragged.dragCfg.oC.x,nx);
				y.custom(dragged.dragCfg.oC.y,ny);
			} else {
				dragged.style.left = nx + 'px';
				dragged.style.top = ny + 1 + 'px';
			}
			jQuery.iDrag.hidehelper();
			if (dragged.dragCfg.ghosting == false) {
				jQuery(dragged).css('display', dragged.dragCfg.oD);
			}
		} else if (dragged.dragCfg.fx > 0) {
			dragged.dragCfg.prot = true;
			if(jQuery.iDrop && jQuery.iDrop.overzone && jQuery.iSort) {
				dh = jQuery.iUtil.getPosition(jQuery.iSort.helper.get(0));
			} else {
				dh = false;
			}
			jQuery.iDrag.helper.animate(
				{
					left : dh ? dh.x : dragged.dragCfg.oC.x,
					top : dh ? dh.y : dragged.dragCfg.oC.y
				},
				dragged.dragCfg.fx,
				function()
				{
					dragged.dragCfg.prot = false;
					if (dragged.dragCfg.ghosting == false) {
						dragged.style.display = dragged.dragCfg.oD;
					}
					jQuery.iDrag.hidehelper();
				}
			);
		} else {
			jQuery.iDrag.hidehelper();
			if (dragged.dragCfg.ghosting == false) {
				jQuery(dragged).css('display', dragged.dragCfg.oD);
			}
		}

		if (jQuery.iDrop && jQuery.iDrop.count > 0 ){
			jQuery.iDrop.checkdrop(dragged);
		}
		if (jQuery.iSort && dragged.dragCfg.so == true) {
			jQuery.iSort.check(dragged);
		}
		if (dragged.dragCfg.onChange && (nx != dragged.dragCfg.oR.x || ny != dragged.dragCfg.oR.y)){
			dragged.dragCfg.onChange.apply(dragged, dragged.dragCfg.lastSi);
		}
		if (dragged.dragCfg.onStart)
			dragged.dragCfg.onStart.apply(elm);
		
		/*if (dragged && dragged.dragCfg.prot == false) {
			if (dragged.dragCfg.ghosting == false) {
				jQuery(dragged).css('display', dragged.dragCfg.oD);
			}
			dragged = null;
		}*/
	},
	
	snapToGrid : function(x, y, dx, dy)
	{
		dx = dx != 0 ? parseInt((dx + (this.dragCfg.gx * dx/Math.abs(dx))/2)/this.dragCfg.gx) * this.dragCfg.gx : 0;
		dy = dy != 0 ? parseInt((dy + (this.dragCfg.gy * dy/Math.abs(dy))/2)/this.dragCfg.gy) * this.dragCfg.gy : 0;
		return {
			dx : dx,
			dy : dy,
			x: 0,
			y: 0
		};
	},
	
	fitToContainer : function(x, y, dx, dy)
	{
		dx = dx < this.dragCfg.cont.dx ? this.dragCfg.cont.dx : ((dx + this.dragCfg.oC.wb) > (this.dragCfg.cont.w + this.dragCfg.cont.dx) ? (this.dragCfg.cont.w + this.dragCfg.cont.dx - this.dragCfg.oC.wb) : dx );
		dy = dy < this.dragCfg.cont.dy ? this.dragCfg.cont.dy : ((dy + this.dragCfg.oC.hb) > (this.dragCfg.cont.h + this.dragCfg.cont.dy) ? (this.dragCfg.cont.h + this.dragCfg.cont.dy - this.dragCfg.oC.hb) : dy );
		return {
			dx : dx,
			dy : dy,
			x: 0,
			y: 0
		}
	},
	
	dragmove : function(e)
	{
		if (!jQuery || jQuery.iDrag.dragged == null || jQuery.iDrag.dragged.dragCfg.prot == true) {
			return;
		}
		var dragged = jQuery.iDrag.dragged;
		if (jQuery.browser.msie) {
			dragged.dragCfg.cursx = window.event.clientX + document.documentElement.scrollLeft + document.body.scrollLeft;
			dragged.dragCfg.cursy = window.event.clientY + document.documentElement.scrollTop + document.body.scrollTop;
		} else {
			dragged.dragCfg.cursx = e.pageX;
			dragged.dragCfg.cursy = e.pageY;
		}
		dx = dragged.dragCfg.cursx - dragged.dragCfg.sx;
		dy = dragged.dragCfg.cursy - dragged.dragCfg.sy;

		
		/*if (dragged.dragCfg.onDrag) {
			newCoords = dragged.dragCfg.onDrag.apply(dragged, [nx, ny]);
			if (newCoords.constructor == Object) {
				dx = newCoords.x - dragged.dragCfg.oR.x;
				dy = newCoords.y - dragged.dragCfg.oR.y;
			}
		}
	
		if (dragged.dragCfg.gx) {
			dx = (parseInt((dx + (dragged.dragCfg.gx * dx/Math.abs(dx))/2)/dragged.dragCfg.gx) || 0) * dragged.dragCfg.gx;
			dy = (parseInt((dy + (dragged.dragCfg.gy * dy/Math.abs(dy))/2)/dragged.dragCfg.gy) || 0) * dragged.dragCfg.gy;
		}
		if (dragged.dragCfg.cont) {
			dx = dx < dragged.dragCfg.cont.dx ? dragged.dragCfg.cont.dx : ((dx + dragged.dragCfg.oC.wb) > (dragged.dragCfg.cont.w + dragged.dragCfg.cont.dx) ? (dragged.dragCfg.cont.w + dragged.dragCfg.cont.dx - dragged.dragCfg.oC.wb) : dx );
			dy = dy < dragged.dragCfg.cont.dy ? dragged.dragCfg.cont.dy : ((dy + dragged.dragCfg.oC.hb) > (dragged.dragCfg.cont.h + dragged.dragCfg.cont.dy) ? (dragged.dragCfg.cont.h + dragged.dragCfg.cont.dy - dragged.dragCfg.oC.hb) : dy );
		}*/
		
	
		for (i in dragged.dragCfg.onDrag) {
			nx = dragged.dragCfg.oR.x + dx;
			ny = dragged.dragCfg.oR.y + dy;
			newCoords = dragged.dragCfg.onDrag[i].apply(dragged, [nx, ny, dx, dy]);
			if (newCoords.constructor == Object) {
				dx = i != 'user' ? newCoords.dx : (newCoords.x - dragged.dragCfg.oR.x);
				dy = i != 'user' ? newCoords.dy : (newCoords.y - dragged.dragCfg.oR.y);
			}
		}
		
		dragged.dragCfg.nx = dragged.dragCfg.oC.x + dx - dragged.dragCfg.diffX;
		dragged.dragCfg.ny = dragged.dragCfg.oC.y + dy - dragged.dragCfg.diffY;
		
		if (dragged.dragCfg.si && (dragged.dragCfg.onSlide || dragged.dragCfg.onChange)) {
			x = dx - dragged.dragCfg.cont.dx;
			y = dy - dragged.dragCfg.cont.dy;
			if (dragged.dragCfg.fractions) {
					xfrac = parseInt(x/dragged.dragCfg.fracW);
					xproc = xfrac * 100 / dragged.dragCfg.fractions;
					yfrac = parseInt(y/dragged.dragCfg.fracH);
					yproc = yfrac * 100 / dragged.dragCfg.fractions;
			} else {
				xproc = parseInt(x * 100 / dragged.dragCfg.maxx);
				yproc = parseInt(y * 100 / dragged.dragCfg.maxy);
			}
			dragged.dragCfg.lastSi = [xproc||0, yproc||0, x||0, y||0];
			if (dragged.dragCfg.onSlide)
				dragged.dragCfg.onSlide.apply(dragged, dragged.dragCfg.lastSi);
		}
		
		if (!dragged.dragCfg.axis || dragged.dragCfg.axis == 'horizontally')
			jQuery.iDrag.helper.get(0).style.left = dragged.dragCfg.nx + 'px';
		if (!dragged.dragCfg.axis || dragged.dragCfg.axis == 'vertically')
			jQuery.iDrag.helper.get(0).style.top = dragged.dragCfg.ny + 'px';
		
		if (jQuery.iDrop && jQuery.iDrop.count > 0 ){
			jQuery.iDrop.checkhover();
		}
	},
	
	dragmoveByKey : function (e)
	{
		if (jQuery.browser.msie) {
			window.event.cancelBubble = true;
			window.event.returnValue = false;
		} else {
			e.preventDefault();
			e.stopPropagation();
		}
		pressedKey = e.charCode || e.keyCode || -1;
		
		switch (pressedKey)
		{
			//end
			case 35:
				jQuery.iDrag.dragmoveBy(this.dragElem, [2000, 2000] );
			break;
			//home
			case 36:
				jQuery.iDrag.dragmoveBy(this.dragElem, [-2000, -2000] );
			break;
			//left
			case 37:
				jQuery.iDrag.dragmoveBy(this.dragElem, [-this.dragElem.dragCfg.gx||-1, 0] );
			break;
			//up
			case 38:
				jQuery.iDrag.dragmoveBy(this.dragElem, [0, -this.dragElem.dragCfg.gy||-1] );
			break;
			//right
			case 39:
				jQuery.iDrag.dragmoveBy(this.dragElem, [this.dragElem.dragCfg.gx||1, 0] );
			break;
			//down;
			case 40:
				jQuery.iDrag.dragmoveBy(this.dragElem, [0, this.dragElem.dragCfg.gy||1] );
			break;
		}
	},
	
	dragmoveBy : function (elm, position) 
	{
		if (!elm.dragCfg) {
			return;
		}
		//elm.dragCfg.oC = jQuery.iUtil.getPos(elm);
		elm.dragCfg.oC = jQuery.extend(
			jQuery.iUtil.getPosition(elm),
			jQuery.iUtil.getSize(elm)
		);
		elm.dragCfg.oR = {
			x : parseInt(jQuery.css(elm, 'left'))||0,
			y : parseInt(jQuery.css(elm, 'top'))||0
		};
		
		elm.dragCfg.oP = jQuery.css(elm, 'position');
		if (elm.dragCfg.oP != 'relative' && elm.dragCfg.oP != 'absolute') {
			elm.style.position = 'relative';
		}
		
		
		if (elm.dragCfg.containment) {
			if (elm.dragCfg.containment.constructor == String) {
				if (elm.dragCfg.containment == 'parent') {
					elm.dragCfg.cont = jQuery.extend(
						{x:0,y:-0},
						jQuery.iUtil.getSize(elm.parentNode)
					);
					if (elm.dragCfg.si) {
						elm.dragCfg.maxx = elm.dragCfg.cont.w - elm.dragCfg.oC.wb;
						elm.dragCfg.maxy = elm.dragCfg.cont.h - elm.dragCfg.oC.hb;
						if (elm.SliderContainer && elm.SliderContainer.slideCfg.restricted ) {
							next = elm.SliderContainer.slideCfg.sliders.get(elm.SliderIteration+1);
							if (next) {
								elm.dragCfg.cont.w = parseInt($(next).css('left')) + elm.dragCfg.oC.wb;
								elm.dragCfg.cont.h = parseInt($(next).css('top')) + elm.dragCfg.oC.hb;
							}
							prev = elm.SliderContainer.slideCfg.sliders.get(elm.SliderIteration-1);
							if (prev) {
								elm.dragCfg.cont.x += parseInt($(prev).css('left'));
								elm.dragCfg.cont.y += parseInt($(prev).css('top'));
								elm.dragCfg.cont.w -= parseInt($(prev).css('left'));
								elm.dragCfg.cont.h -= parseInt($(prev).css('top'));
							}
						}
						if(elm.dragCfg.fractions) {
							elm.dragCfg.gx = ((elm.dragCfg.cont.w - elm.dragCfg.oC.wb)/elm.dragCfg.fractions) || 1;
							elm.dragCfg.gy = ((elm.dragCfg.cont.h - elm.dragCfg.oC.hb)/elm.dragCfg.fractions) || 1;
							elm.dragCfg.fracW = elm.dragCfg.maxx / elm.dragCfg.fractions;
							elm.dragCfg.fracH = elm.dragCfg.maxy / elm.dragCfg.fractions;
						}
						jQuery.iDrag.helper.css('cursor', 'default');
					}
				} else if (elm.dragCfg.containment == 'document') {
					clnt = jQuery.iUtil.getClient();
					elm.dragCfg.cont = {
						x : 0,
						y : 0,
						w : clnt.w,
						h : clnt.h
					};
				};
			} else if (elm.dragCfg.containment.constructor == Array && elm.dragCfg.containment.length == 4) {
				elm.dragCfg.cont = {
					x : parseInt(elm.dragCfg.containment[0]),
					y : parseInt(elm.dragCfg.containment[1]),
					w : parseInt(elm.dragCfg.containment[2]),
					h : parseInt(elm.dragCfg.containment[3])
				};
			}
			elm.dragCfg.cont.dx = elm.dragCfg.cont.x - elm.dragCfg.oC.x;
			elm.dragCfg.cont.dy = elm.dragCfg.cont.y - elm.dragCfg.oC.y;
		}
		
		
		dx = parseInt(position[0]) || 0;
		dy = parseInt(position[1]) || 0;
		if (elm.dragCfg.gx) {
			dx = (parseInt((dx + (elm.dragCfg.gx * dx/Math.abs(dx))/2)/elm.dragCfg.gx) || 0) * elm.dragCfg.gx;
			dy = (parseInt((dy + (elm.dragCfg.gy * dy/Math.abs(dy))/2)/elm.dragCfg.gy) || 0) * elm.dragCfg.gy;
		}
		rx = elm.dragCfg.oR.x + dx;
		ry = elm.dragCfg.oR.y + dy;
		if (elm.dragCfg.cont) {
			rx = rx < elm.dragCfg.cont.x ? elm.dragCfg.cont.x : ((rx + elm.dragCfg.oC.wb) > elm.dragCfg.cont.w ? (elm.dragCfg.cont.w - elm.dragCfg.oC.wb) : rx );
			ry = ry < elm.dragCfg.cont.y ? elm.dragCfg.cont.y : ((ry + elm.dragCfg.oC.hb) > elm.dragCfg.cont.h ? (elm.dragCfg.cont.h - elm.dragCfg.oC.hb) : ry );
		}
				
		if (elm.dragCfg.si && (elm.dragCfg.onSlide || elm.dragCfg.onChange)) {
			x = rx;
			y = ry;
			if (elm.dragCfg.fractions) {
					xfrac = parseInt(x/elm.dragCfg.fracW);
					xproc = xfrac * 100 / elm.dragCfg.fractions;
					yfrac = parseInt(y/elm.dragCfg.fracH);
					yproc = yfrac * 100 / elm.dragCfg.fractions;
			} else {
				xproc = parseInt(x * 100 / elm.dragCfg.maxx);
				yproc = parseInt(y * 100 / elm.dragCfg.maxy);
			}
			elm.dragCfg.lastSi = [xproc||0, yproc||0, x||0, y||0];
			if (elm.dragCfg.onSlide)
				elm.dragCfg.onSlide.apply(jQuery.iDrag.dragged, elm.dragCfg.lastSi);
			
		}
		nx = !elm.dragCfg.axis || elm.dragCfg.axis == 'horizontally' ? rx : elm.dragCfg.oR.x;
		ny = !elm.dragCfg.axis || elm.dragCfg.axis == 'vertically' ? ry : elm.dragCfg.oR.y;
		elm.style.left = nx + 'px';
		elm.style.top = ny + 'px';
	},
	
	
	build : function(o)
	{
		if (!jQuery.iDrag.eventsAttached) {
			jQuery('body').bind('mousemove', jQuery.iDrag.dragmove).bind('mouseup', jQuery.iDrag.dragstop);
			jQuery.iDrag.eventsAttached = true;
		}
		if (!jQuery.iDrag.helper) {
			jQuery('body',document).append('<div id="dragHelper"></div>');
			jQuery.iDrag.helper = jQuery('#dragHelper');
			el = jQuery.iDrag.helper.get(0);
			els = el.style;
			els.position = 'absolute';
			els.display = 'none';
			els.cursor = 'move';
			els.listStyle = 'none';
			els.overflow = 'hidden';
			if (window.ActiveXObject) {
				el.onselectstart = function(){return false;};
				el.ondragstart = function(){return false;};
			}
		}
		if (!o) {
			o = {};
		}
		return this.each(
			function()
			{
				if (this.isDraggable && !jQuery.iUtil)
					return;
				if (window.ActiveXObject) {
					this.onselectstart = function(){return false;};
					this.ondragstart = function(){return false;};
				}
				var dhe = o.handle ? jQuery(this).find(o.handle) : jQuery(this);
				this.dragCfg = {
					revert : o.revert ? true : false,
					ghosting : o.ghosting ? true : false,
					so : o.so ? o.so : false,
					si : o.si ? o.si : false,
					zIndex : o.zIndex ? parseInt(o.zIndex)||0 : false,
					opacity : o.opacity ? parseFloat(o.opacity) : false,
					fx : parseInt(o.fx)||null,
					hpc : o.hpc ? o.hpc : false,
					onDrag : {},
					onStart : o.onStart && o.onStart.constructor == Function ? o.onStart : false,
					onStop : o.onStart && o.onStart.constructor == Function ? o.onStop : false,
					onChange : o.onChange && o.onChange.constructor == Function ? o.onChange : false,
					axis : /vertically|horizontally/.test(o.axis) ? o.axis : false
					
				};
				if (o.onDrag && o.onDrag.constructor == Function)
					this.dragCfg.onDrag.user = o.onDrag;
				if (o.containment && ((o.containment.constructor == String && (o.containment == 'parent' || o.containment == 'document')) || (o.containment.constructor == Array && o.containment.length == 4) )) {
					this.dragCfg.containment = o.containment;
				}
				if(o.fractions) {
					this.dragCfg.fractions = o.fractions;
				}
				if(o.grid){
					if(typeof o.grid == 'number'){
						this.dragCfg.gx = parseInt(o.grid)||1;
						this.dragCfg.gy = parseInt(o.grid)||1;
					} else if (o.grid.length == 2) {
						this.dragCfg.gx = parseInt(o.grid[0])||1;
						this.dragCfg.gy = parseInt(o.grid[1])||1;
					}
				}
				if (o.onSlide && o.onSlide.constructor == Function) {
					this.dragCfg.onSlide = o.onSlide;
				}
				
				this.isDraggable = true;
				dhe.get(0).dragElem = this;
				dhe.bind('mousedown', jQuery.iDrag.dragstart);
				if (this.dragCfg.si != false) {
					dhe.keydown(jQuery.iDrag.dragmoveByKey);
					dhe.attr('tabindex',jQuery.iDrag.tabindex++);
						
				}		
			}
		)
	}
};

jQuery.fn.extend(
	{
		DraggableDestroy : jQuery.iDrag.destroy,
		Draggable : jQuery.iDrag.build
	}
);