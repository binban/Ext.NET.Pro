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
    public partial class ColorPalette
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ColorPalette(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ColorPalette.Config Conversion to ColorPalette
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ColorPalette(ColorPalette.Config config)
        {
            return new ColorPalette(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Component.Config 
        { 
			/*  Implicit ColorPalette.Config Conversion to ColorPalette.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ColorPalette.Builder(ColorPalette.Config config)
			{
				return new ColorPalette.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool allowReselect = false;

			/// <summary>
			/// If set to true then reselecting a color that is already selected fires the select event
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowReselect 
			{ 
				get
				{
					return this.allowReselect;
				}
				set
				{
					this.allowReselect = value;
				}
			}

			private string[] colors = null;

			/// <summary>
			/// An array of 6-digit color hex code strings (without the # symbol).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] Colors 
			{ 
				get
				{
					return this.colors;
				}
				set
				{
					this.colors = value;
				}
			}

			private string itemCls = "";

			/// <summary>
			/// The CSS class to apply to the containing element (defaults to \"x-color-palette\")
			/// </summary>
			[DefaultValue("")]
			public override string ItemCls 
			{ 
				get
				{
					return this.itemCls;
				}
				set
				{
					this.itemCls = value;
				}
			}
        
			private XTemplate template = null;

			/// <summary>
			/// An existing XTemplate instance to be used in place of the default template for rendering the component.
			/// </summary>
			public XTemplate Template
			{
				get
				{
					if (this.template == null)
					{
						this.template = new XTemplate();
					}
			
					return this.template;
				}
			}
			
			private string value = "";

			/// <summary>
			/// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
			/// </summary>
			[DefaultValue("")]
			public virtual string Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}

			private bool autoPostBack = false;

			/// <summary>
			/// AutoPostBack
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}
        
			private ColorPaletteListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ColorPaletteListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ColorPaletteListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ColorPaletteDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ColorPaletteDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ColorPaletteDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}