using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Stats
	{
		[JsonProperty("friends")]
		public int Friends { get; set; }

		[JsonProperty("shows")]
		public int Shows { get; set; }

		[JsonProperty("seasons")]
		public int Seasons { get; set; }

		[JsonProperty("episodes")]
		public int Episodes { get; set; }

		[JsonProperty("comments")]
		public int Comments { get; set; }

		[JsonProperty("progress")]
		public double Progress { get; set; }

		[JsonProperty("episodes_to_watch")]
		public int EpisodesToWatch { get; set; }

		[JsonProperty("time_on_tv")]
		public int TimeOnTv { get; set; }

		[JsonProperty("time_to_spend")]
		public int TimeToSpend { get; set; }

		[JsonProperty("badges")]
		public int Badges { get; set; }
	}

	public class Member
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("xp")]
		public int Xp { get; set; }

		[JsonProperty("cached")]
		public int Cached { get; set; }

		[JsonProperty("avatar")]
		public string Avatar { get; set; }

		[JsonProperty("profile_banner")]
		public object ProfileBanner { get; set; }

		[JsonProperty("in_account")]
		public bool InAccount { get; set; }

		[JsonProperty("stats")]
		public Stats Stats { get; set; }
	}

	public class RootMember
	{
		[JsonProperty("member")]
		public Member Member { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}


}