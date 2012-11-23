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
    public partial class ReferenceColumn
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TReferenceColumn, TBuilder> : ColumnBase.Builder<TReferenceColumn, TBuilder>
            where TReferenceColumn : ReferenceColumn
            where TBuilder : Builder<TReferenceColumn, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TReferenceColumn component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Reference(string reference)
            {
                this.ToComponent().Reference = reference;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ReferenceColumn.Builder<ReferenceColumn, ReferenceColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ReferenceColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ReferenceColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ReferenceColumn.Config config) : base(new ReferenceColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ReferenceColumn component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ReferenceColumn(this);
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
        public ReferenceColumn.Builder ReferenceColumn()
        {
#if MVC
			return this.ReferenceColumn(new ReferenceColumn { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ReferenceColumn(new ReferenceColumn());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceColumn.Builder ReferenceColumn(ReferenceColumn component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ReferenceColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ReferenceColumn.Builder ReferenceColumn(ReferenceColumn.Config config)
        {
#if MVC
			return new ReferenceColumn.Builder(new ReferenceColumn(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ReferenceColumn.Builder(new ReferenceColumn(config));
#endif			
        }
    }
}