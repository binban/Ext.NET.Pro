/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// This class creates a multiline text field, which can be used as a direct replacement for traditional textarea fields. In addition, it supports automatically growing the height of the textarea to fit its content.
    /// All of the configuration options from Ext.form.field.Text can be used on TextArea.
    /// Some other useful configuration options when using grow are growMin and growMax. These allow you to set the minimum and maximum grow heights for the textarea.
    /// Can be used as a direct replacement for traditional textarea &lt;asp:TextBox TextMode='MultiLine'> fields, plus adds support for auto-sizing.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TextArea runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("TextChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Text")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(TextArea), "Build.ToolboxIcons.TextArea.bmp")]
    [Description("Multiline text field. Can be used as a direct replacement for traditional textarea <asp:TextBox TextMode='MultiLine'> fields, plus adds support for auto-sizing.")]
    public partial class TextArea : TextFieldBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TextArea() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TextArea(string text) 
        {
            this.Text = text;
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "textareafield";
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
                return "Ext.form.field.TextArea";
            }
        }

        /// <summary>
        /// An initial value for the 'cols' attribute on the textarea element. This is only used if the component has no configured width and is not given a width by its container's layout. Defaults to 4.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(20)]
        [Description("An initial value for the 'cols' attribute on the textarea element. This is only used if the component has no configured width and is not given a width by its container's layout. Defaults to 4.")]
        public virtual int Cols
        {
            get
            {
                return this.State.Get<int>("Cols", 20);
            }
            set
            {
                this.State.Set("Cols", value);
            }
        }

        /// <summary>
        /// True if you want the ENTER key to be classed as a special key and the specialkey event to be fired when ENTER is pressed. Defaults to: false
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(false)]
        [Description("True if you want the ENTER key to be classed as a special key and the specialkey event to be fired when ENTER is pressed. Defaults to: false")]
        public virtual bool EnterIsSpecial
        {
            get
            {
                return this.State.Get<bool>("EnterIsSpecial", false);
            }
            set
            {
                this.State.Set("EnterIsSpecial", value);
            }
        }

        /// <summary>
        /// A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a newline for TextArea to ensure there is always a space below the current line.
        /// </summary>
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue("")]
        [Description("A string that will be appended to the field's current value for the purposes of calculating the target field size. Only used when the grow config is true. Defaults to a newline for TextArea to ensure there is always a space below the current line.")]
        public override string GrowAppend
        {
            get
            {
                return this.State.Get<string>("GrowAppend", "");
            }
            set
            {
                this.State.Set("GrowAppend", value);
            }
        }

        /// <summary>
        /// The maximum height to allow when grow=true (defaults to 1000)
        /// </summary>
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(typeof(Unit), "1000")]
        [Description("The maximum height to allow when grow=true (defaults to 1000)")]
        public override Unit GrowMax
        {
            get
            {
                return this.UnitPixelTypeCheck(State["GrowMax"], Unit.Pixel(1000), "GrowMax");
            }
            set
            {
                this.State.Set("GrowMax", value);
            }
        }

        /// <summary>
        /// The minimum height to allow when grow=true (defaults to 60)
        /// </summary>
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(typeof(Unit), "60")]
        [Description("The minimum height to allow when grow=true (defaults to 60)")]
        public override Unit GrowMin
        {
            get
            {
                return this.UnitPixelTypeCheck(State["GrowMin"], Unit.Pixel(60), "GrowMin");
            }
            set
            {
                this.State.Set("GrowMin", value);
            }
        }

        /// <summary>
        /// true to prevent scrollbars from appearing regardless of how much text is in the field. This option is only relevant when grow is true. Equivalent to setting overflow: hidden, defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(false)]
        [Description("true to prevent scrollbars from appearing regardless of how much text is in the field. This option is only relevant when grow is true. Equivalent to setting overflow: hidden, defaults to false.")]
        public virtual bool PreventScrollbars
        {
            get
            {
                return this.State.Get<bool>("PreventScrollbars", false);
            }
            set
            {
                this.State.Set("PreventScrollbars", value);
            }
        }

        /// <summary>
        /// An initial value for the 'rows' attribute on the textarea element. This is only used if the component has no configured height and is not given a height by its container's layout. Defaults to 4.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(4)]
        [Description("An initial value for the 'rows' attribute on the textarea element. This is only used if the component has no configured height and is not given a height by its container's layout. Defaults to 4.")]
        public virtual int Rows
        {
            get
            {
                return this.State.Get<int>("Rows", 4);
            }
            set
            {
                this.State.Set("Rows", value);
            }
        }

        private TextFieldListeners listeners;

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
        public TextFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TextFieldListeners();
                }

                return this.listeners;
            }
        }

        private TextFieldDirectEvents directEvents;

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
        public TextFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TextFieldDirectEvents(this);
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Appends the specified string to the TextArea's value.
        /// </summary>
        /// <param name="text">A string to append</param>
        [Description("Appends the specified string to the TextArea's value.")]
        public virtual void Append(string text)
        {
            this.Call("append", text);
        }

        /// <summary>
        /// Appends the specified string and a new line to the TextArea's value.
        /// </summary>
        /// <param name="text">A string to append</param>
        [Description("Appends the specified string and a new line to the TextArea's value.")]
        public virtual void AppendLine(string text)
        {
            this.Call("appendLine", text);
        }
    }
}