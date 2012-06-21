/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DirectEventJsonConverter : ExtJsonConverter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanConvert(Type valueType)
        {
            return typeof(ComponentDirectEvent).IsAssignableFrom(valueType);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && value is ComponentDirectEvent)
            {
                ComponentDirectEvent directEvent = (ComponentDirectEvent)value;

                if (!directEvent.IsDefault)
                {
                    Control owner = null;
                    MessageBusDirectEvent busEvent = directEvent as MessageBusDirectEvent;

                    if (this.Owner is BaseItem)
                    {
                        owner = ((BaseItem)this.Owner).Owner;
                    }
                    else if (this.Owner is Control)
                    {
                        owner = (Control)this.Owner;
                    }

                    directEvent.Owner = owner;
                    directEvent.ExtraParams.Owner = owner;

                    foreach (Parameter param in directEvent.ExtraParams)
                    {
                        param.Owner = owner;
                    }

                    HandlerConfig cfg = directEvent.GetListenerConfig();
                    if (cfg.Delay == 0 && directEvent.HasOwnDelay)
                    {
                        cfg.Delay = -1;
                    }

                    string deScope = directEvent.Scope;
                    directEvent.ClearListenerConfig();
                    
                    string configObject = new ClientConfig().SerializeInternal(directEvent, directEvent.Owner);

                    StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

                    cfgObj.Append(configObject);
                    cfgObj.Remove(cfgObj.Length - 1, 1);
                    cfgObj.AppendFormat("{0}control:this", configObject.Length > 2 ? "," : "");

                    if (busEvent != null)
                    {
                        cfgObj.Append(",eventType:'bus'");
                    }

                    if (busEvent == null)
                    {
                        if (this.PropertyName != "Click")
                        {
                            cfgObj.AppendFormat(",action:'{0}'", this.PropertyName);
                        }
                    }
                    else
                    {
                        cfgObj.AppendFormat(",action:'{0}:'+name", busEvent.Name);
                    }
                    

                    cfgObj.Append("}");

                    if (this.PropertyName.IsNotEmpty())
                    {
                        directEvent.SetArgumentList(this.Owner.GetType().GetProperty(this.PropertyName));
                    }

                    JFunction jFunction = new JFunction("Ext.net.directRequest(".ConcatWith(cfgObj.ToString(), ");"), directEvent.ArgumentList.ToArray());

                    string scope = deScope.IsEmpty() || deScope == "this" ? "" : deScope;

                    StringBuilder sb = new StringBuilder();
                    
                    sb.Append("{");
                    sb.Append("fn:").Append(jFunction.ToScript()).Append(",");

                    if (scope.Length > 0)
                    {
                        sb.Append("scope:").Append(scope).Append(",");
                    }

                    if (busEvent != null)
                    {
                        if (busEvent.Bus.IsNotEmpty())
                        {
                            sb.Append("bus:'").Append(busEvent.Bus).Append("',");
                        }
                        if (busEvent.Name.IsNotEmpty())
                        {
                            sb.Append("name:'").Append(busEvent.Name).Append("',");
                        }                                                
                    }

                    string cfgStr = cfg.Serialize();

                    if (cfgStr != "{}")
                    {
                        sb.Append(cfgStr.Chop());
                    }

                    if (sb[sb.Length - 1] == ',')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append("}");

                    writer.WriteRawValue(sb.ToString());

                    return;
                }
            }

            writer.WriteRawValue("{}");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}