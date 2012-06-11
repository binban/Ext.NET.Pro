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
    public partial class ComponentMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuItemBase.Builder<ComponentMenuItem, ComponentMenuItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComponentMenuItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentMenuItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentMenuItem.Config config) : base(new ComponentMenuItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComponentMenuItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Component(ItemsCollection<Component> component)
            // {
            //    this.ToComponent().Component = component;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The element of component which will be used during menu item rendering
			/// </summary>
            public virtual ComponentMenuItem.Builder ComponentElement(TargetElement componentElement)
            {
                this.ToComponent().ComponentElement = componentElement;
                return this as ComponentMenuItem.Builder;
            }
             
 			/// <summary>
			/// If true then element will be shiffted on horizontal, the icon place will be visible
			/// </summary>
            public virtual ComponentMenuItem.Builder Shift(bool shift)
            {
                this.ToComponent().Shift = shift;
                return this as ComponentMenuItem.Builder;
            }
             
 			/// <summary>
			/// The target element which will be placed to toolbar.
			/// </summary>
            public virtual ComponentMenuItem.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as ComponentMenuItem.Builder;
            }
             
 			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to false).
			/// </summary>
            public virtual ComponentMenuItem.Builder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as ComponentMenuItem.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComponentMenuItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ComponentMenuItem()
        {
            return this.ComponentMenuItem(new ComponentMenuItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ComponentMenuItem(ComponentMenuItem component)
        {
            return new ComponentMenuItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ComponentMenuItem(ComponentMenuItem.Config config)
        {
            return new ComponentMenuItem.Builder(new ComponentMenuItem(config));
        }
    }
}