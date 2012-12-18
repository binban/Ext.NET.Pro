/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A basic hidden field for storing hidden values in forms that need to be passed in the form submit.
    ///
    /// This creates an actual input element with type="submit" in the DOM. While its label is not rendered by default, it is still a real component and may be sized according to its owner container's layout.
    ///
    /// Because of this, in most cases it is more convenient and less problematic to simply pass hidden parameters directly when submitting the form.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Hidden runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("ValueChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Text")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [NonVisualControl]
    [ToolboxBitmap(typeof(Hidden), "Build.ToolboxIcons.Hidden.bmp")]
    [Description("A basic hidden field for storing hidden values in forms that need to be passed in the form submit. Can be used as a direct replacement for the traditional &lt;asp:Hidden> Web Control.")]
    public partial class Hidden : Field
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Hidden() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "hiddenfield";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.field.Hidden";
            }
        }

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public virtual string Text
        {
            get
            {
                return (string)this.Value;
            }
            set
            {
                this.Value = value;
            }
        }

        /*  IField
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The fields null value.")]
        public override object EmptyValue
        {
            get
            {
                return this.State.Get<string>("EmptyValue", "");
            }
            set
            {
                this.State.Set("EmptyValue", value);
            }
        }

        private FieldListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public FieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FieldListeners();
                }

                return this.listeners;
            }
        }

        private FieldDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public FieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventValueChanged = new object();

        /// <summary>
        /// Fires when the Text property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.CheckForceId();
				Events.AddHandler(EventValueChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventValueChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventValueChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val != null && (this.Value == null || !this.Value.Equals(val)))
            {
                try
                {
                    this.SuspendScripting();
                    this.Value = val;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return true;
            }

            return false;
        }
        

        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static Hidden()
        {
            DirectEventChange = new object();
        }

        private static readonly object DirectEventChange;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.CheckForceId();
				this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }
    }
}