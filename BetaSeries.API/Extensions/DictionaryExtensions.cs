using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BetaSeries.API.Extensions
{
	internal static class DictionaryExtensions
	{
		internal static void Add(this Dictionary<string, string> postData, string key, int item)
		{
			postData.Add(key, item.ToString());
		}

		internal static void Add(this Dictionary<string, string> postData, string key, DateTime item)
		{
			postData.Add(key, item.ToString(CultureInfo.InvariantCulture));
		}

		internal static void Add<TEnum>(this Dictionary<string, string> postData, string key, TEnum item) where TEnum : struct
		{
			postData.Add(key, item.GetDescription().ToLower());
		}

		internal static void Add(this Dictionary<string, string> postData, string key, bool item)
		{
			postData.Add(key, item.ToString());
		}

		internal static void Add(this Dictionary<string, string> postData, string key, string item)
		{
			if (!string.IsNullOrEmpty(item))
			{
				postData.Add(key, item);
			}
		}

		internal static void Add<T>(this Dictionary<string, string> postData, string key, List<T> item)
		{
			if (item != null && item.Any())
			{
				postData.Add(key, string.Join(",", item));
			}
		}
	}

}