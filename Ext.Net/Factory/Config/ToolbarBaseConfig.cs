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
        new public abstract partial class Config : ContainerBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string defaultType = "Button";

			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
			[DefaultValue("Button")]
			public override string DefaultType 
			{ 
				get
				{
					return this.defaultType;
				}
				set
				{
					this.defaultType = value;
				}
			}

			private bool flat = false;

			/// <summary>
			/// True to use flat style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Flat 
			{ 
				get
				{
					return this.flat;
				}
				set
				{
					this.flat = value;
				}
			}

			private bool classicButtonStyle = false;

			/// <summary>
			/// True to use classic (none-flat) style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ClassicButtonStyle 
			{ 
				get
				{
					return this.classicButtonStyle;
				}
				set
				{
					this.classicButtonStyle = value;
				}
			}

			private bool enableOverflow = false;

			/// <summary>
			/// Defaults to false. Configure <tt>true</tt> to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableOverflow 
			{ 
				get
				{
					return this.enableOverflow;
				}
				set
				{
					this.enableOverflow = value;
				}
			}

        }
    }
}