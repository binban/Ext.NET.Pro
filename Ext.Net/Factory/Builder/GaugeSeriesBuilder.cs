/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    public partial class GaugeSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractSeries.Builder<GaugeSeries, GaugeSeries.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GaugeSeries()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GaugeSeries component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GaugeSeries.Config config) : base(new GaugeSeries(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GaugeSeries component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers. REQUIRED
			/// </summary>
            public virtual GaugeSeries.Builder AngleField(string angleField)
            {
                this.ToComponent().AngleField = angleField;
                return this as GaugeSeries.Builder;
            }
             
 			/// <summary>
			/// Use the entire disk or just a fraction of it for the gauge.
			/// </summary>
            public virtual GaugeSeries.Builder Donut(int donut)
            {
                this.ToComponent().Donut = donut;
                return this as GaugeSeries.Builder;
            }
             
 			/// <summary>
			/// The duration for the pie slice highlight effect. Defaults to: 150
			/// </summary>
            public virtual GaugeSeries.Builder HighlightDuration(int highlightDuration)
            {
                this.ToComponent().HighlightDuration = highlightDuration;
                return this as GaugeSeries.Builder;
            }
             
 			/// <summary>
			/// Use the Gauge Series as an area series or add a needle to it. Default's false.
			/// </summary>
            public virtual GaugeSeries.Builder Needle(bool needle)
            {
                this.ToComponent().Needle = needle;
                return this as GaugeSeries.Builder;
            }
             
 			/// <summary>
			/// Whether to add the pie chart elements as legend items. Default's false.
			/// </summary>
            public virtual GaugeSeries.Builder ShowInLegend(bool showInLegend)
            {
                this.ToComponent().ShowInLegend = showInLegend;
                return this as GaugeSeries.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GaugeSeries.Builder Style(SpriteAttributes style)
            {
                this.ToComponent().Style = style;
                return this as GaugeSeries.Builder;
            }
             
 			/// <summary>
			/// An array of color values which will be used, in order, as the gauge slice fill colors.
			/// </summary>
            public virtual GaugeSeries.Builder ColorSet(string[] colorSet)
            {
                this.ToComponent().ColorSet = colorSet;
                return this as GaugeSeries.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual GaugeSeries.Builder SetValue(object value)
            {
                this.ToComponent().SetValue(value);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GaugeSeries(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder GaugeSeries()
        {
            return this.GaugeSeries(new GaugeSeries());
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder GaugeSeries(GaugeSeries component)
        {
            return new GaugeSeries.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GaugeSeries.Builder GaugeSeries(GaugeSeries.Config config)
        {
            return new GaugeSeries.Builder(new GaugeSeries(config));
        }
    }
}