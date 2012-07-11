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
    public partial class NumericAxis
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit NumericAxis.Config Conversion to NumericAxis
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator NumericAxis(NumericAxis.Config config)
        {
            return new NumericAxis(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Axis.Config 
        { 
			/*  Implicit NumericAxis.Config Conversion to NumericAxis.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator NumericAxis.Builder(NumericAxis.Config config)
			{
				return new NumericAxis.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool constrain = true;

			/// <summary>
			/// If true, the values of the chart will be rendered only if they belong between minimum and maximum If false, all values of the chart will be rendered, regardless of whether they belong between minimum and maximum or not Default's true if maximum and minimum is specified. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Constrain 
			{ 
				get
				{
					return this.constrain;
				}
				set
				{
					this.constrain = value;
				}
			}

			private Position position = Position.Left;

			/// <summary>
			/// Where to set the axis. Available options are left, bottom, right, top. Default's left.
			/// </summary>
			[DefaultValue(Position.Left)]
			public override Position Position 
			{ 
				get
				{
					return this.position;
				}
				set
				{
					this.position = value;
				}
			}

			private bool adjustMaximumByMajorUnit = false;

			/// <summary>
			/// Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AdjustMaximumByMajorUnit 
			{ 
				get
				{
					return this.adjustMaximumByMajorUnit;
				}
				set
				{
					this.adjustMaximumByMajorUnit = value;
				}
			}

			private bool adjustMinimumByMajorUnit = false;

			/// <summary>
			/// Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AdjustMinimumByMajorUnit 
			{ 
				get
				{
					return this.adjustMinimumByMajorUnit;
				}
				set
				{
					this.adjustMinimumByMajorUnit = value;
				}
			}

			private bool roundToDecimal = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RoundToDecimal 
			{ 
				get
				{
					return this.roundToDecimal;
				}
				set
				{
					this.roundToDecimal = value;
				}
			}

			private int decimals = 2;

			/// <summary>
			/// The number of decimals to round the value to. Default's 2.
			/// </summary>
			[DefaultValue(2)]
			public virtual int Decimals 
			{ 
				get
				{
					return this.decimals;
				}
				set
				{
					this.decimals = value;
				}
			}

			private int? maximum = null;

			/// <summary>
			/// The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.
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
			/// The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.
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

        }
    }
}