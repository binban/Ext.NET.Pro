/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public partial class StoreListeners : AbstractStoreListeners
    {
        private ComponentListener beforePrefetch;

        /// <summary>
        /// Fires before a prefetch occurs. Return false to cancel.
        /// Parameters
        /// store : Ext.data.store
        /// operation : Ext.data.Operation
        /// The associated operation
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "operation", typeof(object), "Ext.data.Operation")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeprefetch", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a prefetch occurs. Return false to cancel.")]
        public virtual ComponentListener BeforePrefetch
        {
            get
            {
                return this.beforePrefetch ?? (this.beforePrefetch = new ComponentListener());
            }
        }

        private ComponentListener groupChange;

        /// <summary>
        /// Fired whenever the grouping in the grid changes
        /// Parameters
        /// store : Ext.data.Store
        /// The store
        ///
        /// groupers : Array
        /// The array of grouper objects
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "groupers", typeof(object), "The array of grouper objects")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired whenever the grouping in the grid changes")]
        public virtual ComponentListener GroupChange
        {
            get
            {
                return this.groupChange ?? (this.groupChange = new ComponentListener());
            }
        }

        private ComponentListener prefetch;

        /// <summary>
        /// Fires whenever records have been prefetched
        /// Parameters
        /// store : Ext.data.Store
        /// records : Array
        /// An array of records
        /// successful : Boolean
        /// True if the operation was successful.
        /// operation : Ext.data.Operation
        /// The associated operation
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Records that were loaded")]
        [ListenerArgument(2, "successful", typeof(object), "True if the operation was successful.")]
        [ListenerArgument(3, "operation", typeof(object), "The associated operation")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("prefetch", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever records have been prefetched")]
        public virtual ComponentListener Prefetch
        {
            get
            {
                return this.prefetch ?? (this.prefetch = new ComponentListener());
            }
        }

        private ComponentListener totalcountchange;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "totalCount")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("totalcountchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener TotalCountChange
        {
            get
            {
                return this.totalcountchange ?? (this.totalcountchange = new ComponentListener());
            }
        }
    }
}