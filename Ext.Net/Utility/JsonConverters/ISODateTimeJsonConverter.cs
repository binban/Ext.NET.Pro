/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Globalization;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    // ISODateTimeJsonConverter based on Newtonsoft.Json.Converters.IsoDateTimeConverter
    // The DateTimeFormat const was changed to remove the millisecond format specifier. 
    // Copyright (c) 2007 James Newton-King

    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53Z).
    /// </summary>
    public partial class ISODateTimeJsonConverter : ExtJsonConverter
    {
        private const string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";

        private DateTimeStyles dateTimeStyles = DateTimeStyles.RoundtripKind;

        /// <summary>
        /// Gets or sets the date time styles used when converting a date to and from JSON.
        /// </summary>
        /// <value>The date time styles used when converting a date to and from JSON.</value>
        public DateTimeStyles DateTimeStyles
        {
            get { return dateTimeStyles; }
            set { dateTimeStyles = value; }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">Serializer</param>
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            string text;

            if (value is DateTime || value is DateTime?)
            {
                DateTime dateTime = value is DateTime ? (DateTime)value : (value as DateTime?).Value;

                if ((dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                  || (dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                {
                    dateTime = dateTime.ToUniversalTime();
                }

                text = dateTime.ToString(ISODateTimeJsonConverter.DateTimeFormat, CultureInfo.InvariantCulture);
            }
            else
            {
                DateTimeOffset dateTimeOffset = (DateTimeOffset)value;

                if ((dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                  || (dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                    dateTimeOffset = dateTimeOffset.ToUniversalTime();

                text = dateTimeOffset.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
            }

            writer.WriteValue(text);
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

            if (reader.TokenType == JsonToken.Date)
            {
                return (DateTime)reader.Value;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new Exception("Unexpected token parsing date. Expected String, got {0}.".FormatWith(reader.TokenType));
            }

            string dateText = reader.Value.ToString();

            if (objectType == typeof(DateTimeOffset))
            {
                return DateTimeOffset.Parse(dateText, CultureInfo.InvariantCulture, dateTimeStyles);
            }

            return DateTime.Parse(dateText, CultureInfo.InvariantCulture, dateTimeStyles);
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