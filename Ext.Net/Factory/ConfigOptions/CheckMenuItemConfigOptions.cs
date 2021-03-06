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
    public partial class CheckMenuItem
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
                
                list.Add("checkChangeDisabled", new ConfigOption("checkChangeDisabled", null, false, this.CheckChangeDisabled ));
                list.Add("checked", new ConfigOption("checked", null, false, this.Checked ));
                list.Add("checkedCls", new ConfigOption("checkedCls", null, "", this.CheckedCls ));
                list.Add("group", new ConfigOption("group", null, "", this.Group ));
                list.Add("groupCls", new ConfigOption("groupCls", null, "", this.GroupCls ));
                list.Add("hideOnClick", new ConfigOption("hideOnClick", null, false, this.HideOnClick ));
                list.Add("uncheckedCls", new ConfigOption("uncheckedCls", null, "", this.UncheckedCls ));
                list.Add("checkHandler", new ConfigOption("checkHandler", new SerializationOptions(typeof(FunctionJsonConverter)), "", this.CheckHandler ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}