/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class BaseControl : IScriptable
    {
#if !MVC
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual bool IsMVC
        {
            get
            {
                return false;
            }
        }
#endif
        
        private static ClientScriptItem uxScriptItem;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static ClientScriptItem UXScriptItem
        {
            get
            {
                if (BaseControl.uxScriptItem == null)
                {
                    BaseControl.uxScriptItem = new ClientScriptItem(
                        "Ext.Net.Build.Ext.Net.ux.extnet-ux.js",
                        "Ext.Net.Build.Ext.Net.ux.extnet-ux-debug.js",
                        "/ux/extnet-ux.js",
                        "/ux/extnet-ux-debug.js");
                }

                return BaseControl.uxScriptItem;
            }
        }

        private static ClientStyleItem uxStyleItem;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static ClientStyleItem UXStyleItem
        {
            get
            {
                if (BaseControl.uxStyleItem == null)
                {
                    BaseControl.uxStyleItem = new ClientStyleItem(
                        "Ext.Net.Build.Ext.Net.ux.resources.extnet-ux-embedded.css",                        
                        "/ux/resources/extnet-ux.css");
                }

                return BaseControl.uxStyleItem;
            }
        }

        /*  Design and Debug
            -----------------------------------------------------------------------------------------------*/

        protected virtual void CheckForceId()
        {
            this.ForceIdRendering = !this.IsDynamic && !this.IsMVC;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual bool IsDebugging
        {
            get
            {
                bool result = false;

                if (HttpContext.Current != null)
                {
                    result = HttpContext.Current.IsDebuggingEnabled;
                }

                return result;
            }
        }


        /*  Helpers
            -----------------------------------------------------------------------------------------------*/
        
        private JObject directConfig;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal JObject DirectConfig
        {
            get
            {
                if (this.directConfig == null)
                {
                    string submitDirectEventConfig = this.Page.Request["submitDirectEventConfig"];

                    if (submitDirectEventConfig.IsNotEmpty())
                    {
                        this.directConfig = JSON.Deserialize<JObject>(submitDirectEventConfig);
                    }
                }

                return this.directConfig;
            }
        }

        private readonly Dictionary<string, object> callbackValues = new Dictionary<string, object>();

        internal Dictionary<string, object> CallbackValues
        {
            get { return callbackValues; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsAjaxRequestInitiator
        {
            get
            {
                if (!RequestManager.IsAjaxRequest || this.IsDynamic)
                {
                    return false;
                }

                if (this.Page == null)
                {
                    return false;
                }

                string ea = "";

                try
                {
                    ea = this.Page.Request["__EVENTARGUMENT"];
                }
                catch (Exception)
                {
                    try
                    {
                        ea = HttpContext.Current.Request["__EVENTARGUMENT"];
                    }
                    catch (Exception)
                    {
                    }
                }

                if (ea.IsEmpty())
                {
                    if (this.DirectConfig == null)
                    {
                        return false;
                    }

                    JToken eventArgumentToken = this.DirectConfig.SelectToken("config.__EVENTARGUMENT", false);

                    if (eventArgumentToken == null)
                    {
                        return false;
                    }

                    ea = JSON.ToString(eventArgumentToken);

                    if (string.IsNullOrEmpty(ea))
                    {
                        return false;
                    }
                }

                string[] args = ea.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                if (args.Length != 3)
                {
                    return false;
                }

                string controlID = args[0];

                return this.ConfigID == controlID;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ParseTarget(string target)
        {
            string parsedTarget = TokenUtils.ParseTokens(target, this);

            if (TokenUtils.IsRawToken(parsedTarget))
            {
                return TokenUtils.ReplaceRawToken(parsedTarget);
            }

            return "\"".ConcatWith(parsedTarget, "\"");
        }


        /*  Helper Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool HasLayout()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool HasContent()
        {
            if (this is IContent)
            {
                return ((IContent)this).ContentEl.IsNotEmpty();
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected Unit UnitPixelTypeCheck(object obj, Unit defaultValue, string propertyName)
        {
            Unit temp = (obj == null) ? defaultValue : (Unit)obj;

            if (temp.Type != UnitType.Pixel)
            {
                throw new InvalidCastException("The Unit Type for the {0} {1} property must be of Type 'Pixel'. Example: Unit.Pixel(150) or '150px'.".FormatWith(this.ID, propertyName));
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual string ResolveUrlLink(string url)
        {
            if (url.IsEmpty())
            {
                return url;
            }

            if (this.Page == null || this.Page is ISelfRenderingPage)
            {
                if (HttpContext.Current == null)
                {
                    return url;
                }
#if MVC                
                return System.Web.Mvc.UrlHelper.GenerateContentUrl(url, new HttpContextWrapper(HttpContext.Current));
#else
                return VirtualPathUtility.ToAbsolute(url);
#endif
            }

            return this.ResolveUrl(url);
        }


        /*  Helper Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Does this object currently represent it's default state.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Does this object currently represent it's default state.")]
        public virtual bool IsDefault
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsLazy
        {
            get
            {
                if (this is Observable)
                {
                    if (BaseControl.HasSections && (this.Parent == null || this.Parent is Page))
                    {
                        return true;
                    }

                    if (this.Parent is ILazyItems)
                    {
                        return (this.Parent as ILazyItems).LazyItems.Contains((Observable)this);
                    }

                    if (this.Parent is ContentContainer && this.Parent.Parent is AbstractContainer)
                    {
                        AbstractContainer container = (AbstractContainer)this.Parent.Parent;
                        if (container.Items.Count == 0 && container.Layout.IsNotEmpty())
                        {
                            return true;
                        }
                    }

                    if (this.Parent is UserControl && this.Parent.Parent is UserControlLoader && this.Parent.Parent.Parent is AbstractContainer)
                    {
                        return true;
                    }

                    if ((this.Parent is UserControl || this.Parent is ContentPlaceHolder) && this.Parent.Parent is ContentContainer && this.Parent.Parent.Parent is AbstractContainer)
                    {
                        AbstractContainer container = (AbstractContainer)this.Parent.Parent.Parent;
                        if (container.Items.Count == 0 && container.Layout.IsNotEmpty())
                        {
                            return true;
                        }
                    }
                }

                return false;
            }            
        }

        internal static bool HasSections
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return false;
                }

                var sectionsObj = HttpContext.Current.Items["Ext.Net.Sections"];

                if (sectionsObj == null)
                {
                    return false;
                }

                var stack = (Stack<List<string>>)sectionsObj;

                return stack.Count > 0 && stack.Peek() != null;
            }
        }
        
        internal static Stack<List<string>> SectionsStack
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return new Stack<List<string>>();
                }

                var sectionsObj = HttpContext.Current.Items["Ext.Net.Sections"];
                
                if (sectionsObj == null)
                {
                    var newStack = new Stack<List<string>>();
                
                    HttpContext.Current.Items["Ext.Net.Sections"] = newStack;
                    
                    return newStack;
                }

                return (Stack<List<string>>)sectionsObj;
            }
        }

        private bool isDynamicLazy;

        internal bool IsDynamicLazy
        {
            get
            {
                return this.isDynamicLazy;
            }
            set
            {
                this.isDynamicLazy = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual string ContainerID
        {
            get
            {
                return (this.IsDynamic && this.IsGeneratedID ? this.DynamicID : this.ClientID).ConcatWith("_Container");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ContainerStyle
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsInHead
        {
            get
            {
                return ReflectionUtils.IsInTypeOf(this, typeof(System.Web.UI.HtmlControls.HtmlHead));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual bool IsInForm
        {
            get
            {
                return (this.ParentForm != null);
            }
        }

        protected virtual string ClientForm
        {
            get
            {
                string formId = null;
                ResourceManager rm = ResourceManager.GetInstance();

                if (rm != null && rm.FormID.IsNotEmpty())
                {
                    formId = rm.FormID;
                }
                else if (this.IsInForm)
                {
                    formId = this.ParentForm.ClientID;
                }
#if MVC
                else
                {
                    var cfg = Ext.Net.MVC.MvcResourceManager.SharedConfig;

                    if (cfg != null && cfg.FormID.IsNotEmpty())
                    {
                        formId = cfg.FormID;
                    }
                }
#endif
                return formId;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual System.Web.UI.HtmlControls.HtmlForm ParentForm
        {
            get
            {
                return (HtmlForm)ReflectionUtils.GetTypeOfParent(this, typeof(System.Web.UI.HtmlControls.HtmlForm));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual AbstractComponent ParentComponent
        {
            get
            {
                return (AbstractComponent)ReflectionUtils.GetTypeOfParent(this, typeof(AbstractComponent));
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual BaseControl ParentWebControl
        {
            get
            {
                return (BaseControl)ReflectionUtils.GetTypeOfParent(this, typeof(BaseControl));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal virtual bool IsDeferredRender
        {
            get
            {
                return false;
            }
        }

        internal virtual bool IsParentDeferredRender
        {
            get
            {
                for (Control parent = this.Parent; parent != null; parent = parent.Parent)
                {
                    if (parent is BaseControl)
                    {
                        if (((BaseControl)parent).IsDeferredRender)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
}