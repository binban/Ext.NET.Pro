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
    public abstract partial class AbstractContainer
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int anchorHeight = 0;

			/// <summary>
			/// The height of this Anchor in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(0)]
			public virtual int AnchorHeight 
			{ 
				get
				{
					return this.anchorHeight;
				}
				set
				{
					this.anchorHeight = value;
				}
			}

			private int anchorWidth = 0;

			/// <summary>
			/// The width of this Anchor in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(0)]
			public virtual int AnchorWidth 
			{ 
				get
				{
					return this.anchorWidth;
				}
				set
				{
					this.anchorWidth = value;
				}
			}

			private string activeItem = "";

			/// <summary>
			/// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveItem 
			{ 
				get
				{
					return this.activeItem;
				}
				set
				{
					this.activeItem = value;
				}
			}

			private int activeIndex = -1;

			/// <summary>
			/// A string component id or the numeric index of the component that should be initially activated within the container's layout on render. For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection). activeItem only applies to layout styles that can display items one at a time (like Ext.layout.container.Card and Ext.layout.container.Fit)
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveIndex 
			{ 
				get
				{
					return this.activeIndex;
				}
				set
				{
					this.activeIndex = value;
				}
			}

			private bool autoDestroy = true;

			/// <summary>
			/// If true the container will automatically destroy any contained component that is removed from it, else destruction must be handled manually. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoDestroy 
			{ 
				get
				{
					return this.autoDestroy;
				}
				set
				{
					this.autoDestroy = value;
				}
			}

			private bool autoDoLayout = false;

			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDoLayout 
			{ 
				get
				{
					return this.autoDoLayout;
				}
				set
				{
					this.autoDoLayout = value;
				}
			}

			private string[] bubbleEvents = null;

			/// <summary>
			/// An array of events that, when fired, should be bubbled to any parent container. See Ext.util.Observable-enableBubble. Defaults to ['add', 'remove'].
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] BubbleEvents 
			{ 
				get
				{
					return this.bubbleEvents;
				}
				set
				{
					this.bubbleEvents = value;
				}
			}

			private string defaultType = "panel";

			/// <summary>
			/// The default xtype of child Components to create in this Container when a child item is specified as a raw configuration object, rather than as an instantiated AbstractComponent. Defaults to 'panel'.
			/// </summary>
			[DefaultValue("panel")]
			public virtual string DefaultType 
			{ 
				get
				{
					return this.defaultType;
				}
				set
				{
					this.defaultType = value;
				}
			}

			private string defaultButton = "";

			/// <summary>
			/// A button is used after Enter is pressed. Can be ID, index or selector
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultButton 
			{ 
				get
				{
					return this.defaultButton;
				}
				set
				{
					this.defaultButton = value;
				}
			}
        
			private ParameterCollection defaults = null;

			/// <summary>
			/// This option is a means of applying default settings to all added items whether added through the items config or via the add or insert methods.
			/// </summary>
			public ParameterCollection Defaults
			{
				get
				{
					if (this.defaults == null)
					{
						this.defaults = new ParameterCollection();
					}
			
					return this.defaults;
				}
			}
			
			private bool detachOnRemove = true;

			/// <summary>
			/// True to move any component to the detachedBody when the component is removed from this container. This option is only applicable when the component is not destroyed while being removed, see autoDestroy and remove. If this option is set to false, the DOM of the component will remain in the current place until it is explicitly moved. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DetachOnRemove 
			{ 
				get
				{
					return this.detachOnRemove;
				}
				set
				{
					this.detachOnRemove = value;
				}
			}

			private bool suspendLayout = false;

			/// <summary>
			/// If true, suspend calls to doLayout.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SuspendLayout 
			{ 
				get
				{
					return this.suspendLayout;
				}
				set
				{
					this.suspendLayout = value;
				}
			}
        
			private MenuCollection tabMenu = null;

			/// <summary>
			/// Tab's menu
			/// </summary>
			public MenuCollection TabMenu
			{
				get
				{
					if (this.tabMenu == null)
					{
						this.tabMenu = new MenuCollection();
					}
			
					return this.tabMenu;
				}
			}
			
			private bool tabMenuHidden = false;

			/// <summary>
			/// Defaults to false. True to hide tab's menu.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TabMenuHidden 
			{ 
				get
				{
					return this.tabMenuHidden;
				}
				set
				{
					this.tabMenuHidden = value;
				}
			}

			private string layout = "";

			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
			[DefaultValue("")]
			public virtual string Layout 
			{ 
				get
				{
					return this.layout;
				}
				set
				{
					this.layout = value;
				}
			}
        
			private LayoutConfigCollection layoutConfig = null;

			/// <summary>
			/// This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)
			/// </summary>
			public LayoutConfigCollection LayoutConfig
			{
				get
				{
					if (this.layoutConfig == null)
					{
						this.layoutConfig = new LayoutConfigCollection();
					}
			
					return this.layoutConfig;
				}
			}
			
        }
    }
}