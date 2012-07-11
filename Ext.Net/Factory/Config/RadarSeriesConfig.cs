/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class RadarSeries
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RadarSeries(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RadarSeries.Config Conversion to RadarSeries
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RadarSeries(RadarSeries.Config config)
        {
            return new RadarSeries(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractSeries.Config 
        { 
			/*  Implicit RadarSeries.Config Conversion to RadarSeries.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RadarSeries.Builder(RadarSeries.Config config)
			{
				return new RadarSeries.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private SpriteAttributes style = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes Style 
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

			private bool showMarkers = false;

			/// <summary>
			/// Whether markers should be displayed at the data points. If true, then the markerConfig config item will determine the markers' styling.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ShowMarkers 
			{ 
				get
				{
					return this.showMarkers;
				}
				set
				{
					this.showMarkers = value;
				}
			}

			private SpriteAttributes markerConfig = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes MarkerConfig 
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

			private bool showInLegend = false;

			/// <summary>
			/// Whether to add the chart elements as legend items. Default's false.
			/// </summary>
			[DefaultValue(false)]
			public override bool ShowInLegend 
			{ 
				get
				{
					return this.showInLegend;
				}
				set
				{
					this.showInLegend = value;
				}
			}

        }
    }
}