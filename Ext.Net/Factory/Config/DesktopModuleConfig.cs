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
    public partial class DesktopModule
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DesktopModule(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DesktopModule.Config Conversion to DesktopModule
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DesktopModule(DesktopModule.Config config)
        {
            return new DesktopModule(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit DesktopModule.Config Conversion to DesktopModule.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DesktopModule.Builder(DesktopModule.Config config)
			{
				return new DesktopModule.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string moduleID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ModuleID 
			{ 
				get
				{
					return this.moduleID;
				}
				set
				{
					this.moduleID = value;
				}
			}

			private string windowID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string WindowID 
			{ 
				get
				{
					return this.windowID;
				}
				set
				{
					this.windowID = value;
				}
			}

			private bool autoRun = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoRun 
			{ 
				get
				{
					return this.autoRun;
				}
				set
				{
					this.autoRun = value;
				}
			}

        }
    }
}