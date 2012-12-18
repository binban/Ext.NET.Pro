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
    public partial class TreeViewDragDrop
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
                
                list.Add("pType", new ConfigOption("pType", new SerializationOptions("ptype"), "", this.PType ));
                list.Add("dragText", new ConfigOption("dragText", null, "{0} selected node{1}", this.DragText ));
                list.Add("allowParentInserts", new ConfigOption("allowParentInserts", null, false, this.AllowParentInserts ));
                list.Add("allowContainerDrops", new ConfigOption("allowContainerDrops", null, false, this.AllowContainerDrops ));
                list.Add("containerScroll", new ConfigOption("containerScroll", null, false, this.ContainerScroll ));
                list.Add("dDGroup", new ConfigOption("dDGroup", new SerializationOptions("ddGroup"), "TreeDD", this.DDGroup ));
                list.Add("dragGroup", new ConfigOption("dragGroup", null, "", this.DragGroup ));
                list.Add("dropGroup", new ConfigOption("dropGroup", null, "", this.DropGroup ));
                list.Add("enableDrag", new ConfigOption("enableDrag", null, true, this.EnableDrag ));
                list.Add("enableDrop", new ConfigOption("enableDrop", null, true, this.EnableDrop ));
                list.Add("appendOnly", new ConfigOption("appendOnly", null, false, this.AppendOnly ));
                list.Add("expandDelay", new ConfigOption("expandDelay", null, 1000, this.ExpandDelay ));
                list.Add("nodeHighlightColor", new ConfigOption("nodeHighlightColor", null, "c3daf9", this.NodeHighlightColor ));
                list.Add("nodeHighlightOnDrop", new ConfigOption("nodeHighlightOnDrop", null, true, this.NodeHighlightOnDrop ));
                list.Add("nodeHighlightOnRepair", new ConfigOption("nodeHighlightOnRepair", null, true, this.NodeHighlightOnRepair ));
                list.Add("allowLeafDrop", new ConfigOption("allowLeafDrop", null, false, this.AllowLeafDrop ));

                return list;
            }
        }
    }
}