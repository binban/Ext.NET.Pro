/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ListViewDateColumn : ListViewColumn
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("xtype")]
		[Description("")]
        public string XType
        {
            get
            {
                return "lvdatecolumn";
            }
        }

        /// <summary>
        /// A formatting string as used by Date.format to format a Date for this Column (defaults to 'd').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. ListView")]
        [DefaultValue("d")]
        [Description("A formatting string as used by Date.format to format a Date for this Column (defaults to 'd').")]
        public virtual string Format
        {
            get
            {
                object obj = this.ViewState["Format"];
                return (obj == null) ? "d" : (string)obj;
            }
            set
            {
                this.ViewState["Format"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("format")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format);
            }
        }
    }
}