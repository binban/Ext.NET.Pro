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
    public partial class CRUDMethods
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCRUDMethods, TBuilder> : BaseItem.Builder<TCRUDMethods, TBuilder>
            where TCRUDMethods : CRUDMethods
            where TBuilder : Builder<TCRUDMethods, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCRUDMethods component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Create(HttpMethod create)
            {
                this.ToComponent().Create = create;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Read(HttpMethod read)
            {
                this.ToComponent().Read = read;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Update(HttpMethod update)
            {
                this.ToComponent().Update = update;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Destroy(HttpMethod destroy)
            {
                this.ToComponent().Destroy = destroy;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CRUDMethods.Builder<CRUDMethods, CRUDMethods.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CRUDMethods()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CRUDMethods component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CRUDMethods.Config config) : base(new CRUDMethods(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CRUDMethods component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CRUDMethods(this);
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
        public CRUDMethods.Builder CRUDMethods()
        {
#if MVC
			return this.CRUDMethods(new CRUDMethods { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CRUDMethods(new CRUDMethods());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder CRUDMethods(CRUDMethods component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CRUDMethods.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CRUDMethods.Builder CRUDMethods(CRUDMethods.Config config)
        {
#if MVC
			return new CRUDMethods.Builder(new CRUDMethods(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CRUDMethods.Builder(new CRUDMethods(config));
#endif			
        }
    }
}