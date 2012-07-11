/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public abstract partial class Field
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
                
                list.Add("dataIndex", new ConfigOption("dataIndex", null, "", this.DataIndex ));
                list.Add("name", new ConfigOption("name", null, "", this.Name ));
                list.Add("autoCreate", new ConfigOption("autoCreate", new SerializationOptions(JsonMode.Raw), "", this.AutoCreate ));
                list.Add("fieldClass", new ConfigOption("fieldClass", null, "", this.FieldClass ));
                list.Add("focusClass", new ConfigOption("focusClass", null, "", this.FocusClass ));
                list.Add("hideWithLabel", new ConfigOption("hideWithLabel", null, true, this.HideWithLabel ));
                list.Add("invalidClass", new ConfigOption("invalidClass", null, "", this.InvalidClass ));
                list.Add("invalidText", new ConfigOption("invalidText", null, "", this.InvalidText ));
                list.Add("msgFx", new ConfigOption("msgFx", null, "normal", this.MsgFx ));
                list.Add("msgTarget", new ConfigOption("msgTarget", new SerializationOptions(JsonMode.ToLower), MessageTarget.Qtip, this.MsgTarget ));
                list.Add("readOnly", new ConfigOption("readOnly", null, false, this.ReadOnly ));
                list.Add("preventMark", new ConfigOption("preventMark", null, false, this.PreventMark ));
                list.Add("tabIndex", new ConfigOption("tabIndex", null, (short)0, this.TabIndex ));
                list.Add("validateOnBlur", new ConfigOption("validateOnBlur", null, true, this.ValidateOnBlur ));
                list.Add("validationDelay", new ConfigOption("validationDelay", null, 250, this.ValidationDelay ));
                list.Add("validationEvent", new ConfigOption("validationEvent", null, "", this.ValidationEvent ));
                list.Add("validateOnEvent", new ConfigOption("validateOnEvent", new SerializationOptions("validationEvent"), true, this.ValidateOnEvent ));
                list.Add("indicatorText", new ConfigOption("indicatorText", null, "", this.IndicatorText ));
                list.Add("indicatorCls", new ConfigOption("indicatorCls", null, "", this.IndicatorCls ));
                list.Add("indicatorIconCls", new ConfigOption("indicatorIconCls", null, "", this.IndicatorIconCls ));
                list.Add("indicatorIconClsProxy", new ConfigOption("indicatorIconClsProxy", new SerializationOptions("indicatorIconCls"), "", this.IndicatorIconClsProxy ));
                list.Add("indicatorTip", new ConfigOption("indicatorTip", null, "", this.IndicatorTip ));
                list.Add("note", new ConfigOption("note", null, "", this.Note ));
                list.Add("noteCls", new ConfigOption("noteCls", null, "", this.NoteCls ));
                list.Add("noteAlign", new ConfigOption("noteAlign", new SerializationOptions(JsonMode.ToLower), NoteAlign.Down, this.NoteAlign ));
                list.Add("noteEncode", new ConfigOption("noteEncode", null, false, this.NoteEncode ));
                list.Add("submitValue", new ConfigOption("submitValue", null, true, this.SubmitValue ));
                list.Add("valueProxy", new ConfigOption("valueProxy", new SerializationOptions("value"), null, this.ValueProxy ));
                list.Add("rawValue", new ConfigOption("rawValue", null, null, this.RawValue ));
                list.Add("isRemoteValidation", new ConfigOption("isRemoteValidation", null, false, this.IsRemoteValidation ));
                list.Add("remoteValidation", new ConfigOption("remoteValidation", new SerializationOptions("remoteValidationOptions", JsonMode.Object), null, this.RemoteValidation ));
                list.Add("getErrors", new ConfigOption("getErrors", new SerializationOptions(JsonMode.Raw), null, this.GetErrors ));

                return list;
            }
        }
    }
}