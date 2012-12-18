/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// This is a layout that manages multiple Panels in an expandable accordion style such that only one Panel can be expanded at any given time. Each Panel has built-in support for expanding and collapsing.
    ///
    /// Note: Only Ext.Panels and all subclasses of Ext.panel.Panel may be used in an accordion layout Container.
	/// </summary>
	[Description("")]
    public partial class AccordionLayoutConfig : VBoxLayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AccordionLayoutConfig() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "accordion";
            }
        }

        /// <summary>
        /// Only valid when multi is false and animate is false.
        /// True to swap the position of each panel as it is expanded so that it becomes the first item in the container, false to keep the panels in the rendered order.   
        /// Defaults to: false
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to swap the position of each panel as it is expanded so that it becomes the first item in the container, false to keep the panels in the rendered order.")]
        public virtual bool ActiveOnTop
        {
            get
            {
                return this.State.Get<bool>("ActiveOnTop", false);
            }
            set
            {
                this.State.Set("ActiveOnTop", value);
            }
        }

        /// <summary>
        /// True to slide the contained panels open and closed during expand/collapse using animation, false to open and close directly with no animation (defaults to true). Note: The layout performs animated collapsing and expanding, not the child Panels
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        public override bool Animate
        {
            get
            {
                return this.State.Get<bool>("Animate", true);
            }
            set
            {
                this.State.Set("Animate", value);
            }
        }

        /// <summary>
        /// If true then original header UI is used.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("If true then original header UI is used")]
        public virtual bool OriginalHeader
        {
            get
            {
                return this.State.Get<bool>("OriginalHeader", false);
            }
            set
            {
                this.State.Set("OriginalHeader", value);
            }
        }

        /// <summary>
        /// True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the contained panels' title bars, false to render it last (defaults to false).
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the contained panels' title bars, false to render it last (defaults to false).")]
        public virtual bool CollapseFirst
        {
            get
            {
                return this.State.Get<bool>("CollapseFirst", false);
            }
            set
            {
                this.State.Set("CollapseFirst", value);
            }
        }

        /// <summary>
        /// True to adjust the active item's height to fill the available space in the container, false to use the item's current height, or auto height if not explicitly set (defaults to true).
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to adjust the active item's height to fill the available space in the container, false to use the item's current height, or auto height if not explicitly set (defaults to true).")]
        public virtual bool Fill
        {
            get
            {
                return this.State.Get<bool>("Fill", true);
            }
            set
            {
                this.State.Set("Fill", value);
            }
        }

        /// <summary>
        /// True to hide the contained panels' collapse/expand toggle buttons, false to display them (defaults to false). When set to true, titleCollapse should be true also.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to hide the contained panels' collapse/expand toggle buttons, false to display them (defaults to false). When set to true, titleCollapse should be true also.")]
        public virtual bool HideCollapseTool
        {
            get
            {
                return this.State.Get<bool>("HideCollapseTool", false);
            }
            set
            {
                this.State.Set("HideCollapseTool", value);
            }
        }

        /// <summary>
        /// Defaults to false. Set to true to enable multiple accordion items to be open at once.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Defaults to false. Set to true to enable multiple accordion items to be open at once.")]
        public virtual bool Multi
        {
            get
            {
                return this.State.Get<bool>("Multi", false);
            }
            set
            {
                this.State.Set("Multi", value);
            }
        }

        /// <summary>
        /// True to allow expand/collapse of each contained panel by clicking anywhere on the title bar, false to allow expand/collapse only when the toggle tool button is clicked (defaults to true). When set to false, hideCollapseTool should be false also.
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to allow expand/collapse of each contained panel by clicking anywhere on the title bar, false to allow expand/collapse only when the toggle tool button is clicked (defaults to true). When set to false, hideCollapseTool should be false also.")]
        public virtual bool TitleCollapse
        {
            get
            {
                return this.State.Get<bool>("TitleCollapse", true);
            }
            set
            {
                this.State.Set("TitleCollapse", value);
            }
        }
    }
}