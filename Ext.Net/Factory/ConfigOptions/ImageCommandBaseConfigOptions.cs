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
    public abstract partial class ImageCommandBase
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
                
                list.Add("commandName", new ConfigOption("commandName", new SerializationOptions("command"), "", this.CommandName ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("hidden", new ConfigOption("hidden", null, false, this.Hidden ));
                list.Add("disabled", new ConfigOption("disabled", null, false, this.Disabled ));
                list.Add("iconCls", new ConfigOption("iconCls", null, "", this.IconCls ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("style", new ConfigOption("style", null, "", this.Style ));
                list.Add("toolTip", new ConfigOption("toolTip", new SerializationOptions("tooltip", JsonMode.Object), null, this.ToolTip ));
                list.Add("hideMode", new ConfigOption("hideMode", new SerializationOptions(JsonMode.ToLower), HideMode.Display, this.HideMode ));

                return list;
            }
        }
    }
}