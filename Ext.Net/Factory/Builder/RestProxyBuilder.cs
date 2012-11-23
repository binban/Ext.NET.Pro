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
    public partial class RestProxy
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TRestProxy, TBuilder> : AjaxProxy.Builder<TRestProxy, TBuilder>
            where TRestProxy : RestProxy
            where TBuilder : Builder<TRestProxy, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TRestProxy component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to automatically append the ID of a Model instance when performing a request based on that single instance. See RestProxy intro docs for more details. Defaults to true.
			/// </summary>
            public virtual TBuilder AppendId(bool appendId)
            {
                this.ToComponent().AppendId = appendId;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional data format to send to the server when making any request (e.g. 'json'). See the RestProxy intro docs for full details. Defaults to undefined.
			/// </summary>
            public virtual TBuilder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : RestProxy.Builder<RestProxy, RestProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RestProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RestProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RestProxy.Config config) : base(new RestProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RestProxy component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RestProxy(this);
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
        public RestProxy.Builder RestProxy()
        {
#if MVC
			return this.RestProxy(new RestProxy { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.RestProxy(new RestProxy());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder RestProxy(RestProxy component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new RestProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RestProxy.Builder RestProxy(RestProxy.Config config)
        {
#if MVC
			return new RestProxy.Builder(new RestProxy(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new RestProxy.Builder(new RestProxy(config));
#endif			
        }
    }
}