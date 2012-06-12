/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public interface IItems
    {
        /// <summary>
        /// 
        /// </summary>
        IList ItemsList { get; }

        /// <summary>
        /// 
        /// </summary>
        string DefaultType { get; set; }
    }
}