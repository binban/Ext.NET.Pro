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
    public partial class ToolbarTextItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ToolbarItem.Builder<ToolbarTextItem, ToolbarTextItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ToolbarTextItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarTextItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ToolbarTextItem.Config config) : base(new ToolbarTextItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ToolbarTextItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A Toolbar Text item.
			/// </summary>
            public virtual ToolbarTextItem.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as ToolbarTextItem.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(BoxComponentListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(BoxComponentDirectEvents directEvents)
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
        public ToolbarTextItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ToolbarTextItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ToolbarTextItem.Builder ToolbarTextItem()
        {
            return this.ToolbarTextItem(new ToolbarTextItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarTextItem.Builder ToolbarTextItem(ToolbarTextItem component)
        {
            return new ToolbarTextItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ToolbarTextItem.Builder ToolbarTextItem(ToolbarTextItem.Config config)
        {
            return new ToolbarTextItem.Builder(new ToolbarTextItem(config));
        }
    }
}