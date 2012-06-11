/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
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
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TColumnBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder HeaderItems(Action<ItemsCollection<AbstractComponent>> action)
            {
                action(this.ToComponent().HeaderItems);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideTitleEl(bool hideTitleEl)
            {
                this.ToComponent().HideTitleEl = hideTitleEl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Locked(bool? locked)
            {
                this.ToComponent().Locked = locked;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Sets the alignment of the header and rendered columns. Defaults to 'left'.
			/// </summary>
            public virtual TBuilder Align(Alignment align)
            {
                this.ToComponent().Align = align;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional array of sub-column definitions. This column becomes a group, and houses the columns defined in the columns config.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Columns(Action<ColumnCollection> action)
            {
                action(this.ToComponent().Columns);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Required. The name of the field in the grid's Ext.data.Store's Ext.data.Model definition from which to draw the column's value.
			/// </summary>
            public virtual TBuilder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A renderer to be used in conjunction with RowEditing. This renderer is used to display a custom value for non-editable fields.
			/// </summary>
            public virtual TBuilder EditorRenderer(Renderer editorRenderer)
            {
                this.ToComponent().EditorRenderer = editorRenderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An optional xtype or config object for a Field to use for editing. Only applicable if the grid is using an Editing plugin.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(Action<EditorCollection> action)
            {
                action(this.ToComponent().Editor);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorStrategy(Action<JFunction> action)
            {
                action(this.ToComponent().EditorStrategy);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Editor options
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorOptions(Action<CellEditorOptions> action)
            {
                action(this.ToComponent().EditorOptions);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The text to diplay in empty cells (cells with a value of undefined, null, or ''). Defaults to &#160; aka &nbsp;.
			/// </summary>
            public virtual TBuilder EmptyCellText(string emptyCellText)
            {
                this.ToComponent().EmptyCellText = emptyCellText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If the grid uses a Ext.grid.feature.Grouping, this option may be used to disable the header menu item to group by the column selected. By default, the header menu group option is enabled. Set to false to disable (but still show) the group option in the header menu for the column.
			/// </summary>
            public virtual TBuilder Groupable(bool groupable)
            {
                this.ToComponent().Groupable = groupable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. Specify as false to prevent the user from hiding this column (defaults to true).
			/// </summary>
            public virtual TBuilder Hideable(bool hideable)
            {
                this.ToComponent().Hideable = hideable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disabled the column header menu containing sort/hide options. Defaults to false.
			/// </summary>
            public virtual TBuilder MenuDisabled(bool menuDisabled)
            {
                this.ToComponent().MenuDisabled = menuDisabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to render in the column visibility selection menu for this column. If not specified, will default to the text value. Defaults to: null
			/// </summary>
            public virtual TBuilder MenuText(string menuText)
            {
                this.ToComponent().MenuText = menuText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A renderer is an 'interceptor' method which can be used transform data (value, appearance, etc.) before it is rendered.
			/// </summary>
            public virtual TBuilder Renderer(Renderer renderer)
            {
                this.ToComponent().Renderer = renderer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to prevent the column from being resizable. Defaults to: true
			/// </summary>
            public virtual TBuilder Resizable(bool resizable)
            {
                this.ToComponent().Resizable = resizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable sorting of this column. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort. Defaults to: true
			/// </summary>
            public virtual TBuilder Sortable(bool? sortable)
            {
                this.ToComponent().Sortable = sortable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional. A CSS class names to apply to the table cells for this column.
			/// </summary>
            public virtual TBuilder TdCls(string tdCls)
            {
                this.ToComponent().TdCls = tdCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The header text to be used as innerHTML (html tags are accepted) to display in the Grid. Note: to have a clickable header with no text displayed you can use the default of &#160; aka &nbsp;. Defaults to: \"&#160;\"
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}