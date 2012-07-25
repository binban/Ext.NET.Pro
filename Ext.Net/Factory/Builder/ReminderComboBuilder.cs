/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
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
    public partial class ReminderCombo
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComboBox.Builder<ReminderCombo, ReminderCombo.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ReminderCombo()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ReminderCombo component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ReminderCombo.Config config) : base(new ReminderCombo(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ReminderCombo component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The label text to display next to this Component (defaults to 'Reminder').
			/// </summary>
            public virtual ReminderCombo.Builder FieldLabel(string fieldLabel)
            {
                this.ToComponent().FieldLabel = fieldLabel;
                return this as ReminderCombo.Builder;
            }
             
 			/// <summary>
			/// The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'All').
			/// </summary>
            public virtual ReminderCombo.Builder TriggerAction(TriggerAction triggerAction)
            {
                this.ToComponent().TriggerAction = triggerAction;
                return this as ReminderCombo.Builder;
            }
             
 			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'Local' which loads from the server).
			/// </summary>
            public virtual ReminderCombo.Builder QueryMode(DataLoadMode queryMode)
            {
                this.ToComponent().QueryMode = queryMode;
                return this as ReminderCombo.Builder;
            }
             
 			/// <summary>
			/// true to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true)
			/// </summary>
            public virtual ReminderCombo.Builder ForceSelection(bool forceSelection)
            {
                this.ToComponent().ForceSelection = forceSelection;
                return this as ReminderCombo.Builder;
            }
             
 			/// <summary>
			/// The underlying data field name to bind to this ComboBox (defaults to 'desc').
			/// </summary>
            public virtual ReminderCombo.Builder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as ReminderCombo.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual ReminderCombo.Builder ValueField(string valueField)
            {
                this.ToComponent().ValueField = valueField;
                return this as ReminderCombo.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ReminderCombo(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ReminderCombo()
        {
            return this.ReminderCombo(new ReminderCombo());
        }

        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ReminderCombo(ReminderCombo component)
        {
            return new ReminderCombo.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ReminderCombo.Builder ReminderCombo(ReminderCombo.Config config)
        {
            return new ReminderCombo.Builder(new ReminderCombo(config));
        }
    }
}