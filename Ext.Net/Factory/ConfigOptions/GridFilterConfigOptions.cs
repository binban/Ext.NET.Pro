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
    public abstract partial class GridFilter
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
                
                list.Add("active", new ConfigOption("active", null, false, this.Active ));
                list.Add("dataIndex", new ConfigOption("dataIndex", null, "", this.DataIndex ));
                list.Add("menuItems", new ConfigOption("menuItems", new SerializationOptions("items", typeof(ItemCollectionJsonConverter)), null, this.MenuItems ));
                list.Add("updateBuffer", new ConfigOption("updateBuffer", null, 500, this.UpdateBuffer ));
                list.Add("getValue", new ConfigOption("getValue", new SerializationOptions(JsonMode.Raw), null, this.GetValue ));
                list.Add("setValueFunc", new ConfigOption("setValueFunc", new SerializationOptions("setValue", JsonMode.Raw), null, this.SetValueFunc ));
                list.Add("getSerialArgs", new ConfigOption("getSerialArgs", new SerializationOptions(JsonMode.Raw), null, this.GetSerialArgs ));
                list.Add("validateRecord", new ConfigOption("validateRecord", new SerializationOptions(JsonMode.Raw), null, this.ValidateRecord ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));

                return list;
            }
        }
    }
}