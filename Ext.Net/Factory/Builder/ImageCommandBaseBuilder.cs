/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
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
    public abstract partial class ImageCommandBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TImageCommandBase, TBuilder> : StateManagedItem.Builder<TImageCommandBase, TBuilder>
            where TImageCommandBase : ImageCommandBase
            where TBuilder : Builder<TImageCommandBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TImageCommandBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CommandName(string commandName)
            {
                this.ToComponent().CommandName = commandName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
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
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
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
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Style(string style)
            {
                this.ToComponent().Style = style;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder ToolTip(SimpleToolTip toolTip)
            // {
            //    this.ToComponent().ToolTip = toolTip;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display) - defaults to 'display'.
			/// </summary>
            public virtual TBuilder HideMode(HideMode hideMode)
            {
                this.ToComponent().HideMode = hideMode;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}