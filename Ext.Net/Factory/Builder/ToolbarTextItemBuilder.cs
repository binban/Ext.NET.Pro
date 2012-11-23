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
    public partial class ToolbarTextItem
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TToolbarTextItem, TBuilder> : ToolbarItem.Builder<TToolbarTextItem, TBuilder>
            where TToolbarTextItem : ToolbarTextItem
            where TBuilder : Builder<TToolbarTextItem, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TToolbarTextItem component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text to be used as innerHTML (html tags are accepted). Defaults to: \"\"
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<AbstractComponentListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<AbstractComponentDirectEvents> action)
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
        public partial class Builder : ToolbarTextItem.Builder<ToolbarTextItem, ToolbarTextItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ToolbarTextItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarTextItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarTextItem.Config config) : base(new ToolbarTextItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ToolbarTextItem component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarTextItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ToolbarTextItem(this);
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
        public ToolbarTextItem.Builder ToolbarTextItem()
        {
#if MVC
			return this.ToolbarTextItem(new ToolbarTextItem { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ToolbarTextItem(new ToolbarTextItem());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarTextItem.Builder ToolbarTextItem(ToolbarTextItem component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ToolbarTextItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarTextItem.Builder ToolbarTextItem(ToolbarTextItem.Config config)
        {
#if MVC
			return new ToolbarTextItem.Builder(new ToolbarTextItem(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ToolbarTextItem.Builder(new ToolbarTextItem(config));
#endif			
        }
    }
}