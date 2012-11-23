/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ContentScriptBuilder : BaseScriptBuilder
    {
        private IList items;
        private IList layoutItems;
        private Control contentContainer;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected ContentScriptBuilder(BaseControl control) : base(control)
        {
            items = new List<object>(0);
            if (control is IItems)
            {
                items = ((IItems) control).ItemsList;

                layoutItems = items;
            }

            if (control is IContent)
            {
                contentContainer = ((IContent) control).ContentContainer;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build(selfRendering, false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Build(bool selfRendering, bool forceResources)
        {
            this.ForceResources = forceResources;
            if (this.script == null)
            {
                Page pageHolder = null;
                this.Control.TopDynamicControl = true;
                this.Control.ForceIdRendering = true;
                this.ResourceManager = Ext.Net.ResourceManager.GetInstance();

                if (selfRendering && this.Control.Page == null)
                {
                    pageHolder = new SelfRenderingPage();

                    ResourceManager rm = new ResourceManager(true);
                    rm.RenderScripts = ResourceLocationType.None;
                    rm.RenderStyles = ResourceLocationType.None;
                    rm.IDMode = IDMode.Explicit;
                    rm.IsDynamic = true;
                    pageHolder.Controls.Add(rm);
                    if (this.ResourceManager == null)
                    {
                        this.ResourceManager = rm;
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

                this.Control.ContentUpdated = this.Control.HasContent();
                AbstractContainer container = this.Control as AbstractContainer;
                if (container != null)
                {
                    sb.AppendFormat("{0}.removeAll();", this.Control.ClientID);
                }

                List<BaseControl> childControls = this.FindControls(this.Control, selfRendering, sb, null, null);

                if (selfRendering && pageHolder != null)
                {
                    pageHolder.Items["Ext.Net.DeferInitScriptGeneration"] = new object();
                }

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible)
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

                    if (this.Control.AutoDataBind)
                    {
                        this.Control.DataBind();
                    }

                    foreach (BaseControl c in newChildControls)
                    {
                        if (!childControls.Contains(c) && c.Visible)
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
                    if (c.Visible)
                    {
                        c.OnClientInit(true);
                        c.RegisterBeforeAfterScript();
                    }
                }

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible)
                    {
                        string initScript = c.BuildInitScript();
                        if (!string.IsNullOrEmpty(initScript))
                        {   if (this.layoutItems.Contains(c))
                            {
                                this.ScriptClientInitBag.Add(c.ClientInitID, this.Control.ClientID.ConcatWith(".add(", initScript, ");"));
                            }
                            else
                            {
                                initScript = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                                {"ref", c.IsLazy ? c.ClientInitID : "init_script"},
                                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                                            }, initScript);    
                                this.ScriptClientInitBag.Add(c.ClientInitID, initScript);
                            }
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

                foreach (KeyValuePair<long, string> script in this.ScriptOnReadyBag)
                {
                    sb.Append(script.Value);
                }
               
                if (container != null && container.Items.Count > 0)
                {
                    sb.AppendFormat("{0}.doLayout();", this.Control.ClientID);
                }

                sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                                                {"id", "init_script"}                            
                                            }));
                this.script = this.RegisterResources(sb.ToString());
            }

            return Transformer.NET.Html.HtmlTransformer.Transform(this.script);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool ExcludeControl(Control parent, Control control)
        {
            return Object.ReferenceEquals(this.Control, parent) && control != this.contentContainer && !this.items.Contains(control);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static ContentScriptBuilder Create(BaseControl control)
        {
            return new ContentScriptBuilder(control);
        }
    }
}