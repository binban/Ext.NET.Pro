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
    public partial class ActionColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TActionColumn, TBuilder> : ColumnBase.Builder<TActionColumn, TBuilder>
            where TActionColumn : ActionColumn
            where TBuilder : Builder<TActionColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TActionColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The alt text to use for the image element. Defaults to ''.
			/// </summary>
            public virtual TBuilder AltText(string altText)
            {
                this.ToComponent().AltText = altText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to true. Prevent grid row selection upon mousedown.
			/// </summary>
            public virtual TBuilder StopSelection(bool stopSelection)
            {
                this.ToComponent().StopSelection = stopSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Items(Action<ActionItemCollection> action)
            {
                action(this.ToComponent().Items);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ActionColumn.Builder<ActionColumn, ActionColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ActionColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ActionColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ActionColumn.Config config) : base(new ActionColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ActionColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ActionColumn(this);
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
        public ActionColumn.Builder ActionColumn()
        {
#if MVC
			return this.ActionColumn(new ActionColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ActionColumn(new ActionColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionColumn.Builder ActionColumn(ActionColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ActionColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ActionColumn.Builder ActionColumn(ActionColumn.Config config)
        {
#if MVC
			return new ActionColumn.Builder(new ActionColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ActionColumn.Builder(new ActionColumn(config));
#endif			
        }
    }
}