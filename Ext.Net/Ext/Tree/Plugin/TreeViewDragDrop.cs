/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// This plugin provides drag and/or drop functionality for a TreeView.
    /// 
    /// It creates a specialized instance of DragZone which knows how to drag out of a TreeView and loads the data object which is passed to a cooperating DragZone's methods with the following properties:
    /// 
    /// copy : Boolean
    /// The value of the TreeView's copy property, or true if the TreeView was configured with allowCopy: true and the control key was pressed when the drag operation was begun.
    /// 
    /// view : TreeView
    /// The source TreeView from which the drag originated.
    /// 
    /// ddel : HtmlElement
    /// The drag proxy element which moves with the mouse
    /// 
    /// item : HtmlElement
    /// The TreeView node upon which the mousedown event was registered.
    /// 
    /// records : Array
    /// An Array of Models representing the selected data being dragged from the source TreeView.
    /// 
    /// It also creates a specialized instance of Ext.dd.DropZone which cooperates with other DropZones which are members of the same ddGroup which processes such data objects.
    /// 
    /// Adding this plugin to a view means that two new events may be fired from the client TreeView, beforedrop and drop.
    /// 
    /// Note that the plugin must be added to the tree view, not to the tree panel.
    /// </summary>
    public partial class TreeViewDragDrop : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.tree.plugin.TreeViewDragDrop";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public override string PType
        {
            get
            {
                return "treeviewdragdrop";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override System.Type RequiredOwnerType
        {
            get
            {
                return typeof(TreeView);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("{0} selected node{1}")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DragText
        {
            get
            {
                return this.State.Get<string>("DragText", "{0} selected node{1}");
            }
            set
            {
                this.State.Set("DragText", value);
            }
        }

        /// <summary>
        /// Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped.")]
        public virtual bool AllowParentInserts
        {
            get
            {
                return this.State.Get<bool>("AllowParentInserts", false);
            }
            set
            {
                this.State.Set("AllowParentInserts", value);
            }
        }

        /// <summary>
        /// True if drops on the tree container (outside of a specific tree node) are allowed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if drops on the tree container (outside of a specific tree node) are allowed.")]
        public virtual bool AllowContainerDrops
        {
            get
            {
                return this.State.Get<bool>("AllowContainerDrops", false);
            }
            set
            {
                this.State.Set("AllowContainerDrops", value);
            }
        }

        /// <summary>
        /// A named drag drop group to which this object belongs. If a group is specified, then both the DragZones and DropZone used by this plugin will only interact with other drag drop objects in the same group. Defaults to: "TreeDD"
        /// </summary>
        [Meta]
        [ConfigOption("ddGroup")]
        [DefaultValue("TreeDD")]
        [NotifyParentProperty(true)]
        [Description("A named drag drop group to which this object belongs. If a group is specified, then both the DragZones and DropZone used by this plugin will only interact with other drag drop objects in the same group. Defaults to: \"TreeDD\"")]
        public virtual string DDGroup
        {
            get
            {
                return this.State.Get<string>("DDGroup", "TreeDD");
            }
            set
            {
                this.State.Set("DDGroup", value);
            }
        }

        /// <summary>
        /// The ddGroup to which the DragZone will belong. This defines which other DropZones the DragZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The ddGroup to which the DragZone will belong. This defines which other DropZones the DragZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.")]
        public virtual string DragGroup
        {
            get
            {
                return this.State.Get<string>("DragGroup", "");
            }
            set
            {
                this.State.Set("DragGroup", value);
            }
        }

        /// <summary>
        /// The ddGroup to which the DropZone will belong. This defines which other DragZones the DropZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The ddGroup to which the DropZone will belong. This defines which other DragZones the DropZone will interact with. Drag/DropZones only interact with other Drag/DropZones which are members of the same ddGroup.")]
        public virtual string DropGroup
        {
            get
            {
                return this.State.Get<string>("DropGroup", "");
            }
            set
            {
                this.State.Set("DropGroup", value);
            }
        }

        /// <summary>
        /// Set to false to disallow dragging items from the View. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Set to false to disallow dragging items from the View. Defaults to: true")]
        public virtual bool EnableDrag
        {
            get
            {
                return this.State.Get<bool>("EnableDrag", true);
            }
            set
            {
                this.State.Set("EnableDrag", value);
            }
        }

        /// <summary>
        /// Set to false to disallow the View from accepting drop gestures. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Set to false to disallow the View from accepting drop gestures. Defaults to: true")]
        public virtual bool EnableDrop
        {
            get
            {
                return this.State.Get<bool>("EnableDrop", true);
            }
            set
            {
                this.State.Set("EnableDrop", value);
            }
        }

        /// <summary>
        /// True if the tree should only allow append drops (use for trees which are sorted). Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True if the tree should only allow append drops (use for trees which are sorted). Defaults to: false")]
        public virtual bool AppendOnly
        {
            get
            {
                return this.State.Get<bool>("AppendOnly", false);
            }
            set
            {
                this.State.Set("AppendOnly", value);
            }
        }

        /// <summary>
        /// The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target. Defaults to: 1000
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(1000)]
        [Description("The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target. Defaults to: 1000")]
        public virtual int ExpandDelay
        {
            get
            {
                return this.State.Get<int>("ExpandDelay", 1000);
            }
            set
            {
                this.State.Set("ExpandDelay", value);
            }
        }

        /// <summary>
        /// The color to use when visually highlighting the dragged or dropped node (default value is light blue). The color must be a 6 digit hex value, without a preceding '#'. See also nodeHighlightOnDrop and nodeHighlightOnRepair. Defaults to: "c3daf9"
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("c3daf9")]
        [Description("The color to use when visually highlighting the dragged or dropped node (default value is light blue). The color must be a 6 digit hex value, without a preceding '#'. See also nodeHighlightOnDrop and nodeHighlightOnRepair. Defaults to: \"c3daf9\"")]
        public virtual string NodeHighlightColor
        {
            get
            {
                return this.State.Get<string>("NodeHighlightColor", "c3daf9");
            }
            set
            {
                this.State.Set("NodeHighlightColor", value);
            }
        }

        /// <summary>
        /// Whether or not to highlight any nodes after they are successfully dropped on their target. Defaults to the value of Ext.enableFx. See also nodeHighlightColor and nodeHighlightOnRepair.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether or not to highlight any nodes after they are successfully dropped on their target. Defaults to the value of Ext.enableFx. See also nodeHighlightColor and nodeHighlightOnRepair.")]
        public virtual bool NodeHighlightOnDrop
        {
            get
            {
                return this.State.Get<bool>("NodeHighlightOnDrop", true);
            }
            set
            {
                this.State.Set("NodeHighlightOnDrop", value);
            }
        }

        /// <summary>
        /// Whether or not to highlight any nodes after they are repaired from an unsuccessful drag/drop. Defaults to the value of Ext.enableFx. See also nodeHighlightColor and nodeHighlightOnDrop.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether or not to highlight any nodes after they are repaired from an unsuccessful drag/drop. Defaults to the value of Ext.enableFx. See also nodeHighlightColor and nodeHighlightOnDrop.")]
        public virtual bool NodeHighlightOnRepair
        {
            get
            {
                return this.State.Get<bool>("NodeHighlightOnRepair", true);
            }
            set
            {
                this.State.Set("NodeHighlightOnRepair", value);
            }
        }

        /// <summary>
        /// true to allow append to the leaf node
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to allow append to the leaf node")]
        public virtual bool AllowLeafDrop
        {
            get
            {
                return this.State.Get<bool>("AllowLeafDrop", false);
            }
            set
            {
                this.State.Set("AllowLeafDrop", value);
            }
        }
    }
}
