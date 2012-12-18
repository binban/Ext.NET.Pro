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
    public partial class Resizer
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
                
                list.Add("constrainToElement", new ConfigOption("constrainToElement", new SerializationOptions("constrainTo"), "", this.ConstrainToElement ));
                list.Add("constrainToRegionProxy", new ConfigOption("constrainToRegionProxy", new SerializationOptions("constrainTo", JsonMode.Raw), null, this.ConstrainToRegionProxy ));
                list.Add("dynamic", new ConfigOption("dynamic", null, null, this.Dynamic ));
                list.Add("handlesSummary", new ConfigOption("handlesSummary", new SerializationOptions("handles"), "", this.HandlesSummary ));
                list.Add("handlesProxy", new ConfigOption("handlesProxy", new SerializationOptions("handles"), "", this.HandlesProxy ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("heightIncrement", new ConfigOption("heightIncrement", null, 0, this.HeightIncrement ));
                list.Add("maxHeight", new ConfigOption("maxHeight", null, 10000, this.MaxHeight ));
                list.Add("maxWidth", new ConfigOption("maxWidth", null, 10000, this.MaxWidth ));
                list.Add("minHeight", new ConfigOption("minHeight", null, 20, this.MinHeight ));
                list.Add("minWidth", new ConfigOption("minWidth", null, 20, this.MinWidth ));
                list.Add("pinned", new ConfigOption("pinned", null, false, this.Pinned ));
                list.Add("preserveRatio", new ConfigOption("preserveRatio", null, false, this.PreserveRatio ));
                list.Add("targetProxy", new ConfigOption("targetProxy", new SerializationOptions("target", JsonMode.Raw), "", this.TargetProxy ));
                list.Add("transparent", new ConfigOption("transparent", null, false, this.Transparent ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("widthIncrement", new ConfigOption("widthIncrement", new SerializationOptions(JsonMode.Raw), 0, this.WidthIncrement ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}