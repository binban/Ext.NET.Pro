/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ControlState : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual T Get<T>(string name, T defaultValue)
        {
            return (T)(this[name].IfNull(defaultValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void Set(string name, object value)
        {
            this[name] = value;
        }

        private readonly BaseControl control;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ControlState(BaseControl control, StateBag viewState)
        {
            this.control = control;
            this.ViewState = viewState;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool Suspend()
        {
            bool oldValue = control.AllowCallbackScriptMonitoring;
            this.control.AllowCallbackScriptMonitoring = false;
            this.control.ScriptSuspended = true;
            Monitor.Enter(this.control);

            return oldValue;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Resume(bool oldValue)
        {
            this.control.AllowCallbackScriptMonitoring = oldValue;
            this.control.ScriptSuspended = false;
            Monitor.Exit(this.control);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Resume()
        {
            this.Resume(true);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object this[string key]
        {
            get
            {
                return this.ViewState[key];
            }
            set
            {
                this.ViewState[key] = value;
                this.SetDirectEventUpdate(key, value);
                
            }
        }

        private void CheckID()
        {
            if (((control.IDMode == Ext.Net.IDMode.Explicit || control.IDMode == Ext.Net.IDMode.Static) && !control.IsIdRequired) || control.IDMode == Ext.Net.IDMode.Ignore)
            {
                throw new Exception("You have to set widget's ID to call its methods (widget - " + control.GetType().ToString() + ")");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDirectEventUpdate(string key, object value)
        {
            if (((control.IsProxy && !control.ScriptSuspended) || (RequestManager.IsAjaxRequest && control.AllowCallbackScriptMonitoring && !control.IsDynamic)) && X.ControlsScripting)
            {
                PropertyInfo pi = control.GetType().GetProperty(key);

                if (pi == null)
                {
                    return;
                }

                object[] attrs = pi.GetCustomAttributes(typeof(DirectEventUpdateAttribute), true);

                if (attrs.Length > 0)
                {
                    this.CheckID();
                    this.control.CallbackValues[key] = value;
                    ((DirectEventUpdateAttribute)attrs[0]).RegisterScript(this.control, pi);
                }
                else
                {
                    ConfigOptionAttribute attr = ClientConfig.GetClientConfigAttribute(pi);
                    if (attr != null)
                    {
                        this.CheckID();
                        this.control.CallbackValues[key] = value;                        
                        this.control.AddScript(string.Format(DirectEventUpdateAttribute.AutoGenerateFormat, this.control.ClientID, JSON.Serialize(value), pi.Name.ToLowerCamelCase()));
                    }
                }
            }
        }
    }
}