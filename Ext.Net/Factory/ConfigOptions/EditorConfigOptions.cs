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
    public partial class Editor
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
                
                list.Add("activateEvent", new ConfigOption("activateEvent", new SerializationOptions(JsonMode.ToLower), "click", this.ActivateEvent ));
                list.Add("alignment", new ConfigOption("alignment", null, "c-c?", this.Alignment ));
                list.Add("alignmentConfig", new ConfigOption("alignmentConfig", new SerializationOptions("alignment", JsonMode.ToString), null, this.AlignmentConfig ));
                list.Add("autoSize", new ConfigOption("autoSize", null, false, this.AutoSize ));
                list.Add("autoSizeConfig", new ConfigOption("autoSizeConfig", new SerializationOptions("autoSize", JsonMode.Object), null, this.AutoSizeConfig ));
                list.Add("allowBlur", new ConfigOption("allowBlur", null, true, this.AllowBlur ));
                list.Add("cancelOnBlur", new ConfigOption("cancelOnBlur", null, false, this.CancelOnBlur ));
                list.Add("cancelOnEsc", new ConfigOption("cancelOnEsc", null, true, this.CancelOnEsc ));
                list.Add("completeOnEnter", new ConfigOption("completeOnEnter", null, true, this.CompleteOnEnter ));
                list.Add("constrain", new ConfigOption("constrain", null, false, this.Constrain ));
                list.Add("hideEl", new ConfigOption("hideEl", null, true, this.HideEl ));
                list.Add("field", new ConfigOption("field", new SerializationOptions("field", typeof(SingleItemCollectionJsonConverter)), null, this.Field ));
                list.Add("fieldDefault", new ConfigOption("fieldDefault", new SerializationOptions("field", JsonMode.Raw), "", this.FieldDefault ));
                list.Add("ignoreNoChange", new ConfigOption("ignoreNoChange", null, false, this.IgnoreNoChange ));
                list.Add("offsets", new ConfigOption("offsets", new SerializationOptions(JsonMode.AlwaysArray), null, this.Offsets ));
                list.Add("parentElement", new ConfigOption("parentElement", new SerializationOptions("parentEl"), "", this.ParentElement ));
                list.Add("revertInvalid", new ConfigOption("revertInvalid", null, true, this.RevertInvalid ));
                list.Add("shadowMode", new ConfigOption("shadowMode", new SerializationOptions("shadow", typeof(ShadowJsonConverter)), ShadowMode.Frame, this.ShadowMode ));
                list.Add("swallowKeys", new ConfigOption("swallowKeys", null, true, this.SwallowKeys ));
                list.Add("updateEl", new ConfigOption("updateEl", null, false, this.UpdateEl ));
                list.Add("value", new ConfigOption("value", null, "", this.Value ));
                list.Add("isSeparate", new ConfigOption("isSeparate", null, false, this.IsSeparate ));
                list.Add("targetProxy", new ConfigOption("targetProxy", new SerializationOptions("target", JsonMode.Raw), "", this.TargetProxy ));
                list.Add("useHtml", new ConfigOption("useHtml", null, false, this.UseHtml ));
                list.Add("htmlEncode", new ConfigOption("htmlEncode", null, false, this.HtmlEncode ));
                list.Add("htmlDecode", new ConfigOption("htmlDecode", null, false, this.HtmlDecode ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}