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
    public partial class PasswordMask
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TPasswordMask, TBuilder> : Plugin.Builder<TPasswordMask, TBuilder>
            where TPasswordMask : PasswordMask
            where TBuilder : Builder<TPasswordMask, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TPasswordMask component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Duration(int duration)
            {
                this.ToComponent().Duration = duration;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ReplacementChar(char replacementChar)
            {
                this.ToComponent().ReplacementChar = replacementChar;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : PasswordMask.Builder<PasswordMask, PasswordMask.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PasswordMask()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PasswordMask component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PasswordMask.Config config) : base(new PasswordMask(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PasswordMask component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PasswordMask.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PasswordMask(this);
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
        public PasswordMask.Builder PasswordMask()
        {
#if MVC
			return this.PasswordMask(new PasswordMask { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.PasswordMask(new PasswordMask());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public PasswordMask.Builder PasswordMask(PasswordMask component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new PasswordMask.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PasswordMask.Builder PasswordMask(PasswordMask.Config config)
        {
#if MVC
			return new PasswordMask.Builder(new PasswordMask(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PasswordMask.Builder(new PasswordMask(config));
#endif			
        }
    }
}