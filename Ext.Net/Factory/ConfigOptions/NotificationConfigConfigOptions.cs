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
    public partial class NotificationConfig
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
                
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("items", JsonMode.Raw), null, this.ItemsProxy ));
                list.Add("dockedItemsProxy", new ConfigOption("dockedItemsProxy", new SerializationOptions("dockedItems", JsonMode.Raw), null, this.DockedItemsProxy ));
                list.Add("layoutConfig", new ConfigOption("layoutConfig", new SerializationOptions("layout>Primary"), null, this.LayoutConfig ));
                list.Add("layoutProxy", new ConfigOption("layoutProxy", new SerializationOptions("layout"), "", this.LayoutProxy ));
                list.Add("iD", new ConfigOption("iD", new SerializationOptions("id"), "", this.ID ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("ctCls", new ConfigOption("ctCls", null, "", this.CtCls ));
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("html", new ConfigOption("html", null, "", this.Html ));
                list.Add("contentEl", new ConfigOption("contentEl", null, "", this.ContentEl ));
                list.Add("width", new ConfigOption("width", null, Unit.Pixel(200), this.Width ));
                list.Add("height", new ConfigOption("height", null, Unit.Pixel(100), this.Height ));
                list.Add("autoHide", new ConfigOption("autoHide", null, true, this.AutoHide ));
                list.Add("autoScroll", new ConfigOption("autoScroll", null, false, this.AutoScroll ));
                list.Add("closable", new ConfigOption("closable", null, true, this.Closable ));
                list.Add("shadow", new ConfigOption("shadow", null, false, this.Shadow ));
                list.Add("header", new ConfigOption("header", null, false, this.Header ));
                list.Add("plain", new ConfigOption("plain", null, false, this.Plain ));
                list.Add("resizable", new ConfigOption("resizable", null, false, this.Resizable ));
                list.Add("draggable", new ConfigOption("draggable", null, false, this.Draggable ));
                list.Add("bodyStyle", new ConfigOption("bodyStyle", null, "", this.BodyStyle ));
                list.Add("alignCfg", new ConfigOption("alignCfg", new SerializationOptions("alignToCfg", JsonMode.Object), null, this.AlignCfg ));
                list.Add("showMode", new ConfigOption("showMode", null, ShowMode.Grid, this.ShowMode ));
                list.Add("closeVisible", new ConfigOption("closeVisible", null, false, this.CloseVisible ));
                list.Add("modal", new ConfigOption("modal", null, false, this.Modal ));
                list.Add("pinEventProxy", new ConfigOption("pinEventProxy", new SerializationOptions("pinEvent"), "none", this.PinEventProxy ));
                list.Add("hideDelay", new ConfigOption("hideDelay", null, 2500, this.HideDelay ));
                list.Add("customConfig", new ConfigOption("customConfig", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomConfig ));
                list.Add("showFx", new ConfigOption("showFx", new SerializationOptions(JsonMode.Object), null, this.ShowFx ));
                list.Add("hideFx", new ConfigOption("hideFx", new SerializationOptions(JsonMode.Object), null, this.HideFx ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("autoLoadProxy", new ConfigOption("autoLoadProxy", new SerializationOptions("autoLoad", JsonMode.Raw), "", this.AutoLoadProxy ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("tools", new ConfigOption("tools", new SerializationOptions(JsonMode.AlwaysArray), null, this.Tools ));
                list.Add("showPin", new ConfigOption("showPin", null, false, this.ShowPin ));
                list.Add("pinned", new ConfigOption("pinned", null, false, this.Pinned ));
                list.Add("bringToFront", new ConfigOption("bringToFront", null, false, this.BringToFront ));

                return list;
            }
        }
    }
}