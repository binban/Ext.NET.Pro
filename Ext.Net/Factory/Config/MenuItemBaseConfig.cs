/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string postBackEvent = "click";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("click")]
			public virtual string PostBackEvent 
			{ 
				get
				{
					return this.postBackEvent;
				}
				set
				{
					this.postBackEvent = value;
				}
			}

			private string postBackUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string PostBackUrl 
			{ 
				get
				{
					return this.postBackUrl;
				}
				set
				{
					this.postBackUrl = value;
				}
			}

			private string onClientClick = "";

			/// <summary>
			/// The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.
			/// </summary>
			[DefaultValue("")]
			public virtual string OnClientClick 
			{ 
				get
				{
					return this.onClientClick;
				}
				set
				{
					this.onClientClick = value;
				}
			}

			private bool autoPostBack = false;

			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private bool causesValidation = true;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

			private string activeCls = "";

			/// <summary>
			/// The CSS class added to the menu item when the item is activated (focused/mouseover). Defaults to Ext.baseCSSPrefix + 'menu-item-active'.
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveCls 
			{ 
				get
				{
					return this.activeCls;
				}
				set
				{
					this.activeCls = value;
				}
			}

			private bool canActivate = true;

			/// <summary>
			/// Whether or not this menu item can be activated when focused/mouseovered. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CanActivate 
			{ 
				get
				{
					return this.canActivate;
				}
				set
				{
					this.canActivate = value;
				}
			}

			private int clickHideDelay = 1;

			/// <summary>
			/// The delay in milliseconds to wait before hiding the menu after clicking the menu item. This only has an effect when hideOnClick: true. Defaults to 1.
			/// </summary>
			[DefaultValue(1)]
			public virtual int ClickHideDelay 
			{ 
				get
				{
					return this.clickHideDelay;
				}
				set
				{
					this.clickHideDelay = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// A function that will handle the click event of this menu item (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope (this reference) in which the handler function will be called.
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private bool destroyMenu = true;

			/// <summary>
			/// Whether or not to destroy any associated sub-menu when this item is destroyed. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DestroyMenu 
			{ 
				get
				{
					return this.destroyMenu;
				}
				set
				{
					this.destroyMenu = value;
				}
			}

			private bool hideOnClick = true;

			/// <summary>
			/// Whether to not to hide the owning menu when this item is clicked. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideOnClick 
			{ 
				get
				{
					return this.hideOnClick;
				}
				set
				{
					this.hideOnClick = value;
				}
			}

			private string href = "#";

			/// <summary>
			/// The href attribute to use for the underlying anchor link. Defaults to #.
			/// </summary>
			[DefaultValue("#")]
			public virtual string Href 
			{ 
				get
				{
					return this.href;
				}
				set
				{
					this.href = value;
				}
			}

			private string hrefTarget = "";

			/// <summary>
			/// The target attribute to use for the underlying anchor link. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string HrefTarget 
			{ 
				get
				{
					return this.hrefTarget;
				}
				set
				{
					this.hrefTarget = value;
				}
			}

			private string iconUrl = "";

			/// <summary>
			/// The path to an icon to display in this item. Defaults to Ext.BLANK_IMAGE_URL.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconUrl 
			{ 
				get
				{
					return this.iconUrl;
				}
				set
				{
					this.iconUrl = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A CSS class that specifies a background-image to use as the icon for this item. Defaults to undefined.
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

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
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

			private string menuAlign = "";

			/// <summary>
			/// The default Ext.Element.getAlignToXY anchor position value for this item's sub-menu relative to this item's position. Defaults to 'tl-tr?'.
			/// </summary>
			[DefaultValue("")]
			public virtual string MenuAlign 
			{ 
				get
				{
					return this.menuAlign;
				}
				set
				{
					this.menuAlign = value;
				}
			}

			private int menuExpandDelay = 200;

			/// <summary>
			/// The delay in milliseconds before this item's sub-menu expands after this item is moused over. Defaults to 200.
			/// </summary>
			[DefaultValue(200)]
			public virtual int MenuExpandDelay 
			{ 
				get
				{
					return this.menuExpandDelay;
				}
				set
				{
					this.menuExpandDelay = value;
				}
			}

			private int menuHideDelay = 200;

			/// <summary>
			/// The delay in milliseconds before this item's sub-menu hides after this item is moused out. Defaults to 200.
			/// </summary>
			[DefaultValue(200)]
			public virtual int MenuHideDelay 
			{ 
				get
				{
					return this.menuHideDelay;
				}
				set
				{
					this.menuHideDelay = value;
				}
			}

			private bool plain = false;

			/// <summary>
			/// Whether or not this item is plain text/html with no icon or visual activation. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Plain 
			{ 
				get
				{
					return this.plain;
				}
				set
				{
					this.plain = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The text to display in this item (defaults to '').
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
        
			private MenuCollection menu = null;

			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
			/// </summary>
			public MenuCollection Menu
			{
				get
				{
					if (this.menu == null)
					{
						this.menu = new MenuCollection();
					}
			
					return this.menu;
				}
			}
			
			private string toolTip = "";

			/// <summary>
			/// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted) or QuickTips config object.
			/// </summary>
			[DefaultValue("")]
			public override string ToolTip 
			{ 
				get
				{
					return this.toolTip;
				}
				set
				{
					this.toolTip = value;
				}
			}
        
			private QTipCfg qTipCfg = null;

			/// <summary>
			/// A tip string.
			/// </summary>
			public QTipCfg QTipCfg
			{
				get
				{
					if (this.qTipCfg == null)
					{
						this.qTipCfg = new QTipCfg();
					}
			
					return this.qTipCfg;
				}
			}
			
			private ToolTipType toolTipType = ToolTipType.Qtip;

			/// <summary>
			/// The type of tooltip to use. Either 'qtip' for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"
			/// </summary>
			[DefaultValue(ToolTipType.Qtip)]
			public virtual ToolTipType ToolTipType 
			{ 
				get
				{
					return this.toolTipType;
				}
				set
				{
					this.toolTipType = value;
				}
			}

        }
    }
}