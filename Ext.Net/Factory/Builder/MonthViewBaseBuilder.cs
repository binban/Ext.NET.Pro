/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public abstract partial class MonthViewBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TMonthViewBase, TBuilder> : AbstractCalendarView.Builder<TMonthViewBase, TBuilder>
            where TMonthViewBase : MonthViewBase
            where TBuilder : Builder<TMonthViewBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMonthViewBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to display a header beneath the navigation bar containing the week names above each week's column, false not to show it and instead display the week names in the first row of days in the calendar (defaults to false).
			/// </summary>
            public virtual TBuilder ShowHeader(bool showHeader)
            {
                this.ToComponent().ShowHeader = showHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the current time in today's box in the calendar, false to not display it (defautls to true)
			/// </summary>
            public virtual TBuilder ShowTime(bool showTime)
            {
                this.ToComponent().ShowTime = showTime;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the todayText string in today's box in the calendar, false to not display it (defautls to true)
			/// </summary>
            public virtual TBuilder ShowTodayText(bool showTodayText)
            {
                this.ToComponent().ShowTodayText = showTodayText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display an extra column before the first day in the calendar that links to the view for each individual week, false to not show it (defaults to false). If true, the week links can also contain the week number depending on the value of showWeekNumbers.
			/// </summary>
            public virtual TBuilder ShowWeekLinks(bool showWeekLinks)
            {
                this.ToComponent().ShowWeekLinks = showWeekLinks;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show the week number for each week in the calendar in the week link column, false to show nothing (defaults to false). Note that if showWeekLinks is false this config will have no affect even if true.
			/// </summary>
            public virtual TBuilder ShowWeekNumbers(bool showWeekNumbers)
            {
                this.ToComponent().ShowWeekNumbers = showWeekNumbers;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class name applied when the mouse moves over a week link element (only applies when showWeekLinks is true, defaults to 'ext-week-link-over').
			/// </summary>
            public virtual TBuilder WeekLinkOverClass(string weekLinkOverClass)
            {
                this.ToComponent().WeekLinkOverClass = weekLinkOverClass;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}