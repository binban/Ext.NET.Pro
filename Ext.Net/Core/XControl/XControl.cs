/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    [Designer(typeof(ExtControlDesigner))]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public abstract partial class XControl : WebControl, ICompositeControlDesignerAccessor, IXObject
    {
        /*  About
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The product name
        /// </summary>
        [Category("0. About")]
        public string ProductName
        {
            get { return "Ext.NET"; }
        }

        /// <summary>
        /// The version name
        /// </summary>
        [Category("0. About")]
        public string VersionName
        {
            get 
            { 
                return this.IsPro ? "Pro" : "Community"; 
            }
        }

        internal string Stamp
        {
            get
            {
                if (this.DesignMode)
                {
                    return "";
                }

                return "{0} [{1}]. Version {2}.".FormatWith(this.ProductName, this.VersionName, this.Version);
            }
        }

        /// <summary>
        /// The Version number of this build
        /// </summary>
        [Category("0. About")]
        public virtual string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        internal bool IsPro
        {
            get
            {
                return true;
            }
        }


        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        private string dynamicID;
        private bool isDynamicIDSet;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected string DynamicID
        {
            get
            {
                if (this.dynamicID.IsEmpty())
                {
                    this.dynamicID = "id" + Guid.NewGuid().ToString().Replace("-", "");
                }

                return this.dynamicID;
            }
        }

        internal void EnsureDynamicID()
        {
            if (this.IsDynamic && this.IsGeneratedID && !this.isDynamicIDSet)
            {
                this.isDynamicIDSet = true;
                this.ID = this.DynamicID;
                this.IsGeneratedID = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        public override string ID
        {
            get
            {
                if (this.IsDynamic && this.IsGeneratedID)
                {
                    this.EnsureDynamicID();
                    return this.DynamicID;
                }

                return base.ID;
            }
            set
            {
                this.IsGeneratedID = false;
                base.ID = value;
            }
        }

        /// <summary>
        /// An itemId can be used as an alternative way to get a reference to a component when no object reference is available.
        /// </summary>
        [Meta]
        [ConfigOption("itemId")]
        [DefaultValue("")]
        [Description("An itemId can be used as an alternative way to get a reference to a component when no object reference is available.")]
        public virtual string ItemID
        {
            get
            {
                return (string)this.ViewState["ItemID"] ?? "";
            }
            set
            {
                this.ViewState["ItemID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string ClientID
        {
            get
            {
                this.EnsureDynamicID();

                if (this.ClientNamespace.IsNotEmpty() && this.ItemID.IsNotEmpty())
                {
                    return this.AddNamespaceToID(this.ItemID);
                }

                return this.AddNamespaceToID(this.ConfigID);
            }
        }

        public virtual string ClientNSID
        {
            get
            {
                this.EnsureDynamicID();

                if (this.ClientNamespace.IsNotEmpty() && this.ItemID.IsNotEmpty())
                {
                    return this.AddNamespaceToID(this.ItemID, true);
                }

                return this.AddNamespaceToID(this.ConfigID, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ConfigID
        {
            get
            {
                this.EnsureDynamicID();

                switch (this.IDMode)
                {
                    case IDMode.Static:
                        return this.ID;
                    case IDMode.Explicit:
                        return this.IsGeneratedID ? this.BaseClientID : this.ID;
                    case IDMode.Predictable:
                        Control parent = this.NamingContainer;

                        return parent != null ? string.Format("{0}_{1}", parent.ID, this.ID) : this.ID;
                    case IDMode.Parent:
                        string id2 = "";

                        Control nc = this.NamingContainer;

                        if (nc != null)
                        {
                            Control nc_parent = nc.Parent;

                            if (nc_parent != null)
                            {
                                Control nc_parent_parent = nc_parent.Parent;

                                bool isCmp = nc_parent is Component;
                                string parentID = isCmp ? (nc_parent as Component).ConfigID : nc_parent.ID;

                                id2 = (nc_parent_parent != null && nc_parent_parent is IContent) ? (nc_parent_parent as Component).ConfigID : parentID;
                            }
                        }

                        return !string.IsNullOrEmpty(id2) ? string.Format("{0}_{1}", id2, this.ID) : this.ID;
                    default:
                        return this.BaseClientID;
                }
            }
        }

        /// <summary>
        /// The base .ClientID property derived from .NET Framework
        /// </summary>
        [Description("The base .ClientID property derived from .NET Framework")]
        public virtual string BaseClientID
        {
            get
            {
                return base.ClientID;
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("id")]
        [DefaultValue("")]
        protected virtual string ConfigIDProxy
        {
            get
            {
                if (!this.IsIdRequired && (this.IDMode == IDMode.Ignore || ((this.IDMode == IDMode.Explicit || this.IDMode == IDMode.Client) && this.IsGeneratedID)))
                {
                    return "";
                }

                if (this.ConfigID == null)
                {
                    return "";
                }

                return this.ConfigID;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasOwnIDMode
        {
            get
            {
                return this.ViewState["IDMode"] != null;
            }
        }

        /// <summary>
        /// IDMode specifies how the ConfigID/ClientID of the control should be generated and rendered to client.
        /// The IDMode property is defined in Ext.Net.XControl, the base class for all Ext.NET controls.
        /// The related things: ID - the native ASP.NET System.Web.UI.Control property, ID is used to access the control on server side;
        /// ClientID - the native ASP.NET System.Web.UI.Control.ClientID property has been overrode in the Ext.Net.XControl class, 
        /// ClientID is used on client as a reference which might be used to access the respective control�s JavaScript instance on client side. 
        /// ClientID is the concatenation of Namespace and ConfigID or Namespace and ItemID if ItemID is explicitly specified and 
        /// there is at least one Namespace explicitly specified in the chain from the control and all its parent controls or in ResourceManager;
        /// BaseClientID - the base ClientID property, i.e. the native ASP.NET System.Web.UI.Control.ClientID property; 
        /// ConfigID - The Ext.Net.XControl property which means the client side �id� config option, 
        /// so, you can access the respective control�s JavaScript instance on client using the Ext.getCmp method.
        /// How to set up IDMode: application level - �idMode� option of �extnet� section in Web.config. Please see the sample Web.config in README, 
        /// page level - IDMode of ResourceManager, control level - IDMode of Control.
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(IDMode.Inherit)]
        [NotifyParentProperty(true)]
        [Description("IDMode specifies how the ConfigID/ClientID of the control should be generated and rendered to client.")]
        public virtual IDMode IDMode
        {
            get
            {
                object obj = this.ViewState["IDMode"];

                IDMode mode = IDMode.Inherit;

                if (obj != null)
                {
                    mode = (IDMode)obj;
                }
                else if (!this.StopIDModeInheritance)
                {
                    XControl control = this.ParentWebControl;

                    if (control != null)
                    {
                        mode = control.IDMode;
                    }
                }

                if (mode == IDMode.Inherit && this.SafeResourceManager != null)
                {
                    mode = this.ResourceManager.IDMode;
                }

                return mode;
            }
            set
            {
                this.ViewState["IDMode"] = value;
            }
        }

        private bool stopIDModeInheritance;
        /// <summary>
        /// 
        /// </summary>
		[DefaultValue(false)]
        public bool StopIDModeInheritance
        {
            get
            {
                return this.stopIDModeInheritance;
            }
            set
            {
                this.stopIDModeInheritance = value;
            }
        }

        /// <summary>
        /// Options for controlling how the lazy control is instantiated in the client.
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(LazyMode.Inherit)]
        [NotifyParentProperty(true)]
        [Description("Options for controlling how the lazy control is instantiated in the client.")]
        public virtual LazyMode LazyMode
        {
            get
            {
                object obj = this.ViewState["LazyMode"];

                LazyMode mode = LazyMode.Inherit;

                if (obj != null)
                {
                    mode = (LazyMode)obj;
                }
                else
                {
                    XControl control = this.ParentWebControl;

                    if (control != null)
                    {
                        mode = control.LazyMode;
                    }
                }

                if (mode == LazyMode.Inherit && this.SafeResourceManager != null)
                {
                    mode = this.ResourceManager.LazyMode;
                }

                return mode;
            }
            set
            {
                this.ViewState["LazyMode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parseDot"></param>
        /// <returns></returns>
        protected virtual string GetNamespace(bool parseDot)
        {
            object obj = this.ViewState["Namespace"];
            XControl control;

            string ns = "";

            if (obj != null)
            {
                ns = (string)obj;

                if (parseDot && ns.IsNotEmpty() && ns.StartsWith("."))
                {
                    control = this.ParentWebControl;
                    string parentNS;
                    if (control != null)
                    {
                        parentNS = control.ClientNamespace;
                    }
                    else
                    {
                        try
                        {
                            parentNS = this.SafeResourceManager != null ? this.SafeResourceManager.Namespace : "";
                        }
                        catch (Exception)
                        {
                            parentNS = "";
                        }
                    }

                    if (parentNS.IsNotEmpty())
                    {
                        ns = parentNS + ns;
                    }
                    else
                    {
                        ns = ns.Remove(0, 1);
                    }
                }
            }
            else
            {
                control = this.ParentWebControl;

                if (control != null)
                {
                    ns = control.ClientNamespace;
                }
            }

            if (ns.IsEmpty() && this.SafeResourceManager != null)
            {
                ns = this.SafeResourceManager.Namespace;
            }

            return ns;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public virtual string ClientNamespace
        {
            get
            {
                return this.GetNamespace(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual string AddNamespaceToID(string id)
        {
            return this.AddNamespaceToID(id, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual string AddNamespaceToID(string id, bool extns)
        {
            string ns = this.ClientNamespace;

            if (ns.IsNotEmpty())
            {
                return (extns ? ("Ext.ns(\""+ns+"\")") : ns) + "." + id;
            }

            return id;
        }


        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("ns")]
        [DefaultValue("")]
        protected virtual string ClientNamespaceProxy
        {
            get
            {
                string ns = this.GetNamespace(true);
                return this.SafeResourceManager != null && ns == this.SafeResourceManager.Namespace ? "" : ns;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string Namespace
        {
            get
            {
                return this.GetNamespace(false);
            }
            set
            {
                this.ViewState["Namespace"] = value;
            }
        }

        /// <summary>
        /// This Component's initial configuration specification. Read-only.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This Component's initial configuration specification. Read-only.")]
        public virtual string InitialConfig
        {
            get
            {
                if (this is Observable)
                {
                    return (this.DesignMode) ? "" : new ClientConfig().Serialize(this);
                }

                return "";
            }
        }

        private bool autoDataBind;

        /// <summary>
        /// 
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool AutoDataBind
        {
            get
            {
                return this.autoDataBind;
            }
            set
            {
                this.autoDataBind = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal virtual string ClientInitID
        {
            get
            {
                return this.ClientID.ConcatWith("_ClientInit");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        [JsonIgnore]
        [Description("")]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("configIDProxy", new ConfigOption("configIDProxy", new SerializationOptions("id"), "", this.ConfigIDProxy));
                list.Add("itemID", new ConfigOption("itemID", new SerializationOptions("itemId"), "", this.ItemID));
                list.Add("clientNamespaceProxy", new ConfigOption("clientNamespaceProxy", new SerializationOptions("ns"), "", this.ClientNamespaceProxy));

                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return ConfigOptionsExtraction.List;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
        [Description("")]
        public T Apply<T>(object config) where T : IComponent
        {
            return (T)this.Apply(config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [Description("")]
        public object Apply(object config)
        {
            return ObjectUtils.Apply(this, config);
        }
    }
}