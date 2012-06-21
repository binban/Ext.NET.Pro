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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Creates a Pie Chart. A Pie Chart is a useful visualization technique to display quantitative information for different categories that also have a meaning as a whole. As with all other series, the Pie Series must be appended in the series Chart array configuration.
    /// </summary>
    [Meta]
    public partial class PieSeries : AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public PieSeries()
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
                return "pie";
            }
        }

        protected internal override void BeforeSerialization()
        {
            base.BeforeSerialization();

            if (this.HighlightConfig != null && this.HighlightSegmentMargin != null)
            {
                this.HighlightConfig.CustomConfig.Add(new ConfigItem("segment", "{margin:" + HighlightSegmentMargin.Value + "}", ParameterMode.Raw));
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
        /// Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.")]
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
        /// 
        /// </summary>
        [Meta]        
        [DefaultValue(null)]
        [Description("")]
        public virtual int? HighlightSegmentMargin
        {
            get
            {
                return this.State.Get<int?>("HighlightSegmentMargin", null);
            }
            set
            {
                this.State.Set("HighlightSegmentMargin", value);
            }
        }

        [ConfigOption("highlightCfg", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string HighlightSegmentMarginProxy
        {
            get
            {
                if (this.HighlightConfig == null && this.HighlightSegmentMargin != null)
                {
                    return "{segment:{margin:" + HighlightSegmentMargin.Value + "}}";
                }

                return "";
            }
        }

        /// <summary>
        /// The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.")]
        public virtual string LengthField
        {
            get
            {
                return this.State.Get<string>("LengthField", "");
            }
            set
            {
                this.State.Set("LengthField", value);
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
    }
}
