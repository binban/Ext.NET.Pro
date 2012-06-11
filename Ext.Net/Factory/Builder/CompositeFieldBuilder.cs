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
    public partial class CompositeField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Field.Builder<CompositeField, CompositeField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CompositeField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CompositeField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CompositeField.Config config) : base(new CompositeField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CompositeField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// If true .doLayout() is called after render. Default is false.
			/// </summary>
            public virtual CompositeField.Builder AutoDoLayout(bool autoDoLayout)
            {
                this.ToComponent().AutoDoLayout = autoDoLayout;
                return this as CompositeField.Builder;
            }
             
 			// /// <summary>
			// /// Builds a label string from an array of subfield labels. Calls if CompositeField has no FieldLabel
			// /// </summary>
            // public virtual TBuilder BuildLabel(JFunction buildLabel)
            // {
            //    this.ToComponent().BuildLabel = buildLabel;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// A Collection of Field Components.
			// /// </summary>
            // public virtual TBuilder Items(ItemsCollection<Component> items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The margins to apply by default to each field in the composite
			/// </summary>
            public virtual CompositeField.Builder DefaultMargins(string defaultMargins)
            {
                this.ToComponent().DefaultMargins = defaultMargins;
                return this as CompositeField.Builder;
            }
             
 			/// <summary>
			/// If true, the defaultMargins are not applied to the last item in the composite field set (defaults to true)
			/// </summary>
            public virtual CompositeField.Builder SkipLastItemMargin(bool skipLastItemMargin)
            {
                this.ToComponent().SkipLastItemMargin = skipLastItemMargin;
                return this as CompositeField.Builder;
            }
             
 			/// <summary>
			/// True to combine errors from the individual fields into a single error message at the CompositeField level (defaults to true)
			/// </summary>
            public virtual CompositeField.Builder CombineErrors(bool combineErrors)
            {
                this.ToComponent().CombineErrors = combineErrors;
                return this as CompositeField.Builder;
            }
             
 			/// <summary>
			/// The string to use when joining segments of the built label together (defaults to ', ')
			/// </summary>
            public virtual CompositeField.Builder LabelConnector(string labelConnector)
            {
                this.ToComponent().LabelConnector = labelConnector;
                return this as CompositeField.Builder;
            }
             
 			// /// <summary>
			// /// A config object that will be applied to all fields added to this CompositeField either via the items config. The defaults config can contain any number of name/value property pairs to be added to each items, and should be valid for the types of items being added to the CompositeField.
			// /// </summary>
            // public virtual TBuilder Defaults(ParameterCollection defaults)
            // {
            //    this.ToComponent().Defaults = defaults;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(CompositeFieldListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(CompositeFieldDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
			/// </summary>
            public virtual CompositeField.Builder DoLayout()
            {
                this.ToComponent().DoLayout();
                return this;
            }
            
 			/// <summary>
			/// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
			/// </summary>
            public virtual CompositeField.Builder DoLayout(bool shallow)
            {
                this.ToComponent().DoLayout(shallow);
                return this;
            }
            
 			/// <summary>
			/// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
			/// </summary>
            public virtual CompositeField.Builder DoLayout(bool shallow, bool force)
            {
                this.ToComponent().DoLayout(shallow, force);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public CompositeField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CompositeField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CompositeField.Builder CompositeField()
        {
            return this.CompositeField(new CompositeField());
        }

        /// <summary>
        /// 
        /// </summary>
        public CompositeField.Builder CompositeField(CompositeField component)
        {
            return new CompositeField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CompositeField.Builder CompositeField(CompositeField.Config config)
        {
            return new CompositeField.Builder(new CompositeField(config));
        }
    }
}