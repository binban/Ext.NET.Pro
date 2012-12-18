/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class TextFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string text = "";

			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private string rawText = "";

			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
			[DefaultValue("")]
			public virtual string RawText 
			{ 
				get
				{
					return this.rawText;
				}
				set
				{
					this.rawText = value;
				}
			}

			private bool allowBlank = true;

			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlank 
			{ 
				get
				{
					return this.allowBlank;
				}
				set
				{
					this.allowBlank = value;
				}
			}

			private bool allowOnlyWhitespace = true;

			/// <summary>
			/// Specify false to automatically trim the value before validating the whether the value is blank. Setting this to false automatically sets AllowBlank to false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowOnlyWhitespace 
			{ 
				get
				{
					return this.allowOnlyWhitespace;
				}
				set
				{
					this.allowOnlyWhitespace = value;
				}
			}

			private string blankText = "";

			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
			[DefaultValue("")]
			public virtual string BlankText 
			{ 
				get
				{
					return this.blankText;
				}
				set
				{
					this.blankText = value;
				}
			}

			private bool disableKeyFilter = false;

			/// <summary>
			/// True to disable input keystroke filtering (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableKeyFilter 
			{ 
				get
				{
					return this.disableKeyFilter;
				}
				set
				{
					this.disableKeyFilter = value;
				}
			}

			private string emptyCls = "";

			/// <summary>
			/// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyCls 
			{ 
				get
				{
					return this.emptyCls;
				}
				set
				{
					this.emptyCls = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// The default text to display in an empty field (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private bool enableKeyEvents = false;

			/// <summary>
			/// True to enable the proxying of key events for the HTML input field (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableKeyEvents 
			{ 
				get
				{
					return this.enableKeyEvents;
				}
				set
				{
					this.enableKeyEvents = value;
				}
			}

			private bool enforceMaxLength = false;

			/// <summary>
			/// True to set the maxLength property on the underlying input field. Defaults to false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnforceMaxLength 
			{ 
				get
				{
					return this.enforceMaxLength;
				}
				set
				{
					this.enforceMaxLength = value;
				}
			}

			private bool grow = false;

			/// <summary>
			/// True if this field should automatically grow and shrink to its content (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Grow 
			{ 
				get
				{
					return this.grow;
				}
				set
				{
					this.grow = value;
				}
			}

			private string growAppend = "W";

			/// <summary>
			/// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital \"W\" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
			/// </summary>
			[DefaultValue("W")]
			public virtual string GrowAppend 
			{ 
				get
				{
					return this.growAppend;
				}
				set
				{
					this.growAppend = value;
				}
			}

			private int growMax = 800;

			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
			[DefaultValue(800)]
			public virtual int GrowMax 
			{ 
				get
				{
					return this.growMax;
				}
				set
				{
					this.growMax = value;
				}
			}

			private int growMin = 30;

			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 30).
			/// </summary>
			[DefaultValue(30)]
			public virtual int GrowMin 
			{ 
				get
				{
					return this.growMin;
				}
				set
				{
					this.growMin = value;
				}
			}

			private string maskRe = "";

			/// <summary>
			/// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
			/// </summary>
			[DefaultValue("")]
			public virtual string MaskRe 
			{ 
				get
				{
					return this.maskRe;
				}
				set
				{
					this.maskRe = value;
				}
			}

			private int maxLength = -1;

			/// <summary>
			/// Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.
			/// </summary>
			[DefaultValue(-1)]
			public virtual int MaxLength 
			{ 
				get
				{
					return this.maxLength;
				}
				set
				{
					this.maxLength = value;
				}
			}

			private string maxLengthText = "";

			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxLengthText 
			{ 
				get
				{
					return this.maxLengthText;
				}
				set
				{
					this.maxLengthText = value;
				}
			}

			private int minLength = 0;

			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinLength 
			{ 
				get
				{
					return this.minLength;
				}
				set
				{
					this.minLength = value;
				}
			}

			private string minLengthText = "";

			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinLengthText 
			{ 
				get
				{
					return this.minLengthText;
				}
				set
				{
					this.minLengthText = value;
				}
			}

			private string regex = "";

			/// <summary>
			/// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
			/// </summary>
			[DefaultValue("")]
			public virtual string Regex 
			{ 
				get
				{
					return this.regex;
				}
				set
				{
					this.regex = value;
				}
			}

			private string regexText = "";

			/// <summary>
			/// The error text to display if regex is used and the test fails during validation (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string RegexText 
			{ 
				get
				{
					return this.regexText;
				}
				set
				{
					this.regexText = value;
				}
			}

			private bool selectOnFocus = false;

			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SelectOnFocus 
			{ 
				get
				{
					return this.selectOnFocus;
				}
				set
				{
					this.selectOnFocus = value;
				}
			}

			private int size = 20;

			/// <summary>
			/// An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.
			/// </summary>
			[DefaultValue(20)]
			public virtual int Size 
			{ 
				get
				{
					return this.size;
				}
				set
				{
					this.size = value;
				}
			}

			private string stripCharsRe = "";

			/// <summary>
			/// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
			/// </summary>
			[DefaultValue("")]
			public virtual string StripCharsRe 
			{ 
				get
				{
					return this.stripCharsRe;
				}
				set
				{
					this.stripCharsRe = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A css class which sets a background image to be used as the icon for this field.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

        }
    }
}