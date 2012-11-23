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
    public abstract partial class LabelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TLabelBase, TBuilder> : ComponentBase.Builder<TLabelBase, TBuilder>
            where TLabelBase : LabelBase
            where TBuilder : Builder<TLabelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TLabelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The format of the string to render using the .Text property. Example 'Hello {0}'.
			/// </summary>
            public virtual TBuilder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text to display if the Text property is empty (defaults to '').
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id of the input element to which this label will be bound via the standard HTML 'for' attribute. If not specified, the attribute will not be added to the label. In most cases you will be associating the label with a Ext.form.field.Base component, so you should make sure this matches the inputId of that field.
			/// </summary>
            public virtual TBuilder ForID(string forID)
            {
                this.ToComponent().ForID = forID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the label. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this label.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) Set the CSS text-align property of the icon. The center is not supported. Defaults to \"Left\"
			/// </summary>
            public virtual TBuilder IconAlign(Alignment iconAlign)
            {
                this.ToComponent().IconAlign = iconAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Inline editor
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(Action<ItemsCollection<Editor>> action)
            {
                action(this.ToComponent().Editor);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}