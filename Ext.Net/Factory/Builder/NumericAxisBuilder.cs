/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Axis.Builder<NumericAxis, NumericAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new NumericAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumericAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(NumericAxis.Config config) : base(new NumericAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(NumericAxis component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If true, the values of the chart will be rendered only if they belong between minimum and maximum If false, all values of the chart will be rendered, regardless of whether they belong between minimum and maximum or not Default's true if maximum and minimum is specified. Defaults to: true
			/// </summary>
            public virtual NumericAxis.Builder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// Where to set the axis. Available options are left, bottom, right, top. Default's left.
			/// </summary>
            public virtual NumericAxis.Builder Position(Position position)
            {
                this.ToComponent().Position = position;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// Indicates whether to extend maximum beyond data's maximum to the nearest majorUnit. Defaults to: false
			/// </summary>
            public virtual NumericAxis.Builder AdjustMaximumByMajorUnit(bool adjustMaximumByMajorUnit)
            {
                this.ToComponent().AdjustMaximumByMajorUnit = adjustMaximumByMajorUnit;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// Indicates whether to extend the minimum beyond data's minimum to the nearest majorUnit. Defaults to: false
			/// </summary>
            public virtual NumericAxis.Builder AdjustMinimumByMajorUnit(bool adjustMinimumByMajorUnit)
            {
                this.ToComponent().AdjustMinimumByMajorUnit = adjustMinimumByMajorUnit;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual NumericAxis.Builder RoundToDecimal(bool roundToDecimal)
            {
                this.ToComponent().RoundToDecimal = roundToDecimal;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// The number of decimals to round the value to. Default's 2.
			/// </summary>
            public virtual NumericAxis.Builder Decimals(int decimals)
            {
                this.ToComponent().Decimals = decimals;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// The maximum value drawn by the axis. If not set explicitly, the axis maximum will be calculated automatically.
			/// </summary>
            public virtual NumericAxis.Builder Maximum(int? maximum)
            {
                this.ToComponent().Maximum = maximum;
                return this as NumericAxis.Builder;
            }
             
 			/// <summary>
			/// The minimum value drawn by the axis. If not set explicitly, the axis minimum will be calculated automatically.
			/// </summary>
            public virtual NumericAxis.Builder Minimum(int? minimum)
            {
                this.ToComponent().Minimum = minimum;
                return this as NumericAxis.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.NumericAxis(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis()
        {
            return this.NumericAxis(new NumericAxis());
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis(NumericAxis component)
        {
            return new NumericAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public NumericAxis.Builder NumericAxis(NumericAxis.Config config)
        {
            return new NumericAxis.Builder(new NumericAxis(config));
        }
    }
}