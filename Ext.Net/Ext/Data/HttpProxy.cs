/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// An implementation of DataProxy that reads a data object from a object configured to reference a certain URL.
    /// 
    /// Note that this class cannot be used to retrieve data from a domain other
    /// than the domain from which the running page was served.
    ///
    /// For cross-domain access to remote data, use a ScriptTagProxy.
    /// 
    /// Be aware that to enable the browser to parse an XML document,
    /// the server must set the Content-Type header in the HTTP response to "text/xml".
    /// </summary>
    [Meta]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Description("An implementation of DataProxy that reads a data object from a object configured to reference a certain URL.")]
    public partial class HttpProxy : DataProxy
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HttpProxy() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.data.HttpProxy";
            }
        }

        /// <summary>
        /// Whether a new request should abort any pending requests. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Whether a new request should abort any pending requests. (defaults to false)")]
        public virtual bool AutoAbort
        {
            get
            {
                object obj = this.ViewState["AutoAbort"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoAbort"] = value;
            }
        }

        private ParameterCollection headers;

        /// <summary>
        /// An object containing request headers which are added to each request made by this object.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing request headers which are added to each request made by this object.")]
        public virtual ParameterCollection Headers
        {
            get
            {
                if (this.headers == null)
                {
                    this.headers = new ParameterCollection();
                }

                return this.headers;
            }
        }

        /// <summary>
        /// True to add a unique cache-buster param to GET requests. (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to add a unique cache-buster param to GET requests. (defaults to true)")]
        public virtual bool DisableCaching
        {
            get
            {
                object obj = this.ViewState["DisableCaching"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DisableCaching"] = value;
            }
        }

        /// <summary>
        /// The default HTTP method to be used for requests.
        /// (defaults to undefined; if not set but params are present will use "POST," otherwise "GET.")
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The default HTTP method to be used for requests.")]
        public virtual HttpMethod Method
        {
            get
            {
                object obj = this.ViewState["Method"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["Method"] = value;
            }
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests. (defaults to 30000)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [DefaultValue(30000)]
        [NotifyParentProperty(true)]
        [Description("The timeout in milliseconds to be used for requests. (defaults to 30000)")]
        public virtual int Timeout
        {
            get
            {
                object obj = this.ViewState["Timeout"];
                return obj == null ? 30000 : (int)obj;
            }
            set
            {
                this.ViewState["Timeout"] = value;
            }
        }

        /// <summary>
        /// The default URL to be used for requests to the server.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Editor(typeof(System.Web.UI.Design.UrlEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Description("The default URL to be used for requests to the server.")]
        public virtual string Url
        {
            get
            {
                return (string)this.ViewState["Url"] ?? "";
            }
            set
            {
                this.ViewState["Url"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string UrlProxy
        {
            get
            {
                Control c = this.Store;

                if (c == null || c.Page is Ext.Net.ISelfRenderingPage)
                {
                    c = new Control();
                }
                return XControl.ResolveUrl(c, this.Url);
            }
        }

        /// <summary>
        /// Send params as JSON object
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Send params as JSON object")]
        public virtual bool Json
        {
            get
            {
                object obj = this.ViewState["Json"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Json"] = value;
            }
        }
    }
}
