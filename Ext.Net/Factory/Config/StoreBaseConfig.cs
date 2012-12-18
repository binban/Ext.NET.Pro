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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class StoreBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractStore.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoDecode = false;

			/// <summary>
			/// If true then submitted data will be decoded
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDecode 
			{ 
				get
				{
					return this.autoDecode;
				}
				set
				{
					this.autoDecode = value;
				}
			}

			private bool buffered = false;

			/// <summary>
			/// Allow the store to buffer and pre-fetch pages of records. This is to be used in conjunction with a view will tell the store to pre-fetch records ahead of a time.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Buffered 
			{ 
				get
				{
					return this.buffered;
				}
				set
				{
					this.buffered = value;
				}
			}

			private bool clearOnPageLoad = true;

			/// <summary>
			/// True to empty the store when loading another page via loadPage, nextPage or previousPage (defaults to true). Setting to false keeps existing records, allowing large data sets to be loaded one page at a time but rendered all together.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearOnPageLoad 
			{ 
				get
				{
					return this.clearOnPageLoad;
				}
				set
				{
					this.clearOnPageLoad = value;
				}
			}

			private bool clearRemovedOnLoad = true;

			/// <summary>
			/// True to clear anything in the removed record collection when the store loads.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearRemovedOnLoad 
			{ 
				get
				{
					return this.clearRemovedOnLoad;
				}
				set
				{
					this.clearRemovedOnLoad = value;
				}
			}

			private object data = null;

			/// <summary>
			/// Optional array of Model instances or data objects to load locally. See \"Inline data\" above for details.
			/// </summary>
			[DefaultValue(null)]
			public virtual object Data 
			{ 
				get
				{
					return this.data;
				}
				set
				{
					this.data = value;
				}
			}

			private SortDirection groupDir = SortDirection.Default;

			/// <summary>
			/// The direction in which sorting should be applied when grouping. Defaults to \"ASC\" - the other supported value is \"DESC\"
			/// </summary>
			[DefaultValue(SortDirection.Default)]
			public virtual SortDirection GroupDir 
			{ 
				get
				{
					return this.groupDir;
				}
				set
				{
					this.groupDir = value;
				}
			}

			private string groupField = "";

			/// <summary>
			/// The (optional) field by which to group data in the store. Internally, grouping is very similar to sorting - the groupField and groupDir are injected as the first sorter (see sort). Stores support a single level of grouping, and groups can be fetched via the getGroups method.
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupField 
			{ 
				get
				{
					return this.groupField;
				}
				set
				{
					this.groupField = value;
				}
			}
        
			private DataSorterCollection groupers = null;

			/// <summary>
			/// The collection of groupers currently applied to this Store
			/// </summary>
			public DataSorterCollection Groupers
			{
				get
				{
					if (this.groupers == null)
					{
						this.groupers = new DataSorterCollection();
					}
			
					return this.groupers;
				}
			}
			
			private int leadingBufferZone = 200;

			/// <summary>
			/// When buffered, the number of extra rows to keep cached on the leading side of scrolling buffer as scrolling proceeds. A larger number means fewer replenishments from the server. Defaults to: 200
			/// </summary>
			[DefaultValue(200)]
			public virtual int LeadingBufferZone 
			{ 
				get
				{
					return this.leadingBufferZone;
				}
				set
				{
					this.leadingBufferZone = value;
				}
			}

			private int pageSize = 25;

			/// <summary>
			/// The number of records considered to form a 'page'. This is used to power the built-in paging using the nextPage and previousPage functions. Defaults to 25.
			/// </summary>
			[DefaultValue(25)]
			public virtual int PageSize 
			{ 
				get
				{
					return this.pageSize;
				}
				set
				{
					this.pageSize = value;
				}
			}

			private int purgePageCount = 5;

			/// <summary>
			/// The number of pages to keep in the cache before purging additional records. A value of 0 indicates to never purge the prefetched data. This option is only relevant when the buffered option is set to true.
			/// </summary>
			[DefaultValue(5)]
			public virtual int PurgePageCount 
			{ 
				get
				{
					return this.purgePageCount;
				}
				set
				{
					this.purgePageCount = value;
				}
			}

			private bool remoteFilter = false;

			/// <summary>
			/// True to defer any filtering operation to the server. If false, filtering is done locally on the client. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteFilter 
			{ 
				get
				{
					return this.remoteFilter;
				}
				set
				{
					this.remoteFilter = value;
				}
			}

			private bool remoteGroup = false;

			/// <summary>
			/// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping information to the server.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteGroup 
			{ 
				get
				{
					return this.remoteGroup;
				}
				set
				{
					this.remoteGroup = value;
				}
			}

			private bool remoteSort = false;

			/// <summary>
			/// True to defer any sorting operation to the server. If false, sorting is done locally on the client. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteSort 
			{ 
				get
				{
					return this.remoteSort;
				}
				set
				{
					this.remoteSort = value;
				}
			}

			private bool remotePaging = true;

			/// <summary>
			/// True to perform remote paging.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RemotePaging 
			{ 
				get
				{
					return this.remotePaging;
				}
				set
				{
					this.remotePaging = value;
				}
			}

			private bool isPagingStore = false;

			/// <summary>
			/// True to use PagingStore instance
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsPagingStore 
			{ 
				get
				{
					return this.isPagingStore;
				}
				set
				{
					this.isPagingStore = value;
				}
			}

			private bool sortOnFilter = true;

			/// <summary>
			/// For local filtering only, causes sort to be called whenever filter is called, causing the sorters to be reapplied after filtering. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SortOnFilter 
			{ 
				get
				{
					return this.sortOnFilter;
				}
				set
				{
					this.sortOnFilter = value;
				}
			}

			private int trailingBufferZone = 25;

			/// <summary>
			/// When buffered, the number of extra records to keep cached on the trailing side of scrolling buffer as scrolling proceeds. A larger number means fewer replenishments from the server. Defaults to: 25
			/// </summary>
			[DefaultValue(25)]
			public virtual int TrailingBufferZone 
			{ 
				get
				{
					return this.trailingBufferZone;
				}
				set
				{
					this.trailingBufferZone = value;
				}
			}

			private bool warningOnDirty = false;

			/// <summary>
			/// If true show a warning before load/reload if store has dirty data
			/// </summary>
			[DefaultValue(false)]
			public virtual bool WarningOnDirty 
			{ 
				get
				{
					return this.warningOnDirty;
				}
				set
				{
					this.warningOnDirty = value;
				}
			}

			private string dirtyWarningTitle = "Uncommitted Changes";

			/// <summary>
			/// The title of window showing before load if the dirty data exists
			/// </summary>
			[DefaultValue("Uncommitted Changes")]
			public virtual string DirtyWarningTitle 
			{ 
				get
				{
					return this.dirtyWarningTitle;
				}
				set
				{
					this.dirtyWarningTitle = value;
				}
			}

			private string dirtyWarningText = "You have uncommitted changes.  Are you sure you want to load/reload data?";

			/// <summary>
			/// The text of window showing before load if the dirty data exists
			/// </summary>
			[DefaultValue("You have uncommitted changes.  Are you sure you want to load/reload data?")]
			public virtual string DirtyWarningText 
			{ 
				get
				{
					return this.dirtyWarningText;
				}
				set
				{
					this.dirtyWarningText = value;
				}
			}

			private bool ignoreExtraFields = true;

			/// <summary>
			/// If true then only properties included to reader will be converted to json
			/// </summary>
			[DefaultValue(true)]
			public virtual bool IgnoreExtraFields 
			{ 
				get
				{
					return this.ignoreExtraFields;
				}
				set
				{
					this.ignoreExtraFields = value;
				}
			}
        
			private ReaderCollection reader = null;

			/// <summary>
			/// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
			/// </summary>
			public ReaderCollection Reader
			{
				get
				{
					if (this.reader == null)
					{
						this.reader = new ReaderCollection();
					}
			
					return this.reader;
				}
			}
			        
			private WriterCollection writer = null;

			/// <summary>
			/// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
			/// </summary>
			public WriterCollection Writer
			{
				get
				{
					if (this.writer == null)
					{
						this.writer = new WriterCollection();
					}
			
					return this.writer;
				}
			}
			
			private object dataSource = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object DataSource 
			{ 
				get
				{
					return this.dataSource;
				}
				set
				{
					this.dataSource = value;
				}
			}

			private string dataSourceID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DataSourceID 
			{ 
				get
				{
					return this.dataSourceID;
				}
				set
				{
					this.dataSourceID = value;
				}
			}

			private string dataMember = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DataMember 
			{ 
				get
				{
					return this.dataMember;
				}
				set
				{
					this.dataMember = value;
				}
			}

        }
    }
}