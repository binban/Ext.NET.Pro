/********
 * @version   : 1.5.0 - Ext.NET Pro License
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
    public partial class TimeField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TimeField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TimeField.Config Conversion to TimeField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TimeField(TimeField.Config config)
        {
            return new TimeField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComboBox.Config 
        { 
			/*  Implicit TimeField.Config Conversion to TimeField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TimeField.Builder(TimeField.Config config)
			{
				return new TimeField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private object emptyValue = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// The fields null value.
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public override object EmptyValue 
			{ 
				get
				{
					return this.emptyValue;
				}
				set
				{
					this.emptyValue = value;
				}
			}

			private TimeSpan selectedTime = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public virtual TimeSpan SelectedTime 
			{ 
				get
				{
					return this.selectedTime;
				}
				set
				{
					this.selectedTime = value;
				}
			}

			private object selectedValue = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual object SelectedValue 
			{ 
				get
				{
					return this.selectedValue;
				}
				set
				{
					this.selectedValue = value;
				}
			}

			private object value = null;

			/// <summary>
			/// 
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

			private string altFormats = "";

			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'm/d/Y|m-d-y|m-d-Y|m/d|m-d|d').
			/// </summary>
			[DefaultValue("")]
			public virtual string AltFormats 
			{ 
				get
				{
					return this.altFormats;
				}
				set
				{
					this.altFormats = value;
				}
			}

			private string format = "t";

			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'h:mm tt', e.g., '3:15 PM'). For 24-hour time format try 'H:mm' instead.
			/// </summary>
			[DefaultValue("t")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

			private int increment = 15;

			/// <summary>
			/// The number of minutes between each time value in the list (defaults to 15).
			/// </summary>
			[DefaultValue(15)]
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

			private string maxText = "";

			/// <summary>
			/// The error text to display when the time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxText 
			{ 
				get
				{
					return this.maxText;
				}
				set
				{
					this.maxText = value;
				}
			}

			private TimeSpan maxTime = new TimeSpan(9223372036854775807);

			/// <summary>
			/// The maximum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to null).
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "9223372036854775807")]
			public virtual TimeSpan MaxTime 
			{ 
				get
				{
					return this.maxTime;
				}
				set
				{
					this.maxTime = value;
				}
			}

			private TimeSpan minTime = new TimeSpan(-9223372036854775808);

			/// <summary>
			/// The minimum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to null).
			/// </summary>
			[DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
			public virtual TimeSpan MinTime 
			{ 
				get
				{
					return this.minTime;
				}
				set
				{
					this.minTime = value;
				}
			}

			private string minText = "";

			/// <summary>
			/// The error text to display when the date in the cell is before minValue (defaults to 'The time in this field must be equal to or after {0}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinText 
			{ 
				get
				{
					return this.minText;
				}
				set
				{
					this.minText = value;
				}
			}

        }
    }
}