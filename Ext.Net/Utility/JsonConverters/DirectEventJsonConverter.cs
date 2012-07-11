/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
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
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && value is ComponentDirectEvent)
            {
                ComponentDirectEvent directEvent = (ComponentDirectEvent)value;
                if (!directEvent.IsDefault)
                {
                    Control owner = null;
                    if (this.Owner is StateManagedItem)
                    {
                        owner = ((StateManagedItem)this.Owner).Owner;
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
                    
                    string configObject = new ClientConfig().SerializeInternal(directEvent, directEvent.Owner);

                    StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

                    cfgObj.Append(configObject);
                    cfgObj.Remove(cfgObj.Length - 1, 1);
                    cfgObj.AppendFormat("{0}control:this", configObject.Length > 2 ? "," : "");

                    if (this.PropertyName != "Click")
                    {
                        cfgObj.AppendFormat(",action:'{0}'", this.PropertyName);
                    }

                    cfgObj.Append("}");

                    directEvent.SetArgumentList(this.Owner.GetType().GetProperty(this.PropertyName));
                    
                    JFunction jFunction = new JFunction("var params=arguments;Ext.net.DirectEvent.confirmRequest(".ConcatWith(cfgObj.ToString(), ");"), directEvent.ArgumentList.ToArray());
                    HandlerConfig cfg = directEvent.GetListenerConfig();
                    string scope = directEvent.Scope.IsEmpty() || directEvent.Scope == "this" ? "" : directEvent.Scope;

                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");

                    sb.Append("fn:").Append(jFunction.ToScript()).Append(",");

                    if (scope.Length > 0)
                    {
                        sb.Append("scope:").Append(scope).Append(",");
                    }

                    string cfgStr = cfg.ToJsonString();
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