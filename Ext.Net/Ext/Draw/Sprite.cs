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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A Sprite is an object rendered in a Drawing surface.
    /// 
    /// Translation
    /// 
    /// For translate, the configuration object contains x and y attributes that indicate where to translate the object. For example:
    /// 
    /// sprite.setAttributes({
    ///   translate: {
    ///    x: 10,
    ///    y: 10
    ///   }
    /// }, true);
    /// Rotation
    /// 
    /// For rotation, the configuration object contains x and y attributes for the center of the rotation (which are optional), and a degrees attribute that specifies the rotation in degrees. For example:
    /// 
    /// sprite.setAttributes({
    ///   rotate: {
    ///    degrees: 90
    ///   }
    /// }, true);
    /// That example will create a 90 degrees rotation using the centroid of the Sprite as center of rotation, whereas:
    /// 
    /// sprite.setAttributes({
    ///   rotate: {
    ///    x: 0,
    ///    y: 0,
    ///    degrees: 90
    ///   }
    /// }, true);
    /// will create a rotation around the (0, 0) axis.
    /// 
    /// Scaling
    /// 
    /// For scaling, the configuration object contains x and y attributes for the x-axis and y-axis scaling. For example:
    /// 
    /// sprite.setAttributes({
    ///   scale: {
    ///    x: 10,
    ///    y: 3
    ///   }
    /// }, true);
    /// You can also specify the center of scaling by adding cx and cy as properties:
    /// 
    /// sprite.setAttributes({
    ///   scale: {
    ///    cx: 0,
    ///    cy: 0,
    ///    x: 10,
    ///    y: 3
    ///   }
    /// }, true);
    /// That last example will scale a sprite taking as centers of scaling the (0, 0) coordinate.
    /// 
    /// Creating and adding a Sprite to a Surface
    /// 
    /// Sprites can be created with a reference to a Ext.draw.Surface
    /// 
    /// var drawComponent = Ext.create('Ext.draw.Component', options here...);
    /// 
    /// var sprite = Ext.create('Ext.draw.Sprite', {
    ///     type: 'circle',
    ///     fill: '#ff0',
    ///     surface: drawComponent.surface,
    ///     radius: 5
    /// });
    /// Sprites can also be added to the surface as a configuration object:
    /// 
    /// var sprite = drawComponent.surface.add({
    ///     type: 'circle',
    ///     fill: '#ff0',
    ///     radius: 5
    /// });
    /// In order to properly apply properties and render the sprite we have to show the sprite setting the option redraw to true:
    /// 
    /// sprite.show(true);
    /// The constructor configuration object of the Sprite can also be used and passed into the Ext.draw.Surface add method to append a new sprite to the canvas. For example:
    /// 
    /// drawComponent.surface.add({
    ///     type: 'circle',
    ///     fill: '#ffc',
    ///     radius: 100,
    ///     x: 100,
    ///     y: 100
    /// });
    /// </summary>
    [Meta]
    public partial class Sprite : SpriteAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        public Sprite()
        {
        }

        public AbstractDrawComponent Draw
        {
            get;
            set;
        }

        public bool IsGroup
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        [Description("")]
        public virtual string SpriteID
        {
            get
            {
                return this.State.Get<string>("SpriteID", "");
            }
            set
            {
                this.State.Set("SpriteID", value);
            }
        }
        
        /// <summary>
        /// True to make the sprite draggable.
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [Description("True to make the sprite draggable.")]
        public virtual bool Draggable
        {
            get
            {
                return this.State.Get<bool>("Draggable", false);
            }
            set
            {
                this.State.Set("Draggable", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("draggable", JsonMode.Raw)]
        protected virtual string DraggableConfigProxy
        {
            get
            {
                if (this.DraggableConfig == null)
                {
                    return this.Draggable ? "true" : "";
                }
                string cfg = new ClientConfig().Serialize(this.DraggableConfig, true);
                return cfg != Const.EmptyObject ? cfg : "";
            }
        }

        private DragSource draggableConfig;

        /// <summary>
        /// Drag config object.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Drag config object.")]
        public virtual DragSource DraggableConfig
        {
            get
            {
                return this.draggableConfig;
            }
            set
            {
                if (value != null)
                {
                    value.EnableViewState = this.DesignMode;
                }
                this.draggableConfig = value;
            }
        }

        /// <summary>
        /// The group that this sprite belongs to, or an array of groups. Only relevant when added to a Ext.draw.Surface
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The group that this sprite belongs to, or an array of groups. Only relevant when added to a Ext.draw.Surface")]
        public virtual string[] Group
        {
            get
            {
                return this.State.Get<string[]>("Group", null);
            }
            set
            {
                this.State.Set("Group", value);
            }
        }  

        protected virtual void CallTemplate(string name, params object[] args)
        {
            if (this.SpriteID.IsEmpty())
            {
                throw new Exception("You have to set sprite's ID to call its methods");
            }

            if (this.Draw == null)
            {
                throw new Exception("Sprite has no DrawComponent reference");
            }

            StringBuilder sb = new StringBuilder();
            var comma = false;

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    if (comma)
                    {
                        sb.Append(",");
                    }
                    comma = true;
                    sb.Append(JSON.Serialize(arg, JSON.ScriptConvertersInternal));
                }
            }

            var template = this.IsGroup ? "{0}.surface.getGroup(\"{1}\").{2}({3});" : "{0}.get(\"{1}\").{2}({3});";

            string script = template.FormatWith(this.Draw.ClientID, this.SpriteID, name, sb.ToString());

            this.Draw.AddScript(script);
        }

        /// <summary>
        /// Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out. Note this method is severly limited in VML.
        /// </summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        [Meta]
        public virtual void AddCls(string className)
        {
            this.CallTemplate("addCls", className);
        }

        /// <summary>
        /// Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out. Note this method is severly limited in VML.
        /// </summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        [Meta]
        public virtual void AddCls(string[] className)
        {
            this.CallTemplate("addCls", className);
        }

        /// <summary>
        /// Perform custom animation on this object.
        /// </summary>
        /// <param name="cfg">An Ext.fx Anim object</param>
        [Meta]
        public virtual void Animate(AnimConfig cfg)
        {
            this.CallTemplate("animate", new JRawValue(new ClientConfig().Serialize(cfg)));
        }

        ///<summary>
        /// Ensures that all effects queued after sequenceFx is called on the element are run in sequence. This is the opposite of syncFx.
        ///</summary>
        [Meta]
        public virtual void SequenceFx()
        {
            this.CallTemplate("sequenceFx");
        }

        ///<summary>
        /// Stops any running effects and clears this object's internal effects queue if it contains any additional effects that haven't started yet.
        ///</summary>
        [Meta]
        public virtual void StopAnimation()
        {
            this.CallTemplate("stopAnimation");
        }

        ///<summary>
        /// Ensures that all effects queued after syncFx is called on the element are run concurrently. This is the opposite of sequenceFx.
        ///</summary>
        [Meta]
        public virtual void SyncFx()
        {
            this.CallTemplate("syncFx");
        }

        /// <summary>
        /// Removes the sprite and clears all listeners.
        /// </summary>
        [Meta]
        public virtual void Destroy()
        {
            this.CallTemplate("destroy");
        }

        /// <summary>
        /// Hides the sprite.
        /// </summary>
        /// <param name="redraw">Flag to immediatly draw the change.</param>
        [Meta]
        public virtual void Hide(bool redraw)
        {
            this.CallTemplate("hide", redraw);
        }

        /// <summary>
        /// Hides the sprite.
        /// </summary>
        [Meta]
        public virtual void Hide()
        {
            this.CallTemplate("hide");
        }

        /// <summary>
        /// Redraws the sprite.
        /// </summary>
        [Meta]
        public virtual void Redraw()
        {
            this.CallTemplate("redraw");
        }

        /// <summary>
        /// Removes the sprite.
        /// </summary>
        [Meta]
        public virtual void Remove()
        {
            this.CallTemplate("remove");
        }

        /// <summary>
        /// Removes one or more CSS classes from the element.
        /// </summary>
        /// <param name="className">The CSS class to remove, or an array of classes. Note this method is severly limited in VML.</param>
        [Meta]
        public virtual void RemoveCls(string className)
        {
            this.CallTemplate("removeCls", className);
        }

        /// <summary>
        /// Removes one or more CSS classes from the element.
        /// </summary>
        /// <param name="className">The CSS class to remove, or an array of classes. Note this method is severly limited in VML.</param>
        [Meta]
        public virtual void RemoveCls(string[] className)
        {
            this.CallTemplate("removeCls", className);
        }

        /// <summary>
        /// Change the attributes of the sprite.
        /// </summary>
        /// <param name="attrs">attributes to be changed on the sprite.</param>
        /// <param name="redraw">Flag to immediatly draw the change.</param>
        [Meta]
        public virtual void SetAttributes(Dictionary<string,object> attrs, bool redraw)
        {
            this.CallTemplate("setAttributes", attrs, redraw);
        }

        /// <summary>
        /// Change the attributes of the sprite.
        /// </summary>
        /// <param name="attrs">attributes to be changed on the sprite.</param>
        [Meta]
        public virtual void SetAttributes(Dictionary<string, object> attrs)
        {
            this.CallTemplate("setAttributes", attrs);
        }

        /// <summary>
        /// Change the attributes of the sprite.
        /// </summary>
        /// <param name="attrs">attributes to be changed on the sprite.</param>
        /// <param name="redraw">Flag to immediatly draw the change.</param>
        [Meta]
        public virtual void SetAttributes(SpriteAttributes attrs, bool redraw)
        {
            this.CallTemplate("setAttributes", JRawValue.From(attrs.Serialize()), redraw);
        }

        /// <summary>
        /// Change the attributes of the sprite.
        /// </summary>
        /// <param name="attrs">attributes to be changed on the sprite.</param>
        [Meta]
        public virtual void SetAttributes(SpriteAttributes attrs)
        {
            this.CallTemplate("setAttributes", JRawValue.From(attrs.Serialize()));
        }

        /// <summary>
        /// Wrapper for setting style properties, also takes single object parameter of multiple styles.
        /// </summary>
        /// <param name="styles">An object of multiple styles.</param>
        [Meta]
        public virtual void SetStyle(Dictionary<string, string> styles)
        {
            this.CallTemplate("setStyle", styles);
        }

        /// <summary>
        /// Wrapper for setting style properties, also takes single object parameter of multiple styles.
        /// </summary>
        /// <param name="property">The style property to be set</param>
        /// <param name="value">The value to apply to the given property</param>
        [Meta]
        public virtual void SetStyle(string property, string value)
        {
            this.CallTemplate("setStyle", property, value);
        }

        /// <summary>
        /// Shows the sprite.
        /// </summary>
        /// <param name="redraw">Flag to immediatly draw the change.</param>
        [Meta]
        public virtual void Show(bool redraw)
        {
            this.CallTemplate("show", redraw);
        }

        /// <summary>
        /// Shows the sprite.
        /// </summary>
        [Meta]
        public virtual void Show()
        {
            this.CallTemplate("show");
        }

        public virtual string Proxy
        {
            get
            {
                if (this.SpriteID.IsEmpty())
                {
                    throw new Exception("You have to set sprite's ID to call its methods");
                }

                if (this.Draw == null)
                {
                    throw new Exception("Sprite has no DrawComponent reference");
                }
                var template = this.IsGroup ? "{0}.surface.getGroup(\"{1}\")" : "{0}.get(\"{1}\")";
                return template.FormatWith(this.Draw.ClientID, this.SpriteID);
            }
        }

        private SpriteListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public SpriteListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new SpriteListeners());
            }
        }
    }

    public class SpriteCollection : BaseItemCollection<Sprite>
    {
    }
}
