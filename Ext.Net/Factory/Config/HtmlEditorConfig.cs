/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
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
    /// <summary>
    /// 
    /// </summary>
    public partial class HtmlEditor
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditor(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HtmlEditor.Config Conversion to HtmlEditor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HtmlEditor(HtmlEditor.Config config)
        {
            return new HtmlEditor(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Field.Config 
        { 
			/*  Implicit HtmlEditor.Config Conversion to HtmlEditor.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HtmlEditor.Builder(HtmlEditor.Config config)
			{
				return new HtmlEditor.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string text = "";

			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}
        
			private HtmlEditorListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public HtmlEditorListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new HtmlEditorListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private HtmlEditorDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public HtmlEditorDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new HtmlEditorDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
			private XTemplate afterIFrameTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup after the iframe element. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate AfterIFrameTpl 
			{ 
				get
				{
					return this.afterIFrameTpl;
				}
				set
				{
					this.afterIFrameTpl = value;
				}
			}

			private XTemplate afterTextAreaTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup after the textarea element. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate AfterTextAreaTpl 
			{ 
				get
				{
					return this.afterTextAreaTpl;
				}
				set
				{
					this.afterTextAreaTpl = value;
				}
			}

			private XTemplate beforeIFrameTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup before the iframe element. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate BeforeIFrameTpl 
			{ 
				get
				{
					return this.beforeIFrameTpl;
				}
				set
				{
					this.beforeIFrameTpl = value;
				}
			}

			private XTemplate beforeTextAreaTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup before the textarea element. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate BeforeTextAreaTpl 
			{ 
				get
				{
					return this.beforeTextAreaTpl;
				}
				set
				{
					this.beforeTextAreaTpl = value;
				}
			}

			private string createLinkText = "";

			/// <summary>
			/// The default text for the create link prompt.
			/// </summary>
			[DefaultValue("")]
			public virtual string CreateLinkText 
			{ 
				get
				{
					return this.createLinkText;
				}
				set
				{
					this.createLinkText = value;
				}
			}

			private string defaultFont = "";

			/// <summary>
			/// The default font family (defaults to 'tahoma').
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultFont 
			{ 
				get
				{
					return this.defaultFont;
				}
				set
				{
					this.defaultFont = value;
				}
			}

			private string defaultLinkValue = "http://";

			/// <summary>
			/// The default value for the create link prompt (defaults to http://).
			/// </summary>
			[DefaultValue("http://")]
			public virtual string DefaultLinkValue 
			{ 
				get
				{
					return this.defaultLinkValue;
				}
				set
				{
					this.defaultLinkValue = value;
				}
			}

			private string defaultValue = "";

			/// <summary>
			/// A default value to be put into the editor to resolve focus issues (defaults to   (Non-breaking space) in Opera and IE6, ​ (Zero-width space) in all other browsers).
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultValue 
			{ 
				get
				{
					return this.defaultValue;
				}
				set
				{
					this.defaultValue = value;
				}
			}

			private bool enableAlignments = true;

			/// <summary>
			/// Enable the left, center, right alignment buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableAlignments 
			{ 
				get
				{
					return this.enableAlignments;
				}
				set
				{
					this.enableAlignments = value;
				}
			}

			private bool enableColors = true;

			/// <summary>
			/// Enable the fore/highlight color buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColors 
			{ 
				get
				{
					return this.enableColors;
				}
				set
				{
					this.enableColors = value;
				}
			}

			private bool enableFont = true;

			/// <summary>
			/// Enable font selection. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFont 
			{ 
				get
				{
					return this.enableFont;
				}
				set
				{
					this.enableFont = value;
				}
			}

			private bool enableFontSize = true;

			/// <summary>
			/// Enable the increase/decrease font size buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFontSize 
			{ 
				get
				{
					return this.enableFontSize;
				}
				set
				{
					this.enableFontSize = value;
				}
			}

			private bool enableFormat = true;

			/// <summary>
			/// Enable the bold, italic and underline buttons (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableFormat 
			{ 
				get
				{
					return this.enableFormat;
				}
				set
				{
					this.enableFormat = value;
				}
			}

			private bool enableLinks = true;

			/// <summary>
			/// Enable the create link button. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableLinks 
			{ 
				get
				{
					return this.enableLinks;
				}
				set
				{
					this.enableLinks = value;
				}
			}

			private bool enableLists = true;

			/// <summary>
			/// Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableLists 
			{ 
				get
				{
					return this.enableLists;
				}
				set
				{
					this.enableLists = value;
				}
			}

			private bool enableSourceEdit = true;

			/// <summary>
			/// Enable the switch to source edit button. Not available in Safari. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableSourceEdit 
			{ 
				get
				{
					return this.enableSourceEdit;
				}
				set
				{
					this.enableSourceEdit = value;
				}
			}

			private bool escapeValue = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EscapeValue 
			{ 
				get
				{
					return this.escapeValue;
				}
				set
				{
					this.escapeValue = value;
				}
			}

			private string[] fontFamilies = null;

			/// <summary>
			/// An array of available font families.
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] FontFamilies 
			{ 
				get
				{
					return this.fontFamilies;
				}
				set
				{
					this.fontFamilies = value;
				}
			}
        
			private HtmlEditorButtonTips buttonTips = null;

			/// <summary>
			/// 
			/// </summary>
			public HtmlEditorButtonTips ButtonTips
			{
				get
				{
					if (this.buttonTips == null)
					{
						this.buttonTips = new HtmlEditorButtonTips();
					}
			
					return this.buttonTips;
				}
			}
			
			private XTemplate iframeAttrTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup inside the iframe element (as attributes). If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate IframeAttrTpl 
			{ 
				get
				{
					return this.iframeAttrTpl;
				}
				set
				{
					this.iframeAttrTpl = value;
				}
			}

        }
    }
}