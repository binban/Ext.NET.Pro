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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class CheckboxGroupBase : Field
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [DefaultValue("")]
        public override string ItemCls
        {
            get 
            { 
                return base.ItemCls; 
            }
            set 
            { 
                base.ItemCls = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("itemCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ItemClsProxy
        {
            get
            {
                return this.ItemCls + " x-form-cb-label-nowrap";
            }
        }

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
                object obj = this.ViewState["AllowBlank"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowBlank"] = value;
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
                return (string)this.ViewState["BlankText"] ?? "";
            }
            set
            {
                this.ViewState["BlankText"] = value;
            }
        }

        /// <summary>
        /// Specifies the number of columns to use when displaying grouped checkbox/radio controls using automatic layout.
        /// </summary>
        [Meta]
        [ConfigOption("columns")]
        [Category("6. CheckboxGroup")]
        [DefaultValue(0)]
        [Description("Specifies the number of columns to use when displaying grouped checkbox/radio controls using automatic layout.")]
        public virtual int ColumnsNumber
        {
            get
            {
                object obj = this.ViewState["ColumnsNumber"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["ColumnsNumber"] = value;
            }
        }

        /// <summary>
        /// You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.
        /// </summary>
        [Meta]
        [ConfigOption("columns", typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("6. CheckboxGroup")]
        [DefaultValue(null)]
        [Description("You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.")]
        public virtual string[] ColumnsWidths
        {
            get
            {
                object obj = this.ViewState["ColumnsWidths"];
                string[] widths =  (obj == null) ? null : (string[])obj;

                if (this.ColumnsNumber > 0 && widths != null && widths.Length > 0)
                {
                    throw new ArgumentException("Do not use both ColumnsNumber and ColumnsWidths");
                }

                return widths;
            }
            set
            {
                this.ViewState["ColumnsWidths"] = value;
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
                object obj = this.ViewState["FireChangeOnLoad"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["FireChangeOnLoad"] = value;
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
                object obj = this.ViewState["Vertical"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Vertical"] = value;
            }
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="id">name</param>
        /// <param name="value">value</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(string id, bool value)
        {
            this.Call("setValue", id, value);
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="values">array of boolean values</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(bool[] values)
        {
            this.Call("setValue", values);
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="values">bject literal specifying item:value pairs</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(Dictionary<string, bool> values)
        {
            this.Call("setValue", values);
        }

        /// <summary>
        /// Set the value(s) of an item or items in the group. 
        /// </summary>
        /// <param name="values">comma separated string to set items with name to true (checked)</param>
        [Meta]
        [Description("")]
        public virtual void SetValue(string values)
        {
            this.Call("setValue", values);
        }
    }
}