/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public abstract partial class EventWindowBase : AbstractWindow
    {
        /// <summary>
        /// The title during event adding
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventWindow")]
        [DefaultValue("Add Event")]
        [NotifyParentProperty(true)]
        [Description("The title during event adding")]
        public virtual string TitleTextAdd
        {
            get
            {
                return (string)this.ViewState["TitleTextAdd"] ?? "Add Event";
            }
            set
            {
                this.ViewState["TitleTextAdd"] = value;
            }
        }

        /// <summary>
        /// The title during event editing
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventWindow")]
        [DefaultValue("Edit Event")]
        [NotifyParentProperty(true)]
        [Description("The title during event editing")]
        public virtual string TitleTextEdit
        {
            get
            {
                return (string)this.ViewState["TitleTextEdit"] ?? "Edit Event";
            }
            set
            {
                this.ViewState["TitleTextEdit"] = value;
            }
        }

        /// <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetWidth")]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "600")]
        [Description("The width of this component in pixels (defaults to auto).")]
        public override Unit Width
        {
            get
            {
                Unit width = this.UnitPixelTypeCheck(ViewState["Width"], Unit.Pixel(600), "Width");
                return width;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventWindow")]
        [DefaultValue("Deleting event...")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DeletingMessage
        {
            get
            {
                return (string)this.ViewState["DeletingMessage"] ?? "Deleting event...";
            }
            set
            {
                this.ViewState["DeletingMessage"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventWindow")]
        [DefaultValue("Saving changes...")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string SavingMessage
        {
            get
            {
                return (string)this.ViewState["SavingMessage"] ?? "Saving changes...";
            }
            set
            {
                this.ViewState["SavingMessage"] = value;
            }
        }

        /// <summary>
        /// True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).")]
        public override bool Resizable
        {
            get
            {
                object obj = this.ViewState["Resizable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Resizable"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. EventEditForm")]
        [DefaultValue(Alignment.Left)]
        [NotifyParentProperty(true)]
        public override Alignment ButtonAlign
        {
            get
            {
                object obj = this.ViewState["ButtonAlign"];
                return (obj == null) ? Alignment.Left : (Alignment)obj;
            }
            set
            {
                this.ViewState["ButtonAlign"] = value;
            }
        }
        
        /// <summary>
        /// The calendar store ID to use.
        /// </summary>
        [Meta]
        [ConfigOption("calendarStore", JsonMode.ToClientID)]
        [Category("8. EventWindow")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The calendar store ID to use.")]
        public virtual string CalendarStoreID
        {
            get
            {
                return (string)this.ViewState["CalendarStoreID"] ?? "";
            }
            set
            {
                this.ViewState["CalendarStoreID"] = value;
            }
        }

        /// <summary>
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The height of this component in pixels (defaults to auto).")]
        public override Unit Height
        {
            get
            {
                Unit height = this.UnitPixelTypeCheck(ViewState["Height"], Unit.Empty, "Height");
                return height;
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="record">record</param>
        public void Show(ModelProxy record)
        {
            this.Call("show", JRawValue.From(record.ModelInstance));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="o">Plain object containing a StartDate property (and optionally an EndDate property) for showing the form in add mode.</param>
        public void Show(JsonObject obj)
        {
            this.Call("show", obj);
        }
    }
}