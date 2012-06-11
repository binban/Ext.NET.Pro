/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Single radio field. Can be used as a direct replacement for traditional Radio controls.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Radio runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("CheckedChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Checked")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [Designer(typeof(RadioDesigner))]
    [ToolboxBitmap(typeof(Radio), "Build.ToolboxIcons.Radio.bmp")]
    [Description("Single radio field. Can be used as a direct replacement for traditional Radio controls.")]
    public partial class Radio : CheckboxBase, IPostBackEventHandler, ICheckBoxControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Radio() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "radio";
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
                return "Ext.form.Radio";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.AutoPostBack)
            {
                this.On("check", new JFunction(this.PostBackFunction));
            }
        }

        private RadioListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public RadioListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RadioListeners();
                }

                return this.listeners;
            }
        }

        private RadioDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public RadioDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RadioDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventCheckedChanged = new object();

        /// <summary>
        /// Fires when the Checked property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Checked property has been changed")]
        public event EventHandler CheckedChanged
        {
            add
            {
                Events.AddHandler(EventCheckedChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventCheckedChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventCheckedChanged];

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

            bool isChecked = false;
            
            string val = postCollection[this.UniqueName];

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val.IsNotEmpty() && val.Equals(this.InputValue))
            {

                try
                {
                    this.SuspendScripting();

                    if (!this.Checked)
                    {
                        this.Checked = true;
                        isChecked = true;
                    }
                }
                finally
                {
                    this.ResumeScripting();
                }

                return isChecked;
            }

            try
            {
                this.SuspendScripting();

                if (this.Checked)
                {
                    this.Checked = false;
                }
            }
            finally
            {
                this.ResumeScripting();
            }

            return isChecked;
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnCheckedChanged(EventArgs.Empty);
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static Radio()
        {
            DirectEventCheck = new object();
        }

        private static readonly object DirectEventCheck;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectCheck
        {
            add
            {
                this.DirectEvents.Check.Event += value;
            }
            remove
            {
                this.DirectEvents.Check.Event -= value;
            }
        }
    }
}