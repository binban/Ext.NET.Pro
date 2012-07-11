/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The field definition object which specify field names, and optionally,
    /// data types, and a mapping for an Reader to extract the field's value
    /// from a data object.
    /// </summary>
    [Meta]
    [Description("")]
    public partial class RecordField : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RecordField() { }

        private JFunction convert;
        private JFunction customSortType;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RecordField(string name)
        {
            this.Name = name;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RecordField(string name, RecordFieldType type)
        {
            this.Name = name;
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RecordField(string name, RecordFieldType type, string dateFormat)
        {
            this.Name = name;
            this.Type = type;
            this.DateFormat = dateFormat;
        }

        /// <summary>
        /// Used for validating a record, defaults to true. An empty value here will cause Ext.data.Record.isValid to evaluate to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("Used for validating a record, defaults to true. An empty value here will cause Ext.data.Record.isValid to evaluate to false.")]
        public virtual bool AllowBlank
        {
            get
            {
                object obj = this.ViewState["AllowBlank"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowBlank"] = value;
            }
        }

        /// <summary>
        /// The name by which the field is referenced within the Record.
        /// This is referenced by, for example the DataIndex property in
        /// column definition objects passed to ColumnModel
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("The name by which the field is referenced within the Record. This is referenced by, for example the DataIndex property in column definition objects passed to ColumnModel")]
        public virtual string Name
        {
            get
            {
                object obj = this.ViewState["Name"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Name"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("name")]
        [Description("")]
        protected virtual string NameProxy
        {
            get
            {
                return this.Name.IsEmpty() ? this.Mapping : this.Name;
            }
        }

        /// <summary>
        /// (Optional) A path specification for use by the Reader implementation
        /// that is creating the Record to access the data value from the data object.
        /// 
        /// If an JsonReader is being used, then this is a string containing the javascript
        /// expression to reference the data relative to the Record item's root.
        /// 
        /// If an XmlReader is being used, this is an Ext.DomQuery path to the data item
        /// relative to the Record element.
        /// 
        /// If the mapping expression is the same as the field name, this may be omitted.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("(Optional) A path specification for use by the Reader implementation that is creating the Record to access the data value from the data object. If an JsonReader is being used, then this is a string containing the javascript expression to reference the data relative to the Record item's root. If an XmlReader is being used, this is an Ext.DomQuery path to the data item relative to the Record element. If the mapping expression is the same as the field name, this may be omitted.")]
        public virtual string Mapping
        {
            get
            {
                object obj = this.ViewState["Mapping"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Mapping"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("")]
        public virtual string ServerMapping
        {
            get
            {
                object obj = this.ViewState["ServerMapping"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["ServerMapping"] = value;
            }
        }

        /// <summary>
        /// The data type for conversion to displayable value
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("Config Options")]
        [DefaultValue(RecordFieldType.Auto)]
        [Description("The data type for conversion to displayable value")]
        public virtual RecordFieldType Type
        {
            get
            {
                object obj = this.ViewState["Type"];
                return (obj == null) ? RecordFieldType.Auto : (RecordFieldType)obj;
            }
            set
            {
                this.ViewState["Type"] = value;
            }
        }

        /// <summary>
        /// Sort method
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ToLowerCamelCase))]
        [Category("Config Options")]
        [DefaultValue(SortTypeMethod.None)]
        [Description("Sort method")]
        public virtual SortTypeMethod SortType
        {
            get
            {
                object obj = this.ViewState["SortType"];
                return (obj == null) ? SortTypeMethod.None : (SortTypeMethod)obj;
            }
            set
            {
                this.ViewState["SortType"] = value;
            }
        }

        /// <summary>
        /// (Optional) Initial direction to sort
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(SortDirection.Default)]
        [Description("(Optional) Initial direction to sort")]
        public virtual SortDirection SortDir
        {
            get
            {
                object obj = this.ViewState["SortDir"];
                return (obj == null) ? SortDirection.Default : (SortDirection)obj;
            }
            set
            {
                this.ViewState["SortDir"] = value;
            }
        }

        /// <summary>
        /// Empty value representation during submit (default value as Undedefined)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("Config Options")]
        [DefaultValue(EmptyValue.Undefined)]
        [Description("Empty value representation during submit (default value as Undedefined)")]
        public virtual EmptyValue SubmitEmptyValue
        {
            get
            {
                object obj = this.ViewState["SubmitEmptyValue"];
                return (obj == null) ? EmptyValue.Undefined : (EmptyValue)obj;
            }
            set
            {
                this.ViewState["SubmitEmptyValue"] = value;
            }
        }


        /// <summary>
        /// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
        /// </summary>
        [Meta]
        [ConfigOption("sortType", JsonMode.Raw)]
        [Category("Config Options")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.")]
        public virtual JFunction CustomSortType
        {
            get
            {
                if (this.customSortType == null)
                {
                    this.customSortType = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.customSortType.Args = new string[] {"value"};
                    }
                }

                return this.customSortType;
            }
        }

        /// <summary>
        /// (Optional) A function which converts the value provided by the Reader
        /// into an object that will be stored in the Record. 
        /// 
        /// It is passed the following parameters:
        ///    v : Mixed
        ///        The data value as read by the Reader.
        /// 
        ///    rec : Mixed
        ///          The data object containting the row as read by the Reader.
        ///          Depending on Reader type, this could be an Array, an object,
        ///          or an XML element.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("(Optional) A function which converts the value provided by the Reader into an object that will be stored in the Record.")]
        public virtual JFunction Convert
        {
            get
            {
                if (this.convert == null)
                {
                    this.convert = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.convert.Args = new string[] { "value", "record" };    
                    }
                }

                return this.convert;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        public virtual bool RenderMilliseconds
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) A format String for the Date.parseDate function
        /// </summary>
        [Meta]
        [ConfigOption(typeof(NetToPHPDateFormatStringJsonConverter))]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("(Optional) A format String for the Date.parseDate function")]
        public virtual string DateFormat
        {
            get
            {
                string temp = (string)this.ViewState["DateFormat"] ?? "";

                if (this.Type == RecordFieldType.Date && this.ViewState["DateFormat"] == null)
                {
                    temp = this.RenderMilliseconds ? "yyyy-MM-ddTHH:mm:ss.u" : "yyyy-MM-ddTHH:mm:ss";
                }

                return temp;
            }
            set
            {
                this.ViewState["DateFormat"] = value;
            }
        }

        /// <summary>
        /// (Optional) The default value passed to the Reader when the field does not exist in the data object
        /// 
        /// Please pay attention that if you use string const then need wrap like this
        ///     DefaultValue="'String const'"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("(Optional) The default value passed to the Reader when the field does not exist in the data object")]
        public virtual string DefaultValue
        {
            get
            {
                object obj = this.ViewState["DefaultValue"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["DefaultValue"] = value;
            }
        }

        /// <summary>
        /// True to render this property as complex object
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True to render this property as complex object")]
        public virtual bool IsComplex
        {
            get
            {
                object obj = this.ViewState["IsComplex"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IsComplex"] = value;
            }
        }

        /// <summary>
        /// (Optional) Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("(Optional) Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false")]
        public virtual bool UseNull
        {
            get
            {
                object obj = this.ViewState["UseNull"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["UseNull"] = value;
            }
        }
    }
}