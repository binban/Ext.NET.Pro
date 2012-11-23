/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class ResourceItem
    {
        private Type type = typeof(ResourceManager);
        private string pathEmbedded;
        private string path = "";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Type Type
        {
            get 
            { 
                return this.type; 
            }
            internal set 
            { 
                this.type = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string PathEmbedded
        {
            get 
            { 
                return this.pathEmbedded; 
            }
            internal set 
            { 
                this.pathEmbedded = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Path
        {
            get
            {
                if (this.path.IsEmpty())
                {
                    this.path = this.PathEmbedded.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", ".");
                }

                return this.path;
            }
            internal set
            {
                this.path = value;
            }
        }

        public bool IgnoreResourceMode
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public sealed class ClientStyleItem : ResourceItem
    {
        private Theme theme = Theme.Default;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Theme Theme
        {
            get 
            { 
                return this.theme; 
            }
            internal set 
            { 
                this.theme = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(Type type, string pathEmbedded, string path) : this(pathEmbedded, path)
        {
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(Type type, string pathEmbedded, string path, Theme theme) : this(type, pathEmbedded, path)
        {
            this.Theme = theme;
        }		

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(string pathEmbedded, string path)
        {
            this.PathEmbedded = pathEmbedded;
            this.Path = path;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(string pathEmbedded, string path, Theme theme)
            : this(pathEmbedded, path)
        {
            this.Theme = theme;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public sealed class ClientScriptItem : ResourceItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(string pathEmbedded, string path)
        {
            this.PathEmbedded = pathEmbedded;
            this.Path = path;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(string pathEmbedded, string pathEmbeddedDebug, string path, string pathDebug)
            : this(pathEmbedded, path)
        {
            this.PathEmbeddedDebug = pathEmbeddedDebug;
            this.PathDebug = pathDebug;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(Type type, string pathEmbedded, string path)
            : this(pathEmbedded, path)
        {
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(Type type, string pathEmbedded, string pathEmbeddedDebug, string path, string pathDebug)
            : this(type, pathEmbedded, path)
        {
            this.PathEmbeddedDebug = pathEmbeddedDebug;
            this.PathDebug = pathDebug;
        }

        private string pathEmbeddedDebug = "";
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string PathEmbeddedDebug
        {
            get 
            { 
                return this.pathEmbeddedDebug; 
            }
            internal set 
            { 
                this.pathEmbeddedDebug = value; 
            }
        }

        private string pathDebug = "";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string PathDebug
        {
            get
            {
                if (this.pathDebug.IsEmpty())
                {
                    this.pathDebug = this.PathEmbeddedDebug.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", ".");
                }

                return this.pathDebug;
            }
            internal set
            {
                this.pathDebug = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class ClientResourceItem
    {
        private Type type;

        /// <summary>
        /// 
        /// </summary>
        [TypeConverter(typeof(NetTypeConverter))]
        public Type Type
        {
            get
            {                
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PathEmbedded
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Path
        {
            get;
            set;
        }

        public ClientResourceItem()
        {
        }
        
        public ClientResourceItem(string url)
        {
            this.Path = url;
        }

        public ClientResourceItem(string url, bool isCss)
        {
            this.Path = url;
            this.IsCss = isCss;
        }

        public ClientResourceItem(Type type, string resourceName)
        {
            this.PathEmbedded = resourceName;
            this.Type = type;
        }

        public ClientResourceItem(Type type, string resourceName, bool isCss)
        {
            this.PathEmbedded = resourceName;
            this.Type = type;
            this.IsCss = isCss;
        }

        public bool IsCss
        {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            ClientResourceItem r = obj as ClientResourceItem;
            if ((object)r == null)
            {
                return false;
            }

            return (this.Path.IsNotEmpty() && this.Path == r.Path) || (this.PathEmbedded.IsNotEmpty() && this.PathEmbedded == r.PathEmbedded);
        }

        public bool Equals(ClientResourceItem obj)
        {
            if (obj == null)
            {
                return false;
            }

            return (this.Path.IsNotEmpty() && this.Path == obj.Path) || (this.PathEmbedded.IsNotEmpty() && this.PathEmbedded == obj.PathEmbedded);
        }

        public override int GetHashCode()
        {
            if (this.Path.IsNotEmpty())
            {
                return base.GetHashCode() ^ this.Path.GetHashCode();
            }

            if (this.PathEmbedded.IsNotEmpty())
            {
                return base.GetHashCode() ^ this.PathEmbedded.GetHashCode();
            }
            
            return base.GetHashCode();
        }
    }
}