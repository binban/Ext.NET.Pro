/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    public partial class ModelStateStore
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ModelStateStore(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ModelStateStore.Config Conversion to ModelStateStore
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ModelStateStore(ModelStateStore.Config config)
        {
            return new ModelStateStore(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Store.Config 
        { 
			/*  Implicit ModelStateStore.Config Conversion to ModelStateStore.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ModelStateStore.Builder(ModelStateStore.Config config)
			{
				return new ModelStateStore.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
        }
    }
}