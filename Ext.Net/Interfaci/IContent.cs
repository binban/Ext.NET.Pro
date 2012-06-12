/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public interface IContent
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        ITemplate Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        HtmlGenericControl ContentContainer { get; }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        ControlCollection ContentControls { get; }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        string ContentEl { get; }
    }
}