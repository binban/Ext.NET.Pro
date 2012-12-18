/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    [Designer(typeof(ExtControlDesigner))]    
    public abstract partial class BaseControl : WebControl, ICompositeControlDesignerAccessor, IXObject, IBase
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
            get { return "Pro"; }
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
#if ISPRO                
                return true;
#else
                return false;
#endif
            }
        }


        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        private string dynamicID;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenerateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            
            return string.Format("id{0:x}", i - DateTime.Now.Ticks);
        }

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
                    this.dynamicID = BaseControl.GenerateID();
                }

                return this.dynamicID;
            }
        }
		
		private bool isDynamicIDSet;

        internal void EnsureDynamicID()
        {
            if (!this.isDynamicIDSet && (this.IsSelfRender || this.IsPageSelfRender || this.IsDynamic) && this.IsGeneratedID)
            {
                this.isDynamicIDSet = true;
                this.ID = this.DynamicID;
                this.IsGeneratedID = true;
            }
        }

        /// <summary>
        /// The unique id of this component instance (defaults to an auto-assigned id).
        /// Components created with an id may be accessed globally using Ext.getCmp.
        /// You can use the itemId config, and ComponentQuery which provides selector-based searching for Sencha Components analogous to DOM querying. The Container class contains shortcut methods to query its descendant Components by selector.
        /// Note that this id will also be used as the element id for the containing HTML element that is rendered to the page for this component. This allows you to write id-based CSS rules to style the specific instance of this component uniquely, and also to select sub-elements using this component's id as the parent.
        /// Note: to avoid complications imposed by a unique id also see itemId.
        /// Note: to access the container of a AbstractComponent see ownerCt.
        /// </summary>
        [Category("0. About")]
        public override string ID
        {
            get
            {
                if ((this.IsSelfRender || this.IsPageSelfRender || this.IsDynamic) && this.IsGeneratedID)
                {
                    this.EnsureDynamicID();
                    return this.DynamicID;
                }

                return base.ID;
            }
            set
            {
                if (this.IsGeneratedID && base.ID != value)
                {
                    this.IsGeneratedID = false;
                }
                base.ID = value;
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

                if (this.HasOwnNamespace && this.ItemID.IsNotEmpty())
                {
                    return this.AddNamespaceToID(this.ItemID);
                }

                return this.AddNamespaceToID(this.ConfigID);
            }
        }

        /// <summary>
        /// An itemId can be used as an alternative way to get a reference to a component when no object reference is available. Instead of using an id with Ext.getCmp, use itemId with Ext.container.Container.getComponent which will retrieve itemId's or id's. Since itemId's are an index to the container's internal MixedCollection, the itemId is scoped locally to the container -- avoiding potential conflicts with Ext.ComponentMgr which requires a unique id
        /// </summary>
        [Meta]
        [ConfigOption("itemId")]
        [DefaultValue("")]
        [Category("3. AbstractComponent")]
        [Description("An itemId can be used as an alternative way to get a reference to a component when no object reference is available.")]
        public virtual string ItemID
        {
            get
            {
                return this.State.Get<string>("ItemID", "");
            }
            set
            {
                this.State.Set("ItemID", value);
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

                if (this.IsGeneratedID)
                {
                    return this.BaseClientID;
                }

                switch (this.IDMode)
                {
                    case IDMode.Static:
                        return this.ID;
                    case IDMode.Explicit:
                        return this.BaseClientID;
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

                                bool isCmp = nc_parent is AbstractComponent;
                                string parentID = isCmp ? ((BaseControl)nc_parent).ConfigID : nc_parent.ID;

                                id2 = (nc_parent_parent != null && nc_parent_parent is IContent) ? ((BaseControl)nc_parent_parent).ConfigID : parentID;
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
                this.EnsureDynamicID();
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
                bool isGenerated = this.IsGeneratedID;
                IDMode idMode = this.IDMode;

                if (this.IsDynamic && isGenerated && !this.TopDynamicControl)
                {
                    return "";
                }

                if (idMode == IDMode.Ignore)
                {
                    return "";
                }

                if (!this.IsIdRequired && ((idMode == IDMode.Explicit || idMode == IDMode.Client || idMode == IDMode.Static) && isGenerated))
                {
                    return "";
                }

                string configID = this.ConfigID;
                if (configID == null)
                {
                    return "";
                }

                return configID;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasOwnIDMode
        {
            get
            {
                return this.State["IDMode"] != null;
            }
        }

        /// <summary>
        /// Options for controlling how the .ClientID property is rendered in the client.
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(IDMode.Inherit)]
        [NotifyParentProperty(true)]
        [Description("Options for controlling how the .ClientID property is rendered in the client.")]
        public virtual IDMode IDMode
        {
            get
            {
                object obj = this.State["IDMode"];

                IDMode mode = IDMode.Inherit;

                if (obj != null)
                {
                    mode = (IDMode)obj;
                }
                else if (!this.StopIDModeInheritance)
                {
                    BaseControl control = this.ParentWebControl;

                    if (control != null && !control.StopIDModeInheritance)
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
                this.State.Set("IDMode", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public virtual bool StopIDModeInheritance
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public virtual bool StopLazyModeInheritance
        {
            get;
            set;
        }

        /// <summary>
        /// Options for controlling how the lazy control is instantiated in the client.
        /// </summary>
        [Category("1. XControl")]
        [DefaultValue(LazyMode.Default)]
        [NotifyParentProperty(true)]
        [Description("Options for controlling how the lazy control is instantiated in the client.")]
        public virtual LazyMode LazyMode
        {
            get
            {
                object obj = this.State["LazyMode"];

                if (obj == null) 
                {
                    return Ext.Net.LazyMode.Default;
                }

                LazyMode mode = (LazyMode)obj;

                if (mode != Ext.Net.LazyMode.Inherit)
                {
                    return mode;
                }
                
                if (!this.StopLazyModeInheritance)
                {
                    BaseControl control = this.ParentWebControl;

                    if (control != null && control.StopLazyModeInheritance)
                    {
                        mode = control.LazyMode;
                    }
                }

                if (mode == LazyMode.Inherit && this.SafeResourceManager != null)
                {
                    mode = this.ResourceManager.LazyMode;
                }

                return mode == Ext.Net.LazyMode.Inherit ? Ext.Net.LazyMode.Default : mode;
            }
            set
            {
                this.State.Set("LazyMode", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasOwnNamespace
        {
            get
            {
                return this.State.Get<string>("Namespace", "").IsNotEmpty();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parseDot"></param>
        /// <returns></returns>
        protected virtual string GetNamespace(bool parseDot)
        {
            object obj = this.State["Namespace"];

            BaseControl control;

            string ns = "";

            if (obj != null)
            {
                ns = (string)obj;

                if (ns.IsEmpty())
                {
                    return "";
                }

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
                            parentNS = this.SafeResourceManager != null ? this.SafeResourceManager.NormalizedNamespace : new ResourceManager().NormalizedNamespace;
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

            if (ns.IsEmpty())
            {
                if (this.SafeResourceManager != null)
                {
                    ns = this.SafeResourceManager.NormalizedNamespace;
                }
                else
                {
                    ns = new ResourceManager().NormalizedNamespace;
                }
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
            string ns = this.ClientNamespace;

            if (ns.IsNotEmpty())
            {
                return ns + "." + id;
            }

            return id;
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
                this.State.Set("Namespace", value);
            }
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
                return this.SafeResourceManager != null && ns == this.SafeResourceManager.NormalizedNamespace ? "" : ns;
            }
        }

        /// <summary>
        /// This AbstractComponent's initial configuration specification. Read-only.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("This AbstractComponent's initial configuration specification. Read-only.")]
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
                return this.BaseClientID.ConcatWith("_ClientInit");
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
                list.Add("postBackConfig", new ConfigOption("postBackConfig", new SerializationOptions("postback", JsonMode.Raw), "", this.PostBackConfig));

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

        public virtual IControlBuilder ToNativeBuilder()
        {
            return this.ToBuilder();
        }

        public virtual T ToBuilder<T>() where T : class, IControlBuilder
        {
            return this.ToNativeBuilder() as T;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
        [Description("")]
        public T Apply<T>(IApply config) where T : IComponent
        {
            return (T)this.Apply(config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [Description("")]
        public object Apply(IApply config)
        {
            return BaseControl.Apply(this, config);
        }

        public BaseControl Apply(object from, bool ignoreDefaultValues)
        {
            return (BaseControl)BaseControl.Apply(this, from, ignoreDefaultValues);
        }

        public BaseControl Apply(object from)
        {
            return (BaseControl)BaseControl.Apply(this, from, true);
        }

        public static object Apply(object to, object from)
        {
            return BaseControl.Apply(to, from, true);
        }

        public static object Apply(object to, object from, bool ignoreDefaultValues)
        {
            System.Reflection.PropertyInfo toProperty;
            
            object fromValue = null;
            object defaultValue = null;

            foreach (PropertyInfo fromProperty in from.GetType().GetProperties())
            {
                if (fromProperty.CanRead)
                {
                    fromValue = fromProperty.GetValue(from, null);

                    if (ignoreDefaultValues)
                    {
                        defaultValue = Ext.Net.Utilities.ReflectionUtils.GetDefaultValue(fromProperty);

                        if (fromValue != null && fromValue.Equals(defaultValue))
                        {
                            continue;
                        }
                    }

                    if (fromValue != null)
                    {
                        toProperty = to.GetType().GetProperty(fromProperty.Name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

                        if (toProperty != null && toProperty.CanWrite && toProperty != null && toProperty.PropertyType.Equals(fromProperty.PropertyType))
                        {
                            toProperty.SetValue(to, fromValue, null);
                        }
                    }
                }
            }

            return to;
        }
    }
}