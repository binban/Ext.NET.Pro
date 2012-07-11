/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public abstract partial class ToolbarBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TToolbarBase, TBuilder> : ContainerBase.Builder<TToolbarBase, TBuilder>
            where TToolbarBase : ToolbarBase
            where TBuilder : Builder<TToolbarBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TToolbarBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
            public virtual TBuilder DefaultType(string defaultType)
            {
                this.ToComponent().DefaultType = defaultType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use flat style.
			/// </summary>
            public virtual TBuilder Flat(bool flat)
            {
                this.ToComponent().Flat = flat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use classic (none-flat) style.
			/// </summary>
            public virtual TBuilder ClassicButtonStyle(bool classicButtonStyle)
            {
                this.ToComponent().ClassicButtonStyle = classicButtonStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to false. Configure <tt>true</tt> to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
			/// </summary>
            public virtual TBuilder EnableOverflow(bool enableOverflow)
            {
                this.ToComponent().EnableOverflow = enableOverflow;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}