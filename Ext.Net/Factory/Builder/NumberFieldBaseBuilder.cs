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
    public abstract partial class NumberFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TNumberFieldBase, TBuilder> : SpinnerFieldBase.Builder<TNumberFieldBase, TBuilder>
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
			/// True to automatically strip not allowed characters from the field. Defaults to false
			/// </summary>
            public virtual TBuilder AutoStripChars(bool autoStripChars)
            {
                this.ToComponent().AutoStripChars = autoStripChars;
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
			/// Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {0}').
			/// </summary>
            public virtual TBuilder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum allowed value (defaults to Number.MAX_VALUE). Will be used by the field's validation logic, and for enabling/disabling the up spinner button.
			/// </summary>
            public virtual TBuilder MaxValue(Double maxValue)
            {
                this.ToComponent().MaxValue = maxValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {0}').
			/// </summary>
            public virtual TBuilder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum allowed value (defaults to Number.NEGATIVE_INFINITY). Will be used by the field's validation logic, and for enabling/disabling the down spinner button.
			/// </summary>
            public virtual TBuilder MinValue(Double minValue)
            {
                this.ToComponent().MinValue = minValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{0} is not a valid number').
			/// </summary>
            public virtual TBuilder NanText(string nanText)
            {
                this.ToComponent().NanText = nanText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the value is negative and minValue is set to 0. This is used instead of the minText in that circumstance only. Defaults to: \"The value cannot be negative\"
			/// </summary>
            public virtual TBuilder NegativeText(string negativeText)
            {
                this.ToComponent().NegativeText = negativeText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies a numeric interval by which the field's value will be incremented or decremented when the user invokes the spinner. Defaults to 1.
			/// </summary>
            public virtual TBuilder Step(double step)
            {
                this.ToComponent().Step = step;
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
			/// False to ensure that the getSubmitValue method strips always uses . as the separator, regardless of the decimalSeparator configuration. Defaults to: true
			/// </summary>
            public virtual TBuilder SubmitLocaleSeparator(bool submitLocaleSeparator)
            {
                this.ToComponent().SubmitLocaleSeparator = submitLocaleSeparator;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}