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
    public partial class DesktopShortcut
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDesktopShortcut, TBuilder> : BaseItem.Builder<TDesktopShortcut, TBuilder>
            where TDesktopShortcut : DesktopShortcut
            where TBuilder : Builder<TDesktopShortcut, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDesktopShortcut component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SortIndex(int sortIndex)
            {
                this.ToComponent().SortIndex = sortIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder X(string x)
            {
                this.ToComponent().X = x;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Y(string y)
            {
                this.ToComponent().Y = y;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder TextCls(string textCls)
            {
                this.ToComponent().TextCls = textCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Module(string module)
            {
                this.ToComponent().Module = module;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder QTitle(string qTitle)
            {
                this.ToComponent().QTitle = qTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder QTip(string qTip)
            {
                this.ToComponent().QTip = qTip;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DesktopShortcut.Builder<DesktopShortcut, DesktopShortcut.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopShortcut()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopShortcut component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopShortcut.Config config) : base(new DesktopShortcut(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopShortcut component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopShortcut(this);
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
        public DesktopShortcut.Builder DesktopShortcut()
        {
#if MVC
			return this.DesktopShortcut(new DesktopShortcut { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DesktopShortcut(new DesktopShortcut());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder DesktopShortcut(DesktopShortcut component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DesktopShortcut.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopShortcut.Builder DesktopShortcut(DesktopShortcut.Config config)
        {
#if MVC
			return new DesktopShortcut.Builder(new DesktopShortcut(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DesktopShortcut.Builder(new DesktopShortcut(config));
#endif			
        }
    }
}