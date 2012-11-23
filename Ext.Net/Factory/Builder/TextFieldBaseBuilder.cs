/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
        new public abstract partial class Builder<TTextFieldBase, TBuilder> : Field.Builder<TTextFieldBase, TBuilder>
            where TTextFieldBase : TextFieldBase
            where TBuilder : Builder<TTextFieldBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTextFieldBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual TBuilder RawText(string rawText)
            {
                this.ToComponent().RawText = rawText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify false to automatically trim the value before validating the whether the value is blank. Setting this to false automatically sets AllowBlank to false.
			/// </summary>
            public virtual TBuilder AllowOnlyWhitespace(bool allowOnlyWhitespace)
            {
                this.ToComponent().AllowOnlyWhitespace = allowOnlyWhitespace;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable input keystroke filtering (defaults to false).
			/// </summary>
            public virtual TBuilder DisableKeyFilter(bool disableKeyFilter)
            {
                this.ToComponent().DisableKeyFilter = disableKeyFilter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
			/// </summary>
            public virtual TBuilder EmptyCls(string emptyCls)
            {
                this.ToComponent().EmptyCls = emptyCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text to display in an empty field (defaults to null).
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable the proxying of key events for the HTML input field (defaults to false)
			/// </summary>
            public virtual TBuilder EnableKeyEvents(bool enableKeyEvents)
            {
                this.ToComponent().EnableKeyEvents = enableKeyEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to set the maxLength property on the underlying input field. Defaults to false
			/// </summary>
            public virtual TBuilder EnforceMaxLength(bool enforceMaxLength)
            {
                this.ToComponent().EnforceMaxLength = enforceMaxLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if this field should automatically grow and shrink to its content (defaults to false).
			/// </summary>
            public virtual TBuilder Grow(bool grow)
            {
                this.ToComponent().Grow = grow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a single capital \"W\" (the widest character in common fonts) to leave enough space for the next typed character and avoid the field value shifting before the width is adjusted.
			/// </summary>
            public virtual TBuilder GrowAppend(string growAppend)
            {
                this.ToComponent().GrowAppend = growAppend;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
            public virtual TBuilder GrowMax(int growMax)
            {
                this.ToComponent().GrowMax = growMax;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 30).
			/// </summary>
            public virtual TBuilder GrowMin(int growMin)
            {
                this.ToComponent().GrowMin = growMin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An input mask regular expression that will be used to filter keystrokes (character being typed) that do not match. Note: It dose not filter characters already in the input.
			/// </summary>
            public virtual TBuilder MaskRe(string maskRe)
            {
                this.ToComponent().MaskRe = maskRe;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Maximum input field length allowed by validation (defaults to Number.MAX_VALUE). This behavior is intended to provide instant feedback to the user by improving usability to allow pasting and editing or overtyping and back tracking. To restrict the maximum number of characters that can be entered into the field use the enforceMaxLength option.
			/// </summary>
            public virtual TBuilder MaxLength(int maxLength)
            {
                this.ToComponent().MaxLength = maxLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
            public virtual TBuilder MaxLengthText(string maxLengthText)
            {
                this.ToComponent().MaxLengthText = maxLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
            public virtual TBuilder MinLength(int minLength)
            {
                this.ToComponent().MinLength = minLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
            public virtual TBuilder MinLengthText(string minLengthText)
            {
                this.ToComponent().MinLengthText = minLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A JavaScript RegExp object to be tested against the field value during validation (defaults to undefined). If the test fails, the field will be marked invalid using regexText.
			/// </summary>
            public virtual TBuilder Regex(string regex)
            {
                this.ToComponent().Regex = regex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display if regex is used and the test fails during validation (defaults to '').
			/// </summary>
            public virtual TBuilder RegexText(string regexText)
            {
                this.ToComponent().RegexText = regexText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
            public virtual TBuilder SelectOnFocus(bool selectOnFocus)
            {
                this.ToComponent().SelectOnFocus = selectOnFocus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An initial value for the 'size' attribute on the text input element. This is only used if the field has no configured width and is not given a width by its container's layout. Defaults to 20.
			/// </summary>
            public virtual TBuilder Size(int size)
            {
                this.ToComponent().Size = size;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A JavaScript RegExp object used to strip unwanted content from the value during input. If stripCharsRe is specified, every character sequence matching stripCharsRe will be removed.
			/// </summary>
            public virtual TBuilder StripCharsRe(string stripCharsRe)
            {
                this.ToComponent().StripCharsRe = stripCharsRe;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this field.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AutoSize()
            {
                this.ToComponent().AutoSize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectText()
            {
                this.ToComponent().SelectText();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectText(int start)
            {
                this.ToComponent().SelectText(start);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects text in this field
			/// </summary>
            public virtual TBuilder SelectText(int start, int end)
            {
                this.ToComponent().SelectText(start, end);
                return this as TBuilder;
            }
            
        }        
    }
}