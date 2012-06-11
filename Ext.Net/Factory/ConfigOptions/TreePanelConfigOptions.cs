/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
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
    public partial class TreePanel
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
                
                list.Add("remoteRenameUrl", new ConfigOption("remoteRenameUrl", new SerializationOptions("raRenameUrl", JsonMode.Url), "", this.RemoteRenameUrl ));
                list.Add("remoteRemoveUrl", new ConfigOption("remoteRemoveUrl", new SerializationOptions("raRemoveUrl", JsonMode.Url), "", this.RemoteRemoveUrl ));
                list.Add("remoteAppendUrl", new ConfigOption("remoteAppendUrl", new SerializationOptions("raAppendUrl", JsonMode.Url), "", this.RemoteAppendUrl ));
                list.Add("remoteInsertUrl", new ConfigOption("remoteInsertUrl", new SerializationOptions("raInsertUrl", JsonMode.Url), "", this.RemoteInsertUrl ));
                list.Add("remoteMoveUrl", new ConfigOption("remoteMoveUrl", new SerializationOptions("raMoveUrl", JsonMode.Url), "", this.RemoteMoveUrl ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}