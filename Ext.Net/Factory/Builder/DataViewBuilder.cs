/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : AbstractDataView.Builder<DataView, DataView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DataView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DataView.Config config) : base(new DataView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DataView component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual DataView.Builder DeselectOnContainerClick(bool deselectOnContainerClick)
            {
                this.ToComponent().DeselectOnContainerClick = deselectOnContainerClick;
                return this as DataView.Builder;
            }
             
 			/// <summary>
			/// Turns on/off keyboard navigation within the DataView. 
			/// </summary>
            public virtual DataView.Builder EnableKeyNav(bool enableKeyNav)
            {
                this.ToComponent().EnableKeyNav = enableKeyNav;
                return this as DataView.Builder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DataView.Builder</returns>
            public virtual DataView.Builder Listeners(Action<DataViewListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as DataView.Builder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DataView.Builder</returns>
            public virtual DataView.Builder DirectEvents(Action<DataViewDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as DataView.Builder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DataView.Builder</returns>
            public virtual DataView.Builder SelectedRows(Action<SelectedRowCollection> action)
            {
                action(this.ToComponent().SelectedRows);
                return this as DataView.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DataView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DataView(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DataView.Builder DataView()
        {
            return this.DataView(new DataView());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataView.Builder DataView(DataView component)
        {
            return new DataView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DataView.Builder DataView(DataView.Config config)
        {
            return new DataView.Builder(new DataView(config));
        }
    }
}