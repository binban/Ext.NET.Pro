/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
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
    public partial class TreeGridColumn
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TreeGridColumn(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TreeGridColumn.Config Conversion to TreeGridColumn
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TreeGridColumn(TreeGridColumn.Config config)
        {
            return new TreeGridColumn(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit TreeGridColumn.Config Conversion to TreeGridColumn.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TreeGridColumn.Builder(TreeGridColumn.Config config)
			{
				return new TreeGridColumn.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private TextAlign align = TextAlign.Left;

			/// <summary>
			/// Set the CSS text-align property of the column. Defaults to 'left'.
			/// </summary>
			[DefaultValue(TextAlign.Left)]
			public virtual TextAlign Align 
			{ 
				get
				{
					return this.align;
				}
				set
				{
					this.align = value;
				}
			}

			private string cls = null;

			/// <summary>
			/// Optional. This option can be used to add a CSS class to the cell of each row for this column.
			/// </summary>
			[DefaultValue(null)]
			public virtual string Cls 
			{ 
				get
				{
					return this.cls;
				}
				set
				{
					this.cls = value;
				}
			}

			private string dataIndex = null;

			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DataIndex 
			{ 
				get
				{
					return this.dataIndex;
				}
				set
				{
					this.dataIndex = value;
				}
			}

			private string header = "";

			/// <summary>
			/// The header text to display in the Grid view.
			/// </summary>
			[DefaultValue("")]
			public virtual string Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private bool hideable = true;

			/// <summary>
			/// (optional) Specify as false to prevent the user from hiding this column. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Hideable 
			{ 
				get
				{
					return this.hideable;
				}
				set
				{
					this.hideable = value;
				}
			}

			private string template = "";

			/// <summary>
			/// Specify a string to pass as the configuration string for Ext.XTemplate. By default an Ext.XTemplate will be implicitly created using the dataIndex.
			/// </summary>
			[DefaultValue("")]
			public virtual string Template 
			{ 
				get
				{
					return this.template;
				}
				set
				{
					this.template = value;
				}
			}
        
			private XTemplate xTemplate = null;

			/// <summary>
			/// An XTemplate to use to process a Record's data to produce a column's rendered value.
			/// </summary>
			public XTemplate XTemplate
			{
				get
				{
					if (this.xTemplate == null)
					{
						this.xTemplate = new XTemplate();
					}
			
					return this.xTemplate;
				}
			}
			
			private double width = 0.0;

			/// <summary>
			/// Percentage of the container width this column should be allocated. Columns that have no width specified will be allocated with an equal percentage to fill 100% of the container width. To easily take advantage of the full container width, leave the width of at least one column undefined. Note that if you do not want to take up the full width of the container, the width of every column needs to be explicitly defined.
			/// </summary>
			[DefaultValue(0.0)]
			public virtual double Width 
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

			private SortTypeMethod sortType = SortTypeMethod.None;

			/// <summary>
			/// Sort method
			/// </summary>
			[DefaultValue(SortTypeMethod.None)]
			public virtual SortTypeMethod SortType 
			{ 
				get
				{
					return this.sortType;
				}
				set
				{
					this.sortType = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// (optional) True to hide the column. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

        }
    }
}