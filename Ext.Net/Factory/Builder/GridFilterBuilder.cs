/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public abstract partial class GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGridFilter, TBuilder> : BaseItem.Builder<TGridFilter, TBuilder>
            where TGridFilter : GridFilter
            where TBuilder : Builder<TGridFilter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGridFilter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Indicates the initial status of the filter (defaults to false).
			/// </summary>
            public virtual TBuilder Active(bool active)
            {
                this.ToComponent().Active = active;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Store data index of the field this filter represents. The dataIndex does not actually have to exist in the store.
			/// </summary>
            public virtual TBuilder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder MenuItems(Action<ItemsCollection<AbstractComponent>> action)
            {
                action(this.ToComponent().MenuItems);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Number of milliseconds to wait after user interaction to fire an update. Only supported by filters: 'list', 'numeric', and 'string'. Defaults to 500.
			/// </summary>
            public virtual TBuilder UpdateBuffer(int updateBuffer)
            {
                this.ToComponent().UpdateBuffer = updateBuffer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Template method to be implemented by all subclasses that is to get and return the value of the filter.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetValue(Action<JFunction> action)
            {
                action(this.ToComponent().GetValue);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Template method to be implemented by all subclasses that is to set the value of the filter and fire the 'update' event.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SetValueFunc(Action<JFunction> action)
            {
                action(this.ToComponent().SetValueFunc);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Template method to be implemented by all subclasses that is to get and return serialized filter data for transmission to the server.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetSerialArgs(Action<JFunction> action)
            {
                action(this.ToComponent().GetSerialArgs);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Template method to be implemented by all subclasses that is to validates the provided Ext.data.Record against the filters configuration.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ValidateRecord(Action<JFunction> action)
            {
                action(this.ToComponent().ValidateRecord);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<GridFilterListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}