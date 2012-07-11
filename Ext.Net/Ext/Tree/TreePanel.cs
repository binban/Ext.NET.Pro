/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Ext.Net
{
    /// <summary>
    /// The TreePanel provides tree-structured UI representation of tree-structured data.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TreePanel runat=\"server\" Title=\"Title\" Height=\"300\"></{0}:TreePanel>")]
    [ToolboxBitmap(typeof(TreePanel), "Build.ToolboxIcons.TreePanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("The TreePanel provides tree-structured UI representation of tree-structured data.")]
    public partial class TreePanel : TreePanelBase, IAjaxPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreePanel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "treepanel";
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
                return "Ext.tree.Panel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("raEditUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteEditUrl
        {
            get
            {
                return this.State.Get<string>("RemoteEditUrl", "");
            }
            set
            {
                this.State.Set("RemoteEditUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("raRemoveUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteRemoveUrl
        {
            get
            {
                return this.State.Get<string>("RemoteRemoveUrl", "");
            }
            set
            {
                this.State.Set("RemoteRemoveUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("raAppendUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteAppendUrl
        {
            get
            {
                return this.State.Get<string>("RemoteAppendUrl", "");
            }
            set
            {
                this.State.Set("RemoteAppendUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("raInsertUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteInsertUrl
        {
            get
            {
                return this.State.Get<string>("RemoteInsertUrl", "");
            }
            set
            {
                this.State.Set("RemoteInsertUrl", value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("raMoveUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteMoveUrl
        {
            get
            {
                return this.State.Get<string>("RemoteMoveUrl", "");
            }
            set
            {
                this.State.Set("RemoteMoveUrl", value);
            }
        }

        private static readonly object EventSubmit = new object();
        private static readonly object EventEdit = new object();
        private static readonly object EventRemove = new object();
        private static readonly object EventAppend = new object();
        private static readonly object EventMove = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void SubmitEventHandler(object sender, SubmitEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteEditEventHandler(object sender, RemoteEditEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteActionEventHandler(object sender, RemoteActionEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteAppendEventHandler(object sender, RemoteAppendEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteMoveEventHandler(object sender, RemoteMoveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event SubmitEventHandler Submit
        {
            add
            {
                this.Events.AddHandler(EventSubmit, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventSubmit, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteEditEventHandler RemoteEdit
        {
            add
            {
                this.Events.AddHandler(EventEdit, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventEdit, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteActionEventHandler RemoteRemove
        {
            add
            {
                this.Events.AddHandler(EventRemove, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventRemove, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteAppendEventHandler RemoteAppend
        {
            add
            {
                this.Events.AddHandler(EventAppend, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAppend, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteMoveEventHandler RemoteMove
        {
            add
            {
                this.Events.AddHandler(EventMove, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventMove, value);
            }
        }

        internal virtual void OnSubmit(SubmitEventArgs e)
        {
            SubmitEventHandler handler = (SubmitEventHandler)Events[EventSubmit];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteEdit(RemoteEditEventArgs e)
        {
            RemoteEditEventHandler handler = (RemoteEditEventHandler)Events[EventEdit];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteRemove(RemoteActionEventArgs e)
        {
            RemoteActionEventHandler handler = (RemoteActionEventHandler)Events[EventRemove];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteAppend(RemoteAppendEventArgs e)
        {
            RemoteAppendEventHandler handler = (RemoteAppendEventHandler)Events[EventAppend];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteMove(RemoteMoveEventArgs e)
        {
            RemoteMoveEventHandler handler = (RemoteMoveEventHandler)Events[EventMove];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        bool initParams = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.initParams)
            {
                return;
            }

            if (this.RemoteExtraParams.Count > 0)
            {
                if (this.Listeners.BeforeRemoteAction.IsDefault)
                {
                    this.Listeners.BeforeRemoteAction.Fn = this.BuildRemoteParams(this.RemoteExtraParams, null, true);
                }
                else
                {
                    if (this.Listeners.BeforeRemoteAction.Fn.IsNotEmpty())
                    {
                        this.Listeners.BeforeRemoteAction.Fn = this.BuildRemoteParams(this.RemoteExtraParams, this.Listeners.BeforeRemoteAction.Fn, true);
                    }
                    else
                    {
                        this.Listeners.BeforeRemoteAction.Fn = this.BuildRemoteParams(this.RemoteExtraParams, this.Listeners.BeforeRemoteAction.Handler, false);
                    }
                }
            }

            this.initParams = true;
        }

        private string BuildRemoteParams(ParameterCollection parameters, string userHandler, bool isFn)
        {
            StringBuilder sb = new StringBuilder("function(tree, node, o, action){");

            sb.AppendFormat("Ext.apply(o.params,{0});", parameters.ToJson());

            if (userHandler.IsNotEmpty())
            {
                sb.Append(userHandler);

                if (isFn)
                {
                    sb.Append("(tree, node, o, action);");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        private string BuildParams(ParameterCollection parameters, string userHandler, bool isFn)
        {
            StringBuilder sb = new StringBuilder("function(loader,node){if (!loader.baseParams){loader.baseParams = {};};");

            sb.AppendFormat("Ext.apply(loader.baseParams,{0});", parameters.ToJson());

            if (userHandler.IsNotEmpty())
            {
                sb.Append(userHandler);

                if (isFn)
                {
                    sb.Append("(loader,node);");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }
        
        private TreePanelListeners listeners;

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
        public TreePanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TreePanelListeners();
                }

                return this.listeners;
            }
        }


        private TreePanelDirectEvents directEvents;

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
        public TreePanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TreePanelDirectEvents(this);
                }

                return this.directEvents;
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
            bool result = base.LoadPostData(postDataKey, postCollection);
            string val = postCollection[this.ConfigID.ConcatWith("_SM")];

            if (val != null && this.SelectionModel.Primary != null)
            {
                List<SubmittedNode> nodes = JSON.Deserialize<List<SubmittedNode>>(val, new CamelCasePropertyNamesContractResolver());
                ((TreeSelectionModel)this.SelectionModel.Primary).SelectedNodes = nodes;
            }

            val = postCollection[this.ConfigID.ConcatWith("_CheckNodes")];
            if (val != null)
            {
                List<SubmittedNode> nodes = JSON.Deserialize<List<SubmittedNode>>(val, new CamelCasePropertyNamesContractResolver());
                this.CheckedNodes = nodes;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        protected virtual void RegisterNodesIcons(NodeCollection nodes)
        {
            if (ResourceManager.HasResourceManager)
            {
                foreach (Node node in nodes)
                {
                    if (node.Icon != Icon.None)
                    {
                        ResourceManager.GetInstance().RegisterIcon(node.Icon);
                    }

                    if (node.Children.Count > 0)
                    {
                        this.RegisterNodesIcons(node.Children);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <param name="extraParams"></param>
        [Description("")]
        public void RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            bool success = true;
            string msg = null;

            Response response = new Response();

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                string data = null;

                if (this.DirectConfig != null)
                {
                    JToken serviceToken = this.DirectConfig.SelectToken("config.serviceParams", false);

                    if (serviceToken != null)
                    {
                        data = JSON.ToString(serviceToken);
                    }
                }

                switch(eventArgument)
                {
                    case "nodeload":
                        //NodeLoadEventArgs e = new NodeLoadEventArgs(extraParams);
                        //PageTreeLoader loader = (PageTreeLoader) this.Loader.Primary;
                        //loader.OnNodeLoad(e);
                        //TreeNodeCollection nodes = e.Nodes;
                        //success = e.Success;
                        //msg = e.ErrorMessage;
                        //response.Data = nodes != null ? nodes.ToJson() : null;
                        break;
                    case "submit":
                        SubmitEventArgs se = new SubmitEventArgs(extraParams, JSON.Deserialize<SubmittedNode>(data, new CamelCasePropertyNamesContractResolver()));
                        this.OnSubmit(se);
                        break;
                    case "raEdit":
                        RemoteEditEventArgs rr = new RemoteEditEventArgs(data,extraParams);
                        this.OnRemoteEdit(rr);
                        success = rr.Accept;
                        msg = rr.RefusalMessage;
                        break;
                    case "raRemove":
                        RemoteActionEventArgs rrm = new RemoteActionEventArgs(data, extraParams);
                        this.OnRemoteRemove(rrm);
                        success = rrm.Accept;
                        msg = rrm.RefusalMessage;
                        break;
                    case "raInsert":
                    case "raAppend":
                        RemoteAppendEventArgs ra = new RemoteAppendEventArgs(eventArgument == "raInsert", data, extraParams);
                        this.OnRemoteAppend(ra);
                        success = ra.Accept;
                        msg = ra.RefusalMessage;
                        break;
                    case "raMove":
                        RemoteMoveEventArgs rm = new RemoteMoveEventArgs(data, extraParams);
                        this.OnRemoteMove(rm);
                        success = rm.Accept;
                        msg = rm.RefusalMessage;
                        break;
                }
            }
            catch (Exception ex)
            {
                success = false;
                msg = this.IsDebugging ? ex.ToString() : ex.Message;

                if (this.ResourceManager.RethrowAjaxExceptions)
                {
                    throw;
                }
            }

            response.Success = success;
            response.Message = msg;

            ResourceManager.ServiceResponse = response;
        }
    }
}