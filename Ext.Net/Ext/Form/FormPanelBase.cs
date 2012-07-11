/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class FormPanelBase : AbstractPanel
    {
        /// <summary>
        /// Interval in milliseconds at which the form's fields are checked for value changes. Only used if the pollForChanges option is set to true. Defaults to 500 milliseconds.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Interval in milliseconds at which the form's fields are checked for value changes. Only used if the pollForChanges option is set to true. Defaults to 500 milliseconds.")]
        public virtual int PollInterval
        {
            get
            {
                return this.State.Get<int>("PollInterval", 500);
            }
            set
            {
                this.State.Set("PollInterval", value);
            }
        }

        /// <summary>
        /// If set to true, sets up an interval task (using the pollInterval) in which the panel's fields are repeatedly checked for changes in their values. This is in addition to the normal detection each field does on its own input element, and is not needed in most cases. It does, however, provide a means to absolutely guarantee detection of all changes including some edge cases in some browsers which do not fire native events. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, sets up an interval task (using the pollInterval) in which the panel's fields are repeatedly checked for changes in their values. This is in addition to the normal detection each field does on its own input element, and is not needed in most cases. It does, however, provide a means to absolutely guarantee detection of all changes including some edge cases in some browsers which do not fire native events. Defaults to false.")]
        public virtual bool PollForChanges
        {
            get
            {
                return this.State.Get<bool>("PollForChanges", false);
            }
            set
            {
                this.State.Set("PollForChanges", value);
            }
        }

        /// <summary>
        /// The Ext.container.Container.layout for the form panel's immediate child items. Defaults to 'anchor'.
        /// </summary>
        [Category("5. Container")]
        [DefaultValue("anchor")]
        [TypeConverter(typeof(LayoutConverter))]
        [Description("The Ext.container.Container.layout for the form panel's immediate child items. Defaults to 'anchor'.")]
        public override string Layout
        {
            get
            {
                return this.State.Get<string>("Layout", "anchor");
            }
            set
            {
                this.State.Set("Layout", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string DefaultLayout
        {
            get
            {
                return "anchor";
            }
        }

        #region /*---- BasicForm properties -------*/

        private ParameterCollection baseParams;

        /// <summary>
        /// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
        /// Parameters are encoded as standard HTTP parameters using Ext.Object.toQueryString.
        /// </summary>
        [Meta]
        [Category("6. FormPanel")]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                if (this.baseParams == null)
                {
                    this.baseParams = new ParameterCollection();
                    this.baseParams.Owner = this;
                }

                return this.baseParams;
            }
        }

        private ReaderCollection errorReader;

        /// <summary>
        /// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read field error messages returned from 'submit' actions. This is optional as there is built-in support for processing JSON responses.
        /// The Records which provide messages for the invalid Fields must use the Field name (or id) as the Record ID, and must contain a field called 'msg' which contains the error message.
        /// The errorReader does not have to be a full-blown implementation of a Reader. It simply needs to implement a read(xhr) function which returns an Array of Records in an object with the following structure:
        /// </summary>
        [Meta]
        [ConfigOption("errorReader>PrimaryProxy")]
        [Category("6. FormPanel")]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read field error messages returned from 'submit' actions. This is optional as there is built-in support for processing JSON responses.")]
        public virtual ReaderCollection ErrorReader
        {
            get
            {
                if (this.errorReader == null)
                {
                    this.errorReader = new ReaderCollection();
                    this.errorReader.LazyMode = Ext.Net.LazyMode.Instance;
                }

                return this.errorReader;
            }
        }

        /// <summary>
        /// The request method to use (GET or POST) for form actions if one isn't supplied in the action options.
        /// </summary>
        [Meta]
        [ConfigOption("method")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The request method to use (GET or POST) for form actions if one isn't supplied in the action options.")]
        public virtual HttpMethod Method
        {
            get
            {
                return this.State.Get<HttpMethod>("Method", HttpMethod.Default);
            }
            set
            {
                this.State.Set("Method", value);
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read data when executing 'load' actions. This is optional as there is built-in support for processing JSON responses.
        /// </summary>
        [Meta]
        [ConfigOption("reader>PrimaryProxy")]
        [Category("6. FormPanel")]        
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.data.DataReader (e.g. Ext.data.reader.Xml) to be used to read data when executing 'load' actions. This is optional as there is built-in support for processing JSON responses.")]
        public virtual ReaderCollection Reader
        {
            get
            {
                if (this.reader == null)
                {
                    this.reader = new ReaderCollection();
                    this.reader.LazyMode = Ext.Net.LazyMode.Instance;
                }

                return this.reader;
            }
        }

        /// <summary>
        /// If set to true, a standard HTML form submit is used instead of a XHR (Ajax) style form submission. All of the field values, plus any additional params configured via baseParams and/or the options to submit, will be included in the values submitted in the form.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, a standard HTML form submit is used instead of a XHR (Ajax) style form submission. All of the field values, plus any additional params configured via baseParams and/or the options to submit, will be included in the values submitted in the form.")]
        public virtual bool StandardSubmit
        {
            get
            {
                return this.State.Get<bool>("StandardSubmit", false);
            }
            set
            {
                this.State.Set("StandardSubmit", value);
            }
        }

        /// <summary>
        /// Timeout for form actions in seconds (default is 30 seconds).
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(30)]
        [Description("Timeout for form actions in seconds (default is 30 seconds).")]
        public virtual int Timeout
        {
            get
            {
                return this.State.Get<int>("Timeout", 30);
            }
            set
            {
                this.State.Set("Timeout", value);
            }
        }

        /// <summary>
        /// If set to true, reset() resets to the last loaded or setValues() data instead of when the form was first created.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, reset() resets to the last loaded or setValues() data instead of when the form was first created.")]
        public virtual bool TrackResetOnLoad
        {
            get
            {
                return this.State.Get<bool>("TrackResetOnLoad", false);
            }
            set
            {
                this.State.Set("TrackResetOnLoad", value);
            }
        }

        /// <summary>
        /// The URL to use for form actions if one isn't supplied in the doAction options.
        /// </summary>
        [Meta]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The URL to use for form actions if one isn't supplied in the doAction options.")]
        public virtual string Url
        {
            get
            {
                return this.State.Get<string>("Url", "");
            }
            set
            {
                this.State.Set("Url", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string UrlProxy
        {
            get
            {
                if (this.Url.IsEmpty())
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request.RawUrl.IsNotEmpty())
                    {
                        return HttpContext.Current.Request.RawUrl;
                    }
                    
                    return "";
                }

                return this.ResolveClientUrl(this.Url);
            }
        }

        /// <summary>
        /// By default wait messages are displayed with Ext.MessageBox.wait. You can target a specific element by passing it or its id or mask the form itself by passing in true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("By default wait messages are displayed with Ext.MessageBox.wait. You can target a specific element by passing it or its id or mask the form itself by passing in true.")]
        public virtual string WaitMsgTarget
        {
            get
            {
                return this.State.Get<string>("WaitMsgTarget", "");
            }
            set
            {
                this.State.Set("WaitMsgTarget", value);
            }
        }

        /// <summary>
        /// The default title to show for the waiting message box. Defaults to: "Please Wait..."
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue("Please Wait...")]
        [NotifyParentProperty(true)]
        [Description("The default title to show for the waiting message box")]
        public virtual string WaitTitle
        {
            get
            {
                return this.State.Get<string>("WaitTitle", "Please Wait...");
            }
            set
            {
                this.State.Set("WaitTitle", value);
            }
        }

        #endregion

        private Labelable fieldDefaults;

        /// <summary>
        /// If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("6. FormPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("If specified, the properties in this object are used as default config values for each Ext.form.Labelable instance (e.g. Ext.form.field.Base or Ext.form.FieldContainer) that is added as a descendant of this container. Corresponding values specified in an individual field's own configuration, or from the defaults config of its parent container, will take precedence. See the documentation for Ext.form.Labelable to see what config options may be specified in the fieldDefaults.")]
        public virtual Labelable FieldDefaults
        {
            get
            {
                if (this.fieldDefaults == null)
                {
                    this.fieldDefaults = new Labelable(this);
                }

                return this.fieldDefaults;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void CallForm(string name, params object[] args)
        {
            this.CallTemplate("{0}.getForm().{1}({2});", name, args);
        }

        /// <summary>
        /// Forces each field within the form panel to check if its value has changed.
        /// </summary>
        public void CheckChange()
        {
            this.Call("checkChange");
        }

        /// <summary>
        /// Start an interval task to continuously poll all the fields in the form for changes in their values. This is normally started automatically by setting the pollForChanges config.
        /// </summary>
        /// <param name="interval">The interval in milliseconds at which the check should run.</param>
        public void StartPolling(int interval)
        {
            this.Call("startPolling", interval);
        }

        /// <summary>
        /// Stop a running interval task that was started by startPolling.
        /// </summary>
        public void StopPolling()
        {
            this.Call("stopPolling");
        }

        /// <summary>
        /// Calls Ext.apply for all fields in this form with the passed object.
        /// </summary>
        /// <param name="values">The object to be applied</param>
        [Meta]
        public virtual void ApplyToFields(object values)
        {
            this.CallForm("applyToFields", values);
        }

        /// <summary>
        /// Calls Ext.applyIf for all fields in this form with the passed object.
        /// </summary>
        /// <param name="values">The object to be applied</param>
        [Meta]
        public virtual void ApplyIfToFields(object values)
        {
            this.CallForm("applyIfToFields", values);
        }

        /// <summary>
        /// Check whether the dirty state of the entire form has changed since it was last checked, and if so fire the dirtychange event. This is automatically invoked when an individual field's dirty state changes.
        /// </summary>
        public virtual void CheckDirty()
        {
            this.CallForm("checkDirty");
        }

        /// <summary>
        /// Check whether the validity of the entire form has changed since it was last checked, and if so fire the validitychange event. This is automatically invoked when an individual field's validity changes.
        /// </summary>
        public virtual void CheckValidity()
        {
            this.CallForm("checkValidity");
        }

        /// <summary>
        /// Clears all invalid field messages in this form.
        /// </summary>
        [Meta]
        public virtual void ClearInvalid()
        {
            this.CallForm("clearInvalid");
        }

        /// <summary>
        /// Load data from a server into the Fields.
        /// A response packet must contain:
        ///     success property : Boolean
        ///     data property : Object
        /// The data property contains the values of Fields to load. The individual value object for each Field is passed to the Field's setValue method.
        /// </summary>
        /// <param name="options">
        /// The options to pass to the Ext.form.action.Action that will get created, if the action argument is a String.
        ///
        /// All of the config options listed below are supported by both the submit and load actions unless otherwise noted (custom actions could also accept other config options):
        /// 
        /// url : String
        /// The url for the action (defaults to the form's url.)
        /// method : String
        /// The form method to use (defaults to the form's method, or POST if not defined)
        /// params : String/Object
        /// The params to pass (defaults to the form's baseParams, or none if not defined)
        /// 
        /// Parameters are encoded as standard HTTP parameters using Ext.Object.toQueryString.
        /// headers : Object
        /// Request headers to set for the action.
        /// success : Function
        /// The callback that will be invoked after a successful response (see top of submit and load for a description of what constitutes a successful response).
        /// 
        /// Parameters
        /// form : Ext.form.Basic
        /// The form that requested the action.
        /// action : Ext.form.action.Action
        /// The Action object which performed the operation. The action object contains these properties of interest:
        /// 
        /// response
        /// result - interrogate for custom postprocessing
        /// type
        /// failure : Function
        /// The callback that will be invoked after a failed transaction attempt.
        /// 
        /// Parameters
        /// form : Ext.form.Basic
        /// The form that requested the action.
        /// action : Ext.form.action.Action
        /// The Action object which performed the operation. The action object contains these properties of interest:
        /// 
        /// failureType
        /// response
        /// result - interrogate for custom postprocessing
        /// type
        /// scope : Object
        /// The scope in which to call the callback functions (The this reference for the callback functions).
        /// clientValidation : Boolean
        /// Submit Action only. Determines whether a Form's fields are validated in a final call to isValid prior to submission. Set to false to prevent this. If undefined, pre-submission field validation is performed.
        /// </param>
        [Meta]
        public virtual void LoadForm(object options)
        {
            this.CallForm("load", options);
        }

        /// <summary>
        /// Mark fields in this form invalid in bulk.
        /// </summary>
        /// <param name="errors">Either an array in the form [{id:'fieldId', msg:'The message'}, ...], an object hash of {id: msg, id2: msg2}, or a Ext.data.Errors object.</param>
        [Meta]
        [Description("Mark fields in this form invalid in bulk.")]
        public virtual void MarkInvalid(object errors)
        {
            this.CallForm("markInvalid", errors);
        }

        /// <summary>
        /// Resets all fields in this form.
        /// </summary>
        [Meta]
        [Description("Resets this form.")]
        public virtual void Reset()
        {
            this.CallForm("reset");
        }

        /// <summary>
        /// Set values for fields in this form in bulk.
        /// </summary>
        /// <param name="values">Either an array in the form: [{id:'clientName', value:'Fred. Olsen Lines'}, {id:'portOfLoading', value:'FXT'}] or an object hash of the form: {clientName: 'Fred. Olsen Lines', portOfLoading: 'FXT'}</param>
        [Meta]
        [Description("Set values for fields in this form in bulk.")]
        public virtual void SetValues(object values)
        {
            this.CallForm("setValues", values);
        }

        /// <summary>
        /// Persists the values in this form into the passed Ext.data.Model object in a beginEdit/endEdit block.
        /// </summary>
        public virtual void UpdateRecord()
        {
            this.CallForm("updateRecord");
        }

        /// <summary>
        /// Persists the values in this form into the passed Ext.data.Model object in a beginEdit/endEdit block.
        /// </summary>
        /// <param name="model">The record to edit</param>
        public virtual void UpdateRecord(ModelProxy model)
        {
            this.CallForm("updateRecord", new JRawValue(model.ModelInstance));
        }

        /// <summary>
        /// Loads an Ext.data.Model into this form by calling setValues with the record data. See also trackResetOnLoad.
        /// </summary>
        /// <param name="model">The record to load</param>
        public virtual void LoadRecord(ModelProxy model)
        {
            this.CallForm("loadRecord", new JRawValue(model.ModelInstance));
        }
    }
}