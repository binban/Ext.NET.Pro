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
    public partial class DateMenu
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDateMenu, TBuilder> : MenuBase.Builder<TDateMenu, TBuilder>
            where TDateMenu : DateMenu
            where TBuilder : Builder<TDateMenu, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDateMenu component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// False to continue showing the menu after a date is selected, defaults to true.
			/// </summary>
            public virtual TBuilder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.DatePicker object
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Picker(Action<DatePicker> action)
            {
                action(this.ToComponent().Picker);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<DateMenuListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<DateMenuDirectEvents> action)
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
        public partial class Builder : DateMenu.Builder<DateMenu, DateMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DateMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DateMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DateMenu.Config config) : base(new DateMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DateMenu component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DateMenu(this);
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
        public DateMenu.Builder DateMenu()
        {
#if MVC
			return this.DateMenu(new DateMenu { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DateMenu(new DateMenu());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder DateMenu(DateMenu component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DateMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DateMenu.Builder DateMenu(DateMenu.Config config)
        {
#if MVC
			return new DateMenu.Builder(new DateMenu(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DateMenu.Builder(new DateMenu(config));
#endif			
        }
    }
}