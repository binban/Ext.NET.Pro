/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [DefaultProperty("Handler")]
    [TypeConverter(typeof(ToolConverter))]
    [ToolboxItem(false)]
    public partial class Tool : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Tool() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Tool(ToolType type)
        {
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Tool(ToolType type, string handler, string qtip) 
        {
            this.Type = type;
            this.Handler = handler;
            this.Qtip = qtip;
        }

        /// <summary>
        /// The type of tool to create.
        /// </summary>
        [ConfigOption("id", JsonMode.ToLower)]
        [DefaultValue(ToolType.None)]
        [NotifyParentProperty(true)]
        [Description("The type of tool to create.")]
        public virtual ToolType Type
        {
            get
            {
                object obj = this.ViewState["Type"];
                return (obj == null) ? ToolType.None : (ToolType)obj;
            }
            set
            {
                this.ViewState["Type"] = value;
            }
        }

        /// <summary>
        /// The custom type of tool to create.
        /// </summary>
        [ConfigOption("id")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The custom type of tool to create.")]
        public string CustomType
        {
            get
            {
                return (string)this.ViewState["CustomType"] ?? "";
            }
            set
            {
                this.ViewState["CustomType"] = value;
            }
        }

        /// <summary>
        /// The raw JavaScript function to be called when this Listener fires.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The raw JavaScript function to be called when this Listener fires.")]
        public string Fn
        {
            get
            {
                return (string)this.ViewState["Fn"] ?? "";
            }
            set
            {
                this.ViewState["Fn"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("handler", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string FnProxy
        {
            get
            {
                if (this.Handler.IsNotEmpty())
                {
                    return new JFunction(TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Handler, this.Owner)), "event", "toolEl", "panel").ToScript();
                }

                return this.Fn;
            }
        }

        /// <summary>
        /// The function to call when clicked. Arguments passed are 'event', 'toolEl' and 'panel'.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The function to call when clicked. Arguments passed are 'event', 'toolEl' and 'panel'.")]
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
        /// The scope in which to call the handler.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [NotifyParentProperty(true)]
        [Description("The scope in which to call the handler.")]
        public virtual string Scope
        {
            get
            {
                return (string)this.ViewState["Scope"] ?? "this";
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// A tip string.
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A tip string.")]
        public virtual string Qtip 
        {
            get
            {
                return (string)this.ViewState["Qtip"] ?? "";
            }
            set
            {
                this.ViewState["Qtip"] = value;
            }
        }

        private QTipCfg qTipCfg;

        /// <summary>
        /// A tip string.
        /// </summary>
        [ConfigOption("qtip", JsonMode.Object)]
        [DefaultValue(null)]
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
        /// True to initially render hidden.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to initially render hidden.")]
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
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Handler.IsEmpty();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.ToString(CultureInfo.InvariantCulture);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToString(CultureInfo culture)
        {
            return TypeDescriptor.GetConverter(this.GetType()).ConvertToString(null, culture, this);
        }
    }
}