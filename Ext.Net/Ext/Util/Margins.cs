/********
 * @version   : 1.3.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-02-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// An object containing margins to apply to the region when in the expanded state.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Description("An object containing margins to apply to the region when in the expanded state.")]
    public partial class Margins : IEquatable<Margins>
    {
        private int bottom;
        private int left;
        private int right;
        private int top;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Margins(int top, int right, int bottom, int left)
        {
            this.top = top;
            this.left = left;
            this.right = right;
            this.bottom = bottom;
        }

		/// <summary>
		/// 
		/// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
		[Description("")]
        public int Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
		[Description("")]
        public int Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
		[Description("")]
        public int Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
		[Description("")]
        public int Bottom
        {
            get { return this.bottom; }
            set { this.bottom = value; }
        }

        /// <summary>
        /// Does this object currently represent it's default state.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Does this object currently represent it's default state.")]
        public virtual bool IsDefault
        {
            get
            {
                return this.ToString().Equals("-1 -1 -1 -1");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return "{0} {1} {2} {3}".FormatWith(this.Top, this.Right, this.Bottom, this.Left);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool Equals(Margins margins)
        {
            return this.ToString().Equals(margins.ToString());
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool Equals(object obj)
        {
            if (!(obj is Margins))
            {
                return false;
            }

            return this.Equals((Margins) obj);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Clear()
        {
            this.Top = -1;
            this.Right = -1;
            this.Bottom = -1;
            this.Left = -1;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override int GetHashCode()
        {
            int result = Convert.ToInt32(this.Bottom);
            result = 29 * result + Convert.ToInt32(this.Left);
            result = 29 * result + Convert.ToInt32(this.Right);
            result = 29 * result + Convert.ToInt32(this.Top);

            return result;
        }
    }
}