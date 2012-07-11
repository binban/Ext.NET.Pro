/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FieldDirectEvents : BoxComponentDirectEvents
    {
        private ComponentDirectEvent blur;

        /// <summary>
        /// Fires when this field loses input focus.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("blur", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this field loses input focus.")]
        public virtual ComponentDirectEvent Blur
        {
            get
            {
                if (this.blur == null)
                {
                    this.blur = new ComponentDirectEvent();
                }

                return this.blur;
            }
        }

        private ComponentDirectEvent change;

        /// <summary>
        /// Fires just before the field blurs if the field value has changed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "newValue", typeof(object), "The new value")]
        [ListenerArgument(2, "oldValue", typeof(object), "The original value")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("change", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires just before the field blurs if the field value has changed.")]
        public virtual ComponentDirectEvent Change
        {
            get
            {
                if (this.change == null)
                {
                    this.change = new ComponentDirectEvent();
                }

                return this.change;
            }
        }

        private ComponentDirectEvent focus;

        /// <summary>
        /// Fires when this field receives input focus.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("focus", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this field receives input focus.")]
        public virtual ComponentDirectEvent Focus
        {
            get
            {
                if (this.focus == null)
                {
                    this.focus = new ComponentDirectEvent();
                }

                return this.focus;
            }
        }

        private ComponentDirectEvent invalid;

        /// <summary>
        /// Fires after the field has been marked as invalid.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "msg", typeof(string), "the validation message")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("invalid", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the field has been marked as invalid.")]
        public virtual ComponentDirectEvent Invalid
        {
            get
            {
                if (this.invalid == null)
                {
                    this.invalid = new ComponentDirectEvent();
                }

                return this.invalid;
            }
        }

        private ComponentDirectEvent specialKey;

        /// <summary>
        /// Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "e", typeof(object), "The event object")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("specialkey", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed.")]
        public virtual ComponentDirectEvent SpecialKey
        {
            get
            {
                if (this.specialKey == null)
                {
                    this.specialKey = new ComponentDirectEvent();
                }

                return this.specialKey;
            }
        }

        private ComponentDirectEvent valid;

        /// <summary>
        /// Fires after the field has been validated with no errors.
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("valid", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the field has been validated with no errors.")]
        public virtual ComponentDirectEvent Valid
        {
            get
            {
                if (this.valid == null)
                {
                    this.valid = new ComponentDirectEvent();
                }

                return this.valid;
            }
        }

        private ComponentDirectEvent remoteValidationFailure;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "e", typeof(Field), "")]
        [ListenerArgument(3, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationfailure", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent RemoteValidationFailure
        {
            get
            {
                if (this.remoteValidationFailure == null)
                {
                    this.remoteValidationFailure = new ComponentDirectEvent();
                }

                return this.remoteValidationFailure;
            }
        }

        private ComponentDirectEvent remoteValidationValid;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "responseObject", typeof(object), "")]
        [ListenerArgument(3, "result", typeof(object), "")]
        [ListenerArgument(4, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationvalid", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent RemoteValidationValid
        {
            get
            {
                if (this.remoteValidationValid == null)
                {
                    this.remoteValidationValid = new ComponentDirectEvent();
                }

                return this.remoteValidationValid;
            }
        }

        private ComponentDirectEvent remoteValidationInvalid;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "response", typeof(object), "")]
        [ListenerArgument(2, "responseObject", typeof(object), "")]
        [ListenerArgument(3, "result", typeof(object), "")]
        [ListenerArgument(4, "o", typeof(Field), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remotevalidationinvalid", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent RemoteValidationInvalid
        {
            get
            {
                if (this.remoteValidationInvalid == null)
                {
                    this.remoteValidationInvalid = new ComponentDirectEvent();
                }

                return this.remoteValidationInvalid;
            }
        }

        private ComponentDirectEvent indicatorIconClick;

        /// <summary>
        ///
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "this")]
        [ListenerArgument(1, "indicatorEl", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("indicatoriconclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent IndicatorIconClick
        {
            get
            {
                if (this.indicatorIconClick == null)
                {
                    this.indicatorIconClick = new ComponentDirectEvent();
                }

                return this.indicatorIconClick;
            }
        }
    }
}