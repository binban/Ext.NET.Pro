/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// The grid View class provides extra Ext.grid.Panel specific functionality to the Ext.view.Table.
    /// 
    /// Drag and drop functionality can be achieved in the grid by attaching a Ext.grid.plugin.DragDrop plugin when creating the view.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("The grid View class provides extra Ext.grid.Panel specific functionality to the Ext.view.Table.")]
    public partial class GridView : TableView
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridView() { }

        /// <summary>
        /// 
        /// </summary>
        public override string XType
        {
            get
            {
                return "gridview";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.View";
            }
        }

        /// <summary>
        /// True to stripe the rows.
        /// This causes the CSS class x-grid-row-alt to be added to alternate rows of the grid. A default CSS rule is provided which sets a background color, but you can override this with a rule which either overrides the background-color style using the !important modifier, or which uses a CSS selector of higher specificity.
        /// Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to stripe the rows. Default is true.")]
        public virtual bool StripeRows
        {
            get
            {
                return this.State.Get<bool>("StripeRows", true);
            }
            set
            {
                this.State.Set("StripeRows", value);
            }
        }

        private GridViewListeners listeners;

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
        public GridViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridViewListeners();
                }

                return this.listeners;
            }
        }

        private GridViewDirectEvents directEvents;

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
        public GridViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridViewDirectEvents(this);
                }

                return this.directEvents;
            }
        }        
    }
}
