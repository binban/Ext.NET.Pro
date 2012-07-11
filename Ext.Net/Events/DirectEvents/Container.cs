/********
 * @version   : 1.5.0 - Ext.NET Pro License
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
    public partial class ContainerDirectEvents : BoxComponentDirectEvents
    {
        private ComponentDirectEvent add;

        /// <summary>
        /// Fires after any Component is added or inserted into the content Container.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ContainerBase), "this")]
        [ListenerArgument(1, "component", typeof(Component), "The component that was added")]
        [ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("add", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after any Component is added or inserted into the content Container.")]
        public virtual ComponentDirectEvent Add
        {
            get
            {
                if (this.add == null)
                {
                    this.add = new ComponentDirectEvent();
                }

                return this.add;
            }
        }

        private ComponentDirectEvent afterLayout;

        /// <summary>
        /// Fires when the components in this content Container are arranged by the associated layout manager.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ContainerBase), "this")]
        [ListenerArgument(1, "layout", typeof(ContainerLayout), "The ContainerLayout implementation for this container")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afterlayout", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the components in this content Container are arranged by the associated layout manager.")]
        public virtual ComponentDirectEvent AfterLayout
        {
            get
            {
                if (this.afterLayout == null)
                {
                    this.afterLayout = new ComponentDirectEvent();
                }

                return this.afterLayout;
            }
        }

        private ComponentDirectEvent beforeAdd;

        /// <summary>
        /// Fires before any Component is added or inserted into the content Container. A handler can return false to cancel the add.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ContainerBase), "this")]
        [ListenerArgument(1, "component", typeof(Component), "The component that was added")]
        [ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeadd", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any Component is added or inserted into the content Container. A handler can return false to cancel the add.")]
        public virtual ComponentDirectEvent BeforeAdd
        {
            get
            {
                if (this.beforeAdd == null)
                {
                    this.beforeAdd = new ComponentDirectEvent();
                }

                return this.beforeAdd;
            }
        }

        private ComponentDirectEvent beforeRemove;

        /// <summary>
        /// Fires before any Component is removed from the content Container. A handler can return false to cancel the remove.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ContainerBase), "this")]
        [ListenerArgument(1, "component", typeof(Component), "The component being removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any Component is removed from the content Container. A handler can return false to cancel the remove.")]
        public virtual ComponentDirectEvent BeforeRemove
        {
            get
            {
                if (this.beforeRemove == null)
                {
                    this.beforeRemove = new ComponentDirectEvent();
                }

                return this.beforeRemove;
            }
        }

        private ComponentDirectEvent remove;

        /// <summary>
        /// Fires after any Component is removed from the content Container.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ContainerBase), "this")]
        [ListenerArgument(1, "component", typeof(Component), "The component that was removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after any Component is removed from the content Container.")]
        public virtual ComponentDirectEvent Remove
        {
            get
            {
                if (this.remove == null)
                {
                    this.remove = new ComponentDirectEvent();
                }

                return this.remove;
            }
        }
    }
}