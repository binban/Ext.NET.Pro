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
    public partial class KeyMap
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TKeyMap, TBuilder> : LazyObservable.Builder<TKeyMap, TBuilder>
            where TKeyMap : KeyMap
            where TBuilder : Builder<TKeyMap, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TKeyMap component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Either a single object describing a handling function for s specified key (or set of keys), or an array of such objects.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Binding(Action<KeyBindingCollection> action)
            {
                action(this.ToComponent().Binding);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The event to listen for to pick up key events. Defaults to: \"keydown\"
			/// </summary>
            public virtual TBuilder EventName(string eventName)
            {
                this.ToComponent().EventName = eventName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to listen component event instead underlying element
			/// </summary>
            public virtual TBuilder ComponentEvent(bool componentEvent)
            {
                this.ToComponent().ComponentEvent = componentEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Element name of target component (can be used if KeyMap belongs to a component)
			/// </summary>
            public virtual TBuilder ComponentElement(string componentElement)
            {
                this.ToComponent().ComponentElement = componentElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Configure this as true if there are any input fields within the target, and this KeyNav should not process events from input fields, (&lt;input>, &lt;textarea> and elements withcontentEditable=\"true\"). Defaults to: false
			/// </summary>
            public virtual TBuilder IgnoreInputFields(bool ignoreInputFields)
            {
                this.ToComponent().IgnoreInputFields = ignoreInputFields;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ProcessEvent(Action<JFunction> action)
            {
                action(this.ToComponent().ProcessEvent);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The scope (this context) in which the processEvent method is executed.
			/// </summary>
            public virtual TBuilder ProcessEventScope(string processEventScope)
            {
                this.ToComponent().ProcessEventScope = processEventScope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The object on which to listen for the event specified by the eventName config option.
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : KeyMap.Builder<KeyMap, KeyMap.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new KeyMap()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyMap component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyMap.Config config) : base(new KeyMap(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(KeyMap component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.KeyMap(this);
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
        public KeyMap.Builder KeyMap()
        {
#if MVC
			return this.KeyMap(new KeyMap { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.KeyMap(new KeyMap());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder KeyMap(KeyMap component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new KeyMap.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder KeyMap(KeyMap.Config config)
        {
#if MVC
			return new KeyMap.Builder(new KeyMap(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new KeyMap.Builder(new KeyMap(config));
#endif			
        }
    }
}