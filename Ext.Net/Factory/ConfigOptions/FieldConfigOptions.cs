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
                
                list.Add("activeError", new ConfigOption("activeError", null, null, this.ActiveError ));
                list.Add("activeErrorsTpl", new ConfigOption("activeErrorsTpl", new SerializationOptions("activeErrorsTpl", typeof(LazyControlJsonConverter)), null, this.ActiveErrorsTpl ));
                list.Add("autoFitErrors", new ConfigOption("autoFitErrors", null, true, this.AutoFitErrors ));
                list.Add("baseBodyCls", new ConfigOption("baseBodyCls", null, "x-form-item-body", this.BaseBodyCls ));
                list.Add("checkChangeBuffer", new ConfigOption("checkChangeBuffer", null, 50, this.CheckChangeBuffer ));
                list.Add("checkChangeEvents", new ConfigOption("checkChangeEvents", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.CheckChangeEvents ));
                list.Add("clearCls", new ConfigOption("clearCls", null, "x-clear", this.ClearCls ));
                list.Add("dirtyCls", new ConfigOption("dirtyCls", null, "x-form-dirty", this.DirtyCls ));
                list.Add("errorMsgCls", new ConfigOption("errorMsgCls", null, "x-form-error-msg", this.ErrorMsgCls ));
                list.Add("fieldBodyCls", new ConfigOption("fieldBodyCls", null, "", this.FieldBodyCls ));
                list.Add("fieldCls", new ConfigOption("fieldCls", null, "", this.FieldCls ));
                list.Add("fieldLabel", new ConfigOption("fieldLabel", null, "", this.FieldLabel ));
                list.Add("fieldStyle", new ConfigOption("fieldStyle", null, "", this.FieldStyle ));
                list.Add("fieldSubTpl", new ConfigOption("fieldSubTpl", new SerializationOptions("fieldSubTpl", typeof(LazyControlJsonConverter)), null, this.FieldSubTpl ));
                list.Add("focusCls", new ConfigOption("focusCls", null, "x-form-focus", this.FocusCls ));
                list.Add("formItemCls", new ConfigOption("formItemCls", null, "x-form-item", this.FormItemCls ));
                list.Add("hideEmptyLabel", new ConfigOption("hideEmptyLabel", null, true, this.HideEmptyLabel ));
                list.Add("hideLabel", new ConfigOption("hideLabel", null, false, this.HideLabel ));
                list.Add("inputID", new ConfigOption("inputID", new SerializationOptions("inputId"), "", this.InputID ));
                list.Add("inputType", new ConfigOption("inputType", new SerializationOptions(JsonMode.ToLower), InputType.Text, this.InputType ));
                list.Add("inputWidth", new ConfigOption("inputWidth", null, 100, this.InputWidth ));
                list.Add("invalidCls", new ConfigOption("invalidCls", null, "x-form-invalid", this.InvalidCls ));
                list.Add("invalidText", new ConfigOption("invalidText", null, "", this.InvalidText ));
                list.Add("labelAlign", new ConfigOption("labelAlign", new SerializationOptions(JsonMode.ToLower), LabelAlign.Left, this.LabelAlign ));
                list.Add("labelCls", new ConfigOption("labelCls", new SerializationOptions("labelClsExtra"), "", this.LabelCls ));
                list.Add("labelPad", new ConfigOption("labelPad", null, 5, this.LabelPad ));
                list.Add("labelSeparator", new ConfigOption("labelSeparator", null, ":", this.LabelSeparator ));
                list.Add("labelStyle", new ConfigOption("labelStyle", null, "", this.LabelStyle ));
                list.Add("labelWidth", new ConfigOption("labelWidth", null, 100, this.LabelWidth ));
                list.Add("msgTarget", new ConfigOption("msgTarget", new SerializationOptions(JsonMode.ToLower), MessageTarget.Qtip, this.MsgTarget ));
                list.Add("msgTargetElement", new ConfigOption("msgTargetElement", new SerializationOptions("msgTarget"), "", this.MsgTargetElement ));
                list.Add("name", new ConfigOption("name", null, "", this.Name ));
                list.Add("preventMark", new ConfigOption("preventMark", null, false, this.PreventMark ));
                list.Add("readOnly", new ConfigOption("readOnly", null, false, this.ReadOnly ));
                list.Add("readOnlyCls", new ConfigOption("readOnlyCls", null, "", this.ReadOnlyCls ));
                list.Add("submitValue", new ConfigOption("submitValue", null, true, this.SubmitValue ));
                list.Add("tabIndex", new ConfigOption("tabIndex", null, (short)0, this.TabIndex ));
                list.Add("validateOnBlur", new ConfigOption("validateOnBlur", null, true, this.ValidateOnBlur ));
                list.Add("validateOnChange", new ConfigOption("validateOnChange", null, true, this.ValidateOnChange ));
                list.Add("inputAttrTpl", new ConfigOption("inputAttrTpl", new SerializationOptions("inputAttrTpl", typeof(LazyControlJsonConverter)), null, this.InputAttrTpl ));
                list.Add("afterLabelTextTpl", new ConfigOption("afterLabelTextTpl", new SerializationOptions("afterLabelTextTpl", typeof(LazyControlJsonConverter)), null, this.AfterLabelTextTpl ));
                list.Add("afterLabelTpl", new ConfigOption("afterLabelTpl", new SerializationOptions("afterLabelTpl", typeof(LazyControlJsonConverter)), null, this.AfterLabelTpl ));
                list.Add("afterSubTpl", new ConfigOption("afterSubTpl", new SerializationOptions("afterSubTpl", typeof(LazyControlJsonConverter)), null, this.AfterSubTpl ));
                list.Add("beforeLabelTextTpl", new ConfigOption("beforeLabelTextTpl", new SerializationOptions("beforeLabelTextTpl", typeof(LazyControlJsonConverter)), null, this.BeforeLabelTextTpl ));
                list.Add("beforeLabelTpl", new ConfigOption("beforeLabelTpl", new SerializationOptions("beforeLabelTpl", typeof(LazyControlJsonConverter)), null, this.BeforeLabelTpl ));
                list.Add("beforeSubTpl", new ConfigOption("beforeSubTpl", new SerializationOptions("beforeSubTpl", typeof(LazyControlJsonConverter)), null, this.BeforeSubTpl ));
                list.Add("labelAttrTpl", new ConfigOption("labelAttrTpl", new SerializationOptions("labelAttrTpl", typeof(LazyControlJsonConverter)), null, this.LabelAttrTpl ));
                list.Add("labelClsExtra", new ConfigOption("labelClsExtra", null, "", this.LabelClsExtra ));
                list.Add("preserveIndicatorIcon", new ConfigOption("preserveIndicatorIcon", null, false, this.PreserveIndicatorIcon ));
                list.Add("indicatorText", new ConfigOption("indicatorText", null, "", this.IndicatorText ));
                list.Add("indicatorCls", new ConfigOption("indicatorCls", null, "", this.IndicatorCls ));
                list.Add("indicatorIconCls", new ConfigOption("indicatorIconCls", null, "", this.IndicatorIconCls ));
                list.Add("indicatorIconClsProxy", new ConfigOption("indicatorIconClsProxy", new SerializationOptions("indicatorIconCls"), "", this.IndicatorIconClsProxy ));
                list.Add("indicatorTip", new ConfigOption("indicatorTip", null, "", this.IndicatorTip ));
                list.Add("note", new ConfigOption("note", null, "", this.Note ));
                list.Add("noteCls", new ConfigOption("noteCls", null, "", this.NoteCls ));
                list.Add("noteAlign", new ConfigOption("noteAlign", new SerializationOptions(JsonMode.ToLower), NoteAlign.Down, this.NoteAlign ));
                list.Add("noteEncode", new ConfigOption("noteEncode", null, false, this.NoteEncode ));
                list.Add("getFieldLabel", new ConfigOption("getFieldLabel", new SerializationOptions(JsonMode.Raw), null, this.GetFieldLabel ));
                list.Add("getModelData", new ConfigOption("getModelData", new SerializationOptions(JsonMode.Raw), null, this.GetModelData ));
                list.Add("getSubmitData", new ConfigOption("getSubmitData", new SerializationOptions(JsonMode.Raw), null, this.GetSubmitData ));
                list.Add("getErrors", new ConfigOption("getErrors", new SerializationOptions(JsonMode.Raw), null, this.GetErrors ));
                list.Add("valueProxy", new ConfigOption("valueProxy", new SerializationOptions("value"), null, this.ValueProxy ));
                list.Add("rawValue", new ConfigOption("rawValue", null, null, this.RawValue ));
                list.Add("validator", new ConfigOption("validator", new SerializationOptions(JsonMode.Raw), null, this.Validator ));
                list.Add("validatorText", new ConfigOption("validatorText", null, "", this.ValidatorText ));
                list.Add("standardVtype", new ConfigOption("standardVtype", new SerializationOptions("vtype", JsonMode.ToLower), ValidationType.None, this.StandardVtype ));
                list.Add("vtype", new ConfigOption("vtype", null, "", this.Vtype ));
                list.Add("vtypeText", new ConfigOption("vtypeText", null, "", this.VtypeText ));
                list.Add("vTypeParams", new ConfigOption("vTypeParams", new SerializationOptions("vtypeParams", JsonMode.ArrayToObject), null, this.VTypeParams ));
                list.Add("isRemoteValidation", new ConfigOption("isRemoteValidation", null, false, this.IsRemoteValidation ));
                list.Add("remoteValidation", new ConfigOption("remoteValidation", new SerializationOptions("remoteValidationOptions", JsonMode.Object), null, this.RemoteValidation ));

                return list;
            }
        }
    }
}