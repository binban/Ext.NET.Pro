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
    public partial class ContainerLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Layout.Builder<ContainerLayout, ContainerLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ContainerLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ContainerLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ContainerLayout.Config config) : base(new ContainerLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ContainerLayout component)
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
        public ContainerLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ContainerLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ContainerLayout.Builder ContainerLayout()
        {
            return this.ContainerLayout(new ContainerLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public ContainerLayout.Builder ContainerLayout(ContainerLayout component)
        {
            return new ContainerLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ContainerLayout.Builder ContainerLayout(ContainerLayout.Config config)
        {
            return new ContainerLayout.Builder(new ContainerLayout(config));
        }
    }
}