/********
 * @version   : 2.1.0 - Ext.NET Pro License
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
    /// <summary>
    /// 
    /// </summary>
    public partial class ListFilter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TListFilter, TBuilder> : GridFilter.Builder<TListFilter, TBuilder>
            where TListFilter : ListFilter
            where TBuilder : Builder<TListFilter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TListFilter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Defaults to 'id'.
			/// </summary>
            public virtual TBuilder IDField(string iDField)
            {
                this.ToComponent().IDField = iDField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The loading text displayed when data loading
			/// </summary>
            public virtual TBuilder LoadingText(string loadingText)
            {
                this.ToComponent().LoadingText = loadingText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true then the data loading on show
			/// </summary>
            public virtual TBuilder LoadOnShow(bool loadOnShow)
            {
                this.ToComponent().LoadOnShow = loadOnShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specify true to group all items in this list into a single-select radio button group. Defaults to false.
			/// </summary>
            public virtual TBuilder Single(bool single)
            {
                this.ToComponent().Single = single;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The list of options
			/// </summary>
            public virtual TBuilder Options(string[] options)
            {
                this.ToComponent().Options = options;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The list of options
			/// </summary>
            public virtual TBuilder Value(string[] value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder LabelField(string labelField)
            {
                this.ToComponent().LabelField = labelField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The config of the ListFilter menu. Defaults to null.
			/// </summary>
            public virtual TBuilder MenuConfig(Menu menuConfig)
            {
                this.ToComponent().MenuConfig = menuConfig;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : ListFilter.Builder<ListFilter, ListFilter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ListFilter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ListFilter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ListFilter.Config config) : base(new ListFilter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ListFilter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ListFilter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ListFilter(this);
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
        public ListFilter.Builder ListFilter()
        {
#if MVC
			return this.ListFilter(new ListFilter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.ListFilter(new ListFilter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public ListFilter.Builder ListFilter(ListFilter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new ListFilter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ListFilter.Builder ListFilter(ListFilter.Config config)
        {
#if MVC
			return new ListFilter.Builder(new ListFilter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new ListFilter.Builder(new ListFilter(config));
#endif			
        }
    }
}