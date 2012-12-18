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
    public partial class Toolbar
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TToolbar, TBuilder> : ToolbarBase.Builder<TToolbar, TBuilder>
            where TToolbar : Toolbar
            where TBuilder : Builder<TToolbar, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TToolbar component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ToolbarListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ToolbarDirectEvents> action)
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
        public partial class Builder : Toolbar.Builder<Toolbar, Toolbar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Toolbar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Toolbar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Toolbar.Config config) : base(new Toolbar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Toolbar component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Toolbar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Toolbar(this);
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
        public Toolbar.Builder Toolbar()
        {
#if MVC
			return this.Toolbar(new Toolbar { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Toolbar(new Toolbar());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Toolbar.Builder Toolbar(Toolbar component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Toolbar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Toolbar.Builder Toolbar(Toolbar.Config config)
        {
#if MVC
			return new Toolbar.Builder(new Toolbar(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Toolbar.Builder(new Toolbar(config));
#endif			
        }
    }
}