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
    public partial class Checkbox
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Checkbox(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Checkbox.Config Conversion to Checkbox
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Checkbox(Checkbox.Config config)
        {
            return new Checkbox(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : CheckboxBase.Config 
        { 
			/*  Implicit Checkbox.Config Conversion to Checkbox.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Checkbox.Builder(Checkbox.Config config)
			{
				return new Checkbox.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private CheckboxListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public CheckboxListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new CheckboxListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private CheckboxDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public CheckboxDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new CheckboxDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}