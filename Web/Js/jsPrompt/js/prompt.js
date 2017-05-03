dom = { getById: function(id) {
    return document.getElementById(id);
}, get: function(e) {
    return (typeof (e) == "string") ? document.getElementById(e) : e;
}, createElementIn: function(tagName, elem, insertFirst, attrs) {
    var _e = (elem = dom.get(elem) || document.body).ownerDocument.createElement(tagName || "div"), k;
    if (typeof (attrs) == 'object') {
        for (k in attrs) {
            if (k == "class") {
                _e.className = attrs[k];
            } else if (k == "style") {
                _e.style.cssText = attrs[k];
            } else {
                _e[k] = attrs[k];
            }
        }
    }
    insertFirst ? elem.insertBefore(_e, elem.firstChild) : elem.appendChild(_e);
    return _e;
}, getStyle: function(el, property) {
    el = dom.get(el);
    if (!el || el.nodeType == 9) {
        return null;
    }
    var w3cMode = document.defaultView && document.defaultView.getComputedStyle, computed = !w3cMode ? null : document.defaultView.getComputedStyle(el, ''), value = "";
    switch (property) {
        case "float":
            property = w3cMode ? "cssFloat" : "styleFloat";
            break;
        case "opacity":
            if (!w3cMode) {
                var val = 100;
                try {
                    val = el.filters['DXImageTransform.Microsoft.Alpha'].opacity;
                } catch (e) {
                    try {
                        val = el.filters('alpha').opacity;
                    } catch (e) {
                    }
                }
                return val / 100;
            } else {
                return parseFloat((computed || el.style)[property]);
            }
            break;
        case "backgroundPositionX":
            if (w3cMode) {
                property = "backgroundPosition";
                return ((computed || el.style)[property]).split(" ")[0];
            }
            break;
        case "backgroundPositionY":
            if (w3cMode) {
                property = "backgroundPosition";
                return ((computed || el.style)[property]).split(" ")[1];
            }
            break;
    }
    if (w3cMode) {
        return (computed || el.style)[property];
    } else {
        return (el.currentStyle[property] || el.style[property]);
    }
}, setStyle: function(el, properties, value) {
    if (!(el = dom.get(el)) || el.nodeType != 1) {
        return false;
    }
    var tmp, bRtn = true, w3cMode = (tmp = document.defaultView) && tmp.getComputedStyle, rexclude = /z-?index|font-?weight|opacity|zoom|line-?height/i;
    if (typeof (properties) == 'string') {
        tmp = properties;
        properties = {};
        properties[tmp] = value;
    }
    for (var prop in properties) {
        value = properties[prop];
        if (prop == 'float') {
            prop = w3cMode ? "cssFloat" : "styleFloat";
        } else if (prop == 'opacity') {
            if (!w3cMode) {
                prop = 'filter';
                value = value >= 1 ? '' : ('alpha(opacity=' + Math.round(value * 100) + ')');
            }
        } else if (prop == 'backgroundPositionX' || prop == 'backgroundPositionY') {
            tmp = prop.slice(-1) == 'X' ? 'Y' : 'X';
            if (w3cMode) {
                var v = dom.getStyle(el, "backgroundPosition" + tmp);
                prop = 'backgroundPosition';
                typeof (value) == 'number' && (value = value + 'px');
                value = tmp == 'Y' ? (value + " " + (v || "top")) : ((v || 'left') + " " + value);
            }
        }
        if (typeof el.style[prop] != "undefined") {
            el.style[prop] = value + (typeof value === "number" && !rexclude.test(prop) ? 'px' : '');
            bRtn = bRtn && true;
        } else {
            bRtn = bRtn && false;
        }
    }
    return bRtn;
}
};

