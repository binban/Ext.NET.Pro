/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GridHeaderContainerListeners : ContainerListeners
    {
        private ComponentListener columnHide;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnhide", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnHide
        {
            get
            {
                return this.columnHide ?? (this.columnHide = new ComponentListener());
            }
        }

        private ComponentListener columnMove;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// fromIdx : Number
        /// toIdx : Number
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "fromIdx", typeof(int), "")]
        [ListenerArgument(3, "toIdx", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnMove
        {
            get
            {
                return this.columnMove ?? (this.columnMove = new ComponentListener());
            }
        }

        private ComponentListener columnResize;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// width : Number
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "width", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnresize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnResize
        {
            get
            {
                return this.columnResize ?? (this.columnResize = new ComponentListener());
            }
        }

        private ComponentListener columnShow;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnshow", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener ColumnShow
        {
            get
            {
                return this.columnShow ?? (this.columnShow = new ComponentListener());
            }
        }

        private ComponentListener headerClick;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// e : Ext.EventObject
        /// t : HTMLElement
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "e", typeof(object), "")]
        [ListenerArgument(3, "t", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headerclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener HeaderClick
        {
            get
            {
                return this.headerClick ?? (this.headerClick = new ComponentListener());
            }
        }

        private ComponentListener headerTriggerClick;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// e : Ext.EventObject
        /// t : HTMLElement
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "e", typeof(object), "")]
        [ListenerArgument(3, "t", typeof(object), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headertriggerclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener HeaderTriggerClick
        {
            get
            {
                return this.headerTriggerClick ?? (this.headerTriggerClick = new ComponentListener());
            }
        }

        private ComponentListener menuCreate;

        /// <summary>
        /// Fired immediately after the column header menu is created.
        /// 
        /// Parameters
        /// item : Ext.grid.header.Container
        /// This instance
        /// 
        /// menu : Ext.menu.Menu
        /// The Menu that was created
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "menu", typeof(Menu), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("menucreate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener MenuCreate
        {
            get
            {
                return this.menuCreate ?? (this.menuCreate = new ComponentListener());
            }
        }

        private ComponentListener sortChange;

        /// <summary>
        /// Parameters
        /// item : Ext.grid.header.Container
        /// The grid's header Container which encapsulates all column headers.
        /// 
        /// column : Ext.grid.column.Column
        /// The Column header Component which provides the column definition
        /// 
        /// direction : String
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridHeaderContainer), "this")]
        [ListenerArgument(1, "column", typeof(ColumnBase), "")]
        [ListenerArgument(2, "direction", typeof(string), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sortchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener SortChange
        {
            get
            {
                return this.sortChange ?? (this.sortChange = new ComponentListener());
            }
        }
    }
}
