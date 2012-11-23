/********
 * @version   : 1.6.0 - Ext.NET Pro License
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
    public partial class Slider
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : SliderBase.Builder<Slider, Slider.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Slider()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Slider component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Slider.Config config) : base(new Slider(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Slider component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(SliderListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(SliderDirectEvents directEvents)
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
        public Slider.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Slider(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Slider.Builder Slider()
        {
            return this.Slider(new Slider());
        }

        /// <summary>
        /// 
        /// </summary>
        public Slider.Builder Slider(Slider component)
        {
            return new Slider.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Slider.Builder Slider(Slider.Config config)
        {
            return new Slider.Builder(new Slider(config));
        }
    }
}