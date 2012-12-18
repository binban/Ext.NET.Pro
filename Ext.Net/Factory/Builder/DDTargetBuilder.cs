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
    public partial class DDTarget
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDDTarget, TBuilder> : DragDrop.Builder<TDDTarget, TBuilder>
            where TDDTarget : DDTarget
            where TBuilder : Builder<TDDTarget, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDDTarget component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DDTarget.Builder<DDTarget, DDTarget.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DDTarget()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DDTarget component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DDTarget.Config config) : base(new DDTarget(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DDTarget component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DDTarget.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DDTarget(this);
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
        public DDTarget.Builder DDTarget()
        {
#if MVC
			return this.DDTarget(new DDTarget { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DDTarget(new DDTarget());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DDTarget.Builder DDTarget(DDTarget component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DDTarget.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DDTarget.Builder DDTarget(DDTarget.Config config)
        {
#if MVC
			return new DDTarget.Builder(new DDTarget(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DDTarget.Builder(new DDTarget(config));
#endif			
        }
    }
}