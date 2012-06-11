/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Provides the ability to execute one or more arbitrary tasks in a multithreaded manner.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TaskManager runat=\"server\"></{0}:TaskManager>")]
    [ToolboxBitmap(typeof(TaskManager), "Build.ToolboxIcons.TaskManager.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Provides the ability to execute one or more arbitrary tasks in a multithreaded manner.")]
    public partial class TaskManager : Observable, IAjaxPostBackEventHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TaskManager() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.TaskManager";
            }
        }

        /// <summary>
        /// The minimum precision in milliseconds supported by this TaskRunner instance (defaults to 10)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(10)]
        [Description("The minimum precision in milliseconds supported by this TaskRunner instance (defaults to 10)")]
        public virtual int Interval
        {
            get
            {
                object obj = this.ViewState["Interval"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                this.ViewState["Interval"] = value;
            }
        }

        /// <summary>
        /// The start delay in milliseconds for autorun tasks
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(50)]
        [Description("The start delay in milliseconds for autorun tasks")]
        public virtual int AutoRunDelay
        {
            get
            {
                object obj = this.ViewState["AutoRunDelay"];
                return (obj == null) ? 50 : (int)obj;
            }
            set
            {
                this.ViewState["AutoRunDelay"] = value;
            }
        }

        private TaskCollection tasks;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("tasksConfig", JsonMode.AlwaysArray)]
        [Category("3. TaskManager")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual TaskCollection Tasks
        {
            get
            {
                if (this.tasks == null)
                {
                    this.tasks = new TaskCollection();
                    this.tasks.AfterItemAdd += this.AfterTaskAdd;
                }

                return this.tasks;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterTaskAdd(Task task)
        {
            task.Owner = this;
            task.Listeners.Update.Owner = this;
            task.DirectEvents.Update.Owner = this;
        }

        void IAjaxPostBackEventHandler.RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            string action = eventArgument;

            foreach (Task task in this.Tasks)
            {
                if (!task.DirectEvents.Update.IsDefault && task.DirectEvents.Update.HandlerName == action)
                {
                    task.DirectEvents.Update.OnEvent(new DirectEventArgs(extraParams));
                }
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        [Meta]
        [Description("")]
        public void AddTask(Task task)
        {
            RequestManager.EnsureDirectEvent();
            task.Owner = this;
            task.Listeners.Update.Owner = this;
            task.DirectEvents.Update.Owner = this;
            this.Call("addTask", new JRawValue(new ClientConfig().Serialize(task)));
        }

		/// <summary>
		/// 
		/// </summary>
        [Meta]
        [Description("")]
        public void RemoveTask(int index)
        {
            this.Call("removeTask", index);
        }

		/// <summary>
		/// 
		/// </summary>
        [Meta]
        [Description("")]
        public void RemoveTask(string name)
        {
            this.Call("removeTask", name);
        }


        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void StartAll()
        {
            this.Call("startAll");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void StopAll()
        {
            this.Call("stopAll");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("")]
        public void StartTask(int index)
        {
            this.Call("startTask", index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("")]
        public void StopTask(int index)
        {
            this.Call("stopTask", index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [Meta]
        [Description("")]
        public void StartTask(string name)
        {
            this.Call("startTask", name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [Meta]
        [Description("")]
        public void StopTask(string name)
        {
            this.Call("stopTask", name);
        }
    }
}