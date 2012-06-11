/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
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
    public partial class LayoutRow
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LayoutItem.Builder<LayoutRow, LayoutRow.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new LayoutRow()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LayoutRow component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(LayoutRow.Config config) : base(new LayoutRow(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(LayoutRow component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than or equal to 1.0.
			/// </summary>
            public virtual LayoutRow.Builder RowHeight(decimal rowHeight)
            {
                this.ToComponent().RowHeight = rowHeight;
                return this as LayoutRow.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutRow.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.LayoutRow(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public LayoutRow.Builder LayoutRow()
        {
            return this.LayoutRow(new LayoutRow());
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutRow.Builder LayoutRow(LayoutRow component)
        {
            return new LayoutRow.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public LayoutRow.Builder LayoutRow(LayoutRow.Config config)
        {
            return new LayoutRow.Builder(new LayoutRow(config));
        }
    }
}