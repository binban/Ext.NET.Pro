/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TreeNodeDirectEvents : ComponentDirectEvents
    {
        public TreeNodeDirectEvents() { }

        public TreeNodeDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent beforeChildrenRendered;

        /// <summary>
        /// Fires right before the child nodes for this node are rendered
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforechildrenrendered", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires right before the child nodes for this node are rendered")]
        public virtual ComponentDirectEvent BeforeChildrenRendered
        {
            get
            {
                if (this.beforeChildrenRendered == null)
                {
                    this.beforeChildrenRendered = new ComponentDirectEvent(this);
                }

                return this.beforeChildrenRendered;
            }
        }

        private ComponentDirectEvent beforeClick;

        /// <summary>
        /// Fires before click processing. Return false to cancel the default action.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before click processing. Return false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeClick
        {
            get
            {
                if (this.beforeClick == null)
                {
                    this.beforeClick = new ComponentDirectEvent(this);
                }

                return this.beforeClick;
            }
        }

        private ComponentDirectEvent beforeCollapse;

        /// <summary>
        /// Fires before this node is collapsed, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "deep")]
        [ListenerArgument(2, "anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed, return false to cancel.")]
        public virtual ComponentDirectEvent BeforeCollapse
        {
            get
            {
                if (this.beforeCollapse == null)
                {
                    this.beforeCollapse = new ComponentDirectEvent(this);
                }

                return this.beforeCollapse;
            }
        }

        private ComponentDirectEvent beforeExpand;

        /// <summary>
        /// Fires before this node is collapsed, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "deep")]
        [ListenerArgument(2, "anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this node is collapsed, return false to cancel.")]
        public virtual ComponentDirectEvent BeforeExpand
        {
            get
            {
                if (this.beforeExpand == null)
                {
                    this.beforeExpand = new ComponentDirectEvent(this);
                }

                return this.beforeExpand;
            }
        }

        private ComponentDirectEvent checkChange;

        /// <summary>
        /// Fires when a node with a checkbox's checked property changes.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node with a checkbox's checked property changes.")]
        public virtual ComponentDirectEvent CheckChange
        {
            get
            {
                if (this.checkChange == null)
                {
                    this.checkChange = new ComponentDirectEvent(this);
                }

                return this.checkChange;
            }
        }

        private ComponentDirectEvent click;

        /// <summary>
        /// Fires when this node is clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is clicked")]
        public virtual ComponentDirectEvent Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentDirectEvent(this);
                }

                return this.click;
            }
        }

        private ComponentDirectEvent collapse;

        /// <summary>
        /// Fires when this node is collapsed
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is collapsed")]
        public virtual ComponentDirectEvent Collapse
        {
            get
            {
                if (this.collapse == null)
                {
                    this.collapse = new ComponentDirectEvent(this);
                }

                return this.collapse;
            }
        }

        private ComponentDirectEvent contextMenu;

        /// <summary>
        /// Fires when this node is right clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("contextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is right clicked")]
        public virtual ComponentDirectEvent ContextMenu
        {
            get
            {
                if (this.contextMenu == null)
                {
                    this.contextMenu = new ComponentDirectEvent(this);
                }

                return this.contextMenu;
            }
        }

        private ComponentDirectEvent dblClick;

        /// <summary>
        /// Fires when this node is double clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is double clicked")]
        public virtual ComponentDirectEvent DblClick
        {
            get
            {
                if (this.dblClick == null)
                {
                    this.dblClick = new ComponentDirectEvent(this);
                }

                return this.dblClick;
            }
        }

        private ComponentDirectEvent disabledChange;

        /// <summary>
        /// Fires when the disabled status of this node changes
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "disabled")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("disabledchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the disabled status of this node changes")]
        public virtual ComponentDirectEvent DisabledChange
        {
            get
            {
                if (this.disabledChange == null)
                {
                    this.disabledChange = new ComponentDirectEvent(this);
                }

                return this.disabledChange;
            }
        }

        private ComponentDirectEvent expand;

        /// <summary>
        /// Fires when this node is expanded
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this node is expanded")]
        public virtual ComponentDirectEvent Expand
        {
            get
            {
                if (this.expand == null)
                {
                    this.expand = new ComponentDirectEvent(this);
                }

                return this.expand;
            }
        }

        private ComponentDirectEvent textChange;

        /// <summary>
        /// Fires when the text for this node is changed
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "text")]
        [ListenerArgument(2, "oldText")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("textchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the text for this node is changed")]
        public virtual ComponentDirectEvent TextChange
        {
            get
            {
                if (this.textChange == null)
                {
                    this.textChange = new ComponentDirectEvent(this);
                }

                return this.textChange;
            }
        }
    }
}