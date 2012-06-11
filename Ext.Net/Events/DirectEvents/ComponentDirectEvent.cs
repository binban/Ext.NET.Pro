/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof (DirectEventConverter))]
    [ToolboxItem(false)]
    [Description("")]
    public partial class ComponentDirectEvent : ObservableDirectEvent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        public delegate void DirectEventHandler(object sender, DirectEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected event DirectEventHandler Handler;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public event DirectEventHandler Event
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.Handler = (DirectEventHandler) System.Delegate.Combine(this.Handler, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.Handler = (DirectEventHandler)System.Delegate.Remove(this.Handler, value);
            }
        }

        internal virtual void OnEvent(DirectEventArgs e)
        {
            if (this.Handler != null)
            {
                this.Handler(this.Owner, e);
            }
        }

        public bool HandlerIsNotEmpty
        {
            get
            {
                return this.Handler != null;
            }
        }

        internal string HandlerName
        {
            get
            {
                return this.Handler.Method.Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Handler == null && this.Url.IsEmpty() && this.Type == DirectEventType.Submit;
            }
        }
        
        private DirectEventConfirmation confirmation;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("")]
        public DirectEventConfirmation Confirmation
        {
            get
            {
                if (this.confirmation == null)
                {
                    this.confirmation = new DirectEventConfirmation();
                }

                return this.confirmation;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DirectEventConfirmation : StateManagedItem
    {
        /// <summary>
        /// If true show confirmation dialog
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("If true show confirmation dialog")]
        public virtual bool ConfirmRequest
        {
            get
            {
                object obj = this.ViewState["ConfirmRequest"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["ConfirmRequest"] = value;
            }
        }

        /// <summary>
        /// Confirmation dialog title
        /// </summary>
        [DefaultValue("Confirmation")]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("Confirmation dialog title")]
        public virtual string Title
        {
            get
            {
                return (string)this.ViewState["Title"] ?? "Confirmation";
            }
            set
            {
                this.ViewState["Title"] = value;
            }
        }

        /// <summary>
        /// Confirmation dialog message
        /// </summary>
        [DefaultValue("Are you sure?")]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("Confirmation dialog message")]
        public virtual string Message
        {
            get
            {
                return (string)this.ViewState["Message"] ?? "Are you sure?";
            }
            set
            {
                this.ViewState["Message"] = value;
            }
        }

        /// <summary>
        /// Before confirm handler. Return false to cancel confirm
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Before confirm handler. Return false to cancel confirm")]
        public virtual string BeforeConfirm
        {
            get
            {
                return (string)this.ViewState["BeforeConfirm"] ?? "";
            }
            set
            {
                this.ViewState["BeforeConfirm"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("beforeConfirm", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string BeforeConfirmProxy
        {
            get
            {
                if (this.BeforeConfirm.IsEmpty())
                {
                    return "";
                }

                return "function(config){".ConcatWith(this.BeforeConfirm, "}");
            }
        }

        /// <summary>
        /// Javascript handler, Fires if user press No in the confirmation dialog
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Javascript handler, Fires if user press No in the confirmation dialog")]
        public virtual string Cancel
        {
            get
            {
                return (string)this.ViewState["Cancel"] ?? "";
            }
            set
            {
                this.ViewState["Cancel"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("cancel", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string CancelProxy
        {
            get
            {
                if (this.Cancel.IsEmpty())
                {
                    return "";
                }

                return "function(config){".ConcatWith(this.Cancel, "}");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DirectEventArgs : EventArgs
    {
        private readonly ParameterCollection extraParams;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extraParams"></param>
        [Description("")]
        public DirectEventArgs(ParameterCollection extraParams)
        {
            this.extraParams = extraParams;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ParameterCollection ExtraParams
        {
            get
            {
                return this.extraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ParameterCollection ExtraParamsResponse
        {
            get
            {
                return ResourceManager.ExtraParamsResponse;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual bool Success
        {
            get 
            { 
                return ResourceManager.AjaxSuccess; 
            }
            set 
            { 
                ResourceManager.AjaxSuccess = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ErrorMessage
        {
            get 
            { 
                return ResourceManager.AjaxErrorMessage; 
            }
            set 
            { 
                ResourceManager.AjaxErrorMessage = value; 
            }
        }
    }
}
