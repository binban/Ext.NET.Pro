/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Collections.Generic;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class Paging<T>
    {
        private List<T> data;
        private int totalRecords;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Paging() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Paging(IEnumerable<T> data, int totalRecords)
        {
            this.data = new List<T>(data);
            this.totalRecords = totalRecords;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int TotalRecords
        {
            get { return totalRecords; }
            set { totalRecords = value; }
        }
    }
}