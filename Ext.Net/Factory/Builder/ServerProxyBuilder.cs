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
    public abstract partial class ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TServerProxy, TBuilder> : AbstractProxy.Builder<TServerProxy, TBuilder>
            where TServerProxy : ServerProxy
            where TBuilder : Builder<TServerProxy, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TServerProxy component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specific urls to call on CRUD action methods \"read\", \"create\", \"update\" and \"destroy\".
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder API(Action<CRUDUrls> action)
            {
                action(this.ToComponent().API);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The name of the cache param added to the url when using noCache (defaults to \"_dc\")
			/// </summary>
            public virtual TBuilder CacheString(string cacheString)
            {
                this.ToComponent().CacheString = cacheString;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the direction parameter to send in a request. This is only used when simpleSortMode is set to true. Defaults to 'dir'.
			/// </summary>
            public virtual TBuilder DirectionParam(string directionParam)
            {
                this.ToComponent().DirectionParam = directionParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Extra parameters that will be included on every request. Individual requests with params of the same name will override these params when they are in conflict.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ExtraParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().ExtraParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The name of the 'filter' parameter to send in a request. Defaults to 'filter'. Set this to undefined if you don't want to send a filter parameter
			/// </summary>
            public virtual TBuilder FilterParam(string filterParam)
            {
                this.ToComponent().FilterParam = filterParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'group' parameter to send in a request. Defaults to 'group'. Set this to undefined if you don't want to send a group parameter
			/// </summary>
            public virtual TBuilder GroupParam(string groupParam)
            {
                this.ToComponent().GroupParam = groupParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'limit' parameter to send in a request. Defaults to 'limit'. Set this to undefined if you don't want to send a limit parameter
			/// </summary>
            public virtual TBuilder LimitParam(string limitParam)
            {
                this.ToComponent().LimitParam = limitParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			///  Defaults to true. Disable caching by adding a unique parameter name to the request. Set to false to allow caching. Defaults to true.
			/// </summary>
            public virtual TBuilder NoCache(bool noCache)
            {
                this.ToComponent().NoCache = noCache;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'page' parameter to send in a request. Defaults to 'page'. Set this to undefined if you don't want to send a page parameter
			/// </summary>
            public virtual TBuilder PageParam(string pageParam)
            {
                this.ToComponent().PageParam = pageParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Reader(Action<ReaderCollection> action)
            {
                action(this.ToComponent().Reader);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Enabling simpleSortMode in conjunction with remoteSort will only send one sort property and a direction when a remote sort is requested. The directionParam and sortParam will be sent with the property name and either 'ASC' or 'DESC'. Defaults to: false
			/// </summary>
            public virtual TBuilder SimpleSortMode(bool simpleSortMode)
            {
                this.ToComponent().SimpleSortMode = simpleSortMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'sort' parameter to send in a request. Defaults to 'sort'. Set this to undefined if you don't want to send a sort parameter
			/// </summary>
            public virtual TBuilder SortParam(string sortParam)
            {
                this.ToComponent().SortParam = sortParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the 'start' parameter to send in a request. Defaults to 'start'. Set this to undefined if you don't want to send a start parameter
			/// </summary>
            public virtual TBuilder StartParam(string startParam)
            {
                this.ToComponent().StartParam = startParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of milliseconds to wait for a response. Defaults to 30000 milliseconds (30 seconds).
			/// </summary>
            public virtual TBuilder Timeout(int timeout)
            {
                this.ToComponent().Timeout = timeout;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default URL to be used for requests to the server.
			/// </summary>
            public virtual TBuilder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Writer(Action<WriterCollection> action)
            {
                action(this.ToComponent().Writer);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ProxyListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Generates a url based on a given Ext.data.Request object. By default, ServerProxy's buildUrl will add the cache-buster param to the end of the url. Subclasses may need to perform additional modifications to the url.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder BuildUrl(Action<JFunction> action)
            {
                action(this.ToComponent().BuildUrl);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}