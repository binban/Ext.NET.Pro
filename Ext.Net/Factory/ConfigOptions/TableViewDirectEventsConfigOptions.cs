/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public partial class TableViewDirectEvents
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
                
                list.Add("uIEvent", new ConfigOption("uIEvent", new SerializationOptions("uievent", typeof(DirectEventJsonConverter)), null, this.UIEvent ));
                list.Add("bodyScroll", new ConfigOption("bodyScroll", new SerializationOptions("bodyscroll", typeof(DirectEventJsonConverter)), null, this.BodyScroll ));
                list.Add("rowFocus", new ConfigOption("rowFocus", new SerializationOptions("rowfocus", typeof(DirectEventJsonConverter)), null, this.RowFocus ));
                list.Add("cellFocus", new ConfigOption("cellFocus", new SerializationOptions("cellfocus", typeof(DirectEventJsonConverter)), null, this.CellFocus ));
                list.Add("beforeCellMouseDown", new ConfigOption("beforeCellMouseDown", new SerializationOptions("beforecellmousedown", typeof(DirectEventJsonConverter)), null, this.BeforeCellMouseDown ));
                list.Add("beforeCellMouseUp", new ConfigOption("beforeCellMouseUp", new SerializationOptions("beforecellmouseup", typeof(DirectEventJsonConverter)), null, this.BeforeCellMouseUp ));
                list.Add("beforeCellClick", new ConfigOption("beforeCellClick", new SerializationOptions("beforecellclick", typeof(DirectEventJsonConverter)), null, this.BeforeCellClick ));
                list.Add("beforeCellDblClick", new ConfigOption("beforeCellDblClick", new SerializationOptions("beforecelldblclick", typeof(DirectEventJsonConverter)), null, this.BeforeCellDblClick ));
                list.Add("beforeCellContextMenu", new ConfigOption("beforeCellContextMenu", new SerializationOptions("beforecellcontextmenu", typeof(DirectEventJsonConverter)), null, this.BeforeCellContextMenu ));
                list.Add("beforeCellKeyDown", new ConfigOption("beforeCellKeyDown", new SerializationOptions("beforecellkeydown", typeof(DirectEventJsonConverter)), null, this.BeforeCellKeyDown ));
                list.Add("cellMouseDown", new ConfigOption("cellMouseDown", new SerializationOptions("cellmousedown", typeof(DirectEventJsonConverter)), null, this.CellMouseDown ));
                list.Add("cellMouseUp", new ConfigOption("cellMouseUp", new SerializationOptions("cellmouseup", typeof(DirectEventJsonConverter)), null, this.CellMouseUp ));
                list.Add("cellClick", new ConfigOption("cellClick", new SerializationOptions("cellclick", typeof(DirectEventJsonConverter)), null, this.CellClick ));
                list.Add("cellDblClick", new ConfigOption("cellDblClick", new SerializationOptions("celldblclick", typeof(DirectEventJsonConverter)), null, this.CellDblClick ));
                list.Add("cellContextMenu", new ConfigOption("cellContextMenu", new SerializationOptions("cellcontextmenu", typeof(DirectEventJsonConverter)), null, this.CellContextMenu ));
                list.Add("cellKeyDown", new ConfigOption("cellKeyDown", new SerializationOptions("cellkeydown", typeof(DirectEventJsonConverter)), null, this.CellKeyDown ));
                list.Add("beforeDrop", new ConfigOption("beforeDrop", new SerializationOptions("beforedrop", typeof(DirectEventJsonConverter)), null, this.BeforeDrop ));
                list.Add("drop", new ConfigOption("drop", new SerializationOptions("drop", typeof(DirectEventJsonConverter)), null, this.Drop ));
                list.Add("groupClick", new ConfigOption("groupClick", new SerializationOptions("groupclick", typeof(DirectEventJsonConverter)), null, this.GroupClick ));
                list.Add("groupCollapse", new ConfigOption("groupCollapse", new SerializationOptions("groupcollapse", typeof(DirectEventJsonConverter)), null, this.GroupCollapse ));
                list.Add("groupContextMenu", new ConfigOption("groupContextMenu", new SerializationOptions("groupcontextmenu", typeof(DirectEventJsonConverter)), null, this.GroupContextMenu ));
                list.Add("groupDblClick", new ConfigOption("groupDblClick", new SerializationOptions("groupdblclick", typeof(DirectEventJsonConverter)), null, this.GroupDblClick ));
                list.Add("groupExpand", new ConfigOption("groupExpand", new SerializationOptions("groupexpand", typeof(DirectEventJsonConverter)), null, this.GroupExpand ));

                return list;
            }
        }
    }
}