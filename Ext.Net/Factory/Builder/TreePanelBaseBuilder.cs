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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class TreePanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTreePanelBase, TBuilder> : TablePanel.Builder<TTreePanelBase, TBuilder>
            where TTreePanelBase : TreePanelBase
            where TBuilder : Builder<TTreePanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTreePanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The Ext.Net.Store the grid should use as its data source (required).
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Store(Action<StoreCollection<TreeStore>> action)
            {
                action(this.ToComponent().Store);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// An array of fields definition objects
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Fields(Action<ModelFieldCollection> action)
            {
                action(this.ToComponent().Fields);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// HiddenField name which submits selected nodes
			/// </summary>
            public virtual TBuilder SelectedHiddenName(string selectedHiddenName)
            {
                this.ToComponent().SelectedHiddenName = selectedHiddenName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// HiddenField name which submits checked nodes
			/// </summary>
            public virtual TBuilder CheckedHiddenName(string checkedHiddenName)
            {
                this.ToComponent().CheckedHiddenName = checkedHiddenName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.data.Model associated with this store
			/// </summary>
            public virtual TBuilder ModelName(string modelName)
            {
                this.ToComponent().ModelName = modelName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Model(Action<ModelCollection> action)
            {
                action(this.ToComponent().Model);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The Ext.grid.View used by the grid. This can be set before a call to render().
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder View(Action<ViewCollection<TreeView>> action)
            {
                action(this.ToComponent().View);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// true to enable animated expand/collapse (defaults to the value of Ext.enableFx)
			/// </summary>
            public virtual TBuilder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field inside the model that will be used as the node's text. Defaults to 'text'.
			/// </summary>
            public virtual TBuilder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically prepend a leaf sorter to the store. Defaults to undefined.
			/// </summary>
            public virtual TBuilder FolderSort(bool? folderSort)
            {
                this.ToComponent().FolderSort = folderSort;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable tree lines (defaults to true)
			/// </summary>
            public virtual TBuilder Lines(bool lines)
            {
                this.ToComponent().Lines = lines;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allows you to not specify a store on this TreePanel. This is useful for creating a simple tree with preloaded data without having to specify a TreeStore and Model. A store and model will be created and root will be passed to that store.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Root(Action<NodeCollection> action)
            {
                action(this.ToComponent().Root);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// false to hide the root node (defaults to true)
			/// </summary>
            public virtual TBuilder RootVisible(bool rootVisible)
            {
                this.ToComponent().RootVisible = rootVisible;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true if only 1 node per branch may be expanded
			/// </summary>
            public virtual TBuilder SingleExpand(bool singleExpand)
            {
                this.ToComponent().SingleExpand = singleExpand;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use Vista-style arrows in the tree (defaults to false)
			/// </summary>
            public virtual TBuilder UseArrows(bool useArrows)
            {
                this.ToComponent().UseArrows = useArrows;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
            public virtual TBuilder ColumnLines(bool columnLines)
            {
                this.ToComponent().ColumnLines = columnLines;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Selection submit config
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder SelectionSubmitConfig(Action<TreeSubmitConfig> action)
            {
                action(this.ToComponent().SelectionSubmitConfig);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Set to Remote need perform remote confirmation for basic operations.
			/// </summary>
            public virtual TBuilder Mode(TreePanelMode mode)
            {
                this.ToComponent().Mode = mode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use json mode
			/// </summary>
            public virtual TBuilder RemoteJson(bool remoteJson)
            {
                this.ToComponent().RemoteJson = remoteJson;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The list of actions which must be local (even if Mode='Remote')
			/// </summary>
            public virtual TBuilder LocalActions(string[] localActions)
            {
                this.ToComponent().LocalActions = localActions;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An object containing properties which are to be sent as parameters on any remote action request.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder RemoteExtraParams(Action<ParameterCollection> action)
            {
                action(this.ToComponent().RemoteExtraParams);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// if true then leaf node has no icon
			/// </summary>
            public virtual TBuilder NoLeafIcon(bool noLeafIcon)
            {
                this.ToComponent().NoLeafIcon = noLeafIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default URL to be used for requests to the server.
			/// </summary>
            public virtual TBuilder SubmitUrl(string submitUrl)
            {
                this.ToComponent().SubmitUrl = submitUrl;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}