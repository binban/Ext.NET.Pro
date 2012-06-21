/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    public partial class Tool
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Tool(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Tool.Config Conversion to Tool
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Tool(Tool.Config config)
        {
            return new Tool(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit Tool.Config Conversion to Tool.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Tool.Builder(Tool.Config config)
			{
				return new Tool.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool stopEvent = true;

			/// <summary>
			/// Specify as false to allow click event to propagate. Default to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool StopEvent 
			{ 
				get
				{
					return this.stopEvent;
				}
				set
				{
					this.stopEvent = value;
				}
			}

			private string toolTip = "";

			/// <summary>
			/// A tip string.
			/// </summary>
			[DefaultValue("")]
			public virtual string ToolTip 
			{ 
				get
				{
					return this.toolTip;
				}
				set
				{
					this.toolTip = value;
				}
			}
        
			private QTipCfg tooltipConfig = null;

			/// <summary>
			/// A tip string.
			/// </summary>
			public QTipCfg TooltipConfig
			{
				get
				{
					if (this.tooltipConfig == null)
					{
						this.tooltipConfig = new QTipCfg();
					}
			
					return this.tooltipConfig;
				}
			}
			
			private ToolTipType toolTipType = ToolTipType.Qtip;

			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute. Defaults to: \"qtip\"
			/// </summary>
			[DefaultValue(ToolTipType.Qtip)]
			public virtual ToolTipType ToolTipType 
			{ 
				get
				{
					return this.toolTipType;
				}
				set
				{
					this.toolTipType = value;
				}
			}
        
			private ToolListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ToolListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ToolListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ToolDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ToolDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ToolDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}