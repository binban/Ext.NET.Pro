/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ItemsBuilder<TParent, TParentBuilder>
        : AbstractComponentCollectionBuilder<TParent, TParentBuilder>
        where TParent : AbstractContainer
        where TParentBuilder : AbstractContainer.Builder<TParent, TParentBuilder>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ItemsBuilder(TParent owner, TParentBuilder builder) : base(owner, builder) { }


        /*  Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public virtual ItemsBuilder<TParent, TParentBuilder> Add(AbstractComponent component)
        {
            this.Owner.Items.Add(component);
            return this;
        }

        /// TODO: .Add(Control control) // add to .Content() collection
        /// TODO: .Add(Func)            // add to .Content() collection

        public virtual ItemsBuilder<TParent, TParentBuilder> Add(AbstractComponent.Builder<TParent, TParentBuilder> builder)
        {
            this.Add(builder.ToComponent());
            return this;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual ItemsBuilder<TParent, TParentBuilder> AddRange(AbstractComponent[] components)
        {
            this.Owner.Items.AddRange(components);
            return this;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual ItemsBuilder<TParent, TParentBuilder> AddRange(AbstractComponent.Builder<TParent, TParentBuilder>[] builders)
        {
            this.AddRange(builders);
            return this;
        }
    }
}