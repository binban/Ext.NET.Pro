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
    public partial class AxisGrid
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TAxisGrid, TBuilder> : BaseItem.Builder<TAxisGrid, TBuilder>
            where TAxisGrid : AxisGrid
            where TBuilder : Builder<TAxisGrid, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TAxisGrid component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Odd(SpriteAttributes odd)
            {
                this.ToComponent().Odd = odd;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Even(SpriteAttributes even)
            {
                this.ToComponent().Even = even;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : AxisGrid.Builder<AxisGrid, AxisGrid.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new AxisGrid()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AxisGrid component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AxisGrid.Config config) : base(new AxisGrid(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(AxisGrid component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AxisGrid.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.AxisGrid(this);
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
        public AxisGrid.Builder AxisGrid()
        {
#if MVC
			return this.AxisGrid(new AxisGrid { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.AxisGrid(new AxisGrid());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public AxisGrid.Builder AxisGrid(AxisGrid component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new AxisGrid.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public AxisGrid.Builder AxisGrid(AxisGrid.Config config)
        {
#if MVC
			return new AxisGrid.Builder(new AxisGrid(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new AxisGrid.Builder(new AxisGrid(config));
#endif			
        }
    }
}