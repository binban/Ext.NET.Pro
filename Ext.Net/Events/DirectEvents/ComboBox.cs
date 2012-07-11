/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class ComboBoxDirectEvents : TriggerFieldDirectEvents
    {
        private ComponentDirectEvent beforeQuery;

        /// <summary>
        /// Fires before all queries are processed. Return false to cancel the query or set the queryEvent's cancel property to true.
        /// </summary>
        [ListenerArgument(0, "queryEvent", typeof(object), "An object that includes combo (This combo box), query (The query), forceAll (True to force 'all' query) and cancel (Set to true to cancel the query).")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforequery", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before all queries are processed. Return false to cancel the query or set the queryEvent's cancel property to true.")]
        public virtual ComponentDirectEvent BeforeQuery 
        {
            get
            {
                if (this.beforeQuery == null)
                {
                    this.beforeQuery = new ComponentDirectEvent();
                }

                return this.beforeQuery;
            }
        }

        private ComponentDirectEvent beforeSelect;

        /// <summary>
        /// Fires before a list items is selected. Return false to cancel the selection.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [ListenerArgument(1, "record", typeof(object), "The data record returned from the underlying store")]
        [ListenerArgument(2, "index", typeof(int), "The index of the selected item in the dropdown list")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeselect", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a list items is selected. Return false to cancel the selection.")]
        public virtual ComponentDirectEvent BeforeSelect
        {
            get
            {
                if (this.beforeSelect == null)
                {
                    this.beforeSelect = new ComponentDirectEvent();
                }

                return this.beforeSelect;
            }
        }

        private ComponentDirectEvent collapse;

        /// <summary>
        /// Fires when the dropdown list is collapsed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the dropdown list is collapsed.")]
        public virtual ComponentDirectEvent Collapse
        {
            get
            {
                if (this.collapse == null)
                {
                    this.collapse = new ComponentDirectEvent();
                }

                return this.collapse;
            }
        }

        private ComponentDirectEvent expand;

        /// <summary>
        /// Fires when the dropdown list is expanded.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the dropdown list is expanded.")]
        public virtual ComponentDirectEvent Expand
        {
            get
            {
                if (this.expand == null)
                {
                    this.expand = new ComponentDirectEvent();
                }

                return this.expand;
            }
        }

        private ComponentDirectEvent select;

        /// <summary>
        /// Fires when a list items is selected.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This combo box")]
        [ListenerArgument(1, "record", typeof(object), "The data record returned from the underlying store")]
        [ListenerArgument(2, "index", typeof(int), "The index of the selected item in the dropdown list")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a list items is selected.")]
        public virtual ComponentDirectEvent Select
        {
            get
            {
                if (this.select == null)
                {
                    this.select = new ComponentDirectEvent();
                }

                return this.select;
            }
        }
    }
}