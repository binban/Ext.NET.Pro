/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class AbstractStoreListeners : ComponentListeners
    {
        private ComponentListener add;

        /// <summary>
        /// Fired when a Model instance has been added to this Store
        /// Parameters
        /// store : Ext.data.Store
        /// The store
        /// 
        /// records : Array
        /// The Model instances that were added
        /// 
        /// index : Number
        /// The index at which the instances were inserted
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Model instances that were added")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the instances were inserted")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("add", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a Model instance has been added to this Store")]
        public virtual ComponentListener Add
        {
            get
            {
                return this.add ?? (this.add = new ComponentListener());
            }
        }

        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled
        /// Parameters
        /// store : Ext.data.Store
        /// This Store
        /// 
        /// operation : Ext.data.Operation
        /// The Ext.data.Operation object that will be passed to the Proxy to load the Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "operation", typeof(object), "The Ext.data.Operation object that will be passed to the Proxy to load the Store")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled")]
        public virtual ComponentListener BeforeLoad
        {
            get
            {
                return this.beforeLoad ?? (this.beforeLoad = new ComponentListener());
            }
        }

        private ComponentListener beforeSync;

        /// <summary>
        /// Called before a call to sync is executed. Return false from any listener to cancel the sync
        /// Parameters
        /// options : Object
        /// Hash of all records to be synchronized, broken down into create, update and destroy
        /// </summary>
        [ListenerArgument(0, "options", typeof(object), "Hash of all records to be synchronized, broken down into create, update and destroy")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforesync", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Called before a call to sync is executed. Return false from any listener to cancel the sync")]
        public virtual ComponentListener BeforeSync
        {
            get
            {
                return this.beforeSync ?? (this.beforeSync = new ComponentListener());
            }
        }

        private ComponentListener clear;

        /// <summary>
        /// Fired after the removeAll method is called.
        /// Parameters
        /// store : Ext.data.Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("clear", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after the removeAll method is called.")]
        public virtual ComponentListener Clear
        {
            get
            {
                return this.clear ?? (this.clear = new ComponentListener());
            }
        }

        private ComponentListener dataChanged;

        /// <summary>
        /// Fires whenever the records in the Store have changed in some way - this could include adding or removing records, or updating the data in existing records
        /// Parameters
        /// store : Ext.data.Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("datachanged", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever the records in the Store have changed in some way - this could include adding or removing records, or updating the data in existing records")]
        public virtual ComponentListener DataChanged
        {
            get
            {
                return this.dataChanged ?? (this.dataChanged = new ComponentListener());
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires whenever the store reads data from a remote data source.
        /// Parameters
        /// store : Ext.data.Store
        /// records : Array
        /// An array of records
        ///
        /// successful : Boolean
        /// True if the operation was successful.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Records that were loaded")]
        [ListenerArgument(2, "successful", typeof(object), "True if the operation was successful.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever the store reads data from a remote data source.")]
        public virtual ComponentListener Load
        {
            get
            {
                return this.load ?? (this.load = new ComponentListener());
            }
        }

        private ComponentListener remove;

        /// <summary>
        /// Fired when a Model instance has been removed from this Store
        /// Parameters
        /// store : Ext.data.Store
        /// The Store object
        ///
        /// record : Ext.data.Model
        /// The record that was removed
        /// 
        /// index : Number
        /// The index of the record that was removed
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "record", typeof(object), "The Record that was removed")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the record was removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when a Model instance has been removed from this Store")]
        public virtual ComponentListener Remove
        {
            get
            {
                return this.remove ?? (this.remove = new ComponentListener());
            }
        }

        private ComponentListener update;

        /// <summary>
        /// Fires when a Record has been updated
        /// Parameters
        /// store : Store
        /// record : Ext.data.Model
        /// The Model instance that was updated
        /// 
        /// operation : String
        /// The update operation being performed. Value may be one of:
        ///     Ext.data.Model.EDIT
        ///     Ext.data.Model.REJECT
        ///     Ext.data.Model.COMMIT
        ///     
        /// modifiedFieldNames : String[]
        /// Array of field names changed during edit.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "record", typeof(object), "The Model instance that was updated")]
        [ListenerArgument(2, "operation", typeof(object), "The update operation being performed")]
        [ListenerArgument(3, "modifiedFieldNames", typeof(object), "Array of field names changed during edit.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("update", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a Record has been updated")]
        public virtual ComponentListener Update
        {
            get
            {
                return this.update ?? (this.update = new ComponentListener());
            }
        }

        private ComponentListener write;

        /// <summary>
        /// Fires whenever a successful write has been made via the configured Proxy
        /// Parameters
        /// store : Ext.data.Store
        ///     This Store
        /// operation : Ext.data.Operation
        ///     The Operation object that was used in the write
        /// </summary>
        [ListenerArgument(0, "store")]
        [ListenerArgument(1, "operation")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("write", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires whenever a successful write has been made via the configured Proxy")]
        public virtual ComponentListener Write
        {
            get
            {
                return this.write ?? (this.write = new ComponentListener());
            }
        }

        private ComponentListener exception;

        /// <summary>
        /// Fires when the server returns an exception
        /// Parameters
        /// proxy : Ext.data.proxy.Proxy
        /// response : Object
        ///   The response from the AJAX request
        /// operation : Ext.data.Operation
        ///    The operation that triggered request
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(AbstractProxy), "The proxy for the request")]
        [ListenerArgument(1, "response", typeof(string), "The response from the AJAX request")]
        [ListenerArgument(2, "operation", typeof(string), "The operation that triggered request")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("exception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the server returns an exception")]
        public virtual ComponentListener Exception
        {
            get
            {
                return this.exception ?? (this.exception = new ComponentListener());
            }
        }

        private ComponentListener metachange;

        /// <summary>
        /// Fires when this store's underlying reader (available via the proxy) provides new metadata. Metadata usually consists of new field definitions, but can include any configuration data required by an application, and can be processed as needed in the event handler. This event is currently only fired for JsonReaders.
        /// 
        /// Parameters
        /// store : Ext.data.Store
        /// meta : Object
        /// The JSON metadata
        /// </summary>
        [ListenerArgument(0, "store")]
        [ListenerArgument(1, "meta")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("metachange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this store's underlying reader (available via the proxy) provides new metadata. Metadata usually consists of new field definitions, but can include any configuration data required by an application, and can be processed as needed in the event handler. This event is currently only fired for JsonReaders.")]
        public virtual ComponentListener MetaChange
        {
            get
            {
                return this.metachange ?? (this.metachange = new ComponentListener());
            }
        }

        private ComponentListener refresh;

        /// <summary>
        /// Fires when the data cache has changed in a bulk manner (e.g., it has been sorted, filtered, etc.) and a widget that is using this Store as a Record cache should refresh its view.
        /// 
        /// Parameters
        /// store : Ext.data.Store        
        /// </summary>
        [ListenerArgument(0, "store")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("refresh", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the data cache has changed in a bulk manner (e.g., it has been sorted, filtered, etc.) and a widget that is using this Store as a Record cache should refresh its view.")]
        public virtual ComponentListener Refresh
        {
            get
            {
                return this.refresh ?? (this.refresh = new ComponentListener());
            }
        }
    }
}
