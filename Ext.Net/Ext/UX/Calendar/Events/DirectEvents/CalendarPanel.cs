/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CalendarPanelDirectEvents : PanelDirectEvents
    {
        public CalendarPanelDirectEvents() { }

        public CalendarPanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent dateChange;

        /// <summary>
        /// Fires after the start date of the view changes
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "startDate", typeof(DateTime), "The start date of the view")]
        [ListenerArgument(2, "viewStart", typeof(DateTime), "The first displayed date in the view")]
        [ListenerArgument(3, "viewEnd", typeof(DateTime), "The last displayed date in the view")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("datechange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the start date of the view changes")]
        public virtual ComponentDirectEvent DateChange
        {
            get
            {
                if (this.dateChange == null)
                {
                    this.dateChange = new ComponentDirectEvent(this);
                }

                return this.dateChange;
            }
        }

        private ComponentDirectEvent dayClick;

        /// <summary>
        /// Fires after the user clicks within a day/week view container and not on an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "dt", typeof(DateTime), "The date/time that was clicked on")]
        [ListenerArgument(2, "allDay", typeof(Boolean), "True if the day clicked on represents an all-day box, else false.")]
        [ListenerArgument(3, "el", typeof(Element), "The Element that was clicked on")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dayclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks within a day/week view container and not on an event element")]
        public virtual ComponentDirectEvent DayClick
        {
            get
            {
                if (this.dayClick == null)
                {
                    this.dayClick = new ComponentDirectEvent(this);
                }

                return this.dayClick;
            }
        }

        private ComponentDirectEvent eventAdd;

        /// <summary>
        /// Fires after a new event is added to the underlying store
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The new record that was added")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventadd", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a new event is added to the underlying store")]
        public virtual ComponentDirectEvent EventAdd
        {
            get
            {
                if (this.eventAdd == null)
                {
                    this.eventAdd = new ComponentDirectEvent(this);
                }

                return this.eventAdd;
            }
        }

        private ComponentDirectEvent eventCancel;

        /// <summary>
        /// Fires after an event add/edit operation is canceled by the user and no store update took place
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The new record that was canceled")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventcancel", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an event add/edit operation is canceled by the user and no store update took place")]
        public virtual ComponentDirectEvent EventCancel
        {
            get
            {
                if (this.eventCancel == null)
                {
                    this.eventCancel = new ComponentDirectEvent(this);
                }

                return this.eventCancel;
            }
        }

        private ComponentDirectEvent eventClick;

        /// <summary>
        /// Fires after the user clicks on an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that was clicked on")]
        [ListenerArgument(2, "el", typeof(object), "The DOM node that was clicked on")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks on an event element")]
        public virtual ComponentDirectEvent EventClick
        {
            get
            {
                if (this.eventClick == null)
                {
                    this.eventClick = new ComponentDirectEvent(this);
                }

                return this.eventClick;
            }
        }

        private ComponentDirectEvent eventDelete;

        /// <summary>
        /// Fires after an event is deleted by the user.
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that was deleted")]
        [ListenerArgument(2, "el", typeof(object), "The target element")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventdelete", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an event is deleted by the user.")]
        public virtual ComponentDirectEvent EventDelete
        {
            get
            {
                if (this.eventDelete == null)
                {
                    this.eventDelete = new ComponentDirectEvent(this);
                }

                return this.eventDelete;
            }
        }

        private ComponentDirectEvent eventMove;

        /// <summary>
        /// Fires after an event element is dragged by the user and dropped in a new position
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that was moved with updated start and end dates")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventmove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an event element is dragged by the user and dropped in a new position")]
        public virtual ComponentDirectEvent EventMove
        {
            get
            {
                if (this.eventMove == null)
                {
                    this.eventMove = new ComponentDirectEvent(this);
                }

                return this.eventMove;
            }
        }

        private ComponentDirectEvent eventOut;

        /// <summary>
        /// Fires anytime the mouse exits an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that the cursor exited")]
        [ListenerArgument(2, "el", typeof(object), "The DOM node that was exited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventout", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires anytime the mouse exits an event element")]
        public virtual ComponentDirectEvent EventOut
        {
            get
            {
                if (this.eventOut == null)
                {
                    this.eventOut = new ComponentDirectEvent(this);
                }

                return this.eventOut;
            }
        }

        private ComponentDirectEvent eventOver;

        /// <summary>
        /// Fires anytime the mouse is over an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that the cursor is over")]
        [ListenerArgument(2, "el", typeof(object), "The DOM node that is being moused over")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires anytime the mouse is over an event element")]
        public virtual ComponentDirectEvent EventOver
        {
            get
            {
                if (this.eventOver == null)
                {
                    this.eventOver = new ComponentDirectEvent(this);
                }

                return this.eventOver;
            }
        }

        private ComponentDirectEvent eventResize;

        /// <summary>
        /// Fires after the user drags the resize handle of an event to resize it
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that was resized containing the updated start and end dates")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user drags the resize handle of an event to resize it")]
        public virtual ComponentDirectEvent EventResize
        {
            get
            {
                if (this.eventResize == null)
                {
                    this.eventResize = new ComponentDirectEvent(this);
                }

                return this.eventResize;
            }
        }

        private ComponentDirectEvent eventsRendered;

        /// <summary>
        /// Fires after events are finished rendering in the view
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventsrendered", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after events are finished rendering in the view")]
        public virtual ComponentDirectEvent EventsRendered
        {
            get
            {
                if (this.eventsRendered == null)
                {
                    this.eventsRendered = new ComponentDirectEvent(this);
                }

                return this.eventsRendered;
            }
        }

        private ComponentDirectEvent eventUpdate;

        /// <summary>
        /// Fires after an existing event is updated
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "record", typeof(object), "The new record that was updated")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventupdate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an existing event is updated")]
        public virtual ComponentDirectEvent EventUpdate
        {
            get
            {
                if (this.eventUpdate == null)
                {
                    this.eventUpdate = new ComponentDirectEvent(this);
                }

                return this.eventUpdate;
            }
        }

        private ComponentDirectEvent initDrag;

        /// <summary>
        /// Fires when a drag operation is initiated in the view
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]        
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("initdrag", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a drag operation is initiated in the view")]
        public virtual ComponentDirectEvent InitDrag
        {
            get
            {
                if (this.initDrag == null)
                {
                    this.initDrag = new ComponentDirectEvent(this);
                }

                return this.initDrag;
            }
        }

        private ComponentDirectEvent rangeSelect;

        /// <summary>
        /// Fires after the user drags on the calendar to select a range of dates/times in which to create an event
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "dates", typeof(object), "An object containing the start (StartDate property) and end (EndDate property) dates selected")]
        [ListenerArgument(2, "callback", typeof(JFunction), "A callback function that MUST be called after the event handling is complete so that the view is properly cleaned up (shim elements are persisted in the view while the user is prompted to handle the range selection). The callback is already created in the proper scope, so it simply needs to be executed as a standard function call (e.g., callback()).")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rangeselect", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user drags on the calendar to select a range of dates/times in which to create an event")]
        public virtual ComponentDirectEvent RangeSelect
        {
            get
            {
                if (this.rangeSelect == null)
                {
                    this.rangeSelect = new ComponentDirectEvent(this);
                }

                return this.rangeSelect;
            }
        }

        private ComponentDirectEvent viewChange;

        /// <summary>
        /// Fires after a different calendar view is activated (but not when the event edit form is activated)
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarPanel), "Ext.calendar.CalendarPanel")]
        [ListenerArgument(1, "view", typeof(object), "The view being activated (any valid CalendarView subclass)")]
        [ListenerArgument(2, "info", typeof(Object), "Extra information about the newly activated view (activeDate, viewStart, viewEnd).")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("viewchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a different calendar view is activated (but not when the event edit form is activated)")]
        public virtual ComponentDirectEvent ViewChange
        {
            get
            {
                if (this.viewChange == null)
                {
                    this.viewChange = new ComponentDirectEvent(this);
                }

                return this.viewChange;
            }
        }       
    }
}