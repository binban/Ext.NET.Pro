/********
 * @version   : 1.6.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Generic;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// Makes a ComboBox more closely mimic an HTML SELECT.  Supports clicking and dragging
    /// through the list, with item selection occurring when the mouse button is released.
    /// When used will automatically set editable to false and call unselectable
    /// on inner elements.  Re-enabling editable after calling this will NOT work.
    /// </summary>
    /// <new date="2009-12-04" owner="vladsch" key="SelectBox">
    /// Added new <see cref="SelectBox" /> control on <see cref="SelectBox" />.
    /// </new>

    public partial class SelectBox : ComboBox
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.form.SelectBox";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "selectbox";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(SelectBox), "Ext.Net.Build.Ext.Net.ux.extensions.selectbox.selectbox.js", "/ux/extensions/selectbox/selectbox.js"));

                return baseList;
            }
        }
    }
}