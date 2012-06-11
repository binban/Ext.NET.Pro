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
    public partial class HtmlEditorListeners
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
                
                list.Add("activate", new ConfigOption("activate", new SerializationOptions("activate", typeof(ListenerJsonConverter)), null, this.Activate ));
                list.Add("beforePush", new ConfigOption("beforePush", new SerializationOptions("beforepush", typeof(ListenerJsonConverter)), null, this.BeforePush ));
                list.Add("beforeSync", new ConfigOption("beforeSync", new SerializationOptions("beforesync", typeof(ListenerJsonConverter)), null, this.BeforeSync ));
                list.Add("editModeChange", new ConfigOption("editModeChange", new SerializationOptions("editmodechange", typeof(ListenerJsonConverter)), null, this.EditModeChange ));
                list.Add("initialize", new ConfigOption("initialize", new SerializationOptions("initialize", typeof(ListenerJsonConverter)), null, this.Initialize ));
                list.Add("push", new ConfigOption("push", new SerializationOptions("push", typeof(ListenerJsonConverter)), null, this.Push ));
                list.Add("sync", new ConfigOption("sync", new SerializationOptions("sync", typeof(ListenerJsonConverter)), null, this.Sync ));

                return list;
            }
        }
    }
}