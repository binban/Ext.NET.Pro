/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public abstract partial class MenuItemBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TMenuItemBase, TBuilder> : ComponentBase.Builder<TMenuItemBase, TBuilder>
            where TMenuItemBase : MenuItemBase
            where TBuilder : Builder<TMenuItemBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMenuItemBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackEvent(string postBackEvent)
            {
                this.ToComponent().PostBackEvent = postBackEvent;
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
			/// The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.
			/// </summary>
            public virtual TBuilder OnClientClick(string onClientClick)
            {
                this.ToComponent().OnClientClick = onClientClick;
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
             
 			/// <summary>
			/// The CSS class added to the menu item when the item is activated (focused/mouseover). Defaults to Ext.baseCSSPrefix + 'menu-item-active'.
			/// </summary>
            public virtual TBuilder ActiveCls(string activeCls)
            {
                this.ToComponent().ActiveCls = activeCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not this menu item can be activated when focused/mouseovered. Defaults to true.
			/// </summary>
            public virtual TBuilder CanActivate(bool canActivate)
            {
                this.ToComponent().CanActivate = canActivate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The delay in milliseconds to wait before hiding the menu after clicking the menu item. This only has an effect when hideOnClick: true. Defaults to 1.
			/// </summary>
            public virtual TBuilder ClickHideDelay(int clickHideDelay)
            {
                this.ToComponent().ClickHideDelay = clickHideDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function that will handle the click event of this menu item (defaults to undefined).
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which the handler function will be called.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not to destroy any associated sub-menu when this item is destroyed. Defaults to true.
			/// </summary>
            public virtual TBuilder DestroyMenu(bool destroyMenu)
            {
                this.ToComponent().DestroyMenu = destroyMenu;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether to not to hide the owning menu when this item is clicked. Defaults to true.
			/// </summary>
            public virtual TBuilder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The href attribute to use for the underlying anchor link. Defaults to #.
			/// </summary>
            public virtual TBuilder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The target attribute to use for the underlying anchor link. Defaults to undefined.
			/// </summary>
            public virtual TBuilder HrefTarget(string hrefTarget)
            {
                this.ToComponent().HrefTarget = hrefTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The path to an icon to display in this item. Defaults to Ext.BLANK_IMAGE_URL.
			/// </summary>
            public virtual TBuilder IconUrl(string iconUrl)
            {
                this.ToComponent().IconUrl = iconUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class that specifies a background-image to use as the icon for this item. Defaults to undefined.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default Ext.Element.getAlignToXY anchor position value for this item's sub-menu relative to this item's position. Defaults to 'tl-tr?'.
			/// </summary>
            public virtual TBuilder MenuAlign(string menuAlign)
            {
                this.ToComponent().MenuAlign = menuAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The delay in milliseconds before this item's sub-menu expands after this item is moused over. Defaults to 200.
			/// </summary>
            public virtual TBuilder MenuExpandDelay(int menuExpandDelay)
            {
                this.ToComponent().MenuExpandDelay = menuExpandDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The delay in milliseconds before this item's sub-menu hides after this item is moused out. Defaults to 200.
			/// </summary>
            public virtual TBuilder MenuHideDelay(int menuHideDelay)
            {
                this.ToComponent().MenuHideDelay = menuHideDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether or not this item is plain text/html with no icon or visual activation. Defaults to false.
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display in this item (defaults to '').
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Menu(Action<MenuCollection> action)
            {
                action(this.ToComponent().Menu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted) or QuickTips config object.
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
			/// The type of tooltip to use. Either 'qtip' for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"
			/// </summary>
            public virtual TBuilder ToolTipType(ToolTipType toolTipType)
            {
                this.ToComponent().ToolTipType = toolTipType;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}