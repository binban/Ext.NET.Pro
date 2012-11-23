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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractPanel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAbstractPanel"></typeparam>
        /// <typeparam name="TBuilder"></typeparam>
        new public abstract partial class Builder<TAbstractPanel, TBuilder> : AbstractContainer.Builder<TAbstractPanel, TBuilder>
            where TAbstractPanel : AbstractPanel
            where TBuilder : Builder<TAbstractPanel, TBuilder>
        {
            //public virtual ToolbarCollection<TPanelBase, TBuilder> TopBar()
            //{
            //    return new ToolbarCollection<TPanelBase, TBuilder>(this.ToControl(), this as TBuilder);
            //}

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            public virtual TBuilder Buttons(Action<ButtonsCollectionBuilder<TAbstractPanel, TBuilder>> action)
            {
                action(new ButtonsCollectionBuilder<TAbstractPanel, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            public virtual TBuilder ToolsBuilder(Action<ToolsCollectionBuilder<TAbstractPanel, TBuilder>> action)
            {
                action(new ToolsCollectionBuilder<TAbstractPanel, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            public virtual TBuilder TopBarBuilder(Action<TBarCollectionBuilder<TAbstractPanel, TBuilder>> action)
            {
                action(new TBarCollectionBuilder<TAbstractPanel, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual TBuilder TopBar(ToolbarBase bar)
            {
                this.ToComponent().TopBar.Add(bar);
                return this as TBuilder;
            }

            public virtual TBuilder TopBarItem(AbstractComponent item)
            {
                var cmp = this.ToComponent();
                if (cmp.TopBar.Count == 0)
                {
                    cmp.TopBar.Add(new Toolbar());
                }

                cmp.TopBar[0].Items.Add(item);

                return this as TBuilder;
            }

            public virtual TBuilder TopBarItem(params AbstractComponent[] items)
            {
                foreach (var item in items)
                {
                    this.TopBarItem(item);
                }

                return this as TBuilder;
            }

            public virtual TBuilder TopBarItem(IEnumerable<AbstractComponent> items)
            {
                foreach (var item in items)
                {
                    this.TopBarItem(item);
                }

                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            public virtual TBuilder BottomBarBuilder(Action<BBarCollectionBuilder<TAbstractPanel, TBuilder>> action)
            {
                action(new BBarCollectionBuilder<TAbstractPanel, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual TBuilder BottomBar(ToolbarBase bar)
            {
                this.ToComponent().BottomBar.Add(bar);
                return this as TBuilder;
            }

            public virtual TBuilder BottomBarItem(AbstractComponent item)
            {
                var cmp = this.ToComponent();
                if (cmp.BottomBar.Count == 0)
                {
                    cmp.BottomBar.Add(new Toolbar());
                }

                cmp.BottomBar[0].Items.Add(item);

                return this as TBuilder;
            }

            public virtual TBuilder BottomBarItem(params AbstractComponent[] items)
            {
                foreach (var item in items)
                {
                    this.BottomBarItem(item);
                }

                return this as TBuilder;
            }

            public virtual TBuilder BottomBarItem(IEnumerable<AbstractComponent> items)
            {
                foreach (var item in items)
                {
                    this.BottomBarItem(item);
                }

                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <returns></returns>
            public virtual TBuilder FooterBarBuilder(Action<FBarCollectionBuilder<TAbstractPanel, TBuilder>> action)
            {
                action(new FBarCollectionBuilder<TAbstractPanel, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual TBuilder FooterBar(ToolbarBase bar)
            {
                this.ToComponent().FooterBar.Add(bar);
                return this as TBuilder;
            }

            public virtual TBuilder FooterBarItem(AbstractComponent item)
            {
                var cmp = this.ToComponent();
                if (cmp.FooterBar.Count == 0)
                {
                    cmp.FooterBar.Add(new Toolbar());
                }

                cmp.FooterBar[0].Items.Add(item);

                return this as TBuilder;
            }

            public virtual TBuilder FooterBarItem(params AbstractComponent[] items)
            {
                foreach (var item in items)
                {
                    this.FooterBarItem(item);
                }

                return this as TBuilder;
            }

            public virtual TBuilder FooterBarItem(IEnumerable<AbstractComponent> items)
            {
                foreach (var item in items)
                {
                    this.FooterBarItem(item);
                }

                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual TBuilder LeftBar(ToolbarBase bar)
            {
                this.ToComponent().LeftBar.Add(bar);
                return this as TBuilder;
            }

            public virtual TBuilder LeftBarItem(AbstractComponent item)
            {
                var cmp = this.ToComponent();
                if (cmp.LeftBar.Count == 0)
                {
                    cmp.LeftBar.Add(new Toolbar());
                }

                cmp.LeftBar[0].Items.Add(item);

                return this as TBuilder;
            }

            public virtual TBuilder LeftBarItem(params AbstractComponent[] items)
            {
                foreach (var item in items)
                {
                    this.LeftBarItem(item);
                }

                return this as TBuilder;
            }

            public virtual TBuilder LeftBarItem(IEnumerable<AbstractComponent> items)
            {
                foreach (var item in items)
                {
                    this.LeftBarItem(item);
                }

                return this as TBuilder;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public virtual TBuilder RightBar(ToolbarBase bar)
            {
                this.ToComponent().RightBar.Add(bar);
                return this as TBuilder;
            }

            public virtual TBuilder RightBarItem(AbstractComponent item)
            {
                var cmp = this.ToComponent();
                if (cmp.RightBar.Count == 0)
                {
                    cmp.RightBar.Add(new Toolbar());
                }

                cmp.RightBar[0].Items.Add(item);

                return this as TBuilder;
            }

            public virtual TBuilder RightBarItem(params AbstractComponent[] items)
            {
                foreach (var item in items)
                {
                    this.RightBarItem(item);
                }

                return this as TBuilder;
            }

            public virtual TBuilder RightBarItem(IEnumerable<AbstractComponent> items)
            {
                foreach (var item in items)
                {
                    this.RightBarItem(item);
                }

                return this as TBuilder;
            }

            /// <summary>
            /// DockedItems collection
            /// </summary>
            [Description("DockedItems collection")]
            public virtual TBuilder DockedItems(AbstractComponent item)
            {
                this.ToComponent().DockedItems.Add(item);
                return this as TBuilder;
            }

            /// <summary>
            /// DockedItems collection
            /// </summary>
            [Description("DockedItems collection")]
            public virtual TBuilder DockedItems(IEnumerable<AbstractComponent> items)
            {
                this.ToComponent().DockedItems.AddRange(items);
                return this as TBuilder;
            }

            /// <summary>
            /// DockedItems collection
            /// </summary>
            [Description("DockedItems collection")]
            public virtual TBuilder DockedItems(params AbstractComponent[] items)
            {
                this.ToComponent().DockedItems.AddRange(items);
                return this as TBuilder;
            }

            /// <summary>
            /// Buttons collection
            /// </summary>
            [Description("Buttons collection")]
            public virtual TBuilder Buttons(ButtonBase button)
            {
                this.ToComponent().Buttons.Add(button);
                return this as TBuilder;
            }

            /// <summary>
            /// Buttons collection
            /// </summary>
            [Description("Buttons collection")]
            public virtual TBuilder Buttons(IEnumerable<ButtonBase> buttons)
            {
                this.ToComponent().Buttons.AddRange(buttons);
                return this as TBuilder;
            }

            /// <summary>
            /// Buttons collection
            /// </summary>
            [Description("Buttons collection")]
            public virtual TBuilder Buttons(params ButtonBase[] buttons)
            {
                this.ToComponent().Buttons.AddRange(buttons);
                return this as TBuilder;
            }

            /// <summary>
            /// Tools collection
            /// </summary>
            [Description("Tools collection")]
            public virtual TBuilder Tools(Tool tool)
            {
                this.ToComponent().Tools.Add(tool);
                return this as TBuilder;
            }

            /// <summary>
            /// Tools collection
            /// </summary>
            [Description("Tools collection")]
            public virtual TBuilder Tools(IEnumerable<Tool> tools)
            {
                this.ToComponent().Tools.AddRange(tools);
                return this as TBuilder;
            }

            /// <summary>
            /// Tools collection
            /// </summary>
            [Description("Tools collection")]
            public virtual TBuilder Tools(params Tool[] tools)
            {
                this.ToComponent().Tools.AddRange(tools);
                return this as TBuilder;
            }
        }        
    }
}