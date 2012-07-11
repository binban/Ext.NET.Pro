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
    public partial class HtmlEditorDirectEvents : FieldDirectEvents
    {
        public HtmlEditorDirectEvents() { }

        public HtmlEditorDirectEvents(Observable parent) { this.Parent = parent; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ComponentDirectEvent Blur
        {
            get
            {
                return base.Blur;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ComponentDirectEvent Focus
        {
            get
            {
                return base.Focus;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ComponentDirectEvent Change
        {
            get
            {
                return base.Change;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ComponentDirectEvent SpecialKey
        {
            get
            {
                return base.SpecialKey;
            }
        }

        private ComponentDirectEvent activate;

        /// <summary>
        /// Fires when the editor is first receives the focus. Any insertion must wait until after this event.
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the editor is first receives the focus. Any insertion must wait until after this event.")]
        public override ComponentDirectEvent Activate
        {
            get
            {
                return this.activate ?? (this.activate = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforePush;

        /// <summary>
        /// Fires before the iframe editor is updated with content from the textarea. Return false to cancel the push.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforepush", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the iframe editor is updated with content from the textarea. Return false to cancel the push.")]
        public virtual ComponentDirectEvent BeforePush
        {
            get
            {
                return this.beforePush ?? (this.beforePush = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent beforeSync;

        /// <summary>
        /// Fires before the textarea is updated with content from the editor iframe. Return false to cancel the sync.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforesync", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the textarea is updated with content from the editor iframe. Return false to cancel the sync.")]
        public virtual ComponentDirectEvent BeforeSync
        {
            get
            {
                return this.beforeSync ?? (this.beforeSync = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent editModeChange;

        /// <summary>
        /// Fires when the editor switches edit modes.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// sourceEdit : Boolean
        ///     True if source edit, false if standard editing.
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "sourceEdit", typeof(bool), "True if source edit, false if standard editing.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("editmodechange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the editor switches edit modes.")]
        public virtual ComponentDirectEvent EditModeChange
        {
            get
            {
                return this.editModeChange ?? (this.editModeChange = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent initialize;

        /// <summary>
        /// Fires when the editor is fully initialized (including the iframe).
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("initialize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the editor is fully initialized (including the iframe).")]
        public virtual ComponentDirectEvent Initialize
        {
            get
            {
                return this.initialize ?? (this.initialize = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent push;

        /// <summary>
        /// Fires when the iframe editor is updated with content from the textarea.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("push", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the iframe editor is updated with content from the textarea.")]
        public virtual ComponentDirectEvent Push
        {
            get
            {
                return this.push ?? (this.push = new ComponentDirectEvent(this));
            }
        }

        private ComponentDirectEvent sync;

        /// <summary>
        /// Fires when the textarea is updated with content from the editor iframe.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sync", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the textarea is updated with content from the editor iframe.")]
        public virtual ComponentDirectEvent Sync
        {
            get
            {
                return this.sync ?? (this.sync = new ComponentDirectEvent(this));
            }
        }
    }
}