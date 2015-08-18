using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Show
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("thetvdb_id")]
		public int ThetvdbId { get; set; }

		[JsonProperty("imdb_id")]
		public string ImdbId { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("remaining")]
		public int Remaining { get; set; }

		[JsonProperty("unseen")]
		public List<Episode> Episodes { get; set; }
	}

	public class ShowList
	{
		[JsonProperty("shows")]
		public List<Show> Shows { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}