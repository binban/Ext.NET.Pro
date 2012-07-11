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
    public partial class GaugeAxis
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GaugeAxis(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GaugeAxis.Config Conversion to GaugeAxis
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GaugeAxis(GaugeAxis.Config config)
        {
            return new GaugeAxis(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractAxis.Config 
        { 
			/*  Implicit GaugeAxis.Config Conversion to GaugeAxis.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GaugeAxis.Builder(GaugeAxis.Config config)
			{
				return new GaugeAxis.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int margin = 10;

			/// <summary>
			/// The offset positioning of the tick marks and labels in pixels. Defaults to: 10
			/// </summary>
			[DefaultValue(10)]
			public virtual int Margin 
			{ 
				get
				{
					return this.margin;
				}
				set
				{
					this.margin = value;
				}
			}

			private int? maximum = null;

			/// <summary>
			/// The maximum value of the interval to be displayed in the axis (REQUIRED).
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Maximum 
			{ 
				get
				{
					return this.maximum;
				}
				set
				{
					this.maximum = value;
				}
			}

			private int? minimum = null;

			/// <summary>
			/// The minimum value of the interval to be displayed in the axis (REQUIRED).
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Minimum 
			{ 
				get
				{
					return this.minimum;
				}
				set
				{
					this.minimum = value;
				}
			}

			private int? steps = null;

			/// <summary>
			/// The number of steps and tick marks to add to the interval. (REQUIRED).
			/// </summary>
			[DefaultValue(null)]
			public virtual int? Steps 
			{ 
				get
				{
					return this.steps;
				}
				set
				{
					this.steps = value;
				}
			}

			private string title = null;

			/// <summary>
			/// The title for the Axis.
			/// </summary>
			[DefaultValue(null)]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

        }
    }
}