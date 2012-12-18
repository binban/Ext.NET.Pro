/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class Mask : ScriptClass
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.Mask";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript()
        {
            return this.currentConfig != null ? this.InstanceOf.ConcatWith(".show(", TokenUtils.ParseTokens(this.currentConfig.ToScript(), this.Page), ");") : "";
        }


        /*  Configure
            -----------------------------------------------------------------------------------------------*/

        private MaskConfig currentConfig = null;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual Mask Configure(MaskConfig config)
        {
            this.currentConfig = config;

            return this;
        }


        /*  Show
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Show()
        {
            this.Render();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Show(MaskConfig config)
        {
            this.Configure(config).Show();
        }


        /*  Hide
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Hides the message box if it is displayed
        /// </summary>
        [Description("Hides the mask")]
        public void Hide()
        {
            this.Call("hide");
        }
    }

    /// <summary>
    /// A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.
    /// </summary>
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class MaskConfig : ExtObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript()
        {
            return new ClientConfig().Serialize(this);
        }

        string msg = "";

        /// <summary>
        /// The title text
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The title text")]
        public virtual string Msg
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = value;
            }
        }

        string msgCls = "";

        /// <summary>
        /// An id or Element from which the message box should animate as it opens and closes (defaults to undefined)
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An id or Element from which the message box should animate as it opens and closes (defaults to undefined)")]
        public virtual string MsgCls
        {
            get
            {
                return this.msgCls;
            }
            set
            {
                this.msgCls = value;
            }
        }

        string el = "";

        /// <summary>
        /// An id or Element from which the message box should animate as it opens and closes (defaults to undefined)
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An element to mask")]
        public virtual string El
        {
            get
            {
                return this.el;
            }
            set
            {
                this.el = value;
            }
        }

        private Control control = null;

        /// <summary>
        /// A Control to mask
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An element to mask")]
        public virtual Control Control
        {
            get
            {
                return this.control;
            }
            set
            {
                this.control = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("el", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ElProxy
        {
            get
            {
                if (this.Control != null)
                {
                    if (this.Control is AbstractComponent)
                    {
                        return this.Control.ClientID;
                    }

                    return "Ext.get(\"".ConcatWith(this.Control.ClientID, "\")");
                }

                return this.El;
            }
        }
    }
}