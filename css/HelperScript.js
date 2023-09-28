document.onkeydown = function() {
    var e = event || window.event;
    var keyASCII = parseInt(e.keyCode, 10);
    var src = e.srcElement;
    var tag = src.tagName.toUpperCase();
    if (keyASCII == 13) {
        return false;
    }
    if (keyASCII == 8) {
        if (src.readOnly || src.disabled || (tag != "INPUT" && tag != "TEXTAREA")) {
            return false;
        }
        if (src.type) {
            var type = ("" + src.type).toUpperCase();
            return type != "CHECKBOX" && type != "RADIO" && type != "BUTTON";
        }
    }
    return true;
}
//        document.onkeydown = function() {
//            var e = event || window.event;
//            var keyASCII = parseInt(e.keyCode, 10);
//            if (e.button == 2) {
//                alert("No right click");
//            }
//        }
function DissableRightClick() {
    var e = event || window.event;
    if (e.button == 2) {
        alert("Right click is not allowed as per security reason");
    }
}
document.onmousedown = DissableRightClick;
history.go(1);

function NOFill(id) {
    var txt = document.getElementById(id);
    txt.setAttribute("autocomplete", "off");

}
//============ CapsLock img CODE start =================//
function capsLock(e) {
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
   
   
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("CapsLock").style.display = "block";
    } else {
        document.getElementById("CapsLock").style.display = "none";
    }
}

function EnterPwd(e) {
    //kc = e.keycode ? e.keycode : e.which;
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("EnterPwd_div").style.display = "block";
    } else {
    document.getElementById("EnterPwd_div").style.display = "none";
    }
}

function ReEnterPwd(e) {
    //kc = e.keycode ? e.keycode : e.which;
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("ReEnterPwd_div").style.display = "block";
    } else {
    document.getElementById("ReEnterPwd_div").style.display = "none";
    }
}

function OldPwd(e) {
    //kc = e.keycode ? e.keycode : e.which;
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("OldPwd_div").style.display = "block";
    } else {
    document.getElementById("OldPwd_div").style.display = "none";
    }
}

function NewPwd(e) {
    //kc = e.keycode ? e.keycode : e.which;
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("NewPwd_div").style.display = "block";
    } else {
    document.getElementById("NewPwd_div").style.display = "none";
    }
}

function frmChangepasswordpage_NewPwd(e) {
    //kc = e.keycode ? e.keycode : e.which;
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("NewPwd_div").style.display = "block";
    } else {
        document.getElementById("NewPwd_div").style.display = "none";
    }
}

function frmChangepasswordpage_OldPwd(e) {
    //kc = e.keycode ? e.keycode : e.which;
    e = (e) ? e : event;
    //alert(window)
    if (navigator.appName == "Microsoft Internet Explorer") {
        kc = e.keyCode;
    }
    else {
        kc = e.charCode;
    }
    sk = e.shiftkey ? e.shiftkey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
        document.getElementById("OldPwd_div").style.display = "block";
    } else {
        document.getElementById("OldPwd_div").style.display = "none";
    }
}