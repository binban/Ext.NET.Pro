/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Creates a Gauge Chart. Gauge Charts are used to show progress in a certain variable. There are two ways of using the Gauge chart. One is setting a store element into the Gauge and selecting the field to be used from that store. Another one is instantiating the visualization and using the setValue method to adjust the value you want.
    /// </summary>
    [Meta]
    public partial class GaugeSeries : AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        protected virtual string Type
        {
            get
            {
                return "gauge";
            }
        }

        /// <summary>
        /// The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers. REQUIRED
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers. REQUIRED")]
        public virtual string AngleField
        {
            get
            {
                return this.State.Get<string>("AngleField", "");
            }
            set
            {
                this.State.Set("AngleField", value);
            }
        }

        /// <summary>
        /// Use the entire disk or just a fraction of it for the gauge.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Use the entire disk or just a fraction of it for the gauge.")]
        public virtual int Donut
        {
            get
            {
                return this.State.Get<int>("Donut", 0);
            }
            set
            {
                this.State.Set("Donut", value);
            }
        }

        /// <summary>
        /// The duration for the pie slice highlight effect. Defaults to: 150
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(150)]
        [Description("The duration for the pie slice highlight effect. Defaults to: 150")]
        public virtual int HighlightDuration
        {
            get
            {
                return this.State.Get<int>("HighlightDuration", 150);
            }
            set
            {
                this.State.Set("HighlightDuration", value);
            }
        }

        /// <summary>
        /// Use the Gauge Series as an area series or add a needle to it. Default's false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Use the Gauge Series as an area series or add a needle to it. Default's false.")]
        public virtual bool Needle
        {
            get
            {
                return this.State.Get<bool>("Needle", false);
            }
            set
            {
                this.State.Set("Needle", value);
            }
        }

        /// <summary>
        /// Whether to add the pie chart elements as legend items. Default's false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether to add the pie chart elements as legend items. Default's false.")]
        public override bool ShowInLegend
        {
            get
            {
                return this.State.Get<bool>("ShowInLegend", false);
            }
            set
            {
                this.State.Set("ShowInLegend", value);
            }
        }

        private SpriteAttributes style;

        /// <summary>
        /// An object containing styles for overriding series styles from Theming.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        /// <summary>
        /// An array of color values which will be used, in order, as the gauge slice fill colors.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("An array of color values which will be used, in order, as the gauge slice fill colors.")]
        public virtual string[] ColorSet
        {
            get
            {
                return this.State.Get<string[]>("ColorSet", null);
            }
            set
            {
                this.State.Set("ColorSet", value);
            }
        }

        /// <summary>
        /// Sets the Gauge chart to the current specified value.
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        public virtual void SetValue(object value)
        {
            this.CallTemplate("setValue", value);
        }
    }
}
