/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    /// <summary>
    /// 
    /// </summary>
    public partial class HasOneAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<THasOneAssociation, TBuilder> : AbstractAssociation.Builder<THasOneAssociation, TBuilder>
            where THasOneAssociation : HasOneAssociation
            where TBuilder : Builder<THasOneAssociation, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(THasOneAssociation component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus \"_id\"
			/// </summary>
            public virtual TBuilder ForeignKey(string foreignKey)
            {
                this.ToComponent().ForeignKey = foreignKey;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getAddress
			/// </summary>
            public virtual TBuilder GetterName(string getterName)
            {
                this.ToComponent().GetterName = getterName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setAddress
			/// </summary>
            public virtual TBuilder SetterName(string setterName)
            {
                this.ToComponent().SetterName = setterName;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : HasOneAssociation.Builder<HasOneAssociation, HasOneAssociation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HasOneAssociation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HasOneAssociation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HasOneAssociation.Config config) : base(new HasOneAssociation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HasOneAssociation component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public HasOneAssociation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HasOneAssociation(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HasOneAssociation.Builder HasOneAssociation()
        {
#if MVC
			return this.HasOneAssociation(new HasOneAssociation { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.HasOneAssociation(new HasOneAssociation());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public HasOneAssociation.Builder HasOneAssociation(HasOneAssociation component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new HasOneAssociation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HasOneAssociation.Builder HasOneAssociation(HasOneAssociation.Config config)
        {
#if MVC
			return new HasOneAssociation.Builder(new HasOneAssociation(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new HasOneAssociation.Builder(new HasOneAssociation(config));
#endif			
        }
    }
}