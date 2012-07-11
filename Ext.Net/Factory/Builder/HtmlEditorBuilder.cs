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
    public partial class HtmlEditor
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Field.Builder<HtmlEditor, HtmlEditor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HtmlEditor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HtmlEditor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HtmlEditor.Config config) : base(new HtmlEditor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HtmlEditor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual HtmlEditor.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as HtmlEditor.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(EditorListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(EditorDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The default text for the create link prompt.
			/// </summary>
            public virtual HtmlEditor.Builder CreateLinkText(string createLinkText)
            {
                this.ToComponent().CreateLinkText = createLinkText;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// The default font family (defaults to 'tahoma').
			/// </summary>
            public virtual HtmlEditor.Builder DefaultFont(string defaultFont)
            {
                this.ToComponent().DefaultFont = defaultFont;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// The default value for the create link prompt (defaults to http://).
			/// </summary>
            public virtual HtmlEditor.Builder DefaultLinkValue(string defaultLinkValue)
            {
                this.ToComponent().DefaultLinkValue = defaultLinkValue;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the left, center, right alignment buttons (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableAlignments(bool enableAlignments)
            {
                this.ToComponent().EnableAlignments = enableAlignments;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the fore/highlight color buttons (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableColors(bool enableColors)
            {
                this.ToComponent().EnableColors = enableColors;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable font selection. Not available in Safari. (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableFont(bool enableFont)
            {
                this.ToComponent().EnableFont = enableFont;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the increase/decrease font size buttons (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableFontSize(bool enableFontSize)
            {
                this.ToComponent().EnableFontSize = enableFontSize;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the bold, italic and underline buttons (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableFormat(bool enableFormat)
            {
                this.ToComponent().EnableFormat = enableFormat;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the create link button. Not available in Safari. (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableLinks(bool enableLinks)
            {
                this.ToComponent().EnableLinks = enableLinks;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableLists(bool enableLists)
            {
                this.ToComponent().EnableLists = enableLists;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// Enable the switch to source edit button. Not available in Safari. (defaults to true).
			/// </summary>
            public virtual HtmlEditor.Builder EnableSourceEdit(bool enableSourceEdit)
            {
                this.ToComponent().EnableSourceEdit = enableSourceEdit;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HtmlEditor.Builder EscapeValue(bool escapeValue)
            {
                this.ToComponent().EscapeValue = escapeValue;
                return this as HtmlEditor.Builder;
            }
             
 			/// <summary>
			/// An array of available font families.
			/// </summary>
            public virtual HtmlEditor.Builder FontFamilies(string[] fontFamilies)
            {
                this.ToComponent().FontFamilies = fontFamilies;
                return this as HtmlEditor.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Protected method that will not generally be called directly. If you need/want custom HTML cleanup, this is the method you should override.
			/// </summary>
            public virtual HtmlEditor.Builder CleanHtml(string html)
            {
                this.ToComponent().CleanHtml(html);
                return this;
            }
            
 			/// <summary>
			/// Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.
			/// </summary>
            public virtual HtmlEditor.Builder ExecCmd(string cmd, string value)
            {
                this.ToComponent().ExecCmd(cmd, value);
                return this;
            }
            
 			/// <summary>
			/// Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.
			/// </summary>
            public virtual HtmlEditor.Builder ExecCmd(string cmd, bool value)
            {
                this.ToComponent().ExecCmd(cmd, value);
                return this;
            }
            
 			/// <summary>
			/// Executes a Midas editor command directly on the editor document. For visual commands, you should use relayCmd instead. This should only be called after the editor is initialized.
			/// </summary>
            public virtual HtmlEditor.Builder InsertAtCursor(string text)
            {
                this.ToComponent().InsertAtCursor(text);
                return this;
            }
            
 			/// <summary>
			/// Protected method that will not generally be called directly. Pushes the value of the textarea into the iframe editor.
			/// </summary>
            public virtual HtmlEditor.Builder PushValue()
            {
                this.ToComponent().PushValue();
                return this;
            }
            
 			/// <summary>
			/// Executes a Midas editor command on the editor document and performs necessary focus and toolbar updates. This should only be called after the editor is initialized.
			/// </summary>
            public virtual HtmlEditor.Builder RelayCmd(string cmd, string value)
            {
                this.ToComponent().RelayCmd(cmd, value);
                return this;
            }
            
 			/// <summary>
			/// Executes a Midas editor command on the editor document and performs necessary focus and toolbar updates. This should only be called after the editor is initialized.
			/// </summary>
            public virtual HtmlEditor.Builder RelayCmd(string cmd, bool value)
            {
                this.ToComponent().RelayCmd(cmd, value);
                return this;
            }
            
 			/// <summary>
			/// Protected method that will not generally be called directly. Syncs the contents of the editor iframe with the textarea.
			/// </summary>
            public virtual HtmlEditor.Builder SyncValue()
            {
                this.ToComponent().SyncValue();
                return this;
            }
            
 			/// <summary>
			/// Toggles the editor between standard and source edit mode.
			/// </summary>
            public virtual HtmlEditor.Builder ToggleSourceEdit()
            {
                this.ToComponent().ToggleSourceEdit();
                return this;
            }
            
 			/// <summary>
			/// Toggles the editor between standard and source edit mode.
			/// </summary>
            public virtual HtmlEditor.Builder ToggleSourceEdit(bool sourceEdit)
            {
                this.ToComponent().ToggleSourceEdit(sourceEdit);
                return this;
            }
            
 			/// <summary>
			/// Protected method that will not generally be called directly. It triggers a toolbar update by reading the markup state of the current selection in the editor.
			/// </summary>
            public virtual HtmlEditor.Builder UpdateToolbar()
            {
                this.ToComponent().UpdateToolbar();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HtmlEditor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HtmlEditor.Builder HtmlEditor()
        {
            return this.HtmlEditor(new HtmlEditor());
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditor.Builder HtmlEditor(HtmlEditor component)
        {
            return new HtmlEditor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlEditor.Builder HtmlEditor(HtmlEditor.Config config)
        {
            return new HtmlEditor.Builder(new HtmlEditor(config));
        }
    }
}