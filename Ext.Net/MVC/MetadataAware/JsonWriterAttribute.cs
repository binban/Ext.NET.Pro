/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;

namespace Ext.Net.MVC
{
    public partial class JsonWriterAttribute : AbstractWriterAttribute
    {
        /// <summary>
        /// The key under which the records in this Writer will be placed. Defaults to undefined.
        /// Example generated request, using root: 'records':
        /// {'records': [{name: 'my record'}, {name: 'another record'}]}
        /// </summary>
        [DefaultValue(null)]
        public virtual string Root
        {
            get;
            set;
        }

        /// <summary>
        /// True to use Ext.encode() on the data before sending. Defaults to false.
        /// The encode option should only be set to true when a root is defined, because the values will be
        /// sent as part of the request parameters as opposed to a raw post. The root will be the name of the parameter
        /// sent to the server.
        /// </summary>
        [DefaultValue(false)]
        public virtual bool Encode
        {
            get;
            set;
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
        [DefaultValue(false)]
        public virtual bool AllowSingle
        {
            get;
            set;
        }
        
        protected override AbstractWriter CreateWriter()
        {
            return new JsonWriter();
        }
    }
}