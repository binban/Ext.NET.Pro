/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
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
    public partial class RowEditorListeners : ComponentListeners
    {
        private ComponentListener afterEdit;

        /// <summary>
        /// Fired after a row is edited and passes validation.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "o", typeof(object), "Object with changes made to the record.")]
        [ListenerArgument(2, "r", typeof(object), "The Record that was edited")]
        [ListenerArgument(3, "rowIndex", typeof(object), "The rowIndex of the row just edited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteredit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a row is edited and passes validation.")]
        public virtual ComponentListener AfterEdit
        {
            get
            {
                if (this.afterEdit == null)
                {
                    this.afterEdit = new ComponentListener();
                }

                return this.afterEdit;
            }
        }

        private ComponentListener beforeEdit;

        /// <summary>
        /// Fired before the row editor is activated.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "rowIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before the row editor is activated.")]
        public virtual ComponentListener BeforeEdit
        {
            get
            {
                if (this.beforeEdit == null)
                {
                    this.beforeEdit = new ComponentListener();
                }

                return this.beforeEdit;
            }
        }

        private ComponentListener cancelEdit;

        /// <summary>
        /// Fired when the editor is cancelled.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "forced")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("canceledit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when the editor is cancelled.")]
        public virtual ComponentListener CancelEdit
        {
            get
            {
                if (this.cancelEdit == null)
                {
                    this.cancelEdit = new ComponentListener();
                }

                return this.cancelEdit;
            }
        }

        private ComponentListener validateEdit;

        /// <summary>
        /// Fired after a row is edited and passes validation.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "o", typeof(object), "Object with changes made to the record.")]
        [ListenerArgument(2, "r", typeof(object), "The Record that was edited")]
        [ListenerArgument(3, "rowIndex", typeof(object), "The rowIndex of the row just edited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a row is edited and passes validation.")]
        public virtual ComponentListener ValidateEdit
        {
            get
            {
                if (this.validateEdit == null)
                {
                    this.validateEdit = new ComponentListener();
                }

                return this.validateEdit;
            }
        }

        private ComponentListener preEdit;

        /// <summary>
        /// Fired for each field's value.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("preedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired for each field's value.")]
        public virtual ComponentListener PreEdit
        {
            get
            {
                if (this.preEdit == null)
                {
                    this.preEdit = new ComponentListener();
                }

                return this.preEdit;
            }
        }
    }
}