/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Ext.Net
{
    /// <summary>
    /// The Draw Component is a surface in which sprites can be rendered. The Draw Component manages and holds a Surface instance: an interface that has an SVG or VML implementation depending on the browser capabilities and where Sprites can be appended.
    /// </summary>
    [Meta]
    public abstract partial class AbstractDrawComponent : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override string ContainerStyle
        {
            get
            {
                return Const.DisplayInline;
            }
        }

        /// <summary>
        /// Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DrawComponent")]
        [DefaultValue(false)]
        [Description("Turn on autoSize support which will set the bounding div's size to the natural size of the contents. Defaults to false.")]
        public virtual bool AutoSize
        {
            get
            {
                return this.State.Get<bool>("AutoSize", false);
            }
            set
            {
                this.State.Set("AutoSize", value);
            }
        }

        /// <summary>
        /// Defines the priority order for which Surface implementation to use. The first one supported by the current environment will be used.
        /// Defaults to: ["Svg", "Vml"]
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("4. DrawComponent")]
        [DefaultValue(null)]
        [Description("Defines the priority order for which Surface implementation to use. The first one supported by the current environment will be used. Defaults to: [\"Svg\", \"Vml\"]")]
        public virtual string[] EnginePriority
        {
            get
            {
                return this.State.Get<string[]>("EnginePriority", null);
            }
            set
            {
                this.State.Set("EnginePriority", value);
            }
        }

        private Gradients gradients;

        /// <summary>
        /// Define a set of gradients that can be used as fill property in sprites.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Define a set of gradients that can be used as fill property in sprites.")]
        public virtual Gradients Gradients
        {
            get
            {
                if (this.gradients == null)
                {
                    this.gradients = new Gradients();
                }

                return this.gradients;
            }
        }

        /// <summary>
        /// Turn on view box support which will scale and position items in the draw component to fit to the component while maintaining aspect ratio. Note that this scaling can override other sizing settings on yor items. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DrawComponent")]
        [DefaultValue(true)]
        [Description("Turn on view box support which will scale and position items in the draw component to fit to the component while maintaining aspect ratio. Note that this scaling can override other sizing settings on yor items. Defaults to true.")]
        public virtual bool ViewBox
        {
            get
            {
                return this.State.Get<bool>("ViewBox", true);
            }
            set
            {
                this.State.Set("ViewBox", value);
            }
        }

        private DrawBackground background;

        /// <summary>
        /// The chart background. This can be a gradient object, image, or color. Defaults to false for no background. 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The chart background. This can be a gradient object, image, or color. Defaults to false for no background.")]
        public DrawBackground Background
        {
            get
            {
                return this.background;
            }
            set
            {
                this.background = value;
            }
        }

        private SpriteCollection items;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("items", JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public SpriteCollection Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new SpriteCollection();
                    this.items.AfterItemAdd += Items_AfterSpriteAdd;
                }

                return this.items;
            }
        }

        protected virtual void Items_AfterSpriteAdd(Sprite item)
        {
            item.Draw = this;
        }      

        public virtual Sprite GetSprite(string id)
        {
            foreach (var item in this.Items)
	        {
                if(item.SpriteID == id)
                {
                    return item;
                }
	        }

            return new Sprite{SpriteID = id, Draw = this};
        }

        public virtual Sprite GetGroup(string id)
        {
            return new Sprite { SpriteID = id, IsGroup = true, Draw = this };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Meta]
        public virtual void CallSurface(string name, params object[] args)
        {
            this.CallTemplate("{0}.surface.{1}({2});", name, args);
        }

        /// <summary>
        /// Adds a Sprite to the surface. See Ext.draw.Sprite for the configuration object to be passed into this method.
        /// </summary>
        /// <param name="sprite">One or more Sprite objects of configs.</param>
        [Meta]
        public virtual void Add(Sprite sprite)
        {
            sprite.Draw = this;
            this.CallSurface("add", JRawValue.From(new ClientConfig().Serialize(sprite, true, true)));
        }

        /// <summary>
        /// Adds a Sprite to the surface. See Ext.draw.Sprite for the configuration object to be passed into this method.
        /// </summary>
        /// <param name="sprite">One or more Sprite objects of configs.</param>
        [Meta]
        public virtual void Add(IEnumerable<Sprite> sprites)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var sprite in sprites)
            {
                sprite.Draw = this;
                sb.Append(new ClientConfig().Serialize(sprite, true, true));
                sb.Append(",");
            }

            if (sb[sb.Length - 1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");
            
            this.CallSurface("add", JRawValue.From(sb.ToString()));
        }

        /// <summary>
        /// Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="sprite">The sprite to add the class to.</param>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        [Meta]
        public virtual void AddCls(Sprite sprite, string className)
        {
            sprite.Draw = this;
            this.CallSurface("addCls", JRawValue.From(sprite.Proxy), className);
        }

        /// <summary>
        /// Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="sprite">The sprite to add the class to.</param>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        [Meta]
        public virtual void AddCls(Sprite sprite, string[] className)
        {
            sprite.Draw = this;
            this.CallSurface("addCls", JRawValue.From(sprite.Proxy), className);
        }

        /// <summary>
        /// Adds a gradient definition to the Surface. Note that in some surface engines, adding a gradient via this method will not take effect if the surface has already been rendered. Therefore, it is preferred to pass the gradients as an item to the surface config, rather than calling this method, especially if the surface is rendered immediately (e.g. due to 'renderTo' in its config). For more information on how to create gradients in the Chart configuration object please refer to Ext.chart.Chart.
        /// 
        /// The gradient object to be passed into this method is composed by:
        /// 
        /// id - string - The unique name of the gradient.
        /// angle - number, optional - The angle of the gradient in degrees.
        /// stops - object - An object with numbers as keys (from 0 to 100) and style objects as values.
        /// </summary>
        /// <param name="gradient">A gradient config.</param>
        [Meta]
        public virtual void AddGradient(Gradient gradient)
        {
            this.CallSurface("addGradient", JRawValue.From(new ClientConfig().Serialize(gradient)));
        }

        /// <summary>
        /// Destroys the surface. This is done by removing all components from it and also removing its reference to a DOM element.
        /// </summary>
        [Meta]
        public virtual void DestroySurface()
        {
            this.CallSurface("destroy");
        }

        /// <summary>
        /// Removes a given sprite from the surface, optionally destroying the sprite in the process. You can also call the sprite own remove method.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="destroySprite"></param>
        [Meta]
        public virtual void Remove(Sprite sprite, bool destroySprite)
        {
            sprite.Draw = this;
            this.CallSurface("remove", JRawValue.From(sprite.Proxy), destroySprite);
        }

        /// <summary>
        /// Removes a given sprite from the surface, optionally destroying the sprite in the process. You can also call the sprite own remove method.
        /// </summary>
        /// <param name="sprite"></param>
        [Meta]
        public virtual void Remove(Sprite sprite)
        {
            sprite.Draw = this;
            this.CallSurface("remove", JRawValue.From(sprite.Proxy));
        }

        /// <summary>
        /// Removes all sprites from the surface, optionally destroying the sprites in the process.
        /// </summary>
        /// <param name="destroySprites">Whether to destroy all sprites when removing them.</param>
        [Meta]
        public virtual void RemoveAll(bool destroySprites)
        {
            this.CallSurface("remove", destroySprites);
        }

        /// <summary>
        /// Removes all sprites from the surface, optionally destroying the sprites in the process.
        /// </summary>
        [Meta]
        public virtual void RemoveAll()
        {
            this.CallSurface("remove");
        }

        /// <summary>
        /// Removes one or more CSS classes from the element.
        /// </summary>
        /// <param name="sprite">The sprite to remove the class from.</param>
        /// <param name="className">The CSS class to remove, or an array of classes</param>
        [Meta]
        public virtual void RemoveCls(Sprite sprite, string className)
        {
            sprite.Draw = this;
            this.CallSurface("removeCls", JRawValue.From(sprite.Proxy), className);
        }

        /// <summary>
        /// Removes one or more CSS classes from the element.
        /// </summary>
        /// <param name="sprite">The sprite to remove the class from.</param>
        /// <param name="className">The CSS class to remove, or an array of classes</param>
        [Meta]
        public virtual void RemoveCls(Sprite sprite, string[] className)
        {
            sprite.Draw = this;
            this.CallSurface("removeCls", JRawValue.From(sprite.Proxy), className);
        }

        /// <summary>
        /// Sets the size of the surface. Accomodates the background (if any) to fit the new size too.
        /// This method is generally called when also setting the size of the draw Component.
        /// </summary>
        /// <param name="width">The new width of the canvas.</param>
        /// <param name="height">The new height of the canvas.</param>
        [Meta]
        public virtual void SetSurfaceSize(int width, int height)
        {
            this.CallSurface("setSize", width, height);
        }

        /// <summary>
        /// Sets CSS style attributes to an element.
        /// </summary>
        /// <param name="sprite">The sprite to add, or an array of classes to</param>
        /// <param name="styles">An Object with CSS styles.</param>
        [Meta]
        public virtual void SetStyle(Sprite sprite, Dictionary<string, string> styles)
        {
            sprite.Draw = this;
            this.CallSurface("setStyle", JRawValue.From(sprite.Proxy), styles);
        }

        /// <summary>
        /// Changes the text in the sprite element. The sprite must be a text sprite. This method can also be called from Ext.draw.Sprite.
        /// </summary>
        /// <param name="sprite">The Sprite to change the text.</param>
        /// <param name="text">The new text to be set.</param>
        [Meta]
        public virtual void SetText(Sprite sprite, string text)
        {
            sprite.Draw = this;
            this.CallSurface("setText", JRawValue.From(sprite.Proxy), text);
        }
    }
}
