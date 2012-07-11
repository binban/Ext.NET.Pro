/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [Meta]
    public partial class FieldTrigger : BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FieldTrigger() { }

        /// <summary>
        /// A trigger tag
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("A trigger tag")]
        public virtual string Tag
        {
            get
            {
                return this.State.Get<string>("Tag", "");
            }
            set
            {
                this.State.Set("Tag", value);
            }
        }

        /// <summary>
        /// True to hide the trigger element and display only the base text field (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("True to hide the trigger element and display only the base text field (defaults to false).")]
        public virtual bool HideTrigger
        {
            get
            {
                return this.State.Get<bool>("HideTrigger", false);
            }
            set
            {
                this.State.Set("HideTrigger", value);
            }
        }

        /// <summary>
        /// A CSS class to apply to the trigger.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("A CSS class to apply to the trigger.")]
        public virtual string TriggerCls
        {
            get
            {
                return this.State.Get<string>("TriggerCls", "");
            }
            set
            {
                this.State.Set("TriggerCls", value);
            }
        }

        /// <summary>
        /// The icon to use in the trigger. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(TriggerIcon.Combo)]
        [Description("The icon to use in the trigger. See also, IconCls to set an icon with a custom Css class.")]
        public virtual TriggerIcon Icon
        {
            get
            {
                return this.State.Get<TriggerIcon>("Icon", TriggerIcon.Combo);
            }
            set
            {
                this.State.Set("Icon", value);
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this button.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this button.")]
        public virtual string IconCls
        {
            get
            {
                return this.State.Get<string>("IconCls", "");
            }
            set
            {
                this.State.Set("IconCls", value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("iconCls", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string IconClsProxy
        {
            get
            {
                if (this.Icon != TriggerIcon.Combo)
                {
                    return "Ext.form.field.Trigger.getIcon(".ConcatWith(JSON.Serialize(this.Icon.ToString()), ")");
                }

                return "\"" + this.IconCls + "\"";
            }
        }

        /// <summary>
        /// Quick tip.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Quick tip.")]
        public virtual string Qtip
        {
            get
            {
                return this.State.Get<string>("Qtip", "");
            }
            set
            {
                this.State.Set("Qtip", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum TriggerIcon
    {
        /// <summary>
        /// 
        /// </summary>
        Empty,

        /// <summary>
        /// 
        /// </summary>
        Ellipsis,

        /// <summary>
        /// 
        /// </summary>
        Date,

        /// <summary>
        /// 
        /// </summary>
        Clear,

        /// <summary>
        /// 
        /// </summary>
        Search,

        /// <summary>
        /// 
        /// </summary>
        Combo,

        /// <summary>
        /// 
        /// </summary>
        SimpleEllipsis,

        /// <summary>
        /// 
        /// </summary>
        SimpleAdd,

        /// <summary>
        /// 
        /// </summary>
        SimpleAlt,

        /// <summary>
        /// 
        /// </summary>
        SimpleArrowDown,

        /// <summary>
        /// 
        /// </summary>
        SimpleArrowUp,

        /// <summary>
        /// 
        /// </summary>
        SimpleConnect,

        /// <summary>
        /// 
        /// </summary>
        SimpleCross,

        /// <summary>
        /// 
        /// </summary>
        SimpleDatabase,

        /// <summary>
        /// 
        /// </summary>
        SimpleDelete,

        /// <summary>
        /// 
        /// </summary>
        SimpleDisk,

        /// <summary>
        /// 
        /// </summary>
        SimpleEarth,

        /// <summary>
        /// 
        /// </summary>
        SimpleEdit,

        /// <summary>
        /// 
        /// </summary>
        SimpleError,

        /// <summary>
        /// 
        /// </summary>
        SimpleFeed,

        /// <summary>
        /// 
        /// </summary>
        SimpleGet,

        /// <summary>
        /// 
        /// </summary>
        SimpleGo,

        /// <summary>
        /// 
        /// </summary>
        SimpleHome,

        /// <summary>
        /// 
        /// </summary>
        SimpleImage,

        /// <summary>
        /// 
        /// </summary>
        SimpleKey,

        /// <summary>
        /// 
        /// </summary>
        SimpleLeft,

        /// <summary>
        /// 
        /// </summary>
        SimpleLightning,

        /// <summary>
        /// 
        /// </summary>
        SimpleMagnify,

        /// <summary>
        /// 
        /// </summary>
        SimpleMinus,

        /// <summary>
        /// 
        /// </summary>
        SimplePlus,

        /// <summary>
        /// 
        /// </summary>
        SimpleRight,

        /// <summary>
        /// 
        /// </summary>
        SimpleShape,

        /// <summary>
        /// 
        /// </summary>
        SimpleSparkle,

        /// <summary>
        /// 
        /// </summary>
        SimpleStar,

        /// <summary>
        /// 
        /// </summary>
        SimpleStart,

        /// <summary>
        /// 
        /// </summary>
        SimpleStop,

        /// <summary>
        /// 
        /// </summary>
        SimpleTick,

        /// <summary>
        /// 
        /// </summary>
        SimpleToggleMinus,

        /// <summary>
        /// 
        /// </summary>
        SimpleTogglePlus,

        /// <summary>
        /// 
        /// </summary>
        SimpleWrench,

        /// <summary>
        /// 
        /// </summary>
        SimpleWrenchRed,

        /// <summary>
        /// 
        /// </summary>
        SimpleTime,

        /// <summary>
        /// 
        /// </summary>
        SimpleDate
    }
}