/********
 * @version   : 1.5.0 - Ext.NET Pro License
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
    public partial class CommandSeparator
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridCommandBase.Builder<CommandSeparator, CommandSeparator.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CommandSeparator()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandSeparator component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CommandSeparator.Config config) : base(new CommandSeparator(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CommandSeparator component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandSeparator.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CommandSeparator(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandSeparator.Builder CommandSeparator()
        {
            return this.CommandSeparator(new CommandSeparator());
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandSeparator.Builder CommandSeparator(CommandSeparator component)
        {
            return new CommandSeparator.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandSeparator.Builder CommandSeparator(CommandSeparator.Config config)
        {
            return new CommandSeparator.Builder(new CommandSeparator(config));
        }
    }
}