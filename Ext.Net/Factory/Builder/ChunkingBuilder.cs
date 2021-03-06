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
    public partial class Chunking
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TChunking, TBuilder> : GridFeature.Builder<TChunking, TBuilder>
            where TChunking : Chunking
            where TBuilder : Builder<TChunking, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TChunking component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ChunkSize(int chunkSize)
            {
                this.ToComponent().ChunkSize = chunkSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RowHeight(int rowHeight)
            {
                this.ToComponent().RowHeight = rowHeight;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Chunking.Builder<Chunking, Chunking.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Chunking()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Chunking component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Chunking.Config config) : base(new Chunking(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Chunking component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Chunking.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Chunking(this);
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
        public Chunking.Builder Chunking()
        {
#if MVC
			return this.Chunking(new Chunking { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Chunking(new Chunking());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Chunking.Builder Chunking(Chunking component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Chunking.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Chunking.Builder Chunking(Chunking.Config config)
        {
#if MVC
			return new Chunking.Builder(new Chunking(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Chunking.Builder(new Chunking(config));
#endif			
        }
    }
}