/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class CalendarPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("dayText", new ConfigOption("dayText", null, "Day", this.DayText ));
                list.Add("monthText", new ConfigOption("monthText", null, "Month", this.MonthText ));
                list.Add("showDayView", new ConfigOption("showDayView", null, true, this.ShowDayView ));
                list.Add("showMonthView", new ConfigOption("showMonthView", null, true, this.ShowMonthView ));
                list.Add("showNavBar", new ConfigOption("showNavBar", null, true, this.ShowNavBar ));
                list.Add("showTime", new ConfigOption("showTime", null, true, this.ShowTime ));
                list.Add("showTodayText", new ConfigOption("showTodayText", null, true, this.ShowTodayText ));
                list.Add("showWeekView", new ConfigOption("showWeekView", null, true, this.ShowWeekView ));
                list.Add("todayText", new ConfigOption("todayText", null, "Today", this.TodayText ));
                list.Add("weekText", new ConfigOption("weekText", null, "Week", this.WeekText ));
                list.Add("calendarStoreID", new ConfigOption("calendarStoreID", new SerializationOptions("calendarStore", JsonMode.ToClientID), "", this.CalendarStoreID ));
                list.Add("calendarStore", new ConfigOption("calendarStore", new SerializationOptions("calendarStore", typeof(LazyControlJsonConverter)), null, this.CalendarStore ));
                list.Add("eventStoreID", new ConfigOption("eventStoreID", new SerializationOptions("eventStore", JsonMode.ToClientID), "", this.EventStoreID ));
                list.Add("eventStore", new ConfigOption("eventStore", new SerializationOptions("eventStore", typeof(LazyControlJsonConverter)), null, this.EventStore ));
                list.Add("dayView", new ConfigOption("dayView", new SerializationOptions("dayViewCfg", typeof(LazyControlJsonConverter)), null, this.DayView ));
                list.Add("weekView", new ConfigOption("weekView", new SerializationOptions("weekViewCfg", typeof(LazyControlJsonConverter)), null, this.WeekView ));
                list.Add("monthView", new ConfigOption("monthView", new SerializationOptions("monthViewCfg", typeof(LazyControlJsonConverter)), null, this.MonthView ));
                list.Add("eventDetails", new ConfigOption("eventDetails", new SerializationOptions("editViewCfg", typeof(LazyControlJsonConverter)), null, this.EventDetails ));

                return list;
            }
        }
    }
}