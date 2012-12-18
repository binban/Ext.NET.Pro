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
    public partial class DesktopModuleProxy
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDesktopModuleProxy, TBuilder> : BaseControl.Builder<TDesktopModuleProxy, TBuilder>
            where TDesktopModuleProxy : DesktopModuleProxy
            where TBuilder : Builder<TDesktopModuleProxy, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDesktopModuleProxy component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Module(DesktopModule module)
            {
                this.ToComponent().Module = module;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DesktopModuleProxy.Builder<DesktopModuleProxy, DesktopModuleProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopModuleProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopModuleProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopModuleProxy.Config config) : base(new DesktopModuleProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopModuleProxy component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModuleProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopModuleProxy(this);
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
        public DesktopModuleProxy.Builder DesktopModuleProxy()
        {
#if MVC
			return this.DesktopModuleProxy(new DesktopModuleProxy { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DesktopModuleProxy(new DesktopModuleProxy());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModuleProxy.Builder DesktopModuleProxy(DesktopModuleProxy component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DesktopModuleProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopModuleProxy.Builder DesktopModuleProxy(DesktopModuleProxy.Config config)
        {
#if MVC
			return new DesktopModuleProxy.Builder(new DesktopModuleProxy(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DesktopModuleProxy.Builder(new DesktopModuleProxy(config));
#endif			
        }
    }
}