/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
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
    public partial class Hidden
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Field.Builder<Hidden, Hidden.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Hidden()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Hidden component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Hidden.Config config) : base(new Hidden(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Hidden component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual Hidden.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as Hidden.Builder;
            }
             
 			/// <summary>
			/// The fields null value.
			/// </summary>
            public virtual Hidden.Builder EmptyValue(object emptyValue)
            {
                this.ToComponent().EmptyValue = emptyValue;
                return this as Hidden.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(FieldListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(FieldDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Hidden.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Hidden(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Hidden.Builder Hidden()
        {
            return this.Hidden(new Hidden());
        }

        /// <summary>
        /// 
        /// </summary>
        public Hidden.Builder Hidden(Hidden component)
        {
            return new Hidden.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Hidden.Builder Hidden(Hidden.Config config)
        {
            return new Hidden.Builder(new Hidden(config));
        }
    }
}