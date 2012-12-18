/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TJsonReader, TBuilder> : AbstractReader.Builder<TJsonReader, TBuilder>
            where TJsonReader : JsonReader
            where TBuilder : Builder<TJsonReader, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TJsonReader component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The optional location within the JSON response that the record data itself can be found at. See the JsonReader intro docs for more details. This is not often needed and defaults to undefined.
			/// </summary>
            public virtual TBuilder Record(string record)
            {
                this.ToComponent().Record = record;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ensure that field names/mappings are treated as literals when reading values. Defalts to false. For example, by default, using the mapping \"foo.bar.baz\" will try and read a property foo from the root, then a property bar from foo, then a property baz from bar. Setting the simple accessors to true will read the property with the name \"foo.bar.baz\" direct from the root object.
			/// </summary>
            public virtual TBuilder UseSimpleAccessors(bool useSimpleAccessors)
            {
                this.ToComponent().UseSimpleAccessors = useSimpleAccessors;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : JsonReader.Builder<JsonReader, JsonReader.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new JsonReader()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonReader component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(JsonReader.Config config) : base(new JsonReader(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(JsonReader component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.JsonReader(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder JsonReader()
        {
#if MVC
			return this.JsonReader(new JsonReader { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.JsonReader(new JsonReader());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder JsonReader(JsonReader component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new JsonReader.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public JsonReader.Builder JsonReader(JsonReader.Config config)
        {
#if MVC
			return new JsonReader.Builder(new JsonReader(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new JsonReader.Builder(new JsonReader(config));
#endif			
        }
    }
}