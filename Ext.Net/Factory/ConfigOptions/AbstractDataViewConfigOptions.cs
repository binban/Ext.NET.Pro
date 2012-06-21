/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class AbstractDataView
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
                
                list.Add("copy", new ConfigOption("copy", null, false, this.Copy ));
                list.Add("allowCopy", new ConfigOption("allowCopy", null, false, this.AllowCopy ));
                list.Add("blockRefresh", new ConfigOption("blockRefresh", null, false, this.BlockRefresh ));
                list.Add("deferEmptyText", new ConfigOption("deferEmptyText", null, true, this.DeferEmptyText ));
                list.Add("deferInitialRefresh", new ConfigOption("deferInitialRefresh", null, true, this.DeferInitialRefresh ));
                list.Add("disableSelection", new ConfigOption("disableSelection", null, false, this.DisableSelection ));
                list.Add("emptyText", new ConfigOption("emptyText", null, "", this.EmptyText ));
                list.Add("itemCls", new ConfigOption("itemCls", null, "", this.ItemCls ));
                list.Add("itemSelector", new ConfigOption("itemSelector", null, "", this.ItemSelector ));
                list.Add("itemTpl", new ConfigOption("itemTpl", new SerializationOptions("itemTpl", typeof(LazyControlJsonConverter)), null, this.ItemTpl ));
                list.Add("loadMask", new ConfigOption("loadMask", null, true, this.LoadMask ));
                list.Add("loadingCls", new ConfigOption("loadingCls", null, "", this.LoadingCls ));
                list.Add("loadingUseMsg", new ConfigOption("loadingUseMsg", null, true, this.LoadingUseMsg ));
                list.Add("loadingHeight", new ConfigOption("loadingHeight", null, null, this.LoadingHeight ));
                list.Add("loadingText", new ConfigOption("loadingText", null, "", this.LoadingText ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, false, this.MultiSelect ));
                list.Add("overItemCls", new ConfigOption("overItemCls", null, "", this.OverItemCls ));
                list.Add("preserveScrollOnRefresh", new ConfigOption("preserveScrollOnRefresh", null, false, this.PreserveScrollOnRefresh ));
                list.Add("selectedItemCls", new ConfigOption("selectedItemCls", null, "x-item-selected", this.SelectedItemCls ));
                list.Add("simpleSelect", new ConfigOption("simpleSelect", null, false, this.SimpleSelect ));
                list.Add("singleSelect", new ConfigOption("singleSelect", null, false, this.SingleSelect ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("tpl", new ConfigOption("tpl", new SerializationOptions("tpl", typeof(LazyControlJsonConverter)), null, this.Tpl ));
                list.Add("trackOver", new ConfigOption("trackOver", null, false, this.TrackOver ));
                list.Add("prepareData", new ConfigOption("prepareData", new SerializationOptions(JsonMode.Raw), null, this.PrepareData ));

                return list;
            }
        }
    }
}