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
    public partial class BelongsToAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TBelongsToAssociation, TBuilder> : AbstractAssociation.Builder<TBelongsToAssociation, TBuilder>
            where TBelongsToAssociation : BelongsToAssociation
            where TBuilder : Builder<TBelongsToAssociation, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TBelongsToAssociation component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name of the foreign key on the owner model that links it to the associated model. Defaults to the lowercased name of the associated model plus \"_id\", e.g. an association with a model called Product would set up a product_id foreign key.
			/// </summary>
            public virtual TBuilder ForeignKey(string foreignKey)
            {
                this.ToComponent().ForeignKey = foreignKey;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the getter function that will be added to the local model's prototype. Defaults to 'get' + the name of the foreign model, e.g. getCategory
			/// </summary>
            public virtual TBuilder GetterName(string getterName)
            {
                this.ToComponent().GetterName = getterName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the setter function that will be added to the local model's prototype. Defaults to 'set' + the name of the foreign model, e.g. setCategory
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
        public partial class Builder : BelongsToAssociation.Builder<BelongsToAssociation, BelongsToAssociation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BelongsToAssociation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BelongsToAssociation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BelongsToAssociation.Config config) : base(new BelongsToAssociation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BelongsToAssociation component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BelongsToAssociation(this);
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
        public BelongsToAssociation.Builder BelongsToAssociation()
        {
#if MVC
			return this.BelongsToAssociation(new BelongsToAssociation { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.BelongsToAssociation(new BelongsToAssociation());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder BelongsToAssociation(BelongsToAssociation component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new BelongsToAssociation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BelongsToAssociation.Builder BelongsToAssociation(BelongsToAssociation.Config config)
        {
#if MVC
			return new BelongsToAssociation.Builder(new BelongsToAssociation(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new BelongsToAssociation.Builder(new BelongsToAssociation(config));
#endif			
        }
    }
}