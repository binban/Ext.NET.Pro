/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public partial class WeekView
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TWeekView, TBuilder> : DayView.Builder<TWeekView, TBuilder>
            where TWeekView : WeekView
            where TBuilder : Builder<TWeekView, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TWeekView component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The number of days to display in the view (defaults to 7)
			/// </summary>
            public virtual TBuilder DayCount(int dayCount)
            {
                this.ToComponent().DayCount = dayCount;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)
			/// </summary>
            public virtual TBuilder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : WeekView.Builder<WeekView, WeekView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new WeekView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(WeekView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(WeekView.Config config) : base(new WeekView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(WeekView component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.WeekView(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder WeekView()
        {
#if MVC
			return this.WeekView(new WeekView { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.WeekView(new WeekView());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder WeekView(WeekView component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new WeekView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public WeekView.Builder WeekView(WeekView.Config config)
        {
#if MVC
			return new WeekView.Builder(new WeekView(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new WeekView.Builder(new WeekView(config));
#endif			
        }
    }
}