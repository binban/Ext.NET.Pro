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
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class MenuItemBase : ComponentBase, IIcon, IAutoPostBack, IPostBackEventHandler, IButtonControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            base.OnBeforeClientInitHandler();

            if (this.OnClientClick.IsNotEmpty())
            {
                this.Handler = new JFunction(TokenUtils.ParseTokens(this.OnClientClick, this), "el", "e").ToScript();
            }
        }

        /*  PostBack
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("click")]
        [Description("")]
        public virtual string PostBackEvent
        {
            get
            {
                return this.State.Get<string>("PostBackEvent", "click");
            }
            set
            {
                this.State.Set("PostBackEvent", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [UrlProperty("*.aspx")]
        [Editor("System.Web.UI.Design.UrlEditor", typeof(UITypeEditor))]
        [Description("")]
        public virtual string PostBackUrl
        {
            get
            {
                return this.State.Get<string>("PostBackUrl", "");
            }
            set
            {
                this.State.Set("PostBackUrl", value);
            }
        }


        /*  EventClick
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventClick = new object();

        /// <summary>
        /// Fires when the button has been clicked
        /// </summary>
        [Category("Action")]
        [Description("Fires when the button has been clicked")]
        public event EventHandler Click
        {
            add
            {
                this.CheckForceId();
				this.Events.AddHandler(EventClick, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventClick, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventClick];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        [Description("")]
        protected virtual void RaisePostBackEvent(string eventArgument)
        {
            if (this.CausesValidation)
            {
                this.Page.Validate(this.ValidationGroup);
            }
            this.OnClick(EventArgs.Empty);
            this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.RaisePostBackEvent(eventArgument);
        }


        /*  EventCommand
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventCommand = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event CommandEventHandler Command
        {
            add
            {
                this.CheckForceId();
				base.Events.AddHandler(EventCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCommand, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnCommand(CommandEventArgs e)
        {
            CommandEventHandler handler = (CommandEventHandler)base.Events[EventCommand];

            if (handler != null)
            {
                handler(this, e);
            }
            base.RaiseBubbleEvent(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public virtual string CommandName
        {
            get
            {
                return this.State.Get<string>("CommandName", "");
            }
            set
            {
                this.State.Set("CommandName", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public virtual string CommandArgument
        {
            get
            {
                return this.State.Get<string>("CommandArgument", "");
            }
            set
            {
                this.State.Set("CommandArgument", value);
            }
        }

        /// <summary>
        /// The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.
        /// </summary>
        [Meta]
        [Category("5. Item")]
        [DefaultValue("")]
        [Description("The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.")]
        public virtual string OnClientClick
        {
            get
            {
                return this.State.Get<string>("OnClientClick", "");
            }
            set
            {
                this.State.Set("OnClientClick", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.")]
        public virtual bool AutoPostBack
        {
            get
            {
                return this.State.Get<bool>("AutoPostBack", false);
            }
            set
            {
                this.State.Set("AutoPostBack", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                return this.State.Get<bool>("CausesValidation", true);
            }
            set
            {
                this.State.Set("CausesValidation", value);
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return this.State.Get<string>("ValidationGroup", "");
            }
            set
            {
                this.State.Set("ValidationGroup", value);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public MenuBase ParentMenu
        {
            get
            {
                return (MenuBase)ReflectionUtils.GetTypeOfParent(this, typeof(MenuBase));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// The CSS class added to the menu item when the item is activated (focused/mouseover). Defaults to Ext.baseCSSPrefix + 'menu-item-active'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MenuItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class added to the menu item when the item is activated (focused/mouseover). Defaults to Ext.baseCSSPrefix + 'menu-item-active'.")]
        public virtual string ActiveCls
        {
            get
            {
                return this.State.Get<string>("ActiveCls", "");
            }
            set
            {
                this.State.Set("ActiveCls", value);
            }
        }

        /// <summary>
        /// Whether or not this menu item can be activated when focused/mouseovered. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MenuItem")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Whether or not this menu item can be activated when focused/mouseovered. Defaults to true.")]
        public virtual bool CanActivate
        {
            get
            {
                return this.State.Get<bool>("CanActivate", true);
            }
            set
            {
                this.State.Set("CanActivate", value);
            }
        }

        /// <summary>
        /// The delay in milliseconds to wait before hiding the menu after clicking the menu item. This only has an effect when hideOnClick: true. Defaults to 1.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MenuItem")]
        [DefaultValue(1)]
        [NotifyParentProperty(true)]
        [Description("The delay in milliseconds to wait before hiding the menu after clicking the menu item. This only has an effect when hideOnClick: true. Defaults to 1.")]
        public virtual int ClickHideDelay
        {
            get
            {
                return this.State.Get<int>("ClickHideDelay", 1);
            }
            set
            {
                this.State.Set("ClickHideDelay", value);
            }
        }

        /// <summary>
        /// A function that will handle the click event of this menu item (defaults to undefined).
        /// Parameters
        /// item : Ext.menu.Item
        /// The item that was clicked
        /// e : Ext.EventObject
        /// The underyling Ext.EventObject.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(FunctionJsonConverter))]
        [Category("4. MenuItem")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName="SetHandler")]
        [NotifyParentProperty(true)]
        [Description("A function that will handle the click event of this menu item (defaults to undefined).")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler function will be called.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. MenuItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope (this reference) in which the handler function will be called.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// Whether or not to destroy any associated sub-menu when this item is destroyed. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MenuItem")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Whether or not to destroy any associated sub-menu when this item is destroyed. Defaults to true.")]
        public virtual bool DestroyMenu
        {
            get
            {
                return this.State.Get<bool>("DestroyMenu", true);
            }
            set
            {
                this.State.Set("DestroyMenu", value);
            }
        }

        /// <summary>
        /// Whether to not to hide the owning menu when this item is clicked. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. MenuItem")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Whether to not to hide the owning menu when this item is clicked. Defaults to true.")]
        public virtual bool HideOnClick
        {
            get
            {
                return this.State.Get<bool>("HideOnClick", true);
            }
            set
            {
                this.State.Set("HideOnClick", value);
            }
        }

        /// <summary>
        /// The href attribute to use for the underlying anchor link. Defaults to #.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("#")]
        [NotifyParentProperty(true)]
        [Description("The href attribute to use for the underlying anchor link. Defaults to #.")]
        public virtual string Href
        {
            get
            {
                return this.State.Get<string>("Href", "#");
            }
            set
            {
                this.State.Set("Href", value);
            }
        }

        /// <summary>
        /// The target attribute to use for the underlying anchor link. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target attribute to use for the underlying anchor link. Defaults to undefined.")]
        public virtual string HrefTarget
        {
            get
            {
                return this.State.Get<string>("HrefTarget", "");
            }
            set
            {
                this.State.Set("HrefTarget", value);
            }
        }

        /// <summary>
        /// The path to an icon to display in this item. Defaults to Ext.BLANK_IMAGE_URL.
        /// </summary>
        [Meta]
        [ConfigOption("icon", JsonMode.Url)]
        [DirectEventUpdate(MethodName="SetIconUrl")]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The path to an icon to display in this item. Defaults to Ext.BLANK_IMAGE_URL.")]
        public virtual string IconUrl
        {
            get
            {
                return this.State.Get<string>("IconUrl", "");
            }
            set
            {
                this.State.Set("IconUrl", value);
            }
        }

        /// <summary>
        /// A CSS class that specifies a background-image to use as the icon for this item. Defaults to undefined.
        /// </summary>
        [Meta]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("A CSS class that specifies a background-image to use as the icon for this item. Defaults to undefined.")]
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
        /// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. Item")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconCls")]
        [Description("The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.")]
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

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
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
        /// The default Ext.Element.getAlignToXY anchor position value for this item's sub-menu relative to this item's position. Defaults to 'tl-tr?'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default Ext.Element.getAlignToXY anchor position value for this item's sub-menu relative to this item's position. Defaults to 'tl-tr?'.")]
        public virtual string MenuAlign
        {
            get
            {
                return this.State.Get<string>("MenuAlign", "");
            }
            set
            {
                this.State.Set("MenuAlign", value);
            }
        }


        /// <summary>
        /// The delay in milliseconds before this item's sub-menu expands after this item is moused over. Defaults to 200.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("The delay in milliseconds before this item's sub-menu expands after this item is moused over. Defaults to 200.")]
        public virtual int MenuExpandDelay 
        {
            get
            {
                return this.State.Get<int>("MenuExpandDelay", 200);
            }
            set
            {
                this.State.Set("MenuExpandDelay", value);
            }
        }

        /// <summary>
        /// The delay in milliseconds before this item's sub-menu hides after this item is moused out. Defaults to 200.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("The delay in milliseconds before this item's sub-menu hides after this item is moused out. Defaults to 200.")]
        public virtual int MenuHideDelay
        {
            get
            {
                return this.State.Get<int>("MenuHideDelay", 200);
            }
            set
            {
                this.State.Set("MenuHideDelay", value);
            }
        }

        /// <summary>
        /// Whether or not this item is plain text/html with no icon or visual activation. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Whether or not this item is plain text/html with no icon or visual activation. Defaults to false.")]
        public virtual bool Plain
        {
            get
            {
                return this.State.Get<bool>("Plain", false);
            }
            set
            {
                this.State.Set("Plain", value);
            }
        }

        /// <summary>
        /// The text to display in this item (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.WithSet)]
        [Description("The text to display in this item (defaults to '').")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        private MenuCollection menu;

        /// <summary>
        /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
        /// </summary>
        [Meta]
        [ConfigOption("menu", typeof(SingleItemCollectionJsonConverter))]
        [Category("5. Item")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob")]
        public virtual MenuCollection Menu
        {
            get
            {
                if (this.menu == null)
                {
                    this.menu = new MenuCollection();
                    this.menu.AfterItemAdd += this.AfterItemAdd;
                    this.menu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.menu;
            }
        }

        /// <summary>
        /// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted) or QuickTips config object.
        /// </summary>
        [Meta]
        [ConfigOption("tooltip")]
        [DirectEventUpdate(MethodName = "SetTooltip")]
        [Localizable(true)]
        [Category("5. Item")]
        [DefaultValue("")]
        [ReadOnly(false)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted) or QuickTips config object.")]
        public override string ToolTip
        {
            get
            {
                return this.State.Get<string>("ToolTip", "");
            }
            set
            {
                this.State.Set("ToolTip", value);
            }
        }

        private QTipCfg qTipCfg;

        /// <summary>
        /// A tip string.
        /// </summary>
        [Meta]
        [ConfigOption("tooltip", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tip string.")]
        public virtual QTipCfg QTipCfg
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

        /// <summary>
        /// The type of tooltip to use. Either 'qtip' for QuickTips or 'title' for title attribute. Defaults to: "qtip"
        /// </summary>
        [Meta]
        [ConfigOption("tooltipType")]
        [Localizable(true)]
        [Category("5. Item")]
        [DefaultValue(ToolTipType.Qtip)]
        [Description("The type of tooltip to use. Either 'qtip' for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"")]
        public virtual ToolTipType ToolTipType
        {
            get
            {
                return this.State.Get<ToolTipType>("ToolTipType", ToolTipType.Qtip);
            }
            set
            {
                this.State.Set("ToolTipType", value);
            }
        }

        /// <summary>
        /// Sets the click handler of this item
        /// </summary>
        /// <param name="handler">The handler function</param>
        protected virtual void SetHandler(string handler)
        {
            this.Call("setHandler", JRawValue.From(handler));
        }

        /// <summary>
        /// Sets the iconCls of this item
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconCls(string cls)
        {
            this.Call("setIconCls", cls);
        }

        /// <summary>
        /// Sets the iconCls of this item
        /// </summary>
        protected virtual void SetIconCls(Icon icon)
        {
            this.SetIconCls(this.Icon != Icon.None ? "#" + icon.ToString() : "");
        }

        /// <summary>
        /// Sets the icon on this item.
        /// </summary>
        /// <param name="url">The new icon</param>
        protected virtual void SetIconUrl(string url)
        {
            this.Call("setIcon", this.ResolveUrlLink(url));
        }

        /// <summary>
        /// Set a child menu for this item. See the menu configuration.
        /// </summary>
        /// <param name="menu">A menu, or menu configuration. null may be passed to remove the menu.</param>
        /// <param name="destroyMenu">True to destroy any existing menu. False to prevent destruction. If not specified, the destroyMenu configuration will be used.</param>
        public virtual void SetMenu(MenuBase menu, bool destroyMenu)
        {
            this.Call("setMenu", menu != null ? menu.ToConfig() : null, destroyMenu);
        }

        /// <summary>
        /// Set a child menu for this item. See the menu configuration.
        /// </summary>
        /// <param name="menu">A menu, or menu configuration. null may be passed to remove the menu.</param>
        public virtual void SetMenu(MenuBase menu)
        {
            this.Call("setMenu", menu != null ? menu.ToConfig() : null);
        }

        /// <summary>
        /// Sets the tooltip for this menu item.
        /// </summary>
        /// <param name="tooltip">A string to be used as innerHTML (html tags are accepted) to show in a tooltip</param>
        protected virtual void SetTooltip(string tooltip)
        {
            this.Call("setTooltip", tooltip);
        }

        /// <summary>
        /// Sets the tooltip for this menu item.
        /// </summary>
        /// <param name="config">A configuration object for Ext.tip.QuickTipManager.register.</param>
        public virtual void SetTooltip(QTipCfg config)
        {
            this.Call("setTooltip", new JRawValue(new ClientConfig().Serialize(config, true)));
        }
    }
}