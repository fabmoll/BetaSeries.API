using BetaSeries.API.Attributes;

namespace BetaSeries.API.Model
{
	public enum CommentType
	{
		[Description("episode")]
		Episode,
		[Description("show")]
		Show,
		[Description("member")]
		Member,
		[Description("movie")]
		Movie
	}
}