/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FlashComponent
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public FlashComponent(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit FlashComponent.Config Conversion to FlashComponent
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator FlashComponent(FlashComponent.Config config)
        {
            return new FlashComponent(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ComponentBase.Config 
        { 
			/*  Implicit FlashComponent.Config Conversion to FlashComponent.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator FlashComponent.Builder(FlashComponent.Config config)
			{
				return new FlashComponent.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string backgroundColor = "#ffffff";

			/// <summary>
			/// The background color. Defaults to '#ffffff' (white).
			/// </summary>
			[DefaultValue("#ffffff")]
			public virtual string BackgroundColor 
			{ 
				get
				{
					return this.backgroundColor;
				}
				set
				{
					this.backgroundColor = value;
				}
			}

			private bool expressInstall = false;

			/// <summary>
			/// True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ExpressInstall 
			{ 
				get
				{
					return this.expressInstall;
				}
				set
				{
					this.expressInstall = value;
				}
			}

			private string flashVersion = "9.0.45";

			/// <summary>
			/// Indicates the version the flash content was published for. Defaults to '9.0.45'.
			/// </summary>
			[DefaultValue("9.0.45")]
			public virtual string FlashVersion 
			{ 
				get
				{
					return this.flashVersion;
				}
				set
				{
					this.flashVersion = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The URL of the swf object to include. Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string Url 
			{ 
				get
				{
					return this.url;
				}
				set
				{
					this.url = value;
				}
			}
        
			private ParameterCollection flashVars = null;

			/// <summary>
			/// A set of key value pairs to be passed to the flash object as flash variables.
			/// </summary>
			public ParameterCollection FlashVars
			{
				get
				{
					if (this.flashVars == null)
					{
						this.flashVars = new ParameterCollection();
					}
			
					return this.flashVars;
				}
			}
			        
			private ParameterCollection flashParams = null;

			/// <summary>
			/// A set of key value pairs to be passed to the flash object as parameters.
			/// </summary>
			public ParameterCollection FlashParams
			{
				get
				{
					if (this.flashParams == null)
					{
						this.flashParams = new ParameterCollection();
					}
			
					return this.flashParams;
				}
			}
			
			private string swfHeight = "";

			/// <summary>
			/// The height of the embedded SWF movie inside the component. Defaults to \"100%\" so that the movie matches the height of the component.
			/// </summary>
			[DefaultValue("")]
			public virtual string SwfHeight 
			{ 
				get
				{
					return this.swfHeight;
				}
				set
				{
					this.swfHeight = value;
				}
			}

			private string swfWidth = "";

			/// <summary>
			/// The width of the embedded SWF movie inside the component. Defaults to \"100%\" so that the movie matches the width of the component.
			/// </summary>
			[DefaultValue("")]
			public virtual string SwfWidth 
			{ 
				get
				{
					return this.swfWidth;
				}
				set
				{
					this.swfWidth = value;
				}
			}

			private string wMode = "";

			/// <summary>
			/// The wmode of the flash object. This can be used to control layering. Set to 'transparent' to ignore the backgroundColor and make the background of the Flash movie transparent.
			/// </summary>
			[DefaultValue("")]
			public virtual string WMode 
			{ 
				get
				{
					return this.wMode;
				}
				set
				{
					this.wMode = value;
				}
			}
        
			private FlashComponentListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public FlashComponentListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new FlashComponentListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private FlashComponentDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public FlashComponentDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new FlashComponentDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}