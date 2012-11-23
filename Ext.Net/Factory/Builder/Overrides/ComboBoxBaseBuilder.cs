/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class ComboBoxBase
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract partial class Builder<TComboBoxBase, TBuilder> : PickerField.Builder<TComboBoxBase, TBuilder>
            where TComboBoxBase : ComboBoxBase
            where TBuilder : Builder<TComboBoxBase, TBuilder>
        {
            public virtual TBuilder Store(Store store)
            {
                this.ToComponent().Store.Add(store);
                return this as TBuilder;
            }

            public virtual TBuilder Items(IEnumerable<ListItem> items)
            {
                this.ToComponent().Items.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder Items(params ListItem[] items)
            {
                this.ToComponent().Items.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder Items(ListItem item)
            {
                this.ToComponent().Items.Add(item);
                return this as TBuilder;
            }

            public virtual TBuilder Items(object items)
            {
                this.ToComponent().Items.Add(items);
                return this as TBuilder;
            }

            public virtual TBuilder Items(string item)
            {
                this.ToComponent().Items.Add(new ListItem(item));
                return this as TBuilder;
            }

            public virtual TBuilder Items(params string[] items)
            {
                this.ToComponent().Items.AddRange(items.Select(i=>new ListItem(i)));
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(IEnumerable<ListItem> items)
            {
                this.ToComponent().SelectedItems.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(params ListItem[] items)
            {
                this.ToComponent().SelectedItems.AddRange(items);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(ListItem item)
            {
                this.ToComponent().SelectedItems.Add(item);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(object items)
            {
                this.ToComponent().SelectedItems.Add(items);
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(string item)
            {
                this.ToComponent().SelectedItems.Add(new ListItem(item));
                return this as TBuilder;
            }

            public virtual TBuilder SelectedItems(params string[] items)
            {
                this.ToComponent().SelectedItems.AddRange(items.Select(i => new ListItem(i)));
                return this as TBuilder;
            }
        }
    }
}