/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
    /// An extended Ext.Element object that supports a shadow and shim, constrain to viewport and automatic maintaining of shadow/shim positions.
	/// </summary>
    [Description("An extended Ext.Element object that supports a shadow and shim, constrain to viewport and automatic maintaining of shadow/shim positions.")]
    public class Layer : Element
    {
		/// <summary>
        /// Creates new Layer.
		/// </summary>
        public Layer(LayerConfig config) : base(config.Serialize(true)) { }

        /// <summary>
        /// Sets the z-index of this layer and adjusts any shadow and shim z-indexes. The layer z-index is automatically incremented depending upon the presence of a shim or a shadow in so that it always shows above those two associated elements.
        /// Any shim, will be assigned the passed z-index. A shadow will be assigned the next highet z-index, and the Layer's element will receive the highest z-index.
        /// </summary>
        /// <param name="zindex">The new z-index to set</param>
        /// <returns>This layer</returns>
        public virtual Layer SetZIndex(int zindex)
        {
            this.Call("setZIndex", zindex);
            return this;
        }

		/// <summary>
        /// Synchronize this Layer's associated elements, the shadow, and possibly the shim.
		/// </summary>
        /// <param name="show">Pass true to ensure that the shadow is shown.</param>
        /// <returns>This layer</returns>
        public virtual Layer Sync(bool show)
        {
            this.Call("sync", show);
            return this;
        }

		/// <summary>
        /// Synchronize this Layer's associated elements, the shadow, and possibly the shim.
		/// </summary>
        /// <returns>This layer</returns>
        public virtual Layer Sync()
        {
            this.Call("sync");
            return this;
        }
    }

    public partial class LayerConfig : BaseItem
    {
        /// <summary>
        /// CSS class to add to the element
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        public virtual string Cls
        {
            get
            {
                return this.State.Get<string>("Cls", "");
            }
            set
            {
                this.State.Set("Cls", value);
            }
        }

        /// <summary>
        /// The Layer ID
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        public virtual string ID
        {
            get
            {
                return this.State.Get<string>("ID", "");
            }
            set
            {
                this.State.Set("ID", value);
            }
        }

        /// <summary>
        /// False to disable constrain to viewport (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        public virtual bool Constrain
        {
            get
            {
                return this.State.Get<bool>("Constrain", true);
            }
            set
            {
                this.State.Set("Constrain", value);
            }
        }

        private DomObject dh;

        /// <summary>
        /// DomHelper object config to create element with (defaults to {tag: 'div', cls: 'x-layer'}).
        /// </summary>
        [Meta]
        [ConfigOption("dh", JsonMode.Object)]
        public virtual DomObject DH
        {
            get
            {
                if (this.dh == null)
                {
                    this.dh = new DomObject();
                }

                return this.dh;
            }
        }

        /// <summary>
        /// A String which specifies how this AbstractComponent's encapsulating DOM element will be hidden. Values may be
        /// 'display' : The AbstractComponent will be hidden using the display: none style.
        /// 'visibility' : The AbstractComponent will be hidden using the visibility: hidden style.
        /// 'offsets' : The AbstractComponent will be hidden by absolutely positioning it out of the visible area of the document. This is useful when a hidden AbstractComponent must maintain measurable dimensions. Hiding using display results in a AbstractComponent having zero dimensions.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("A String which specifies how this AbstractComponent's encapsulating DOM element will be hidden.")]
        public virtual HideMode? HideMode
        {
            get
            {
                return this.State.Get<HideMode?>("HideMode", null);
            }
            set
            {
                this.State.Set("HideMode", value);
            }
        }

        /// <summary>
        /// True to automatically create an Ext.Shadow, or a string indicating the shadow's display Ext.Shadow.mode. False to disable the shadow. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [DefaultValue(ShadowMode.None)]
        public virtual ShadowMode Shadow
        {
            get
            {
                return this.State.Get<ShadowMode>("Shadow", ShadowMode.None);
            }
            set
            {
                this.State.Set("Shadow", value);
            }
        }

        /// <summary>
        /// Number of pixels to offset the shadow (defaults to 4)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(4)]
        public virtual int ShadowOffset
        {
            get
            {
                return this.State.Get<int>("ShadowOffset", 4);
            }
            set
            {
                this.State.Set("ShadowOffset", value);
            }
        }

        /// <summary>
        /// False to disable the iframe shim in browsers which need one (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        public virtual bool Shim
        {
            get
            {
                return this.State.Get<bool>("Shim", true);
            }
            set
            {
                this.State.Set("Shim", value);
            }
        }

        /// <summary>
        /// Defaults to use css offsets to hide the Layer. Specify true to use css style 'display:none;' to hide the Layer.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        public virtual bool UseDisplay
        {
            get
            {
                return this.State.Get<bool>("UseDisplay", false);
            }
            set
            {
                this.State.Set("UseDisplay", value);
            }
        }

        /// <summary>
        /// The CSS class name to add in order to hide this Layer if this layer is configured with hideMode: 'asclass'
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        public virtual string VisibilityCls
        {
            get
            {
                return this.State.Get<string>("VisibilityCls", "");
            }
            set
            {
                this.State.Set("VisibilityCls", value);
            }
        }

        /// <summary>
        /// Starting z-index (defaults to 11000)
        /// </summary>
        [Meta]
        [ConfigOption("zindex")]
        [DefaultValue(11000)]
        public virtual int ZIndex
        {
            get
            {
                return this.State.Get<int>("ZIndex", 11000);
            }
            set
            {
                this.State.Set("ZIndex", value);
            }
        }

        private Element parentElement;

        /// <summary>
        /// Parent element for current Layer
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        public virtual Element ParentElement
        {
            get
            {
                return this.parentElement;
            }
            set
            {
                this.parentElement = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption("parentEl", JsonMode.Raw)]
		[Description("")]
        protected virtual string ParentElementProxy
        {
            get
            {
                if (this.ParentElement != null)
                {
                    return this.ParentElement.Descriptor;
                }

                return "";
            }
        }

        private Element existingElement;

        /// <summary>
        /// Uses an existing DOM element. If the element is not found it creates it.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        public virtual Element ExistingElement
        {
            get
            {
                return this.existingElement;
            }
            set
            {
                this.existingElement = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return this.Serialize(false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize(bool withInstance)
        {
            string config = new ClientConfig().Serialize(this, true);

            if (withInstance)
            {
                config = "new Ext.Layer(".ConcatWith(config, this.ExistingElement != null ? ", "+this.ExistingElement.Descriptor : "" , ")");
            }
            
            return config;
        }
    }
}
