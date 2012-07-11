/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class Toolbar
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarBase.Builder<Toolbar, Toolbar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Toolbar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Toolbar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Toolbar.Config config) : base(new Toolbar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Toolbar component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(ToolbarListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(ToolbarDirectEvents directEvents)
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
        public Toolbar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Toolbar(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Toolbar.Builder Toolbar()
        {
            return this.Toolbar(new Toolbar());
        }

        /// <summary>
        /// 
        /// </summary>
        public Toolbar.Builder Toolbar(Toolbar component)
        {
            return new Toolbar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Toolbar.Builder Toolbar(Toolbar.Config config)
        {
            return new Toolbar.Builder(new Toolbar(config));
        }
    }
}