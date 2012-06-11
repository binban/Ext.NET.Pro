/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Configuration;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class GlobalConfig : ConfigurationSection
    {
        private static GlobalConfig settings = ConfigurationManager.GetSection("extnet") as GlobalConfig;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static GlobalConfig Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new GlobalConfig();
                }

                return settings;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("ajaxViewStateMode", DefaultValue = ViewStateMode.Inherit, IsRequired = false)]
        [Description("")]
        public ViewStateMode AjaxViewStateMode
        {
            get
            {
                return (ViewStateMode)this["ajaxViewStateMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("directMethodProxy", DefaultValue = ClientProxy.Default, IsRequired = false)]
        [Description("")]
        public ClientProxy DirectMethodProxy
        {
            get
            {
                return (ClientProxy)this["directMethodProxy"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("idMode", DefaultValue = IDMode.Explicit, IsRequired = false)]
        [Description("")]
        public IDMode IDMode
        {
            get
            {
                return (IDMode)this["idMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("initScriptMode", DefaultValue = InitScriptMode.Inline, IsRequired = false)]
        [Description("")]
        public InitScriptMode InitScriptMode
        {
            get
            {
                return (InitScriptMode)this["initScriptMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("gzip", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool GZip
        {
            get
            {
                return (bool)this["gzip"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("cleanResourceUrl", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool CleanResourceUrl
        {
            get
            {
                return (bool)this["cleanResourceUrl"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("clientInitDirectMethods", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool ClientInitDirectMethods
        {
            get
            {
                return (bool)this["clientInitDirectMethods"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("renderScripts", DefaultValue = ResourceLocationType.Embedded, IsRequired = false)]
        [Description("")]
        public ResourceLocationType RenderScripts
        {
            get
            {
                return (ResourceLocationType)this["renderScripts"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("renderStyles", DefaultValue = ResourceLocationType.Embedded, IsRequired = false)]
        [Description("")]
        public ResourceLocationType RenderStyles
        {
            get
            {
                return (ResourceLocationType)this["renderStyles"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("resourcePath", DefaultValue = "~/Ext.Net/", IsRequired = false)]
        [Description("")]
        public string ResourcePath
        {
            get
            {
                return (string)this["resourcePath"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("scriptMode", DefaultValue = ScriptMode.Release, IsRequired = false)]
        [Description("")]
        public ScriptMode ScriptMode
        {
            get
            {
                return (ScriptMode)this["scriptMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("sourceFormatting", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool SourceFormatting
        {
            get
            {
                return (bool)this["sourceFormatting"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("stateProvider", DefaultValue = StateProvider.PostBack, IsRequired = false)]
        [Description("")]
        public StateProvider StateProvider
        {
            get
            {
                return (StateProvider)this["stateProvider"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("theme", DefaultValue = Theme.Default, IsRequired = false)]
        [Description("")]
        public Theme Theme
        {
            get
            {
                Theme theme = (Theme)this["theme"];
                return theme;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("quickTips", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool QuickTips
        {
            get
            {
                return (bool)this["quickTips"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("directEventUrl", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string DirectEventUrl
        {
            get
            {
                return (string)this["directEventUrl"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("locale", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string Locale
        {
            get
            {
                return (string)this["locale"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("directMethodNamespace", DefaultValue = ".direct", IsRequired = false)]
        [Description("")]
        public string DirectMethodNamespace
        {
            get
            {
                return (string)this["directMethodNamespace"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("disableViewState", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool DisableViewState
        {
            get
            {
                return (bool)this["disableViewState"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("rethrowAjaxExceptions", DefaultValue = false, IsRequired = false)]
        [Description("")]
        public bool RethrowAjaxExceptions
        {
            get
            {
                return (bool)this["rethrowAjaxExceptions"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("showWarningOnAjaxFailure", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool ShowWarningOnAjaxFailure
        {
            get
            {
                return (bool)this["showWarningOnAjaxFailure"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("designMode", DefaultValue = DesignMode.Enabled, IsRequired = false)]
        [Description("")]
        public DesignMode DesignMode
        {
            get
            {
                return (DesignMode)this["designMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("lazyMode", DefaultValue = LazyMode.Inherit, IsRequired = false)]
        [Description("")]
        public LazyMode LazyMode
        {
            get
            {
                return (LazyMode)this["lazyMode"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("submitDisabled", DefaultValue = true, IsRequired = false)]
        [Description("")]
        public bool SubmitDisabled
        {
            get
            {
                return (bool)this["submitDisabled"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("namespace", DefaultValue = "App", IsRequired = false)]
        [Description("")]
        public string Namespace
        {
            get
            {
                return (string)this["namespace"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("licenseKey", DefaultValue = "", IsRequired = false)]
        [Description("")]
        public string LicenseKey
        {
            get
            {
                return (string)this["licenseKey"];
            }
        }

        //[ConfigurationProperty("settings")]
        //public ExtNetConfigurationElementCollection Settings
        //{
        //    get
        //    {
        //        return (ExtNetConfigurationElementCollection)this["settings"];
        //    }
        //}
    }

    //public partial class ExtNetConfigurationElement : ConfigurationElement
    //{
    //    [ConfigurationProperty("key", IsRequired = true)]
    //    public string Key
    //    {
    //        get
    //        {
    //            return this["key"] as string;
    //        }
    //    }

    //    [ConfigurationProperty("value", IsRequired = false)]
    //    public string Value
    //    {
    //        get
    //        {
    //            return this["value"] as string;
    //        }
    //    }
    //}

    //public partial class ExtNetConfigurationElementCollection : ConfigurationElementCollection
    //{
    //    public ExtNetConfigurationElement this[int index]
    //    {
    //        get
    //        {
    //            return (ExtNetConfigurationElement)base.BaseGet(index);
    //        }
    //        set
    //        {
    //            if (base.BaseGet(index) != null)
    //            {
    //                base.BaseRemoveAt(index);
    //            }
    //            this.BaseAdd(index, value);
    //        }
    //    }

    //    public ExtNetConfigurationElement this[string name]
    //    {
    //        get
    //        {
    //            object value = base.BaseGet(name);
    //            return (value == null) ? null : (ExtNetConfigurationElement)value;

    //            //return (ExtNetConfigurationElement)base.BaseGet(name);
    //        }
    //        set
    //        {
    //            if (base.BaseGet(name) != null)
    //            {
    //                base.BaseRemove(name);
    //            }
    //            this.BaseAdd(value);
    //        }
    //    }

    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        return new ExtNetConfigurationElement();
    //    }

    //    protected override object GetElementKey(ConfigurationElement element)
    //    {
    //        return ((ExtNetConfigurationElement)element).Key;
    //    }
    //}
}