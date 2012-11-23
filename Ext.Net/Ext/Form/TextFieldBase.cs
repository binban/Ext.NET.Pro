/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for all Text Field Web Controls.
    /// </summary>
    [Meta]
    [Description("Base Class for all Text Field Web Controls.")]
    public abstract partial class TextFieldBase : Field, IEditableTextControl
    {
        /*  ITextControl
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Category("6. TextField")]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public virtual string Text
        {
            get
            {
                object val = this.Value;
                return val == null ? "" : this.Value.ToString();
            }
            set
            {
                this.Value = value == "" ? null : value;
            }
        }

        /// <summary>
        /// Get or Set the RawValue as a string value.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Category("6. TextField")]
        [Localizable(true)]
        [Description("The Text value to initialize this field with.")]
        public virtual string RawText
        {
            get
            {
                return this.RawValue != null ? this.RawValue.ToString() : "";
            }
            set
            {
                this.RawValue = value; 
            }
        }

        /// <summary>
        /// False to validate that the value length > 0 (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(true)]
        [Description("False to validate that the value length > 0 (defaults to true).")]
        public virtual bool AllowBlank
        {
            get
            {
                return this.State.Get<bool>("AllowBlank", true);
            }
            set
            {
                this.State.Set("AllowBlank", value);
            }
        }

        /// <summary>
        /// Specify false to automatically trim the value before validating the whether the value is blank. Setting this to false automatically sets AllowBlank to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(true)]
        [Description("Specify false to automatically trim the value before validating the whether the value is blank. Setting this to false automatically sets AllowBlank to false.")]
        public virtual bool AllowOnlyWhitespace
        {
            get
            {
                return this.State.Get<bool>("AllowOnlyWhitespace", true);
            }
            set
            {
                this.State.Set("AllowOnlyWhitespace", value);
            }
        }

        /// <summary>
        /// Error text to display if the allow blank validation fails (defaults to 'This field is required').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the allow blank validation fails (defaults to 'This field is required').")]
        public virtual string BlankText
        {
            get
            {
                return this.State.Get<string>("BlankText", "");
            }
            set
            {
                this.State.Set("BlankText", value);
            }
        }

        /// <summary>
        /// True to disable input keystroke filtering (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to disable input keystroke filtering (defaults to false).")]
        public virtual bool DisableKeyFilter
        {
            get
            {
                return this.State.Get<bool>("DisableKeyFilter", false);
            }
            set
            {
                this.State.Set("DisableKeyFilter", value);
            }
        }

        /// <summary>
        /// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Description("The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.")]
        public virtual string EmptyCls
        {
            get
            {
                return this.State.Get<string>("EmptyCls", "");
            }
            set
            {
                this.State.Set("EmptyCls", value);
            }
        }

        /// <summary>
        /// The default text to place into an empty field.
        /// 
        /// Note that normally this value will be submitted to the server if this field is enabled; to prevent this you can set the submitEmptyText option of Ext.form.Basic.submit to false.
        /// 
        /// Also note that if you use inputType:'file', emptyText is not supported and should be avoided.
        /// 
        /// Note that for browsers that support it, setting this property will use the HTML 5 placeholder attribute, and for older browsers that don't support the HTML 5 placeholder attribute the value will be placed directly into the input element itself as the raw value. This means that older browsers will obfuscate the emptyText value for password input fields.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The default text to display in an empty field (defaults to null).")]
        public virtual string EmptyText
        {
            get
            {
                return this.State.Get<string>("EmptyText", "");
            }
            set
            {
                this.State.Set("EmptyText", value);
            }
        }

        /// <summary>
        /// True to enable the proxying of key events for the HTML input field (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to enable the proxying of key events for the HTML input field (defaults to false)")]
        public virtual bool EnableKeyEvents
        {
            get
            {
                return this.State.Get<bool>("EnableKeyEvents", false);
            }
            set
            {
                this.State.Set("EnableKeyEvents", value);
            }
        }

        /// <summary>
        /// True to set the maxLength property on the underlying input field. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to set the maxLength property on the underlying input field. Defaults to false")]
        public virtual bool EnforceMaxLength
        {
            get
            {
                return this.State.Get<bool>("EnforceMaxLength", false);
            }
            set
            {
                this.State.Set("EnforceMaxLength", value);
            }
        }

        /// <summary>
        /// True if this field should automatically grow and shrink to its content (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True if this field should automatically grow and shrink to its content (defaults to false).")]
        public virtual bool Grow
        {
            get
            {
                return this.State.Get<bool>("Grow", false);
            }
            set
            {
                this.State.Set("Grow", value);
            }
        }

        /// <summary>
        /// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital "W" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("W")]
        [Description("A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital \"W\" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.")]
        public virtual string GrowAppend
        {
            get
            {
                return this.State.Get<string>("GrowAppend", "W");
            }
            set
            {
                this.State.Set("GrowAppend", value);
            }
        }

        /// <summary>
        /// The maximum width to allow when grow = true (defaults to 800).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(800)]
        [Description("The maximum width to allow when grow = true (defaults to 800).")]
        public virtual int GrowMax
        {
            get
            {
                return this.State.Get<int>("GrowMax", 800);
            }
            set
            {
                this.State.Set("GrowMax", value);
            }
        }

        /// <summary>
        /// The minimum width to allow when grow = true (defaults to 30).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(30)]
        [Description("The minimum width to allow when grow = true (defaults to 30).")]
        public virtual int GrowMin
        {
            get
            {
                return this.State.Get<int>("GrowMin", 30);
            }
            set
            {
                this.State.Set("GrowMin", value);
            }
        }

        /// <summary>
        /// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [DirectEventUpdate(MethodName="SetMaskRe")]
        [Description("An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.")]
        public virtual string MaskRe
        {
            get
            {
                return this.State.Get<string>("MaskRe", "");
            }
            set
            {
                this.State.Set("MaskRe", value);
            }
        }

        /// <summary>
        /// Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(-1)]
        [Description("Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.")]
        public virtual int MaxLength
        {
            get
            {
                return this.State.Get<int>("MaxLength", -1);
            }
            set
            {
                this.State.Set("MaxLength", value);
            }
        }

        /// <summary>
        /// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').")]
        public virtual string MaxLengthText
        {
            get
            {
                return this.State.Get<string>("MaxLengthText", "");
            }
            set
            {
                this.State.Set("MaxLengthText", value);
            }
        }

        /// <summary>
        /// Minimum input field length required (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(0)]
        [Description("Minimum input field length required (defaults to 0).")]
        public virtual int MinLength
        {
            get
            {
                return this.State.Get<int>("MinLength", 0);
            }
            set
            {
                this.State.Set("MinLength", value);
            }
        }

        /// <summary>
        /// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').")]
        public virtual string MinLengthText
        {
            get
            {
                return this.State.Get<string>("MinLengthText", "");
            }
            set
            {
                this.State.Set("MinLengthText", value);
            }
        }

        /// <summary>
        /// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.")]
        public virtual string Regex
        {
            get
            {
                return this.State.Get<string>("Regex", "");
            }
            set
            {
                this.State.Set("Regex", value);
            }
        }

        /// <summary>
        /// The error text to display if regex is used and the test fails during validation (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display if regex is used and the test fails during validation (defaults to '').")]
        public virtual string RegexText
        {
            get
            {
                return this.State.Get<string>("RegexText", "");
            }
            set
            {
                this.State.Set("RegexText", value);
            }
        }

        /// <summary>
        /// True to automatically select any existing field text when the field receives input focus (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to automatically select any existing field text when the field receives input focus (defaults to false).")]
        public virtual bool SelectOnFocus
        {
            get
            {
                return this.State.Get<bool>("SelectOnFocus", false);
            }
            set
            {
                this.State.Set("SelectOnFocus", value);
            }
        }

        /// <summary>
        /// An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(20)]
        [Description("An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.")]
        public virtual int Size
        {
            get
            {
                return this.State.Get<int>("Size", 20);
            }
            set
            {
                this.State.Set("Size", value);
            }
        }

        /// <summary>
        /// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.")]
        public virtual string StripCharsRe
        {
            get
            {
                return this.State.Get<string>("StripCharsRe", "");
            }
            set
            {
                this.State.Set("StripCharsRe", value);
            }
        }        

        private static readonly object EventTextChanged = new object();

        /// <summary>
        /// Fires when the Text property has been changed.
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed.")]
        public event EventHandler TextChanged
        {
            add
            {
                this.CheckForceId();
				Events.AddHandler(EventTextChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventTextChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTextChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            this.OnTextChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];
            val = val != null && val.Equals(this.EmptyText) ? "" : val;

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val != null && this.Text != val)
            {
                bool raise = val != (this.Text ?? "");

                try
                {
                    this.SuspendScripting();
                    this.Text = val.Equals(this.EmptyText) ? "" : val;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return raise;
            }

            return false;
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Automatically grows the field to accomodate the width of the text up to the maximum field width allowed. This only takes effect if grow = true, and fires the autosize event if the width changes.
        /// </summary>
        [Meta]
        public virtual void AutoSize()
        {
            this.Call("autoSize");
        }

        /// <summary>
        /// Selects text in this field
        /// </summary>
        [Meta]
        public virtual void SelectText()
        {
            this.Call("selectText");
        }

        /// <summary>
        /// Selects text in this field
        /// </summary>
        /// <param name="start">The index where the selection should start (defaults to 0)</param>
        [Meta]
        public virtual void SelectText(int start)
        {
            this.Call("selectText", start);
        }

        /// <summary>
        /// Selects text in this field
        /// </summary>
        /// <param name="start">The index where the selection should start (defaults to 0)</param>
        /// <param name="end">The index where the selection should end (defaults to the text length)</param>
        [Meta]
        [Description("Selects text in this field")]
        public virtual void SelectText(int start, int end)
        {
            this.Call("selectText", start, end);
        }

        /// <summary>
        /// The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "#" + this.Icon.ToString();
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this field.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Category("5. Button")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this field.")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override List<Icon> Icons
        {
            get
            {
                List<Icon> icons = base.Icons;
                icons.Capacity += 1;
                icons.Add(this.Icon);
                return icons;
            }
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconCls(string cls)
        {
            this.Call("setIconCls", cls);
        }

        /// <summary>
        /// Sets an input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).
        /// </summary>
        /// <param name="maskRe"></param>
        [Description("Sets an input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).")]
        protected void SetMaskRe(string maskRe)
        {
            this.Set("maskRe", new JRawValue(maskRe.StartsWith("/") ? maskRe : maskRe.Wrap("/")));
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconCls(Icon icon)
        {
            if (this.Icon != Icon.None)
            {
                this.SetIconCls("#" + icon.ToString());
            }
            else
            {
                this.SetIconCls("");
            }
        }
    }
}