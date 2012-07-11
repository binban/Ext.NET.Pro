/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class LayoutColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LayoutItem.Builder<LayoutColumn, LayoutColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LayoutColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LayoutColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LayoutColumn.Config config) : base(new LayoutColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LayoutColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than or equal to 1.0.
			/// </summary>
            public virtual LayoutColumn.Builder ColumnWidth(decimal columnWidth)
            {
                this.ToComponent().ColumnWidth = columnWidth;
                return this as LayoutColumn.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LayoutColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public LayoutColumn.Builder LayoutColumn()
        {
            return this.LayoutColumn(new LayoutColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutColumn.Builder LayoutColumn(LayoutColumn component)
        {
            return new LayoutColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutColumn.Builder LayoutColumn(LayoutColumn.Config config)
        {
            return new LayoutColumn.Builder(new LayoutColumn(config));
        }
    }
}