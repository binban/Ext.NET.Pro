/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class GridHeaderContainer
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GridHeaderContainer(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GridHeaderContainer.Config Conversion to GridHeaderContainer
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GridHeaderContainer(GridHeaderContainer.Config config)
        {
            return new GridHeaderContainer(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractContainer.Config 
        { 
			/*  Implicit GridHeaderContainer.Config Conversion to GridHeaderContainer.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GridHeaderContainer.Builder(GridHeaderContainer.Config config)
			{
				return new GridHeaderContainer.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int defaultWidth = 100;

			/// <summary>
			/// Width of the header if no width or flex is specified. Defaults to 100.
			/// </summary>
			[DefaultValue(100)]
			public virtual int DefaultWidth 
			{ 
				get
				{
					return this.defaultWidth;
				}
				set
				{
					this.defaultWidth = value;
				}
			}

			private int weight = 100;

			/// <summary>
			/// HeaderContainer overrides the default weight of 0 for all docked items to 100. This is so that it has more priority over things like toolbars. Defaults to: 100
			/// </summary>
			[DefaultValue(100)]
			public override int Weight 
			{ 
				get
				{
					return this.weight;
				}
				set
				{
					this.weight = value;
				}
			}

			private bool? sortable = null;

			/// <summary>
			/// Provides the default sortable state for all Headers within this HeaderContainer. Also turns on or off the menus in the HeaderContainer. Note that the menu is shared across every header and therefore turning it off will remove the menu items for every header.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Sortable 
			{ 
				get
				{
					return this.sortable;
				}
				set
				{
					this.sortable = value;
				}
			}

			private string sortAscText = "";

			/// <summary>
			/// The text displayed in the \"Sort Ascending\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string SortAscText 
			{ 
				get
				{
					return this.sortAscText;
				}
				set
				{
					this.sortAscText = value;
				}
			}

			private string sortDescText = "";

			/// <summary>
			/// The text displayed in the \"Sort Descending\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string SortDescText 
			{ 
				get
				{
					return this.sortDescText;
				}
				set
				{
					this.sortDescText = value;
				}
			}

			private string sortClearText = "";

			/// <summary>
			/// The text displayed in the \"Clear Sort\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string SortClearText 
			{ 
				get
				{
					return this.sortClearText;
				}
				set
				{
					this.sortClearText = value;
				}
			}

			private string columnsText = "";

			/// <summary>
			/// The text displayed in the \"Columns\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string ColumnsText 
			{ 
				get
				{
					return this.columnsText;
				}
				set
				{
					this.columnsText = value;
				}
			}
        
			private ItemsCollection<ColumnBase> columns = null;

			/// <summary>
			/// An array of column definition objects which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
			/// </summary>
			public ItemsCollection<ColumnBase> Columns
			{
				get
				{
					if (this.columns == null)
					{
						this.columns = new ItemsCollection<ColumnBase>();
					}
			
					return this.columns;
				}
			}
			
			private bool forceFit = false;

			/// <summary>
			/// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceFit 
			{ 
				get
				{
					return this.forceFit;
				}
				set
				{
					this.forceFit = value;
				}
			}

			private bool enableColumnMove = true;

			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnMove 
			{ 
				get
				{
					return this.enableColumnMove;
				}
				set
				{
					this.enableColumnMove = value;
				}
			}

			private bool enableColumnResize = true;

			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnResize 
			{ 
				get
				{
					return this.enableColumnResize;
				}
				set
				{
					this.enableColumnResize = value;
				}
			}

			private bool enableColumnHide = true;

			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnHide 
			{ 
				get
				{
					return this.enableColumnHide;
				}
				set
				{
					this.enableColumnHide = value;
				}
			}
        
			private GridHeaderContainerListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public GridHeaderContainerListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new GridHeaderContainerListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private GridHeaderContainerDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public GridHeaderContainerDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new GridHeaderContainerDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}