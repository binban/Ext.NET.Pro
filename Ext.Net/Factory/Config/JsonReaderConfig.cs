/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
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
    public partial class JsonReader
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public JsonReader(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit JsonReader.Config Conversion to JsonReader
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator JsonReader(JsonReader.Config config)
        {
            return new JsonReader(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractReader.Config 
        { 
			/*  Implicit JsonReader.Config Conversion to JsonReader.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator JsonReader.Builder(JsonReader.Config config)
			{
				return new JsonReader.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string record = "";

			/// <summary>
			/// The optional location within the JSON response that the record data itself can be found at. See the JsonReader intro docs for more details. This is not often needed and defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string Record 
			{ 
				get
				{
					return this.record;
				}
				set
				{
					this.record = value;
				}
			}

			private bool useSimpleAccessors = false;

			/// <summary>
			/// True to ensure that field names/mappings are treated as literals when reading values. Defalts to false. For example, by default, using the mapping \"foo.bar.baz\" will try and read a property foo from the root, then a property bar from foo, then a property baz from bar. Setting the simple accessors to true will read the property with the name \"foo.bar.baz\" direct from the root object.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseSimpleAccessors 
			{ 
				get
				{
					return this.useSimpleAccessors;
				}
				set
				{
					this.useSimpleAccessors = value;
				}
			}

        }
    }
}