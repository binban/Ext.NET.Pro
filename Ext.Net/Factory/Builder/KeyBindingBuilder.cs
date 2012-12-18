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
    public partial class KeyBinding
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TKeyBinding, TBuilder> : BaseItem.Builder<TKeyBinding, TBuilder>
            where TKeyBinding : KeyBinding
            where TBuilder : Builder<TKeyBinding, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TKeyBinding component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)
			/// </summary>
            public virtual TBuilder Shift(bool? shift)
            {
                this.ToComponent().Shift = shift;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)
			/// </summary>
            public virtual TBuilder Ctrl(bool? ctrl)
            {
                this.ToComponent().Ctrl = ctrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)
			/// </summary>
            public virtual TBuilder Alt(bool? alt)
            {
                this.ToComponent().Alt = alt;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The function to call when KeyMap finds the expected key combination
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope of the callback function
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A default action to apply to the event. Possible values are: stopEvent, stopPropagation, preventDefault. If no value is set no action is performed.
			/// </summary>
            public virtual TBuilder DefaultEventAction(EventAction defaultEventAction)
            {
                this.ToComponent().DefaultEventAction = defaultEventAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A single keycode or an array of keycodes to handle
			/// </summary>
            public virtual TBuilder KeysString(string keysString)
            {
                this.ToComponent().KeysString = keysString;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : KeyBinding.Builder<KeyBinding, KeyBinding.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new KeyBinding()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyBinding component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyBinding.Config config) : base(new KeyBinding(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(KeyBinding component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.KeyBinding(this);
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
        public KeyBinding.Builder KeyBinding()
        {
#if MVC
			return this.KeyBinding(new KeyBinding { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.KeyBinding(new KeyBinding());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder KeyBinding(KeyBinding component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new KeyBinding.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder KeyBinding(KeyBinding.Config config)
        {
#if MVC
			return new KeyBinding.Builder(new KeyBinding(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new KeyBinding.Builder(new KeyBinding(config));
#endif			
        }
    }
}