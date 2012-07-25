/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class AbstractContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAbstractContainer"></typeparam>
        /// <typeparam name="TBuilder"></typeparam>
        new public abstract partial class Builder<TAbstractContainer, TBuilder> : ComponentBase.Builder<TAbstractContainer, TBuilder>
            where TAbstractContainer : AbstractContainer
            where TBuilder : Builder<TAbstractContainer, TBuilder>
        {
            //public virtual ItemsBuilder<TContainerBase, TBuilder> Items()
            //{
            //    return new ItemsBuilder<TContainerBase, TBuilder>(this.ToControl(), this as TBuilder);
            //}

            /// <summary>
            /// The layout type to be used in this container.
            /// </summary>
            public virtual TBuilder Layout(LayoutType layout)
            {
                this.ToComponent().Layout = layout.ToString();
                return this as TBuilder;
            }

            /// <summary>
            /// Items collection
            /// </summary>
            [Description("Items collection")]
            public virtual TBuilder Items(Action<ItemsBuilder<TAbstractContainer, TBuilder>> action)
            {
                action(new ItemsBuilder<TAbstractContainer, TBuilder>(this.ToComponent(), this as TBuilder));
                return this as TBuilder;
            }

            /// <summary>
            /// In layout pages, renders the content of a named section as items and specifies whether the section is required.
            /// </summary>
            /// <param name="page">Page instance</param>
            /// <param name="name">Section name to render as items</param>
            /// <param name="required">True to specify that the section is required</param>
            /// <returns></returns>
            public virtual TBuilder ItemsFromSection(System.Web.WebPages.WebPageBase page, string name, bool required)
            {
                BaseControl.SectionsStack.Push(new List<string>());
                var result = page.RenderSection(name, required);
                
                if (result != null)
                {
                    this.ToComponent().ItemsToRender = result.ToHtmlString();
                    this.ToComponent().IDSToRender = BaseControl.SectionsStack.Pop();
                }
                else
                {
                    BaseControl.SectionsStack.Pop();
                }

                return this as TBuilder;
            }            

            /// <summary>
            /// In layout pages, renders the content of a named section as items
            /// </summary>
            /// <param name="page">Page instance</param>
            /// <param name="name">Section name to render as items</param>
            /// <returns></returns>
            public virtual TBuilder ItemsFromSection(System.Web.WebPages.WebPageBase page, string name)
            {
                return this.ItemsFromSection(page, name, false);
            }

            /// <summary>
            /// Renders the content of one page within another page as items.
            /// </summary>
            /// <param name="page">Page instance</param>
            /// <param name="path">The path of the page to render.</param>
            /// <param name="data">(Optional) An array of data to pass to the page being rendered. In the rendered page, these parameters can be accessed by using the PageData property.</param>
            /// <returns></returns>
            public virtual TBuilder ItemsFromPage(System.Web.WebPages.WebPageBase page, string path, params object[] data)
            {
                BaseControl.SectionsStack.Push(new List<string>());
                var result = page.RenderPage(path, data);

                if (result != null)
                {
                    this.ToComponent().ItemsToRender = result.ToHtmlString();
                    this.ToComponent().IDSToRender = BaseControl.SectionsStack.Pop();
                }
                else
                {
                    BaseControl.SectionsStack.Pop();
                }

                return this as TBuilder;
            }        
        }
    }
}