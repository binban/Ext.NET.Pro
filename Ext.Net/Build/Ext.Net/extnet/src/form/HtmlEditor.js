
// @source core/form/HtmlEditor.js

Ext.form.field.HtmlEditor.override({
    escapeValue: true,

    initComponent: function () {
        this.callParent(arguments);
        if (this.initialConfig && this.initialConfig.buttonTips) {
            this.buttonTips = Ext.Object.merge(Ext.clone(Ext.form.field.HtmlEditor.prototype.buttonTips), this.buttonTips);
        }

        if (!this.name) {
            this.name = this.id || this.inputId || Ext.id();
        }
    },

    getSubTplData: function () {
        var cssPrefix = Ext.baseCSSPrefix;

        return {
            $comp: this,
            cmpId: this.id,
            id: this.getInputId(),
            textareaCls: Ext.baseCSSPrefix + 'hidden',
            value: this.value,
            iframeName: Ext.id(),
            iframeSrc: Ext.SSL_SECURE_URL,
            size: 'height:100%;width:100%;',
            name: this.submitValue ? this.getName() : undefined
        };
    },

    syncValue: function () {
        var me = this,
            body, changed, html, bodyStyle, match;
        if (me.initialized) {
            body = me.getEditorBody();
            html = body.innerHTML;
            if (Ext.isWebKit) {
                bodyStyle = body.getAttribute('style'); // Safari puts text-align styles on the body element!
                match = bodyStyle.match(/text-align:(.*?);/i);
                if (match && match[1]) {
                    html = '<div style="' + match[0] + '">' + html + '</div>';
                }
            }
            html = me.cleanHtml(html);
            if (me.fireEvent('beforesync', me, html) !== false) {

                if (me.textareaEl.dom.value != html) {
                    this.textareaEl.dom.value = this.escapeValue ? escape(html) : html;
                    changed = true;
                }

                me.fireEvent('sync', me, html);

                if (changed && !me.inSync) {
                    // we have to guard this to avoid infinite recursion because getValue
                    // calls this method...
                    me.inSync = true;
                    me.checkChange();
                    delete me.isSync;
                }
            }
        }
    },

    setValue: function (value) {
        var me = this,
            textarea = me.textareaEl;
        me.mixins.field.setValue.call(me, value);
        if (value === null || value === undefined) {
            value = '';
        }
        if (textarea) {
            textarea.dom.value = this.escapeValue ? escape(value) : value;
        }
        me.pushValue();
        return this;
    },


    getValue: function () {
        var me = this,
            value;
        if (!me.sourceEditMode) {
            me.syncValue();
        }
        value = me.rendered ? me.textareaEl.dom.value : me.value;
        me.value = value;

        return this.escapeValue ? unescape(value) : value;
    },

    toggleSourceEdit: function (sourceEditMode) {
        var me = this,
            iframe = me.iframeEl,
            textarea = me.textareaEl,
            hiddenCls = Ext.baseCSSPrefix + 'hidden',
            btn = me.getToolbar().getComponent('sourceedit');

        if (!Ext.isBoolean(sourceEditMode)) {
            sourceEditMode = !me.sourceEditMode;
        }
        me.sourceEditMode = sourceEditMode;

        if (btn.pressed !== sourceEditMode) {
            btn.toggle(sourceEditMode);
        }
        if (sourceEditMode) {
            me.disableItems(true);
            me.syncValue();
            if (this.escapeValue) {
                textarea.dom.value = unescape(this.textareaEl.dom.value);
            }
            iframe.addCls(hiddenCls);
            textarea.removeCls(hiddenCls);
            textarea.dom.removeAttribute('tabIndex');
            textarea.focus();
            me.inputEl = textarea;
        }
        else {
            if (me.initialized) {
                me.disableItems(me.readOnly);
            }
            me.pushValue();
            if (this.escapeValue) {
                textarea.dom.value = escape(this.textareaEl.dom.value);
            }
            iframe.removeCls(hiddenCls);
            textarea.addCls(hiddenCls);
            textarea.dom.setAttribute('tabIndex', -1);
            me.deferFocus();
            me.inputEl = iframe;
        }
        me.fireEvent('editmodechange', me, sourceEditMode);
        me.doComponentLayout();
    },

    pushValue: function () {
        var me = this,
            v;
        if (me.initialized) {
            v = (me.escapeValue ? unescape(me.textareaEl.dom.value) : me.textareaEl.dom.value) || "";
            if (!me.activated && v.length < 1) {
                v = me.defaultValue;
            }
            if (me.fireEvent('beforepush', me, v) !== false) {
                me.getEditorBody().innerHTML = v;
                if (Ext.isGecko) {
                    // Gecko hack, see: https://bugzilla.mozilla.org/show_bug.cgi?id=232791#c8
                    me.setDesignMode(false);  //toggle off first
                    me.setDesignMode(true);
                }
                me.fireEvent('push', me, v);
            }
        }
    },

    onEditorEvent: function () {
        if (Ext.isIE) {
            this.currentRange = this.getDoc().selection.createRange();
        }
        this.updateToolbar();
    },

    insertAtCursor: function (text) {
        if (!this.activated) {
            return;
        }

        this.win.focus();

        if (Ext.isIE) {
            var doc = this.getDoc(),
                r = this.currentRange || doc.selection.createRange();

            if (r) {
                r.pasteHTML(text);
                this.syncValue();
                this.deferFocus();
            }
        } else {
            this.execCmd("InsertHTML", text);
            this.deferFocus();
        }
    }
});

/// TODO:   The following fixes an issue in IE only 
///         where a bulleted list is not created properly.
///         Need to check this fix with future releases of ExtJS. 
Ext.form.field.HtmlEditor.override({
    fixKeys : (function () { // load time branching for fastest keydown performance
        if (Ext.isIE) {
            return function (e) {
                var me = this,
                    k = e.getKey(),
                    doc = me.getDoc(),
                    readOnly = me.readOnly,
                    range, target;

                if (k === e.TAB) {
                    e.stopEvent();
                    if (!readOnly) {
                        range = doc.selection.createRange();
                        if (range) {
                            range.collapse(true);
                            range.pasteHTML('&#160;&#160;&#160;&#160;');
                            me.deferFocus();
                        }
                    }
                }
//                else if (k === e.ENTER) {
//                    if (!readOnly) {
//                        range = doc.selection.createRange();
//                        if (range) {
//                            target = range.parentElement();

//                            if (!target || target.tagName.toLowerCase() !== 'li') {
//                                e.stopEvent();
//                                range.pasteHTML('<br />');
//                                range.collapse(false);
//                                range.select();
//                            }
//                        }
//                    }
//                }
            };
        }

        if (Ext.isOpera) {
            return function (e) {
                var me = this;
                if (e.getKey() === e.TAB) {
                    e.stopEvent();
                    if (!me.readOnly) {
                        me.win.focus();
                        me.execCmd('InsertHTML', '&#160;&#160;&#160;&#160;');
                        me.deferFocus();
                    }
                }
            };
        }

        if (Ext.isWebKit) {
            return function (e) {
                var me = this,
                    k = e.getKey(),
                    readOnly = me.readOnly;

                if (k === e.TAB) {
                    e.stopEvent();
                    if (!readOnly) {
                        me.execCmd('InsertText', '\t');
                        me.deferFocus();
                    }
                }
                else if (k === e.ENTER) {
                    e.stopEvent();
                    if (!readOnly) {
                        me.execCmd('InsertHtml', '<br /><br />');
                        me.deferFocus();
                    }
                }
            };
        }

        return null; // not needed, so null
    } ())
});