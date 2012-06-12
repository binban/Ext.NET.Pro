/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
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
    public partial class Viewport
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Viewport(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Viewport.Config Conversion to Viewport
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Viewport(Viewport.Config config)
        {
            return new Viewport(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ViewportBase.Config 
        { 
			/*  Implicit Viewport.Config Conversion to Viewport.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Viewport.Builder(Viewport.Config config)
			{
				return new Viewport.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ContainerListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ContainerListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ContainerListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ContainerDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ContainerDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ContainerDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}