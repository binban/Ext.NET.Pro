/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class PropertyGridDirectEvents : GridPanelDirectEvents
    {
        public PropertyGridDirectEvents() { }

        public PropertyGridDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforePropertyChange;

        /// <summary>
        /// Fires before a property value changes. Handlers can return false to cancel the property change (this will internally call Ext.data.Model.reject on the property's record).
        /// 
        /// Parameters
        /// source : Object
        ///     The source data object for the grid (corresponds to the same object passed in as the source config property).
        /// recordId : String
        ///     The record's id in the data store
        /// value : Object
        ///     The current edited property value
        /// oldValue : Object
        ///     The original property value prior to editing
        /// </summary>
        [ListenerArgument(0, "source")]
        [ListenerArgument(1, "recordId")]
        [ListenerArgument(2, "value")]
        [ListenerArgument(3, "oldValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforepropertychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a property value changes. Handlers can return false to cancel the property change (this will internally call Ext.data.Record.reject on the property's record).")]
        public virtual ComponentDirectEvent BeforePropertyChange
        {
            get
            {
                return this.beforePropertyChange ?? (this.beforePropertyChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent propertyChange;

        /// <summary>
        /// Fires after a property value has changed.
        /// 
        /// Parameters
        /// source : Object
        ///     The source data object for the grid (corresponds to the same object passed in as the source config property).
        /// recordId : String
        ///     The record's id in the data store
        /// value : Object
        ///     The current edited property value
        /// oldValue : Object
        ///     The original property value prior to editing
        /// </summary>
        [ListenerArgument(0, "source")]
        [ListenerArgument(1, "recordId")]
        [ListenerArgument(2, "value")]
        [ListenerArgument(3, "oldValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("propertychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a property value has changed.")]
        public virtual ComponentDirectEvent PropertyChange
        {
            get
            {
                return this.propertyChange ?? (this.propertyChange = new ComponentDirectEvent(this));
            }
        }
    }
}