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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ItemsCollection<T> : List<T>
    {
	    public ItemsCollection()
        {
        }

        public ItemsCollection(bool singleItemMode)
        {
            this.SingleItemMode = singleItemMode;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();
                
                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        new public void Add(T item)
        {
            this.CheckItem(item);

            if (this.BeforeItemAdd != null)
            {
                this.BeforeItemAdd(item);
            }
            
            base.Add(item);

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Add(IEnumerable<T> collection)
        {
            this.AddRange(collection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        [Description("")]
        new public void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);

            foreach (T item in collection)
            {
                if (this.AfterItemAdd != null)
                {
                    this.AfterItemAdd(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        [Description("")]
        new public void Insert(int index, T item)
        {
            this.CheckItem(item);

            if (this.BeforeItemAdd != null)
            {
                this.BeforeItemAdd(item);
            } 
            
            base.Insert(index, item);

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        [Description("")]
        new public void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);

            foreach (T item in collection)
            {
                if (this.AfterItemAdd != null)
                {
                    this.AfterItemAdd(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        new public void Clear()
        {
            foreach (T item in this)
            {
                if (this.AfterItemRemove != null)
                {
                    this.AfterItemRemove(item);
                }
            }

            base.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        new public void Remove(T item)
        {
            base.Remove(item);

            if (this.AfterItemRemove != null)
            {
                this.AfterItemRemove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Description("")]
        new public void RemoveAt(int index)
        {
            T item = this[index];
            base.RemoveAt(index);

            if (this.AfterItemRemove != null)
            {
                this.AfterItemRemove(item);
            }
        }

        protected virtual void CheckItem(T item)
        {
            if (this.SingleItemMode && this.Count > 0)
            {
                throw new InvalidOperationException("Only one item is allowed in this Collection.");
            }
        }

        private bool singleItemMode = false;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool SingleItemMode
        {
            get
            {
                return this.singleItemMode;
            }
            protected internal set
            {
                this.singleItemMode = value;
            }
        }

        public delegate void BeforeItemAddHandler(T item);
        public event BeforeItemAddHandler BeforeItemAdd;

        public delegate void AfterItemAddHandler(T item);
        public event AfterItemAddHandler AfterItemAdd;

        public delegate void AfterItemRemoveHandler(T item);
        public event AfterItemRemoveHandler AfterItemRemove;
    }
}