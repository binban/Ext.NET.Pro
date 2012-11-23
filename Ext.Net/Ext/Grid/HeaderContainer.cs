/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Linq;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// Container which holds headers and is docked at the top or bottom of a TablePanel. The HeaderContainer drives resizing/moving/hiding of columns within the TableView. As headers are hidden, moved or resized the headercontainer is responsible for triggering changes within the view.
    /// </summary>
    [Meta]
    [Browsable(false)]
    [ToolboxItem(false)]
    public partial class GridHeaderContainer : AbstractContainer, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>
        public GridHeaderContainer()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsDefault
        {
            get
            {
                return this.Parent is TreePanelBase && this.Columns.Count == 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RenderColumnsOnly
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool Visible
        {
            get
            {
                if (!base.Visible)
                {
                    return base.Visible;
                }
                return !this.IsDefault;
            }
            set
            {
                base.Visible = value;
            }
        }

        /// <summary>
        /// Width of the header if no width or flex is specified. Defaults to 100.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(100)]
        [Description("Width of the header if no width or flex is specified. Defaults to 100.")]
        public virtual int DefaultWidth
        {
            get
            {
                return this.State.Get<int>("DefaultWidth", 100);
            }
            set
            {
                this.State.Set("DefaultWidth", value);
            }
        }

        /// <summary>
        /// HeaderContainer overrides the default weight of 0 for all docked items to 100. This is so that it has more priority over things like toolbars. Defaults to: 100
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(100)]
        [Description("HeaderContainer overrides the default weight of 0 for all docked items to 100. This is so that it has more priority over things like toolbars. Defaults to: 100")]
        public override int Weight
        {
            get
            {
                return this.State.Get<int>("Weight", 100);
            }
            set
            {
                this.State.Set("Weight", value);
            }
        }

        /// <summary>
        /// Provides the default sortable state for all Headers within this HeaderContainer. Also turns on or off the menus in the HeaderContainer. Note that the menu is shared across every header and therefore turning it off will remove the menu items for every header.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Provides the default sortable state for all Headers within this HeaderContainer. Also turns on or off the menus in the HeaderContainer. Note that the menu is shared across every header and therefore turning it off will remove the menu items for every header.")]
        public virtual bool? Sortable
        {
            get
            {
                return this.State.Get<bool?>("Sortable", null);
            }
            set
            {
                this.State.Set("Sortable", value);
            }
        }

        /// <summary>
        /// The text displayed in the \"Sort Ascending\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [DefaultValue("")]
        [Description("The text displayed in the \"Sort Ascending\" menu item")]
        public virtual string SortAscText
        {
            get
            {
                return this.State.Get<string>("SortAscText", "");
            }
            set
            {
                this.State.Set("SortAscText", value);
            }
        }

        /// <summary>
        /// The text displayed in the \"Sort Descending\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [DefaultValue("")]
        [Description("The text displayed in the \"Sort Descending\" menu item")]
        public virtual string SortDescText
        {
            get
            {
                return this.State.Get<string>("SortDescText", "");
            }
            set
            {
                this.State.Set("SortDescText", value);
            }
        }

        /// <summary>
        /// The text displayed in the \"Clear Sort\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [DefaultValue("")]
        [Description("The text displayed in the \"Clear Sort\" menu item")]
        public virtual string SortClearText
        {
            get
            {
                return this.State.Get<string>("SortClearText", "");
            }
            set
            {
                this.State.Set("SortClearText", value);
            }
        }

        /// <summary>
        /// The text displayed in the \"Columns\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [DefaultValue("")]
        [Description("The text displayed in the \"Columns\" menu item")]
        public virtual string ColumnsText
        {
            get
            {
                return this.State.Get<string>("ColumnsText", "");
            }
            set
            {
                this.State.Set("ColumnsText", value);
            }
        }

        private ItemsCollection<ColumnBase> columns;

        /// <summary>
        /// An array of column definition objects which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of column definition objects which define all columns that appear in this grid. Each column definition provides the header text for the column, and a definition of where the data for that column comes from.")]
        public virtual ItemsCollection<ColumnBase> Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new ColumnCollection();
                    this.columns.AfterItemAdd += this.AfterItemAdd;
                    this.columns.AfterItemRemove += this.AfterItemRemove;
                }

                return this.columns;
            }
        }

        /// <summary>
        /// Items Collection
        /// </summary>
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [DeferredRender]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Items Collection")]
        protected override ItemsCollection<AbstractComponent> ItemsProxy
        {
            get
            {
                if (this.Columns.Count > 0)
                {
                    ItemsCollection<AbstractComponent> columns = new ItemsCollection<AbstractComponent>();

                    foreach (ColumnBase column in this.Columns)
                    {
                        columns.Add(column);
                    }

                    return columns;
                }

                return base.ItemsProxy;
            }
        }

        /// <summary>
        /// Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Specify as true to force the columns to fit into the available width. Headers are first sized according to configuration, whether that be a specific width, or flex. Then they are all proportionally changed in width so that the entire content width is used.")]
        public virtual bool ForceFit
        {
            get
            {
                return this.State.Get<bool>("ForceFit", false);
            }
            set
            {
                this.State.Set("ForceFit", value);
            }
        }

        /// <summary>
        /// True to enable drag and drop reorder of columns.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to enable drag and drop reorder of columns.")]
        public virtual bool EnableColumnMove
        {
            get
            {
                return this.State.Get<bool>("EnableColumnMove", true);
            }
            set
            {
                this.State.Set("EnableColumnMove", value);
            }
        }

        /// <summary>
        /// False to turn off column resizing for the whole grid (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to turn off column resizing for the whole grid (defaults to true).")]
        public virtual bool EnableColumnResize
        {
            get
            {
                return this.State.Get<bool>("EnableColumnResize", true);
            }
            set
            {
                this.State.Set("EnableColumnResize", value);
            }
        }

        /// <summary>
        /// False to disable column hiding within this grid. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("False to turn off column resizing for the whole grid (defaults to true).")]
        public virtual bool EnableColumnHide
        {
            get
            {
                return this.State.Get<bool>("EnableColumnHide", true);
            }
            set
            {
                this.State.Set("EnableColumnHide", value);
            }
        }

        private GridHeaderContainerListeners listeners;


        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public GridHeaderContainerListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new GridHeaderContainerListeners());
            }
        }

        private GridHeaderContainerDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public GridHeaderContainerDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new GridHeaderContainerDirectEvents(this));
            }
        }

        public ColumnBase GetColumnByDataIndex(string dataIndex)
        {
            return this.Columns.FirstOrDefault(c => c.DataIndex == dataIndex);
        }

        #region Члены ICustomConfigSerialization

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public string ToScript(Control owner)
        {
            if (this.RenderColumnsOnly)
            {
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                JsonTextWriter writer = new JsonTextWriter(sw);

                ItemCollectionJsonConverter converter = new ItemCollectionJsonConverter();
                converter.Name = "columns";
                converter.PropertyName = "Items";
                converter.Owner = this;

                converter.WriteJson(writer, this.ItemsProxy, null);               
                
                return sw.GetStringBuilder().ToString();
            }
            else
            {
                return new ClientConfig().Serialize(this, true);
            }
        }

        #endregion
    }
}
