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
    public abstract partial class ButtonBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TButtonBase, TBuilder> : ComponentBase.Builder<TButtonBase, TBuilder>
            where TButtonBase : ButtonBase
            where TBuilder : Builder<TButtonBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TButtonBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to enable stand out by default (defaults to false).
			/// </summary>
            public virtual TBuilder StandOut(bool standOut)
            {
                this.ToComponent().StandOut = standOut;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackUrl(string postBackUrl)
            {
                this.ToComponent().PostBackUrl = postBackUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.
			/// </summary>
            public virtual TBuilder OnClientClick(string onClientClick)
            {
                this.ToComponent().OnClientClick = onClientClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PressedHiddenName(string pressedHiddenName)
            {
                this.ToComponent().PressedHiddenName = pressedHiddenName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.
			/// </summary>
            public virtual TBuilder AllowDepress(bool allowDepress)
            {
                this.ToComponent().AllowDepress = allowDepress;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.
			/// </summary>
            public virtual TBuilder ArrowAlign(ArrowAlign arrowAlign)
            {
                this.ToComponent().ArrowAlign = arrowAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The className used for the inner arrow element if the button has a menu.
			/// </summary>
            public virtual TBuilder ArrowCls(string arrowCls)
            {
                this.ToComponent().ArrowCls = arrowCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object literal of parameters to pass to the url when the href property is specified.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder BaseParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().BaseParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The DOM event that will fire the handler of the button. This can be any valid event name (dblclick, contextmenu). Defaults to: \"click\"
			/// </summary>
            public virtual TBuilder ClickEvent(string clickEvent)
            {
                this.ToComponent().ClickEvent = clickEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable pressed/not pressed toggling (defaults to false).
			/// </summary>
            public virtual TBuilder EnableToggle(bool enableToggle)
            {
                this.ToComponent().EnableToggle = enableToggle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to add to a button when it is in the focussed state. Defaults to: \"focus\"
			/// </summary>
            public virtual TBuilder FocusCls(string focusCls)
            {
                this.ToComponent().FocusCls = focusCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to apply a flat style.
			/// </summary>
            public virtual TBuilder Flat(bool flat)
            {
                this.ToComponent().Flat = flat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).
			/// </summary>
            public virtual TBuilder HandleMouseEvents(bool handleMouseEvents)
            {
                this.ToComponent().HandleMouseEvents = handleMouseEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function called when the button is clicked (can be used instead of click event).
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The URL to open when the button is clicked.
			/// </summary>
            public virtual TBuilder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The target attribute to use for the underlying anchor. Only used if the href property is specified. Defaults to: \"_blank\"
			/// </summary>
            public virtual TBuilder HrefTarget(string hrefTarget)
            {
                this.ToComponent().HrefTarget = hrefTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The path to an image to display in the button (the image will be set as the background-image CSS property of the button by default, so if you want a mixed icon/text button, set cls:'x-btn-text-icon')
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The side of the Button box to render the icon. Defaults to 'Left'.
			/// </summary>
            public virtual TBuilder IconAlign(IconAlign iconAlign)
            {
                this.ToComponent().IconAlign = iconAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The path to an image to display in the button
			/// </summary>
            public virtual TBuilder IconUrl(string iconUrl)
            {
                this.ToComponent().IconUrl = iconUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to hide the Menu arrow drop down arrow (defaults to true).
			/// </summary>
            public virtual TBuilder MenuArrow(bool menuArrow)
            {
                this.ToComponent().MenuArrow = menuArrow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Menu(Action<MenuCollection> action)
            {
                action(this.ToComponent().Menu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The CSS class to add to a button when it's menu is active. Defaults to: \"menu-active\"
			/// </summary>
            public virtual TBuilder MenuActiveCls(string menuActiveCls)
            {
                this.ToComponent().MenuActiveCls = menuActiveCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
			/// </summary>
            public virtual TBuilder MenuAlign(string menuAlign)
            {
                this.ToComponent().MenuAlign = menuAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If used in a Toolbar, the text to be used if this item is shown in the overflow menu.
			/// </summary>
            public virtual TBuilder OverflowText(string overflowText)
            {
                this.ToComponent().OverflowText = overflowText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object literal of parameters to pass to the url when the href property is specified. Any params override baseParams. New params can be set using the setParams method.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Params(Action<ParameterCollection> action)
            {
                action(this.ToComponent().Params);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to start pressed (only if enableToggle = true). Defaults to: false
			/// </summary>
            public virtual TBuilder Pressed(bool pressed)
            {
                this.ToComponent().Pressed = pressed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to add to a button when it is in the pressed state. Defaults to: \"pressed\"
			/// </summary>
            public virtual TBuilder PressedCls(string pressedCls)
            {
                this.ToComponent().PressedCls = pressedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to prevent the default action when the clickEvent is processed. Defaults to: true
			/// </summary>
            public virtual TBuilder PreventDefault(bool preventDefault)
            {
                this.ToComponent().PreventDefault = preventDefault;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to repeat fire the click event while the mouse is down. (defaults to false).
			/// </summary>
            public virtual TBuilder Repeat(bool repeat)
            {
                this.ToComponent().Repeat = repeat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler and toggleHandler is executed. Defaults to this Button.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The size of the Button. Defaults to 'Small'.
			/// </summary>
            public virtual TBuilder Scale(ButtonScale scale)
            {
                this.ToComponent().Scale = scale;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set a DOM tabIndex for this button (defaults to undefined).
			/// </summary>
            public virtual TBuilder TabIndex(short tabIndex)
            {
                this.ToComponent().TabIndex = tabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The button text to be used as innerHTML (html tags are accepted).
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text alignment for this button (center, left, right). Defaults to: \"center\"
			/// </summary>
            public virtual TBuilder TextAlign(ButtonTextAlign textAlign)
            {
                this.ToComponent().TextAlign = textAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Function called when a Button with enableToggle set to true is clicked.
			/// </summary>
            public virtual TBuilder ToggleHandler(string toggleHandler)
            {
                this.ToComponent().ToggleHandler = toggleHandler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).
			/// </summary>
            public virtual TBuilder ToggleGroup(string toggleGroup)
            {
                this.ToComponent().ToggleGroup = toggleGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.
			/// </summary>
            public virtual TBuilder ToolTip(string toolTip)
            {
                this.ToComponent().ToolTip = toolTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A tip string.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder QTipCfg(Action<QTipCfg> action)
            {
                action(this.ToComponent().QTipCfg);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.
			/// </summary>
            public virtual TBuilder ToolTipType(ToolTipType toolTipType)
            {
                this.ToComponent().ToolTipType = toolTipType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The type of input to create: submit, reset or button. Defaults to: \"button\"
			/// </summary>
            public virtual TBuilder Type(ButtonType type)
            {
                this.ToComponent().Type = type;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Hide this button's menu (if it has one)
			/// </summary>
            public virtual TBuilder HideMenu()
            {
                this.ToComponent().HideMenu();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetTooltip(string tooltip)
            {
                this.ToComponent().SetTooltip(tooltip);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetTooltip(QTipCfg config)
            {
                this.ToComponent().SetTooltip(config);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowMenu()
            {
                this.ToComponent().ShowMenu();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Toggle()
            {
                this.ToComponent().Toggle();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Toggle(bool state)
            {
                this.ToComponent().Toggle(state);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Toggle(bool state, bool suppressEvent)
            {
                this.ToComponent().Toggle(state, suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
			/// </summary>
            public virtual TBuilder ToggleMenuArrow()
            {
                this.ToComponent().ToggleMenuArrow();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
			/// </summary>
            public virtual TBuilder ToggleMenuArrow(bool state)
            {
                this.ToComponent().ToggleMenuArrow(state);
                return this as TBuilder;
            }
            
        }        
    }
}