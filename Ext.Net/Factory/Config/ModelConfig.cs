/********
 * @version   : 2.1.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
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
    public partial class Model
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Model(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Model.Config Conversion to Model
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Model(Model.Config config)
        {
            return new Model(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit Model.Config Conversion to Model.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Model.Builder(Model.Config config)
			{
				return new Model.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string name = null;

			/// <summary>
			/// The model name. Required
			/// </summary>
			[DefaultValue(null)]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			private string belongsTo = "";

			/// <summary>
			/// One or more BelongsTo associationa for this model.
			/// </summary>
			[DefaultValue("")]
			public virtual string BelongsTo 
			{ 
				get
				{
					return this.belongsTo;
				}
				set
				{
					this.belongsTo = value;
				}
			}

			private string hasMany = "";

			/// <summary>
			/// One or more HasMany associations for this model.
			/// </summary>
			[DefaultValue("")]
			public virtual string HasMany 
			{ 
				get
				{
					return this.hasMany;
				}
				set
				{
					this.hasMany = value;
				}
			}

			private string clientIdProperty = "clientId";

			/// <summary>
			/// The name of a property that is used for submitting this Model's unique client-side identifier to the server when multiple phantom records are saved
			/// </summary>
			[DefaultValue("clientId")]
			public virtual string ClientIdProperty 
			{ 
				get
				{
					return this.clientIdProperty;
				}
				set
				{
					this.clientIdProperty = value;
				}
			}

			private string extend = "Ext.data.Model";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("Ext.data.Model")]
			public virtual string Extend 
			{ 
				get
				{
					return this.extend;
				}
				set
				{
					this.extend = value;
				}
			}
        
			private ModelFieldCollection fields = null;

			/// <summary>
			/// An array of fields definition objects
			/// </summary>
			public ModelFieldCollection Fields
			{
				get
				{
					if (this.fields == null)
					{
						this.fields = new ModelFieldCollection();
					}
			
					return this.fields;
				}
			}
			
			private string iDProperty = "";

			/// <summary>
			/// The name of the field treated as this Model's unique id (defaults to 'id').
			/// </summary>
			[DefaultValue("")]
			public virtual string IDProperty 
			{ 
				get
				{
					return this.iDProperty;
				}
				set
				{
					this.iDProperty = value;
				}
			}
        
			private ProxyCollection proxy = null;

			/// <summary>
			/// The Proxy object which provides access to a data object.
			/// </summary>
			public ProxyCollection Proxy
			{
				get
				{
					if (this.proxy == null)
					{
						this.proxy = new ProxyCollection();
					}
			
					return this.proxy;
				}
			}
			        
			private AssociationCollection associations = null;

			/// <summary>
			/// Models associations
			/// </summary>
			public AssociationCollection Associations
			{
				get
				{
					if (this.associations == null)
					{
						this.associations = new AssociationCollection();
					}
			
					return this.associations;
				}
			}
			        
			private ValidationCollection validations = null;

			/// <summary>
			/// Models validations
			/// </summary>
			public ValidationCollection Validations
			{
				get
				{
					if (this.validations == null)
					{
						this.validations = new ValidationCollection();
					}
			
					return this.validations;
				}
			}
			        
			private ModelIdGeneratorCollection iDGen = null;

			/// <summary>
			/// The id generator to use for this model. The default id generator does not generate values for the idProperty.
			/// </summary>
			public ModelIdGeneratorCollection IDGen
			{
				get
				{
					if (this.iDGen == null)
					{
						this.iDGen = new ModelIdGeneratorCollection();
					}
			
					return this.iDGen;
				}
			}
			
        }
    }
}