/********
 * @version   : 1.5.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Globalization;
using Newtonsoft.Json;
using Ext.Net.Utilities;

namespace Ext.Net
{
    // JSONDateTimeJsonConverter based on Newtonsoft.Json.Converters.IsoDateTimeConverter
    // The JSONDateTimeJsonConverter returns the server's local time.
    // Copyright (c) 2007 James Newton-King

    /// <summary>
    /// Converts a <see cref="DateTime" /> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53) using the server
    /// time. Does not adjust for timezone.
    /// </summary>
    public partial class JSONDateTimeJsonConverter : ExtJsonConverter
    {
        private const string DateTimeFormatMs = "yyyy-MM-dd'T'HH:mm:ss.fff";
        private const string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";

        public virtual bool RenderMilliseconds
        {
            get;
            set;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime || value is DateTime?)
            {
                DateTime date = value is DateTime ? (DateTime)value : (value as DateTime?).Value;

                if (date != DateTime.MinValue)
                {
                    writer.WriteValue(date.ToString(this.RenderMilliseconds ? DateTimeFormatMs : DateTimeFormat, CultureInfo.InvariantCulture));
                }
                else
                {
                    writer.WriteRawValue("null");
                }

                return;
            }
            else
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)value;

                if (dateTimeOffset != DateTimeOffset.MinValue)
                {
                    writer.WriteValue(dateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture));
                }
                else
                {
                    writer.WriteRawValue("null");
                }
            }

            writer.WriteRawValue("null");
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">Existing Value</param>
        /// <param name="serializer">Serializer</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null && objectType.IsAssignableFrom(typeof(DateTime?)))
            {
                return null;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new Exception("Unexpected token parsing date. Expected String, got {0}.".FormatWith(reader.TokenType));
            }

            if (reader.Value.ToString().IsEmpty())
            {
                return null;
            }

            return DateTime.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return (typeof(DateTime).IsAssignableFrom(objectType)
              || typeof(DateTime?).IsAssignableFrom(objectType)
              || typeof(DateTimeOffset).IsAssignableFrom(objectType));
        }
    }
}