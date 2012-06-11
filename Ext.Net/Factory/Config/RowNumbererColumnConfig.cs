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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public RowNumbererColumn(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit RowNumbererColumn.Config Conversion to RowNumbererColumn
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator RowNumbererColumn(RowNumbererColumn.Config config)
        {
            return new RowNumbererColumn(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ColumnBase.Config 
        { 
			/*  Implicit RowNumbererColumn.Config Conversion to RowNumbererColumn.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator RowNumbererColumn.Builder(RowNumbererColumn.Config config)
			{
				return new RowNumbererColumn.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private Unit width = Unit.Pixel(-1);

			/// <summary>
			/// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.
			/// </summary>
			[DefaultValue(typeof(Unit), "-1")]
			public override Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private int rowSpan = 1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(1)]
			public virtual int RowSpan 
			{ 
				get
				{
					return this.rowSpan;
				}
				set
				{
					this.rowSpan = value;
				}
			}

        }
    }
}