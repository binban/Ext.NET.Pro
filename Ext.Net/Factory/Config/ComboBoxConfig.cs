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
    public partial class ComboBox
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ComboBox(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ComboBox.Config Conversion to ComboBox
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ComboBox(ComboBox.Config config)
        {
            return new ComboBox(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComboBoxBaseSingle<ListItem>.Config 
        { 
			/*  Implicit ComboBox.Config Conversion to ComboBox.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ComboBox.Builder(ComboBox.Config config)
			{
				return new ComboBox.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ComboBoxListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ComboBoxListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ComboBoxListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ComboBoxDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ComboBoxDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ComboBoxDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}