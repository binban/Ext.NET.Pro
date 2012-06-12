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
    public partial class FieldSet
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Panel.Builder<FieldSet, FieldSet.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FieldSet()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldSet component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FieldSet.Config config) : base(new FieldSet(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FieldSet component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
			/// </summary>
            public virtual FieldSet.Builder AnimCollapse(bool animCollapse)
            {
                this.ToComponent().AnimCollapse = animCollapse;
                return this as FieldSet.Builder;
            }
             
 			/// <summary>
			/// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
			/// </summary>
            public virtual FieldSet.Builder CheckboxName(string checkboxName)
            {
                this.ToComponent().CheckboxName = checkboxName;
                return this as FieldSet.Builder;
            }
             
 			/// <summary>
			/// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
			/// </summary>
            public virtual FieldSet.Builder CheckboxToggle(bool checkboxToggle)
            {
                this.ToComponent().CheckboxToggle = checkboxToggle;
                return this as FieldSet.Builder;
            }
             
 			/// <summary>
			/// A css class to apply to the x-form-items of fields. This property cascades to child containers.
			/// </summary>
            public virtual FieldSet.Builder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as FieldSet.Builder;
            }
             
 			/// <summary>
			/// The width of labels. This property cascades to child containers.
			/// </summary>
            public virtual FieldSet.Builder LabelWidth(int labelWidth)
            {
                this.ToComponent().LabelWidth = labelWidth;
                return this as FieldSet.Builder;
            }
             
 			/// <summary>
			/// The Ext.Container.layout to use inside the fieldset (defaults to 'form').
			/// </summary>
            public virtual FieldSet.Builder Layout(string layout)
            {
                this.ToComponent().Layout = layout;
                return this as FieldSet.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FieldSet(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder FieldSet()
        {
            return this.FieldSet(new FieldSet());
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder FieldSet(FieldSet component)
        {
            return new FieldSet.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FieldSet.Builder FieldSet(FieldSet.Config config)
        {
            return new FieldSet.Builder(new FieldSet(config));
        }
    }
}