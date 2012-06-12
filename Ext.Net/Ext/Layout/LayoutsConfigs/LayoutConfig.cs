/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class LayoutConfig : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LayoutConfig() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LayoutConfig(bool renderHidden, string extraCls)
        {
            this.RenderHidden = renderHidden;
            this.ExtraCls = extraCls;
        }

        /// <summary>
        /// True to hide each contained item on render (defaults to false).
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to hide each contained item on render (defaults to false).")]
        public virtual bool RenderHidden
        {
            get
            {
                object obj = this.ViewState["RenderHidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RenderHidden"] = value;
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to the container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules. See Component.CtCls also.
        /// Note: ExtraCls defaults to '' except for the following classes which assign a value by default:
        /// Absolute Layout : 'x-abs-layout-item'
        /// Box Layout : 'x-box-item'
        /// Column Layout : 'x-column'
        /// To configure the above Classes with an extra CSS class append to the default. For example, for ColumnLayout:
        /// extraCls: 'x-column custom-class'
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Description("An optional extra CSS class that will be added to the container")]
        public virtual string ExtraCls
        {
            get
            {
                return (string)this.ViewState["ExtraCls"] ?? "";
            }
            set
            {
                this.ViewState["ExtraCls"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class LayoutConfigCollection : StateManagedCollection<LayoutConfig>
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Description("")]
        public LayoutConfig Primary
        {
            get
            {
                if (this.Count > 0)
                {
                    return this[0];
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public LayoutConfigCollection()
        {
            this.SingleItemMode = true;
        }
    }
}