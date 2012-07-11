/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// Proxies are used by Stores to handle the loading and saving of Model data. Usually developers will not need to create or interact with proxies directly.
    /// 
    /// Types of Proxy
    /// 
    /// There are two main types of Proxy - Client and Server. The Client proxies save their data locally and include the following subclasses:
    /// 
    /// LocalStorageProxy - saves its data to localStorage if the browser supports it
    /// SessionStorageProxy - saves its data to sessionStorage if the browsers supports it
    /// MemoryProxy - holds data in memory only, any data is lost when the page is refreshed
    /// 
    /// The Server proxies save their data by sending requests to some remote server. These proxies include:
    /// 
    /// AjaxProxy - sends requests to a server on the same domain
    /// JsonPProxy - uses JSON-P to send requests to a server on a different domain
    /// DirectProxt - uses Ext.direct to send requests
    /// Proxies operate on the principle that all operations performed are either Create, Read, Update or Delete. These four operations are mapped to the methods create, read, update and destroy respectively. Each Proxy subclass implements these functions.
    /// 
    /// The CRUD methods each expect an Operation object as the sole argument. The Operation encapsulates information about the action the Store wishes to perform, the model instances that are to be modified, etc. See the Operation documentation for more details. Each CRUD method also accepts a callback function to be called asynchronously on completion.
    /// 
    /// Proxies also support batching of Operations via a batch object, invoked by the batch method.
    /// </summary>
    [Meta]
    public abstract partial class AbstractProxy : BaseItem
    {
        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected abstract string Type
        {
            get;
        }
        
        /// <summary>
        /// True to batch actions of a particular type when synchronizing the store. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. AbstractProxy")]
        [DefaultValue(true)]
        [Description("True to batch actions of a particular type when synchronizing the store. Defaults to true.")]
        public virtual bool BatchActions
        {
            get
            {
                return this.State.Get<bool>("BatchActions", true);
            }
            set
            {
                this.State.Set("BatchActions", value);
            }
        }

        /// <summary>
        /// Comma-separated ordering 'create', 'update' and 'destroy' actions when batching. Override this to set a different order for the batched CRUD actions to be executed in. Defaults to 'create,update,destroy'
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. AbstractProxy")]
        [DefaultValue("create,update,destroy")]
        [Description("Comma-separated ordering 'create', 'update' and 'destroy' actions when batching. Override this to set a different order for the batched CRUD actions to be executed in. Defaults to 'create,update,destroy'")]
        public virtual string BatchOrder
        {
            get
            {
                return this.State.Get<string>("BatchOrder", "create,update,destroy");
            }
            set
            {
                this.State.Set("BatchOrder", value);
            }
        }
    }
}
