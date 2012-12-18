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
    public partial class TransformGrid
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTransformGrid, TBuilder> : GridPanel.Builder<TTransformGrid, TBuilder>
            where TTransformGrid : TransformGrid
            where TBuilder : Builder<TTransformGrid, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTransformGrid component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The table element from which this grid will be created.
			/// </summary>
            public virtual TBuilder Table(string table)
            {
                this.ToComponent().Table = table;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TransformGrid.Builder<TransformGrid, TransformGrid.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TransformGrid()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TransformGrid component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TransformGrid.Config config) : base(new TransformGrid(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TransformGrid component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TransformGrid.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TransformGrid(this);
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
        public TransformGrid.Builder TransformGrid()
        {
#if MVC
			return this.TransformGrid(new TransformGrid { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TransformGrid(new TransformGrid());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TransformGrid.Builder TransformGrid(TransformGrid component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TransformGrid.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TransformGrid.Builder TransformGrid(TransformGrid.Config config)
        {
#if MVC
			return new TransformGrid.Builder(new TransformGrid(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TransformGrid.Builder(new TransformGrid(config));
#endif			
        }
    }
}