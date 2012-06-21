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
    public partial class FormPanelDirectEvents : PanelDirectEvents
    {
        public FormPanelDirectEvents() { }

        public FormPanelDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent actionComplete;

        /// <summary>
        /// Fires when an action is completed.
        /// Parameters
        /// this : Ext.form.Basic
        /// action : Ext.form.action.Action
        ///     The Ext.form.action.Action that completed
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("actioncomplete", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an action is completed.")]
        public virtual ComponentDirectEvent ActionComplete
        {
            get
            {
                return this.actionComplete ?? (this.actionComplete = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent actionFailed;

        /// <summary>
        /// Fires when an action fails.
        /// Parameters
        /// this : Ext.form.Basic
        /// action : Ext.form.action.Action
        ///     The Ext.form.action.Action that completed
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("actionfailed", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an action fails.")]
        public virtual ComponentDirectEvent ActionFailed
        {
            get
            {
                return this.actionFailed ?? (this.actionFailed = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeAction;

        /// <summary>
        /// Fires before any action is performed. Return false to cancel the action.
        /// Parameters
        /// this : Ext.form.Basic
        /// action : Ext.form.action.Action
        ///     The Ext.form.action.Action that completed
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "action")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeaction", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before any action is performed. Return false to cancel the action.")]
        public virtual ComponentDirectEvent BeforeAction
        {
            get
            {
                return this.beforeAction ?? (this.beforeAction = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent dirtyChange;

        /// <summary>
        /// Fires when the dirty state of the entire form changes.
        /// Parameters
        /// this : Ext.form.Basic
        /// dirty : Boolean
        ///     true if the form is now dirty, false if it is no longer dirty.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "dirty")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dirtychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the dirty state of the entire form changes.")]
        public virtual ComponentDirectEvent DirtyChange
        {
            get
            {
                return this.dirtyChange ?? (this.dirtyChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent validityChange;

        /// <summary>
        /// Fires when the validity of the entire form changes.
        /// Parameters
        /// this : Ext.form.Basic
        /// valid : Boolean
        ///    true if the form is now valid, false if it is now invalid.
        /// </summary>
        [ListenerArgument(0, "item", typeof(FormPanel))]
        [ListenerArgument(1, "valid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validitychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the validity of the entire form changes.")]
        public virtual ComponentDirectEvent ValidityChange
        {
            get
            {
                return this.validityChange ?? (this.validityChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent fieldErrorChange;

        /// <summary>
        /// Fires when the active error message is changed for any one of the Ext.form.Labelable instances within this container.
        /// Parameters
        /// item : Ext.form.FieldAncestor
        /// field : Ext.form.Labelable
        ///     Labelable instance whose active error was changed
        /// error : String
        ///     The active error message
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "error")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fielderrorchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the active error message is changed for any one of the Ext.form.Labelable instances within this container.")]
        public virtual ComponentDirectEvent FieldErrorChange
        {
            get
            {
                return this.fieldErrorChange ?? (this.fieldErrorChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent fieldValidityChange;

        /// <summary>
        /// Fires when the validity state of any one of the Ext.form.field.Field instances within this container changes.
        /// Parameters
        /// item : Ext.form.FieldAncestor
        /// field : Ext.form.Labelable
        ///     Field instance whose validity changed
        /// isValid : bool
        ///     The field's new validity state
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "isValid")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fieldvaliditychange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the validity state of any one of the Ext.form.field.Field instances within this container changes.")]
        public virtual ComponentDirectEvent FieldValidityChange
        {
            get
            {
                return this.fieldValidityChange ?? (this.fieldValidityChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent fieldChange;

        /// <summary>
        /// Fires when the value of any one of the Ext.form.field.Field instances within this container changes.
        /// Parameters
        /// item : Ext.form.Panel
        /// field : Ext.form.Labelable
        ///     Field instance whose value changed
        /// newValue : Object
        ///     The new value
        /// oldValue : Object
        ///     The original value
        /// </summary>
        [ListenerArgument(0, "item")]
        [ListenerArgument(1, "field")]
        [ListenerArgument(2, "newValue")]
        [ListenerArgument(3, "oldValue")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("fieldchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the value of any one of the Ext.form.field.Field instances within this container changes.")]
        public virtual ComponentDirectEvent FieldChange
        {
            get
            {
                return this.fieldChange ?? (this.fieldChange = new ComponentDirectEvent(this));
            }
        }
    }
}