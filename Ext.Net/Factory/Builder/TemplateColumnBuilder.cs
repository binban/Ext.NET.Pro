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
    public partial class TemplateColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTemplateColumn, TBuilder> : CellCommandColumn.Builder<TTemplateColumn, TBuilder>
            where TTemplateColumn : TemplateColumn
            where TBuilder : Builder<TTemplateColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTemplateColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Template(Action<XTemplate> action)
            {
                action(this.ToComponent().Template);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An XTemplate, or an XTemplate definition string to use to process a Model's data to produce a column's rendered value.
			/// </summary>
            public virtual TBuilder TemplateString(string templateString)
            {
                this.ToComponent().TemplateString = templateString;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TemplateColumn.Builder<TemplateColumn, TemplateColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TemplateColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TemplateColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TemplateColumn.Config config) : base(new TemplateColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TemplateColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TemplateColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TemplateColumn(this);
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
        public TemplateColumn.Builder TemplateColumn()
        {
#if MVC
			return this.TemplateColumn(new TemplateColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TemplateColumn(new TemplateColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TemplateColumn.Builder TemplateColumn(TemplateColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TemplateColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TemplateColumn.Builder TemplateColumn(TemplateColumn.Config config)
        {
#if MVC
			return new TemplateColumn.Builder(new TemplateColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TemplateColumn.Builder(new TemplateColumn(config));
#endif			
        }
    }
}