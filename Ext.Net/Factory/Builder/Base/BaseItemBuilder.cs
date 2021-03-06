/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;
using System;

namespace Ext.Net
{
    /*  Abstract
        -----------------------------------------------------------------------------------------------*/
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BaseItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public partial class Builder<TItem, TBuilder>
            where TItem : BaseItem
            where TBuilder : Builder<TItem, TBuilder>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public Builder(TItem item)
            {
                this.item = item;
            }

            /// <summary>
            /// 
            /// </summary>
            protected TItem item;

            /// <summary>
            /// Get the instance of the underlying StateManagedItem.
            /// </summary>
            /// <returns>Control</returns>
            public virtual TItem ToComponent()
            {
                return this.item;
            }

            /// <summary>
            /// Implicit conversion of a TItem object directly into a TComponent. 
            /// </summary>
            public static implicit operator TItem(BaseItem.Builder<TItem, TBuilder> builder)
            {
                return builder.ToComponent();
            }

            /// <summary>
            /// Collection of custom js config
            /// </summary>
            /// <param name="action">The action delegate</param>
            /// <returns>An instance of TBuilder</returns>
            public virtual TBuilder CustomConfig(Action<ConfigItemCollection> action)
            {
                action(this.ToComponent().CustomConfig);
                return this as TBuilder;
            }
        }
    }
}
