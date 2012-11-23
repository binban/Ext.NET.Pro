/********
 * @version   : 2.1.0 - Ext.NET Pro License
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
    /// <summary>
    /// 
    /// </summary>
    public partial class FieldSet
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public FieldSet(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit FieldSet.Config Conversion to FieldSet
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator FieldSet(FieldSet.Config config)
        {
            return new FieldSet(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractContainer.Config 
        { 
			/*  Implicit FieldSet.Config Conversion to FieldSet.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator FieldSet.Builder(FieldSet.Config config)
			{
				return new FieldSet.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string checkboxName = "";

			/// <summary>
			/// The name to assign to the fieldset's checkbox if checkboxToggle = true (defaults to '[fieldset id]-checkbox').
			/// </summary>
			[DefaultValue("")]
			public virtual string CheckboxName 
			{ 
				get
				{
					return this.checkboxName;
				}
				set
				{
					this.checkboxName = value;
				}
			}

			private bool checkboxToggle = false;

			/// <summary>
			/// Set to true to render a checkbox into the fieldset frame just in front of the legend to expand/collapse the fieldset when the checkbox is toggled. (defaults to false). This checkbox will be included in form submits using the checkboxName.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CheckboxToggle 
			{ 
				get
				{
					return this.checkboxToggle;
				}
				set
				{
					this.checkboxToggle = value;
				}
			}

			private bool collapsed = false;

			/// <summary>
			/// Set to true to render the fieldset as collapsed by default. If checkboxToggle is specified, the checkbox will also be unchecked by default.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsed 
			{ 
				get
				{
					return this.collapsed;
				}
				set
				{
					this.collapsed = value;
				}
			}

			private bool collapsible = false;

			/// <summary>
			/// Set to true to make the fieldset collapsible and have the expand/collapse toggle button automatically rendered into the legend element, false to keep the fieldset statically sized with no collapse button (defaults to false). Another option is to configure checkboxToggle. Use the collapsed config to collapse the fieldset by default.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsible 
			{ 
				get
				{
					return this.collapsible;
				}
				set
				{
					this.collapsible = value;
				}
			}

			private string title = "";

			/// <summary>
			/// A title to be displayed in the fieldset's legend. May contain HTML markup.
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private bool toggleOnTitleClick = true;

			/// <summary>
			/// Set to true will add a listener to the titleCmp property for the click event which will execute the toggle method. This option is only used when the collapsible property is set to true. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ToggleOnTitleClick 
			{ 
				get
				{
					return this.toggleOnTitleClick;
				}
				set
				{
					this.toggleOnTitleClick = value;
				}
			}
        
			private FieldSetListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public FieldSetListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new FieldSetListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private FieldSetDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public FieldSetDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new FieldSetDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}