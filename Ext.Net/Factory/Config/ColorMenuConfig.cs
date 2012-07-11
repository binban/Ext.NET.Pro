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
    public partial class ColorMenu
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ColorMenu(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ColorMenu.Config Conversion to ColorMenu
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ColorMenu(ColorMenu.Config config)
        {
            return new ColorMenu(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : MenuBase.Config 
        { 
			/*  Implicit ColorMenu.Config Conversion to ColorMenu.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ColorMenu.Builder(ColorMenu.Config config)
			{
				return new ColorMenu.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ColorPalette palette = null;

			/// <summary>
			/// The ColorPalette object
			/// </summary>
			public ColorPalette Palette
			{
				get
				{
					if (this.palette == null)
					{
						this.palette = new ColorPalette();
					}
			
					return this.palette;
				}
			}
			        
			private ColorMenuListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ColorMenuListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ColorMenuListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ColorMenuDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ColorMenuDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ColorMenuDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}