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
                list.Add("alignment", new ConfigOption("alignment", new SerializationOptions(JsonMode.ToString), null, this.Alignment ));
                list.Add("autoSizeProxy", new ConfigOption("autoSizeProxy", new SerializationOptions("autoSize", JsonMode.Raw), "false", this.AutoSizeProxy ));
                list.Add("zIndex", new ConfigOption("zIndex", null, 0, this.ZIndex ));
                list.Add("allowBlur", new ConfigOption("allowBlur", null, true, this.AllowBlur ));
                list.Add("cancelOnBlur", new ConfigOption("cancelOnBlur", null, false, this.CancelOnBlur ));
                list.Add("cancelOnEsc", new ConfigOption("cancelOnEsc", null, false, this.CancelOnEsc ));
                list.Add("completeOnEnter", new ConfigOption("completeOnEnter", null, false, this.CompleteOnEnter ));
                list.Add("hideEl", new ConfigOption("hideEl", null, true, this.HideEl ));
                list.Add("ignoreNoChange", new ConfigOption("ignoreNoChange", null, false, this.IgnoreNoChange ));
                list.Add("revertInvalid", new ConfigOption("revertInvalid", null, true, this.RevertInvalid ));
                list.Add("shadow", new ConfigOption("shadow", new SerializationOptions(typeof(ShadowJsonConverter)), ShadowMode.Frame, this.Shadow ));
                list.Add("swallowKeys", new ConfigOption("swallowKeys", null, true, this.SwallowKeys ));
                list.Add("updateEl", new ConfigOption("updateEl", null, false, this.UpdateEl ));
                list.Add("value", new ConfigOption("value", null, "", this.Value ));
                list.Add("field", new ConfigOption("field", new SerializationOptions("field", typeof(ItemCollectionJsonConverter)), null, this.Field ));
                list.Add("offsets", new ConfigOption("offsets", new SerializationOptions(JsonMode.AlwaysArray), null, this.Offsets ));
                list.Add("isSeparate", new ConfigOption("isSeparate", null, false, this.IsSeparate ));
                list.Add("targetProxy", new ConfigOption("targetProxy", new SerializationOptions("target", JsonMode.Raw), "", this.TargetProxy ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}