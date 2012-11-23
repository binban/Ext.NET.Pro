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
    public partial class FileUploadField
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TFileUploadField, TBuilder> : TextFieldBase.Builder<TFileUploadField, TBuilder>
            where TFileUploadField : FileUploadField
            where TBuilder : Builder<TFileUploadField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TFileUploadField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A standard Ext.button.Button config object.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Button(Action<Button> action)
            {
                action(this.ToComponent().Button);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for buttonConfig, the buttonConfig.text value will be used instead if available.
			/// </summary>
            public virtual TBuilder ButtonText(string buttonText)
            {
                this.ToComponent().ButtonText = buttonText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the file upload field as a button with no visible text field (defaults to false). If true, all inherited Text members will still be available.
			/// </summary>
            public virtual TBuilder ButtonOnly(bool buttonOnly)
            {
                this.ToComponent().ButtonOnly = buttonOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of pixels of space reserved between the button and the text field (defaults to 3). Note that this only applies if buttonOnly = false.
			/// </summary>
            public virtual TBuilder ButtonMargin(int buttonMargin)
            {
                this.ToComponent().ButtonMargin = buttonMargin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<FileUploadFieldListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side Ajax Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<FileUploadFieldDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : FileUploadField.Builder<FileUploadField, FileUploadField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new FileUploadField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FileUploadField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(FileUploadField.Config config) : base(new FileUploadField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(FileUploadField component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.FileUploadField(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField()
        {
#if MVC
			return this.FileUploadField(new FileUploadField { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.FileUploadField(new FileUploadField());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField(FileUploadField component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new FileUploadField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public FileUploadField.Builder FileUploadField(FileUploadField.Config config)
        {
#if MVC
			return new FileUploadField.Builder(new FileUploadField(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new FileUploadField.Builder(new FileUploadField(config));
#endif			
        }
    }
}