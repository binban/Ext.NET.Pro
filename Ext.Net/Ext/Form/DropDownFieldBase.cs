/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    [Meta]
    [Description("")]
    public abstract partial class DropDownFieldBase : PickerField
    {       
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            bool baseLoadPost = base.LoadPostData(postDataKey, postCollection);

            string val = postCollection[this.ValueHiddenName.IsNotEmpty() ? this.ValueHiddenName : (this.UniqueName + "_value")];

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val != null)
            {
                try
                {
                    this.SuspendScripting();
                    this.UnderlyingValue = val;
                }
                finally
                {
                    this.ResumeScripting();
                }
            }

            return baseLoadPost;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DropDownField")]
        [DefaultValue("")]
        [Description("")]
        public virtual string ValueHiddenName
        {
            get
            {
                return this.State.Get<string>("ValueHiddenName", "");
            }
            set
            {
                this.State.Set("ValueHiddenName", value);
            }
        }

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Category("8. DropDownField")]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [DirectEventUpdate(MethodName = "SetValue")]
        [Description("The Text value to initialize this field with.")]
        public override string Text
        {
            get
            {
                return this.State.Get<string>("Text", "");
            }
            set
            {
                this.State.Set("Text", value);
            }
        }

        /// <summary>
        /// The underlying value which mapping on the Text, similar the Value property but can be set declarative
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Category("8. DropDownField")]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The underlying value which mapping on the Text, similar the Value property but can be set declarative")]
        public virtual string UnderlyingValue
        {
            get
            {
                return (string)this.Value;
            }
            set
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. DropDownField")]
        [DefaultValue(DropDownMode.Text)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual DropDownMode Mode
        {
            get
            {
                return this.State.Get<DropDownMode>("Mode", DropDownMode.Text);
            }
            set
            {
                this.State.Set("Mode", value);
            }
        }


        /// <summary>
        /// False to hide the component when the field is blurred. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. DropDownField")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to hide the component when the field is blurred. Defaults to false.")]
        public virtual bool AllowBlur
        {
            get
            {
                return this.State.Get<bool>("AllowBlur", false);
            }
            set
            {
                this.State.Set("AllowBlur", value);
            }
        }

        ItemsCollection<AbstractContainer> component;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("8. DropDownField")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("component", typeof(SingleItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<AbstractContainer> Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new ItemsCollection<AbstractContainer>();
                    this.component.SingleItemMode = true;
                    this.component.AfterItemAdd += this.AfterItemAdd;
                    this.component.AfterItemRemove += this.AfterItemRemove;
                }

                return this.component;
            }
        }

        /// <summary>
        /// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
        /// </summary>
        [Meta]
        [Category("8. DropDownField")]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.")]
        public virtual string ComponentRenderTo
        {
            get
            {
                return this.State.Get<string>("ComponentRenderTo", "");
            }
            set
            {
                this.State.Set("ComponentRenderTo", value);
            }
        }

        private JFunction syncValue;

        /// <summary>
        /// Function to syncronize value of the field and dropdown control
        /// Parameters:
        ///    value : value
        ///    text : text
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("8. DropDownField")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Function to syncronize value of the field and dropdown control")]
        public virtual JFunction SyncValue
        {
            get
            {
                if (this.syncValue == null)
                {
                    this.syncValue = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.syncValue.Args = new string[] { "value", "text"};
                    }
                }

                return this.syncValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetValue(string value, string text)
        {
            this.SuspendScripting();
            this.Value = value;
            this.ResumeScripting();

            this.Call("setValue", value, text);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetValue(string value, string text, bool collapse)
        {
            this.SuspendScripting();
            this.Value = value;
            this.ResumeScripting();
            this.Call("setValue", value, text, collapse);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetValue(string value, string text, bool collapse, bool preventSync)
        {
            this.SuspendScripting();
            this.Value = value;
            this.ResumeScripting();
            this.Call("setValue", value, text, collapse, preventSync);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void SetValueProxy(object value)
        {
            if (this.Mode == DropDownMode.ValueText)
            {
                return;
            }

            this.Call("setValue", value);
        }
    }
}
