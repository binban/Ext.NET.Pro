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
    public partial class CommandMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<CommandMenu, CommandMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandMenu.Config config) : base(new CommandMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandMenu component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Items(MenuCommandCollection items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CommandMenu.Builder Shared(bool shared)
            {
                this.ToComponent().Shared = shared;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// Whenever a menu gets so long that the items won't fit the viewable area, it provides the user with an easy UI to scroll the menu.
			/// </summary>
            public virtual CommandMenu.Builder EnableScrolling(bool enableScrolling)
            {
                this.ToComponent().EnableScrolling = enableScrolling;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// The minimum width of the menu in pixels (defaults to 120).
			/// </summary>
            public virtual CommandMenu.Builder MinWidth(int minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// The maximum height of the menu. Only applies when enableScrolling is set to True (defaults to null).
			/// </summary>
            public virtual CommandMenu.Builder MaxHeight(int maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// The amount to scroll the menu. Only applies when enableScrolling is set to True (defaults to 24).
			/// </summary>
            public virtual CommandMenu.Builder ScrollIncrement(int scrollIncrement)
            {
                this.ToComponent().ScrollIncrement = scrollIncrement;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// True to show the icon separator. (defaults to true).
			/// </summary>
            public virtual CommandMenu.Builder ShowSeparator(bool showSeparator)
            {
                this.ToComponent().ShowSeparator = showSeparator;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// True or \"sides\" for the default effect, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"sides\")
			/// </summary>
            public virtual CommandMenu.Builder Shadow(ShadowMode shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// The Ext.Element.alignTo anchor position value to use for submenus of this menu (defaults to \"tl-tr?\")
			/// </summary>
            public virtual CommandMenu.Builder SubMenuAlign(string subMenuAlign)
            {
                this.ToComponent().SubMenuAlign = subMenuAlign;
                return this as CommandMenu.Builder;
            }
             
 			/// <summary>
			/// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).
			/// </summary>
            public virtual CommandMenu.Builder IgnoreParentClicks(bool ignoreParentClicks)
            {
                this.ToComponent().IgnoreParentClicks = ignoreParentClicks;
                return this as CommandMenu.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandMenu(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder CommandMenu()
        {
            return this.CommandMenu(new CommandMenu());
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder CommandMenu(CommandMenu component)
        {
            return new CommandMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandMenu.Builder CommandMenu(CommandMenu.Config config)
        {
            return new CommandMenu.Builder(new CommandMenu(config));
        }
    }
}