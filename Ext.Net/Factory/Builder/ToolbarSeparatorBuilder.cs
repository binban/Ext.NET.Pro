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
    public partial class ToolbarSeparator
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TToolbarSeparator, TBuilder> : ToolbarItem.Builder<TToolbarSeparator, TBuilder>
            where TToolbarSeparator : ToolbarSeparator
            where TBuilder : Builder<TToolbarSeparator, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TToolbarSeparator component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarSeparator.Builder<ToolbarSeparator, ToolbarSeparator.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ToolbarSeparator()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarSeparator component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarSeparator.Config config) : base(new ToolbarSeparator(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ToolbarSeparator component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarSeparator.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ToolbarSeparator(this);
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
        public ToolbarSeparator.Builder ToolbarSeparator()
        {
#if MVC
			return this.ToolbarSeparator(new ToolbarSeparator { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ToolbarSeparator(new ToolbarSeparator());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarSeparator.Builder ToolbarSeparator(ToolbarSeparator component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ToolbarSeparator.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarSeparator.Builder ToolbarSeparator(ToolbarSeparator.Config config)
        {
#if MVC
			return new ToolbarSeparator.Builder(new ToolbarSeparator(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ToolbarSeparator.Builder(new ToolbarSeparator(config));
#endif			
        }
    }
}