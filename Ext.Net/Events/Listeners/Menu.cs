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
    public partial class MenuListeners : ContainerListeners
    {
        private ComponentListener click;

        /// <summary>
        /// Fires when this menu is clicked (or when the enter key is pressed while it is active)
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(1, "menuItem", typeof(object))]
        [ListenerArgument(2, "e", typeof(Menu), "Ext.EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this menu is clicked (or when the enter key is pressed while it is active)")]
        public virtual ComponentListener Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentListener();
                }

                return this.click;
            }
        }

        private ComponentListener itemClick;

        /// <summary>
        /// Fires when a menu item contained in this menu is clicked
        /// </summary>
        [ListenerArgument(0, "menuItem", typeof(object))]
        [ListenerArgument(1, "e", typeof(Menu), "Ext.EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("itemclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a menu item contained in this menu is clicked")]
        public virtual ComponentListener ItemClick
        {
            get
            {
                if (this.itemClick == null)
                {
                    this.itemClick = new ComponentListener();
                }

                return this.itemClick;
            }
        }

        private ComponentListener mouseOut;

        /// <summary>
        /// Fires when the mouse exits this menu
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(2, "menuItem", typeof(object))]
        [ListenerArgument(1, "e", typeof(Menu), "Ext.EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse exits this menu")]
        public virtual ComponentListener MouseOut
        {
            get
            {
                if (this.mouseOut == null)
                {
                    this.mouseOut = new ComponentListener();
                }

                return this.mouseOut;
            }
        }

        private ComponentListener mouseOver;

        /// <summary>
        /// Fires when the mouse is hovering over this menu
        /// </summary>
        [ListenerArgument(0, "item", typeof(Menu), "this")]
        [ListenerArgument(2, "menuItem", typeof(object))]
        [ListenerArgument(1, "e", typeof(Menu), "Ext.EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse is hovering over this menu")]
        public virtual ComponentListener MouseOver
        {
            get
            {
                if (this.mouseOver == null)
                {
                    this.mouseOver = new ComponentListener();
                }

                return this.mouseOver;
            }
        }
    }
}