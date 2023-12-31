
var arrowimages={down:['downarrowclass', '../down.gif', 23], right:['rightarrowclass', '../right.gif']}

var jqueryslidemenu2={

animateduration: {over: 200, out: 200}, //duration of slide in/ out animation, in milliseconds

buildmenu:function(menuid, arrowsvar){
	jQuery(document).ready(function($){
		var $mainmenu=$("#"+menuid+">ul")
		var $headers=$mainmenu.find("ul").parent()
		$headers.each(function(i){
			var $curobj=$(this)
			var $subul=$(this).find('ul:eq(0)')
			this._dimensions={w:this.offsetWidth, h:this.offsetHeight, subulw:$subul.outerWidth(), subulh:$subul.outerHeight()}
			this.istopheader=$curobj.parents("ul").length==1? true : false
			$subul.css({top:this.istopheader? this._dimensions.h+"px" : 0})
			$curobj.children("a:eq(0)").css(this.istopheader? {paddingRight: arrowsvar.down[2]} : {}).append(
				'<img src="'+ (this.istopheader? arrowsvar.down[1] : arrowsvar.right[1])
				+'" class="' + (this.istopheader? arrowsvar.down[0] : arrowsvar.right[0])
				+ '" style="border:0;" />'
			)
			$curobj.hover(
				function(e){
					var $targetul=$(this).children("ul:eq(0)")
					this._offsets={left:$(this).offset().left, top:$(this).offset().top}
					var menuleft=this.istopheader? 0 : this._dimensions.w
					menuleft=(this._offsets.left+menuleft+this._dimensions.subulw>$(window).width())? (this.istopheader? -this._dimensions.subulw+this._dimensions.w : -this._dimensions.w) : menuleft
					if ($targetul.queue().length<=1) //if 1 or less queued animations
						$targetul.css({left:menuleft+"px", width:this._dimensions.subulw+'px'}).slideDown(jqueryslidemenu2.animateduration.over)
				},
				function(e){
					var $targetul=$(this).children("ul:eq(0)")
					$targetul.slideUp(jqueryslidemenu2.animateduration.out)
				}
			) //end hover
			$curobj.click(function(){
				$(this).children("ul:eq(0)").hide()
			})
		}) //end $headers.each()
		$mainmenu.find("ul").css({display:'none', visibility:'visible'})
	}) //end document.ready
}
}

//build menu with ID="myslidemenu" on page:
jqueryslidemenu2.buildmenu("myslidemenu", arrowimages)


// New Code Start Add by uttam (16/07/12)
// Coometed by uttam (26/07/12)
//var Spry;
//if (!Spry) {
//    Spry = {};
//}
//if (!Spry.Widget) {
//    Spry.Widget = {};
//}

//// Constructor for Menu Bar
//// element should be an ID of an unordered list (<ul> tag)
//// preloadImage1 and preloadImage2 are images for the rollover state of a menu
//Spry.Widget.MenuBar = function(element, opts) {
//    this.init(element, opts);
//};

//Spry.Widget.MenuBar.prototype.init = function(element, opts) {
//    this.element = this.getElement(element);

//    // represents the current (sub)menu we are operating on
//    this.currMenu = null;

//    var isie = (typeof document.all != 'undefined' && typeof window.opera == 'undefined' && navigator.vendor != 'KDE');
//    if (typeof document.getElementById == 'undefined' || (navigator.vendor == 'Apple Computer, Inc.' && typeof window.XMLHttpRequest == 'undefined') || (isie && typeof document.uniqueID == 'undefined')) {
//        // bail on older unsupported browsers
//        return;
//    }

//    // load hover images now
//    if (opts) {
//        for (var k in opts) {
//            var rollover = new Image;
//            rollover.src = opts[k];
//        }
//    }

//    if (this.element) {
//        this.currMenu = this.element;
//        var items = this.element.getElementsByTagName('li');
//        for (var i = 0; i < items.length; i++) {
//            this.initialize(items[i], element, isie);
//            if (isie) {
//                this.addClassName(items[i], "MenuBarItemIE");
//                items[i].style.position = "static";
//            }
//        }
//        if (isie) {
//            if (this.hasClassName(this.element, "MenuBarVertical")) {
//                this.element.style.position = "relative";
//            }
//            var linkitems = this.element.getElementsByTagName('a');
//            for (var i = 0; i < linkitems.length; i++) {
//                linkitems[i].style.position = "relative";
//            }
//        }
//    }
//};

//Spry.Widget.MenuBar.prototype.getElement = function(ele) {
//    if (ele && typeof ele == "string")
//        return document.getElementById(ele);
//    return ele;
//};

//Spry.Widget.MenuBar.prototype.hasClassName = function(ele, className) {
//    if (!ele || !className || !ele.className || ele.className.search(new RegExp("\\b" + className + "\\b")) == -1) {
//        return false;
//    }
//    return true;
//};

//Spry.Widget.MenuBar.prototype.addClassName = function(ele, className) {
//    if (!ele || !className || this.hasClassName(ele, className))
//        return;
//    ele.className += (ele.className ? " " : "") + className;
//};

//Spry.Widget.MenuBar.prototype.removeClassName = function(ele, className) {
//    if (!ele || !className || !this.hasClassName(ele, className))
//        return;
//    ele.className = ele.className.replace(new RegExp("\\s*\\b" + className + "\\b", "g"), "");
//};

//// addEventListener for Menu Bar
//// attach an event to a tag without creating obtrusive HTML code
//Spry.Widget.MenuBar.prototype.addEventListener = function(element, eventType, handler, capture) {
//    try {
//        if (element.addEventListener) {
//            element.addEventListener(eventType, handler, capture);
//        }
//        else if (element.attachEvent) {
//            element.attachEvent('on' + eventType, handler);
//        }
//    }
//    catch (e) { }
//};

