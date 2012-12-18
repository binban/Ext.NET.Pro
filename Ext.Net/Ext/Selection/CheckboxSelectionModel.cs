/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A selection model that renders a column of checkboxes that can be toggled to select or deselect rows. The default mode for this selection model is MULTI.
    /// The selection model will inject a header for the checkboxes in the first view and according to the 'injectCheckbox' configuration.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class CheckboxSelectionModel : RowSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public CheckboxSelectionModel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.selection.CheckboxModel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        [DefaultValue("")]
        [ConfigOption]
        public override string SelType
        {
            get
            {
                return "checkboxmodel";
            }
        }

        /// <summary>
        /// true if rows can only be selected by clicking on the checkbox column (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("true if rows can only be selected by clicking on the checkbox column (defaults to false).")]
        public virtual bool CheckOnly
        {
            get
            {
                return this.State.Get<bool>("CheckOnly", false);
            }
            set
            {
                this.State.Set("CheckOnly", value);
            }
        }

        /// <summary>
        /// Modes of selection. Valid values are SINGLE, SIMPLE, and MULTI. Defaults to 'MULTI'
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SelectionMode.Multi)]
        [NotifyParentProperty(true)]
        [Description("Modes of selection. Valid values are SINGLE, SIMPLE, and MULTI. Defaults to 'MULTI'")]
        public override SelectionMode Mode
        {
            get
            {
                return this.State.Get<SelectionMode>("Mode", SelectionMode.Multi);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }

        /// <summary>
        /// Instructs the SelectionModel whether or not to inject the checkbox header automatically or not. (Note: By not placing the checkbox in manually, the grid view will need to be rendered 2x on initial render.) Supported values are a Number index, false and the strings 'first' and 'last'. Default is 0.
        /// </summary>
        [Meta]
        [DefaultValue("0")]
        [NotifyParentProperty(true)]
        [Description("Instructs the SelectionModel whether or not to inject the checkbox header automatically or not. (Note: By not placing the checkbox in manually, the grid view will need to be rendered 2x on initial render.) Supported values are a Number index, false and the strings 'first' and 'last'. Default is 0.")]
        public virtual string InjectCheckbox
        {
            get
            {
                return this.State.Get<string>("InjectCheckbox", "0");
            }
            set
            {
                this.State.Set("InjectCheckbox", value);
            }
        }

        /// <summary>
        /// RowSpan attribute for the checkbox table cell
        /// </summary>
        [Meta]
        [ConfigOption("rowspan")]
        [Category("Config Options")]
        [DefaultValue(1)]
        [Description("RowSpan attribute for the checkbox table cell")]
        public virtual int RowSpan
        {
            get
            {
                return this.State.Get<int>("RowSpan", 1);
            }
            set
            {
                this.State.Set("RowSpan", value);
            }
        }

        /// <summary>
        /// Configure as false to not display the header checkbox at the top of the column. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [Description("RowSpan attribute for the checkbox table cell")]
        public virtual bool ShowHeaderCheckbox
        {
            get
            {
                return this.State.Get<bool>("ShowHeaderCheckbox", true);
            }
            set
            {
                this.State.Set("ShowHeaderCheckbox", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("injectCheckbox", JsonMode.Raw)]
        protected virtual string InjectCheckboxProxy
        {
            get
            {
                string s = this.InjectCheckbox.ToLowerInvariant();
                
                if (s == "false")
                {
                    return s;
                }

                if (s == "first" || s == "last")
                {
                    return JSON.Serialize(s);
                }

                int ind;
                if (int.TryParse(s, out ind) && ind > 0)
                {
                    return ind.ToString();
                }

                return "";
            }
        }

        private Renderer renderer;

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
        ///         tdCls : String
        ///             A CSS class name to add to the cell's TD element.
        ///         tdAttr : String
        ///             An HTML attribute definition string to apply to the data container element
        ///              within the table cell (e.g. 'style="color:red;"').
        ///         style : String
        ///     
        ///     record : Ext.data.record
        ///         The Ext.data.Record from which the data was extracted.
        ///     rowIndex : Number
        ///         Row index
        ///     colIndex : Number
        ///         Column index
        ///     store : Ext.data.Store
        ///         The Ext.data.Store object from which the Record was extracted.
        ///     view : Ext.grid.View
        /// Returns:
        ///     void
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RendererJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]        
        [Description("(optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.")]
        public virtual Renderer Renderer
        {
            get
            {
                return this.renderer ?? (this.renderer = new Renderer());
            }
            set
            {
                this.renderer = value;
            }
        }

        /// <summary>
        /// Toggle the ui header between checked and unchecked state.
        /// </summary>
        /// <param name="isChecked"></param>
        public void ToggleUiHeader(bool isChecked)
        {
            this.Call("toggleUiHeader", isChecked);
        }
    }
}
