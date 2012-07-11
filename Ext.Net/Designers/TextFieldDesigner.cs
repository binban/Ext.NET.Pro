/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TextFieldDesigner : ExtControlDesigner
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml()
        {
            StringWriter writer = new StringWriter(CultureInfo.CurrentCulture);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);

            TextField c = (TextField)this.Control;

            string width = (c.Width != Unit.Empty) ? " width: {0};".FormatWith((c.Grow && c.GrowMin.Value > c.Width.Value) ? c.GrowMin.ToString() : c.Width.ToString()) : "";
            string height = (c.Height != Unit.Empty) ? " height: {0};".FormatWith(c.Height.ToString()) : "";

            object[] args = new object[7];
            args[0] = c.ClientID;
            args[1] = c.Text.IsEmpty() ? c.EmptyText : c.Text;
            args[2] = c.InputType.ToString().ToLower();
            args[3] = width;
            args[4] = height;
            args[5] = c.StyleSpec;
            args[6] = "x-form-text x-form-field " + (c.Text.IsEmpty() ? "x-form-empty-field " : "") + c.Cls;
            
            LiteralControl ctrl = new LiteralControl(string.Format(this.Html, args));
            ctrl.RenderControl(htmlWriter);

            return writer.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Html
        {
            get
            {
                /*
                 * 0 - ClientID
                 * 1 - Text
                 * 2 - Width
                 * 3 - Height
                 * 4 - Style
                 * 5 - Class
                 * 6 - InputType
                 */
                return @"<input value=""{1}"" type=""{2}"" style=""{5}{4}{3}"" class=""{6}"" />";
            }
        }

        private DesignerActionListCollection actionLists;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionListCollection XActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new TextFieldActionList(this.Component));
                }

                return actionLists;
            }
        }
    }
}