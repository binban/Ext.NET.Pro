/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractWriter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BaseItem.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string nameProperty = "";

			/// <summary>
			/// This property is used to read the key for each value that will be sent to the server.
			/// </summary>
			[DefaultValue("")]
			public virtual string NameProperty 
			{ 
				get
				{
					return this.nameProperty;
				}
				set
				{
					this.nameProperty = value;
				}
			}

			private bool writeAllFields = true;

			/// <summary>
			/// True to write all fields from the record to the server. If set to false it will only send the fields that were modified. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool WriteAllFields 
			{ 
				get
				{
					return this.writeAllFields;
				}
				set
				{
					this.writeAllFields = value;
				}
			}
        
			private JFunction getRecordData = null;

			/// <summary>
			/// Formats the data for each record before sending it to the server. This method should be overridden to format the data in a way that differs from the default.
			/// </summary>
			public JFunction GetRecordData
			{
				get
				{
					if (this.getRecordData == null)
					{
						this.getRecordData = new JFunction();
					}
			
					return this.getRecordData;
				}
			}
			        
			private JFunction filterRecord = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction FilterRecord
			{
				get
				{
					if (this.filterRecord == null)
					{
						this.filterRecord = new JFunction();
					}
			
					return this.filterRecord;
				}
			}
			        
			private JFunction filterField = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction FilterField
			{
				get
				{
					if (this.filterField == null)
					{
						this.filterField = new JFunction();
					}
			
					return this.filterField;
				}
			}
			        
			private JFunction prepare = null;

			/// <summary>
			/// 
			/// </summary>
			public JFunction Prepare
			{
				get
				{
					if (this.prepare == null)
					{
						this.prepare = new JFunction();
					}
			
					return this.prepare;
				}
			}
			
			private bool excludeId = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ExcludeId 
			{ 
				get
				{
					return this.excludeId;
				}
				set
				{
					this.excludeId = value;
				}
			}

			private bool skipIdForPhantomRecords = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SkipIdForPhantomRecords 
			{ 
				get
				{
					return this.skipIdForPhantomRecords;
				}
				set
				{
					this.skipIdForPhantomRecords = value;
				}
			}

			private bool skipPhantomId = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SkipPhantomId 
			{ 
				get
				{
					return this.skipPhantomId;
				}
				set
				{
					this.skipPhantomId = value;
				}
			}

			private bool htmlEncode = false;

			/// <summary>
			/// Configure `true` to encode html in record data before sending
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HtmlEncode 
			{ 
				get
				{
					return this.htmlEncode;
				}
				set
				{
					this.htmlEncode = value;
				}
			}

			private string dateFormat = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DateFormat 
			{ 
				get
				{
					return this.dateFormat;
				}
				set
				{
					this.dateFormat = value;
				}
			}

        }
    }
}