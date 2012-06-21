/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// A type of axis that displays items in categories. This axis is generally used to display categorical information like names of items, month names, quarters, etc. but no quantitative values. For that other type of information Number axis are more suitable.
    /// </summary>
    [Meta]
    public partial class CategoryAxis : Axis
    {
        /// <summary>
        /// 
        /// </summary>
        public CategoryAxis()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]        
        public virtual string Type
        {
            get
            {
                return "Category";
            }
        }

        /// <summary>
        /// Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Indicates whether or not to calculate the number of categories (ticks and labels) when there is not enough room to display all labels on the axis. If set to true, the axis will determine the number of categories to plot. If not, all categories will be plotted. Defaults to: false")]
        public virtual bool CalculateCategoryCount
        {
            get
            {
                return this.State.Get<bool>("CalculateCategoryCount", false);
            }
            set
            {
                this.State.Set("CalculateCategoryCount", value);
            }
        }

        /// <summary>
        /// A list of category names to display along this axis.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]        
        [DefaultValue(null)]
        [Description("A list of category names to display along this axis.")]
        public virtual string[] CategoryNames
        {
            get
            {
                return this.State.Get<string[]>("CategoryNames", null);
            }
            set
            {
                this.State.Set("CategoryNames", value);
            }
        }
    }
}
