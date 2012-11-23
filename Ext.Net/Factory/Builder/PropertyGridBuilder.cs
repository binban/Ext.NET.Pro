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
    public partial class PropertyGrid
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TPropertyGrid, TBuilder> : GridPanelBase.Builder<TPropertyGrid, TBuilder>
            where TPropertyGrid : PropertyGrid
            where TBuilder : Builder<TPropertyGrid, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TPropertyGrid component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A data object to use as the data source of the grid.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Source(Action<PropertyGridParameterCollection> action)
            {
                action(this.ToComponent().Source);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// If false then all cells will be read only
			/// </summary>
            public virtual TBuilder Editable(bool editable)
            {
                this.ToComponent().Editable = editable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically infer the type based on the initial value passed for each field. This ensures the editor remains the correct type even if the value is blanked and becomes empty. Defaults to: true
			/// </summary>
            public virtual TBuilder InferTypes(bool inferTypes)
            {
                this.ToComponent().InferTypes = inferTypes;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. Specify the width for the name column. The value column will take any remaining space. Defaults to 115.
			/// </summary>
            public virtual TBuilder NameColumnWidth(int nameColumnWidth)
            {
                this.ToComponent().NameColumnWidth = nameColumnWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<PropertyGridListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<PropertyGridDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : PropertyGrid.Builder<PropertyGrid, PropertyGrid.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PropertyGrid()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGrid component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGrid.Config config) : base(new PropertyGrid(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PropertyGrid component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PropertyGrid(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder PropertyGrid()
        {
#if MVC
			return this.PropertyGrid(new PropertyGrid { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.PropertyGrid(new PropertyGrid());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder PropertyGrid(PropertyGrid component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new PropertyGrid.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGrid.Builder PropertyGrid(PropertyGrid.Config config)
        {
#if MVC
			return new PropertyGrid.Builder(new PropertyGrid(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PropertyGrid.Builder(new PropertyGrid(config));
#endif			
        }
    }
}