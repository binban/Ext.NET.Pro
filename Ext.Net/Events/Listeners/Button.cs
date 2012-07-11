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
    public partial class ButtonListeners : BoxComponentListeners
    {
        private ComponentListener click;

        /// <summary>
        /// Fires when this button is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Button), "this")]
        [ListenerArgument(1, "e", typeof(object), "The click event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this button is clicked.")]
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

        private ComponentListener menuHide;

        /// <summary>
        /// If this button has a menu, this event fires when it is hidden.
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
                if (this.menuHide == null)
                {
                    this.menuHide = new ComponentListener();
                }

                return this.menuHide;
            }
        }

        private ComponentListener menuShow;

        /// <summary>
        /// If this button has a menu, this event fires when it is shown.
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
                if (this.menuShow == null)
                {
                    this.menuShow = new ComponentListener();
                }

                return this.menuShow;
            }
        }

        private ComponentListener menuTriggerOut;

        /// <summary>
        /// If this button has a menu, this event fires when the mouse leaves the menu triggering element.
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
                if (this.menuTriggerOut == null)
                {
                    this.menuTriggerOut = new ComponentListener();
                }

                return this.menuTriggerOut;
            }
        }

        private ComponentListener menuTriggerOver;

        /// <summary>
        /// If this button has a menu, this event fires when the mouse enters the menu triggering element.
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
                if (this.menuTriggerOver == null)
                {
                    this.menuTriggerOver = new ComponentListener();
                }

                return this.menuTriggerOver;
            }
        }

        private ComponentListener mouseOut;

        /// <summary>
        /// Fires when the mouse exits the button.
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
                if (this.mouseOut == null)
                {
                    this.mouseOut = new ComponentListener();
                }

                return this.mouseOut;
            }
        }

        private ComponentListener mouseOver;

        /// <summary>
        /// Fires when the mouse hovers over the button.
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
                if (this.mouseOver == null)
                {
                    this.mouseOver = new ComponentListener();
                }

                return this.mouseOver;
            }
        }

        private ComponentListener toggle;

        /// <summary>
        /// Fires when the 'pressed' state of this button changes (only if enableToggle = true).
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
                if (this.toggle == null)
                {
                    this.toggle = new ComponentListener();
                }

                return this.toggle;
            }
        }
    }
}