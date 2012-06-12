/********
 * @version   : 1.4.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A menu containing a Ext.menu.ColorItem component (which provides a basic color picker).
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("A menu containing a Ext.menu.ColorItem component (which provides a basic color picker).")]
    public partial class ColorMenu : MenuBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ColorMenu()
        {
            this.palette = new ColorPalette();
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
                return "colormenu";
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
                return "Ext.menu.ColorMenu";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Controls.Add(this.palette);
            this.LazyItems.Add(this.palette);
        }

        private ColorPalette palette;

        /// <summary>
        /// The ColorPalette object
        /// </summary>
        [Meta]
        [ConfigOption("palette", typeof(LazyControlJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The ColorPalette object")]
        public ColorPalette Palette
        {
            get
            {
                return this.palette;
            }
        }
        
        private ColorMenuListeners listeners;

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
        public ColorMenuListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ColorMenuListeners();
                }

                return this.listeners;
            }
        }

        private ColorMenuDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public ColorMenuDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ColorMenuDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}
