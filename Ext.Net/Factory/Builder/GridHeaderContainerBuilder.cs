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
    public partial class GridHeaderContainer
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGridHeaderContainer, TBuilder> : AbstractContainer.Builder<TGridHeaderContainer, TBuilder>
            where TGridHeaderContainer : GridHeaderContainer
            where TBuilder : Builder<TGridHeaderContainer, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGridHeaderContainer component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Width of the header if no width or flex is specified. Defaults to 100.
			/// </summary>
            public virtual TBuilder DefaultWidth(int defaultWidth)
            {
                this.ToComponent().DefaultWidth = defaultWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// HeaderContainer overrides the default weight of 0 for all docked items to 100. This is so that it has more priority over things like toolbars. Defaults to: 100
			/// </summary>
            public virtual TBuilder Weight(int weight)
            {
                this.ToComponent().Weight = weight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Provides the default sortable state for all Headers within this HeaderContainer. Also turns on or off the menus in the HeaderContainer. Note that the menu is shared across every header and therefore turning it off will remove the menu items for every header.
			/// </summary>
            public virtual TBuilder Sortable(bool? sortable)
            {
                this.ToComponent().Sortable = sortable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Sort Ascending\" menu item
			/// </summary>
            public virtual TBuilder SortAscText(string sortAscText)
            {
                this.ToComponent().SortAscText = sortAscText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Sort Descending\" menu item
			/// </summary>
            public virtual TBuilder SortDescText(string sortDescText)
            {
                this.ToComponent().SortDescText = sortDescText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Clear Sort\" menu item
			/// </summary>
            public virtual TBuilder SortClearText(string sortClearText)
            {
                this.ToComponent().SortClearText = sortClearText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Columns\" menu item
			/// </summary>
            public virtual TBuilder ColumnsText(string columnsText)
            {
                this.ToComponent().ColumnsText = columnsText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An array of column definition objects which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Columns(Action<ItemsCollection<ColumnBase>> action)
            {
                action(this.ToComponent().Columns);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
			/// </summary>
            public virtual TBuilder ForceFit(bool forceFit)
            {
                this.ToComponent().ForceFit = forceFit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
            public virtual TBuilder EnableColumnMove(bool enableColumnMove)
            {
                this.ToComponent().EnableColumnMove = enableColumnMove;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
            public virtual TBuilder EnableColumnResize(bool enableColumnResize)
            {
                this.ToComponent().EnableColumnResize = enableColumnResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
            public virtual TBuilder EnableColumnHide(bool enableColumnHide)
            {
                this.ToComponent().EnableColumnHide = enableColumnHide;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<GridHeaderContainerListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<GridHeaderContainerDirectEvents> action)
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
        public partial class Builder : GridHeaderContainer.Builder<GridHeaderContainer, GridHeaderContainer.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GridHeaderContainer()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridHeaderContainer component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridHeaderContainer.Config config) : base(new GridHeaderContainer(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GridHeaderContainer component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GridHeaderContainer.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GridHeaderContainer(this);
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
        public GridHeaderContainer.Builder GridHeaderContainer()
        {
#if MVC
			return this.GridHeaderContainer(new GridHeaderContainer { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.GridHeaderContainer(new GridHeaderContainer());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public GridHeaderContainer.Builder GridHeaderContainer(GridHeaderContainer component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new GridHeaderContainer.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GridHeaderContainer.Builder GridHeaderContainer(GridHeaderContainer.Config config)
        {
#if MVC
			return new GridHeaderContainer.Builder(new GridHeaderContainer(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new GridHeaderContainer.Builder(new GridHeaderContainer(config));
#endif			
        }
    }
}