﻿Ext.onReady(function(){
    var el = Ext.DomHelper.append(document.body, {
        tag : "div",
        id: "unlicensed",
        children : [{
            tag: "div",
            id: "popaction",
            children: [{
                tag : "a",
                target : "_blank",
                href : "http://www.ext.net/store/",
                children: [{
                    tag: "img",
                    width: 137,
                    height: 49,
                    src: Ext.net.ResourceMgr.resolveUrl("~/extnet/unlicensed/images/unlicensed-button-txt-png/ext.axd")
                }]
            }]
        }]
    }, true);

    el.alignTo(document, "br-br", [-20,-20]);
    el.slideIn("b", { 
        callback: function () {
            (function(){
                el.slideOut("b", {
                    callback : function () {
                        el.remove.defer(100, el);
                    }
                });
            }).defer(20000);
        } 
    });
}, window, {delay:500});