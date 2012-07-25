/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    /// ToolTip is a Ext.tip.Tip implementation that handles the common case of displaying a tooltip when hovering over a certain element or elements on the page. It allows fine-grained control over the tooltip's alignment relative to the target element or mouse, and the timing of when it is automatically shown and hidden.
    /// This implementation does not have a built-in method of automatically populating the tooltip's text based on the target element; you must either configure a fixed html value for each ToolTip instance, or implement custom logic (e.g. in a beforeshow event listener) to generate the appropriate tooltip content on the fly. See Ext.tip.QuickTip for a more convenient way of automatically populating and configuring a tooltip based on specific DOM attributes of each target element.
    /// 
    /// Delegation
    /// In addition to attaching a ToolTip to a single element, you can also use delegation to attach one ToolTip to many elements under a common parent. This is more efficient than creating many ToolTip instances. To do this, point the target config to a common ancestor of all the elements, and then set the delegate config to a CSS selector that will select all the appropriate sub-elements.
    /// When using delegation, it is likely that you will want to programmatically change the content of the ToolTip based on each delegate element; you can do this by implementing a custom listener for the beforeshow event. 
    /// 
    /// Alignment
    /// The following configuration properties allow control over how the ToolTip is aligned relative to the target element and/or mouse pointer:
    ///     anchor
    ///     anchorToTarget
    ///     anchorOffset
    ///     trackMouse
    ///     mouseOffset
    /// 
    /// Showing/Hiding
    /// The following configuration properties allow control over how and when the ToolTip is automatically shown and hidden:
    ///     autoHide
    ///     showDelay
    ///     hideDelay
    ///     dismissDelay
    /// </summary>
    [Meta]
    [Description("ToolTip is a Ext.tip.Tip implementation that handles the common case of displaying a tooltip when hovering over a certain element or elements on the page. It allows fine-grained control over the tooltip's alignment relative to the target element or mouse, and the timing of when it is automatically shown and hidden.")]
    public abstract partial class ToolTipBase : Tip
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderTo")]
        [DefaultValue("")]
        protected internal override string RenderToProxy
        {
            get
            {
                if (!this.IsLazy && !this.PreventRenderTo)
                {
                    return this.RenderTo.IsEmpty() ? (this.TopDynamicControl ? this.TopDynamicRenderTo : (this.RemoveContainer ? "" : this.ContainerID)) : this.RenderTo;
                }
                else if (this.ForceRendering)
                {
                    return "={Ext.net.ResourceMgr.getRenderTarget()}";
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("8. ToolTip")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool ForceRendering
        {
            get
            {
                return this.State.Get<bool>("ForceRendering", false);
            }
            set
            {
                this.State.Set("ForceRendering", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// If specified, indicates that the tip should be anchored to a particular side of the target element or mouse pointer ("top", "right", "bottom", or "left"), with an arrow pointing back at the target or mouse pointer. If constrainPosition is enabled, this will be used as a preferred value only and may be flipped as needed.
        /// </summary>
        [Meta]
        [Category("8. ToolTip")]
        [DefaultValue(null)]
        [Description("If specified, indicates that the tip should be anchored to a particular side of the target element or mouse pointer (\"top\", \"right\", \"bottom\", or \"left\"), with an arrow pointing back at the target or mouse pointer. If constrainPosition is enabled, this will be used as a preferred value only and may be flipped as needed.")]
        public override string Anchor
        {
            get
            {
                return this.State.Get<string>("Anchor", null);
            }
            set
            {
                this.State.Set("Anchor", value);
            }
        }

        /// <summary>
        /// A numeric pixel value used to offset the default position of the anchor arrow. When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset. Defaults to: 0
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("A numeric pixel value used to offset the default position of the anchor arrow. When the anchor position is on the top or bottom of the tooltip, anchorOffset will be used as a horizontal offset. Likewise, when the anchor position is on the left or right side, anchorOffset will be used as a vertical offset. Defaults to: 0")]
        public virtual int AnchorOffset
        {
            get
            {
                return this.State.Get<int>("AnchorOffset", 0);
            }
            set
            {
                this.State.Set("AnchorOffset", value);
            }
        }

        /// <summary>
        /// True to anchor the tooltip to the target element, false to anchor it relative to the mouse coordinates. When anchorToTarget is true, use defaultAlign to control tooltip alignment to the target element. When anchorToTarget is false, use anchor instead to control alignment. Defaults to: true
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to anchor the tooltip to the target element, false to anchor it relative to the mouse coordinates. When anchorToTarget is true, use defaultAlign to control tooltip alignment to the target element. When anchorToTarget is false, use anchor instead to control alignment. Defaults to: true")]
        public virtual bool AnchorToTarget
        {
            get
            {
                return this.State.Get<bool>("AnchorToTarget", true);
            }
            set
            {
                this.State.Set("AnchorToTarget", value);
            }
        }

        /// <summary>
        /// True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically hide the tooltip after the mouse exits the target element or after the dismissDelay has expired if set (defaults to true). If closable = true a close tool button will be rendered into the tooltip header.")]
        public virtual bool AutoHide
        {
            get
            {
                return this.State.Get<bool>("AutoHide", true);
            }
            set
            {
                this.State.Set("AutoHide", value);
            }
        }

        /// <summary>
        /// A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.
        /// When specified, the child element of the target which caused a show event is placed into the triggerElement property before the ToolTip is shown.
        /// This may be useful when a Component has regular, repeating elements in it, each of which need a ToolTip which contains information specific to that element.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A DomQuery selector which allows selection of individual elements within the target element to trigger showing and hiding the ToolTip as the mouse moves within the target.")]
        public virtual string Delegate
        {
            get
            {
                return this.State.Get<string>("Delegate", "");
            }
            set
            {
                this.State.Set("Delegate", value);
            }
        }

        /// <summary>
        /// Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(5000)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds before the tooltip automatically hides (defaults to 5000). To disable automatic hiding, set dismissDelay = 0.")]
        public virtual int DismissDelay
        {
            get
            {
                return this.State.Get<int>("DismissDelay", 5000);
            }
            set
            {
                this.State.Set("DismissDelay", value);
            }
        }

        /// <summary>
        /// Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds after the mouse exits the target element but before the tooltip actually hides (defaults to 200). Set to 0 for the tooltip to hide immediately.")]
        public virtual int HideDelay
        {
            get
            {
                return this.State.Get<int>("HideDelay", 200);
            }
            set
            {
                this.State.Set("HideDelay", value);
            }
        }

        /// <summary>
        /// An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("8. ToolTip")]
        [DefaultValue(null)]
        [Description("An XY offset from the mouse position where the tooltip should be shown (defaults to [15,18]).")]
        public virtual int[] MouseOffset
        {
            get
            {
                return this.State.Get<int[]>("MouseOffset", null);
            }
            set
            {
                this.State.Set("MouseOffset", value);
            }
        }

        /// <summary>
        /// Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Delay in milliseconds before the tooltip displays after the mouse enters the target element (defaults to 500).")]
        public virtual int ShowDelay
        {
            get
            {
                return this.State.Get<int>("ShowDelay", 500);
            }
            set
            {
                this.State.Set("ShowDelay", value);
            }
        }

        private Control targetControl;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public Control TargetControl
        {
            get
            {
                return this.targetControl;
            }
            set
            {
                this.targetControl = value;
            }
        }

        /// <summary>
        /// The target id to associate with this tooltip.
        /// </summary>
        [Meta]
        [Category("8. ToolTip")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target id to associate with this tooltip.")]
        public virtual string Target
        {
            get
            {
                return this.State.Get<string>("Target", "");
            }
            set
            {
                this.State.Set("Target", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string TargetProxy
        {
            get
            {
                string target = this.Target;

                if (target.IsNotEmpty())
                {
                    string t = this.ParseTarget(target);

                    if (t.StartsWith("\""))
                    {
                        return t;
                    }

                    return TokenUtils.ParseAndNormalize(t);
                }

                if (this.TargetControl != null)
                {
                    return JSON.Serialize(this.TargetControl.ClientID);
                }

                return "";
            }
        }

        /// <summary>
        /// True to have the tooltip follow the mouse as it moves over the target element (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ToolTip")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to have the tooltip follow the mouse as it moves over the target element (defaults to false).")]
        public virtual bool TrackMouse
        {
            get
            {
                return this.State.Get<bool>("TrackMouse", false);
            }
            set
            {
                this.State.Set("TrackMouse", value);
            }
        }
    }
}