/********
 * @version   : 2.0.0.beta3 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-05-28
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:MenuPanel runat=\"server\" Title=\"Menu\" Height=\"300\" Width=\"185\"><Menu><Items><ext:MenuItem runat=\"server\" Text=\"Item1\"><Menu><ext:Menu runat=\"server\"><Items><ext:MenuItem runat=\"server\" Text=\"SubItem1\" /><ext:MenuItem runat=\"server\" Text=\"SubItem2\" /></Items></ext:Menu></Menu></ext:MenuItem><ext:MenuItem runat=\"server\" Text=\"Item2\" /><ext:MenuItem runat=\"server\" Text=\"Item3\" /><ext:MenuItem runat=\"server\" Text=\"Item4\" /></Items></Menu></{0}:MenuPanel>")]
    [ToolboxBitmap(typeof(MenuPanel), "Build.ToolboxIcons.MenuPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class MenuPanel : AbstractPanel
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public MenuPanel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "netmenupanel";
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
                return "Ext.net.MenuPanel";
            }
        }

        private static readonly object EventSelectedItemChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("Fires when the selected Item has been changed")]
        public event EventHandler SelectedItemChanged
        {
            add
            {
                Events.AddHandler(EventSelectedItemChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventSelectedItemChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSelectedItemChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventSelectedItemChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            if (this.baseLoadPostData)
            {
                base.RaisePostDataChangedEvent();    
            }
            
            if (this.thisLoadPostData)
            {
                this.OnSelectedItemChanged(EventArgs.Empty);
            }
        }

        private bool baseLoadPostData;
        private bool thisLoadPostData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.baseLoadPostData = base.LoadPostData(postDataKey, postCollection);

            string index = postCollection[this.ConfigID.ConcatWith("_SelIndex")] ?? "";

            if (index.IsNotEmpty())
            {
                try
                {
                    this.SuspendScripting();
                    int tmpIndex;

                    if (int.TryParse(index, out tmpIndex))
                    {
                        if (tmpIndex != this.SelectedIndex)
                        {
                            this.SelectedIndex = tmpIndex;
                            this.thisLoadPostData = true;
                            return true;
                        }
                    }
                }
                finally
                {
                    this.ResumeScripting();
                }
            }

            return this.baseLoadPostData;
        }

        /// <summary>
        /// Items Collection
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public override ItemsCollection<AbstractComponent> Items
        {
            get
            {
                return base.Items;
            }
        }
        
        private Menu menu;

        /// <summary>
        /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
        /// </summary>
        [Meta]
        [ConfigOption("menu", typeof(LazyControlJsonConverter))]
        [Category("7. MenuPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob")]
        public virtual Menu Menu
        {
            get
            {
                if (this.menu == null)
                {
                    this.menu = new Menu();
                    this.Controls.Add(this.menu);
                    this.LazyItems.Add(this.menu);
                    this.menu.Floating = false;
                    this.menu.RenderEmptyMenu = true;
                }

                return this.menu;
            }
        }

        /// <summary>
        /// Save selection after click
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. MenuPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Save selection after click")]
        public virtual bool SaveSelection
        {
            get
            {
                return this.State.Get<bool>("SaveSelection", true);
            }
            set
            {
                this.State.Set("SaveSelection", value);
            }
        }

        /// <summary>
        /// Index of selected item
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetSelectedIndex")]
        [Category("7. MenuPanel")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("Index of selected item")]
        public virtual int SelectedIndex
        {
            get
            {
                return this.State.Get<int>("SelectedIndex", -1);
            }
            set
            {
                this.State.Set("SelectedIndex", value);
            }
        }

        private PanelListeners listeners;

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
        public PanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PanelListeners();
                }

                return this.listeners;
            }
        }

        private PanelDirectEvents directEvents;

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
        public PanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PanelDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("")]
        public void SetSelectedIndex(int index)
        {
            this.Call("setSelectedIndex", index);
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void ClearSelection()
        {
            this.Call("clearSelection");
        }
    }
}