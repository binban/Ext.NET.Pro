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
    public partial class ToolbarHtmlElement
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarItem.Builder<ToolbarHtmlElement, ToolbarHtmlElement.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ToolbarHtmlElement()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarHtmlElement component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarHtmlElement.Config config) : base(new ToolbarHtmlElement(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ToolbarHtmlElement component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The target element which will be placed to toolbar.
			/// </summary>
            public virtual ToolbarHtmlElement.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as ToolbarHtmlElement.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ToolbarHtmlElement(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToolbarHtmlElement()
        {
            return this.ToolbarHtmlElement(new ToolbarHtmlElement());
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToolbarHtmlElement(ToolbarHtmlElement component)
        {
            return new ToolbarHtmlElement.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarHtmlElement.Builder ToolbarHtmlElement(ToolbarHtmlElement.Config config)
        {
            return new ToolbarHtmlElement.Builder(new ToolbarHtmlElement(config));
        }
    }
}