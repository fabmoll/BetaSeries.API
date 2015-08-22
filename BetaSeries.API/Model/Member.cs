using System;
using System.Collections.Generic;
using BetaSeries.API.Converters;
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
		public string ProfileBanner { get; set; }

		[JsonProperty("in_account")]
		public bool InAccount { get; set; }

		[JsonProperty("stats")]
		public Stats Stats { get; set; }

		[JsonProperty("shows")]
		public List<MemberShowInformation> Shows { get; set; }

		[JsonProperty("options")]
		public Options Options { get; set; }
	}
	
	public class RootMember
	{
		[JsonProperty("member")]
		public Member Member { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}

	public class MemberShowInformation
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("thetvdb_id")]
		public int ThetvdbId { get; set; }

		[JsonProperty("imdb_id")]
		public string ImdbId { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("seasons")]
		public string Seasons { get; set; }

		[JsonProperty("seasons_details")]
		public List<SeasonsDetail> SeasonsDetails { get; set; }

		[JsonProperty("episodes")]
		public string Episodes { get; set; }

		[JsonProperty("followers")]
		public string Followers { get; set; }

		[JsonProperty("comments")]
		public string Comments { get; set; }

		[JsonProperty("similars")]
		public string Similars { get; set; }

		[JsonProperty("characters")]
		public string Characters { get; set; }

		[JsonProperty("creation")]
		[JsonConverter(typeof(DateTimeConverterFromString))]
		public DateTime? Creation { get; set; }

		[JsonProperty("genres")]
		public List<string> Genres { get; set; }

		[JsonProperty("length")]
		public string Length { get; set; }

		[JsonProperty("network")]
		public string Network { get; set; }

		[JsonProperty("rating")]
		public string Rating { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("notes")]
		public Note Note { get; set; }

		[JsonProperty("in_account")]
		public bool InAccount { get; set; }

		[JsonProperty("aliases")]
		public List<string> Aliases { get; set; }

		[JsonProperty("user")]
		public Member Member { get; set; }

		[JsonProperty("resource_url")]
		public string ResourceUrl { get; set; }
	}

	public class SeasonsDetail
	{
		[JsonProperty("number")]
		public int Number { get; set; }

		[JsonProperty("episodes")]
		public int Episodes { get; set; }
	}

	public class MemberList
	{
		[JsonProperty("users")]
		public List<Member> Members { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}