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
    public partial class CommandText
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCommandText, TBuilder> : GridCommandBase.Builder<TCommandText, TBuilder>
            where TCommandText : CommandText
            where TBuilder : Builder<TCommandText, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCommandText component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CommandText.Builder<CommandText, CommandText.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandText()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandText component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandText.Config config) : base(new CommandText(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandText component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandText.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandText(this);
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
        public CommandText.Builder CommandText()
        {
#if MVC
			return this.CommandText(new CommandText { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CommandText(new CommandText());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandText.Builder CommandText(CommandText component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CommandText.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandText.Builder CommandText(CommandText.Config config)
        {
#if MVC
			return new CommandText.Builder(new CommandText(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CommandText.Builder(new CommandText(config));
#endif			
        }
    }
}