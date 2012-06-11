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
    public partial class PieSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractSeries.Builder<PieSeries, PieSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PieSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PieSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PieSeries.Config config) : base(new PieSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PieSeries component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers. REQUIRED
			/// </summary>
            public virtual PieSeries.Builder AngleField(string angleField)
            {
                this.ToComponent().AngleField = angleField;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// An array of color values which will be used, in order, as the gauge slice fill colors.
			/// </summary>
            public virtual PieSeries.Builder ColorSet(string[] colorSet)
            {
                this.ToComponent().ColorSet = colorSet;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.
			/// </summary>
            public virtual PieSeries.Builder Donut(int donut)
            {
                this.ToComponent().Donut = donut;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// The duration for the pie slice highlight effect. Defaults to: 150
			/// </summary>
            public virtual PieSeries.Builder HighlightDuration(int highlightDuration)
            {
                this.ToComponent().HighlightDuration = highlightDuration;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual PieSeries.Builder HighlightSegmentMargin(int? highlightSegmentMargin)
            {
                this.ToComponent().HighlightSegmentMargin = highlightSegmentMargin;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.
			/// </summary>
            public virtual PieSeries.Builder LengthField(string lengthField)
            {
                this.ToComponent().LengthField = lengthField;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// Whether to add the pie chart elements as legend items. Default's false.
			/// </summary>
            public virtual PieSeries.Builder ShowInLegend(bool showInLegend)
            {
                this.ToComponent().ShowInLegend = showInLegend;
                return this as PieSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual PieSeries.Builder Style(SpriteAttributes style)
            {
                this.ToComponent().Style = style;
                return this as PieSeries.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PieSeries(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder PieSeries()
        {
            return this.PieSeries(new PieSeries());
        }

        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder PieSeries(PieSeries component)
        {
            return new PieSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PieSeries.Builder PieSeries(PieSeries.Config config)
        {
            return new PieSeries.Builder(new PieSeries(config));
        }
    }
}