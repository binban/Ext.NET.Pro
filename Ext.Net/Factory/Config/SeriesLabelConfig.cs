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
    public partial class SeriesLabel
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public SeriesLabel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit SeriesLabel.Config Conversion to SeriesLabel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator SeriesLabel(SeriesLabel.Config config)
        {
            return new SeriesLabel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : SpriteAttributes.Config 
        { 
			/*  Implicit SeriesLabel.Config Conversion to SeriesLabel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator SeriesLabel.Builder(SeriesLabel.Config config)
			{
				return new SeriesLabel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private SeriesLabelDisplay display = SeriesLabelDisplay.None;

			/// <summary>
			/// Specifies the presence and position of labels for each pie slice.
			/// </summary>
			[DefaultValue(SeriesLabelDisplay.None)]
			public virtual SeriesLabelDisplay Display 
			{ 
				get
				{
					return this.display;
				}
				set
				{
					this.display = value;
				}
			}

			private string color = "";

			/// <summary>
			/// The color of the label text. Default value: '#000' (black).
			/// </summary>
			[DefaultValue("")]
			public virtual string Color 
			{ 
				get
				{
					return this.color;
				}
				set
				{
					this.color = value;
				}
			}

			private bool contrast = false;

			/// <summary>
			/// True to render the label in contrasting color with the backround. Default value: false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Contrast 
			{ 
				get
				{
					return this.contrast;
				}
				set
				{
					this.contrast = value;
				}
			}

			private string field = "";

			/// <summary>
			/// The name of the field to be displayed in the label. Default value: 'name'.
			/// </summary>
			[DefaultValue("")]
			public virtual string Field 
			{ 
				get
				{
					return this.field;
				}
				set
				{
					this.field = value;
				}
			}

			private int minMargin = 50;

			/// <summary>
			/// Specifies the minimum distance from a label to the origin of the visualization. This parameter is useful when using PieSeries width variable pie slice lengths. Default value: 50.
			/// </summary>
			[DefaultValue(50)]
			public virtual int MinMargin 
			{ 
				get
				{
					return this.minMargin;
				}
				set
				{
					this.minMargin = value;
				}
			}

			private Orientation orientation = Orientation.Horizontal;

			/// <summary>
			/// Either \"horizontal\" or \"vertical\". Dafault value: \"horizontal\".
			/// </summary>
			[DefaultValue(Orientation.Horizontal)]
			public virtual Orientation Orientation 
			{ 
				get
				{
					return this.orientation;
				}
				set
				{
					this.orientation = value;
				}
			}
        
			private JFunction renderer = null;

			/// <summary>
			/// Optional function for formatting the label into a displayable value. Default value: function(value) { return value; }
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
			
        }
    }
}