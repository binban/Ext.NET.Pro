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
    public partial class DayView
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DayView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DayView.Config Conversion to DayView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DayView(DayView.Config config)
        {
            return new DayView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Container.Config 
        { 
			/*  Implicit DayView.Config Conversion to DayView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DayView.Builder(DayView.Config config)
			{
				return new DayView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int dayCount = 1;

			/// <summary>
			/// The number of days to display in the view (defaults to 1). Only values from 1 to 7 are allowed.
			/// </summary>
			[DefaultValue(1)]
			public virtual int DayCount 
			{ 
				get
				{
					return this.dayCount;
				}
				set
				{
					this.dayCount = value;
				}
			}

			private string dDCreateEventText = "Create event for {0}";

			/// <summary>
			/// The text to display inside the drag proxy while dragging over the calendar to create a new event (defaults to 'Create event for {0}' where {0} is a date range supplied by the view)
			/// </summary>
			[DefaultValue("Create event for {0}")]
			public virtual string DDCreateEventText 
			{ 
				get
				{
					return this.dDCreateEventText;
				}
				set
				{
					this.dDCreateEventText = value;
				}
			}

			private string dDMoveEventText = "Move event to {0}";

			/// <summary>
			/// The text to display inside the drag proxy while dragging an event to reposition it (defaults to 'Move event to {0}' where {0} is the updated event start date/time supplied by the view)
			/// </summary>
			[DefaultValue("Move event to {0}")]
			public virtual string DDMoveEventText 
			{ 
				get
				{
					return this.dDMoveEventText;
				}
				set
				{
					this.dDMoveEventText = value;
				}
			}

			private bool showTime = true;

			/// <summary>
			/// True to display the current time in today's box in the calendar, false to not display it (defautls to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowTime 
			{ 
				get
				{
					return this.showTime;
				}
				set
				{
					this.showTime = value;
				}
			}

			private bool showTodayText = true;

			/// <summary>
			/// True to display the todayText string in today's box in the calendar, false to not display it (defautls to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowTodayText 
			{ 
				get
				{
					return this.showTodayText;
				}
				set
				{
					this.showTodayText = value;
				}
			}

			private string todayText = "Today";

			/// <summary>
			/// The text to display in the current day's box in the calendar when showTodayText is true (defaults to 'Today')
			/// </summary>
			[DefaultValue("Today")]
			public virtual string TodayText 
			{ 
				get
				{
					return this.todayText;
				}
				set
				{
					this.todayText = value;
				}
			}

        }
    }
}