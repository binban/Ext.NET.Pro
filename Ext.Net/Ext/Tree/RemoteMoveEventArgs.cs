/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class RemoteMoveEventArgs : RemoteActionEventArgs
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RemoteMoveEventArgs(string serviceParams, ParameterCollection extraParams) : base(serviceParams, extraParams) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DropPoint Point
        {
            get
            {
                string point = this.GetValue<string>("point");
                return (DropPoint)Enum.Parse(typeof(DropPoint), point, true);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string TargetNodeID
        {
            get
            {
                return this.GetValue<string>("targetId");
            }
        }
    }
}