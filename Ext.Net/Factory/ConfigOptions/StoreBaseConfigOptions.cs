/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    public abstract partial class StoreBase
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("autoDestroy", new ConfigOption("autoDestroy", null, false, this.AutoDestroy ));
                list.Add("autoLoadProxy", new ConfigOption("autoLoadProxy", new SerializationOptions("autoLoad"), false, this.AutoLoadProxy ));
                list.Add("restful", new ConfigOption("restful", null, false, this.Restful ));
                list.Add("saveAllFields", new ConfigOption("saveAllFields", null, true, this.SaveAllFields ));
                list.Add("autoSave", new ConfigOption("autoSave", null, false, this.AutoSave ));
                list.Add("autoLoadParamsProxy", new ConfigOption("autoLoadParamsProxy", new SerializationOptions("autoLoad", typeof(AutoLoadParamsJsonConverter)), null, this.AutoLoadParamsProxy ));
                list.Add("proxy", new ConfigOption("proxy", new SerializationOptions("proxy>Proxy"), null, this.Proxy ));
                list.Add("updateProxy", new ConfigOption("updateProxy", new SerializationOptions("updateProxy>Proxy"), null, this.UpdateProxy ));
                list.Add("reader", new ConfigOption("reader", new SerializationOptions("reader>Reader"), null, this.Reader ));
                list.Add("pruneModifiedRecords", new ConfigOption("pruneModifiedRecords", null, false, this.PruneModifiedRecords ));
                list.Add("remoteSort", new ConfigOption("remoteSort", null, false, this.RemoteSort ));
                list.Add("sortInfo", new ConfigOption("sortInfo", new SerializationOptions(JsonMode.Object), null, this.SortInfo ));
                list.Add("warningOnDirty", new ConfigOption("warningOnDirty", null, true, this.WarningOnDirty ));
                list.Add("dirtyWarningTitle", new ConfigOption("dirtyWarningTitle", null, "Uncommitted Changes", this.DirtyWarningTitle ));
                list.Add("dirtyWarningText", new ConfigOption("dirtyWarningText", null, "You have uncommitted changes.  Are you sure you want to load/reload data?", this.DirtyWarningText ));
                list.Add("refreshAfterSaving", new ConfigOption("refreshAfterSaving", new SerializationOptions("refreshAfterSave", JsonMode.Value), RefreshAfterSavingMode.Auto, this.RefreshAfterSaving ));
                list.Add("useIdConfirmation", new ConfigOption("useIdConfirmation", new SerializationOptions("useIdConfirmation", JsonMode.Value), false, this.UseIdConfirmation ));
                list.Add("directEventConfig", new ConfigOption("directEventConfig", new SerializationOptions(JsonMode.ObjectAllowEmpty), null, this.DirectEventConfig ));
                list.Add("groupField", new ConfigOption("groupField", null, "", this.GroupField ));
                list.Add("groupDir", new ConfigOption("groupDir", new SerializationOptions(JsonMode.ToLower), SortDirection.Default, this.GroupDir ));
                list.Add("groupOnSort", new ConfigOption("groupOnSort", null, false, this.GroupOnSort ));
                list.Add("remoteGroup", new ConfigOption("remoteGroup", null, false, this.RemoteGroup ));
                list.Add("showWarningOnFailure", new ConfigOption("showWarningOnFailure", null, true, this.ShowWarningOnFailure ));
                list.Add("skipIdForNewRecords", new ConfigOption("skipIdForNewRecords", null, true, this.SkipIdForNewRecords ));

                return list;
            }
        }
    }
}