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
    public partial class CommandSpacer
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCommandSpacer, TBuilder> : GridCommandBase.Builder<TCommandSpacer, TBuilder>
            where TCommandSpacer : CommandSpacer
            where TBuilder : Builder<TCommandSpacer, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCommandSpacer component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CommandSpacer.Builder<CommandSpacer, CommandSpacer.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandSpacer()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandSpacer component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandSpacer.Config config) : base(new CommandSpacer(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandSpacer component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandSpacer.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandSpacer(this);
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
        public CommandSpacer.Builder CommandSpacer()
        {
#if MVC
			return this.CommandSpacer(new CommandSpacer { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CommandSpacer(new CommandSpacer());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandSpacer.Builder CommandSpacer(CommandSpacer component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CommandSpacer.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandSpacer.Builder CommandSpacer(CommandSpacer.Config config)
        {
#if MVC
			return new CommandSpacer.Builder(new CommandSpacer(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CommandSpacer.Builder(new CommandSpacer(config));
#endif			
        }
    }
}