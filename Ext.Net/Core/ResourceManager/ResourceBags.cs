/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;

using Ext.Net.Utilities;
using System.Web;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ResourceManager
    {
        /*  PreClientInit
            -----------------------------------------------------------------------------------------------*/

        private List<string> scriptBeforeClientInitBag = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public List<string> ScriptBeforeClientInitBag
        {
            get
            {
                if(this.IsSelfRender && HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items["Ext.Net.GlobalScriptBeforeClientInit"] == null)
                    {
                        List<string> scriptBag = new List<string>();
                        HttpContext.Current.Items["Ext.Net.GlobalScriptBeforeClientInit"] = scriptBag;
                    }

                    return (List<string>)HttpContext.Current.Items["Ext.Net.GlobalScriptBeforeClientInit"];
                }

                return this.scriptBeforeClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterBeforeClientInitScript(string script)
        {
            this.ScriptBeforeClientInitBag.Add(script);
        }


        /*  ScriptClientSpecialInitBag
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> scriptClientSpecialInitBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientSpecialInitScriptRegistered(string key)
        {
            return this.scriptClientSpecialInitBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ScriptClientSpecialInitBag
        {
            get
            {
                return this.scriptClientSpecialInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterClientSpecialInitScript(string key, string script)
        {
            if (!this.IsClientSpecialInitScriptRegistered(key))
            {
                this.scriptClientSpecialInitBag.Add(key, script);
            }
        }


        /*  ClientInitScript
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> scriptClientInitBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientInitScriptRegistered(string key)
        {
            return this.scriptClientInitBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ScriptClientInitBag
        {
            get
            {
                return this.scriptClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterClientInitScript(string key, string script)
        {
            if (!this.IsClientInitScriptRegistered(key))
            {
                this.scriptClientInitBag.Add(key, script);
            }
        }


        /*  PostClientInit
            -----------------------------------------------------------------------------------------------*/

        private List<string> scriptAfterClientInitBag = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public List<string> ScriptAfterClientInitBag
        {
            get
            {
                if (this.IsSelfRender && HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items["Ext.Net.GlobalScriptAfterClientInit"] == null)
                    {
                        List<string> scriptBag = new List<string>();
                        HttpContext.Current.Items["Ext.Net.GlobalScriptAfterClientInit"] = scriptBag;
                    }

                    return (List<string>)HttpContext.Current.Items["Ext.Net.GlobalScriptAfterClientInit"];
                }
                return this.scriptAfterClientInitBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterAfterClientInitScript(string script)
        {
            this.ScriptAfterClientInitBag.Add(script);
        }


        /*  onReady
            -----------------------------------------------------------------------------------------------*/
        private static string scriptOrderkey = "Ext.Net.ScriptOrder";
        internal static int ScriptOrderNumber
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return 0;
                }
                if (HttpContext.Current.Items[ResourceManager.scriptOrderkey] == null)
                {
                    HttpContext.Current.Items[ResourceManager.scriptOrderkey] = new CounterStore();                    
                }

                return ((CounterStore)HttpContext.Current.Items[ResourceManager.scriptOrderkey]).counter++;
            }
        }

        internal static void ScriptOrderNextRange()
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            if (HttpContext.Current.Items[ResourceManager.scriptOrderkey] == null)
            {
                HttpContext.Current.Items[ResourceManager.scriptOrderkey] = new CounterStore();
            }

            CounterStore c = ((CounterStore)HttpContext.Current.Items[ResourceManager.scriptOrderkey]);
            c.counter = c.counter + 1000000;
        }

        internal static void ScriptOrderPrevRange()
        {
            if (HttpContext.Current == null)
            {
                return;
            }
            if (HttpContext.Current.Items[ResourceManager.scriptOrderkey] == null)
            {
                return;
            }

            CounterStore c = ((CounterStore)HttpContext.Current.Items[ResourceManager.scriptOrderkey]);
            c.counter = c.counter - 1000000;
        }

        /// <summary>
        /// Private class to avoid boxing/unboxing operation during placing to HttpContext.Current.Items
        /// </summary>
        private class CounterStore
        {
            public int counter = 0;
        }

        private readonly SortedList<long, string> scriptOnReadyBag = new SortedList<long, string>();

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public SortedList<long, string> ScriptOnReadyBag
        {
            get
            {
                return this.scriptOnReadyBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterOnReadyScript(string script)
        {
            this.RegisterOnReadyScript(ResourceManager.ScriptOrderNumber, script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="script"></param>
        [Description("")]
        internal void RegisterOnReadyScript(long orderNumber, string script)
        {
            if (script.IsNotEmpty())
            {
                this.ScriptOnReadyBag.Add(orderNumber, script);
            }
        }

        /*  JavaScript - Blocks
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientScriptBlock = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientScriptBlockRegistered(string key)
        {
            return this.clientScriptBlock.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientScriptBlockBag
        {
            get
            {
                return this.clientScriptBlock;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientScriptBlock(string resourceName)
        {
            this.RegisterClientScriptBlock(resourceName, this.GetWebResourceAsString(resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        [Description("")]
        public void RegisterClientScriptBlock(string key, string script)
        {
            if (!this.IsClientScriptBlockRegistered(key))
            {
                this.clientScriptBlock.Add(key, script);
            }
        }


        /*  JavaScript - Includes
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientScriptIncludeBag = new InsertOrderedDictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Description("")]
        public bool IsClientScriptIncludeRegistered(string key)
        {
            return (this.clientScriptIncludeBag.ContainsKey(key) || this.clientScriptIncludeInternalBag.ContainsKey(key));
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientScriptIncludeBag
        {
            get
            {
                return this.clientScriptIncludeBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string resourceName)
        {
            this.RegisterClientScriptInclude(this.GetType(), resourceName, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="force"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string resourceName, bool force)
        {
            this.RegisterClientScriptInclude(this.GetType(), resourceName, force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientScriptInclude(Type type, string resourceName)
        {
            this.RegisterClientScriptInclude(resourceName, this.GetWebResourceUrl(type, resourceName), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        /// <param name="force"></param>
        [Description("")]
        public void RegisterClientScriptInclude(Type type, string resourceName, bool force)
        {
            this.RegisterClientScriptInclude(resourceName, this.GetWebResourceUrl(type, resourceName), force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string key, string url)
        {
            this.RegisterClientScriptInclude(key, url, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        /// <param name="force"></param>
        [Description("")]
        public void RegisterClientScriptInclude(string key, string url, bool force)
        {
            if (!this.IsClientScriptIncludeRegistered(key))
            {
                if (!X.IsAjaxRequest)
                {
                    this.clientScriptIncludeBag.Add(key, this.ResolveUrlLink(url));
                }
                else
                {
                    this.RegisterClientScriptIncludeInternal(key, url, force);
                }
            }
        }


        /*  JavaScript - Includes Internal
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientScriptIncludeInternalBag = new InsertOrderedDictionary<string, string>();

        internal bool IsClientScriptIncludeInternalRegistered(string key)
        {
            return (this.clientScriptIncludeInternalBag.ContainsKey(key) || this.clientScriptIncludeBag.ContainsKey(key));
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal InsertOrderedDictionary<string, string> ClientScriptIncludeInternalBag
        {
            get
            {
                return this.clientScriptIncludeInternalBag;
            }
        }

        internal void RegisterClientScriptIncludeInternal(string resourceName)
        {
            this.RegisterClientScriptIncludeInternal(this.GetType(), resourceName, false);
        }

        internal void RegisterClientScriptIncludeInternal(string resourceName, bool force)
        {
            this.RegisterClientScriptIncludeInternal(this.GetType(), resourceName);
        }

        internal void RegisterClientScriptIncludeInternal(Type type, string resourceName)
        {
            this.RegisterClientScriptIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName), false);
        }

        internal void RegisterClientScriptIncludeInternal(Type type, string resourceName, bool force)
        {
            this.RegisterClientScriptIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName), force);
        }

        internal void RegisterClientScriptIncludeInternal(string key, string url)
        {
            this.RegisterClientScriptIncludeInternal(key, url, false);
        }

        internal void RegisterClientScriptIncludeInternal(string key, string url, bool force)
        {
            if (!this.IsClientScriptIncludeInternalRegistered(key))
            {
                this.clientScriptIncludeInternalBag.Add(key, (force ? "_force_" : "") + this.ResolveUrlLink(url));
            }
        }


        /*  StyleSheet - Blocks
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientStyleBlockBag = new InsertOrderedDictionary<string, string>();

        internal bool IsClientStyleBlockRegistered(string key)
        {
            return this.clientStyleBlockBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientStyleBlockBag
        {
            get
            {
                return this.clientStyleBlockBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleBlock(string resourceName)
        {
            this.RegisterClientStyleBlock(this.GetType(), resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleBlock(Type type, string resourceName)
        {
            this.RegisterClientStyleBlock(resourceName, this.GetWebResourceAsString(type, resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="styles"></param>
        [Description("")]
        public void RegisterClientStyleBlock(string key, string styles)
        {
            if (!this.IsClientStyleBlockRegistered(key))
            {
                if (!X.IsAjaxRequest)
                {
                    this.clientStyleBlockBag.Add(key, styles);
                }
                else
                {
                    this.RegisterClientStyleIncludeInternal(key, styles);
                }
            }
        }


        /*  StyleSheet - Includes
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientStyleIncludeBag = new InsertOrderedDictionary<string, string>();

        internal bool IsClientStyleIncludeRegistered(string key)
        {
            return this.clientStyleIncludeBag.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public InsertOrderedDictionary<string, string> ClientStyleIncludeBag
        {
            get
            {
                return this.clientStyleIncludeBag;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleInclude(string resourceName)
        {
            this.RegisterClientStyleInclude(this.GetType(), resourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="resourceName"></param>
        [Description("")]
        public void RegisterClientStyleInclude(Type type, string resourceName)
        {
            this.RegisterClientStyleInclude(resourceName, this.GetWebResourceUrl(type, resourceName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        [Description("")]
        public void RegisterClientStyleInclude(string key, string url)
        {
            if (!this.IsClientStyleIncludeRegistered(key))
            {
                this.clientStyleIncludeBag.Add(key, this.ResolveUrlLink(url));
            }
        }


        /*  StyleSheet - Includes Internal
            -----------------------------------------------------------------------------------------------*/

        private InsertOrderedDictionary<string, string> clientStyleIncludeInternalBag = new InsertOrderedDictionary<string, string>();
        private InsertOrderedDictionary<string, string> themeIncludeInternalBag = new InsertOrderedDictionary<string, string>();

        internal bool IsClientStyleIncludeInternalRegistered(string key)
        {
            return this.clientStyleIncludeInternalBag.ContainsKey(key);
        }

        internal bool IsThemeIncludeInternalRegistered(string key)
        {
            return this.themeIncludeInternalBag.ContainsKey(key);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal InsertOrderedDictionary<string, string> ClientStyleIncludeInternalBag
        {
            get
            {
                return this.clientStyleIncludeInternalBag;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal InsertOrderedDictionary<string, string> ThemeIncludeInternalBag
        {
            get
            {
                return this.themeIncludeInternalBag;
            }
        }

        internal void RegisterClientStyleIncludeInternal(string resourceName)
        {
            this.RegisterClientStyleIncludeInternal(this.GetType(), resourceName);
        }

        internal void RegisterClientStyleIncludeInternal(Type type, string resourceName)
        {
            this.RegisterClientStyleIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName));
        }

        internal void RegisterClientStyleIncludeInternal(string key, string url)
        {
            if (!this.IsClientStyleIncludeInternalRegistered(key))
            {
                this.clientStyleIncludeInternalBag.Add(key, this.ResolveUrlLink(url));
            }
        }

        internal void RegisterThemeIncludeInternal(Type type, string resourceName)
        {
            this.RegisterThemeIncludeInternal(resourceName, this.GetWebResourceUrl(type, resourceName));
        }

        internal void RegisterThemeIncludeInternal(string key, string url)
        {
            if (!this.IsThemeIncludeInternalRegistered(key))
            {
                this.themeIncludeInternalBag.Add(key, this.ResolveUrlLink(url));
            }
        }

        private static List<string> locales;

        internal static List<string> Locales
        {
            get
            {
                if (ResourceManager.locales == null)
                {
                    ResourceManager.locales = new List<string>("af bg ca cs da de el-GR en en-GB es et fa fi fr fr-CA he hr hu id it ja ko lt lv mk nl no nn-NO pl pt pt-BR pt-PT ro ru sk sl sr sr-Cyrl-CS sv-SE th tr uk vi zh-CN zh-TW".Split(' '));
                }

                return ResourceManager.locales;
            }
        }

        private static List<CultureInfo> supportedCultures;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static List<CultureInfo> SupportedCultures
        {
            get
            {
                if (ResourceManager.supportedCultures == null)
                {
                    List<CultureInfo> cultures = new List<CultureInfo>(ResourceManager.Locales.Count);

                    foreach (string c in ResourceManager.Locales)
                    {
                        cultures.Add(new CultureInfo(c));
                    }

                    ResourceManager.supportedCultures = cultures;
                }

                return ResourceManager.supportedCultures;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(CultureInfo culture)
        {
            bool parent;

            return ResourceManager.IsSupportedCulture(culture, out parent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="isParentSupported"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(CultureInfo culture, out bool isParentSupported)
        {
            string child = culture.ToString();
            string parent = (culture.IsNeutralCulture) ? culture.ToString() : culture.Parent.ToString();

            bool childSupport = ResourceManager.Locales.Contains(child);
            bool parentSupport = ResourceManager.Locales.Contains(parent);
            isParentSupported = !childSupport && parentSupport;

            return (childSupport || parentSupport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(string code)
        {
            bool parent;

            return ResourceManager.IsSupportedCulture(code, out parent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isParentSupported"></param>
        /// <returns></returns>
        [Description("")]
        public static bool IsSupportedCulture(string code, out bool isParentSupported)
        {
            isParentSupported = false;

            if (code == "Invariant")
            {
                return false;
            }

            try
            {
                return ResourceManager.IsSupportedCulture(new CultureInfo(code), out isParentSupported);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}