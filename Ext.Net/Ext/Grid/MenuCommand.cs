/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class MenuCommand : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MenuCommand() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("command")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string CommandName
        {
            get
            {
                return (string)this.ViewState["CommandName"] ?? "";
            }
            set
            {
                this.ViewState["CommandName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(Ext.Net.Icon.None)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Ext.Net.Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string IconCls
        {
            get
            {
                if (this.Icon != Ext.Net.Icon.None)
                {
                    return "icon-{0}".FormatWith(this.Icon.ToString().ToLower());
                }

                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Text
        {
            get
            {
                return (string)this.ViewState["Text"] ?? "";
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CtCls
        {
            get
            {
                return (string)this.ViewState["CtCls"] ?? "";
            }
            set
            {
                this.ViewState["CtCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Disabled
        {
            get
            {
                object obj = this.ViewState["Disabled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Disabled"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DisabledClass
        {
            get
            {
                return (string)this.ViewState["DisabledClass"] ?? "";
            }
            set
            {
                this.ViewState["DisabledClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool Hidden
        {
            get
            {
                object obj = this.ViewState["Hidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Hidden"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string OverCls
        {
            get
            {
                return (string)this.ViewState["OverCls"] ?? "";
            }
            set
            {
                this.ViewState["OverCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }

        private CommandMenu menu;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("menu", JsonMode.Object)]
        [Category("2. MenuCommand")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public virtual CommandMenu Menu
        {
            get
            {
                if (this.menu == null)
                {
                    this.menu = new CommandMenu();
                }

                return this.menu;
            }
        }

        /// <summary>
        /// A function that will handle the click event of this menu item (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("2. MenuCommand")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A function that will handle the click event of this menu item (defaults to undefined).")]
        public virtual string Handler
        {
            get
            {
                return (string)this.ViewState["Handler"] ?? "";
            }
            set
            {
                this.ViewState["Handler"] = value;
            }
        }

        /// <summary>
        /// True to hide the containing menu after this item is clicked (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. MenuCommand")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to hide the containing menu after this item is clicked (defaults to true).")]
        public virtual bool HideOnClick
        {
            get
            {
                object obj = this.ViewState["HideOnClick"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HideOnClick"] = value;
            }
        }
    }
}