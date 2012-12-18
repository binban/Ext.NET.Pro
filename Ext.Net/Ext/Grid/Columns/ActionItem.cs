/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Action column item definition
    /// </summary>
    [Meta]
    public partial class ActionItem : BaseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public ActionItem()
        {

        }

        /// <summary>
        /// An icon to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
        /// </summary>
        [Meta]
        [DefaultValue(Icon.None)]
        [NotifyParentProperty(true)]
        [Description("An icon to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.")]
        public virtual Icon Icon
        {
            get
            {
                return this.State.Get<Icon>("Icon", Icon.None);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IconProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "X.net.RM.getIcon({0})".FormatWith(JSON.Serialize(this.Icon.ToString()));
                }

                return "";
            }
        }

        /// <summary>
        /// A CSS class to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class to apply to the icon image. To determine the class dynamically, configure the item with a getClass function.")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

        /// <summary>
        /// The url of an image to display as the clickable element in the column.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The url of an image to display as the clickable element in the column.")]
        public virtual string IconUrl
        {
            get
            {
                return this.State.Get<string>("IconUrl", "");
            }
            set
            {
                this.State.Set("IconUrl", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("icon")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IconUrlProxy
        {
            get
            {
                return this.IconUrl.IsEmpty() ? "" : ExtNetTransformer.ResolveUrl(this.IconUrl);
            }
        }

        private JFunction getClass;

        /// <summary>
        /// A function which returns the CSS class to apply to the icon image. 
        /// The function is passed the following parameters:
        /// Parameters
        /// value : Object
        /// The value of the column's configured field (if any).
        /// 
        /// metadata : Object
        /// An object in which you may set the following attributes:
        /// 
        ///     tdCls : String
        ///             A CSS class name to add to the cell's TD element.
        ///     tdAttr : String
        ///             An HTML attribute definition string to apply to the data container element within the table cell (e.g. 'style="color:red;"').
        ///     style : String
        /// 
        /// record : Ext.data.Record
        /// The Record providing the data.
        /// 
        /// rowIndex : Number
        /// The row index.
        /// 
        /// colIndex : Number
        /// The column index.
        /// 
        /// store : Ext.data.Store
        /// The Store which is providing the data Model.
        /// 
        /// view : Ext.grid.View
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function which returns the CSS class to apply to the icon image.")]
        public virtual JFunction GetClass
        {
            get
            {
                if (this.getClass == null)
                {
                    this.getClass = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.getClass.Args = new string[] { "value", "metadata", "record", "rowIndex", "colIndex", "store", "view" };
                    }
                }

                return this.getClass;
            }
        }

        private JFunction getTip;

        /// <summary>
        /// A function which returns the tooltip string for any row.
        /// 
        /// Parameters
        /// value : Object
        ///     The value of the column's configured field (if any).
        /// metadata : Object
        ///     An object in which you may set the following attributes:
        ///         css : String
        ///             A CSS class name to add to the cell's TD element.
        ///         attr : String
        ///             An HTML attribute definition string to apply to the data container element within the table cell (e.g. 'style="color:red;"').
        /// record : Ext.data.Model
        ///     The Record providing the data.
        /// rowIndex : Number
        ///     The row index.
        /// colIndex : Number
        ///     The column index.
        /// store : Ext.data.Store
        ///     The Store which is providing the data Model.
        /// view : Ext.grid.View
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function which returns the tooltip string for any row.")]
        public virtual JFunction GetTip
        {
            get
            {
                if (this.getTip == null)
                {
                    this.getTip = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.getTip.Args = new string[] { "value", "metadata", "record", "rowIndex", "colIndex", "store", "view" };
                    }
                }

                return this.getTip;
            }
        }

        private JFunction isDisabled;

        /// <summary>
        /// A function which determines whether the action item for any row is disabled and returns true or false.
        /// 
        /// Parameters
        /// view : Ext.view.Table
        ///     The owning TableView.
        /// rowIndex : Number
        ///     The row index.
        /// colIndex : Number
        ///     The column index.
        /// item : Object
        ///     The clicked item (or this Column if multiple items were not configured).
        /// record : Ext.data.Model
        ///     The Record underlying the row.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function which determines whether the action item for any row is disabled and returns true or false.")]
        public virtual JFunction IsDisabled
        {
            get
            {
                if (this.isDisabled == null)
                {
                    this.isDisabled = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.isDisabled.Args = new string[] { "view", "rowIndex", "colIndex", "item", "record" };
                    }
                }

                return this.isDisabled;
            }
        }

        /// <summary>
        /// A function called when the icon is clicked.
        /// Parameters
        /// view : Ext.view.Table
        ///     The owning TableView.
        /// rowIndex : Number
        ///     The row index clicked on.
        /// colIndex : Number
        ///     The column index clicked on.
        /// item : Object
        ///     The clicked item (or this Column if multiple items were not configured).
        /// e : Event
        ///     The click event.
        /// record : Ext.data.Model
        ///     The Record underlying the clicked row.
        /// row : HTMLElement
        ///     The table row clicked upon.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(FunctionJsonConverter))]
        [DefaultValue("")]
        [Description("A function called when the icon is clicked.")]
        public virtual string Handler
        {
            get
            {
                return this.State.Get<string>("Handler", "");
            }
            set
            {
                this.State.Set("Handler", value);
            }
        }

        /// <summary>
        /// The scope (this reference) in which the handler, getClass, isDisabled and getTip fuctions are executed. Defaults to this Column.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [Description("The scope (this reference) in which the handler, getClass, isDisabled and getTip fuctions are executed. Defaults to this Column.")]
        public virtual string Scope
        {
            get
            {
                return this.State.Get<string>("Scope", null);
            }
            set
            {
                this.State.Set("Scope", value);
            }
        }

        /// <summary>
        /// A tooltip message to be displayed on hover. Ext.tip.QuickTipManager must have been initialized.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("A tooltip message to be displayed on hover. Ext.tip.QuickTipManager must have been initialized.")]
        public virtual string Tooltip
        {
            get
            {
                return this.State.Get<string>("Tooltip", null);
            }
            set
            {
                this.State.Set("Tooltip", value);
            }
        }

        /// <summary>
        /// If true, the action will not respond to click events, and will be displayed semi-opaque.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("If true, the action will not respond to click events, and will be displayed semi-opaque.")]
        public virtual bool Disabled
        {
            get
            {
                return this.State.Get<bool>("Disabled", false);
            }
            set
            {
                this.State.Set("Disabled", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ActionItemCollection : BaseItemCollection<ActionItem> { }
}
