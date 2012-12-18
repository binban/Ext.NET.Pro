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
    public abstract partial class AbstractPanel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractContainer.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private Button tabConfig = null;

			/// <summary>
			/// A standard Ext.button.Button config object.
			/// </summary>
			public Button TabConfig
			{
				get
				{
					if (this.tabConfig == null)
					{
						this.tabConfig = new Button();
					}
			
					return this.tabConfig;
				}
			}
			
			private string bodyCls = "";

			/// <summary>
			/// Additional css class selector to be applied to the body element
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyCls 
			{ 
				get
				{
					return this.bodyCls;
				}
				set
				{
					this.bodyCls = value;
				}
			}

			private string bodyStyle = "";

			/// <summary>
			/// Custom CSS styles to be applied to the body element.
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyStyle 
			{ 
				get
				{
					return this.bodyStyle;
				}
				set
				{
					this.bodyStyle = value;
				}
			}

			private bool animCollapse = true;

			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnimCollapse 
			{ 
				get
				{
					return this.animCollapse;
				}
				set
				{
					this.animCollapse = value;
				}
			}

			private int animCollapseDuration = 0;

			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.fx.Anim class is available, otherwise false). May also be specified as the animation duration in milliseconds
			/// </summary>
			[DefaultValue(0)]
			public virtual int AnimCollapseDuration 
			{ 
				get
				{
					return this.animCollapseDuration;
				}
				set
				{
					this.animCollapseDuration = value;
				}
			}

			private int? bodyBorder = null;

			/// <summary>
			/// A shortcut to add or remove the border on the body of a panel. This only applies to a panel which has the frame configuration set to true. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? BodyBorder 
			{ 
				get
				{
					return this.bodyBorder;
				}
				set
				{
					this.bodyBorder = value;
				}
			}

			private int? bodyPadding = null;

			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual int? BodyPadding 
			{ 
				get
				{
					return this.bodyPadding;
				}
				set
				{
					this.bodyPadding = value;
				}
			}

			private string bodyPaddingSummary = null;

			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. Defaults to undefined.
			/// </summary>
			[DefaultValue(null)]
			public virtual string BodyPaddingSummary 
			{ 
				get
				{
					return this.bodyPaddingSummary;
				}
				set
				{
					this.bodyPaddingSummary = value;
				}
			}
        
			private ToolbarCollection bottomBar = null;

			/// <summary>
			/// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
			/// </summary>
			public ToolbarCollection BottomBar
			{
				get
				{
					if (this.bottomBar == null)
					{
						this.bottomBar = new ToolbarCollection();
					}
			
					return this.bottomBar;
				}
			}
			
			private Alignment buttonAlign = Alignment.Right;

			/// <summary>
			/// The alignment of any buttons added to this panel. Valid values are 'right', 'left' and 'center' (defaults to 'right' for buttons/fbar, 'left' for other toolbar types).
			/// </summary>
			[DefaultValue(Alignment.Right)]
			public virtual Alignment ButtonAlign 
			{ 
				get
				{
					return this.buttonAlign;
				}
				set
				{
					this.buttonAlign = value;
				}
			}

			private bool closable = false;

			/// <summary>
			/// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (defaults to false).
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

			private CloseAction closeAction = CloseAction.Destroy;

			/// <summary>
			/// The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.
			/// </summary>
			[DefaultValue(CloseAction.Destroy)]
			public virtual CloseAction CloseAction 
			{ 
				get
				{
					return this.closeAction;
				}
				set
				{
					this.closeAction = value;
				}
			}

			private Direction collapseDirection = Direction.None;

			/// <summary>
			/// The direction to collapse the Panel when the toggle button is clicked.
			/// </summary>
			[DefaultValue(Direction.None)]
			public virtual Direction CollapseDirection 
			{ 
				get
				{
					return this.collapseDirection;
				}
				set
				{
					this.collapseDirection = value;
				}
			}

			private bool collapseFirst = true;

			/// <summary>
			/// true to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CollapseFirst 
			{ 
				get
				{
					return this.collapseFirst;
				}
				set
				{
					this.collapseFirst = value;
				}
			}

			private CollapseMode collapseMode = CollapseMode.Default;

			/// <summary>
			/// When not a direct child item of a border layout, then the Panel's header remains visible, and the body is collapsed to zero dimensions. If the Panel has no header, then a new header (orientated correctly depending on the collapseDirection) will be inserted to show a the title and a re-expand tool.
			/// </summary>
			[DefaultValue(CollapseMode.Default)]
			public virtual CollapseMode CollapseMode 
			{ 
				get
				{
					return this.collapseMode;
				}
				set
				{
					this.collapseMode = value;
				}
			}

			private bool collapsed = false;

			/// <summary>
			/// True to render the panel collapsed, false to render it expanded (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsed 
			{ 
				get
				{
					return this.collapsed;
				}
				set
				{
					this.collapsed = value;
				}
			}

			private string collapsedCls = "";

			/// <summary>
			/// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-collapsed').
			/// </summary>
			[DefaultValue("")]
			public virtual string CollapsedCls 
			{ 
				get
				{
					return this.collapsedCls;
				}
				set
				{
					this.collapsedCls = value;
				}
			}

			private bool collapsible = false;

			/// <summary>
			/// True to make the panel collapsible and have an expand/collapse toggle Tool added into the header tool button area. False to keep the panel sized either statically, or by an owning layout manager, with no toggle Tool (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsible 
			{ 
				get
				{
					return this.collapsible;
				}
				set
				{
					this.collapsible = value;
				}
			}
        
			private ItemsCollection<AbstractComponent> dockedItems = null;

			/// <summary>
			/// A component or series of components to be added as docked items to this panel. The docked items can be docked to either the top, right, left or bottom of a panel.
			/// </summary>
			public ItemsCollection<AbstractComponent> DockedItems
			{
				get
				{
					if (this.dockedItems == null)
					{
						this.dockedItems = new ItemsCollection<AbstractComponent>();
					}
			
					return this.dockedItems;
				}
			}
			        
			private ToolbarCollection footerBar = null;

			/// <summary>
			/// Convenience method used for adding items to the bottom right of the panel.
			/// </summary>
			public ToolbarCollection FooterBar
			{
				get
				{
					if (this.footerBar == null)
					{
						this.footerBar = new ToolbarCollection();
					}
			
					return this.footerBar;
				}
			}
			        
			private ToolbarCollection leftBar = null;

			/// <summary>
			/// Convenience method. Short for 'Left Bar' (left-docked, vertical toolbar).
			/// </summary>
			public ToolbarCollection LeftBar
			{
				get
				{
					if (this.leftBar == null)
					{
						this.leftBar = new ToolbarCollection();
					}
			
					return this.leftBar;
				}
			}
			        
			private ToolbarCollection rightBar = null;

			/// <summary>
			/// Convenience method. Short for 'Right Bar' (right-docked, vertical toolbar).
			/// </summary>
			public ToolbarCollection RightBar
			{
				get
				{
					if (this.rightBar == null)
					{
						this.rightBar = new ToolbarCollection();
					}
			
					return this.rightBar;
				}
			}
			
			private bool floatable = true;

			/// <summary>
			/// True to allow clicking a collapsed Panel's placeHolder to display the Panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Floatable 
			{ 
				get
				{
					return this.floatable;
				}
				set
				{
					this.floatable = value;
				}
			}

			private bool frameHeader = true;

			/// <summary>
			/// True to apply a frame to the panel panels header (if 'frame' is true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool FrameHeader 
			{ 
				get
				{
					return this.frameHeader;
				}
				set
				{
					this.frameHeader = value;
				}
			}

			private bool header = true;

			/// <summary>
			/// Pass as false to prevent a Header from being created and shown.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private PanelHeader headerConfig = null;

			/// <summary>
			/// Pass as a config object (optionally containing an xtype) to custom-configure this Panel's header.
			/// </summary>
			[DefaultValue(null)]
			public virtual PanelHeader HeaderConfig 
			{ 
				get
				{
					return this.headerConfig;
				}
				set
				{
					this.headerConfig = value;
				}
			}

			private Direction headerPosition = Direction.Top;

			/// <summary>
			/// Specify as 'top', 'bottom', 'left' or 'right'. Defaults to 'top'.
			/// </summary>
			[DefaultValue(Direction.Top)]
			public virtual Direction HeaderPosition 
			{ 
				get
				{
					return this.headerPosition;
				}
				set
				{
					this.headerPosition = value;
				}
			}

			private string headerTextCls = "";

			/// <summary>
			/// A CSS class to add to the panel's header text.
			/// </summary>
			[DefaultValue("")]
			public virtual string HeaderTextCls 
			{ 
				get
				{
					return this.headerTextCls;
				}
				set
				{
					this.headerTextCls = value;
				}
			}

			private bool hideCollapseTool = false;

			/// <summary>
			/// True to hide the expand/collapse toggle button when collapsible == true, false to display it (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideCollapseTool 
			{ 
				get
				{
					return this.hideCollapseTool;
				}
				set
				{
					this.hideCollapseTool = value;
				}
			}

			private bool manageHeight = true;

			/// <summary>
			/// When true, the dock component layout writes height information to the panel's DOM elements based on its shrink wrap height calculation. This ensures that the browser respects the calculated height. When false, the dock component layout will not write heights on the panel or its body element. In some simple layout cases, not writing the heights to the DOM may be desired because this allows the browser to respond to direct DOM manipulations (like animations).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ManageHeight 
			{ 
				get
				{
					return this.manageHeight;
				}
				set
				{
					this.manageHeight = value;
				}
			}

			private int minButtonWidth = 75;

			/// <summary>
			/// Minimum width of all footer toolbar buttons in pixels (defaults to undefined). If set, this will be used as the default value for the Ext.button.Button-minWidth config of each Button added to the footer toolbar. Will be ignored for buttons that have this value configured some other way, e.g. in their own config object or via the defaults of their parent container
			/// </summary>
			[DefaultValue(75)]
			public virtual int MinButtonWidth 
			{ 
				get
				{
					return this.minButtonWidth;
				}
				set
				{
					this.minButtonWidth = value;
				}
			}

			private bool? overlapHeader = null;

			/// <summary>
			/// True to overlap the header in a panel over the framing of the panel itself. This is needed when frame:true (and is done automatically for you). Otherwise it is undefined. If you manually add rounded corners to a panel header which does not have frame:true, this will need to be set to true.
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? OverlapHeader 
			{ 
				get
				{
					return this.overlapHeader;
				}
				set
				{
					this.overlapHeader = value;
				}
			}
        
			private ItemsCollection<AbstractComponent> placeHolder = null;

			/// <summary>
			/// A Component (or config object for a Component) to show in place of this Panel when this Panel is collapsed by a border layout. Defaults to a generated Header containing a Tool to re-expand the Panel.
			/// </summary>
			public ItemsCollection<AbstractComponent> PlaceHolder
			{
				get
				{
					if (this.placeHolder == null)
					{
						this.placeHolder = new ItemsCollection<AbstractComponent>();
					}
			
					return this.placeHolder;
				}
			}
			        
			private ToolbarCollection topBar = null;

			/// <summary>
			/// Convenience method used for adding items to the top of the panel.
			/// </summary>
			public ToolbarCollection TopBar
			{
				get
				{
					if (this.topBar == null)
					{
						this.topBar = new ToolbarCollection();
					}
			
					return this.topBar;
				}
			}
			
			private string title = "";

			/// <summary>
			/// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
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

			private TitleAlign titleAlign = TitleAlign.Default;

			/// <summary>
			/// May be \"left\", \"right\" or \"center\". The alignment of the title text within the available space between the icon and the tools. Defaults to: \"left\"
			/// </summary>
			[DefaultValue(TitleAlign.Default)]
			public virtual TitleAlign TitleAlign 
			{ 
				get
				{
					return this.titleAlign;
				}
				set
				{
					this.titleAlign = value;
				}
			}

			private bool titleCollapse = false;

			/// <summary>
			/// true to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false) to allow it only by clicking to tool button (defaults to false)).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TitleCollapse 
			{ 
				get
				{
					return this.titleCollapse;
				}
				set
				{
					this.titleCollapse = value;
				}
			}

			private DragSource draggablePanelConfig = null;

			/// <summary>
			/// Drag config object.
			/// </summary>
			[DefaultValue(null)]
			public virtual DragSource DraggablePanelConfig 
			{ 
				get
				{
					return this.draggablePanelConfig;
				}
				set
				{
					this.draggablePanelConfig = value;
				}
			}

			private string defaultDockWeights = null;

			/// <summary>
			/// This object holds the default weights applied to dockedItems that have no weight. These start with a weight of 1, to allow negative weights to insert before top items and are odd numbers so that even weights can be used to get between different dock orders. Defaults to: {top: 1, left: 3, right: 5, bottom: 7}. A string must be the four numbers separated by space symbols. The first number is a top dock weight, the second one - left, the third one - right, the fourth one - bottom.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DefaultDockWeights 
			{ 
				get
				{
					return this.defaultDockWeights;
				}
				set
				{
					this.defaultDockWeights = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
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
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
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

			private string iconPath = "";

			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string IconPath 
			{ 
				get
				{
					return this.iconPath;
				}
				set
				{
					this.iconPath = value;
				}
			}
        
			private ToolsCollection tools = null;

			/// <summary>
			/// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
			/// </summary>
			public ToolsCollection Tools
			{
				get
				{
					if (this.tools == null)
					{
						this.tools = new ToolsCollection();
					}
			
					return this.tools;
				}
			}
			
			private bool unstyled = false;

			/// <summary>
			/// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Unstyled 
			{ 
				get
				{
					return this.unstyled;
				}
				set
				{
					this.unstyled = value;
				}
			}

        }
    }
}