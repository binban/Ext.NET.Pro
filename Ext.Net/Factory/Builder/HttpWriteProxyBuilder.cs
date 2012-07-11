/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class HttpWriteProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : HttpProxy.Builder<HttpWriteProxy, HttpWriteProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HttpWriteProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HttpWriteProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HttpWriteProxy.Config config) : base(new HttpWriteProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HttpWriteProxy component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If save handler is web service then response will be xml. This option specifies how to handle response.
			/// </summary>
            public virtual HttpWriteProxy.Builder HandleSaveResponseAsXml(bool handleSaveResponseAsXml)
            {
                this.ToComponent().HandleSaveResponseAsXml = handleSaveResponseAsXml;
                return this as HttpWriteProxy.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpWriteProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HttpWriteProxy(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpWriteProxy.Builder HttpWriteProxy()
        {
            return this.HttpWriteProxy(new HttpWriteProxy());
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpWriteProxy.Builder HttpWriteProxy(HttpWriteProxy component)
        {
            return new HttpWriteProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpWriteProxy.Builder HttpWriteProxy(HttpWriteProxy.Config config)
        {
            return new HttpWriteProxy.Builder(new HttpWriteProxy(config));
        }
    }
}