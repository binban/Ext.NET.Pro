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
    public partial class ComponentColumnDirectEvents
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
                
                list.Add("pin", new ConfigOption("pin", new SerializationOptions("pin", typeof(DirectEventJsonConverter)), null, this.Pin ));
                list.Add("unpin", new ConfigOption("unpin", new SerializationOptions("unpin", typeof(DirectEventJsonConverter)), null, this.Unpin ));
                list.Add("bind", new ConfigOption("bind", new SerializationOptions("bind", typeof(DirectEventJsonConverter)), null, this.Bind ));
                list.Add("unbind", new ConfigOption("unbind", new SerializationOptions("unbind", typeof(DirectEventJsonConverter)), null, this.Unbind ));
                list.Add("validateEdit", new ConfigOption("validateEdit", new SerializationOptions("validateedit", typeof(DirectEventJsonConverter)), null, this.ValidateEdit ));
                list.Add("edit", new ConfigOption("edit", new SerializationOptions("edit", typeof(DirectEventJsonConverter)), null, this.Edit ));

                return list;
            }
        }
    }
}