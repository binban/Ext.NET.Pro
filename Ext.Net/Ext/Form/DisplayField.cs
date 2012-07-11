/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A display-only text field which is not validated and not submitted. This is useful for when you want to display a value from a form's loaded data but do not want to allow the user to edit or submit that value. The value can be optionally HTML encoded if it contains HTML markup that you do not want to be rendered.
    ///
    /// If you have more complex content, or need to include components within the displayed content, also consider using a Ext.form.FieldContainer instead.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DisplayField runat=\"server\" />")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(DisplayField), "Build.ToolboxIcons.DisplayField.bmp")]
    [Description("A display-only text field which is not validated and not submitted.")]
    public partial class DisplayField : Field
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DisplayField() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "displayfield";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.field.Display";
            }
        }

        /// <summary>
        /// The default CSS class for the field (defaults to "x-form-display-field")
        /// </summary>
        [ConfigOption]
        [Category("6. DisplayField")]
        [DefaultValue("x-form-display-field")]
        [Localizable(true)]
        [Description("The default CSS class for the field (defaults to 'x-form-display-field')")]
        public override string FieldCls
        {
            get
            {
                return this.State.Get<string>("FieldCls", "x-form-display-field");
            }
            set
            {
                this.State.Set("FieldCls", value);
            }
        }
        
        /// <summary>
        /// True to escape HTML in text when rendering it.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetHtmlEncode")]
        [ConfigOption]
        [Category("6. DisplayField")]
        [DefaultValue(false)]
        [Description("True to escape HTML in text when rendering it.")]
        public virtual bool HtmlEncode
        {
            get
            {
                return this.State.Get<bool>("HtmlEncode", false);
            }
            set
            {
                this.State.Set("HtmlEncode", value);
            }
        }

        /// <summary>
        /// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
        /// </summary>
        [Meta]
        [ConfigOption("value")]
        [DirectEventUpdate(MethodName = "SetValue")]
        [Localizable(true)]
        [Category("6. DisplayField")]
        [DefaultValue("")]
        [Description("The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.")]
        public virtual string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        private JFunction renderer;

        /// <summary>   
        /// A function to transform the raw value for display in the field. The function will receive 2 arguments, the raw value and the Ext.form.field.Display object.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("6. DisplayField")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("A function to transform the raw value for display in the field. The function will receive 2 arguments, the raw value and the Ext.form.field.Display object.")]
        public virtual JFunction Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new JFunction();
                    if(!this.DesignMode)
                    {
                        this.renderer.Args = new string[] { "value", "field" };
                    }
                }

                return this.renderer;
            }
        }

        private FieldListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]        
        [Description("Client-side JavaScript Event Handlers")]
        public FieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FieldListeners();
                }

                return this.listeners;
            }
        }

        private FieldDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]        
        [Description("Server-side Ajax Event Handlers")]
        public FieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Appends the specified string to the DisplayField's value.
        /// </summary>
        /// <param name="text">A string to append</param>
        [Description("Appends the specified string to the DisplayField's value.")]
        public virtual void Append(string text)
        {
            this.Call("append", text);
        }

        /// <summary>
        /// Appends the specified string and a new line to the DisplayField's value.
        /// </summary>
        /// <param name="text">A string to append</param>
        [Description("Appends the specified string and a new line to the DisplayField's value.")]
        public virtual void AppendLine(string text)
        {
            this.Call("appendLine", text);
        }

        /// <summary>
        /// false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.
        /// </summary>
        /// <seealso cref="HtmlEncode" />
        [Description("false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.")]
        protected virtual void SetHtmlEncode(bool encode)
        {
            this.Set("htmlEncode", encode);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        /// <seealso cref="HtmlEncode" />
        [Description("Updates the DisplayField's innerHTML with the specified string.")]
        protected virtual void SetText(string text)
        {
            this.Call("setValue", text);
        }
    }
}