/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
    public partial class DropTarget
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DDTarget.Builder<DropTarget, DropTarget.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DropTarget()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DropTarget component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DropTarget.Config config) : base(new DropTarget(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DropTarget component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A named drag drop group to which this object belongs. If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).
			/// </summary>
            public virtual DropTarget.Builder Group(string group)
            {
                this.ToComponent().Group = group;
                return this as DropTarget.Builder;
            }
             
 			/// <summary>
			/// The CSS class returned to the drag source when drop is allowed (defaults to \"x-dd-drop-ok\").
			/// </summary>
            public virtual DropTarget.Builder DropAllowed(string dropAllowed)
            {
                this.ToComponent().DropAllowed = dropAllowed;
                return this as DropTarget.Builder;
            }
             
 			/// <summary>
			/// The CSS class returned to the drag source when drop is not allowed (defaults to \"x-dd-drop-nodrop\").
			/// </summary>
            public virtual DropTarget.Builder DropNotAllowed(string dropNotAllowed)
            {
                this.ToComponent().DropNotAllowed = dropNotAllowed;
                return this as DropTarget.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied to the drop target element while the drag source is over it (defaults to \"\").
			/// </summary>
            public virtual DropTarget.Builder OverClass(string overClass)
            {
                this.ToComponent().OverClass = overClass;
                return this as DropTarget.Builder;
            }
             
 			/// <summary>
			/// True to register this container with the Scrollmanager for auto scrolling during drag operations.
			/// </summary>
            public virtual DropTarget.Builder ContainerScroll(bool containerScroll)
            {
                this.ToComponent().ContainerScroll = containerScroll;
                return this as DropTarget.Builder;
            }
             
 			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the dragged item has been dropped on it. This method has no default implementation and returns false, so you must provide an implementation that does something to process the drop event and returns true so that the drag source's repair action does not run.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DropTarget.Builder</returns>
            public virtual DropTarget.Builder NotifyDrop(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyDrop);
                return this as DropTarget.Builder;
            }
			 
 			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the source is now over the target. This default implementation adds the CSS class specified by overClass (if any) to the drop element and returns the dropAllowed config value. This method should be overridden if drop validation is required.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DropTarget.Builder</returns>
            public virtual DropTarget.Builder NotifyEnter(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyEnter);
                return this as DropTarget.Builder;
            }
			 
 			/// <summary>
			/// The function a Ext.dd.DragSource calls once to notify this drop target that the source has been dragged out of the target without dropping. This default implementation simply removes the CSS class specified by overClass (if any) from the drop element.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DropTarget.Builder</returns>
            public virtual DropTarget.Builder NotifyOut(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyOut);
                return this as DropTarget.Builder;
            }
			 
 			/// <summary>
			/// The function a Ext.dd.DragSource calls continuously while it is being dragged over the target. This method will be called on every mouse movement while the drag source is over the drop target. This default implementation simply returns the dropAllowed config value.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of DropTarget.Builder</returns>
            public virtual DropTarget.Builder NotifyOver(Action<JFunction> action)
            {
                action(this.ToComponent().NotifyOver);
                return this as DropTarget.Builder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DropTarget(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder DropTarget()
        {
            return this.DropTarget(new DropTarget());
        }

        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder DropTarget(DropTarget component)
        {
            return new DropTarget.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DropTarget.Builder DropTarget(DropTarget.Config config)
        {
            return new DropTarget.Builder(new DropTarget(config));
        }
    }
}