/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    public partial class Chart
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
                
                list.Add("axes", new ConfigOption("axes", new SerializationOptions(JsonMode.AlwaysArray), null, this.Axes ));
                list.Add("insetPadding", new ConfigOption("insetPadding", null, 10, this.InsetPadding ));
                list.Add("animate", new ConfigOption("animate", null, false, this.Animate ));
                list.Add("animateConfig", new ConfigOption("animateConfig", new SerializationOptions("animate", JsonMode.Object), null, this.AnimateConfig ));
                list.Add("legend", new ConfigOption("legend", null, false, this.Legend ));
                list.Add("legendConfig", new ConfigOption("legendConfig", new SerializationOptions("legend", JsonMode.ObjectAllowEmpty), null, this.LegendConfig ));
                list.Add("series", new ConfigOption("series", new SerializationOptions(JsonMode.AlwaysArray), null, this.Series ));
                list.Add("theme", new ConfigOption("theme", null, "", this.Theme ));
                list.Add("standardTheme", new ConfigOption("standardTheme", new SerializationOptions("theme", JsonMode.ToString), StandardChartTheme.Base, this.StandardTheme ));
                list.Add("maskProxy", new ConfigOption("maskProxy", new SerializationOptions("mask", JsonMode.Raw), "", this.MaskProxy ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("store", new ConfigOption("store", new SerializationOptions("store>Primary"), null, this.Store ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}