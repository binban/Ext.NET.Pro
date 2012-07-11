/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class PanelListeners : ContainerListeners
    {
        private ComponentListener beforeClose;

        /// <summary>
        /// Fires before the user closes the panel. Return false from any listener to stop the close event being fired
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel being closed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeclose", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the user closes the panel. Return false from any listener to stop the close event being fired")]
        public virtual ComponentListener BeforeClose
        {
            get
            {
                return this.beforeClose ?? (this.beforeClose = new ComponentListener());
            }
        }

        private ComponentListener beforeCollapse;

        /// <summary>
        /// Fires before this panel is collapsed. Return false to prevent the collapse.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel being collapsed.
        /// direction : string
        ///    The direction of the collapse.
        /// animate : bool
        ///    True if the collapse is animated, else false.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "the Panel being collapsed.")]
        [ListenerArgument(1, "direction", typeof(bool), "")]
        [ListenerArgument(2, "animate", typeof(bool), "True if the collapse is animated, else false.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this panel is collapsed. Return false to prevent the collapse.")]
        public virtual ComponentListener BeforeCollapse
        {
            get
            {
                return this.beforeCollapse ?? (this.beforeCollapse = new ComponentListener());
            }
        }

        private ComponentListener beforeExpand;

        /// <summary>
        /// Fires before this panel is expanded. Return false to prevent the expand.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel being expanded.
        /// animate : bool
        ///    True if the expand is animated, else false.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel being expanded.")]
        [ListenerArgument(1, "animate", typeof(bool), "True if the expand is animated, else false.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before this panel is expanded. Return false to prevent the expand.")]
        public virtual ComponentListener BeforeExpand
        {
            get
            {
                return this.beforeExpand ?? (this.beforeExpand = new ComponentListener());
            }
        }

        private ComponentListener bodyResize;

        /// <summary>
        /// Fires after the Panel has been resized.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     the Panel which has been resized.
        /// width : Number
        ///     The Panel body's new width.
        /// height : Number
        ///     The Panel body's new height.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel which has been resized.")]
        [ListenerArgument(1, "width", typeof(int), "The Panel's new width.")]
        [ListenerArgument(2, "height", typeof(int), "The Panel's new height.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyresize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been resized.")]
        public virtual ComponentListener BodyResize
        {
            get
            {
                return this.bodyResize ?? (this.bodyResize = new ComponentListener());
            }
        }

        private ComponentListener close;

        /// <summary>
        /// Fires when the user closes the panel.
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been closed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("close", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user closes the panel.")]
        public virtual ComponentListener Close
        {
            get
            {
                return this.close ?? (this.close = new ComponentListener());
            }
        }

        private ComponentListener collapse;

        /// <summary>
        /// Fires after the Panel has been collapsed.
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been collapsed.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been collapsed.")]
        public virtual ComponentListener Collapse
        {
            get
            {
                return this.collapse ?? (this.collapse = new ComponentListener());
            }
        }

        private ComponentListener expand;

        /// <summary>
        /// Fires after the Panel has been expanded.
        /// Parameters
        /// item : Ext.panel.Panel
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel that has been expanded.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel has been expanded.")]
        public virtual ComponentListener Expand
        {
            get
            {
                return this.expand ?? (this.expand = new ComponentListener());
            }
        }

        private ComponentListener titleChange;

        /// <summary>
        /// Fires after the Panel title has been set or changed.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel which has had its title changed.
        /// newTitle : String
        ///     The new title.
        /// oldTitle : String
        ///     The previous panel title.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "The Panel which has had its title changed.")]
        [ListenerArgument(1, "newTitle", typeof(string), "new title.")]
        [ListenerArgument(2, "oldTitle", typeof(string), "old title.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("titlechange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel title has been set or changed.")]
        public virtual ComponentListener TitleChange
        {
            get
            {
                return this.titleChange ?? (this.titleChange = new ComponentListener());
            }
        }

        private ComponentListener iconClsChange;

        /// <summary>
        /// Fires after the Panel icon class has been set or changed.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel which has the iconCls changed.
        /// newIconCls : string
        ///     The new iconCls.
        /// oldIconCls : string
        ///     The previous panel iconCls.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "newIconCls", typeof(string))]
        [ListenerArgument(2, "oldIconCls", typeof(string))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconclschange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel icon class has been set or changed.")]
        public virtual ComponentListener IconClsChange
        {
            get
            {
                return this.iconClsChange ?? (this.iconClsChange = new ComponentListener());
            }
        }

        private ComponentListener iconChange;

        /// <summary>
        /// Fires after the Panel icon has been set or changed.
        /// Parameters
        /// item : Ext.panel.Panel
        ///     The Panel which has the icon changed.
        /// newIcon : string
        ///     The path to the new icon image.
        /// oldIcon : string
        ///     The path to the previous panel icon image.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Panel), "this")]
        [ListenerArgument(1, "newIcon", typeof(string))]
        [ListenerArgument(2, "oldIcon", typeof(string))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("iconchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the Panel icon has been set or changed.")]
        public virtual ComponentListener IconChange
        {
            get
            {
                return this.iconChange ?? (this.iconChange = new ComponentListener());
            }
        }
    }
}