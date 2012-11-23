/********
 * @version   : 1.6.0 - Ext.NET Pro License
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
    public abstract partial class BaseMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Component.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activeClass = "";

			/// <summary>
			/// The CSS class to use when the item becomes activated (defaults to \"x-menu-item-active\").
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveClass 
			{ 
				get
				{
					return this.activeClass;
				}
				set
				{
					this.activeClass = value;
				}
			}

			private bool canActivate = false;

			/// <summary>
			/// True if this item can be visually activated (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CanActivate 
			{ 
				get
				{
					return this.canActivate;
				}
				set
				{
					this.canActivate = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// A function that will handle the click event of this menu item (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope (this reference) in which the handler function will be called.
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private int hideDelay = 100;

			/// <summary>
			/// Length of time in milliseconds to wait before hiding after a click (defaults to 100).
			/// </summary>
			[DefaultValue(100)]
			public virtual int HideDelay 
			{ 
				get
				{
					return this.hideDelay;
				}
				set
				{
					this.hideDelay = value;
				}
			}

			private bool hideOnClick = true;

			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideOnClick 
			{ 
				get
				{
					return this.hideOnClick;
				}
				set
				{
					this.hideOnClick = value;
				}
			}

        }
    }
}