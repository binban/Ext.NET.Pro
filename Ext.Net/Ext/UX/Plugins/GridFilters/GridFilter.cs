/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class GridFilter : StateManagedItem
    {
        /// <summary>
        /// Indicates the initial status of the filter (defaults to false).
        /// </summary>
        [ConfigOption]
        [Category("2. GridFilter")]
        [DefaultValue(false)]
        [Description("Indicates the initial status of the filter (defaults to false).")]
        public virtual bool Active
        {
            get
            {
                object obj = this.ViewState["Active"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Active"] = value;
            }
        }

        /// <summary>
        /// The Store data index of the field this filter represents. The dataIndex does not actually have to exist in the store.
        /// </summary>
        [ConfigOption]
        [Category("2. GridFilter")]
        [DefaultValue("")]
        [Description("The Store data index of the field this filter represents. The dataIndex does not actually have to exist in the store.")]
        public virtual string DataIndex
        {
            get
            {
                object obj = this.ViewState["DataIndex"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["DataIndex"] = value;
            }
        }

        private JFunction getValue;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// get and return the value of the filter.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to get and return the value of the filter.")]
        public virtual JFunction GetValue
        {
            get
            {
                if (this.getValue == null)
                {
                    this.getValue = new JFunction();
                }

                return this.getValue;
            }
        }

        private JFunction setValue;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// set the value of the filter and fire the 'update' event.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to set the value of the filter and fire the 'update' event.")]
        public virtual JFunction SetValue
        {
            get
            {
                if (this.setValue == null)
                {
                    this.setValue = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.setValue.Args = new string[] { "value" };
                    }
                }

                return this.setValue;
            }
        }

        private JFunction getSerialArgs;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// get and return serialized filter data for transmission to the server.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to get and return serialized filter data for transmission to the server.")]
        public virtual JFunction GetSerialArgs
        {
            get
            {
                if (this.getSerialArgs == null)
                {
                    this.getSerialArgs = new JFunction();
                }

                return this.getSerialArgs;
            }
        }

        private JFunction validateRecord;

        /// <summary>
        /// Template method to be implemented by all subclasses that is to
        /// validates the provided Ext.data.Record against the filters configuration.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("2. GridFilter")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Template method to be implemented by all subclasses that is to validates the provided Ext.data.Record against the filters configuration.")]
        public virtual JFunction ValidateRecord
        {
            get
            {
                if (this.validateRecord == null)
                {
                    this.validateRecord = new JFunction();
                    if (!this.DesignMode)
                    {
                        this.validateRecord.Args = new string[] { "record" };
                    }
                }

                return this.validateRecord;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public abstract FilterType Type
        {
            get;
        }

        private GridPanel parentGrid;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridPanel ParentGrid
        {
            get
            {
                if (this.parentGrid == null && this.Plugin != null)
                {
                    this.parentGrid = this.Plugin.ParentComponent as GridPanel;
                }
                return this.parentGrid;
            }
            set
            {
                this.parentGrid = value;
            }
        }

        private GridFilters plugin;

        internal GridFilters Plugin
        {
            get
            {
                return this.plugin;
            }
            set
            {
                this.plugin = value;
            }
        }

        private GridFilterListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public GridFilterListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridFilterListeners();
                }

                return this.listeners;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetActive(bool active)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setActive({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(active));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class GridFilterCollection : StateManagedCollection<GridFilter> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum FilterType
    {
        /// <summary>
        /// 
        /// </summary>
        Boolean,

        /// <summary>
        /// 
        /// </summary>
        Date,

        /// <summary>
        /// 
        /// </summary>
        List,

        /// <summary>
        /// 
        /// </summary>
        Numeric,

        /// <summary>
        /// 
        /// </summary>
        String
    }
}
