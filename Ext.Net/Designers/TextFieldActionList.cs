/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TextFieldActionList : ExtControlActionList
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TextFieldActionList(IComponent component) : base(component) { }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public bool AllowBlank
        {
            get
            {
                return ((TextField)this.Control).AllowBlank;
            }
            set
            {
                this.GetPropertyByName("AllowBlank").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Text
        {
            get
            {
                return ((TextField)this.Control).Text;
            }
            set
            {
                this.GetPropertyByName("Text").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string EmptyText
        {
            get
            {
                return ((TextField)this.Control).EmptyText;
            }
            set
            {
                this.GetPropertyByName("EmptyText").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit Width
        {
            get
            {
                return ((TextField)this.Control).Width;
            }
            set
            {
                this.GetPropertyByName("Width").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public InputType InputType
        {
            get
            {
                return ((TextField)this.Control).InputType;
            }
            set
            {
                this.GetPropertyByName("InputType").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Grow
        {
            get
            {
                return ((TextField)this.Control).Grow;
            }
            set
            {
                this.GetPropertyByName("Grow").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit GrowMin
        {
            get
            {
                return ((TextField)this.Control).GrowMin;
            }
            set
            {
                this.GetPropertyByName("GrowMin").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit GrowMax
        {
            get
            {
                return ((TextField)this.Control).GrowMax;
            }
            set
            {
                this.GetPropertyByName("GrowMax").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddPropertyItem(new DesignerActionPropertyItem("Text", "Text", "500", "Change the Text of the control"));
            this.AddPropertyItem(new DesignerActionPropertyItem("EmptyText", "Empty Text", "500", "Change the Text of the control"));
            this.AddPropertyItem(new DesignerActionPropertyItem("AllowBlank", "AllowBlank", "500", "Ensure the length of the text is > 0"));
            this.AddPropertyItem(new DesignerActionPropertyItem("InputType", "Input Type", "500", "Change the input type of the control. [Text or Password]"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Width", "Width", "500", "Change the Width of the control"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Grow", "Grow", "500", "Change the TextField to automatically grow and shrink to its content"));

            DesignerActionPropertyItem growmin = new DesignerActionPropertyItem("GrowMin", "Grow Min Size", "500", "The minimum width to allow when grow = true");
            DesignerActionPropertyItem growmax = new DesignerActionPropertyItem("GrowMax", "Grow Max Size", "500", "The maximum width to allow when grow = true");

            if (((TextField)this.Control).Grow)
            {
                this.AddPropertyItem(growmin);
                this.AddPropertyItem(growmax);
            }
            else
            {
                this.RemovePropertyItem(growmin);
                this.RemovePropertyItem(growmax);
            }

            return base.GetSortedActionItems();
        }
    }
}