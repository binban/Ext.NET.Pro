/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
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
    public partial class CenterLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ContainerLayout.Builder<CenterLayout, CenterLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CenterLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CenterLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CenterLayout.Config config) : base(new CenterLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CenterLayout component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CenterLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CenterLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CenterLayout.Builder CenterLayout()
        {
            return this.CenterLayout(new CenterLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public CenterLayout.Builder CenterLayout(CenterLayout component)
        {
            return new CenterLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CenterLayout.Builder CenterLayout(CenterLayout.Config config)
        {
            return new CenterLayout.Builder(new CenterLayout(config));
        }
    }
}