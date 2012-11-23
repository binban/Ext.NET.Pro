/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Series is the abstract class containing the common logic to all chart series. Series includes methods from Labels, Highlights, Tips and Callouts mixins. This class implements the logic of handling mouse events, animating, hiding, showing all elements and returning the color of the series to be used as a legend item.
    /// 
    /// The series class supports listeners via the Observable syntax. Some of these listeners are:
    /// itemmouseup When the user interacts with a marker.
    /// itemmousedown When the user interacts with a marker.
    /// itemmousemove When the user iteracts with a marker.
    /// afterrender Will be triggered when the animation ends or when the series has been rendered completely.
    /// </summary>
    [Meta]
    public abstract partial class AbstractSeries : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("seriesId")]
        [DefaultValue("")]
        [Description("")]
        public virtual string SeriesID
        {
            get
            {
                return this.State.Get<string>("SeriesID", "");
            }
            set
            {
                this.State.Set("SeriesID", value);
            }
        }

        /// <summary>
        /// If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.")]
        public virtual bool Highlight
        {
            get
            {                
                return this.State.Get<bool>("Highlight", false);
            }
            set
            {
                this.State.Set("Highlight", value);
            }
        }

        private SpriteAttributes highlightConfig;

        /// <summary>
        /// If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.
        /// </summary>
        [Meta]
        [ConfigOption("highlightCfg", JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes HighlightConfig
        {
            get
            {
                return this.highlightConfig;
            }
            set
            {
                this.highlightConfig = value;
            }
        }

        private SeriesLabel label;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SeriesLabel Label
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
            }
        }

        private JFunction renderer;

        /// <summary>
        /// A function that can be overridden to set custom styling properties to each rendered element. Passes in (sprite, record, attributes, index, store) to the function.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function that can be overridden to set custom styling properties to each rendered element. Passes in (sprite, record, attributes, index, store) to the function.")]
        public virtual JFunction Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.renderer.Args = new string[] { "sprite", "record", "attributes", "index", "store" };
                    }
                }

                return this.renderer;
            }
        }

        /// <summary>
        /// Whether to show this series in the legend. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Whether to show this series in the legend. Defaults to: true")]
        public virtual bool ShowInLegend
        {
            get
            {
                return this.State.Get<bool>("ShowInLegend", true);
            }
            set
            {
                this.State.Set("ShowInLegend", value);
            }
        }

        private ChartTip tips;

        /// <summary>
        /// Add tooltips to the visualization's markers. The options for the tips are the same configuration used with Ext.tip.ToolTip.
        /// </summary>
        [Meta]
        [ConfigOption("tips", typeof(LazyControlJsonConverter))]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Add tooltips to the visualization's markers. The options for the tips are the same configuration used with Ext.tip.ToolTip.")]
        public virtual ChartTip Tips
        {
            get
            {
                return this.tips;
            }
            set
            {
                this.InitTips(false);
                this.tips = value;
                this.InitTips(true);
            }
        }

        protected internal virtual void InitTips(bool add)
        {
            Chart chart = this.Owner as Chart;
            
            if (chart == null || this.tips == null)
            {
                return;
            }

            if (add)
            {
                if (!chart.Controls.Contains(this.tips))
                {
                    chart.Controls.Add(this.tips);
                }

                if (!chart.LazyItems.Contains(this.tips))
                {
                    chart.LazyItems.Add(this.tips);
                }
            }
            else
            {
                if (chart.Controls.Contains(this.tips))
                {
                    chart.Controls.Remove(this.tips);
                }

                if (chart.LazyItems.Contains(this.tips))
                {
                    chart.LazyItems.Remove(this.tips);
                }
            }
        }

        /// <summary>
        /// The human-readable name of the series.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The human-readable name of the series.")]
        [DirectEventUpdate(MethodName="SetTitle")]
        public virtual string Title
        {
            get
            {
                return this.State.Get<string>("Title", "");
            }
            set
            {
                this.State.Set("Title", value);
            }
        }

        /// <summary>
        /// The human-readable name of the series.
        /// </summary>
        [Meta]
        [ConfigOption("title", typeof(SingleStringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The human-readable name of the series.")]
        [DirectEventUpdate(MethodName = "SetTitles")]
        public virtual string[] Titles
        {
            get
            {
                return this.State.Get<string[]>("Titles", null);
            }
            set
            {
                this.State.Set("Titles", value);
            }
        }

        /// <summary>
        /// The field used to access the x axis value from the items from the data source.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleStringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The field used to access the x axis value from the items from the data source.")]
        public virtual string[] XField
        {
            get
            {
                return this.State.Get<string[]>("XField", null);
            }
            set
            {
                this.State.Set("XField", value);
            }
        }

        /// <summary>
        /// The field used to access the y axis value from the items from the data source.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(SingleStringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The field used to access the y axis value from the items from the data source.")]
        public virtual string[] YField
        {
            get
            {
                return this.State.Get<string[]>("YField", null);
            }
            set
            {
                this.State.Set("YField", value);
            }
        }

        private SeriesListeners listeners;

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
        public SeriesListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new SeriesListeners());
            }
        }

        protected virtual void CallTemplate(string name, params object[] args)
        {
            if (this.SeriesID.IsEmpty())
            {
                throw new Exception("You have to set series ID to call its methods");
            }

            Chart chart = this.Owner as Chart;

            if (chart == null)
            {
                throw new Exception("Series has no Chart reference");
            }

            StringBuilder sb = new StringBuilder();
            
            bool comma = false;

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

            string template = "{0}.series.get(\"{1}\").{2}({3});";

            string script = template.FormatWith(chart.ClientID, this.SeriesID, name, sb.ToString());

            chart.AddScript(script);
        }

        /// <summary>
        /// Hides all the elements in the series.
        /// </summary>
        [Meta]
        public virtual void HideAll()
        {
            this.CallTemplate("hideAll");
        }

        /// <summary>
        /// Shows all the elements in the series.
        /// </summary>
        [Meta]
        public virtual void ShowAll()
        {
            this.CallTemplate("showAll");
        }

        /// <summary>
        /// Changes the value of the title for the series.
        /// </summary>
        /// <param name="title">The new single title for the series (applies to series with only one yField)</param>
        [Meta]
        public virtual void SetTitle(string title)
        {
            this.CallTemplate("setTitle", title);
        }

        /// <summary>
        /// Changes values of the titles for the series.
        /// </summary>
        /// <param name="title">The new titles for the series</param>
        [Meta]
        public virtual void SetTitles(string[] titles)
        {
            if(titles == null)
            {
                return;
            }

            for (int i = 0; i < titles.Length; i++)
            {
                this.SetTitle(i, titles[i]);
            }
        }

        /// <summary>
        /// Changes the value of the title for the series. This will set the title for a single indexed yField
        /// </summary>
        /// <param name="index"></param>
        /// <param name="title"></param>
        [Meta]
        public virtual void SetTitle(int index, string title)
        {
            this.CallTemplate("setTitle", index, title);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SeriesCollection : BaseItemCollection<AbstractSeries>
    {
    }
}
