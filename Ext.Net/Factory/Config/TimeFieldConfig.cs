/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
        new public partial class Config : PickerField.Config 
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

			private string altFormats = "";

			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H|gi a|hi a|giA|hiA|gi A|hi A').
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
			/// The default time format string which can be overriden for localization support. The format must be valid according to Ext.Date.parse (defaults to 'g:i A', e.g., '3:15 PM'). For 24-hour time format try 'H:i' instead.
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

			private string maxText = "The time in this field must be equal to or before {0}";

			/// <summary>
			/// The error text to display when the entered time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
			/// </summary>
			[DefaultValue("The time in this field must be equal to or before {0}")]
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
			/// The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
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
			/// The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see format and altFormats (defaults to undefined).
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

			private string minText = "The time in this field must be equal to or after {0}";

			/// <summary>
			/// The error text to display when the entered time is before minValue (defaults to 'The time in this field must be equal to or after {0}').
			/// </summary>
			[DefaultValue("The time in this field must be equal to or after {0}")]
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

			private int pickerMaxHeight = 300;

			/// <summary>
			/// The maximum height of the Ext.picker.Time dropdown. Defaults to 300.
			/// </summary>
			[DefaultValue(300)]
			public virtual int PickerMaxHeight 
			{ 
				get
				{
					return this.pickerMaxHeight;
				}
				set
				{
					this.pickerMaxHeight = value;
				}
			}

			private bool selectOnTab = true;

			/// <summary>
			/// Whether the Tab key should select the currently highlighted item. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SelectOnTab 
			{ 
				get
				{
					return this.selectOnTab;
				}
				set
				{
					this.selectOnTab = value;
				}
			}

			private bool snapToIncrement = false;

			/// <summary>
			/// Specify as true to enforce that only values on the increment boundary are accepted. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SnapToIncrement 
			{ 
				get
				{
					return this.snapToIncrement;
				}
				set
				{
					this.snapToIncrement = value;
				}
			}

			private string submitFormat = "t";

			/// <summary>
			/// The date format string which will be submitted to the server. The format must be valid according to Ext.Date.parse (defaults to format).
			/// </summary>
			[DefaultValue("t")]
			public virtual string SubmitFormat 
			{ 
				get
				{
					return this.submitFormat;
				}
				set
				{
					this.submitFormat = value;
				}
			}
        
			private PickerFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public PickerFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new PickerFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private PickerFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public PickerFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new PickerFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}