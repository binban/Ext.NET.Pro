/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BaseItem.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string seriesID = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string SeriesID 
			{ 
				get
				{
					return this.seriesID;
				}
				set
				{
					this.seriesID = value;
				}
			}

			private bool highlight = false;

			/// <summary>
			/// If set to true it will highlight the markers or the series when hovering with the mouse. This parameter can also be an object with the same style properties you would apply to a Ext.draw.Sprite to apply custom styles to markers and series.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Highlight 
			{ 
				get
				{
					return this.highlight;
				}
				set
				{
					this.highlight = value;
				}
			}

			private SpriteAttributes highlightConfig = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SpriteAttributes HighlightConfig 
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

			private SeriesLabel label = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual SeriesLabel Label 
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
        
			private JFunction renderer = null;

			/// <summary>
			/// A function that can be overridden to set custom styling properties to each rendered element. Passes in (sprite, record, attributes, index, store) to the function.
			/// </summary>
			public JFunction Renderer
			{
				get
				{
					if (this.renderer == null)
					{
						this.renderer = new JFunction();
					}
			
					return this.renderer;
				}
			}
			
			private bool showInLegend = true;

			/// <summary>
			/// Whether to show this series in the legend. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowInLegend 
			{ 
				get
				{
					return this.showInLegend;
				}
				set
				{
					this.showInLegend = value;
				}
			}

			private ChartTip tips = null;

			/// <summary>
			/// Add tooltips to the visualization's markers. The options for the tips are the same configuration used with Ext.tip.ToolTip.
			/// </summary>
			[DefaultValue(null)]
			public virtual ChartTip Tips 
			{ 
				get
				{
					return this.tips;
				}
				set
				{
					this.tips = value;
				}
			}

			private string title = "";

			/// <summary>
			/// The human-readable name of the series.
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private string[] titles = null;

			/// <summary>
			/// The human-readable name of the series.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Titles 
			{ 
				get
				{
					return this.titles;
				}
				set
				{
					this.titles = value;
				}
			}

			private string[] xField = null;

			/// <summary>
			/// The field used to access the x axis value from the items from the data source.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] XField 
			{ 
				get
				{
					return this.xField;
				}
				set
				{
					this.xField = value;
				}
			}

			private string[] yField = null;

			/// <summary>
			/// The field used to access the y axis value from the items from the data source.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] YField 
			{ 
				get
				{
					return this.yField;
				}
				set
				{
					this.yField = value;
				}
			}
        
			private SeriesListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public SeriesListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new SeriesListeners();
					}
			
					return this.listeners;
				}
			}
			
        }
    }
}