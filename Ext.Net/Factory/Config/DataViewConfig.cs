/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class DataView
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DataView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DataView.Config Conversion to DataView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DataView(DataView.Config config)
        {
            return new DataView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractDataView.Config 
        { 
			/*  Implicit DataView.Config Conversion to DataView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DataView.Builder(DataView.Config config)
			{
				return new DataView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool deselectOnContainerClick = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeselectOnContainerClick 
			{ 
				get
				{
					return this.deselectOnContainerClick;
				}
				set
				{
					this.deselectOnContainerClick = value;
				}
			}

			private bool enableKeyNav = true;

			/// <summary>
			/// Turns on/off keyboard navigation within the DataView. 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableKeyNav 
			{ 
				get
				{
					return this.enableKeyNav;
				}
				set
				{
					this.enableKeyNav = value;
				}
			}
        
			private DataViewListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public DataViewListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new DataViewListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private DataViewDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public DataViewDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new DataViewDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			        
			private SelectedRowCollection selectedRows = null;

			/// <summary>
			/// 
			/// </summary>
			public SelectedRowCollection SelectedRows
			{
				get
				{
					if (this.selectedRows == null)
					{
						this.selectedRows = new SelectedRowCollection();
					}
			
					return this.selectedRows;
				}
			}
			
        }
    }
}