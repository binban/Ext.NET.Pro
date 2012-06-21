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
    public partial class Node
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
                
                list.Add("nodeID", new ConfigOption("nodeID", new SerializationOptions("id"), "", this.NodeID ));
                list.Add("leaf", new ConfigOption("leaf", null, false, this.Leaf ));
                list.Add("allowDrag", new ConfigOption("allowDrag", null, true, this.AllowDrag ));
                list.Add("allowDrop", new ConfigOption("allowDrop", null, true, this.AllowDrop ));
                list.Add("checked", new ConfigOption("checked", null, null, this.Checked ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("expandable", new ConfigOption("expandable", null, false, this.Expandable ));
                list.Add("expanded", new ConfigOption("expanded", null, false, this.Expanded ));
                list.Add("emptyChildrenProxy", new ConfigOption("emptyChildrenProxy", new SerializationOptions("children", JsonMode.Raw), "", this.EmptyChildrenProxy ));
                list.Add("href", new ConfigOption("href", null, "#", this.Href ));
                list.Add("hrefTarget", new ConfigOption("hrefTarget", null, "", this.HrefTarget ));
                list.Add("iconFile", new ConfigOption("iconFile", new SerializationOptions("icon"), "", this.IconFile ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("qtip", new ConfigOption("qtip", null, "", this.Qtip ));
                list.Add("qtitle", new ConfigOption("qtitle", null, "", this.Qtitle ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("children", new ConfigOption("children", new SerializationOptions(JsonMode.AlwaysArray), null, this.Children ));
                list.Add("dataPath", new ConfigOption("dataPath", null, "", this.DataPath ));
                list.Add("customAttributes", new ConfigOption("customAttributes", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomAttributes ));
                list.Add("attributesObject", new ConfigOption("attributesObject", new SerializationOptions(JsonMode.UnrollObject), null, this.AttributesObject ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));

                return list;
            }
        }
    }
}