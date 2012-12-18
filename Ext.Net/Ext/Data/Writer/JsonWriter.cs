/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// Writer that outputs model data in JSON format
    /// </summary>
    [Meta]
    public partial class JsonWriter : AbstractWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonWriter()
        {
        }

        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "json";
            }
        }

        /// <summary>
        /// The HTTP parameter name by which JSON encoded records will be passed to the server if the encode option is `true`.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The HTTP parameter name by which JSON encoded records will be passed to the server if the encode option is `true`.")]
        public virtual string Root
        {
            get
            {
                return this.State.Get<string>("Root", "");
            }
            set
            {
                this.State.Set("Root", value);
            }
        }

        /// <summary>
        /// Configure `true` to send record data (all record fields if writeAllFields is `true`) as a JSON encoded HTTP parameter named by the root configuration.
        /// The encode option should only be set to true when a root is defined, because the values will be
        /// sent as part of the request parameters as opposed to a raw post. The root will be the name of the parameter
        /// sent to the server.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Configure `true` to send record data (all record fields if writeAllFields is `true`) as a JSON encoded HTTP parameter named by the root configuration.")]
        public virtual bool Encode
        {
            get
            {
                return this.State.Get<bool>("Encode", false);
            }
            set
            {
                this.State.Set("Encode", value);
            }
        }

        /// <summary>
        /// False to ensure that records are always wrapped in an array, even if there is only
        /// one record being sent. When there is more than one record, they will always be encoded into an array.
        /// Defaults to true. Example:
        /// // with allowSingle: true
        /// "root": {
        ///     "first": "Mark",
        ///     "last": "Corrigan"
        /// }
        ///
        /// // with allowSingle: false
        /// "root": [{
        ///    "first": "Mark",
        ///    "last": "Corrigan"
        /// }]
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("False to ensure that records are always wrapped in an array, even if there is only one record being sent. When there is more than one record, they will always be encoded into an array.")]
        public virtual bool AllowSingle
        {
            get
            {
                return this.State.Get<bool>("AllowSingle", false);
            }
            set
            {
                this.State.Set("AllowSingle", value);
            }
        }
    }
}
