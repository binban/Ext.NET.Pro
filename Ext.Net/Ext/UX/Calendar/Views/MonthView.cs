/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Displays a calendar view by month. This class does not usually need ot be used directly as you can use a CalendarPanel to manage multiple calendar views at once including the month view.
    /// </summary>
    [Meta]
    public partial class MonthView : MonthViewBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public MonthView() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.calendar.view.Month";
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
                return "monthview";
            }
        }

        private MonthViewListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public MonthViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MonthViewListeners();
                }

                return this.listeners;
            }
        }

        private MonthViewDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public MonthViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new MonthViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }        
    }
}