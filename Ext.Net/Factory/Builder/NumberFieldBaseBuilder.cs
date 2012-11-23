/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public abstract partial class NumberFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TNumberFieldBase, TBuilder> : TextFieldBase.Builder<TNumberFieldBase, TBuilder>
            where TNumberFieldBase : NumberFieldBase
            where TBuilder : Builder<TNumberFieldBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TNumberFieldBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// The fields null value.
			// /// </summary>
            // public virtual TBuilder EmptyValue(object emptyValue)
            // {
            //    this.ToComponent().EmptyValue = emptyValue;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InputType(InputType inputType)
            {
                this.ToComponent().InputType = inputType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Number (double) to initialize this field with.
			/// </summary>
            public virtual TBuilder Number(double number)
            {
                this.ToComponent().Number = number;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disallow decimal values (defaults to true).
			/// </summary>
            public virtual TBuilder AllowDecimals(bool allowDecimals)
            {
                this.ToComponent().AllowDecimals = allowDecimals;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disallow trim trailed zeros.
			/// </summary>
            public virtual TBuilder TrimTrailedZeros(bool trimTrailedZeros)
            {
                this.ToComponent().TrimTrailedZeros = trimTrailedZeros;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to prevent entering a negative sign (defaults to true).
			/// </summary>
            public virtual TBuilder AllowNegative(bool allowNegative)
            {
                this.ToComponent().AllowNegative = allowNegative;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The base set of characters to evaluate as valid numbers (defaults to '0123456789').
			/// </summary>
            public virtual TBuilder BaseChars(string baseChars)
            {
                this.ToComponent().BaseChars = baseChars;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum precision to display after the decimal separator (defaults to 2).
			/// </summary>
            public virtual TBuilder DecimalPrecision(int decimalPrecision)
            {
                this.ToComponent().DecimalPrecision = decimalPrecision;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Character(s) to allow as the decimal separator (defaults to '.').
			/// </summary>
            public virtual TBuilder DecimalSeparator(string decimalSeparator)
            {
                this.ToComponent().DecimalSeparator = decimalSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {maxValue}').
			/// </summary>
            public virtual TBuilder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum allowed value (defaults to Double.MaxValue)
			/// </summary>
            public virtual TBuilder MaxValue(Double maxValue)
            {
                this.ToComponent().MaxValue = maxValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {minValue}').
			/// </summary>
            public virtual TBuilder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum allowed value (defaults to Double.MinValue)
			/// </summary>
            public virtual TBuilder MinValue(Double minValue)
            {
                this.ToComponent().MinValue = minValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{value} is not a valid number').
			/// </summary>
            public virtual TBuilder NanText(string nanText)
            {
                this.ToComponent().NanText = nanText;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}