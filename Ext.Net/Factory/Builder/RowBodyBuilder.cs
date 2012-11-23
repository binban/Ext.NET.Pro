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
    public partial class RowBody
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TRowBody, TBuilder> : GridFeature.Builder<TRowBody, TBuilder>
            where TRowBody : RowBody
            where TBuilder : Builder<TRowBody, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TRowBody component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RowBodyHiddenCls(string rowBodyHiddenCls)
            {
                this.ToComponent().RowBodyHiddenCls = rowBodyHiddenCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RowBodyTrCls(string rowBodyTrCls)
            {
                this.ToComponent().RowBodyTrCls = rowBodyTrCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RowBodyTdCls(string rowBodyTdCls)
            {
                this.ToComponent().RowBodyTdCls = rowBodyTdCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RowBodyDivCls(string rowBodyDivCls)
            {
                this.ToComponent().RowBodyDivCls = rowBodyDivCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GetAdditionalData(Action<JFunction> action)
            {
                action(this.ToComponent().GetAdditionalData);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : RowBody.Builder<RowBody, RowBody.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowBody()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowBody component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowBody.Config config) : base(new RowBody(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowBody component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowBody(this);
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
        public RowBody.Builder RowBody()
        {
#if MVC
			return this.RowBody(new RowBody { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.RowBody(new RowBody());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder RowBody(RowBody component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new RowBody.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowBody.Builder RowBody(RowBody.Config config)
        {
#if MVC
			return new RowBody.Builder(new RowBody(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new RowBody.Builder(new RowBody(config));
#endif			
        }
    }
}