string = { RegExps: { trim: /^\s+|\s+$/g, ltrim: /^\s+/, rtrim: /\s+$/, nl2br: /\n/g, s2nb: /[\x20]{2}/g, URIencode: /[\x09\x0A\x0D\x20\x21-\x29\x2B\x2C\x2F\x3A-\x3F\x5B-\x5E\x60\x7B-\x7E]/g, escHTML: { re_amp: /&/g, re_lt: /</g, re_gt: />/g, re_apos: /\x27/g, re_quot: /\x22/g }, escString: { bsls: /\\/g, sls: /\//g, nl: /\n/g, rt: /\r/g, tab: /\t/g }, restXHTML: { re_amp: /&amp;/g, re_lt: /&lt;/g, re_gt: /&gt;/g, re_apos: /&(?:apos|#0?39);/g, re_quot: /&quot;/g }, write: /\{(\d{1,2})(?:\:([xodQqb]))?\}/g, isURL: /^(?:ht|f)tp(?:s)?\:\/\/(?:[\w\-\.]+)\.\w+/i, cut: /[\x00-\xFF]/, getRealLen: { r0: /[^\x00-\xFF]/g, r1: /[\x00-\xFF]/g }, format: /\{([\d\w\.]+)\}/g }, commonReplace: function(s, p, r) {
    return s.replace(p, r);
}, format: function(str) {
    var args = Array.prototype.slice.call(arguments), v;
    str = String(args.shift());
    if (args.length == 1 && typeof (args[0]) == 'object') {
        args = args[0];
    }
    string.RegExps.format.lastIndex = 0;
    return str.replace(string.RegExps.format, function(m, n) {
        v = object.route(args, n);
        return v === undefined ? m : v;
    });
}
};

object = {
    routeRE: /([\d\w_]+)/g,
    route: function(obj, path) {
        obj = obj || {};
        path = String(path);
        var r = object.routeRE, m;
        r.lastIndex = 0;
        while ((m = r.exec(path)) !== null) {
            obj = obj[m[0]];
            if (obj === undefined || obj === null) {
                break;
            }
        }
        return obj;
    }
};

var ua = userAgent = {}, agent = navigator.userAgent;
ua.ie = 9 - ((agent.indexOf('Trident/5.0') > -1) ? 0 : 1) - (window.XDomainRequest ? 0 : 1) - (window.XMLHttpRequest ? 0 : 1);

if (typeof (msgbox) == 'undefined') {
    msgbox = {};
}
msgbox._timer = null;
msgbox.loadingAnimationPath = msgbox.loadingAnimationPath || ("loading.gif");
msgbox.prompt = function (msgHtml, type, timeout, opts) {
    $("#q_MsgboxShade").remove();
    $(".msgbox_layer_wrap").hide();
    if (typeof (opts) == 'number') {
        opts = { topPosition: opts };
    }
    opts = opts || {};
    var _s = msgbox,
    mBox = document.getElementById("q_Msgbox") || dom.createElementIn("div", document.body, false, { className: "msgbox_layer_wrap" });
    $("#q_Msgbox").css("display", "block");
    mBox.id = "q_Msgbox";
    var showType = "";
    var loadIcon = "";
    if (type == 1) {
        showType = "hits";
    }
    else if (type == 2) {
        showType = "succ";
    }
    else if (type == 3) {
        showType = "fail";
    }
    else if (type == 4) {
        showType = "clear";
        loadIcon = "<span class=\"gtl_ico_loading\"></span>";
        timeout = "loading";
        $("#q_Msgbox").after("<div id='q_MsgboxShade' style='width:100%;height:100%;position:fixed;top:0px;left:0px;z-index:998;filter:alpha(opacity=40);opacity: 0.4;background-color:white;'></div>");
    }
    else {
        showType = "hits";
    }
    var html = "<span class=\"msgbox_layer\" style=\"display:none;z-index:10000;\" id=\"mode_tips_v2\"><span class=\"gtl_ico_" + showType + "\"></span>" + loadIcon + msgHtml + "<span class=\"gtl_end\"></span></span>";
    mBox.innerHTML = html;
    _s._setPosition(mBox, timeout, opts.topPosition);
};
msgbox._setPosition = function(tips, timeout, topPosition) {
    tips.firstChild.style.display = "";
    var curWidth = $(".msgbox_layer_wrap").width() + $(".msgbox_layer > span:eq(0)").width() + $(".msgbox_layer > span:eq(1)").width();
    var _s = msgbox, bt = ($(window).width() - curWidth) / 2, ch = $(window).height() - 120;
    $(tips).css({ "left": bt + $(".msgbox_layer > span:eq(0)").width() + "px", "top": ch + "px" });
    clearTimeout(_s._timer);
    if (timeout != "loading") {
        timeout = timeout || 3000;
        timeout && (_s._timer = window.top.setTimeout(_s.hidden, timeout));
    }
};
msgbox.hidden = function(timeout) {
    var _s = msgbox;
    if (timeout) {
        clearTimeout(_s._timer);
        _s._timer = window.top.setTimeout(_s._hidden, timeout);
    } else {
        _s._hidden();
    }
};
msgbox._hidden = function() {
    $("#q_MsgboxShade").remove();
    $(".msgbox_layer_wrap").hide();
};