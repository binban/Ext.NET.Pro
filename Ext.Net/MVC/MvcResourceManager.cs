/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Text;
using System.Web;
using System;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public class MvcResourceManagerConfig
    {
        private bool cleanResourceUrl = true;

        /// <summary>
        /// 
        /// </summary>
        public bool CleanResourceUrl
        {
            get
            {
                return this.cleanResourceUrl;
            }
            set
            {
                this.cleanResourceUrl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ResourcePath
        {
            get;
            set;
        }

        private ScriptMode scriptMode = ScriptMode.Release;

        /// <summary>
        /// 
        /// </summary>
        public ScriptMode ScriptMode
        {
            get
            {
                return this.scriptMode;
            }
            set
            {
                this.scriptMode = value;
            }
        }

        private ResourceLocationType renderScripts = ResourceLocationType.Embedded;

        /// <summary>
        /// 
        /// </summary>
        public ResourceLocationType RenderScripts
        {
            get
            {
                return this.renderScripts;
            }
            set
            {
                this.renderScripts = value;
            }
        }

        private ResourceLocationType renderStyles = ResourceLocationType.Embedded;

        /// <summary>
        /// 
        /// </summary>
        public ResourceLocationType RenderStyles
        {
            get
            {
                return this.renderStyles;
            }
            set
            {
                this.renderStyles = value;
            }
        }

        private Theme theme = Theme.Default;

        /// <summary>
        /// 
        /// </summary>
        public Theme Theme
        {
            get
            {
                return this.theme;
            }
            set
            {
                this.theme = value;
            }
        }

        private bool quickTips = true;

        /// <summary>
        /// 
        /// </summary>
        public bool QuickTips
        {
            get
            {
                return this.quickTips;
            }
            set
            {
                this.quickTips = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Locale
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Namespace
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDMode IDMode
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string FormID
        {
            get;
            set;
        }
        
        private ResourceManagerListeners listeners;

        /// <summary>
        /// 
        /// </summary>
        public ResourceManagerListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new ResourceManagerListeners());
            }
            internal set
            {
                this.listeners = value;
            }
        }

        private ListenerCollection customListeners;

        /// <summary>
        /// 
        /// </summary>
        public ListenerCollection CustomListeners
        {
            get
            {
                return this.customListeners ?? (this.customListeners = new ListenerCollection());
            }
            internal set
            {
                this.customListeners = value;
            }
        }

        private ResourceManagerDirectEvents directEvents;

        /// <summary>
        /// 
        /// </summary>
        public ResourceManagerDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new ResourceManagerDirectEvents());
            }
            internal set
            {
                this.directEvents = value;
            }
        }

        private DirectEventCollection customDirectEvents;

        /// <summary>
        /// 
        /// </summary>
        public DirectEventCollection CustomDirectEvents
        {
            get
            {
                return this.customDirectEvents ?? (this.customDirectEvents = new DirectEventCollection());
            }
            internal set
            {
                this.customDirectEvents = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MvcResourceManager : ResourceManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onready"></param>
        protected override void AddInitAchorTag(StringBuilder onready)
        {
            onready.Append("<#:anchor id='ext.net.global.script.before' />");

            base.AddInitAchorTag(onready);

            if (this.RenderStyles != ResourceLocationType.None)
            {
                onready.Append("<#:anchor id='ext.net.global.icons' />");
            }
            onready.Append("<#:anchor id='ext.net.global.script.after' />");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string BuildStyleBlock()
        {
            string s = base.BuildStyleBlock();
            return s + (this.RenderStyles != ResourceLocationType.None ? "<#:anchor id='ext.net.global.styles' />" : "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ignoreRenderScriptsMode"></param>
        /// <returns></returns>
        public override string BuildScripts(bool ignoreRenderScriptsMode)
        {
            string s = base.BuildScripts(ignoreRenderScriptsMode);
            return s + (this.RenderScripts != ResourceLocationType.None ? "<#:anchor id='ext.net.global.scripts' />" : "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string SelfRender()
        {
            this.ShareConfig();
            return base.SelfRender();
        }

        /// <summary>
        /// 
        /// </summary>
        public static MvcResourceManagerConfig SharedConfig
        {
            get
            {
                var config = HttpContext.Current.Items["Ext.Net.GlobalManagerConfig"];
                return config == null ? new MvcResourceManagerConfig() : (MvcResourceManagerConfig)config;
            }
            set
            {
                HttpContext.Current.Items["Ext.Net.GlobalManagerConfig"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void ShareConfig()
        {
            HttpContext.Current.Items["Ext.Net.GlobalManagerConfig"] = new MvcResourceManagerConfig
            {
                CleanResourceUrl = this.CleanResourceUrl,
                ResourcePath = this.ResourcePath,
                ScriptMode = this.ScriptMode,
                RenderScripts = this.RenderScripts,
                RenderStyles = this.RenderStyles,
                Theme = this.Theme,
                QuickTips = this.QuickTips,
                Locale = this.Locale,
                Namespace = this.Namespace,
                IDMode = this.IDMode,
                FormID = this.FormID,
                Listeners = this.Listeners,
                CustomListeners = this.CustomListeners,
                DirectEvents = this.DirectEvents,
                CustomDirectEvents = this.CustomDirectEvents
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MvcResourceManagerBuilder : IHtmlString
    {
        private MvcResourceManagerConfig config;

        /// <summary>
        /// 
        /// </summary>
        public MvcResourceManagerBuilder()
        {
            this.config = new MvcResourceManagerConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public MvcResourceManagerBuilder(MvcResourceManagerConfig config)
        {
            this.config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cleanResourceUrl"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder CleanResourceUrl(bool cleanResourceUrl)
        {
            this.config.CleanResourceUrl = cleanResourceUrl;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourcePath"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder ResourcePath(string resourcePath)
        {
            this.config.ResourcePath = resourcePath;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptMode"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder ScriptMode(ScriptMode scriptMode)
        {
            this.config.ScriptMode = scriptMode;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderScripts"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder RenderScripts(ResourceLocationType renderScripts)
        {
            this.config.RenderScripts = renderScripts;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderStyles"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder RenderStyles(ResourceLocationType renderStyles)
        {
            this.config.RenderStyles = renderStyles;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder Theme(Theme theme)
        {
            this.config.Theme = theme;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quickTips"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder QuickTips(bool quickTips)
        {
            this.config.QuickTips = quickTips;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder Locale(string locale)
        {
            this.config.Locale = locale;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMode"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder IDMode(IDMode idMode)
        {
            this.config.IDMode = idMode;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder Namespace(string ns)
        {
            this.config.Namespace = ns;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public MvcResourceManagerBuilder FormID(string formID)
        {
            this.config.FormID = formID;
            return this;
        }

        public virtual MvcResourceManagerBuilder Listeners(Action<ResourceManagerListeners> action)
        {
            action(this.config.Listeners);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomListeners(Action<ListenerCollection> action)
        {
            action(this.config.CustomListeners);
            return this;
        }

        public virtual MvcResourceManagerBuilder DirectEvents(Action<ResourceManagerDirectEvents> action)
        {
            action(this.config.DirectEvents);
            return this;
        }

        public virtual MvcResourceManagerBuilder CustomDirectEvents(Action<DirectEventCollection> action)
        {
            action(this.config.CustomDirectEvents);
            return this;
        }

        #region IHtmlString

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString()
        {
            var mgr = new MvcResourceManager
            {
                CleanResourceUrl = config.CleanResourceUrl,
                ResourcePath = config.ResourcePath,
                Locale = config.Locale,
                FormID = config.FormID,
                Namespace = config.Namespace
            };

            if (config.ScriptMode != Ext.Net.ScriptMode.Release)
            {
                mgr.ScriptMode = config.ScriptMode;
            }

            if (config.RenderScripts != ResourceLocationType.Embedded)
            {
                mgr.RenderScripts = config.RenderScripts;
            }

            if (config.RenderStyles != ResourceLocationType.Embedded)
            {
                mgr.RenderStyles = config.RenderStyles;
            }

            if (config.Theme != Ext.Net.Theme.Default)
            {
                mgr.Theme = config.Theme;
            }

            if (!config.QuickTips)
            {
                mgr.QuickTips = config.QuickTips;
            }

            if (config.IDMode != Ext.Net.IDMode.Explicit)
            {
                mgr.IDMode = config.IDMode;
            }

            mgr.Listeners = config.Listeners;
            mgr.CustomListeners = config.CustomListeners;
            mgr.DirectEvents = config.DirectEvents;
            mgr.CustomDirectEvents = config.CustomDirectEvents;

            return mgr.SelfRender();
        }

        #endregion
    }
}
