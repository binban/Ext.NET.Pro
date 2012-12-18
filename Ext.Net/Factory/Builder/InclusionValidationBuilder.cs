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
    public partial class InclusionValidation
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TInclusionValidation, TBuilder> : AbstractValidation.Builder<TInclusionValidation, TBuilder>
            where TInclusionValidation : InclusionValidation
            where TBuilder : Builder<TInclusionValidation, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TInclusionValidation component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : InclusionValidation.Builder<InclusionValidation, InclusionValidation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new InclusionValidation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(InclusionValidation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(InclusionValidation.Config config) : base(new InclusionValidation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(InclusionValidation component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public InclusionValidation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.InclusionValidation(this);
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
        public InclusionValidation.Builder InclusionValidation()
        {
#if MVC
			return this.InclusionValidation(new InclusionValidation { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.InclusionValidation(new InclusionValidation());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public InclusionValidation.Builder InclusionValidation(InclusionValidation component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new InclusionValidation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public InclusionValidation.Builder InclusionValidation(InclusionValidation.Config config)
        {
#if MVC
			return new InclusionValidation.Builder(new InclusionValidation(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new InclusionValidation.Builder(new InclusionValidation(config));
#endif			
        }
    }
}