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
    public abstract partial class DragDrop
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
                
                list.Add("configIDProxy", new ConfigOption("configIDProxy", new SerializationOptions(JsonMode.Ignore), "", this.ConfigIDProxy ));
                list.Add("defaultPadding", new ConfigOption("defaultPadding", new SerializationOptions("defaultPadding", JsonMode.Raw), null, this.DefaultPadding ));
                list.Add("groups", new ConfigOption("groups", new SerializationOptions("groups", JsonMode.Raw), null, this.Groups ));
                list.Add("hasOuterHandles", new ConfigOption("hasOuterHandles", null, false, this.HasOuterHandles ));
                list.Add("ignoreSelf", new ConfigOption("ignoreSelf", null, true, this.IgnoreSelf ));
                list.Add("invalidHandleClasses", new ConfigOption("invalidHandleClasses", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.InvalidHandleClasses ));
                list.Add("invalidHandleTypesProxy", new ConfigOption("invalidHandleTypesProxy", new SerializationOptions("invalidHandleTypes", JsonMode.Raw), "", this.InvalidHandleTypesProxy ));
                list.Add("invalidHandleIdsProxy", new ConfigOption("invalidHandleIdsProxy", new SerializationOptions("invalidHandleIds", JsonMode.Raw), "", this.InvalidHandleIdsProxy ));
                list.Add("isTarget", new ConfigOption("isTarget", null, true, this.IsTarget ));
                list.Add("maintainOffset", new ConfigOption("maintainOffset", null, false, this.MaintainOffset ));
                list.Add("moveOnly", new ConfigOption("moveOnly", null, false, this.MoveOnly ));
                list.Add("padding", new ConfigOption("padding", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.Padding ));
                list.Add("primaryButtonOnly", new ConfigOption("primaryButtonOnly", null, true, this.PrimaryButtonOnly ));
                list.Add("xTicks", new ConfigOption("xTicks", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.XTicks ));
                list.Add("yTicks", new ConfigOption("yTicks", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.YTicks ));
                list.Add("getDragEl", new ConfigOption("getDragEl", new SerializationOptions(JsonMode.Raw), null, this.GetDragEl ));
                list.Add("endDrag", new ConfigOption("endDrag", new SerializationOptions(JsonMode.Raw), null, this.EndDrag ));
                list.Add("onAvailable", new ConfigOption("onAvailable", new SerializationOptions(JsonMode.Raw), null, this.OnAvailable ));
                list.Add("onDrag", new ConfigOption("onDrag", new SerializationOptions(JsonMode.Raw), null, this.OnDrag ));
                list.Add("onDragDrop", new ConfigOption("onDragDrop", new SerializationOptions(JsonMode.Raw), null, this.OnDragDrop ));
                list.Add("onDragEnter", new ConfigOption("onDragEnter", new SerializationOptions(JsonMode.Raw), null, this.OnDragEnter ));
                list.Add("onDragOut", new ConfigOption("onDragOut", new SerializationOptions(JsonMode.Raw), null, this.OnDragOut ));
                list.Add("onDragOver", new ConfigOption("onDragOver", new SerializationOptions(JsonMode.Raw), null, this.OnDragOver ));
                list.Add("onInvalidDrop", new ConfigOption("onInvalidDrop", new SerializationOptions(JsonMode.Raw), null, this.OnInvalidDrop ));
                list.Add("onMouseDown", new ConfigOption("onMouseDown", new SerializationOptions(JsonMode.Raw), null, this.OnMouseDown ));
                list.Add("onMouseUp", new ConfigOption("onMouseUp", new SerializationOptions(JsonMode.Raw), null, this.OnMouseUp ));
                list.Add("startDrag", new ConfigOption("startDrag", new SerializationOptions(JsonMode.Raw), null, this.StartDrag ));
                list.Add("b4Drag", new ConfigOption("b4Drag", new SerializationOptions(JsonMode.Raw), null, this.B4Drag ));
                list.Add("b4DragDrop", new ConfigOption("b4DragDrop", new SerializationOptions(JsonMode.Raw), null, this.B4DragDrop ));
                list.Add("b4DragOut", new ConfigOption("b4DragOut", new SerializationOptions(JsonMode.Raw), null, this.B4DragOut ));
                list.Add("b4DragOver", new ConfigOption("b4DragOver", new SerializationOptions(JsonMode.Raw), null, this.B4DragOver ));
                list.Add("b4EndDrag", new ConfigOption("b4EndDrag", new SerializationOptions(JsonMode.Raw), null, this.B4EndDrag ));
                list.Add("b4MouseDown", new ConfigOption("b4MouseDown", new SerializationOptions(JsonMode.Raw), null, this.B4MouseDown ));
                list.Add("b4StartDrag", new ConfigOption("b4StartDrag", new SerializationOptions(JsonMode.Raw), null, this.B4StartDrag ));

                return list;
            }
        }
    }
}