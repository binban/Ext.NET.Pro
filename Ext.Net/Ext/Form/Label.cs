/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Produces a standalone <label /> element which can be inserted into a form and be associated with a field in that form using the forId property.
    ///
    /// NOTE: in most cases it will be more appropriate to use the fieldLabel and associated config properties (Ext.form.Labelable.labelAlign, Ext.form.Labelable.labelWidth, etc.) in field components themselves, as that allows labels to be uniformly sized throughout the form. Ext.form.Label should only be used when your layout can not be achieved with the standard field layout.
    ///
    /// You will likely be associating the label with a field component that extends Ext.form.field.Base, so you should make sure the forId is set to the same value as the inputId of that field.
    ///
    /// The label's text can be set using either the text or html configuration properties; the difference between the two is that the former will automatically escape HTML characters when rendering, while the latter will not.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Label runat=\"server\" />")]
    [DefaultProperty("Html")]
    [ParseChildren(true, "Html")]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [ToolboxBitmap(typeof(Label), "Build.ToolboxIcons.Label.bmp")]
    [Description("Produces a standalone <label /> element which can be inserted into a form and be associated with a field in that form using the forId property.")]
    public partial class Label : LabelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Label() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Label(string text) 
        {
            this.Text = text;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Label(string format, string text)
        {
            this.Format = format;
            this.Text = text;
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
                return "Ext.net.Label";
            }
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
                return "netlabel";
            }
        }

        private AbstractComponentListeners listeners;

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
        public AbstractComponentListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new AbstractComponentListeners();
                }

                return this.listeners;
            }
        }

        private AbstractComponentDirectEvents directEvents;

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
        public AbstractComponentDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new AbstractComponentDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }
}