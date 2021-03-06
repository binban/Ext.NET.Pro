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
    public partial class LoadMask
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
                
                list.Add("showMask", new ConfigOption("showMask", null, false, this.ShowMask ));
                list.Add("msg", new ConfigOption("msg", null, "Loading...", this.Msg ));
                list.Add("msgCls", new ConfigOption("msgCls", null, "x-mask-loading", this.MsgCls ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("useMsg", new ConfigOption("useMsg", null, true, this.UseMsg ));

                return list;
            }
        }
    }
}