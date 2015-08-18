using System.Linq;
using System.Reflection;
using BetaSeries.API.Attributes;

namespace BetaSeries.API.Extensions
{
	internal static class AttributeExtensions
	{
		internal static string GetDescription(this object en)
		{
			var type = en.GetType();
			var memInfo = type.GetMember(en.ToString());

			if (memInfo.Length <= 0) return en.ToString();

			var attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);
			if (attrs != null && attrs.Any())
			{
				return ((Description)attrs.ElementAt(0)).Text;
			}

			return en.ToString();
		}
	}

}