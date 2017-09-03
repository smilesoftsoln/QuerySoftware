var containerHeight = 0;
var scrollCotent = '';
function getContainerHeight(o) {
   containerHeight = $(o).parent().height();
   containerHeight -= 20;
}
function getScrollContent(o) {
   sc = $(o).next();
   sch = sc.height();
}
$(document).ready( function() {

  $('.scroll-handle').Draggable(
	{
		zIndex: 	1000,
		containment:     'parent',
		axis:    'vertically',
		opacity: 	0.7,
		onStart: function() { 
                    getContainerHeight( this );
                    getScrollContent( this )
                },
		onDrag : function(x,y)
		{
                      var move = sch - containerHeight;

                      if(y>0 && y<(containerHeight))
                         sc.top(- y/containerHeight*move + "px");

                      return {x: x,y: y}
		}
	}
 );
});