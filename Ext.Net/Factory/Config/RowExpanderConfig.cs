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
    public partial class RowExpander
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RowExpander(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RowExpander.Config Conversion to RowExpander
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RowExpander(RowExpander.Config config)
        {
            return new RowExpander(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit RowExpander.Config Conversion to RowExpander.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RowExpander.Builder(RowExpander.Config config)
			{
				return new RowExpander.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private ComponentLoader loader = null;

			/// <summary>
			/// A configuration object or an instance of a Ext.ComponentLoader to load remote content.
			/// </summary>
			[DefaultValue(null)]
			public virtual ComponentLoader Loader 
			{ 
				get
				{
					return this.loader;
				}
				set
				{
					this.loader = value;
				}
			}
        
			private XTemplate template = null;

			/// <summary>
			/// The template string to use to display each item in the dropdown list.
			/// </summary>
			public XTemplate Template
			{
				get
				{
					if (this.template == null)
					{
						this.template = new XTemplate();
					}
			
					return this.template;
				}
			}
			        
			private ItemsCollection<AbstractComponent> component = null;

			/// <summary>
			/// 
			/// </summary>
			public ItemsCollection<AbstractComponent> Component
			{
				get
				{
					if (this.component == null)
					{
						this.component = new ItemsCollection<AbstractComponent>();
					}
			
					return this.component;
				}
			}
			
			private bool recreateComponent = false;

			/// <summary>
			/// Recreate component on each row expand
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RecreateComponent 
			{ 
				get
				{
					return this.recreateComponent;
				}
				set
				{
					this.recreateComponent = value;
				}
			}

			private bool doLayoutOnExpand = true;

			/// <summary>
			/// Call doLayout after a row expanding/collapsing
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DoLayoutOnExpand 
			{ 
				get
				{
					return this.doLayoutOnExpand;
				}
				set
				{
					this.doLayoutOnExpand = value;
				}
			}

			private bool swallowBodyEvents = false;

			/// <summary>
			/// Swallow row body's events
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SwallowBodyEvents 
			{ 
				get
				{
					return this.swallowBodyEvents;
				}
				set
				{
					this.swallowBodyEvents = value;
				}
			}

			private bool selectRowOnExpand = false;

			/// <summary>
			/// True to select a row when clicking on the expander icon (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SelectRowOnExpand 
			{ 
				get
				{
					return this.selectRowOnExpand;
				}
				set
				{
					this.selectRowOnExpand = value;
				}
			}

			private int scrollOffset = 0;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(0)]
			public virtual int ScrollOffset 
			{ 
				get
				{
					return this.scrollOffset;
				}
				set
				{
					this.scrollOffset = value;
				}
			}

			private bool expandOnEnter = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ExpandOnEnter 
			{ 
				get
				{
					return this.expandOnEnter;
				}
				set
				{
					this.expandOnEnter = value;
				}
			}

			private bool expandOnDblClick = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ExpandOnDblClick 
			{ 
				get
				{
					return this.expandOnDblClick;
				}
				set
				{
					this.expandOnDblClick = value;
				}
			}

			private bool invalidateComponentsOnRefresh = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool InvalidateComponentsOnRefresh 
			{ 
				get
				{
					return this.invalidateComponentsOnRefresh;
				}
				set
				{
					this.invalidateComponentsOnRefresh = value;
				}
			}

			private bool? singleExpand = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? SingleExpand 
			{ 
				get
				{
					return this.singleExpand;
				}
				set
				{
					this.singleExpand = value;
				}
			}

			private Renderer renderer = null;

			/// <summary>
			/// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
			/// </summary>
			[DefaultValue(null)]
			public virtual Renderer Renderer 
			{ 
				get
				{
					return this.renderer;
				}
				set
				{
					this.renderer = value;
				}
			}
        
			private RowExpanderListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public RowExpanderListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new RowExpanderListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private RowExpanderDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public RowExpanderDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new RowExpanderDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}