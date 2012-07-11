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
    public partial class TabStripItem
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TabStripItem(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TabStripItem.Config Conversion to TabStripItem
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TabStripItem(TabStripItem.Config config)
        {
            return new TabStripItem(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit TabStripItem.Config Conversion to TabStripItem.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TabStripItem.Builder(TabStripItem.Config config)
			{
				return new TabStripItem.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string itemID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ItemID 
			{ 
				get
				{
					return this.itemID;
				}
				set
				{
					this.itemID = value;
				}
			}

			private string actionItemID = "";

			/// <summary>
			/// Managed container id. It will be shown when tab is activated
			/// </summary>
			[DefaultValue("")]
			public virtual string ActionItemID 
			{ 
				get
				{
					return this.actionItemID;
				}
				set
				{
					this.actionItemID = value;
				}
			}

			private Component actionItem = null;

			/// <summary>
			/// Managed container. It will be shown when tab is activated
			/// </summary>
			[DefaultValue(null)]
			public virtual Component ActionItem 
			{ 
				get
				{
					return this.actionItem;
				}
				set
				{
					this.actionItem = value;
				}
			}

			private HideMode hideMode = HideMode.Display;

			/// <summary>
			/// How the action item. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
			/// </summary>
			[DefaultValue(HideMode.Display)]
			public virtual HideMode HideMode 
			{ 
				get
				{
					return this.hideMode;
				}
				set
				{
					this.hideMode = value;
				}
			}

			private string title = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private string tabTip = "";

			/// <summary>
			/// A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.
			/// </summary>
			[DefaultValue("")]
			public virtual string TabTip 
			{ 
				get
				{
					return this.tabTip;
				}
				set
				{
					this.tabTip = value;
				}
			}

			private bool closable = false;

			/// <summary>
			/// Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Closable 
			{ 
				get
				{
					return this.closable;
				}
				set
				{
					this.closable = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}
        
			private ConfigItemCollection customConfig = null;

			/// <summary>
			/// Collection of custom js config
			/// </summary>
			public ConfigItemCollection CustomConfig
			{
				get
				{
					if (this.customConfig == null)
					{
						this.customConfig = new ConfigItemCollection();
					}
			
					return this.customConfig;
				}
			}
			
        }
    }
}