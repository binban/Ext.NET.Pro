/********
 * @version   : 1.5.0 - Ext.NET Pro License
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
    /// Provides editor functionality for inline tree node editing. Any valid Ext.form.Field subclass can be used as the editor field.
    /// </summary>
    [ToolboxData("<{0}:TreeEditor runat=\"server\" />")]
    [ToolboxBitmap(typeof(Editor), "Build.ToolboxIcons.Editor.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Provides editor functionality for inline tree node editing. Any valid Ext.form.Field subclass can be used as the editor field.")]
    public partial class TreeEditor : Editor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.ViewState["LazyMode"] == null)
            {
                this.LazyMode = LazyMode.Config;
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
                return "treeeditor";
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
                return "Ext.net.TreeEditor";
            }
        }

        /// <summary>
        /// The number of milliseconds between clicks to register a double-click that will trigger editing on the current node (defaults to 350). If two clicks occur on the same node within this time span, the editor for the node will display, otherwise it will be processed as a regular click.
        /// </summary>
        [ConfigOption]
        [Category("5. TreeEditor")]
        [DefaultValue(350)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds between clicks to register a double-click that will trigger editing on the current node (defaults to 350). If two clicks occur on the same node within this time span, the editor for the node will display, otherwise it will be processed as a regular click.")]
        public virtual int EditDelay
        {
            get
            {
                object obj = this.ViewState["EditDelay"];
                return (obj == null) ? 350 : (int)obj;
            }
            set
            {
                this.ViewState["EditDelay"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("5. TreeEditor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool AutoEdit
        {
            get
            {
                object obj = this.ViewState["AutoEdit"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoEdit"] = value;
            }
        }

        /// <summary>
        /// False to keep the bound element visible while the editor is displayed (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("5. TreeEditor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to keep the bound element visible while the editor is displayed (defaults to false)")]
        public override bool HideEl
        {
            get
            {
                object obj = this.ViewState["HideEl"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideEl"] = value;
            }
        }

        /// <summary>
        /// The maximum width in pixels of the editor field (defaults to 250). Note that if the maxWidth would exceed the containing tree element's size, it will be automatically limited for you to the container width, taking scroll and client offsets into account prior to each edit.
        /// </summary>
        [ConfigOption]
        [Category("5. TreeEditor")]
        [DefaultValue(250)]
        [NotifyParentProperty(true)]
        [Description("The maximum width in pixels of the editor field (defaults to 250). Note that if the maxWidth would exceed the containing tree element's size, it will be automatically limited for you to the container width, taking scroll and client offsets into account prior to each edit.")]
        public virtual int MaxWidth
        {
            get
            {
                object obj = this.ViewState["MaxWidth"];
                return (obj == null) ? 250 : (int)obj;
            }
            set
            {
                this.ViewState["MaxWidth"] = value;
            }
        }

        /// <summary>
        /// True to shim the editor if selects/iframes could be displayed beneath it (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("5. TreeEditor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to shim the editor if selects/iframes could be displayed beneath it (defaults to false)")]
        public virtual bool Shim
        {
            get
            {
                object obj = this.ViewState["Shim"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Shim"] = value;
            }
        }

        /// <summary>
        /// The tree panel to use.
        /// </summary>
        [ConfigOption("tree", JsonMode.ToClientID)]
        [Category("5. TreeEditor")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(TreePanel))]
        [Description("The tree panel to use.")]
        public virtual string TreePanelID
        {
            get
            {
                return (string)this.ViewState["TreePanelID"] ?? "";
            }
            set
            {
                this.ViewState["TreePanelID"] = value;
            }
        }

        private TreeEditorFilter filter;

        /// <summary>
        /// The tree editor filter to edit particular nodes
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Category("5. TreeEditor")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The tree editor filter to edit particular nodes")]
        public virtual TreeEditorFilter Filter
        {
            get
            {
                if (this.filter == null)
                {
                    this.filter = new TreeEditorFilter();
                }

                return this.filter;
            }
        }

        /// <summary>
        /// Handle the keydown/keypress events so they don't propagate (defaults to true)
        /// </summary>
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to update the innerHTML of the bound element when the update completes (defaults to false)")]
        public override bool UpdateEl
        {
            get
            {
                object obj = this.ViewState["UpdateEl"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["UpdateEl"] = value;
            }
        }
    }
}