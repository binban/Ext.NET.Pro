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
    public abstract partial class ToolTipBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Tip.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool forceRendering = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceRendering 
			{ 
				get
				{
					return this.forceRendering;
				}
				set
				{
					this.forceRendering = value;
				}
			}

			private string anchor = null;

			/// <summary>
			/// If specified, indicates that the tip should be anchored to a particular side of the target element or mouse pointer (\"top\", \"right\", \"bottom\", or \"left\"), with an arrow pointing back at the target or mouse pointer. If constrainPosition is enabled, this will be used as a preferred value only and may be flipped as needed.
			/// </summary>
			[DefaultValue(null)]
			public override string Anchor 
			{ 
				get
				{
					return this.anchor;
				}
				set
				{
					this.anchor = value;
				}
			}

			private int anchorOffset = 0;

			/// <summary>
			/// A numeric pixel value used to offset the default position of the anchor arrow. When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset. Defaults to: 0
			/// </summary>
			[DefaultValue(0)]
			public virtual int AnchorOffset 
			{ 
				get
				{
					return this.anchorOffset;
				}
				set
				{
					this.anchorOffset = value;
				}
			}

			private bool anchorToTarget = true;

			/// <summary>
			/// True to anchor the tooltip to the target element, false to anchor it relative to the mouse coordinates. When anchorToTarget is true, use defaultAlign to control tooltip alignment to the target element. When anchorToTarget is false, use anchor instead to control alignment. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnchorToTarget 
			{ 
				get
				{
					return this.anchorToTarget;
				}
				set
				{
					this.anchorToTarget = value;
				}
			}

			private bool autoHide = true;

			/// <summary>
			/// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoHide 
			{ 
				get
				{
					return this.autoHide;
				}
				set
				{
					this.autoHide = value;
				}
			}

			private string _delegate = "";

			/// <summary>
			/// A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.
			/// </summary>
			[DefaultValue("")]
			public virtual string Delegate 
			{ 
				get
				{
					return this._delegate;
				}
				set
				{
					this._delegate = value;
				}
			}

			private int dismissDelay = 5000;

			/// <summary>
			/// Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.
			/// </summary>
			[DefaultValue(5000)]
			public virtual int DismissDelay 
			{ 
				get
				{
					return this.dismissDelay;
				}
				set
				{
					this.dismissDelay = value;
				}
			}

			private int hideDelay = 200;

			/// <summary>
			/// Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.
			/// </summary>
			[DefaultValue(200)]
			public virtual int HideDelay 
			{ 
				get
				{
					return this.hideDelay;
				}
				set
				{
					this.hideDelay = value;
				}
			}

			private int[] mouseOffset = null;

			/// <summary>
			/// An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] MouseOffset 
			{ 
				get
				{
					return this.mouseOffset;
				}
				set
				{
					this.mouseOffset = value;
				}
			}

			private int showDelay = 500;

			/// <summary>
			/// Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).
			/// </summary>
			[DefaultValue(500)]
			public virtual int ShowDelay 
			{ 
				get
				{
					return this.showDelay;
				}
				set
				{
					this.showDelay = value;
				}
			}
        
			private Control targetControl = null;

			/// <summary>
			/// 
			/// </summary>
			public Control TargetControl
			{
				get
				{
					if (this.targetControl == null)
					{
						this.targetControl = new Control();
					}
			
					return this.targetControl;
				}
			}
			
			private string target = "";

			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}

			private bool trackMouse = false;

			/// <summary>
			/// True to have the tooltip follow the mouse as it moves over the target element (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackMouse 
			{ 
				get
				{
					return this.trackMouse;
				}
				set
				{
					this.trackMouse = value;
				}
			}

        }
    }
}