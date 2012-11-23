/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// A layout that arranges items vertically down a Container. This layout optionally divides available vertical space between child items containing a numeric flex configuration.
    /// This layout may also be used to set the widths of child items by configuring it with the align option.
	/// </summary>
	[Description("")]
    public partial class VBoxLayoutConfig : BoxLayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public VBoxLayoutConfig()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        [DefaultValue("")]
        protected override string LayoutType
        {
            get
            {
                return "vbox";
            }
        }

		/// <summary>
		/// Controls how the child items of the container are aligned. Acceptable configuration values for this property are:
        ///     left : Default child items are aligned horizontally at the left side of the container
        ///     center : child items are aligned horizontally at the mid-width of the container
        ///     stretch : child items are stretched horizontally to fill the width of the container
        ///     stretchmax : child items are stretched horizontally to the size of the largest item.
        /// Defaults to: "left"
		/// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(VBoxAlign.Left)]
		[Description("")]
        public VBoxAlign Align
        {
            get
            {
                return this.State.Get<VBoxAlign>("Align", VBoxAlign.Left);
            }
            set
            {
                this.State.Set("Align", value);
            }
        }

        /// <summary>
        /// Limits the size of aligned components to the size of the container under certain circumstances. Firstly, the container width must not be determined by the width of the child components. Secondly, the child components must have their width shrinkwrapped. Defaults to: false
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("")]
        public bool ConstrainAlign
        {
            get
            {
                return this.State.Get<bool>("ConstrainAlign", false);
            }
            set
            {
                this.State.Set("ConstrainAlign", value);
            }
        }
    }
}