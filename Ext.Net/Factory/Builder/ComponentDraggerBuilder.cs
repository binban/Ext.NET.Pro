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
    public partial class ComponentDragger
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TComponentDragger, TBuilder> : DragTracker.Builder<TComponentDragger, TBuilder>
            where TComponentDragger : ComponentDragger
            where TBuilder : Builder<TComponentDragger, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComponentDragger component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComponentDragger.Builder<ComponentDragger, ComponentDragger.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComponentDragger()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentDragger component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentDragger.Config config) : base(new ComponentDragger(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComponentDragger component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentDragger.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComponentDragger(this);
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
        public ComponentDragger.Builder ComponentDragger()
        {
#if MVC
			return this.ComponentDragger(new ComponentDragger { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ComponentDragger(new ComponentDragger());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentDragger.Builder ComponentDragger(ComponentDragger component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ComponentDragger.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentDragger.Builder ComponentDragger(ComponentDragger.Config config)
        {
#if MVC
			return new ComponentDragger.Builder(new ComponentDragger(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ComponentDragger.Builder(new ComponentDragger(config));
#endif			
        }
    }
}