/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class ConfigScriptBuilder : BaseScriptBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        [Description("")]
        public ConfigScriptBuilder(BaseControl control) : base(control) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string Build()
        {
            return this.Build(LazyMode.Config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selfRendering"></param>
        /// <returns></returns>
        [Description("")]
        public override string Build(bool selfRendering)
        {
            return this.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string Build(LazyMode mode)
        {            
            if (this.script == null)
            {
                AbstractComponent cmp = this.Control as AbstractComponent;
                
                if (cmp != null)
                {
                    cmp.PreventRenderTo = true;
                }
                
                this.Control.IsDynamicLazy = true;
                this.Control.TopDynamicControl = true;

                StringBuilder sb = new StringBuilder();

                List<BaseControl> childControls = this.FindControls(this.Control, false, null, null, null);
                childControls.Insert(0, this.Control);                

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        c.DeferInitScriptGeneration = true;

                        if (c.AutoDataBind)
                        {
                            c.DataBind();
                        }
                    }
                }

                var html = this.Control is INoneContentable ? null : BaseScriptBuilder.RenderControl(this.Control, null);

                foreach (BaseControl c in childControls)
                {
                    c.DeferInitScriptGeneration = false;
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

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        c.OnClientInit(true);
                        c.RegisterBeforeAfterScript();
                    }
                }

                foreach (BaseControl c in childControls)
                {
                    if (c.Visible || Object.ReferenceEquals(c, this.Control))
                    {
                        if (Object.ReferenceEquals(c, this.Control))
                        {
                            string initScript;

                            if (this.Control is ICustomConfigSerialization)
                            {
                                initScript = ((ICustomConfigSerialization)c).ToScript(c);
                            }
                            else
                            {
                                initScript = mode == LazyMode.Instance ? "new {0}({1})".FormatWith(c.InstanceOf, c.InitialConfig) : c.InitialConfig;
                            }
                            
                            this.ScriptClientInitBag.Add(c.ClientInitID, initScript);
                        }
                        else
                        {
                            string script = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string>{                        
                                                {"ref", c.IsLazy ? c.ClientInitID : "init_script"},
                                                {"index", ResourceManager.ScriptOrderNumber.ToString()}
                                            }, c.BuildInitScript());

                            this.ScriptClientInitBag.Add(c.ClientInitID, script);
                        }
                        
                        c.AlreadyRendered = true;
                    }
                }

                if (this.ScriptClientInitBag.Count > 0)
                {
                    foreach (KeyValuePair<string, string> item in this.ScriptClientInitBag)
                    {
                        sb.Append(this.ScriptClientInitBag[item.Key]);
                    }
                }                
                
                var initToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                    {"id", "init_script"}                            
                });

                if (html.IsNotEmpty())
                {
                    sb.Insert(sb.ToString().IndexOf('{') + 1, "contentHtml:function(){{{0}{1}}},".FormatWith(html, initToken));
                }
                else
                {
                    sb.Append(initToken);
                }

                this.script = sb.ToString();
            }

            var config = Transformer.NET.Html.HtmlTransformer.Transform(this.script);                        

            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        protected override void CheckResources(BaseControl control, ResourceManager manager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="icons"></param>
        protected override void CheckIcon(BaseControl control, List<Icon> icons)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        [Description("")]
        public static ConfigScriptBuilder Create(BaseControl control)
        {
            return new ConfigScriptBuilder(control);
        }
    }
}
