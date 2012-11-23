/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A simple class that provides the basic implementation needed to make any element a drop target that can have draggable items dropped onto it. The drop has no effect until an implementation of notifyDrop is provided.
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DropTarget runat=\"server\"></{0}:DropTarget>")]
    [ToolboxBitmap(typeof(DropTarget), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A simple class that provides the basic implementation needed to make any element a drop target that can have draggable items dropped onto it. The drop has no effect until an implementation of notifyDrop is provided.")]
    public partial class DropTarget : DDTarget
    {
        /// <summary>
        /// 
        /// </summary>
        public DropTarget()
        {
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
                return "Ext.dd.DropTarget";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript(Control owner)
        {
            string script = "new Ext.net.ProxyDDCreator({{target: {0}, config: {1}, type: {2}}}){3}".FormatWith(
                      this.ParsedTarget,
                      new ClientConfig().Serialize(this, true),
                      this.InstanceOf,
                      this.IsLazy ? "" : ";"
                   );

            return this.IsIdRequired ? string.Concat("window.", this.ClientID, "=", script) : script;
        }

        /// <summary>
        /// A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption("ddGroup")]
        [Category("5. DropTarget")]
        [DefaultValue("")]
        [Description("A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).")]
        public override string Group
        {
            get
            {
                return this.State.Get<string>("Group", "");
            }
            set
            {
                this.State.Set("Group", value);
            }
        }

        /// <summary>
        /// The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue("x-dd-drop-ok")]
        [Description("The CSS class returned to the drag source when drop is allowed (defaults to \"x-dd-drop-ok\").")]
        public virtual string DropAllowed
        {
            get
            {
                return this.State.Get<string>("DropAllowed", "x-dd-drop-ok");
            }
            set
            {
                this.State.Set("DropAllowed", value);
            }
        }

        /// <summary>
        /// The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue("x-dd-drop-nodrop")]
        [Description("The CSS class returned to the drag source when drop is not allowed (defaults to \"x-dd-drop-nodrop\").")]
        public virtual string DropNotAllowed
        {
            get
            {
                return this.State.Get<string>("DropNotAllowed", "x-dd-drop-nodrop");
            }
            set
            {
                this.State.Set("DropNotAllowed", value);
            }
        }

        /// <summary>
        /// The CSS class applied to the drop target element while the drag source is over it (defaults to "").
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue("")]
        [Description("The CSS class applied to the drop target element while the drag source is over it (defaults to \"\").")]
        public virtual string OverClass
        {
            get
            {
                return this.State.Get<string>("OverClass", "");
            }
            set
            {
                this.State.Set("OverClass", value);
            }
        }

        /// <summary>
        /// True to register this container with the Scrollmanager for auto scrolling during drag operations.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DropTarget")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to register this container with the Scrollmanager for auto scrolling during drag operations.")]
        public virtual bool ContainerScroll
        {
            get
            {
                return this.State.Get<bool>("ContainerScroll", false);
            }
            set
            {
                this.State.Set("ContainerScroll", value);
            }
        }

        private JFunction notifyDrop;

        /// <summary>
        /// The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.")]
        public virtual JFunction NotifyDrop
        {
            get
            {
                if (this.notifyDrop == null)
                {
                    this.notifyDrop = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyDrop.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyDrop;
            }
        }

        private JFunction notifyEnter;

        /// <summary>
        /// The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.")]
        public virtual JFunction NotifyEnter
        {
            get
            {
                if (this.notifyEnter == null)
                {
                    this.notifyEnter = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyEnter.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyEnter;
            }
        }

        private JFunction notifyOut;

        /// <summary>
        /// The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.")]
        public virtual JFunction NotifyOut
        {
            get
            {
                if (this.notifyOut == null)
                {
                    this.notifyOut = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyOut.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyOut;
            }
        }

        private JFunction notifyOver;

        /// <summary>
        /// The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.
        /// Parameters:
        ///    source : The drag source that was dragged over this drop target
        ///    e : The event
        ///    data : An object containing arbitrary data supplied by the drag source
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DropTarget")]
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.")]
        public virtual JFunction NotifyOver
        {
            get
            {
                if (this.notifyOver == null)
                {
                    this.notifyOver = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.notifyOver.Args = new string[] {"source", "e", "data"};
                    }
                }

                return this.notifyOver;
            }
        }
    }
}