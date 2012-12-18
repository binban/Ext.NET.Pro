/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// This class is a sequential id generator.
    /// </summary>
    [Meta]
    public partial class SequentialIdGenerator : ModelIdGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        public SequentialIdGenerator() 
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("type")]
        protected override string Type
        {
            get
            {
                return "sequential";
            }
        }

        /// <summary>
        /// The string to place in front of the sequential number for each generated id. The default is blank.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The string to place in front of the sequential number for each generated id. The default is blank.")]
        public virtual string Prefix
        {
            get
            {
                return this.State.Get<string>("Prefix", "");
            }
            set
            {
                this.State.Set("Prefix", value);
            }
        }

        /// <summary>
        /// The number at which to start generating sequential id's. The default is 1.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(1)]
        [Description("The number at which to start generating sequential id's. The default is 1.")]
        public virtual int Seed
        {
            get
            {
                return this.State.Get<int>("Seed", 1);
            }
            set
            {
                this.State.Set("Seed", value);
            }
        }
    }
}