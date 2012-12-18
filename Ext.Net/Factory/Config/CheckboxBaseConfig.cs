/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    public abstract partial class CheckboxBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private XTemplate afterBoxLabelTextTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup after the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate AfterBoxLabelTextTpl 
			{ 
				get
				{
					return this.afterBoxLabelTextTpl;
				}
				set
				{
					this.afterBoxLabelTextTpl = value;
				}
			}

			private XTemplate afterBoxLabelTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup after the box label element. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate AfterBoxLabelTpl 
			{ 
				get
				{
					return this.afterBoxLabelTpl;
				}
				set
				{
					this.afterBoxLabelTpl = value;
				}
			}

			private XTemplate beforeBoxLabelTextTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate BeforeBoxLabelTextTpl 
			{ 
				get
				{
					return this.beforeBoxLabelTextTpl;
				}
				set
				{
					this.beforeBoxLabelTextTpl = value;
				}
			}

			private XTemplate beforeBoxLabelTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup before the box label text. If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate BeforeBoxLabelTpl 
			{ 
				get
				{
					return this.beforeBoxLabelTpl;
				}
				set
				{
					this.beforeBoxLabelTpl = value;
				}
			}

			private string boxLabel = "";

			/// <summary>
			/// An optional text label that will appear next to the checkbox. Whether it appears before or after the checkbox is determined by the boxLabelAlign config (defaults to after).
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabel 
			{ 
				get
				{
					return this.boxLabel;
				}
				set
				{
					this.boxLabel = value;
				}
			}

			private BoxLabelAlign boxLabelAlign = BoxLabelAlign.After;

			/// <summary>
			/// The position relative to the checkbox where the boxLabel should appear. Recognized values are 'before' and 'after'. Defaults to 'after'.
			/// </summary>
			[DefaultValue(BoxLabelAlign.After)]
			public virtual BoxLabelAlign BoxLabelAlign 
			{ 
				get
				{
					return this.boxLabelAlign;
				}
				set
				{
					this.boxLabelAlign = value;
				}
			}

			private string boxLabelStyle = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabelStyle 
			{ 
				get
				{
					return this.boxLabelStyle;
				}
				set
				{
					this.boxLabelStyle = value;
				}
			}

			private XTemplate boxLabelAttrTpl = null;

			/// <summary>
			/// An optional string or XTemplate configuration to insert in the field markup inside the box label element (as attributes). If an XTemplate is used, the component's subTpl data serves as the context.
			/// </summary>
			[DefaultValue(null)]
			public virtual XTemplate BoxLabelAttrTpl 
			{ 
				get
				{
					return this.boxLabelAttrTpl;
				}
				set
				{
					this.boxLabelAttrTpl = value;
				}
			}

			private string boxLabelCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabelCls 
			{ 
				get
				{
					return this.boxLabelCls;
				}
				set
				{
					this.boxLabelCls = value;
				}
			}

			private bool _checked = false;

			/// <summary>
			/// True if the the checkbox should render already checked (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Checked 
			{ 
				get
				{
					return this._checked;
				}
				set
				{
					this._checked = value;
				}
			}

			private string checkedCls = "";

			/// <summary>
			/// The CSS class added to the component's main element when it is in the checked state.
			/// </summary>
			[DefaultValue("")]
			public virtual string CheckedCls 
			{ 
				get
				{
					return this.checkedCls;
				}
				set
				{
					this.checkedCls = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// A function called when the checked value changes (can be used instead of handling the change event).
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private string inputValue = "";

			/// <summary>
			/// The value that should go into the generated input element's value attribute and should be used as the parameter value when submitting as part of a form. Defaults to \"on\".
			/// </summary>
			[DefaultValue("")]
			public virtual string InputValue 
			{ 
				get
				{
					return this.inputValue;
				}
				set
				{
					this.inputValue = value;
				}
			}

			private string scope = null;

			/// <summary>
			/// An object to use as the scope ('this' reference) of the handler function. Defaults to this Checkbox.
			/// </summary>
			[DefaultValue(null)]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private string uncheckedValue = null;

			/// <summary>
			/// If configured, this will be submitted as the checkbox's value during form submit if the checkbox is unchecked. By default this is undefined, which results in nothing being submitted for the checkbox field when the form is submitted (the default behavior of HTML checkboxes).
			/// </summary>
			[DefaultValue(null)]
			public virtual string UncheckedValue 
			{ 
				get
				{
					return this.uncheckedValue;
				}
				set
				{
					this.uncheckedValue = value;
				}
			}

        }
    }
}