/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class PropertyGridParameter : BaseParameter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter(string name, string value) : base(name, value) { }

        private EditorCollection editor;

        /// <summary>
        /// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
        /// </summary>
        //[ClientConfig("editor>Editor")]
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.")]
        public virtual EditorCollection Editor
        {
            get
            {
                if (this.editor == null)
                {
                    editor = new EditorCollection();
                }

                return editor;
            }
        }

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value.
        /// If not specified, the default renderer uses the raw data value.
        /// 
        /// Sets the rendering (formatting) function for a column. 
        /// See Ext.util.Format for some default formatting functions.
        ///
        /// The render function is called with the following parameters:
        ///     value : Object
        ///         The data value for the cell.
        ///     metadata : Object
        ///         An object in which you may set the following attributes:
        ///         
        ///         css : String
        ///             A CSS class name to add to the cell's TD element.
        ///         attr : String
        ///             An HTML attribute definition string to apply to the data container element
        ///              within the table cell (e.g. 'style="color:red;"').
        ///     
        ///     record : Ext.data.record
        ///         The Ext.data.Record from which the data was extracted.
        /// Returns:
        ///     void
        /// </summary>

        private Renderer renderer;

        /// <summary>
        /// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("(optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.")]
        public virtual Renderer Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new Renderer();
                }

                return this.renderer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("")]
        public string DisplayName
        {
            get
            {
                return (string)this.ViewState["DisplayName"] ?? "";
            }
            set
            {
                this.ViewState["DisplayName"] = value;
            }
        }

        private bool isChanged;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        [Description("")]
        public bool IsChanged
        {
            get 
            { 
                return this.isChanged; 
            }
            internal set 
            { 
                this.isChanged = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToString()
        {
            return "{0}:{1}".FormatWith(JSON.Serialize(Name), Mode == ParameterMode.Value ? JSON.Serialize(this.Value) : Value);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class PropertyGridParameterCollection : StateManagedCollection<PropertyGridParameter>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter this[string name]
        {
            get 
            {
                return GetParameterByName(name);
            }
        }

        private PropertyGridParameter GetParameterByName(string name)
        {
            foreach (PropertyGridParameter parameter in this)
            {
                if (parameter.Name == name)
                {
                    return parameter;
                }
            }

            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJsonObject()
        {
            if (this.Count == 0)
            {
                return "{}";
            }

            StringBuilder sb = new StringBuilder(256);
            sb.Append("{");

            foreach (PropertyGridParameter parameter in this)
            {
                sb.Append(parameter.ToString().ConcatWith(","));
            }
            
            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");

            return sb.ToString();
        }
    }
}