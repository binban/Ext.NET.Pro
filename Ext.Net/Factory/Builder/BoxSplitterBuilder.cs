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
    public partial class BoxSplitter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TBoxSplitter, TBuilder> : AbstractComponent.Builder<TBoxSplitter, TBuilder>
            where TBoxSplitter : BoxSplitter
            where TBuilder : Builder<TBoxSplitter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TBoxSplitter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to enable dblclick to toggle expand and collapse on the collapseTarget Panel. Defaults to: true
			/// </summary>
            public virtual TBuilder CollapseOnDblClick(bool collapseOnDblClick)
            {
                this.ToComponent().CollapseOnDblClick = collapseOnDblClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string describing the relative position of the immediate sibling Panel to collapse.
			/// </summary>
            public virtual TBuilder CollapseTarget(CollapseTarget collapseTarget)
            {
                this.ToComponent().CollapseTarget = collapseTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string describing the relative position of the immediate sibling Panel to collapse.
			/// </summary>
            public virtual TBuilder CollapseTargetPanel(string collapseTargetPanel)
            {
                this.ToComponent().CollapseTargetPanel = collapseTargetPanel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A class to add to the splitter when it is collapsed. See collapsible.
			/// </summary>
            public virtual TBuilder CollapsedCls(string collapsedCls)
            {
                this.ToComponent().CollapsedCls = collapsedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show a mini-collapse tool in the Splitter to toggle expand and collapse on the collapseTarget Panel. Defaults to the collapsible setting of the Panel. Defaults to: false
			/// </summary>
            public virtual TBuilder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Provides a default maximum width or height for the two components that the splitter is between. Defaults to: 1000
			/// </summary>
            public virtual TBuilder DefaultSplitMax(int defaultSplitMax)
            {
                this.ToComponent().DefaultSplitMax = defaultSplitMax;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Provides a default minimum width or height for the two components that the splitter is between. Defaults to: 40
			/// </summary>
            public virtual TBuilder DefaultSplitMin(int defaultSplitMin)
            {
                this.ToComponent().DefaultSplitMin = defaultSplitMin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to false to prevent this Splitter's mini-collapse tool from managing the collapse state of the collapseTarget.
			/// </summary>
            public virtual TBuilder PerformCollapse(bool performCollapse)
            {
                this.ToComponent().PerformCollapse = performCollapse;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : BoxSplitter.Builder<BoxSplitter, BoxSplitter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BoxSplitter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BoxSplitter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BoxSplitter.Config config) : base(new BoxSplitter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BoxSplitter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BoxSplitter(this);
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
        public BoxSplitter.Builder BoxSplitter()
        {
#if MVC
			return this.BoxSplitter(new BoxSplitter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.BoxSplitter(new BoxSplitter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder BoxSplitter(BoxSplitter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new BoxSplitter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BoxSplitter.Builder BoxSplitter(BoxSplitter.Config config)
        {
#if MVC
			return new BoxSplitter.Builder(new BoxSplitter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new BoxSplitter.Builder(new BoxSplitter(config));
#endif			
        }
    }
}