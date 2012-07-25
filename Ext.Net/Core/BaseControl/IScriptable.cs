/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web;

using Ext.Net.Utilities;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class BaseControl : IScriptable
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        const string SETEMPLATE= "{0}.{1}={2};";
        const string CALLTEMPLATE = "{0}.{1}({2});";

        private bool isProxy;

        internal virtual bool IsProxy
        {
            get { return this.isProxy; }
            set { this.isProxy = value; }
        }

        private bool generateMethodsCalling;
        internal virtual bool GenerateMethodsCalling
        {
            get { return this.generateMethodsCalling; }
            set { this.generateMethodsCalling = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string InstanceOf
        {
            get { return ""; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string DefineInstance()
        {
            return string.Format("Ext.define(\"{0}\", {1})", this.InstanceOf, this.InitialConfig);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public virtual string DefineInstance(string config)
        {
            return string.Format("Ext.define(\"{0}\", {1})", this.InstanceOf, config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceOf"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public virtual string DefineInstance(string instanceOf, string config)
        {
            return string.Format("Ext.define(\"{0}\", {1})", instanceOf, config);
        }

        private string directScript;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToConfig()
        {
            return ConfigScriptBuilder.Create(this).Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ToConfig(LazyMode mode)
        {
            return ConfigScriptBuilder.Create(this).Build(mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ToScript(bool selfRendering)
        {
            if (this.AlreadyRendered && this.directScript != null)
            {
                return this.directScript;
            }

            this.directScript = DefaultScriptBuilder.Create(this).Build(selfRendering);

            return this.directScript;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToScript()
        {
            return this.ToScript(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element)
        {
            return this.ToScript(mode, element, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element, bool selfRendering)
        {
            if (this.AlreadyRendered)
            {
                return this.directScript;
            }

            this.directScript = DefaultScriptBuilder.Create(this).Build(mode, element, selfRendering);

            return this.directScript;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element, int index)
        {
            return this.ToScript(mode, element, index, this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public string ToScript(RenderMode mode, string element, int index, bool selfRendering)
        {
            if (this.AlreadyRendered)
            {
                return this.directScript;
            }

            this.directScript = DefaultScriptBuilder.Create(this).Build(mode, element, index, selfRendering);

            return this.directScript;
        }

        /// <summary>
        /// Adds the script to be be called on the client.
        /// </summary>
        /// <param name="script">The script</param>
        [Description("Adds the script to be be called on the client.")]
        public virtual void AddScript(string script)
        {
            if (this.IsProxy || this.AlreadyRendered)
            {
                if (HttpContext.Current == null)
                {
                    ResourceManager.AddInstanceScript(script);
                    return;
                }

                ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);

                if (HttpContext.Current.CurrentHandler is Page && rm != null)
                {
                    rm.AddScript(script);
                }
                else
                {
                    ResourceManager.AddInstanceScript(script);
                }

                return;
            }

            if (script.IsNotEmpty() && !this.IsParentDeferredRender && this.Visible)
            {
                if (this.AlreadyRendered && this.HasResourceManager)
                {
                    this.ResourceManager.RegisterOnReadyScript(ResourceManager.ScriptOrderNumber, TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(script, this)));
                }
                else
                {
                    this.ProxyScripts.Add(ResourceManager.ScriptOrderNumber, TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(script, this)));    
                }
            }
        }

        /// <summary>
        /// Adds the script to be be called on the client. The script is formatted using the template and args.
        /// </summary>
        /// <param name="template">The script string template</param>
        /// <param name="args">The arguments to use with the template</param>
        [Description("Adds the script to be be called on the client. The script is formatted using the template and args.")]
        public virtual void AddScript(string template, params object[] args)
        {
            this.AddScript(args != null ? template.FormatWith(args) : template);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [Description("")]
        public virtual void Set(string name, object value)
        {
            this.Set(ScriptPosition.Auto, name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [Description("")]
        public virtual void Set(ScriptPosition position, string name, object value)
        {
            this.CallTemplate(position, BaseControl.SETEMPLATE, name, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        [Description("")]
        public virtual void Call(string name)
        {
            this.Call(name, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        public virtual void Call(string name, params object[] args)
        {
            this.Call(ScriptPosition.Auto, name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        public virtual void Call(ScriptPosition mode, string name, params object[] args)
        {
            this.CallTemplate(mode, BaseControl.CALLTEMPLATE, name, args);
        }


        /*  Protected
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        [Description("")]
        protected virtual void CallTemplate(string template)
        {
            this.CallTemplate(template, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallTemplate(string template, string name, params object[] args)
        {
            this.CallTemplate(ScriptPosition.Auto, template, name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="template"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallTemplate(ScriptPosition position, string template, string name, params object[] args)
        {
            if (((this.IDMode == Ext.Net.IDMode.Explicit || this.IDMode == Ext.Net.IDMode.Static) && !this.IsIdRequired) || this.IDMode == Ext.Net.IDMode.Ignore)
            {
                throw new Exception("You have to set widget's ID to call its methods");
            }
            
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    if (arg is string)
                    {
                        sb.AppendFormat("{0},", TokenUtils.ParseAndNormalize(arg.ToString(), this.SafeResourceManager  ));
                    }
                    else
                    {
                        sb.AppendFormat("{0},", JSON.Serialize(arg, JSON.ScriptConvertersInternal));
                    }
                }
            }

            string script = template.FormatWith(this.CallID, name, sb.ToString().LeftOfRightmostOf(','));

            switch (position)
            {
                case ScriptPosition.BeforeInit:
                    this.ResourceManager.RegisterBeforeClientInitScript(script);
                    break;
                case ScriptPosition.AfterInit:
                    this.ResourceManager.RegisterAfterClientInitScript(script);
                    break;
                default:
                    this.AddScript(script);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string SelfRender()
        {
            if (HttpContext.Current == null)
            {
                return "";
            }
            
            var pageHolder = new SelfRenderingPage();

            if (!(this is ResourceManager))
            {
                var newMgr = new ResourceManager();
                newMgr.RenderScripts = ResourceLocationType.None;
                newMgr.RenderStyles = ResourceLocationType.None;
                newMgr.IDMode = IDMode.Explicit;
                newMgr.IsSelfRender = true;            
                newMgr.IsDynamic = true;
                pageHolder.Controls.Add(newMgr);
            }

            this.IsSelfRender = true;            
            this.IDMode = IDMode.Explicit;               
            
            pageHolder.Controls.Add(this);

            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, true);
            this.IsSelfRender = false;

            return output.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string CallID
        {
            get
            {
                return this.ClientID;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ScriptPosition
    {
        /// <summary>
        /// 
        /// </summary>
        BeforeInit,

        /// <summary>
        /// 
        /// </summary>
        AfterInit,

        /// <summary>
        /// 
        /// </summary>
        Auto
    }
}