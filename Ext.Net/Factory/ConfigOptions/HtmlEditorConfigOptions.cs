/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
    public partial class HtmlEditor
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
                
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));
                list.Add("afterIFrameTpl", new ConfigOption("afterIFrameTpl", new SerializationOptions("afterIFrameTpl", typeof(LazyControlJsonConverter)), null, this.AfterIFrameTpl ));
                list.Add("afterTextAreaTpl", new ConfigOption("afterTextAreaTpl", new SerializationOptions("afterTextAreaTpl", typeof(LazyControlJsonConverter)), null, this.AfterTextAreaTpl ));
                list.Add("beforeIFrameTpl", new ConfigOption("beforeIFrameTpl", new SerializationOptions("beforeIFrameTpl", typeof(LazyControlJsonConverter)), null, this.BeforeIFrameTpl ));
                list.Add("beforeTextAreaTpl", new ConfigOption("beforeTextAreaTpl", new SerializationOptions("beforeTextAreaTpl", typeof(LazyControlJsonConverter)), null, this.BeforeTextAreaTpl ));
                list.Add("createLinkText", new ConfigOption("createLinkText", null, "", this.CreateLinkText ));
                list.Add("defaultFont", new ConfigOption("defaultFont", null, "", this.DefaultFont ));
                list.Add("defaultLinkValue", new ConfigOption("defaultLinkValue", null, "http://", this.DefaultLinkValue ));
                list.Add("defaultValue", new ConfigOption("defaultValue", null, "", this.DefaultValue ));
                list.Add("enableAlignments", new ConfigOption("enableAlignments", null, true, this.EnableAlignments ));
                list.Add("enableColors", new ConfigOption("enableColors", null, true, this.EnableColors ));
                list.Add("enableFont", new ConfigOption("enableFont", null, true, this.EnableFont ));
                list.Add("enableFontSize", new ConfigOption("enableFontSize", null, true, this.EnableFontSize ));
                list.Add("enableFormat", new ConfigOption("enableFormat", null, true, this.EnableFormat ));
                list.Add("enableLinks", new ConfigOption("enableLinks", null, true, this.EnableLinks ));
                list.Add("enableLists", new ConfigOption("enableLists", null, true, this.EnableLists ));
                list.Add("enableSourceEdit", new ConfigOption("enableSourceEdit", null, true, this.EnableSourceEdit ));
                list.Add("escapeValue", new ConfigOption("escapeValue", null, true, this.EscapeValue ));
                list.Add("fontFamilies", new ConfigOption("fontFamilies", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.FontFamilies ));
                list.Add("buttonTips", new ConfigOption("buttonTips", new SerializationOptions(JsonMode.Object), null, this.ButtonTips ));
                list.Add("iframeAttrTpl", new ConfigOption("iframeAttrTpl", new SerializationOptions("iframeAttrTpl", typeof(LazyControlJsonConverter)), null, this.IframeAttrTpl ));

                return list;
            }
        }
    }
}