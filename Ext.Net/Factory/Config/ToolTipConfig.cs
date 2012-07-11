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
    public partial class ToolTip
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ToolTip(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ToolTip.Config Conversion to ToolTip
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ToolTip(ToolTip.Config config)
        {
            return new ToolTip(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Tip.Config 
        { 
			/*  Implicit ToolTip.Config Conversion to ToolTip.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ToolTip.Builder(ToolTip.Config config)
			{
				return new ToolTip.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int anchorOffset = 0;

			/// <summary>
			/// A numeric pixel value used to offset the default position of the anchor arrow (defaults to 0). When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset.
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
			/// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
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
        
			private PanelListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public PanelListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new PanelListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private PanelDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public PanelDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new PanelDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}