/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
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
    public partial class DisplayField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Field.Builder<DisplayField, DisplayField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DisplayField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DisplayField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DisplayField.Config config) : base(new DisplayField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DisplayField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The default CSS class for the field (defaults to 'x-form-display-field')
			/// </summary>
            public virtual DisplayField.Builder FieldClass(string fieldClass)
            {
                this.ToComponent().FieldClass = fieldClass;
                return this as DisplayField.Builder;
            }
             
 			/// <summary>
			/// false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.
			/// </summary>
            public virtual DisplayField.Builder HtmlEncode(bool htmlEncode)
            {
                this.ToComponent().HtmlEncode = htmlEncode;
                return this as DisplayField.Builder;
            }
             
 			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
			/// </summary>
            public virtual DisplayField.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as DisplayField.Builder;
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
        public DisplayField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DisplayField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField()
        {
            return this.DisplayField(new DisplayField());
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField(DisplayField component)
        {
            return new DisplayField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DisplayField.Builder DisplayField(DisplayField.Config config)
        {
            return new DisplayField.Builder(new DisplayField(config));
        }
    }
}