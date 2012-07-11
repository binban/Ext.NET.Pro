/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Multiline text field. Can be used as a direct replacement for traditional textarea &lt;asp:TextBox TextMode='MultiLine'> fields, plus adds support for auto-sizing.
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
    [Designer(typeof(TextAreaDesigner))]
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
                return "textarea";
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
                return "Ext.form.TextArea";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.AutoPostBack)
            {
                this.On("change", new JFunction(this.PostBackFunction));
            }
        }

        /// <summary>
        /// The maximum width to allow when grow = true (defaults to 800).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(typeof(Unit), "1000")]
        [Description("The maximum width to allow when grow = true (defaults to 800).")]
        public override Unit GrowMax
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["GrowMax"], Unit.Pixel(1000), "GrowMax");
            }
            set
            {
                this.ViewState["GrowMax"] = value;
            }
        }

        /// <summary>
        /// The minimum width to allow when grow = true (defaults to 60).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(typeof(Unit), "60")]
        [Description("The minimum width to allow when grow = true (defaults to 60).")]
        public override Unit GrowMin
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["GrowMin"], Unit.Pixel(60), "GrowMin");
            }
            set
            {
                this.ViewState["GrowMin"] = value;
            }
        }

        /// <summary>
        /// True to prevent scrollbars from appearing regardless of how much text is in the field (equivalent to setting overflow: hidden, defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TextArea")]
        [DefaultValue(false)]
        [Description("True to prevent scrollbars from appearing regardless of how much text is in the field (equivalent to setting overflow: hidden, defaults to false).")]
        public virtual bool PreventScrollbars
        {
            get
            {
                object obj = this.ViewState["PreventScrollbars"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PreventScrollbars"] = value;
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
        [ViewStateMember]
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
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public TextFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TextFieldDirectEvents();
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