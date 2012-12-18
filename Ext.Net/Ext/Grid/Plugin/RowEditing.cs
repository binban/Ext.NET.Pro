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
    /// The Ext.grid.plugin.RowEditing plugin injects editing at a row level for a Grid. When editing begins, a small floating dialog will be shown for the appropriate row. Each editable column will show a field for editing. There is a button to save or cancel all changes for the edit.
    /// 
    /// The field that will be used for the editor is defined at the editor. The editor can be a field instance or a field configuration. If an editor is not specified for a particular column then that column won't be editable and the value of the column will be displayed. To provide a custom renderer for non-editable values, use the editRenderer configuration on the column.
    /// 
    /// The editor may be shared for each column in the grid, or a different one may be specified for each column. An appropriate field type should be chosen to match the data structure that it will be editing. For example, to edit a date, it would be useful to specify Ext.form.field.Date as the editor.
    /// </summary>
    [Meta]
    public partial class RowEditing : GridEditing
    {
        /// <summary>
        /// 
        /// </summary>
        public RowEditing()
        { 
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
                return "Ext.grid.plugin.RowEditing";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [ConfigOption("ptype")]
        [DefaultValue("")]
        [Description("")]
        public override string PType
        {
            get
            {
                return "rowediting";
            }
        }

        /// <summary>
        /// true to automatically cancel any pending changes when the row editor begins editing a new row. false to force the user to explicitly cancel the pending changes. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("true to automatically cancel any pending changes when the row editor begins editing a new row. false to force the user to explicitly cancel the pending changes. Defaults to true.")]
        public virtual bool AutoCancel
        {
            get
            {
                return this.State.Get<bool>("AutoCancel", true);
            }
            set
            {
                this.State.Set("AutoCancel", value);
            }
        }

        /// <summary>
        /// The number of clicks to move the row editor to a new row while it is visible and actively editing another row. This will default to the same value as clicksToEdit.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("The number of clicks to move the row editor to a new row while it is visible and actively editing another row. This will default to the same value as clicksToEdit.")]
        public virtual int ClicksToMoveEditor
        {
            get
            {
                return this.State.Get<int>("ClicksToMoveEditor", 0);
            }
            set
            {
                this.State.Set("ClicksToMoveEditor", value);
            }
        }

        /// <summary>
        /// true to show a tooltip that summarizes all validation errors present in the row editor. Set to false to prevent the tooltip from showing. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("true to show a tooltip that summarizes all validation errors present in the row editor. Set to false to prevent the tooltip from showing. Defaults to true.")]
        public virtual bool ErrorSummary
        {
            get
            {
                return this.State.Get<bool>("ErrorSummary", true);
            }
            set
            {
                this.State.Set("ErrorSummary", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("Update")]
        [Description("")]
        public virtual string SaveBtnText
        {
            get
            {
                return this.State.Get<string>("SaveBtnText", "Update");
            }
            set
            {
                this.State.Set("SaveBtnText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("Cancel")]
        [Description("")]
        public virtual string CancelBtnText
        {
            get
            {
                return this.State.Get<string>("CancelBtnText", "Cancel");
            }
            set
            {
                this.State.Set("CancelBtnText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("Errors")]
        [Description("")]
        public virtual string ErrorsText
        {
            get
            {
                return this.State.Get<string>("ErrorsText", "Errors");
            }
            set
            {
                this.State.Set("ErrorsText", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("You need to commit or cancel your changes")]
        [Description("")]
        public virtual string DirtyText
        {
            get
            {
                return this.State.Get<string>("DirtyText", "You need to commit or cancel your changes");
            }
            set
            {
                this.State.Set("DirtyText", value);
            }
        }

        /// <summary>
        /// A function called when the save button is clicked
        /// </summary>
        [Meta]
        [ConfigOption(typeof(FunctionJsonConverter))]
        [DefaultValue("")]
        [Description("A function called when the save button is clicked")]
        public virtual string SaveHandler
        {
            get
            {
                return this.State.Get<string>("SaveHandler", "");
            }
            set
            {
                this.State.Set("SaveHandler", value);
            }
        }

        private RowEditingListeners listeners;

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
        public RowEditingListeners Listeners
        {
            get
            {
                return this.listeners ?? (this.listeners = new RowEditingListeners());
            }
        }

        private RowEditingDirectEvents directEvents;

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
        public RowEditingDirectEvents DirectEvents
        {
            get
            {
                return this.directEvents ?? (this.directEvents = new RowEditingDirectEvents(this));
            }
        }

        /// <summary>
        /// Start editing the specified record.
        /// </summary>
        /// <param name="recordId">The Store data record id which backs the row to be edited.</param>
        public virtual void StartEdit(object recordId)
        {
            this.Call("startEdit", new JRawValue("{0}.grid.store.getById({1})".FormatWith(this.ClientID, JSON.Serialize(recordId))), 0);
        }

        /// <summary>
        /// Start editing the specified record.
        /// </summary>
        /// <param name="recordIndex">The Store data record index which backs the row to be edited.</param>
        public virtual void StartEdit(int recordIndex)
        {
            this.Call("startEdit", recordIndex, 0);
        }

        /// <summary>
        /// Start editing the specified record.
        /// </summary>
        /// <param name="record">The Store data record which backs the row to be edited.</param>
        public virtual void StartEdit(ModelProxy record)
        {
            this.Call("startEdit", JRawValue.From(record.ModelInstance), 0);
        }
    }
}
