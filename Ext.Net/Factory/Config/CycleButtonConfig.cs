/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
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
    /// <summary>
    /// 
    /// </summary>
    public partial class CycleButton
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CycleButton(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CycleButton.Config Conversion to CycleButton
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CycleButton(CycleButton.Config config)
        {
            return new CycleButton(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : SplitButtonBase.Config 
        { 
			/*  Implicit CycleButton.Config Conversion to CycleButton.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CycleButton.Builder(CycleButton.Config config)
			{
				return new CycleButton.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string changeHandler = "";

			/// <summary>
			/// A callback function that will be invoked each time the active menu items in the button's menu has changed. If this callback is not supplied, the SplitButton will instead fire the change event on active items change. The changeHandler function will be called with the following argument list: (SplitButton this, Ext.menu.CheckItem items).
			/// </summary>
			[DefaultValue("")]
			public virtual string ChangeHandler 
			{ 
				get
				{
					return this.changeHandler;
				}
				set
				{
					this.changeHandler = value;
				}
			}

			private string forceIcon = "";

			/// <summary>
			/// A css class which sets an image to be used as the static icon for this button. This icon will always be displayed regardless of which item is selected in the dropdown list. This overrides the default behavior of changing the button's icon to match the selected item's icon on change.
			/// </summary>
			[DefaultValue("")]
			public virtual string ForceIcon 
			{ 
				get
				{
					return this.forceIcon;
				}
				set
				{
					this.forceIcon = value;
				}
			}

			private string prependText = "";

			/// <summary>
			/// A static string to prepend before the active items's text when displayed as the button's text (only applies when showText = true, defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string PrependText 
			{ 
				get
				{
					return this.prependText;
				}
				set
				{
					this.prependText = value;
				}
			}

			private bool showText = false;

			/// <summary>
			/// True to display the active item's text as the button text. The Button will show its configured text if this config is omitted (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ShowText 
			{ 
				get
				{
					return this.showText;
				}
				set
				{
					this.showText = value;
				}
			}

			private bool toggleOnClick = true;

			/// <summary>
			/// False to prevent change active item after button click (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ToggleOnClick 
			{ 
				get
				{
					return this.toggleOnClick;
				}
				set
				{
					this.toggleOnClick = value;
				}
			}
        
			private CycleButtonListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CycleButtonListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CycleButtonListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CycleButtonDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public CycleButtonDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CycleButtonDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}