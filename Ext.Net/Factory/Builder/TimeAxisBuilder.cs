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
    public partial class TimeAxis
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : NumericAxis.Builder<TimeAxis, TimeAxis.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TimeAxis()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeAxis component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeAxis.Config config) : base(new TimeAxis(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TimeAxis component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeAxis.Builder RoundToDecimal(bool roundToDecimal)
            {
                this.ToComponent().RoundToDecimal = roundToDecimal;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// If true, the values of the chart will be rendered only if they belong between the fromDate and toDate. If false, the time axis will adapt to the new values by adding/removing steps. Defaults to: false
			/// </summary>
            public virtual TimeAxis.Builder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// Indicates the format the date will be rendered on. For example: 'MMM dd' will render the dates as 'Jan 30', etc.
			/// </summary>
            public virtual TimeAxis.Builder DateFormat(string dateFormat)
            {
                this.ToComponent().DateFormat = dateFormat;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// The starting date for the time axis.
			/// </summary>
            public virtual TimeAxis.Builder FromDate(DateTime fromDate)
            {
                this.ToComponent().FromDate = fromDate;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// The ending date for the time axis.
			/// </summary>
            public virtual TimeAxis.Builder ToDate(DateTime toDate)
            {
                this.ToComponent().ToDate = toDate;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// The number of units for the step
			/// </summary>
            public virtual TimeAxis.Builder Step(int step)
            {
                this.ToComponent().Step = step;
                return this as TimeAxis.Builder;
            }
             
 			/// <summary>
			/// The unit of the step (day, month, year, etc).
			/// </summary>
            public virtual TimeAxis.Builder StepUnit(DateUnit stepUnit)
            {
                this.ToComponent().StepUnit = stepUnit;
                return this as TimeAxis.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TimeAxis(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder TimeAxis()
        {
            return this.TimeAxis(new TimeAxis());
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder TimeAxis(TimeAxis component)
        {
            return new TimeAxis.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeAxis.Builder TimeAxis(TimeAxis.Config config)
        {
            return new TimeAxis.Builder(new TimeAxis(config));
        }
    }
}