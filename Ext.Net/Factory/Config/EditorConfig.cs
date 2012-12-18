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
    public partial class Editor
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Editor(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Editor.Config Conversion to Editor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Editor(Editor.Config config)
        {
            return new Editor(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : AbstractContainer.Config 
        { 
			/*  Implicit Editor.Config Conversion to Editor.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Editor.Builder(Editor.Config config)
			{
				return new Editor.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activateEvent = "click";

			/// <summary>
			/// Event name for activate the editor
			/// </summary>
			[DefaultValue("click")]
			public virtual string ActivateEvent 
			{ 
				get
				{
					return this.activateEvent;
				}
				set
				{
					this.activateEvent = value;
				}
			}

			private string alignment = "c-c?";

			/// <summary>
			/// The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").
			/// </summary>
			[DefaultValue("c-c?")]
			public virtual string Alignment 
			{ 
				get
				{
					return this.alignment;
				}
				set
				{
					this.alignment = value;
				}
			}

			private EditorAlignmentConfig alignmentConfig = null;

			/// <summary>
			/// The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").
			/// </summary>
			[DefaultValue(null)]
			public virtual EditorAlignmentConfig AlignmentConfig 
			{ 
				get
				{
					return this.alignmentConfig;
				}
				set
				{
					this.alignmentConfig = value;
				}
			}

			private bool autoSize = false;

			/// <summary>
			/// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object. 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoSize 
			{ 
				get
				{
					return this.autoSize;
				}
				set
				{
					this.autoSize = value;
				}
			}

			private EditorAutoSize autoSizeConfig = null;

			/// <summary>
			/// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object.
			/// </summary>
			[DefaultValue(null)]
			public virtual EditorAutoSize AutoSizeConfig 
			{ 
				get
				{
					return this.autoSizeConfig;
				}
				set
				{
					this.autoSizeConfig = value;
				}
			}

			private bool allowBlur = true;

			/// <summary>
			/// True to complete the editing process if in edit mode when the field is blurred. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlur 
			{ 
				get
				{
					return this.allowBlur;
				}
				set
				{
					this.allowBlur = value;
				}
			}

			private bool cancelOnBlur = false;

			/// <summary>
			/// True to cancel the edit when the blur event is fired (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CancelOnBlur 
			{ 
				get
				{
					return this.cancelOnBlur;
				}
				set
				{
					this.cancelOnBlur = value;
				}
			}

			private bool cancelOnEsc = true;

			/// <summary>
			/// True to cancel the edit when the escape key is pressed. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CancelOnEsc 
			{ 
				get
				{
					return this.cancelOnEsc;
				}
				set
				{
					this.cancelOnEsc = value;
				}
			}

			private bool completeOnEnter = true;

			/// <summary>
			/// True to complete the edit when the enter key is pressed (defaults to false)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CompleteOnEnter 
			{ 
				get
				{
					return this.completeOnEnter;
				}
				set
				{
					this.completeOnEnter = value;
				}
			}

			private bool constrain = false;

			/// <summary>
			/// True to constrain the editor to the viewport. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Constrain 
			{ 
				get
				{
					return this.constrain;
				}
				set
				{
					this.constrain = value;
				}
			}

			private bool hideEl = true;

			/// <summary>
			/// False to keep the bound element visible while the editor is displayed. Defaults to: true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideEl 
			{ 
				get
				{
					return this.hideEl;
				}
				set
				{
					this.hideEl = value;
				}
			}
        
			private ItemsCollection<Field> field = null;

			/// <summary>
			/// The Field object (or descendant)
			/// </summary>
			public ItemsCollection<Field> Field
			{
				get
				{
					if (this.field == null)
					{
						this.field = new ItemsCollection<Field>();
					}
			
					return this.field;
				}
			}
			
			private bool ignoreNoChange = false;

			/// <summary>
			/// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed. Applies only to string values - edits for other data types will never be ignored. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreNoChange 
			{ 
				get
				{
					return this.ignoreNoChange;
				}
				set
				{
					this.ignoreNoChange = value;
				}
			}

			private string parentElement = "";

			/// <summary>
			/// An element to render to. Defaults to the document.body.
			/// </summary>
			[DefaultValue("")]
			public virtual string ParentElement 
			{ 
				get
				{
					return this.parentElement;
				}
				set
				{
					this.parentElement = value;
				}
			}

			private bool revertInvalid = true;

			/// <summary>
			/// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RevertInvalid 
			{ 
				get
				{
					return this.revertInvalid;
				}
				set
				{
					this.revertInvalid = value;
				}
			}

			private bool swallowKeys = true;

			/// <summary>
			/// Handle the keydown/keypress events so they don't propagate (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SwallowKeys 
			{ 
				get
				{
					return this.swallowKeys;
				}
				set
				{
					this.swallowKeys = value;
				}
			}

			private bool updateEl = false;

			/// <summary>
			/// True to update the innerHTML of the bound element when the update completes (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UpdateEl 
			{ 
				get
				{
					return this.updateEl;
				}
				set
				{
					this.updateEl = value;
				}
			}

			private string value = "";

			/// <summary>
			/// The data value of the underlying field (defaults to \"\")
			/// </summary>
			[DefaultValue("")]
			public virtual string Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}
        
			private Control targetControl = null;

			/// <summary>
			/// 
			/// </summary>
			public Control TargetControl
			{
				get
				{
					if (this.targetControl == null)
					{
						this.targetControl = new Control();
					}
			
					return this.targetControl;
				}
			}
			
			private string target = "";

			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}

			private bool useHtml = false;

			/// <summary>
			/// true to use innerHTML of bound element, otherwise innerText will be used
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseHtml 
			{ 
				get
				{
					return this.useHtml;
				}
				set
				{
					this.useHtml = value;
				}
			}

			private bool htmlEncode = false;

			/// <summary>
			/// True to encode value before start editing
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HtmlEncode 
			{ 
				get
				{
					return this.htmlEncode;
				}
				set
				{
					this.htmlEncode = value;
				}
			}

			private bool htmlDecode = false;

			/// <summary>
			/// True to decode value after editing
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HtmlDecode 
			{ 
				get
				{
					return this.htmlDecode;
				}
				set
				{
					this.htmlDecode = value;
				}
			}
        
			private InlineEditorListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public InlineEditorListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new InlineEditorListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private InlineEditorDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public InlineEditorDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new InlineEditorDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}