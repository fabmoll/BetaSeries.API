using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BetaSeries.API.Converters
{
	public class DateTimeConverterFromString : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			JToken token = JToken.Load(reader);
			if (token.Value<string>() != null)
			{
				DateTime dateTime;

				if (DateTime.TryParse(token.Value<string>(), out dateTime))
					return dateTime;

				return null;
			}
			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, ((DateTime)value).ToString(CultureInfo.InvariantCulture));
		}

	}
}