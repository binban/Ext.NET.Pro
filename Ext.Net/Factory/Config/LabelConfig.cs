/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public partial class Label
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Label(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Label.Config Conversion to Label
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Label(Label.Config config)
        {
            return new Label(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BoxComponentBase.Config 
        { 
			/*  Implicit Label.Config Conversion to Label.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Label.Builder(Label.Config config)
			{
				return new Label.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string format = "";

			/// <summary>
			/// The format of the string to render using the .Text property. Example 'Hello {0}'.
			/// </summary>
			[DefaultValue("")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// The default text to display if the Text property is empty (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private string forID = "";

			/// <summary>
			/// The id of the input element to which this label will be bound via the standard 'htmlFor' attribute. If not specified, the attribute will not be added to the label.
			/// </summary>
			[DefaultValue("")]
			public virtual string ForID 
			{ 
				get
				{
					return this.forID;
				}
				set
				{
					this.forID = value;
				}
			}

			private string html = "";

			/// <summary>
			/// An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.
			/// </summary>
			[DefaultValue("")]
			public virtual string Html 
			{ 
				get
				{
					return this.html;
				}
				set
				{
					this.html = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the label. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A css class which sets a background image to be used as the icon for this label.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private Alignment iconAlign = Alignment.Left;

			/// <summary>
			/// (optional) Set the CSS text-align property of the icon. The center is not supported. Defaults to \"Left\"
			/// </summary>
			[DefaultValue(Alignment.Left)]
			public virtual Alignment IconAlign 
			{ 
				get
				{
					return this.iconAlign;
				}
				set
				{
					this.iconAlign = value;
				}
			}
        
			private ItemsCollection<Editor> editor = null;

			/// <summary>
			/// Inline editor
			/// </summary>
			public ItemsCollection<Editor> Editor
			{
				get
				{
					if (this.editor == null)
					{
						this.editor = new ItemsCollection<Editor>();
					}
			
					return this.editor;
				}
			}
			        
			private BoxComponentListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public BoxComponentListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new BoxComponentListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private BoxComponentDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public BoxComponentDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new BoxComponentDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}