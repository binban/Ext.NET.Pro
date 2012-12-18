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
    public partial class TabMenu
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTabMenu, TBuilder> : Plugin.Builder<TTabMenu, TBuilder>
            where TTabMenu : TabMenu
            where TBuilder : Builder<TTabMenu, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTabMenu component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TabMenu.Builder<TabMenu, TabMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabMenu.Config config) : base(new TabMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabMenu component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TabMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabMenu(this);
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
        public TabMenu.Builder TabMenu()
        {
#if MVC
			return this.TabMenu(new TabMenu { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TabMenu(new TabMenu());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabMenu.Builder TabMenu(TabMenu component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TabMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabMenu.Builder TabMenu(TabMenu.Config config)
        {
#if MVC
			return new TabMenu.Builder(new TabMenu(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TabMenu.Builder(new TabMenu(config));
#endif			
        }
    }
}