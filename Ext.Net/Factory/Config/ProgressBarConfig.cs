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
    public partial class ProgressBar
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ProgressBar.Config Conversion to ProgressBar
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ProgressBar(ProgressBar.Config config)
        {
            return new ProgressBar(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit ProgressBar.Config Conversion to ProgressBar.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ProgressBar.Builder(ProgressBar.Config config)
			{
				return new ProgressBar.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool animate = false;

			/// <summary>
			/// True to animate the progress bar during transitions
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Animate 
			{ 
				get
				{
					return this.animate;
				}
				set
				{
					this.animate = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The text shown in the progress bar (defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private string textEl = "";

			/// <summary>
			/// The element to render the progress text to (defaults to the progress bar's internal text element)
			/// </summary>
			[DefaultValue("")]
			public virtual string TextEl 
			{ 
				get
				{
					return this.textEl;
				}
				set
				{
					this.textEl = value;
				}
			}

			private float value = 0;

			/// <summary>
			/// A floating point value between 0 and 1 (e.g., .5, defaults to 0)
			/// </summary>
			[DefaultValue(0)]
			public virtual float Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}
        
			private ProgressBarListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ProgressBarListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ProgressBarListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ProgressBarDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ProgressBarDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ProgressBarDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}