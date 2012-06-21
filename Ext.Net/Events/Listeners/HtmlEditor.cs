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
    public partial class HtmlEditorListeners : FieldListeners
    {
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ComponentListener Blur
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
        public override ComponentListener Focus
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
        public override ComponentListener Change
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
        public override ComponentListener SpecialKey
        {
            get
            {
                return base.SpecialKey;
            }
        }

        private ComponentListener activate;

        /// <summary>
        /// Fires when the editor is first receives the focus. Any insertion must wait until after this event.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the editor is first receives the focus. Any insertion must wait until after this event.")]
        public override ComponentListener Activate
        {
            get
            {
                return this.activate ?? (this.activate = new ComponentListener());
            }
        }

        private ComponentListener beforePush;

        /// <summary>
        /// Fires before the iframe editor is updated with content from the textarea. Return false to cancel the push.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforepush", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the iframe editor is updated with content from the textarea. Return false to cancel the push.")]
        public virtual ComponentListener BeforePush
        {
            get
            {
                return this.beforePush ?? (this.beforePush = new ComponentListener());
            }
        }

        private ComponentListener beforeSync;

        /// <summary>
        /// Fires before the textarea is updated with content from the editor iframe. Return false to cancel the sync.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforesync", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the textarea is updated with content from the editor iframe. Return false to cancel the sync.")]
        public virtual ComponentListener BeforeSync
        {
            get
            {
                return this.beforeSync ?? (this.beforeSync = new ComponentListener());
            }
        }

        private ComponentListener editModeChange;

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
        [ConfigOption("editmodechange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the editor switches edit modes.")]
        public virtual ComponentListener EditModeChange
        {
            get
            {
                return this.editModeChange ?? (this.editModeChange = new ComponentListener());
            }
        }

        private ComponentListener initialize;

        /// <summary>
        /// Fires when the editor is fully initialized (including the iframe).
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("initialize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the editor is fully initialized (including the iframe).")]
        public virtual ComponentListener Initialize
        {
            get
            {
                return this.initialize ?? (this.initialize = new ComponentListener());
            }
        }

        private ComponentListener push;

        /// <summary>
        /// Fires when the iframe editor is updated with content from the textarea.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("push", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the iframe editor is updated with content from the textarea.")]
        public virtual ComponentListener Push
        {
            get
            {
                return this.push ?? (this.push = new ComponentListener());
            }
        }

        private ComponentListener sync;

        /// <summary>
        /// Fires when the textarea is updated with content from the editor iframe.
        /// Parameters
        /// item : Ext.form.field.HtmlEditor
        /// html : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(HtmlEditor), "this")]
        [ListenerArgument(1, "html", typeof(string), "Html")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sync", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the textarea is updated with content from the editor iframe.")]
        public virtual ComponentListener Sync
        {
            get
            {
                return this.sync ?? (this.sync = new ComponentListener());
            }
        }
    }
}