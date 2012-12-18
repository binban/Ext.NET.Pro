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
    public partial class FormatValidation
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TFormatValidation, TBuilder> : AbstractValidation.Builder<TFormatValidation, TBuilder>
            where TFormatValidation : FormatValidation
            where TBuilder : Builder<TFormatValidation, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFormatValidation component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A JavaScript RegExp object to be tested against the value
			/// </summary>
            public virtual TBuilder Matcher(string matcher)
            {
                this.ToComponent().Matcher = matcher;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : FormatValidation.Builder<FormatValidation, FormatValidation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FormatValidation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FormatValidation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FormatValidation.Config config) : base(new FormatValidation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FormatValidation component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FormatValidation(this);
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
        public FormatValidation.Builder FormatValidation()
        {
#if MVC
			return this.FormatValidation(new FormatValidation { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.FormatValidation(new FormatValidation());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder FormatValidation(FormatValidation component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new FormatValidation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FormatValidation.Builder FormatValidation(FormatValidation.Config config)
        {
#if MVC
			return new FormatValidation.Builder(new FormatValidation(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new FormatValidation.Builder(new FormatValidation(config));
#endif			
        }
    }
}