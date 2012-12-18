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
    public abstract partial class ColumnBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TColumnBase, TBuilder> : ComponentBase.Builder<TColumnBase, TBuilder>
            where TColumnBase : ColumnBase
            where TBuilder : Builder<TColumnBase, TBuilder>
        {
            /// <summary>
			/// Specify as true to constrain column dragging so that a column cannot be dragged into or out of this column. Note that this config is only valid for column headers which contain child column headers.
			/// </summary>
            public virtual TBuilder Sealed(bool @sealed)
            {
                this.ToComponent().Sealed = @sealed;
                return this as TBuilder;
            }

            /// <summary>
            /// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
            /// </summary>
            public virtual TBuilder Renderer(RendererFormat rendererFormat)
            {
                this.ToComponent().Renderer = new Renderer { Format = rendererFormat };
                return this as TBuilder;
            }

            /// <summary>
            /// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
            /// </summary>
            public virtual TBuilder Renderer(RendererFormat rendererFormat, params string[] formatArgs)
            {
                this.ToComponent().Renderer = new Renderer { Format = rendererFormat, FormatArgs = formatArgs };
                return this as TBuilder;
            }

            /// <summary>
            /// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
            /// </summary>
            public virtual TBuilder Renderer(string handler)
            {
                this.ToComponent().Renderer = new Renderer(handler);
                return this as TBuilder;
            }

            /// <summary>
            /// An optional xtype or config object for a Field to use for editing. Only applicable if the grid is using an Editing plugin.
            /// </summary>
            /// <param name="editor"></param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(Field editor)
            {
                this.ToComponent().Editor.Add(editor);
                return this as TBuilder;
            }            
        }        
    }
}