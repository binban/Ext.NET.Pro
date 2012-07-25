/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class TextArea
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TextArea(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TextArea.Config Conversion to TextArea
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TextArea(TextArea.Config config)
        {
            return new TextArea(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : TextFieldBase.Config 
        { 
			/*  Implicit TextArea.Config Conversion to TextArea.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TextArea.Builder(TextArea.Config config)
			{
				return new TextArea.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int cols = 20;

			/// <summary>
			/// An initial value for the 'cols' attribute on the textarea element. This is only used if the component has no configured width and is not given a width by its container's layout. Defaults to 4.
			/// </summary>
			[DefaultValue(20)]
			public virtual int Cols 
			{ 
				get
				{
					return this.cols;
				}
				set
				{
					this.cols = value;
				}
			}

			private bool enterIsSpecial = false;

			/// <summary>
			/// True if you want the ENTER key to be classed as a special key and the specialkey event to be fired when ENTER is pressed. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnterIsSpecial 
			{ 
				get
				{
					return this.enterIsSpecial;
				}
				set
				{
					this.enterIsSpecial = value;
				}
			}

			private bool preventScrollbars = false;

			/// <summary>
			/// true to prevent scrollbars from appearing regardless of how much text is in the field. This option is only relevant when grow is true. Equivalent to setting overflow: hidden, defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventScrollbars 
			{ 
				get
				{
					return this.preventScrollbars;
				}
				set
				{
					this.preventScrollbars = value;
				}
			}

			private int rows = 4;

			/// <summary>
			/// An initial value for the 'rows' attribute on the textarea element. This is only used if the component has no configured height and is not given a height by its container's layout. Defaults to 4.
			/// </summary>
			[DefaultValue(4)]
			public virtual int Rows 
			{ 
				get
				{
					return this.rows;
				}
				set
				{
					this.rows = value;
				}
			}
        
			private TextFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public TextFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new TextFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private TextFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public TextFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new TextFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}