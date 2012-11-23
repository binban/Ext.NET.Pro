/********
 * @version   : 2.1.0 - Ext.NET Pro License
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
    /// <summary>
    /// 
    /// </summary>
    public partial class ClickRepeater
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ClickRepeater(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ClickRepeater.Config Conversion to ClickRepeater
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ClickRepeater(ClickRepeater.Config config)
        {
            return new ClickRepeater(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit ClickRepeater.Config Conversion to ClickRepeater.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ClickRepeater.Builder(ClickRepeater.Config config)
			{
				return new ClickRepeater.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool accelerate = false;

			/// <summary>
			/// True if autorepeating should start slowly and accelerate. Interval and Delay are ignored.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Accelerate 
			{ 
				get
				{
					return this.accelerate;
				}
				set
				{
					this.accelerate = value;
				}
			}

			private int delay = 250;

			/// <summary>
			/// The initial delay before the repeating event begins firing. Similar to an autorepeat key delay.
			/// </summary>
			[DefaultValue(250)]
			public virtual int Delay 
			{ 
				get
				{
					return this.delay;
				}
				set
				{
					this.delay = value;
				}
			}

			private string target = "";

			/// <summary>
			/// The element to act as a button.
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

			private int interval = 20;

			/// <summary>
			/// The interval between firings of the \"click\" event. Default 20 ms.
			/// </summary>
			[DefaultValue(20)]
			public virtual int Interval 
			{ 
				get
				{
					return this.interval;
				}
				set
				{
					this.interval = value;
				}
			}

			private string pressedCls = "";

			/// <summary>
			/// A CSS class name to be applied to the element while pressed.
			/// </summary>
			[DefaultValue("")]
			public virtual string PressedCls 
			{ 
				get
				{
					return this.pressedCls;
				}
				set
				{
					this.pressedCls = value;
				}
			}

			private bool preventDefault = false;

			/// <summary>
			/// True to prevent the default click event.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventDefault 
			{ 
				get
				{
					return this.preventDefault;
				}
				set
				{
					this.preventDefault = value;
				}
			}

			private bool stopDefault = false;

			/// <summary>
			/// True to stop the default click event
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StopDefault 
			{ 
				get
				{
					return this.stopDefault;
				}
				set
				{
					this.stopDefault = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// A function called when the traget is clicked (can be used instead of click event).
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private bool ignoreLeftButton = false;

			/// <summary>
			/// True to ignore the left button
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreLeftButton 
			{ 
				get
				{
					return this.ignoreLeftButton;
				}
				set
				{
					this.ignoreLeftButton = value;
				}
			}

			private bool ignoreRightButton = false;

			/// <summary>
			/// True to ignore the right button
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreRightButton 
			{ 
				get
				{
					return this.ignoreRightButton;
				}
				set
				{
					this.ignoreRightButton = value;
				}
			}

			private bool ignoreMiddleButton = false;

			/// <summary>
			/// True to ignore the middle button
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreMiddleButton 
			{ 
				get
				{
					return this.ignoreMiddleButton;
				}
				set
				{
					this.ignoreMiddleButton = value;
				}
			}
        
			private ClickRepeaterListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ClickRepeaterListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ClickRepeaterListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ClickRepeaterDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ClickRepeaterDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ClickRepeaterDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}