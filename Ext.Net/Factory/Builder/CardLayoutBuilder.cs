/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class CardLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ContainerLayout.Builder<CardLayout, CardLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CardLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CardLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CardLayout.Config config) : base(new CardLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CardLayout component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to render each contained items at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.
			/// </summary>
            public virtual CardLayout.Builder DeferredRender(bool deferredRender)
            {
                this.ToComponent().DeferredRender = deferredRender;
                return this as CardLayout.Builder;
            }
             
 			/// <summary>
			/// True to force a layout of the active item when the active card is changed. Defaults to false.
			/// </summary>
            public virtual CardLayout.Builder LayoutOnCardChange(bool layoutOnCardChange)
            {
                this.ToComponent().LayoutOnCardChange = layoutOnCardChange;
                return this as CardLayout.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CardLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CardLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CardLayout.Builder CardLayout()
        {
            return this.CardLayout(new CardLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public CardLayout.Builder CardLayout(CardLayout component)
        {
            return new CardLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CardLayout.Builder CardLayout(CardLayout.Config config)
        {
            return new CardLayout.Builder(new CardLayout(config));
        }
    }
}