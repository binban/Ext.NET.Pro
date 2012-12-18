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
    public partial class TreePanel
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTreePanel, TBuilder> : TreePanelBase.Builder<TTreePanel, TBuilder>
            where TTreePanel : TreePanel
            where TBuilder : Builder<TTreePanel, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTreePanel component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoteEditUrl(string remoteEditUrl)
            {
                this.ToComponent().RemoteEditUrl = remoteEditUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoteRemoveUrl(string remoteRemoveUrl)
            {
                this.ToComponent().RemoteRemoveUrl = remoteRemoveUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoteAppendUrl(string remoteAppendUrl)
            {
                this.ToComponent().RemoteAppendUrl = remoteAppendUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoteInsertUrl(string remoteInsertUrl)
            {
                this.ToComponent().RemoteInsertUrl = remoteInsertUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoteMoveUrl(string remoteMoveUrl)
            {
                this.ToComponent().RemoteMoveUrl = remoteMoveUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<TreePanelListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<TreePanelDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TreePanel.Builder<TreePanel, TreePanel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TreePanel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TreePanel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TreePanel.Config config) : base(new TreePanel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TreePanel component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TreePanel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TreePanel(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TreePanel.Builder TreePanel()
        {
#if MVC
			return this.TreePanel(new TreePanel { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TreePanel(new TreePanel());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TreePanel.Builder TreePanel(TreePanel component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TreePanel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TreePanel.Builder TreePanel(TreePanel.Config config)
        {
#if MVC
			return new TreePanel.Builder(new TreePanel(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TreePanel.Builder(new TreePanel(config));
#endif			
        }
    }
}