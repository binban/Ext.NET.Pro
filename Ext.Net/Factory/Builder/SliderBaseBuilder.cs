/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
        public abstract partial class Builder<TSliderBase, TBuilder> : Field.Builder<TSliderBase, TBuilder>
            where TSliderBase : SliderBase
            where TBuilder : Builder<TSliderBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSliderBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True for single thumb slider
			/// </summary>
            public virtual TBuilder Single(bool single)
            {
                this.ToComponent().Single = single;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Thumbs value
			/// </summary>
            public virtual TBuilder Number(double? number)
            {
                this.ToComponent().Number = number;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Turn on or off animation. Defaults to true
			/// </summary>
            public virtual TBuilder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Determines whether or not clicking on the Slider axis will change the slider. Defaults to true
			/// </summary>
            public virtual TBuilder ClickToChange(bool clickToChange)
            {
                this.ToComponent().ClickToChange = clickToChange;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disallow thumbs from overlapping one another. Defaults to true
			/// </summary>
            public virtual TBuilder ConstrainThumbs(bool constrainThumbs)
            {
                this.ToComponent().ConstrainThumbs = constrainThumbs;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of decimal places to which to round the Slider's value. Defaults to 0.
			/// </summary>
            public virtual TBuilder DecimalPrecision(int decimalPrecision)
            {
                this.ToComponent().DecimalPrecision = decimalPrecision;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.
			/// </summary>
            public virtual TBuilder Increment(int increment)
            {
                this.ToComponent().Increment = increment;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.
			/// </summary>
            public virtual TBuilder KeyIncrement(int keyIncrement)
            {
                this.ToComponent().KeyIncrement = keyIncrement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value for the Slider. Defaults to 100.
			/// </summary>
            public virtual TBuilder MaxValue(double maxValue)
            {
                this.ToComponent().MaxValue = maxValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value for the Slider. Defaults to 0.
			/// </summary>
            public virtual TBuilder MinValue(double minValue)
            {
                this.ToComponent().MinValue = minValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Orient the Slider vertically rather than horizontally, defaults to false.
			/// </summary>
            public virtual TBuilder Vertical(bool vertical)
            {
                this.ToComponent().Vertical = vertical;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to calculate snap points based on increments from zero as opposed to from this Slider's minValue.
			/// </summary>
            public virtual TBuilder ZeroBasedSnapping(bool zeroBasedSnapping)
            {
                this.ToComponent().ZeroBasedSnapping = zeroBasedSnapping;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use an Ext.slider.Tip to display tips for the value. Defaults to: true
			/// </summary>
            public virtual TBuilder UseTips(bool useTips)
            {
                this.ToComponent().UseTips = useTips;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function used to display custom text for the slider tip. Defaults to null, which will use the default on the plugin.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TipText(Action<JFunction> action)
            {
                action(this.ToComponent().TipText);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
            public virtual TBuilder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Synchronizes thumbs position to the proper proportion of the total component width based on the current slider value. This will be called automatically when the Slider is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the Slider if necessary.
			/// </summary>
            public virtual TBuilder SyncThumbs()
            {
                this.ToComponent().SyncThumbs();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Creates a new thumb and adds it to the slider
			/// </summary>
            public virtual TBuilder AddThumb(int value)
            {
                this.ToComponent().AddThumb(value);
                return this as TBuilder;
            }
            
        }        
    }
}