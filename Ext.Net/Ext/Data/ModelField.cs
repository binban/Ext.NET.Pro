/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Fields are used to define what a Model is. They aren't instantiated directly - instead, when we create a class that extends Ext.data.Model, it will automatically create a Field instance for each field configured in a Model. For example, we might set up a model like this:
    /// 
    /// Ext.define('User', {
    ///     extend: 'Ext.data.Model',
    ///     fields: [
    ///         'name', 'email',
    ///         {name: 'age', type: 'int'},
    ///         {name: 'gender', type: 'string', defaultValue: 'Unknown'}
    ///     ]
    /// });
    /// Four fields will have been created for the User Model - name, email, age and gender. Note that we specified a couple of different formats here; if we only pass in the string name of the field (as with name and email), the field is set up with the 'auto' type. It's as if we'd done this instead:
    ///
    /// Ext.define('User', {
    ///     extend: 'Ext.data.Model',
    ///     fields: [
    ///         {name: 'name', type: 'auto'},
    ///         {name: 'email', type: 'auto'},
    ///         {name: 'age', type: 'int'},
    ///         {name: 'gender', type: 'string', defaultValue: 'Unknown'}
    ///     ]
    /// });
    /// Types and conversion
    /// 
    /// The type is important - it's used to automatically convert data passed to the field into the correct format. In our example above, the name and email fields used the 'auto' type and will just accept anything that is passed into them. The 'age' field had an 'int' type however, so if we passed 25.4 this would be rounded to 25.
    /// 
    /// Sometimes a simple type isn't enough, or we want to perform some processing when we load a Field's data. We can do this using a convert function. Here, we're going to create a new field based on another:
    /// 
    /// Ext.define('User', {
    ///     extend: 'Ext.data.Model',
    ///     fields: [
    ///         'name', 'email',
    ///         {name: 'age', type: 'int'},
    ///         {name: 'gender', type: 'string', defaultValue: 'Unknown'},
    /// 
    ///         {
    ///             name: 'firstName',
    ///             convert: function(value, record) {
    ///                 var fullName  = record.get('name'),
    ///                     splits    = fullName.split(" "),
    ///                     firstName = splits[0];
    /// 
    ///                 return firstName;
    ///             }
    ///         }
    ///     ]
    /// });
    /// Now when we create a new User, the firstName is populated automatically based on the name:
    /// 
    /// var ed = Ext.create('User', {name: 'Ed Spencer'});
    /// 
    /// console.log(ed.get('firstName')); //logs 'Ed', based on our convert function
    /// In fact, if we log out all of the data inside ed, we'll see this:
    /// 
    /// console.log(ed.data);
    /// 
    /// //outputs this:
    /// {
    ///     age: 0,
    ///     email: "",
    ///     firstName: "Ed",
    ///     gender: "Unknown",
    ///     name: "Ed Spencer"
    /// }
    /// The age field has been given a default of zero because we made it an int type. As an auto field, email has defaulted to an empty string. When we registered the User model we set gender's defaultValue to 'Unknown' so we see that now. Let's correct that and satisfy ourselves that the types work as we expect:
    /// 
    /// ed.set('gender', 'Male');
    /// ed.get('gender'); //returns 'Male'
    ///
    /// ed.set('age', 25.4);
    /// ed.get('age'); //returns 25 - we wanted an int, not a float, so no decimal places allowed
    /// </summary>
    [Meta]
    [Description("")]
    public partial class ModelField : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ModelField() { }

        private JFunction convert;
        private JFunction customSortType;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ModelField(string name)
        {
            this.Name = name;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ModelField(string name, ModelFieldType type)
        {
            this.Name = name;
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ModelField(string name, ModelFieldType type, string dateFormat)
        {
            this.Name = name;
            this.Type = type;
            this.DateFormat = dateFormat;
        }

        /// <summary>
        /// The name by which the field is referenced within the Model. This is referenced by, for example, the dataIndex property in column definition objects passed to Ext.grid.header.Container.
        ///
        /// Note: In the simplest case, if no properties other than name are required, a field definition may consist of just a String for the field name.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("The name by which the field is referenced within the Model.")]
        public virtual string Name
        {
            get
            {
                return this.State.Get<string>("Name", "");
            }
            set
            {
                this.State.Set("Name", value);
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
        /// (Optional) A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extract the Field value from the data object. If the path expression is the same as the field name, the mapping may be omitted.
        /// 
        /// The form of the mapping expression depends on the Reader being used.
        /// 
        /// Ext.data.reader.Json
        /// The mapping is a string containing the javascript expression to reference the data from an element of the data item's root Array. Defaults to the field name.
        /// Ext.data.reader.Xml
        /// The mapping is an Ext.DomQuery path to the data item relative to the DOM element that represents the record. Defaults to the field name.
        /// Ext.data.reader.Array
        /// The mapping is a number indicating the Array index of the field's value. Defaults to the field specification's Array position.
        /// If a more complex value extraction strategy is required, then configure the Field with a convert function. This is passed the whole row object, and may interrogate it in whatever way is necessary in order to return the desired data.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("(Optional) A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extract the Field value from the data object. If the path expression is the same as the field name, the mapping may be omitted.")]
        public virtual string Mapping
        {
            get
            {
                return this.State.Get<string>("Mapping", "");
            }
            set
            {
                this.State.Set("Mapping", value);
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
                return this.State.Get<string>("ServerMapping", "");
            }
            set
            {
                this.State.Set("ServerMapping", value);
            }
        }

        /// <summary>
        /// (Optional) The data type for automatic conversion from received data to the stored value if convert has not been specified. This may be specified as a string value. Possible values are
        /// 
        /// auto (Default, implies no conversion)
        /// string
        /// int
        /// float
        /// boolean
        /// date
        /// This may also be specified by referencing a member of the Ext.data.Types class.
        /// 
        /// Developers may create their own application-specific data types by defining new members of the Ext.data.Types class.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("Config Options")]
        [DefaultValue(ModelFieldType.Auto)]
        [Description("(Optional) The data type for automatic conversion from received data to the stored value if convert has not been specified.")]
        public virtual ModelFieldType Type
        {
            get
            {
                return this.State.Get<ModelFieldType>("Type", ModelFieldType.Auto);
            }
            set
            {
                this.State.Set("Type", value);
            }
        }

        /// <summary>
        /// A function which converts a Field's value to a comparable value in order to ensure correct sort ordering. Predefined functions are provided in Ext.data.SortTypes.       
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
                return this.State.Get<SortTypeMethod>("SortType", SortTypeMethod.None);
            }
            set
            {
                this.State.Set("SortType", value);
            }
        }

        /// <summary>
        /// Initial direction to sort ("ASC" or "DESC"). Defaults to "ASC".
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
                return this.State.Get<SortDirection>("SortDir", SortDirection.Default);
            }
            set
            {
                this.State.Set("SortDir", value);
            }
        }
        
        /// <summary>
        /// Empty value representation during saving (default value as None)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("Config Options")]
        [DefaultValue(EmptyValue.None)]
        [Description("Empty value representation during saving (default value as None)")]
        public virtual EmptyValue SubmitEmptyValue
        {
            get
            {
                return this.State.Get<EmptyValue>("SubmitEmptyValue", EmptyValue.None);
            }
            set
            {
                this.State.Set("SubmitEmptyValue", value);
            }
        }
        

        /// <summary>
        ///  A function which converts a Field's value to a comparable value in order to ensure correct sort ordering. A custom sort example:
        /// 
        /// // current sort     after sort we want
        /// // +-+------+          +-+------+
        /// // |1|First |          |1|First |
        /// // |2|Last  |          |3|Second|
        /// // |3|Second|          |2|Last  |
        /// // +-+------+          +-+------+
        /// 
        /// sortType: function(value) {
        ///    switch (value.toLowerCase()) // native toLowerCase():
        ///    {
        ///       case 'first': return 1;
        ///       case 'second': return 2;
        ///       default: return 3;
        ///    }
        /// }
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
        /// (Optional) A function which converts the value provided by the Reader into an object that will be stored in the Model. It is passed the following parameters:
        /// 
        /// value : Mixed
        ///   The data value as read by the Reader, if undefined will use the configured defaultValue.
        /// record : Ext.data.Model
        ///   The data object containing the Model as read so far by the Reader. Note that the Model may not be fully populated at this point as the fields are read in the order that they are defined in your fields array.
        ///   
        /// // example of convert function
        /// function fullName(v, record){
        ///     return record.name.last + ', ' + record.name.first;
        /// }
        /// 
        /// function location(v, record){
        ///     return !record.city ? '' : (record.city + ', ' + record.state);
        /// }
        /// 
        /// var Dude = Ext.regModel({
        ///     fields: [
        ///         {name: 'fullname',  convert: fullName},
        ///         {name: 'firstname', mapping: 'name.first'},
        ///         {name: 'lastname',  mapping: 'name.last'},
        ///         {name: 'city', defaultValue: 'homeless'},
        ///         'state',
        ///         {name: 'location',  convert: location}
        ///     ]
        /// });
        /// 
        /// // create the data store
        /// var store = new Ext.data.Store({
        ///     reader: {
        ///         type: 'json',
        ///         model: 'Dude',
        ///         idProperty: 'key',
        ///         root: 'daRoot',
        ///         totalProperty: 'total'
        ///     }
        /// });
        /// 
        /// var myData = [
        ///     { key: 1,
        ///       name: { first: 'Fat',    last:  'Albert' }
        ///       // notice no city, state provided in data object
        ///     },
        ///     { key: 2,
        ///       name: { first: 'Barney', last:  'Rubble' },
        ///       city: 'Bedrock', state: 'Stoneridge'
        ///     },
        ///     { key: 3,
        ///       name: { first: 'Cliff',  last:  'Claven' },
        ///       city: 'Boston',  state: 'MA'
        ///     }
        /// ];
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
        /// If you ensure that data comes with correct format then convert can be set to null, it increase a parsing performance 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool NullConvert
        {
            get
            {
                return this.State.Get<bool>("NullConvert", false);
            }
            set
            {
                this.State.Set("NullConvert", value);
            }
        }

        [ConfigOption("convert", JsonMode.Raw)]
        [DefaultValue(null)]
        protected virtual string NullConvertProxy
        {
            get
            {
                return this.NullConvert ? "null" : null;
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
        /// (Optional) Used when converting received data into a Date when the type is specified as "date".
        /// 
        /// A format string for the Ext.Date.parse function, or "timestamp" if the value provided by the Reader is a UNIX timestamp, or "time" if the value provided by the Reader is a javascript millisecond timestamp. 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(NetToPHPDateFormatStringJsonConverter))]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("(Optional) Used when converting received data into a Date when the type is specified as \"date\".")]
        public virtual string DateFormat
        {
            get
            {
                string temp = (string)this.ViewState["DateFormat"] ?? "";

                if (this.Type == ModelFieldType.Date && this.ViewState["DateFormat"] == null)
                {
                    temp = this.RenderMilliseconds ? "yyyy-MM-ddTHH:mm:ss.u" : "yyyy-MM-ddTHH:mm:ss";
                }

                return temp;
            }
            set
            {
                this.State.Set("DateFormat", value);
            }
        }

        /// <summary>
        /// (Optional) The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). (defaults to "")
        /// 
        /// Please pay attention that if you use string const then need wrap like this
        ///     DefaultValue="'String const'"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("(Optional) The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). (defaults to \"\")")]
        public virtual string DefaultValue
        {
            get
            {
                return this.State.Get<string>("DefaultValue", "");
            }
            set
            {
                this.State.Set("DefaultValue", value);
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
                return this.State.Get<bool>("IsComplex", false);
            }
            set
            {
                this.State.Set("IsComplex", value);
            }
        }

        /// <summary>
        /// False to exclude this field from the Ext.data.Model.modified fields in a model. This will also exclude the field from being written using a Ext.data.writer.Writer. This option is useful when model fields are used to keep state on the client but do not need to be persisted to the server. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("False to exclude this field from the Ext.data.Model.modified fields in a model. This will also exclude the field from being written using a Ext.data.writer.Writer. This option is useful when model fields are used to keep state on the client but do not need to be persisted to the server. Defaults to true.")]
        public virtual bool Persist
        {
            get
            {
                return this.State.Get<bool>("Persist", true);
            }
            set
            {
                this.State.Set("Persist", value);
            }
        }

        /// <summary>
        /// Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.")]
        public virtual bool UseNull
        {
            get
            {
                return this.State.Get<bool>("UseNull", false);
            }
            set
            {
                this.State.Set("UseNull", value);
            }
        }
    }
}