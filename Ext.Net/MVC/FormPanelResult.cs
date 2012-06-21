/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Web.Mvc;
using System.Xml.Serialization;
using Ext.Net.Utilities;
using Newtonsoft.Json;
using System.Web;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormPanelResult : ActionResult, IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        public FormPanelResult() { }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        public string Script 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUpload 
        { 
            get; 
            set; 
        }

        private bool success = true;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        public bool Success
        {
            get 
            { 
                return this.success; 
            }
            set 
            { 
                this.success = value; 
            }
        }

        private List<FieldError> errors;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        public List<FieldError> Errors
        {
            get
            {
                if(this.errors == null)
                {
                    this.errors = new List<FieldError>();
                }

                return this.errors;
            }
        }

        private ParameterCollection extraParams;

        /// <summary>
        /// 
        /// </summary>
        public ParameterCollection ExtraParams
        {
            get
            {
                if (this.extraParams == null)
                {
                    this.extraParams = new ParameterCollection();
                }

                return this.extraParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("extraParams", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ExtraParamsProxy
        {
            get
            {
                if (this.ExtraParams.Count > 0)
                {
                   return ExtraParams.ToJson();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (HttpContext.Current != null)
            {
                var instanceScript = HttpContext.Current.Items[ResourceManager.INSTANCESCRIPT];
                if (instanceScript != null)
                {
                    this.Script = instanceScript.ToString() + (this.Script ?? "");
                }
            }

            if (!string.IsNullOrEmpty(this.Script))
            {
                this.Script = string.Concat("<string>", this.Script);
            }

            if (this.IsUpload)
            {
                context.HttpContext.Response.Write("<textarea>{0}</textarea>".FormatWith(new ClientConfig().Serialize(this)));
            }
            else
            {
                CompressionUtils.GZipAndSend(new ClientConfig().Serialize(this));
            }
        }

        #region Члены IXObject

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("script", new ConfigOption("script", null, null, this.Script));
                list.Add("success", new ConfigOption("success", null, "", this.Success));
                list.Add("errors", new ConfigOption("errors", new SerializationOptions(JsonMode.AlwaysArray), null, this.Errors));
                list.Add("extraParamsProxy", new ConfigOption("extraParamsProxy", new SerializationOptions("extraParams", JsonMode.Raw), "", this.ExtraParamsProxy));

                return list;
            }
        }

        public ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get 
            {
                return Ext.Net.ConfigOptionsExtraction.List;
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class FieldError: IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldID"></param>
        /// <param name="errorMessage"></param>
        public FieldError(string fieldID, string errorMessage)
        {
            if(string.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException("fieldID", "Field ID can not be empty");
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException("errorMessage", "Error message can not be empty");
            }

            this.FieldID = fieldID;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("id")]
        [DefaultValue("")]
        public string FieldID 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("msg")]
        [DefaultValue("")]
        public string ErrorMessage 
        { 
            get; 
            set; 
        }

        #region Члены IXObject

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                list.Add("fieldID", new ConfigOption("fieldID", new SerializationOptions("id"), "", this.FieldID));
                list.Add("errorMessage", new ConfigOption("errorMessage", new SerializationOptions("msg"), "", this.ErrorMessage));

                return list;
            }
        }

        public ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get 
            {
                return Ext.Net.ConfigOptionsExtraction.List;
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class FieldErrors : Collection<FieldError> { }
}
