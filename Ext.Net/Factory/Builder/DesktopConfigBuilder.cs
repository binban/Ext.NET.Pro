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
    public partial class DesktopConfig
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TDesktopConfig, TBuilder> : Panel.Builder<TDesktopConfig, TBuilder>
            where TDesktopConfig : DesktopConfig
            where TBuilder : Builder<TDesktopConfig, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDesktopConfig component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ContextMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().ContextMenu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ShortcutContextMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().ShortcutContextMenu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder WindowMenu(Action<MenuCollection> action)
            {
                action(this.ToComponent().WindowMenu);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder ShortcutDefaults(Action<ShortcutDefaults> action)
            {
                action(this.ToComponent().ShortcutDefaults);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SortShortcuts(bool sortShortcuts)
            {
                this.ToComponent().SortShortcuts = sortShortcuts;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DefaultWindowMenu(bool defaultWindowMenu)
            {
                this.ToComponent().DefaultWindowMenu = defaultWindowMenu;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DefaultWindowMenuItemsFirst(bool defaultWindowMenuItemsFirst)
            {
                this.ToComponent().DefaultWindowMenuItemsFirst = defaultWindowMenuItemsFirst;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RestoreText(string restoreText)
            {
                this.ToComponent().RestoreText = restoreText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MinimizeText(string minimizeText)
            {
                this.ToComponent().MinimizeText = minimizeText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MaximizeText(string maximizeText)
            {
                this.ToComponent().MaximizeText = maximizeText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CloseText(string closeText)
            {
                this.ToComponent().CloseText = closeText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ActiveWindowCls(string activeWindowCls)
            {
                this.ToComponent().ActiveWindowCls = activeWindowCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder InactiveWindowCls(string inactiveWindowCls)
            {
                this.ToComponent().InactiveWindowCls = inactiveWindowCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder XTickSize(int xTickSize)
            {
                this.ToComponent().XTickSize = xTickSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder YTickSize(int yTickSize)
            {
                this.ToComponent().YTickSize = yTickSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShortcutItemSelector(string shortcutItemSelector)
            {
                this.ToComponent().ShortcutItemSelector = shortcutItemSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShortcutTpl(XTemplate shortcutTpl)
            {
                this.ToComponent().ShortcutTpl = shortcutTpl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShortcutEvent(string shortcutEvent)
            {
                this.ToComponent().ShortcutEvent = shortcutEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DDShortcut(bool dDShortcut)
            {
                this.ToComponent().DDShortcut = dDShortcut;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShortcutDragSelector(bool shortcutDragSelector)
            {
                this.ToComponent().ShortcutDragSelector = shortcutDragSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShortcutNameEditing(bool shortcutNameEditing)
            {
                this.ToComponent().ShortcutNameEditing = shortcutNameEditing;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignToGrid(bool alignToGrid)
            {
                this.ToComponent().AlignToGrid = alignToGrid;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Wallpaper(string wallpaper)
            {
                this.ToComponent().Wallpaper = wallpaper;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder WallpaperStretch(bool wallpaperStretch)
            {
                this.ToComponent().WallpaperStretch = wallpaperStretch;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : DesktopConfig.Builder<DesktopConfig, DesktopConfig.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopConfig()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopConfig component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopConfig.Config config) : base(new DesktopConfig(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopConfig component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopConfig(this);
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
        public DesktopConfig.Builder DesktopConfig()
        {
#if MVC
			return this.DesktopConfig(new DesktopConfig { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.DesktopConfig(new DesktopConfig());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder DesktopConfig(DesktopConfig component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new DesktopConfig.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopConfig.Builder DesktopConfig(DesktopConfig.Config config)
        {
#if MVC
			return new DesktopConfig.Builder(new DesktopConfig(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new DesktopConfig.Builder(new DesktopConfig(config));
#endif			
        }
    }
}