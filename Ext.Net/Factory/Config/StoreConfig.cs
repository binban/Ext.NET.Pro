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
    public partial class Store
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Store(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Store.Config Conversion to Store
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Store(Store.Config config)
        {
            return new Store(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StoreDataBound.Config 
        { 
			/*  Implicit Store.Config Conversion to Store.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Store.Builder(Store.Config config)
			{
				return new Store.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private StoreListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public StoreListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new StoreListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private StoreDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public StoreDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new StoreDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}