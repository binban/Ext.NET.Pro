/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
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
    public partial class CommandMenu
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CommandMenu.Config Conversion to CommandMenu
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CommandMenu(CommandMenu.Config config)
        {
            return new CommandMenu(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit CommandMenu.Config Conversion to CommandMenu.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CommandMenu.Builder(CommandMenu.Config config)
			{
				return new CommandMenu.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private MenuCommandCollection items = null;

			/// <summary>
			/// 
			/// </summary>
			public MenuCommandCollection Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new MenuCommandCollection();
					}
			
					return this.items;
				}
			}
			
			private bool shared = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Shared 
			{ 
				get
				{
					return this.shared;
				}
				set
				{
					this.shared = value;
				}
			}

			private bool enableScrolling = true;

			/// <summary>
			/// Whenever a menu gets so long that the items won't fit the viewable area, it provides the user with an easy UI to scroll the menu.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableScrolling 
			{ 
				get
				{
					return this.enableScrolling;
				}
				set
				{
					this.enableScrolling = value;
				}
			}

			private int minWidth = 120;

			/// <summary>
			/// The minimum width of the menu in pixels (defaults to 120).
			/// </summary>
			[DefaultValue(120)]
			public virtual int MinWidth 
			{ 
				get
				{
					return this.minWidth;
				}
				set
				{
					this.minWidth = value;
				}
			}

			private int maxHeight = 0;

			/// <summary>
			/// The maximum height of the menu. Only applies when enableScrolling is set to True (defaults to null).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MaxHeight 
			{ 
				get
				{
					return this.maxHeight;
				}
				set
				{
					this.maxHeight = value;
				}
			}

			private int scrollIncrement = 24;

			/// <summary>
			/// The amount to scroll the menu. Only applies when enableScrolling is set to True (defaults to 24).
			/// </summary>
			[DefaultValue(24)]
			public virtual int ScrollIncrement 
			{ 
				get
				{
					return this.scrollIncrement;
				}
				set
				{
					this.scrollIncrement = value;
				}
			}

			private bool showSeparator = true;

			/// <summary>
			/// True to show the icon separator. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowSeparator 
			{ 
				get
				{
					return this.showSeparator;
				}
				set
				{
					this.showSeparator = value;
				}
			}

			private ShadowMode shadow = ShadowMode.Sides;

			/// <summary>
			/// True or \"sides\" for the default effect, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"sides\")
			/// </summary>
			[DefaultValue(ShadowMode.Sides)]
			public virtual ShadowMode Shadow 
			{ 
				get
				{
					return this.shadow;
				}
				set
				{
					this.shadow = value;
				}
			}

			private string subMenuAlign = "";

			/// <summary>
			/// The Ext.Element.alignTo anchor position value to use for submenus of this menu (defaults to \"tl-tr?\")
			/// </summary>
			[DefaultValue("")]
			public virtual string SubMenuAlign 
			{ 
				get
				{
					return this.subMenuAlign;
				}
				set
				{
					this.subMenuAlign = value;
				}
			}

			private bool ignoreParentClicks = false;

			/// <summary>
			/// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreParentClicks 
			{ 
				get
				{
					return this.ignoreParentClicks;
				}
				set
				{
					this.ignoreParentClicks = value;
				}
			}

        }
    }
}