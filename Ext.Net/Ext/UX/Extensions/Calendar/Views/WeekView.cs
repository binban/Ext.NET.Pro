/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// Displays a calendar view by week. This class does not usually need ot be used directly as you can use a CalendarPanel to manage multiple calendar views at once including the week view.
    /// </summary>
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(DayView), "Build.ToolboxIcons.CalendarPanel.bmp")]
    public partial class WeekView : DayView
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public WeekView() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.calendar.WeekView";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "weekview";
            }
        }

        /// <summary>
        /// The number of days to display in the view (defaults to 7)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DayView")]
        [DefaultValue(7)]
        [NotifyParentProperty(true)]
        [Description("The number of days to display in the view (defaults to 7)")]
        public override int DayCount
        {
            get
            {
                object obj = this.ViewState["DayCount"];
                return obj != null ? (int)obj : 7;
            }
            set
            {
                this.ViewState["DayCount"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string CallID
        {
            get
            {
                Component cmp = this.ParentComponent;
                return cmp != null ? string.Format("Ext.getCmp(\"{0}\")", cmp.ConfigID + "-week") : this.ClientID;
            }
        }

        /// <summary>
        /// The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)")]
        public virtual int StartDay
        {
            get
            {
                object obj = this.ViewState["StartDay"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["StartDay"] = value;
            }
        }
    }
}