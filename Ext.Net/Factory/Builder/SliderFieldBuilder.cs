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
    public partial class SliderField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Field.Builder<SliderField, SliderField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SliderField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SliderField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SliderField.Config config) : base(new SliderField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SliderField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Slider object config
			// /// </summary>
            // public virtual TBuilder Slider(Slider slider)
            // {
            //    this.ToComponent().Slider = slider;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SliderField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SliderField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SliderField.Builder SliderField()
        {
            return this.SliderField(new SliderField());
        }

        /// <summary>
        /// 
        /// </summary>
        public SliderField.Builder SliderField(SliderField component)
        {
            return new SliderField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SliderField.Builder SliderField(SliderField.Config config)
        {
            return new SliderField.Builder(new SliderField(config));
        }
    }
}