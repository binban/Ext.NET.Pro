/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public abstract partial class SliderBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool single = false;

			/// <summary>
			/// True for single thumb slider
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Single 
			{ 
				get
				{
					return this.single;
				}
				set
				{
					this.single = value;
				}
			}

			private double? number = null;

			/// <summary>
			/// Thumbs value
			/// </summary>
			[DefaultValue(null)]
			public virtual double? Number 
			{ 
				get
				{
					return this.number;
				}
				set
				{
					this.number = value;
				}
			}

			private bool animate = true;

			/// <summary>
			/// Turn on or off animation. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Animate 
			{ 
				get
				{
					return this.animate;
				}
				set
				{
					this.animate = value;
				}
			}

			private bool clickToChange = true;

			/// <summary>
			/// Determines whether or not clicking on the Slider axis will change the slider. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClickToChange 
			{ 
				get
				{
					return this.clickToChange;
				}
				set
				{
					this.clickToChange = value;
				}
			}

			private bool constrainThumbs = true;

			/// <summary>
			/// True to disallow thumbs from overlapping one another. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ConstrainThumbs 
			{ 
				get
				{
					return this.constrainThumbs;
				}
				set
				{
					this.constrainThumbs = value;
				}
			}

			private int decimalPrecision = 0;

			/// <summary>
			/// The number of decimal places to which to round the Slider's value. Defaults to 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int DecimalPrecision 
			{ 
				get
				{
					return this.decimalPrecision;
				}
				set
				{
					this.decimalPrecision = value;
				}
			}

			private int increment = 0;

			/// <summary>
			/// How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Increment 
			{ 
				get
				{
					return this.increment;
				}
				set
				{
					this.increment = value;
				}
			}

			private int keyIncrement = 1;

			/// <summary>
			/// How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.
			/// </summary>
			[DefaultValue(1)]
			public virtual int KeyIncrement 
			{ 
				get
				{
					return this.keyIncrement;
				}
				set
				{
					this.keyIncrement = value;
				}
			}

			private double maxValue = 100d;

			/// <summary>
			/// The maximum value for the Slider. Defaults to 100.
			/// </summary>
			[DefaultValue(100d)]
			public virtual double MaxValue 
			{ 
				get
				{
					return this.maxValue;
				}
				set
				{
					this.maxValue = value;
				}
			}

			private double minValue = 0d;

			/// <summary>
			/// The minimum value for the Slider. Defaults to 0.
			/// </summary>
			[DefaultValue(0d)]
			public virtual double MinValue 
			{ 
				get
				{
					return this.minValue;
				}
				set
				{
					this.minValue = value;
				}
			}

			private bool vertical = false;

			/// <summary>
			/// Orient the Slider vertically rather than horizontally, defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Vertical 
			{ 
				get
				{
					return this.vertical;
				}
				set
				{
					this.vertical = value;
				}
			}

			private bool zeroBasedSnapping = false;

			/// <summary>
			/// Set to true to calculate snap points based on increments from zero as opposed to from this Slider's minValue.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ZeroBasedSnapping 
			{ 
				get
				{
					return this.zeroBasedSnapping;
				}
				set
				{
					this.zeroBasedSnapping = value;
				}
			}

			private bool useTips = true;

			/// <summary>
			/// True to use an Ext.slider.Tip to display tips for the value. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool UseTips 
			{ 
				get
				{
					return this.useTips;
				}
				set
				{
					this.useTips = value;
				}
			}
        
			private JFunction tipText = null;

			/// <summary>
			/// A function used to display custom text for the slider tip. Defaults to null, which will use the default on the plugin.
			/// </summary>
			public JFunction TipText
			{
				get
				{
					if (this.tipText == null)
					{
						this.tipText = new JFunction();
					}
			
					return this.tipText;
				}
			}
			
			private object value = null;

			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
			[DefaultValue(null)]
			public override object Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}

        }
    }
}