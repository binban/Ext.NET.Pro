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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class CheckboxGroupBase : FieldContainerBase
    {
        /// <summary>
        /// False to validate that at least one item in the group is checked (defaults to true). If no items are selected at validation time, BlankText will be used as the error text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue(true)]
        [Description("False to validate that at least one item in the group is checked (defaults to true). If no items are selected at validation time, BlankText will be used as the error text.")]
        public virtual bool AllowBlank
        {
            get
            {
                return this.State.Get<bool>("AllowBlank", true);
            }
            set
            {
                this.State.Set("AllowBlank", value);
            }
        }

        /// <summary>
        /// Error text to display if the AllowBlank validation fails (defaults to 'You must select at least one item in this group')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the AllowBlank validation fails (defaults to 'You must select at least one item in this group')")]
        public virtual string BlankText
        {
            get
            {
                return this.State.Get<string>("BlankText", "");
            }
            set
            {
                this.State.Set("BlankText", value);
            }
        }

        /// <summary>
        /// Specifies a number of columns will be created and the contained controls will be automatically distributed based on the value of vertical.
        /// </summary>
        [Meta]
        [ConfigOption("columns")]
        [Category("6. CheckboxGroup")]
        [DefaultValue(0)]
        [Description("Specifies a number of columns will be created and the contained controls will be automatically distributed based on the value of vertical.")]
        public virtual int ColumnsNumber
        {
            get
            {
                return this.State.Get<int>("ColumnsNumber", 0);
            }
            set
            {
                this.State.Set("ColumnsNumber", value);
            }
        }

        /// <summary>
        /// You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.Serialize)]
        [TypeConverter(typeof(DoubleArrayConverter))]
        [Category("6. CheckboxGroup")]
        [DefaultValue(null)]
        [Description("You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.")]
        public virtual double[] ColumnsWidths
        {
            get
            {
                double[] widths = this.State.Get<double[]>("ColumnsWidths", null);

                if (this.ColumnsNumber > 0 && widths != null && widths.Length > 0)
                {
                    throw new ArgumentException("Do not use both ColumnsNumber and ColumnsWidths");
                }

                return widths;
            }
            set
            {
                this.State.Set("ColumnsWidths", value);
            }
        }

        /// <summary>
        /// Fire change event after rendering
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue(false)]
        [Description("Fire change event after rendering")]
        public virtual bool FireChangeOnLoad
        {
            get
            {
                return this.State.Get<bool>("FireChangeOnLoad", false);
            }
            set
            {
                this.State.Set("FireChangeOnLoad", value);
            }
        }

        /// <summary>
        /// True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column. The number of controls in each column will be automatically calculated to keep columns as even as possible. The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckboxGroup")]
        [DefaultValue(false)]
        [Description("True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column. The number of controls in each column will be automatically calculated to keep columns as even as possible. The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.")]
        public virtual bool Vertical
        {
            get
            {
                return this.State.Get<bool>("Vertical", false);
            }
            set
            {
                this.State.Set("Vertical", value);
            }
        }

        /// <summary>
        /// Sets the value(s) of all checkboxes in the group. The expected format is an Object of name-value pairs corresponding to the names of the checkboxes in the group. Each pair can have either a single or multiple values:
        /// 
        /// A single Boolean or String value will be passed to the setValue method of the checkbox with that name. See the rules in Ext.form.field.Checkbox.setValue for accepted values.
        /// An Array of String values will be matched against the inputValue of checkboxes in the group with that name; those checkboxes whose inputValue exists in the array will be checked and others will be unchecked.
        /// If a checkbox's name is not in the mapping at all, it will be unchecked.
        /// 
        /// An example:
        /// 
        /// var myCheckboxGroup = new Ext.form.CheckboxGroup({
        ///     columns: 3,
        ///     items: [{
        ///         name: 'cb1',
        ///         boxLabel: 'Single 1'
        ///     }, {
        ///         name: 'cb2',
        ///         boxLabel: 'Single 2'
        ///     }, {
        ///         name: 'cb3',
        ///         boxLabel: 'Single 3'
        ///     }, {
        ///         name: 'cbGroup',
        ///         boxLabel: 'Grouped 1'
        ///         inputValue: 'value1'
        ///     }, {
        ///         name: 'cbGroup',
        ///         boxLabel: 'Grouped 2'
        ///         inputValue: 'value2'
        ///     }, {
        ///         name: 'cbGroup',
        ///         boxLabel: 'Grouped 3'
        ///         inputValue: 'value3'
        ///     }]
        /// });
        /// 
        /// myCheckboxGroup.setValue({
        ///     cb1: true,
        ///     cb3: false,
        ///     cbGroup: ['value1', 'value3']
        /// });
        /// The above code will cause the checkbox named 'cb1' to be checked, as well as the first and third checkboxes named 'cbGroup'. The other three checkboxes will be unchecked.
        /// </summary>
        /// <param name="values">bject literal specifying item:value pairs</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(Dictionary<string, object> values)
        {
            this.Call("setValue", values);
        }

        /// <summary>
        /// Resets the checked state of all checkboxes in the group to their originally loaded values and clears any validation messages. See Ext.form.Basic.trackResetOnLoad
        /// </summary>
        public void Reset()
        {
            this.Call("reset");
        }
    }
}