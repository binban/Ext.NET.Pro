/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class CommandColumn : ColumnBase, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CommandColumn() { }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "commandcolumn";
            }
        }

        /// <summary>
        /// (optional) Specify as false to prevent the user from hiding this column. Defaults to false.
        /// </summary>
        [ConfigOption]
        [Category("3. CommandColumn")]
        [DefaultValue(false)]
        [Description("(optional) Specify as false to prevent the user from hiding this column. Defaults to true.")]
        public override bool Hideable
        {
            get
            {
                return this.State.Get<bool>("Hideable", false);
            }
            set
            {
                this.State.Set("Hideable", value);
            }
        }

        /// <summary>
        /// True to disabled the column header menu containing sort/hide options. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to disabled the column header menu containing sort/hide options. Defaults to false.")]
        public override bool MenuDisabled
        {
            get
            {
                return this.State.Get<bool>("MenuDisabled", true);
            }
            set
            {
                this.State.Set("MenuDisabled", value);
            }
        }

        /// <summary>
        /// True to show toolbar for over row only
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CommandColumn")]
        [DefaultValue(false)]
        [Description("True to show toolbar for over row only")]
        public virtual bool OverOnly
        {
            get
            {
                return this.State.Get<bool>("OverOnly", false);
            }
            set
            {
                this.State.Set("OverOnly", value);
            }
        }

        /// <summary>
        /// Delay before showing over toolbar
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CommandColumn")]
        [DefaultValue(250)]
        [Description("Delay before showing over toolbar")]
        public virtual int ShowDelay
        {
            get
            {
                return this.State.Get<int>("ShowDelay", 250);
            }
            set
            {
                this.State.Set("ShowDelay", value);
            }
        }

        /// <summary>
        /// Delay before hide over toolbar
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. CommandColumn")]
        [DefaultValue(500)]
        [Description("Delay before hide over toolbar")]
        public virtual int HideDelay
        {
            get
            {
                return this.State.Get<int>("HideDelay", 500);
            }
            set
            {
                this.State.Set("HideDelay", value);
            }
        }
        
        private GridCommandCollection commands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("commands", JsonMode.AlwaysArray)]
        [Category("3. CommandColumn")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]        
        [Description("")]
        public virtual GridCommandCollection Commands
        {
            get
            {
                if (this.commands == null)
                {
                    this.commands = new GridCommandCollection();
                }

                return this.commands;
            }
        }

        private GridCommandCollection groupCommands;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("groupCommands", JsonMode.AlwaysArray)]
        [Category("3. CommandColumn")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]        
        [Description("")]
        public virtual GridCommandCollection GroupCommands
        {
            get
            {
                if (this.groupCommands == null)
                {
                    this.groupCommands = new GridCommandCollection();
                }

                return this.groupCommands;
            }
        }

        private void RegisterIcons(GridCommandCollection commands, List<Icon> icons)
        {
            foreach (GridCommandBase command in commands)
            {
                GridCommand cmd = command as GridCommand;

                if (cmd != null)
                {
                    if (cmd.Icon != Icon.None)
                    {
                        icons.Add(cmd.Icon);
                    }

                    if (cmd.Menu.Items.Count > 0)
                    {
                        this.RegisterMenuIcons(cmd.Menu, icons);
                    }
                }
            }
        }

        private void RegisterMenuIcons(CommandMenu menu, List<Icon> icons)
        {
            foreach (MenuCommand menuCommand in menu.Items)
            {
                if (menuCommand.Icon != Icon.None)
                {
                    icons.Add(menuCommand.Icon);
                }

                if (menuCommand.Menu.Items.Count > 0)
                {
                    this.RegisterMenuIcons(menuCommand.Menu, icons);
                }
            }
        }

        private JFunction prepareToolbar;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. CommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareToolbar
        {
            get
            {
                if (this.prepareToolbar == null)
                {
                    this.prepareToolbar = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareToolbar.Args = new string[] { "grid", "toolbar", "rowIndex", "record" };
                    }
                    
                }

                return this.prepareToolbar;
            }
        }

        private JFunction prepareGroupToolbar;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. CommandColumn")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction PrepareGroupToolbar
        {
            get
            {
                if (this.prepareGroupToolbar == null)
                {
                    this.prepareGroupToolbar = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.prepareGroupToolbar.Args = new string[] {"grid", "toolbar", "groupId", "records"};
                    }
                }

                return this.prepareGroupToolbar;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public System.Collections.Generic.List<Icon> Icons
        {
            get 
            {
                List<Icon> icons = new List<Icon>();
                
                RegisterIcons(this.Commands, icons);
                RegisterIcons(this.GroupCommands, icons);

                return icons;
            }
        }

        /// <summary>
        /// Valid values are "start", "center" and "end" (defaults to "start").
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. CommandColumn")]
        [DefaultValue(BoxPack.Start)]
        [NotifyParentProperty(true)]
        [Description("Valid values are \"start\", \"center\" and \"end\" (defaults to \"start\").")]
        public virtual BoxPack Pack
        {
            get
            {
                return this.State.Get<BoxPack>("ButtonAlign", BoxPack.Start);
            }
            set
            {
                this.State.Set("ButtonAlign", value);
            }
        }

        private ImageCommandColumnListeners listeners;

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
        public ImageCommandColumnListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ImageCommandColumnListeners();
                }

                return this.listeners;
            }
        }

        private ImageCommandColumnDirectEvents directEvents;

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
        public ImageCommandColumnDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ImageCommandColumnDirectEvents(this);
                }

                return this.directEvents;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class GridCommandBase : BaseItem { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class GridCommandCollection : BaseItemCollection<GridCommandBase> { }
}