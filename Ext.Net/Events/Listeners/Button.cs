/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    public partial class ButtonListeners : AbstractComponentListeners
    {
        private ComponentListener click;

        /// <summary>
        /// Fires when this button is clicked, before the configured handler is invoked. Execution of the handler may be vetoed by returning false to this event.
        /// Parameters
        /// item : Ext.button.Button
        /// e : Event
        /// The click event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The click event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this button is clicked, before the configured handler is invoked. Execution of the handler may be vetoed by returning false to this event.")]
        public virtual ComponentListener Click
        {
            get
            {
                return this.click ?? (this.click = new ComponentListener());
            }
        }

        private ComponentListener menuHide;

        /// <summary>
        /// If this button has a menu, this event fires when it is hidden.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menuhide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when it is hidden.")]
        public virtual ComponentListener MenuHide
        {
            get
            {
                return this.menuHide ?? (this.menuHide = new ComponentListener());
            }
        }

        private ComponentListener menuShow;

        /// <summary>
        /// If this button has a menu, this event fires when it is shown.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menushow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when it is shown.")]
        public virtual ComponentListener MenuShow
        {
            get
            {
                return this.menuShow ?? (this.menuShow = new ComponentListener());
            }
        }

        private ComponentListener menuTriggerOut;

        /// <summary>
        /// If this button has a menu, this event fires when the mouse leaves the menu triggering element.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menutriggerout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when the mouse leaves the menu triggering element.")]
        public virtual ComponentListener MenuTriggerOut
        {
            get
            {
                return this.menuTriggerOut ?? (this.menuTriggerOut = new ComponentListener());
            }
        }

        private ComponentListener menuTriggerOver;

        /// <summary>
        /// If this button has a menu, this event fires when the mouse enters the menu triggering element.
        /// Parameters
        /// item : Ext.button.Button
        /// menu : Ext.menu.Menu
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "menu", typeof(object), "Menu")]
        [ListenerArgument(1, "e", typeof(object), "EventObject")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menutriggerover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("If this button has a menu, this event fires when the mouse enters the menu triggering element.")]
        public virtual ComponentListener MenuTriggerOver
        {
            get
            {
                return this.menuTriggerOver ?? (this.menuTriggerOver = new ComponentListener());
            }
        }

        private ComponentListener mouseOut;

        /// <summary>
        /// Fires when the mouse exits the button.
        /// Parameters
        /// item : Ext.button.Button
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse exits the button.")]
        public virtual ComponentListener MouseOut
        {
            get
            {
                return this.mouseOut ?? (this.mouseOut = new ComponentListener());
            }
        }

        private ComponentListener mouseOver;

        /// <summary>
        /// Fires when the mouse hovers over the button.
        /// Parameters
        /// item : Ext.button.Button
        /// e : Event
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse hovers over the button.")]
        public virtual ComponentListener MouseOver
        {
            get
            {
                return this.mouseOver ?? (this.mouseOver = new ComponentListener());
            }
        }

        private ComponentListener toggle;

        /// <summary>
        /// Fires when the 'pressed' state of this button changes (only if enableToggle = true).
        /// Parameters
        /// item : Ext.button.Button
        /// pressed : Boolean
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "pressed", typeof(bool), "Pressed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("toggle", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the 'pressed' state of this button changes (only if enableToggle = true).")]
        public virtual ComponentListener Toggle
        {
            get
            {
                return this.toggle ?? (this.toggle = new ComponentListener());
            }
        }
    }
}