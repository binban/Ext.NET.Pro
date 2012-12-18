/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class Task : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Task() { }

        /// <summary>
        /// (optional) The TaskID.
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("(optional) The TaskID.")]
        public virtual string TaskID
        {
            get
            {
                return this.State.Get<string>("TaskID", "");
            }
            set
            {
                this.State.Set("TaskID", value);
            }
        }

        /// <summary>
        /// True to auto run task (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(true)]
        [Description("True to auto run task (defaults to false).")]
        public virtual bool AutoRun
        {
            get
            {
                return this.State.Get<bool>("AutoRun", true);
            }
            set
            {
                this.State.Set("AutoRun", value);
            }
        }

        /// <summary>
        /// True to wait previous request.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(false)]
        [Description("True to wait previous request.")]
        public virtual bool WaitPreviousRequest
        {
            get
            {
                return this.State.Get<bool>("WaitPreviousRequest", false);
            }
            set
            {
                this.State.Set("WaitPreviousRequest", value);
            }
        }

        /// <summary>
        /// The frequency in milliseconds with which the task should be executed (defaults to 1000)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(1000)]
        [Description("The frequency in milliseconds with which the task should be executed (defaults to 1000)")]
        public virtual int Interval
        {
            get
            {
                return this.State.Get<int>("Interval", 1000);
            }
            set
            {
                this.State.Set("Interval", value);
            }
        }

        /// <summary>
        /// (optional) An array of arguments to be passed to the function specified by run
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("(optional) An array of arguments to be passed to the function specified by run")]
        public virtual string[] Args
        {
            get
            {
                return this.State.Get<string[]>("Args", null);
            }
            set
            {
                this.State.Set("Args", value);
            }
        }

        /// <summary>
        /// (optional) The scope in which to execute the run function.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [NotifyParentProperty(true)]
        [Description("(optional) The scope in which to execute the run function.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", "this");
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// (optional) The length of time in milliseconds to execute the task before stopping automatically (defaults to indefinite).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(0)]
        [Description("(optional) The length of time in milliseconds to execute the task before stopping automatically (defaults to indefinite).")]
        public virtual int Duration
        {
            get
            {
                return this.State.Get<int>("Duration", 0);
            }
            set
            {
                this.State.Set("Duration", value);
            }
        }

        /// <summary>
        /// (optional) The number of times to execute the task before stopping automatically (defaults to indefinite).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(0)]
        [Description("(optional) The number of times to execute the task before stopping automatically (defaults to indefinite).")]
        public virtual int Repeat
        {
            get
            {
                return this.State.Get<int>("Repeat", 0);
            }
            set
            {
                this.State.Set("Repeat", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("serverRun", JsonMode.Raw)]
        [Description("")]
        protected string DirectEventProxy
        {
            get
            {
                if (!this.DirectEvents.Update.IsDefault)
                {
                    string configObject = new ClientConfig().SerializeInternal(this.DirectEvents.Update, this.DirectEvents.Update.Owner);

                    StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

                    cfgObj.Append(configObject);
                    if (this.DirectEvents.Update.HandlerIsNotEmpty)
                    {
                        cfgObj.Remove(cfgObj.Length - 1, 1);
                        cfgObj.AppendFormat("{0}eventType: \"{1}\"", configObject.Length > 2 ? "," : "", AjaxRequestType.PostBack.ToString().ToLowerInvariant());
                        cfgObj.AppendFormat(",action:\"{0}\"", this.DirectEvents.Update.HandlerName);
                        cfgObj.Append("}");
                    }

                    return new JFunction(string.Concat("return ", cfgObj.ToString(), ";")).ToString();
                }
                
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("clientRun", JsonMode.Raw)]
        [Description("")]
        protected string ListenerProxy
        {
            get
            {
                if (!this.Listeners.Update.IsDefault)
                {
                    return this.Listeners.Update.ToString();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [ConfigOption("onstart", typeof(FunctionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public string OnStart
        {
            get
            {
                return this.State.Get<string>("OnStart", "");
            }
            set
            {
                this.State.Set("OnStart", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [ConfigOption("onstop", typeof(FunctionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public string OnStop
        {
            get
            {
                return this.State.Get<string>("OnStop", "");
            }
            set
            {
                this.State.Set("OnStop", value);
            }
        }

        private TaskListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public TaskListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TaskListeners();
                }

                return this.listeners;
            }
        }

        private TaskDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side DirectEventHandlers")]
        public TaskDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TaskDirectEvents();
                }

                return this.directEvents;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TaskCollection : BaseItemCollection<Task> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TaskListeners : BaseItem
    {
        private SimpleListener update;

        /// <summary>
        /// The function to execute each time the task is run. The function will be called at each interval.
        /// </summary>
        [ConfigOption("clientRun", JsonMode.Raw)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The function to execute each time the task is run. The function will be called at each interval.")]
        public virtual SimpleListener Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new SimpleListener();
                }

                return this.update;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override object SaveViewState()
        {
            return this.Update.SaveViewState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [Description("")]
        public override void LoadViewState(object state)
        {
            this.Update.LoadViewState(state);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TaskDirectEvents : BaseItem
    {
        private ComponentDirectEvent update;

        /// <summary>
        /// The function to execute each time the task is run. The function will be called at each interval.
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The function to execute each time the task is run. The function will be called at each interval.")]
        public virtual ComponentDirectEvent Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new ComponentDirectEvent();
                }

                return this.update;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override object SaveViewState()
        {
            return this.Update.SaveViewState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [Description("")]
        public override void LoadViewState(object state)
        {
            this.Update.LoadViewState(state);
        }
    }
}