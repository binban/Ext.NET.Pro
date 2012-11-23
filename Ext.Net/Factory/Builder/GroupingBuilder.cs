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
    public partial class Grouping
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGrouping, TBuilder> : GridFeature.Builder<TGrouping, TBuilder>
            where TGrouping : Grouping
            where TBuilder : Builder<TGrouping, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGrouping component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
            public virtual TBuilder DepthToIndent(int depthToIndent)
            {
                this.ToComponent().DepthToIndent = depthToIndent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable the grouping control in the header menu (defaults to true)
			/// </summary>
            public virtual TBuilder EnableGroupingMenu(bool enableGroupingMenu)
            {
                this.ToComponent().EnableGroupingMenu = enableGroupingMenu;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow the user to turn off grouping (defaults to true)
			/// </summary>
            public virtual TBuilder EnableNoGroups(bool enableNoGroups)
            {
                this.ToComponent().EnableNoGroups = enableNoGroups;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Text displayed in the grid header menu for grouping by header (defaults to 'Group By This Field').
			/// </summary>
            public virtual TBuilder GroupByText(string groupByText)
            {
                this.ToComponent().GroupByText = groupByText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string Template snippet, an array of strings (optionally followed by an object containing Template methods) to be used to construct a Template, or a Template instance. Defaults to: \"{columnName}: {name}\"
			/// </summary>
            public virtual TBuilder GroupHeaderTplString(string groupHeaderTplString)
            {
                this.ToComponent().GroupHeaderTplString = groupHeaderTplString;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the header that is currently grouped (defaults to false)
			/// </summary>
            public virtual TBuilder HideGroupedHeader(bool hideGroupedHeader)
            {
                this.ToComponent().HideGroupedHeader = hideGroupedHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').
			/// </summary>
            public virtual TBuilder ShowGroupsText(string showGroupsText)
            {
                this.ToComponent().ShowGroupsText = showGroupsText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to start all groups collapsed (defaults to false)
			/// </summary>
            public virtual TBuilder StartCollapsed(bool startCollapsed)
            {
                this.ToComponent().StartCollapsed = startCollapsed;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Grouping.Builder<Grouping, Grouping.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Grouping()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Grouping component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Grouping.Config config) : base(new Grouping(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Grouping component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Grouping(this);
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
        public Grouping.Builder Grouping()
        {
#if MVC
			return this.Grouping(new Grouping { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Grouping(new Grouping());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder Grouping(Grouping component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Grouping.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Grouping.Builder Grouping(Grouping.Config config)
        {
#if MVC
			return new Grouping.Builder(new Grouping(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Grouping.Builder(new Grouping(config));
#endif			
        }
    }
}