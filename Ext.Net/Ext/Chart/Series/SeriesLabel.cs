/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public partial class SeriesLabel : SpriteAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel()
        {
        }

        /// <summary>
        /// Specifies the presence and position of labels for each pie slice. Either "rotate", "middle", "insideStart", "insideEnd", "outside", "over", "under", or "none" to prevent label rendering. Default value: 'none'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToCamelLower)]
        [DefaultValue(SeriesLabelDisplay.None)]
        [Description("Specifies the presence and position of labels for each pie slice.")]
        public virtual SeriesLabelDisplay Display
        {
            get
            {
                return this.State.Get<SeriesLabelDisplay>("Display", SeriesLabelDisplay.None);
            }
            set
            {
                this.State.Set("Display", value);
            }
        }

        /// <summary>
        /// The color of the label text. Default value: '#000' (black).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The color of the label text. Default value: '#000' (black).")]
        public virtual string Color
        {
            get
            {
                return this.State.Get<string>("Color", "");
            }
            set
            {
                this.State.Set("Color", value);
            }
        }

        /// <summary>
        /// True to render the label in contrasting color with the backround. Default value: false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to render the label in contrasting color with the backround. Default value: false.")]
        public virtual bool Contrast
        {
            get
            {
                return this.State.Get<bool>("Contrast", false);
            }
            set
            {
                this.State.Set("Contrast", value);
            }
        }

        /// <summary>
        /// The name of the field to be displayed in the label. Default value: 'name'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The name of the field to be displayed in the label. Default value: 'name'.")]
        public virtual string Field
        {
            get
            {
                return this.State.Get<string>("Field", "");
            }
            set
            {
                this.State.Set("Field", value);
            }
        }

        /// <summary>
        /// Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(50)]
        [Description("Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.")]
        public virtual int MinMargin
        {
            get
            {
                return this.State.Get<int>("MinMargin", 50);
            }
            set
            {
                this.State.Set("MinMargin", value);
            }
        }

        /// <summary>
        /// Either "horizontal" or "vertical". Dafault value: "horizontal".
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(Orientation.Horizontal)]
        [Description("Either \"horizontal\" or \"vertical\". Dafault value: \"horizontal\".")]
        public virtual Orientation Orientation
        {
            get
            {
                return this.State.Get<Orientation>("Orientation", Orientation.Horizontal);
            }
            set
            {
                this.State.Set("Orientation", value);
            }
        }

        private JFunction renderer;

        /// <summary>
        /// Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }")]
        public virtual JFunction Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.renderer.Args = new string[] { "value" };
                    }
                }

                return this.renderer;
            }
        }
    }
}
