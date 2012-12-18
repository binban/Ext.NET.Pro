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
    public abstract partial class AbstractPanel
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
                
                list.Add("tabConfig", new ConfigOption("tabConfig", new SerializationOptions(typeof(LazyControlJsonConverter)), null, this.TabConfig ));
                list.Add("bodyCls", new ConfigOption("bodyCls", null, "", this.BodyCls ));
                list.Add("bodyStyle", new ConfigOption("bodyStyle", null, "", this.BodyStyle ));
                list.Add("animCollapseProxy", new ConfigOption("animCollapseProxy", new SerializationOptions("animCollapse", JsonMode.Raw), "", this.AnimCollapseProxy ));
                list.Add("bodyBorder", new ConfigOption("bodyBorder", null, null, this.BodyBorder ));
                list.Add("bodyPadding", new ConfigOption("bodyPadding", null, null, this.BodyPadding ));
                list.Add("bodyPaddingSummary", new ConfigOption("bodyPaddingSummary", new SerializationOptions("bodyPadding"), null, this.BodyPaddingSummary ));
                list.Add("bottomBar", new ConfigOption("bottomBar", new SerializationOptions("bbar", typeof(SingleItemCollectionJsonConverter)), null, this.BottomBar ));
                list.Add("buttonAlign", new ConfigOption("buttonAlign", new SerializationOptions(JsonMode.ToLower), Alignment.Right, this.ButtonAlign ));
                list.Add("buttons", new ConfigOption("buttons", new SerializationOptions("buttons", typeof(ItemCollectionJsonConverter)), null, this.Buttons ));
                list.Add("closable", new ConfigOption("closable", null, false, this.Closable ));
                list.Add("closeAction", new ConfigOption("closeAction", new SerializationOptions(JsonMode.ToLower), CloseAction.Destroy, this.CloseAction ));
                list.Add("collapseDirection", new ConfigOption("collapseDirection", new SerializationOptions(JsonMode.ToLower), Direction.None, this.CollapseDirection ));
                list.Add("collapseFirst", new ConfigOption("collapseFirst", null, true, this.CollapseFirst ));
                list.Add("collapseMode", new ConfigOption("collapseMode", new SerializationOptions(JsonMode.ToLower), CollapseMode.Default, this.CollapseMode ));
                list.Add("collapsedProxy", new ConfigOption("collapsedProxy", new SerializationOptions("collapsed", JsonMode.Raw), "", this.CollapsedProxy ));
                list.Add("collapsedCls", new ConfigOption("collapsedCls", null, "", this.CollapsedCls ));
                list.Add("collapsible", new ConfigOption("collapsible", null, false, this.Collapsible ));
                list.Add("dockedItemsProxy", new ConfigOption("dockedItemsProxy", new SerializationOptions("dockedItems", typeof(ItemCollectionJsonConverter)), null, this.DockedItemsProxy ));
                list.Add("footerBar", new ConfigOption("footerBar", new SerializationOptions("fbar", typeof(SingleItemCollectionJsonConverter)), null, this.FooterBar ));
                list.Add("leftBar", new ConfigOption("leftBar", new SerializationOptions("lbar", typeof(SingleItemCollectionJsonConverter)), null, this.LeftBar ));
                list.Add("rightBar", new ConfigOption("rightBar", new SerializationOptions("rbar", typeof(SingleItemCollectionJsonConverter)), null, this.RightBar ));
                list.Add("floatable", new ConfigOption("floatable", null, true, this.Floatable ));
                list.Add("frameHeader", new ConfigOption("frameHeader", null, true, this.FrameHeader ));
                list.Add("header", new ConfigOption("header", null, true, this.Header ));
                list.Add("headerConfig", new ConfigOption("headerConfig", new SerializationOptions("header", typeof(LazyControlJsonConverter)), null, this.HeaderConfig ));
                list.Add("headerPosition", new ConfigOption("headerPosition", new SerializationOptions(JsonMode.ToLower), Direction.Top, this.HeaderPosition ));
                list.Add("headerTextCls", new ConfigOption("headerTextCls", null, "", this.HeaderTextCls ));
                list.Add("hideCollapseTool", new ConfigOption("hideCollapseTool", null, false, this.HideCollapseTool ));
                list.Add("manageHeight", new ConfigOption("manageHeight", null, true, this.ManageHeight ));
                list.Add("minButtonWidth", new ConfigOption("minButtonWidth", null, 75, this.MinButtonWidth ));
                list.Add("overlapHeader", new ConfigOption("overlapHeader", null, null, this.OverlapHeader ));
                list.Add("placeHolder", new ConfigOption("placeHolder", new SerializationOptions(typeof(SingleItemCollectionJsonConverter)), null, this.PlaceHolder ));
                list.Add("topBar", new ConfigOption("topBar", new SerializationOptions("tbar", typeof(SingleItemCollectionJsonConverter)), null, this.TopBar ));
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("titleAlign", new ConfigOption("titleAlign", new SerializationOptions(JsonMode.ToLower), TitleAlign.Default, this.TitleAlign ));
                list.Add("titleCollapse", new ConfigOption("titleCollapse", null, false, this.TitleCollapse ));
                list.Add("draggableConfigProxy", new ConfigOption("draggableConfigProxy", new SerializationOptions("draggable", JsonMode.Raw), "", this.DraggableConfigProxy ));
                list.Add("draggableProxy", new ConfigOption("draggableProxy", new SerializationOptions("draggable"), false, this.DraggableProxy ));
                list.Add("defaultDockWeightsProxy", new ConfigOption("defaultDockWeightsProxy", new SerializationOptions("defaultDockWeights", JsonMode.Raw), null, this.DefaultDockWeightsProxy ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("iconPath", new ConfigOption("iconPath", new SerializationOptions("icon", JsonMode.Url), "", this.IconPath ));
                list.Add("tools", new ConfigOption("tools", new SerializationOptions("tools", typeof(ItemCollectionJsonConverter)), null, this.Tools ));
                list.Add("unstyled", new ConfigOption("unstyled", null, false, this.Unstyled ));

                return list;
            }
        }
    }
}