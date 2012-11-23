/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    [Meta]
    [Description("")]
    public partial class DateFilter : GridFilter
    {
        public DateFilter() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. DateFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.Date;
            }
        }

        /// <summary>
        /// The text displayed for the 'Before' menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("Before")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'Before' menu item")]
        public string BeforeText
        {
            get
            {
                return this.State.Get<string>("BeforeText", "Before");
            }
            set
            {
                this.State.Set("BeforeText", value);
            }
        }

        /// <summary>
        /// The text displayed for the 'After' menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("After")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'After' menu item")]
        public string AfterText
        {
            get
            {
                return this.State.Get<string>("AfterText", "After");
            }
            set
            {
                this.State.Set("AfterText", value);
            }
        }

        /// <summary>
        /// The text displayed for the 'On' menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("On")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'On' menu item")]
        public virtual string OnText
        {
            get
            {
                return this.State.Get<string>("OnText", "On");
            }
            set
            {
                this.State.Set("OnText", value);
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
        /// </summary>
        [Meta]
        [Category("8. DateField")]
        [DefaultValue("d")]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').")]
        public virtual string Format
        {
            get
            {
                return this.State.Get<string>("Format", "d");
            }
            set
            {
                this.State.Set("Format", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dateFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format);
            }
        }

        private DatePickerOptions pickerOptions;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("pickerOpts", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public DatePickerOptions DatePickerOptions
        {
            get
            {
                if (pickerOptions == null)
                {
                    pickerOptions = new DatePickerOptions();
                }

                return pickerOptions;
            }
        }

        /// <summary>
        /// Allowable date as passed to the Ext.DatePicker
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "9999-12-31")]
        [Bindable(true)]
        [Description("Allowable date as passed to the Ext.DatePicker")]
        public virtual DateTime MaxDate
        {
            get
            {
                object obj = this.State.Get<object>("MaxDate",null);

                if (obj == null && this.DesignMode)
                {
                    return DateTime.MinValue;
                }

                return obj == null ? new DateTime(9999, 12, 31) : (DateTime)obj;
            }
            set
            {
                this.State.Set("MaxDate", value.Date);
            }
        }

        /// <summary>
        /// Allowable date as passed to the Ext.DatePicker
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Bindable(true)]
        [Description("Allowable date as passed to the Ext.DatePicker")]
        public virtual DateTime MinDate
        {
            get
            {
                return this.State.Get<DateTime>("MinDate", new DateTime(0001, 01, 01));
            }
            set
            {
                this.State.Set("MinDate", value.Date);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Meta]
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? BeforeValue
        {
            get
            {
                return this.State.Get<DateTime?>("BeforeValue", null);
            }
            set
            {
                this.State.Set("BeforeValue", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Meta]
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? AfterValue
        {
            get
            {
                return this.State.Get<DateTime?>("AfterValue", null);
            }
            set
            {
                this.State.Set("AfterValue", value);
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Meta]
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? OnValue
        {
            get
            {
                return this.State.Get<DateTime?>("OnValue", null);
            }
            set
            {
                this.State.Set("OnValue", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(DateTime? afterValue, DateTime? beforeValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.Plugin != null)
            {
                string value = "{before:".ConcatWith(beforeValue.HasValue ? JSON.Serialize(beforeValue.Value, JSON.ScriptConverters) : "undefined",
                    ",after:", afterValue.HasValue ? JSON.Serialize(afterValue.Value, JSON.ScriptConverters) : "undefined", "}");

                this.ParentGrid.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(DateTime? onValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.Plugin != null)
            {
                string value = "{on:".ConcatWith(onValue.HasValue ? JSON.Serialize(onValue.Value, JSON.ScriptConverters) : "undefined", "}");

                this.Plugin.AddScript("{0}.getFilter({1}).setValue({2});", this.Plugin.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ValueProxy
        {
            get
            {
                if (this.BeforeValue.HasValue || this.AfterValue.HasValue || this.OnValue.HasValue)
                {
                    StringWriter sw = new StringWriter(new StringBuilder());
                    JsonTextWriter jw = new JsonTextWriter(sw);
                    jw.WriteStartObject();

                    if (this.BeforeValue.HasValue)
                    {
                        jw.WritePropertyName("before");
                        jw.WriteRawValue(JSON.Serialize(this.BeforeValue.Value, JSON.ScriptConverters));
                    }

                    if (this.AfterValue.HasValue)
                    {
                        jw.WritePropertyName("after");
                        jw.WriteRawValue(JSON.Serialize(this.AfterValue.Value, JSON.ScriptConverters));
                    }

                    if (this.OnValue.HasValue)
                    {
                        jw.WritePropertyName("on");
                        jw.WriteRawValue(JSON.Serialize(this.OnValue.Value, JSON.ScriptConverters));
                    }
                    
                    jw.WriteEndObject();

                    return sw.GetStringBuilder().ToString();
                }

                return "";
            }
        }
    }
}