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
    public partial class Anchor
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LayoutItem.Builder<Anchor, Anchor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Anchor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Anchor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Anchor.Config config) : base(new Anchor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Anchor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).
			/// </summary>
            public virtual Anchor.Builder IsFormField(bool isFormField)
            {
                this.ToComponent().IsFormField = isFormField;
                return this as Anchor.Builder;
            }
             
 			/// <summary>
			/// Horizontal Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).
			/// </summary>
            public virtual Anchor.Builder Horizontal(string horizontal)
            {
                this.ToComponent().Horizontal = horizontal;
                return this as Anchor.Builder;
            }
             
 			/// <summary>
			/// Vertical Anchor value. Can be a Percentage (1-100%), an Offset (Any positive or negative integer value), a Sides value (Valid values are 'right' (or 'r') and 'bottom' (or 'b').).
			/// </summary>
            public virtual Anchor.Builder Vertical(string vertical)
            {
                this.ToComponent().Vertical = vertical;
                return this as Anchor.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Anchor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder Anchor()
        {
            return this.Anchor(new Anchor());
        }

        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder Anchor(Anchor component)
        {
            return new Anchor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Anchor.Builder Anchor(Anchor.Config config)
        {
            return new Anchor.Builder(new Anchor(config));
        }
    }
}