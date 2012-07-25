/********
 * @version   : 2.0.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace Ext.Net
{
    // Comments are Copyright (c) 2007 James Newton-King
    /// <summary>
    /// Convenience wrappers for Json.NET
    /// </summary>
    public partial class JSON
    {
        /// <summary>
        /// Serializes the specified object to a Json object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="converters">A List of JsonConverter objects to customize serialization.</param>
        /// <param name="quoteName">Gets or Sets a value indicating whether object names will be surrounded with quotes.</param>
        /// <param name="resolver">The IContractResolver object to customize serialization.</param>
        /// <returns>A Json string representation of the object.</returns>
        [Description("Serializes the specified object to a Json object.")]
        public static string Serialize(object obj, List<JsonConverter> converters, bool quoteName, IContractResolver resolver)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings { 
                ContractResolver = resolver,
                Converters = converters,             
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        /// <summary>
        /// Serializes the Json object to a specific object.
        /// </summary>
        /// <param name="value">Json object</param>
        /// <param name="type">Object's type</param>
        /// <param name="converters">A List of JsonConverter objects to customize deserialization.</param>
        /// <param name="resolver">The IContractResolver object to customize serialization.</param>
        /// <returns>Object</returns>
        [Description("Serializes the Json object to a specific object.")]
        public static object Deserialize(string value, Type type, List<JsonConverter> converters, IContractResolver resolver)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Converters = converters == null ? JSON.ConvertersInternal : converters;

            if (resolver != null)
            {
                settings.ContractResolver = resolver;
            }

            return JsonConvert.DeserializeObject(value, type, settings);
        }

        /// <summary>
        /// Serializes the specified object to a Json object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="converters">A List of JsonConverter objects to customize serialization.</param>
        /// <returns>A Json string representation of the object.</returns>
        [Description("Serializes the specified object to a Json object.")]
        public static string Serialize(object obj, List<JsonConverter> converters)
        {
            return JSON.Serialize(obj, converters, true, null);
        }

        /// <summary>
        /// Serializes the specified object to a Json object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A Json string representation of the object.</returns>
        [Description("Serializes the specified object to a Json object.")]
        public static string Serialize(object obj)
        {
            return JSON.Serialize(obj, JSON.ConvertersInternal, true, null);
        }

        /// <summary>
        /// Serializes the specified object to a Json object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="resolver">The IContractResolver object to customize serialization.</param>
        /// <returns>A Json string representation of the object.</returns>
        [Description("Serializes the specified object to a Json object.")]
        public static string Serialize(object obj, IContractResolver resolver)
        {
            return JSON.Serialize(obj, JSON.ConvertersInternal, true, resolver);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        private static List<JsonConverter> BaseConverters
        {
            get
            {
                List<JsonConverter> converters = new List<JsonConverter>();
                converters.Add(new EnumJsonConverter());
                converters.Add(new GuidJsonConverter());
                converters.Add(new JFunctionJsonConverter());
                converters.Add(new JRawValueJsonConverter());

                return converters;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static List<JsonConverter> Converters
        {
            get
            {
                List<JsonConverter> converters = JSON.BaseConverters;
                converters.Add(new JSONDateTimeJsonConverter());
                
                return converters;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static List<JsonConverter> DateMsConverters
        {
            get
            {
                List<JsonConverter> converters = JSON.BaseConverters;
                converters.Add(new JSONDateTimeJsonConverter { RenderMilliseconds = true });

                return converters;
            }
        }

        private static List<JsonConverter> dateMsConvertersInternal;

        internal static List<JsonConverter> DateMsConvertersInternal
        {
            get
            {
                if (dateMsConvertersInternal == null)
                {
                    dateMsConvertersInternal = JSON.DateMsConverters;
                }

                return dateMsConvertersInternal;
            }
        }

        //used internally to minimize Converters calling (less memory consumption)
        private static List<JsonConverter> convertersInternal;
        
        internal static List<JsonConverter> ConvertersInternal
        {
            get
            {
                if (convertersInternal == null)
                {
                    convertersInternal = JSON.Converters;
                }

                return convertersInternal;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static List<JsonConverter> ScriptConverters
        {
            get
            {
                List<JsonConverter> converters = JSON.BaseConverters;
                converters.Add(new CtorDateTimeJsonConverter());

                return converters;
            }
        }

        private static List<JsonConverter> scriptConvertersInternal;
       
        internal static List<JsonConverter> ScriptConvertersInternal
        {
            get
            {
                if (scriptConvertersInternal == null)
                {
                    scriptConvertersInternal = JSON.ScriptConverters;
                }

                return scriptConvertersInternal;
            }
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static object Deserialize(string value)
        {
            return JSON.Deserialize(value, null);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <param name="value">The object to deserialize.</param>
        /// <param name="type">The <see cref="Type"/> of object being deserialized.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static object Deserialize(string value, Type type)
        {
            return JSON.Deserialize(value, type, null, null);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <param name="value">The object to deserialize.</param>
        /// <param name="type">The <see cref="Type"/> of object being deserialized.</param>
        /// <param name="resolver">The IContractResolver object to customize serialization.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static object Deserialize(string value, Type type, IContractResolver resolver)
        {
            return JSON.Deserialize(value, type, null, resolver);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static T Deserialize<T>(string value)
        {
            return (T)JSON.Deserialize(value, typeof(T), null, null);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <param name="converters">A List of JsonConverter objects to customize serialization.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static T Deserialize<T>(string value, List<JsonConverter> converters)
        {
            return (T)JSON.Deserialize(value, typeof(T), converters, null);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <param name="resolver">The IContractResolver object to customize serialization.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static T Deserialize<T>(string value, IContractResolver resolver)
        {
            return (T)JSON.Deserialize(value, typeof(T), resolver);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <param name="converters">A List of JsonConverter objects to customize serialization.</param>
        /// <param name="resolver">The IContractResolver object to customize serialization.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static T Deserialize<T>(string value, List<JsonConverter> converters, IContractResolver resolver)
        {
            return (T)JSON.Deserialize(value, typeof(T), converters, resolver);
        }

        /// <summary>
        /// Deserializes the specified object to a Json object.
        /// </summary>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized object from the Json string.</returns>
        [Description("Deserializes the specified object to a Json object.")]
        public static XmlNode DeserializeXmlNode(string value)
        {
            return JsonConvert.DeserializeXmlNode(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string ToString(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Property:
                    return JSON.ToString(((JProperty)token).Value);
                case JTokenType.String:
                    return (string) token;
            }

            return token.ToString(Formatting.None);
        }
    }
}