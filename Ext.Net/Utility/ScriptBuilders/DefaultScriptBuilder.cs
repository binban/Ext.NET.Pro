/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DefaultScriptBuilder : BaseScriptBuilder
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected DefaultScriptBuilder(BaseControl control) : base(control) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build(RenderMode.Auto, null, null, selfRendering, false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Build(RenderMode mode, string element, bool selfRendering)
        {
            return this.Build(mode, element, null, selfRendering, false);
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
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering)
        {
            return this.Build(mode, element, index, selfRendering, false);
        }

        [Description("")]
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering, bool forceResources)
        {
            return this.Build(mode, element, index, selfRendering, forceResources, null, false, false);
        }

        [Description("")]
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering, bool forceResources, string method, bool forceLazy)
        {
            return this.Build(mode, element, index, selfRendering, forceResources, method, forceLazy, false);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="element"></param>
        /// <param name="index"></param>
        /// <param name="selfRendering"></param>
        /// <param name="forceResources"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string Build(RenderMode mode, string element, int? index, bool selfRendering, bool forceResources, string method, bool forceLazy, bool clearContainer)
        {
            this.ForceResources = forceResources;

            if (this.script == null)
            {
                AbstractComponent cmp = this.Control as AbstractComponent;

                bool isLazy = this.Control.IsLazy;

                if (mode == RenderMode.Auto)
                {
                    mode = isLazy ? RenderMode.AddTo : RenderMode.RenderTo;                    
                }                

                switch (mode)
                {
                    case RenderMode.RenderTo:
                        if (cmp != null)
                        {
                            if (string.IsNullOrEmpty(element))
                            {
                                element = TokenUtils.RawWrap("Ext.net.ResourceMgr.getRenderTarget()");
                            }

                            if (this.Control.IsLazy)
                            {
                                throw new Exception("Lazy control cannot be rendered with RenderTo mode.");
                            }

                            cmp.RenderTo = element;
                        }
                        break;
                    case RenderMode.AddTo:
                    case RenderMode.Replace:
                    case RenderMode.InsertTo:
                        if (cmp == null)
                        {
                            throw new Exception("AddTo mode can be applied to only a AbstractComponent.");
                        }

                        if (string.IsNullOrEmpty(element))
                        {
                            if (isLazy)
                            {
                                element = this.Control.ParentComponent.ClientID;
                            }
                            else
                            {
                                throw new Exception("You must specify an Element for the AddTo mode.");
                            }
                        }

                        if (mode == RenderMode.InsertTo && index == null)
                        {
                            throw new Exception("You have to provide the index for the InsertTo mode.");
                        }

                        cmp.PreventRenderTo = true;
                        break;
                }

                Page pageHolder = null;                
                this.Control.IsDynamicLazy = isLazy || (mode == RenderMode.AddTo || mode == RenderMode.InsertTo || mode == RenderMode.Replace);
                this.Control.TopDynamicControl = true;
                //this.Control.ForceIdRendering = true;
                this.Control.ForceLazy = forceLazy || this.Control.IsDynamicLazy;
                this.ResourceManager = Ext.Net.ResourceManager.GetInstance();

                if (selfRendering && this.Control.Page == null)
                {
                    pageHolder = new SelfRenderingPage();

                    ResourceManager newMgr = new ResourceManager(true);
                    newMgr.RenderScripts = ResourceLocationType.None;
                    newMgr.RenderStyles = ResourceLocationType.None;
                    newMgr.IDMode = IDMode.Explicit;
                    newMgr.IsDynamic = true;
                    pageHolder.Controls.Add(newMgr);
                    
                    if (this.ResourceManager == null)
                    {
                        this.ResourceManager = newMgr;
                    }

                    pageHolder.Controls.Add(this.Control);   
                }
                else if (selfRendering && this.Control.Page is ISelfRenderingPage)
                {
                    pageHolder = this.Control.Page;
                    ResourceManager newMgr = Ext.Net.Utilities.ControlUtils.FindControl<ResourceManager>(pageHolder);
                    if (this.ResourceManager == null)
                    {
                        this.ResourceManager = newMgr;
                    }
                    if (newMgr != null)
                    {
                        newMgr.IsDynamic = true;
                    }
                }

                StringBuilder sb = new StringBuilder();

                if (this.Control.ClientID.IsNotEmpty() && !this.Control.IsGeneratedID)
                {
                    sb.AppendFormat("Ext.net.ResourceMgr.destroyCmp(\"{0}\");", this.Control.ClientID);
                }

                if (clearContainer)
                {
                    if (mode == RenderMode.AddTo || mode == RenderMode.InsertTo)
                    {
                        string elementGet = element.Contains(".") ? element : "Ext.getCmp({0})".FormatWith(JSON.Serialize(element));
                        sb.AppendFormat("{0}.removeAll();", elementGet);
                    }
                    else if(mode != RenderMode.Replace)
                    {
                        sb.AppendFormat("Ext.net.getEl(\"{0}\").update();", element);
                    }
                }

                List<BaseControl> childControls = this.FindControls(this.Control, selfRendering, sb, null, null);
                childControls.Insert(0, this.Control);

                if (selfRendering && pageHolder != null)
                {
                    pageHolder.Items["Ext.Net.DeferInitScriptGeneration"] = new object();
                }
                
                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }
                    }
                }

                if (selfRendering)
                {
                    this.RegisterHtml(sb, pageHolder);

                    if (pageHolder != null)
                    {
                        pageHolder.Items["Ext.Net.DeferInitScriptGeneration"] = null;
                    }

                    List<BaseControl> newChildControls = this.FindControls(this.Control, false, sb, null, null);
                    newChildControls.Insert(0, this.Control);

                    foreach (BaseControl c in newChildControls)
                    {
                        if (!childControls.Contains(c) && (c.Visible || Object.ReferenceEquals(c, this.Control)))
                        {
                            if (c.AutoDataBind)
                            {
                                c.DataBind();
                            }
                        }
                    }

                    childControls = newChildControls;
                }

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        c.OnClientInit(true);
                        c.RegisterBeforeAfterScript();
                    }
                }

                string methodTemplate = string.Concat(".",method ?? "add","(");

                if (mode == RenderMode.InsertTo)
                {
                    methodTemplate = string.Concat(".", method ?? "insert", "(", index.Value, ",");
                }               
                
                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (Object.ReferenceEquals(c, this.Control) && (this.Control.IsLazy || this.Control.ForceLazy))
                        {
                            this.ScriptClientInitBag.Add(c.ClientInitID + "_BeforeScript", c.BeforeScript);
                            
                            string initScript = c.BuildInitScript();
                            string topScript = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                                {"ref", "top_dynamic_control"},
                                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                                            }, initScript);
                            this.ScriptClientInitBag.Add(c.ClientInitID, topScript);
                            
                            this.ScriptClientInitBag.Add(c.ClientInitID + "_AfterScript", c.AfterScript);
                        }
                        else
                        {
                            string tokenValue = ((c is LazyObservable && c.IsIdRequired) ? "window.{0}=".FormatWith(c.ClientID) : "") + c.BuildInitScript();
                            string script = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                                {"ref", c.IsLazy ? c.ClientInitID : "init_script"},
                                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                                            }, tokenValue);

                            this.ScriptClientInitBag.Add(c.ClientInitID, script);
                        }
                        
                        c.AlreadyRendered = true;

                        foreach (KeyValuePair<long, string> proxyScript in c.ProxyScripts)
                        {
                            if (proxyScript.Value.IsNotEmpty())
                            {
                                this.ScriptOnReadyBag.Add(proxyScript.Key, proxyScript.Value);
                            }
                        }
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        sb.Append(this.ScriptClientInitBag[item.Key]);
                    }
                }

                sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "init_script"}                            
                }));

                string topAnchor = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "top_dynamic_control"}                            
                });

                if (mode == RenderMode.AddTo || mode == RenderMode.InsertTo)
                {
                    string elementGet = element.Contains(".") ? element : "Ext.getCmp({0})".FormatWith(JSON.Serialize(element));
                    sb.Append(elementGet.ConcatWith(methodTemplate, topAnchor, ");"));
                }
                else if (mode == RenderMode.Replace)
                {
                    sb.Append("Ext.net._renderTo(arguments[0],".ConcatWith(topAnchor, ");"));
                }

                foreach (KeyValuePair<long, string> script in this.ScriptOnReadyBag)
                {
                    sb.Append(script.Value);
                }

                if (mode == RenderMode.Replace)
                {
                    string elementGet = element.Contains(".") ? element : "Ext.getCmp({0})".FormatWith(JSON.Serialize(element));
                    sb.Insert(0, elementGet + ".replace(function(){");
                    sb.Append("});");
                }
                
                this.script = this.RegisterResources(sb.ToString());
            }

            this.Control.ForceLazy = false;

            return Transformer.NET.Html.HtmlTransformer.Transform(this.script);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static DefaultScriptBuilder Create(BaseControl control)
        {
            return new DefaultScriptBuilder(control);
        }
    }
}
