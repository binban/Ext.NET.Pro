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
    public partial class TablePanelDirectEvents
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
                
                list.Add("beforeSelect", new ConfigOption("beforeSelect", new SerializationOptions("beforeselect", typeof(DirectEventJsonConverter)), null, this.BeforeSelect ));
                list.Add("beforeContainerClick", new ConfigOption("beforeContainerClick", new SerializationOptions("beforecontainerclick", typeof(DirectEventJsonConverter)), null, this.BeforeContainerClick ));
                list.Add("beforeContainerContextMenu", new ConfigOption("beforeContainerContextMenu", new SerializationOptions("beforecontainercontextmenu", typeof(DirectEventJsonConverter)), null, this.BeforeContainerContextMenu ));
                list.Add("beforeContainerDblClick", new ConfigOption("beforeContainerDblClick", new SerializationOptions("beforecontainerdblclick", typeof(DirectEventJsonConverter)), null, this.BeforeContainerDblClick ));
                list.Add("beforeContainerMouseDown", new ConfigOption("beforeContainerMouseDown", new SerializationOptions("beforecontainermousedown", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseDown ));
                list.Add("beforeContainerMouseOut", new ConfigOption("beforeContainerMouseOut", new SerializationOptions("beforecontainermouseout", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseOut ));
                list.Add("beforeContainerMouseOver", new ConfigOption("beforeContainerMouseOver", new SerializationOptions("beforecontainermouseover", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseOver ));
                list.Add("beforeContainerMouseUp", new ConfigOption("beforeContainerMouseUp", new SerializationOptions("beforecontainermouseup", typeof(DirectEventJsonConverter)), null, this.BeforeContainerMouseUp ));
                list.Add("beforeDeselect", new ConfigOption("beforeDeselect", new SerializationOptions("beforedeselect", typeof(DirectEventJsonConverter)), null, this.BeforeDeselect ));
                list.Add("beforeEdit", new ConfigOption("beforeEdit", new SerializationOptions("beforeedit", typeof(DirectEventJsonConverter)), null, this.BeforeEdit ));
                list.Add("beforeItemClick", new ConfigOption("beforeItemClick", new SerializationOptions("beforeitemclick", typeof(DirectEventJsonConverter)), null, this.BeforeItemClick ));
                list.Add("beforeItemContextMenu", new ConfigOption("beforeItemContextMenu", new SerializationOptions("beforeitemcontextmenu", typeof(DirectEventJsonConverter)), null, this.BeforeItemContextMenu ));
                list.Add("beforeItemDblClick", new ConfigOption("beforeItemDblClick", new SerializationOptions("beforeitemdblclick", typeof(DirectEventJsonConverter)), null, this.BeforeItemDblClick ));
                list.Add("beforeItemMouseDown", new ConfigOption("beforeItemMouseDown", new SerializationOptions("beforeitemmousedown", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseDown ));
                list.Add("beforeItemMouseEnter", new ConfigOption("beforeItemMouseEnter", new SerializationOptions("beforeitemmouseenter", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseEnter ));
                list.Add("beforeItemMouseLeave", new ConfigOption("beforeItemMouseLeave", new SerializationOptions("beforeitemmouseleave", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseLeave ));
                list.Add("beforeItemMouseUp", new ConfigOption("beforeItemMouseUp", new SerializationOptions("beforeitemmouseup", typeof(DirectEventJsonConverter)), null, this.BeforeItemMouseUp ));
                list.Add("cancelEdit", new ConfigOption("cancelEdit", new SerializationOptions("canceledit", typeof(DirectEventJsonConverter)), null, this.CancelEdit ));
                list.Add("containerClick", new ConfigOption("containerClick", new SerializationOptions("containerclick", typeof(DirectEventJsonConverter)), null, this.ContainerClick ));
                list.Add("containerContextMenu", new ConfigOption("containerContextMenu", new SerializationOptions("containercontextmenu", typeof(DirectEventJsonConverter)), null, this.ContainerContextMenu ));
                list.Add("containerDblClick", new ConfigOption("containerDblClick", new SerializationOptions("containerdblclick", typeof(DirectEventJsonConverter)), null, this.ContainerDblClick ));
                list.Add("containerMouseOut", new ConfigOption("containerMouseOut", new SerializationOptions("containermouseout", typeof(DirectEventJsonConverter)), null, this.ContainerMouseOut ));
                list.Add("containerMouseOver", new ConfigOption("containerMouseOver", new SerializationOptions("containermouseover", typeof(DirectEventJsonConverter)), null, this.ContainerMouseOver ));
                list.Add("containerMouseUp", new ConfigOption("containerMouseUp", new SerializationOptions("containermouseup", typeof(DirectEventJsonConverter)), null, this.ContainerMouseUp ));
                list.Add("deselect", new ConfigOption("deselect", new SerializationOptions("deselect", typeof(DirectEventJsonConverter)), null, this.Deselect ));
                list.Add("edit", new ConfigOption("edit", new SerializationOptions("edit", typeof(DirectEventJsonConverter)), null, this.Edit ));
                list.Add("itemClick", new ConfigOption("itemClick", new SerializationOptions("itemclick", typeof(DirectEventJsonConverter)), null, this.ItemClick ));
                list.Add("itemContextMenu", new ConfigOption("itemContextMenu", new SerializationOptions("itemcontextmenu", typeof(DirectEventJsonConverter)), null, this.ItemContextMenu ));
                list.Add("itemDblClick", new ConfigOption("itemDblClick", new SerializationOptions("itemdblclick", typeof(DirectEventJsonConverter)), null, this.ItemDblClick ));
                list.Add("itemMouseDown", new ConfigOption("itemMouseDown", new SerializationOptions("itemmousedown", typeof(DirectEventJsonConverter)), null, this.ItemMouseDown ));
                list.Add("itemMouseEnter", new ConfigOption("itemMouseEnter", new SerializationOptions("itemmouseenter", typeof(DirectEventJsonConverter)), null, this.ItemMouseEnter ));
                list.Add("itemMouseLeave", new ConfigOption("itemMouseLeave", new SerializationOptions("itemmouseleave", typeof(DirectEventJsonConverter)), null, this.ItemMouseLeave ));
                list.Add("itemMouseUp", new ConfigOption("itemMouseUp", new SerializationOptions("itemmouseup", typeof(DirectEventJsonConverter)), null, this.ItemMouseUp ));
                list.Add("reconfigure", new ConfigOption("reconfigure", new SerializationOptions("reconfigure", typeof(DirectEventJsonConverter)), null, this.Reconfigure ));
                list.Add("scrollerHide", new ConfigOption("scrollerHide", new SerializationOptions("scrollerhide", typeof(DirectEventJsonConverter)), null, this.ScrollerHide ));
                list.Add("scrollerShow", new ConfigOption("scrollerShow", new SerializationOptions("scrollershow", typeof(DirectEventJsonConverter)), null, this.ScrollerShow ));
                list.Add("columnHide", new ConfigOption("columnHide", new SerializationOptions("columnhide", typeof(DirectEventJsonConverter)), null, this.ColumnHide ));
                list.Add("columnMove", new ConfigOption("columnMove", new SerializationOptions("columnmove", typeof(DirectEventJsonConverter)), null, this.ColumnMove ));
                list.Add("columnResize", new ConfigOption("columnResize", new SerializationOptions("columnresize", typeof(DirectEventJsonConverter)), null, this.ColumnResize ));
                list.Add("columnShow", new ConfigOption("columnShow", new SerializationOptions("columnshow", typeof(DirectEventJsonConverter)), null, this.ColumnShow ));
                list.Add("cellClick", new ConfigOption("cellClick", new SerializationOptions("cellclick", typeof(DirectEventJsonConverter)), null, this.CellClick ));
                list.Add("cellDblClick", new ConfigOption("cellDblClick", new SerializationOptions("celldblclick", typeof(DirectEventJsonConverter)), null, this.CellDblClick ));
                list.Add("selectionChange", new ConfigOption("selectionChange", new SerializationOptions("selectionchange", typeof(DirectEventJsonConverter)), null, this.SelectionChange ));
                list.Add("sortChange", new ConfigOption("sortChange", new SerializationOptions("sortchange", typeof(DirectEventJsonConverter)), null, this.SortChange ));
                list.Add("select", new ConfigOption("select", new SerializationOptions("select", typeof(DirectEventJsonConverter)), null, this.Select ));
                list.Add("validateEdit", new ConfigOption("validateEdit", new SerializationOptions("validateedit", typeof(DirectEventJsonConverter)), null, this.ValidateEdit ));
                list.Add("viewReady", new ConfigOption("viewReady", new SerializationOptions("viewready", typeof(DirectEventJsonConverter)), null, this.ViewReady ));

                return list;
            }
        }
    }
}