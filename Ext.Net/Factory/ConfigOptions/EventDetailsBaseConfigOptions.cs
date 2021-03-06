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
    public abstract partial class EventDetailsBase
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
                
                list.Add("title", new ConfigOption("title", null, "Event Form", this.Title ));
                list.Add("titleTextAdd", new ConfigOption("titleTextAdd", null, "Add Event", this.TitleTextAdd ));
                list.Add("titleTextEdit", new ConfigOption("titleTextEdit", null, "Edit Event", this.TitleTextEdit ));
                list.Add("buttonAlign", new ConfigOption("buttonAlign", new SerializationOptions(JsonMode.ToLower), Alignment.Center, this.ButtonAlign ));
                list.Add("calendarStoreID", new ConfigOption("calendarStoreID", new SerializationOptions("calendarStore", JsonMode.ToClientID), "", this.CalendarStoreID ));

                return list;
            }
        }
    }
}