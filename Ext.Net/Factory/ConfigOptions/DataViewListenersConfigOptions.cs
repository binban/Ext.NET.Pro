/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class DataViewListeners
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
                
                list.Add("beforeRefresh", new ConfigOption("beforeRefresh", new SerializationOptions("beforerefresh", typeof(ListenerJsonConverter)), null, this.BeforeRefresh ));
                list.Add("itemAdd", new ConfigOption("itemAdd", new SerializationOptions("itemadd", typeof(ListenerJsonConverter)), null, this.ItemAdd ));
                list.Add("itemRemove", new ConfigOption("itemRemove", new SerializationOptions("itemremove", typeof(ListenerJsonConverter)), null, this.ItemRemove ));
                list.Add("itemUpdate", new ConfigOption("itemUpdate", new SerializationOptions("itemupdate", typeof(ListenerJsonConverter)), null, this.ItemUpdate ));
                list.Add("refresh", new ConfigOption("refresh", new SerializationOptions("refresh", typeof(ListenerJsonConverter)), null, this.Refresh ));
                list.Add("viewReady", new ConfigOption("viewReady", new SerializationOptions("viewready", typeof(ListenerJsonConverter)), null, this.ViewReady ));
                list.Add("beforeContainerClick", new ConfigOption("beforeContainerClick", new SerializationOptions("beforecontainerclick", typeof(ListenerJsonConverter)), null, this.BeforeContainerClick ));
                list.Add("beforeContainerContextMenu", new ConfigOption("beforeContainerContextMenu", new SerializationOptions("beforecontainercontextmenu", typeof(ListenerJsonConverter)), null, this.BeforeContainerContextMenu ));
                list.Add("beforeContainerDblClick", new ConfigOption("beforeContainerDblClick", new SerializationOptions("beforecontainerdblclick", typeof(ListenerJsonConverter)), null, this.BeforeContainerDblClick ));
                list.Add("beforeContainerKeyDown", new ConfigOption("beforeContainerKeyDown", new SerializationOptions("beforecontainerkeydown", typeof(ListenerJsonConverter)), null, this.BeforeContainerKeyDown ));
                list.Add("beforeContainerMouseDown", new ConfigOption("beforeContainerMouseDown", new SerializationOptions("beforecontainermousedown", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseDown ));
                list.Add("beforeContainerMouseOut", new ConfigOption("beforeContainerMouseOut", new SerializationOptions("beforecontainermouseout", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseOut ));
                list.Add("beforeContainerMouseOver", new ConfigOption("beforeContainerMouseOver", new SerializationOptions("beforecontainermouseover", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseOver ));
                list.Add("beforeContainerMouseUp", new ConfigOption("beforeContainerMouseUp", new SerializationOptions("beforecontainermouseup", typeof(ListenerJsonConverter)), null, this.BeforeContainerMouseUp ));
                list.Add("beforeItemClick", new ConfigOption("beforeItemClick", new SerializationOptions("beforeitemclick", typeof(ListenerJsonConverter)), null, this.BeforeItemClick ));
                list.Add("beforeItemContextMenu", new ConfigOption("beforeItemContextMenu", new SerializationOptions("beforeitemcontextmenu", typeof(ListenerJsonConverter)), null, this.BeforeItemContextMenu ));
                list.Add("beforeItemDblClick", new ConfigOption("beforeItemDblClick", new SerializationOptions("beforeitemdblclick", typeof(ListenerJsonConverter)), null, this.BeforeItemDblClick ));
                list.Add("beforeItemKeyDown", new ConfigOption("beforeItemKeyDown", new SerializationOptions("beforeitemkeydown", typeof(ListenerJsonConverter)), null, this.BeforeItemKeyDown ));
                list.Add("beforeItemMouseDown", new ConfigOption("beforeItemMouseDown", new SerializationOptions("beforeitemmousedown", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseDown ));
                list.Add("beforeItemMouseEnter", new ConfigOption("beforeItemMouseEnter", new SerializationOptions("beforeitemmouseenter", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseEnter ));
                list.Add("beforeItemMouseLeave", new ConfigOption("beforeItemMouseLeave", new SerializationOptions("beforeitemmouseleave", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseLeave ));
                list.Add("beforeItemMouseUp", new ConfigOption("beforeItemMouseUp", new SerializationOptions("beforeitemmouseup", typeof(ListenerJsonConverter)), null, this.BeforeItemMouseUp ));
                list.Add("beforeSelect", new ConfigOption("beforeSelect", new SerializationOptions("beforeselect", typeof(ListenerJsonConverter)), null, this.BeforeSelect ));
                list.Add("containerClick", new ConfigOption("containerClick", new SerializationOptions("containerclick", typeof(ListenerJsonConverter)), null, this.ContainerClick ));
                list.Add("containerContextMenu", new ConfigOption("containerContextMenu", new SerializationOptions("containercontextmenu", typeof(ListenerJsonConverter)), null, this.ContainerContextMenu ));
                list.Add("containerDblClick", new ConfigOption("containerDblClick", new SerializationOptions("containerdblclick", typeof(ListenerJsonConverter)), null, this.ContainerDblClick ));
                list.Add("containerKeyDown", new ConfigOption("containerKeyDown", new SerializationOptions("containerkeydown", typeof(ListenerJsonConverter)), null, this.ContainerKeyDown ));
                list.Add("containerMouseOut", new ConfigOption("containerMouseOut", new SerializationOptions("containermouseout", typeof(ListenerJsonConverter)), null, this.ContainerMouseOut ));
                list.Add("containerMouseOver", new ConfigOption("containerMouseOver", new SerializationOptions("containermouseover", typeof(ListenerJsonConverter)), null, this.ContainerMouseOver ));
                list.Add("containerMouseUp", new ConfigOption("containerMouseUp", new SerializationOptions("containermouseup", typeof(ListenerJsonConverter)), null, this.ContainerMouseUp ));
                list.Add("highlightItem", new ConfigOption("highlightItem", new SerializationOptions("highlightitem", typeof(ListenerJsonConverter)), null, this.HighlightItem ));
                list.Add("itemClick", new ConfigOption("itemClick", new SerializationOptions("itemclick", typeof(ListenerJsonConverter)), null, this.ItemClick ));
                list.Add("itemContextMenu", new ConfigOption("itemContextMenu", new SerializationOptions("itemcontextmenu", typeof(ListenerJsonConverter)), null, this.ItemContextMenu ));
                list.Add("itemDblClick", new ConfigOption("itemDblClick", new SerializationOptions("itemdblclick", typeof(ListenerJsonConverter)), null, this.ItemDblClick ));
                list.Add("itemKeyDown", new ConfigOption("itemKeyDown", new SerializationOptions("itemkeydown", typeof(ListenerJsonConverter)), null, this.ItemKeyDown ));
                list.Add("itemMouseDown", new ConfigOption("itemMouseDown", new SerializationOptions("itemmousedown", typeof(ListenerJsonConverter)), null, this.ItemMouseDown ));
                list.Add("itemMouseEnter", new ConfigOption("itemMouseEnter", new SerializationOptions("itemmouseenter", typeof(ListenerJsonConverter)), null, this.ItemMouseEnter ));
                list.Add("itemMouseLeave", new ConfigOption("itemMouseLeave", new SerializationOptions("itemmouseleave", typeof(ListenerJsonConverter)), null, this.ItemMouseLeave ));
                list.Add("itemMouseUp", new ConfigOption("itemMouseUp", new SerializationOptions("itemmouseup", typeof(ListenerJsonConverter)), null, this.ItemMouseUp ));
                list.Add("selectionChange", new ConfigOption("selectionChange", new SerializationOptions("selectionchange", typeof(ListenerJsonConverter)), null, this.SelectionChange ));
                list.Add("unhighlightItem", new ConfigOption("unhighlightItem", new SerializationOptions("unhighlightitem", typeof(ListenerJsonConverter)), null, this.UnhighlightItem ));
                list.Add("beforeDrop", new ConfigOption("beforeDrop", new SerializationOptions("beforedrop", typeof(ListenerJsonConverter)), null, this.BeforeDrop ));
                list.Add("drop", new ConfigOption("drop", new SerializationOptions("drop", typeof(ListenerJsonConverter)), null, this.Drop ));
                list.Add("beforeItemRemove", new ConfigOption("beforeItemRemove", new SerializationOptions("beforeitemremove", typeof(ListenerJsonConverter)), null, this.BeforeItemRemove ));
                list.Add("beforeItemUpdate", new ConfigOption("beforeItemUpdate", new SerializationOptions("beforeitemupdate", typeof(ListenerJsonConverter)), null, this.BeforeItemUpdate ));

                return list;
            }
        }
    }
}