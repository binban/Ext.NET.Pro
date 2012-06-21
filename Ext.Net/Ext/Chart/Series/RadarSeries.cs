/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Creates a Radar Chart. A Radar Chart is a useful visualization technique for comparing different quantitative values for a constrained number of categories.
    /// As with all other series, the Radar series must be appended in the series Chart array configuration. 
    /// </summary>
    [Meta]
    public partial class RadarSeries : AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public RadarSeries()
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
                return "radar";
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
        /// Whether markers should be displayed at the data points. If true, then the markerConfig config item will determine the markers' styling.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether markers should be displayed at the data points. If true, then the markerConfig config item will determine the markers' styling.")]
        public virtual bool ShowMarkers
        {
            get
            {
                return this.State.Get<bool>("ShowMarkers", false);
            }
            set
            {
                this.State.Set("ShowMarkers", value);
            }
        }

        private SpriteAttributes markerConfig;

        /// <summary>
        /// The display style for the markers. Only used if showMarkers is true. The markerConfig is a configuration object containing the same set of properties defined in the Sprite class.
        /// </summary>
        [Meta]
        [ConfigOption("markerConfig", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes MarkerConfig
        {
            get
            {
                return this.markerConfig;
            }
            set
            {
                this.markerConfig = value;
            }
        }

        /// <summary>
        /// Whether to add the chart elements as legend items. Default's false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether to add the chart elements as legend items. Default's false.")]
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
    }
}
