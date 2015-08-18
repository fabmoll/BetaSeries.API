using BetaSeries.API.Attributes;

namespace BetaSeries.API.Model
{
	public enum Language
	{
		None = 0,
		[Description("all")]
		All = 1,
		[Description("vf")]
		Vf = 2,
		[Description("vo")]
		Vo = 3
	}
}