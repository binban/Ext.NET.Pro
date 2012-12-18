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
    public partial class SummaryColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSummaryColumn, TBuilder> : Column.Builder<TSummaryColumn, TBuilder>
            where TSummaryColumn : SummaryColumn
            where TBuilder : Builder<TSummaryColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSummaryColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SummaryType(SummaryType summaryType)
            {
                this.ToComponent().SummaryType = summaryType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CustomSummaryType(string customSummaryType)
            {
                this.ToComponent().CustomSummaryType = customSummaryType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SummaryRenderer(Action<JFunction> action)
            {
                action(this.ToComponent().SummaryRenderer);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : SummaryColumn.Builder<SummaryColumn, SummaryColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SummaryColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SummaryColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SummaryColumn.Config config) : base(new SummaryColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SummaryColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SummaryColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SummaryColumn(this);
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
        public SummaryColumn.Builder SummaryColumn()
        {
#if MVC
			return this.SummaryColumn(new SummaryColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.SummaryColumn(new SummaryColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public SummaryColumn.Builder SummaryColumn(SummaryColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new SummaryColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SummaryColumn.Builder SummaryColumn(SummaryColumn.Config config)
        {
#if MVC
			return new SummaryColumn.Builder(new SummaryColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new SummaryColumn.Builder(new SummaryColumn(config));
#endif			
        }
    }
}