/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    public abstract partial class ComboBoxBase
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
                
                list.Add("selectedItemsProxy", new ConfigOption("selectedItemsProxy", new SerializationOptions("selectedItems", JsonMode.Raw), "", this.SelectedItemsProxy ));
                list.Add("valueHiddenName", new ConfigOption("valueHiddenName", null, "", this.ValueHiddenName ));
                list.Add("simpleSubmit", new ConfigOption("simpleSubmit", null, false, this.SimpleSubmit ));
                list.Add("allQuery", new ConfigOption("allQuery", null, "", this.AllQuery ));
                list.Add("autoSelect", new ConfigOption("autoSelect", null, true, this.AutoSelect ));
                list.Add("delimiter", new ConfigOption("delimiter", null, ", ", this.Delimiter ));
                list.Add("displayField", new ConfigOption("displayField", null, "text", this.DisplayField ));
                list.Add("forceSelection", new ConfigOption("forceSelection", null, false, this.ForceSelection ));
                list.Add("growToLongestValue", new ConfigOption("growToLongestValue", null, true, this.GrowToLongestValue ));
                list.Add("listConfig", new ConfigOption("listConfig", new SerializationOptions("listConfig", typeof(LazyControlJsonConverter)), null, this.ListConfig ));
                list.Add("fireSelectOnLoad", new ConfigOption("fireSelectOnLoad", null, false, this.FireSelectOnLoad ));
                list.Add("minChars", new ConfigOption("minChars", null, 0, this.MinChars ));
                list.Add("multiSelect", new ConfigOption("multiSelect", null, false, this.MultiSelect ));
                list.Add("pageSize", new ConfigOption("pageSize", null, 0, this.PageSize ));
                list.Add("queryCaching", new ConfigOption("queryCaching", null, true, this.QueryCaching ));
                list.Add("queryDelay", new ConfigOption("queryDelay", null, -1, this.QueryDelay ));
                list.Add("queryMode", new ConfigOption("queryMode", new SerializationOptions("queryMode", JsonMode.ToLower), DataLoadMode.Remote, this.QueryMode ));
                list.Add("queryParam", new ConfigOption("queryParam", null, "query", this.QueryParam ));
                list.Add("selectOnTab", new ConfigOption("selectOnTab", null, true, this.SelectOnTab ));
                list.Add("transform", new ConfigOption("transform", null, "", this.Transform ));
                list.Add("triggerAction", new ConfigOption("triggerAction", new SerializationOptions(JsonMode.ToLower), TriggerAction.Query, this.TriggerAction ));
                list.Add("typeAhead", new ConfigOption("typeAhead", null, false, this.TypeAhead ));
                list.Add("typeAheadDelay", new ConfigOption("typeAheadDelay", null, 250, this.TypeAheadDelay ));
                list.Add("valueField", new ConfigOption("valueField", null, "", this.ValueField ));
                list.Add("valueNotFoundText", new ConfigOption("valueNotFoundText", null, "", this.ValueNotFoundText ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("alwaysMergeItems", new ConfigOption("alwaysMergeItems", null, true, this.AlwaysMergeItems ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("store", JsonMode.Raw), "", this.ItemsProxy ));
                list.Add("mergeItems", new ConfigOption("mergeItems", new SerializationOptions("mergeItems", JsonMode.Raw), "", this.MergeItems ));
                list.Add("renderToProxy", new ConfigOption("renderToProxy", new SerializationOptions("renderTo"), "", this.RenderToProxy ));

                return list;
            }
        }
    }
}