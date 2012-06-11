/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class TrayClock : ToolbarTextItem
    {
        internal TrayClock() 
        { 
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
                return "trayclock";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("t")]
        [Description("")]
        public virtual string TimeFormat
        {
            get
            {
                return this.State.Get<string>("TimeFormat", "t");
            }
            set
            {
                this.State.Set("TimeFormat", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("timeFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string TimeFormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.TimeFormat, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("tpl")]
        [DefaultValue("{time}")]
        [Description("")]
        public virtual string Template
        {
            get
            {
                return this.State.Get<string>("Template", "{time}");
            }
            set
            {
                this.State.Set("Template", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(10000)]
        [Description("")]
        public virtual int RefreshInterval
        {
            get
            {
                return this.State.Get<int>("RefreshInterval", 10000);
            }
            set
            {
                this.State.Set("RefreshInterval", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Hidden
        {
            get
            {
                return base.Hidden;
            }
            set
            {
                base.Hidden = value;
                this.Visible = !value;
            }
        }
    }
}