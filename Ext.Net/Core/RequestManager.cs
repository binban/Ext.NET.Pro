/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class RequestManager
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal static void EnsureDirectEvent()
        {
            if (!RequestManager.IsAjaxRequest)
            {
            //    throw new InvalidOperationException("This operation requires an AjaxRequest");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsAjaxRequest
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    if (HttpContext.Current.Items["__Ext.Net.SuppressAjaxRequestMarker"] != null)
                    {
                        return false;
                    }

                    return RequestManager.HasXHeader(HttpContext.Current.Request) || RequestManager.HasInputFieldMarker(HttpContext.Current.Request);
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public static bool IsMicrosoftAjaxRequest
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    return RequestManager.HasXMicrosoftAjaxHeader(HttpContext.Current.Request);
                }

                return false;
            }
        }

        public static void SuppressAjaxRequestMarker()
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            HttpContext.Current.Items["__Ext.Net.SuppressAjaxRequestMarker"] = true;
        }

        public static void ResumeAjaxRequestMarker()
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            if (HttpContext.Current.Items.Contains("__Ext.Net.SuppressAjaxRequestMarker"))
            {
                HttpContext.Current.Items.Remove("__Ext.Net.SuppressAjaxRequestMarker");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("")]
        public static bool HasInputFieldMarker(HttpRequest request)
        {
            if (request == null)
            {
                return false;    
            }

            try
            {
                string marker = request.Form["__ExtNetDirectEventMarker"];

                if (marker.IsNotEmpty())
                {
                    if (marker.ToLowerInvariant().Contains("delta=true"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
            }
            
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("")]
        public static bool HasXHeader(HttpRequest request)
        {
            string[] values = request.Headers.GetValues("X-Ext.Net");

            if (values != null)
            {
                foreach (string value in values)
                {
                    if (value.ToLowerInvariant().Contains("delta=true"))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("")]
        public static bool HasXMicrosoftAjaxHeader(HttpRequest request)
        {
            if (HttpContext.Current == null)
            {
                return false;
            }

            string[] values = HttpContext.Current.Request.Headers.GetValues("X-MicrosoftAjax");

            if (values != null)
            {
                foreach (string value in values)
                {
                    if (value.ToLowerInvariant().Contains("delta=true"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /*  User Agent Detection (browser)
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static bool IsOpera
        {
            get
            {
                return (HttpContext.Current != null && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("opera"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsChrome
        {
            get
            {
                return (HttpContext.Current != null && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("chrome"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsWebKit
        {
            get
            {
                return (HttpContext.Current != null && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("webkit"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSafari
        {
            get
            {
                return (HttpContext.Current != null && !RequestManager.IsChrome && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("safari"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSafari3
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsSafari && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("version/3"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsSafari4
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsSafari && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("version/4"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE
        {
            get
            {
                return (HttpContext.Current != null && !RequestManager.IsOpera && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("msie"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE6
        {
            get
            {

                return (HttpContext.Current != null && RequestManager.IsIE && HttpContext.Current.Request.Browser.MajorVersion <= 6);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE7
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsIE && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("msie 7"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsIE8
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsIE && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("msie 8"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static bool IsIE9
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsIE && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("msie 9"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsGecko
        {
            get
            {
                return (HttpContext.Current != null && !RequestManager.IsWebKit && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("gecko"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsGecko3
        {
            get
            {
                return (HttpContext.Current != null && RequestManager.IsGecko && (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant().Contains("rv:1.9"));
            }
        }


        /*  User Agent Detection (operating system)
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static bool IsWindows
        {
            get
            {
                string ua = (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant();
                return (HttpContext.Current != null && (ua.Contains("windows") || ua.Contains("win32")));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsMac
        {
            get
            {
                string ua = (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant();
                return (HttpContext.Current != null && (ua.Contains("macintosh") || ua.Contains("mac os x")));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsLinux
        {
            get
            {
                string ua = (HttpContext.Current.Request.UserAgent ?? "").ToLowerInvariant();
                return (HttpContext.Current != null && ua.Contains("linux"));
            }
        }
    }
}