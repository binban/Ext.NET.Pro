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
    public abstract partial class ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractComponent.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoScroll = false;

			/// <summary>
			/// true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoScroll 
			{ 
				get
				{
					return this.autoScroll;
				}
				set
				{
					this.autoScroll = value;
				}
			}

			private bool draggable = false;

			/// <summary>
			/// Allows the component to be dragged via the touch event.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Draggable 
			{ 
				get
				{
					return this.draggable;
				}
				set
				{
					this.draggable = value;
				}
			}

			private ComponentDragger draggableConfig = null;

			/// <summary>
			/// Specify as true to make a floating AbstractComponent draggable using the AbstractComponent's encapsulating element as the drag handle.
			/// </summary>
			[DefaultValue(null)]
			public virtual ComponentDragger DraggableConfig 
			{ 
				get
				{
					return this.draggableConfig;
				}
				set
				{
					this.draggableConfig = value;
				}
			}

			private bool maintainFlex = false;

			/// <summary>
			/// Specifies that if an immediate sibling Splitter is moved, the AbstractComponent on the other side is resized, and this AbstractComponent maintains its configured flex value.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MaintainFlex 
			{ 
				get
				{
					return this.maintainFlex;
				}
				set
				{
					this.maintainFlex = value;
				}
			}

			private Overflow overflowX = Overflow.Hidden;

			/// <summary>
			/// Possible values are: * 'auto' to enable automatic horizontal scrollbar (overflow-x: 'auto'). * 'scroll' to always enable horizontal scrollbar (overflow-x: 'scroll'). The default is overflow-x: 'hidden'. This should not be combined with autoScroll.
			/// </summary>
			[DefaultValue(Overflow.Hidden)]
			public virtual Overflow OverflowX 
			{ 
				get
				{
					return this.overflowX;
				}
				set
				{
					this.overflowX = value;
				}
			}

			private Overflow overflowY = Overflow.Hidden;

			/// <summary>
			/// Possible values are: * 'auto' to enable automatic vertical scrollbar (overflow-y: 'auto'). * 'scroll' to always enable vertical scrollbar (overflow-y: 'scroll'). The default is overflow-y: 'hidden'. This should not be combined with autoScroll.
			/// </summary>
			[DefaultValue(Overflow.Hidden)]
			public virtual Overflow OverflowY 
			{ 
				get
				{
					return this.overflowY;
				}
				set
				{
					this.overflowY = value;
				}
			}

			private bool resizable = false;

			/// <summary>
			/// Specify as true to apply a Resizer to this AbstractComponent after rendering.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Resizable 
			{ 
				get
				{
					return this.resizable;
				}
				set
				{
					this.resizable = value;
				}
			}

			private Resizer resizableConfig = null;

			/// <summary>
			/// Specify as a config object to apply a Resizer to this AbstractComponent after rendering.
			/// </summary>
			[DefaultValue(null)]
			public virtual Resizer ResizableConfig 
			{ 
				get
				{
					return this.resizableConfig;
				}
				set
				{
					this.resizableConfig = value;
				}
			}

			private ResizeHandle resizeHandles = ResizeHandle.All;

			/// <summary>
			/// A valid Ext.resizer.Resizer handles config string (defaults to 'all'). Only applies when resizable = true.
			/// </summary>
			[DefaultValue(ResizeHandle.All)]
			public virtual ResizeHandle ResizeHandles 
			{ 
				get
				{
					return this.resizeHandles;
				}
				set
				{
					this.resizeHandles = value;
				}
			}

			private bool toFrontOnShow = true;

			/// <summary>
			/// True to automatically call toFront when the show method is called on an already visible, floating component (default is true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ToFrontOnShow 
			{ 
				get
				{
					return this.toFrontOnShow;
				}
				set
				{
					this.toFrontOnShow = value;
				}
			}

        }
    }
}