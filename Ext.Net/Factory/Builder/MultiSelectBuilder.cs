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
    public partial class MultiSelect
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TMultiSelect, TBuilder> : MultiSelectBase.Builder<TMultiSelect, TBuilder>
            where TMultiSelect : MultiSelect
            where TBuilder : Builder<TMultiSelect, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMultiSelect component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<MultiSelectListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<MultiSelectDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : MultiSelect.Builder<MultiSelect, MultiSelect.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MultiSelect()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MultiSelect component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MultiSelect.Config config) : base(new MultiSelect(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MultiSelect component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MultiSelect.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MultiSelect(this);
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
        public MultiSelect.Builder MultiSelect()
        {
#if MVC
			return this.MultiSelect(new MultiSelect { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.MultiSelect(new MultiSelect());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public MultiSelect.Builder MultiSelect(MultiSelect component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new MultiSelect.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MultiSelect.Builder MultiSelect(MultiSelect.Config config)
        {
#if MVC
			return new MultiSelect.Builder(new MultiSelect(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new MultiSelect.Builder(new MultiSelect(config));
#endif			
        }
    }
}