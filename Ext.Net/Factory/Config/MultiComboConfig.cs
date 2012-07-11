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
    public partial class MultiCombo
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public MultiCombo(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit MultiCombo.Config Conversion to MultiCombo
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator MultiCombo(MultiCombo.Config config)
        {
            return new MultiCombo(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComboBoxBaseMulti<ListItem>.Config 
        { 
			/*  Implicit MultiCombo.Config Conversion to MultiCombo.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator MultiCombo.Builder(MultiCombo.Config config)
			{
				return new MultiCombo.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool editable = false;

			/// <summary>
			/// False to prevent the user from typing text directly into the field, just like a traditional select (defaults to true).
			/// </summary>
			[DefaultValue(false)]
			public override bool Editable 
			{ 
				get
				{
					return this.editable;
				}
				set
				{
					this.editable = value;
				}
			}
        
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