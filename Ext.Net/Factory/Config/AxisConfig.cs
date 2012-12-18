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
    public abstract partial class Axis
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractAxis.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool adjustEnd = true;

			/// <summary>
			/// Whether to adjust the label at the end of the axis. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AdjustEnd 
			{ 
				get
				{
					return this.adjustEnd;
				}
				set
				{
					this.adjustEnd = value;
				}
			}

			private int dashSize = 3;

			/// <summary>
			/// The size of the dash marker. Default's 3.
			/// </summary>
			[DefaultValue(3)]
			public virtual int DashSize 
			{ 
				get
				{
					return this.dashSize;
				}
				set
				{
					this.dashSize = value;
				}
			}

			private bool grid = false;

			/// <summary>
			/// The grid configuration enables you to set a background grid for an axis. If set to true on a vertical axis, vertical lines will be drawn. If set to true on a horizontal axis, horizontal lines will be drawn. If both are set, a proper grid with horizontal and vertical lines will be drawn.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Grid 
			{ 
				get
				{
					return this.grid;
				}
				set
				{
					this.grid = value;
				}
			}

			private AxisGrid gridConfig = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual AxisGrid GridConfig 
			{ 
				get
				{
					return this.gridConfig;
				}
				set
				{
					this.gridConfig = value;
				}
			}

			private int length = 0;

			/// <summary>
			/// Offset axis position. Default's 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Length 
			{ 
				get
				{
					return this.length;
				}
				set
				{
					this.length = value;
				}
			}

			private int majorTickSteps = int.MinValue;

			/// <summary>
			/// If minimum and maximum are specified it forces the number of major ticks to the specified value.
			/// </summary>
			[DefaultValue(int.MinValue)]
			public virtual int MajorTickSteps 
			{ 
				get
				{
					return this.majorTickSteps;
				}
				set
				{
					this.majorTickSteps = value;
				}
			}

			private int minorTickSteps = 0;

			/// <summary>
			/// The number of small ticks between two major ticks. Default is zero.
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinorTickSteps 
			{ 
				get
				{
					return this.minorTickSteps;
				}
				set
				{
					this.minorTickSteps = value;
				}
			}

			private Position position = Position.Bottom;

			/// <summary>
			/// Where to set the axis. Available options are left, bottom, right, top. Default's bottom.
			/// </summary>
			[DefaultValue(Position.Bottom)]
			public virtual Position Position 
			{ 
				get
				{
					return this.position;
				}
				set
				{
					this.position = value;
				}
			}

			private string title = "";

			/// <summary>
			/// The title for the Axis
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private int width = 0;

			/// <summary>
			/// Offset axis width. Default's 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Width 
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

			private string[] fields = null;

			/// <summary>
			/// The fields of model to bind to this axis.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Fields 
			{ 
				get
				{
					return this.fields;
				}
				set
				{
					this.fields = value;
				}
			}

        }
    }
}