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
    public partial class Spotlight
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TSpotlight, TBuilder> : Observable.Builder<TSpotlight, TBuilder>
            where TSpotlight : Spotlight
            where TBuilder : Builder<TSpotlight, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TSpotlight component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to animate the spot (defaults to true).
			/// </summary>
            public virtual TBuilder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Animation duration if animate = true (defaults to .25)
			/// </summary>
            public virtual TBuilder Duration(double duration)
            {
                this.ToComponent().Duration = duration;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Animation easing if animate = true (defaults to 'easeNone')
			/// </summary>
            public virtual TBuilder Easing(Easing easing)
            {
                this.ToComponent().Easing = easing;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Show(string id)
            {
                this.ToComponent().Show(id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Show(BaseControl control)
            {
                this.ToComponent().Show(control);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hide()
            {
                this.ToComponent().Hide();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SyncSize()
            {
                this.ToComponent().SyncSize();
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Spotlight.Builder<Spotlight, Spotlight.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Spotlight()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Spotlight component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Spotlight.Config config) : base(new Spotlight(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Spotlight component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Spotlight.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Spotlight(this);
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
        public Spotlight.Builder Spotlight()
        {
#if MVC
			return this.Spotlight(new Spotlight { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Spotlight(new Spotlight());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Spotlight.Builder Spotlight(Spotlight component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Spotlight.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Spotlight.Builder Spotlight(Spotlight.Config config)
        {
#if MVC
			return new Spotlight.Builder(new Spotlight(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Spotlight.Builder(new Spotlight(config));
#endif			
        }
    }
}