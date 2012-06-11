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
    public partial class RowNumbererColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ColumnBase.Builder<RowNumbererColumn, RowNumbererColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new RowNumbererColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowNumbererColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(RowNumbererColumn.Config config) : base(new RowNumbererColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(RowNumbererColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.
			/// </summary>
            public virtual RowNumbererColumn.Builder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as RowNumbererColumn.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual RowNumbererColumn.Builder RowSpan(int rowSpan)
            {
                this.ToComponent().RowSpan = rowSpan;
                return this as RowNumbererColumn.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public RowNumbererColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.RowNumbererColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public RowNumbererColumn.Builder RowNumbererColumn()
        {
            return this.RowNumbererColumn(new RowNumbererColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public RowNumbererColumn.Builder RowNumbererColumn(RowNumbererColumn component)
        {
            return new RowNumbererColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public RowNumbererColumn.Builder RowNumbererColumn(RowNumbererColumn.Config config)
        {
            return new RowNumbererColumn.Builder(new RowNumbererColumn(config));
        }
    }
}