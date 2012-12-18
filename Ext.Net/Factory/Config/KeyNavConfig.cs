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
    public partial class KeyNav
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public KeyNav(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit KeyNav.Config Conversion to KeyNav
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator KeyNav(KeyNav.Config config)
        {
            return new KeyNav(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit KeyNav.Config Conversion to KeyNav.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator KeyNav.Builder(KeyNav.Config config)
			{
				return new KeyNav.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool componentEvent = false;

			/// <summary>
			/// True to listen component event instead underlying element
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ComponentEvent 
			{ 
				get
				{
					return this.componentEvent;
				}
				set
				{
					this.componentEvent = value;
				}
			}

			private EventAction defaultEventAction = EventAction.StopEvent;

			/// <summary>
			/// The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation.
			/// </summary>
			[DefaultValue(EventAction.StopEvent)]
			public virtual EventAction DefaultEventAction 
			{ 
				get
				{
					return this.defaultEventAction;
				}
				set
				{
					this.defaultEventAction = value;
				}
			}

			private bool disabled = false;

			/// <summary>
			/// True to disable this KeyNav instance (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Disabled 
			{ 
				get
				{
					return this.disabled;
				}
				set
				{
					this.disabled = value;
				}
			}

			private string eventName = "";

			/// <summary>
			/// The event to listen for to pick up key events. Defaults to: \"keypress\"
			/// </summary>
			[DefaultValue("")]
			public virtual string EventName 
			{ 
				get
				{
					return this.eventName;
				}
				set
				{
					this.eventName = value;
				}
			}

			private bool forceKeyDown = false;

			/// <summary>
			/// Handle the keydown event instead of keypress. KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceKeyDown 
			{ 
				get
				{
					return this.forceKeyDown;
				}
				set
				{
					this.forceKeyDown = value;
				}
			}

			private string componentElement = "";

			/// <summary>
			/// Element name of target component (can be used if KeyNav belongs to a component)
			/// </summary>
			[DefaultValue("")]
			public virtual string ComponentElement 
			{ 
				get
				{
					return this.componentElement;
				}
				set
				{
					this.componentElement = value;
				}
			}

			private bool ignoreInputFields = false;

			/// <summary>
			/// Configure this as true if there are any input fields within the target, and this KeyNav should not process events from input fields, (&lt;input>, &lt;textarea> and elements withcontentEditable=\"true\"). Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreInputFields 
			{ 
				get
				{
					return this.ignoreInputFields;
				}
				set
				{
					this.ignoreInputFields = value;
				}
			}
        
			private JFunction processEvent = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction ProcessEvent
			{
				get
				{
					if (this.processEvent == null)
					{
						this.processEvent = new JFunction();
					}
			
					return this.processEvent;
				}
			}
			
			private string processEventScope = "";

			/// <summary>
			/// The scope (this context) in which the processEvent method is executed.
			/// </summary>
			[DefaultValue("")]
			public virtual string ProcessEventScope 
			{ 
				get
				{
					return this.processEventScope;
				}
				set
				{
					this.processEventScope = value;
				}
			}

			private string target = "";

			/// <summary>
			/// The element to bind to
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
        
			private JFunction space = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Space
			{
				get
				{
					if (this.space == null)
					{
						this.space = new JFunction();
					}
			
					return this.space;
				}
			}
			        
			private JFunction left = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Left
			{
				get
				{
					if (this.left == null)
					{
						this.left = new JFunction();
					}
			
					return this.left;
				}
			}
			        
			private JFunction right = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Right
			{
				get
				{
					if (this.right == null)
					{
						this.right = new JFunction();
					}
			
					return this.right;
				}
			}
			        
			private JFunction up = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Up
			{
				get
				{
					if (this.up == null)
					{
						this.up = new JFunction();
					}
			
					return this.up;
				}
			}
			        
			private JFunction down = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Down
			{
				get
				{
					if (this.down == null)
					{
						this.down = new JFunction();
					}
			
					return this.down;
				}
			}
			        
			private JFunction pageUp = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction PageUp
			{
				get
				{
					if (this.pageUp == null)
					{
						this.pageUp = new JFunction();
					}
			
					return this.pageUp;
				}
			}
			        
			private JFunction pageDown = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction PageDown
			{
				get
				{
					if (this.pageDown == null)
					{
						this.pageDown = new JFunction();
					}
			
					return this.pageDown;
				}
			}
			        
			private JFunction del = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Del
			{
				get
				{
					if (this.del == null)
					{
						this.del = new JFunction();
					}
			
					return this.del;
				}
			}
			        
			private JFunction home = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Home
			{
				get
				{
					if (this.home == null)
					{
						this.home = new JFunction();
					}
			
					return this.home;
				}
			}
			        
			private JFunction end = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction End
			{
				get
				{
					if (this.end == null)
					{
						this.end = new JFunction();
					}
			
					return this.end;
				}
			}
			        
			private JFunction enter = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Enter
			{
				get
				{
					if (this.enter == null)
					{
						this.enter = new JFunction();
					}
			
					return this.enter;
				}
			}
			        
			private JFunction esc = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Esc
			{
				get
				{
					if (this.esc == null)
					{
						this.esc = new JFunction();
					}
			
					return this.esc;
				}
			}
			        
			private JFunction tab = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Tab
			{
				get
				{
					if (this.tab == null)
					{
						this.tab = new JFunction();
					}
			
					return this.tab;
				}
			}
			
        }
    }
}