//// createIframeLayer for Menu Bar
//// creates an IFRAME underneath a menu so that it will show above form controls and ActiveX
//Spry.Widget.MenuBar.prototype.createIframeLayer = function(menu) {
//    var layer = document.createElement('iframe');
//    layer.tabIndex = '-1';
//    layer.src = 'javascript:false;';
//    menu.parentNode.appendChild(layer);

//    layer.style.left = menu.offsetLeft + 'px';
//    layer.style.top = menu.offsetTop + 'px';
//    layer.style.width = menu.offsetWidth + 'px';
//    layer.style.height = menu.offsetHeight + 'px';
//};

//// removeIframeLayer for Menu Bar
//// removes an IFRAME underneath a menu to reveal any form controls and ActiveX
//Spry.Widget.MenuBar.prototype.removeIframeLayer = function(menu) {
//    var layers = menu.parentNode.getElementsByTagName('iframe');
//    while (layers.length > 0) {
//        layers[0].parentNode.removeChild(layers[0]);
//    }
//};

//// clearMenus for Menu Bar
//// root is the top level unordered list (<ul> tag)
//Spry.Widget.MenuBar.prototype.clearMenus = function(root) {
//    var menus = root.getElementsByTagName('ul');
//    for (var i = 0; i < menus.length; i++) {
//        this.hideSubmenu(menus[i]);
//    }
//    this.removeClassName(this.element, "MenuBarActive");
//};

//// bubbledTextEvent for Menu Bar
//// identify bubbled up text events in Safari so we can ignore them
//Spry.Widget.MenuBar.prototype.bubbledTextEvent = function() {
//    return (navigator.vendor == 'Apple Computer, Inc.' && (event.target == event.relatedTarget.parentNode || (event.eventPhase == 3 && event.target.parentNode == event.relatedTarget)));
//};

//// showSubmenu for Menu Bar
//// set the proper CSS class on this menu to show it
//Spry.Widget.MenuBar.prototype.showSubmenu = function(menu) {
//    if (this.currMenu) {
//        this.clearMenus(this.currMenu);
//        this.currMenu = null;
//    }

//    if (menu) {
//        this.addClassName(menu, "MenuBarSubmenuVisible");
//        if (typeof document.all != 'undefined' && typeof window.opera == 'undefined' && navigator.vendor != 'KDE') {
//            if (!this.hasClassName(this.element, "MenuBarHorizontal") || menu.parentNode.parentNode != this.element) {
//                menu.style.top = menu.parentNode.offsetTop + 'px';
//            }
//        }
//        if (typeof document.uniqueID != "undefined") {
//            this.createIframeLayer(menu);
//        }
//    }
//    this.addClassName(this.element, "MenuBarActive");
//};

//// hideSubmenu for Menu Bar
//// remove the proper CSS class on this menu to hide it
//Spry.Widget.MenuBar.prototype.hideSubmenu = function(menu) {
//    if (menu) {
//        this.removeClassName(menu, "MenuBarSubmenuVisible");
//        if (typeof document.all != 'undefined' && typeof window.opera == 'undefined' && navigator.vendor != 'KDE') {
//            menu.style.top = '';
//            menu.style.left = '';
//        }
//        this.removeIframeLayer(menu);
//    }
//};

//// initialize for Menu Bar
//// create event listeners for the Menu Bar widget so we can properly
//// show and hide submenus
//Spry.Widget.MenuBar.prototype.initialize = function(listitem, element, isie) {
//    var opentime, closetime;
//    var link = listitem.getElementsByTagName('a')[0];
//    var submenus = listitem.getElementsByTagName('ul');
//    var menu = (submenus.length > 0 ? submenus[0] : null);

//    var hasSubMenu = false;
//    if (menu) {
//        this.addClassName(link, "MenuBarItemSubmenu");
//        hasSubMenu = true;
//    }

//    if (!isie) {
//        // define a simple function that comes standard in IE to determine
//        // if a node is within another node
//        listitem.contains = function(testNode) {
//            // this refers to the list item
//            if (testNode == null) {
//                return false;
//            }
//            if (testNode == this) {
//                return true;
//            }
//            else {
//                return this.contains(testNode.parentNode);
//            }
//        };
//    }

//    // need to save this for scope further down
//    var self = this;

//    this.addEventListener(listitem, 'mouseover', function(e) {
//        if (self.bubbledTextEvent()) {
//            // ignore bubbled text events
//            return;
//        }
//        clearTimeout(closetime);
//        if (self.currMenu == listitem) {
//            self.currMenu = null;
//        }
//        // show menu highlighting
//        self.addClassName(link, hasSubMenu ? "MenuBarItemSubmenuHover" : "MenuBarItemHover");
//        if (menu && !self.hasClassName(menu, "MenuBarSubmenuVisible")) {
//            opentime = window.setTimeout(function() { self.showSubmenu(menu); }, 200);
//        }
//    }, false);

//    this.addEventListener(listitem, 'mouseout', function(e) {
//        if (self.bubbledTextEvent()) {
//            // ignore bubbled text events
//            return;
//        }

//        var related = (typeof e.relatedTarget != 'undefined' ? e.relatedTarget : e.toElement);
//        if (!listitem.contains(related)) {
//            clearTimeout(opentime);
//            self.currMenu = listitem;

//            // remove menu highlighting
//            self.removeClassName(link, hasSubMenu ? "MenuBarItemSubmenuHover" : "MenuBarItemHover");
//            if (menu) {
//                closetime = window.setTimeout(function() { self.hideSubmenu(menu); }, 200);
//            }
//        }
//    }, false);
//};
