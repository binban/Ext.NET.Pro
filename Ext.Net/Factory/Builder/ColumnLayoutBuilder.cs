/********
 * @version   : 1.6.0 - Ext.NET Pro License
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
    public partial class ColumnLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ContainerLayout.Builder<ColumnLayout, ColumnLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ColumnLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ColumnLayout.Config config) : base(new ColumnLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ColumnLayout component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to fit the column elements height-wise into the Container. Defaults to false.
			/// </summary>
            public virtual ColumnLayout.Builder FitHeight(bool fitHeight)
            {
                this.ToComponent().FitHeight = fitHeight;
                return this as ColumnLayout.Builder;
            }
             
 			/// <summary>
			/// True to fill background by predefined color. Defaults to false.
			/// </summary>
            public virtual ColumnLayout.Builder Background(bool background)
            {
                this.ToComponent().Background = background;
                return this as ColumnLayout.Builder;
            }
             
 			/// <summary>
			/// True to allow resizing of the columns using a SplitBar. Defaults to false.
			/// </summary>
            public virtual ColumnLayout.Builder Split(bool split)
            {
                this.ToComponent().Split = split;
                return this as ColumnLayout.Builder;
            }
             
 			/// <summary>
			/// Width of margin between columns in pixels. Overrides any style settings. Defaults to 0.
			/// </summary>
            public virtual ColumnLayout.Builder Margin(int margin)
            {
                this.ToComponent().Margin = margin;
                return this as ColumnLayout.Builder;
            }
             
 			/// <summary>
			/// The amount of space to reserve for the scrollbar
			/// </summary>
            public virtual ColumnLayout.Builder ScrollOffset(int scrollOffset)
            {
                this.ToComponent().ScrollOffset = scrollOffset;
                return this as ColumnLayout.Builder;
            }
             
 			// /// <summary>
			// /// Columns collection
			// /// </summary>
            // public virtual TBuilder Columns(LayoutColumnCollection columns)
            // {
            //    this.ToComponent().Columns = columns;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ColumnLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnLayout.Builder ColumnLayout()
        {
            return this.ColumnLayout(new ColumnLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnLayout.Builder ColumnLayout(ColumnLayout component)
        {
            return new ColumnLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColumnLayout.Builder ColumnLayout(ColumnLayout.Config config)
        {
            return new ColumnLayout.Builder(new ColumnLayout(config));
        }
    }
}