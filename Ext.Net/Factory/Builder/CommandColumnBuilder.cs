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
    public partial class CommandColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCommandColumn, TBuilder> : ColumnBase.Builder<TCommandColumn, TBuilder>
            where TCommandColumn : CommandColumn
            where TBuilder : Builder<TCommandColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCommandColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to disabled the column header menu containing sort/hide options. Defaults to false.
			/// </summary>
            public virtual TBuilder MenuDisabled(bool menuDisabled)
            {
                this.ToComponent().MenuDisabled = menuDisabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show toolbar for over row only
			/// </summary>
            public virtual TBuilder OverOnly(bool overOnly)
            {
                this.ToComponent().OverOnly = overOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay before showing over toolbar
			/// </summary>
            public virtual TBuilder ShowDelay(int showDelay)
            {
                this.ToComponent().ShowDelay = showDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Delay before hide over toolbar
			/// </summary>
            public virtual TBuilder HideDelay(int hideDelay)
            {
                this.ToComponent().HideDelay = hideDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Commands(Action<GridCommandCollection> action)
            {
                action(this.ToComponent().Commands);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder GroupCommands(Action<GridCommandCollection> action)
            {
                action(this.ToComponent().GroupCommands);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PrepareToolbar(Action<JFunction> action)
            {
                action(this.ToComponent().PrepareToolbar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder PrepareGroupToolbar(Action<JFunction> action)
            {
                action(this.ToComponent().PrepareGroupToolbar);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Valid values are \"start\", \"center\" and \"end\" (defaults to \"start\").
			/// </summary>
            public virtual TBuilder Pack(BoxPack pack)
            {
                this.ToComponent().Pack = pack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<ImageCommandColumnListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<ImageCommandColumnDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : CommandColumn.Builder<CommandColumn, CommandColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandColumn.Config config) : base(new CommandColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandColumn(this);
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
        public CommandColumn.Builder CommandColumn()
        {
#if MVC
			return this.CommandColumn(new CommandColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.CommandColumn(new CommandColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder CommandColumn(CommandColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new CommandColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandColumn.Builder CommandColumn(CommandColumn.Config config)
        {
#if MVC
			return new CommandColumn.Builder(new CommandColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new CommandColumn.Builder(new CommandColumn(config));
#endif			
        }
    }
}