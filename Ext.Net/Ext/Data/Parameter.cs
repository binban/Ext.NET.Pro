/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class Parameter : BaseParameter
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Parameter() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Parameter(string name, string value) : base(name, value) { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Parameter(string name, string value, ParameterMode mode) : base(name, value, mode) { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Parameter(string name, string value, bool encode) : base(name, value, encode) { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Parameter(string name, string value, ParameterMode mode, bool encode) : base(name, value, mode, encode) { }
    }
}