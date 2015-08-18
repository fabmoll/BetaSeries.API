using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class SubTitle
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("quality")]
		public int Quality { get; set; }

		[JsonProperty("file")]
		public string File { get; set; }

		[JsonProperty("content")]
		public List<string> Content { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("episode")]
		public EpisodeInformation EpisodeInformation { get; set; }

		[JsonProperty("date")]
		public string Date { get; set; }

	}

	public class RootSubTitle
	{
		[JsonProperty("subtitles")]
		public List<SubTitle> Subtitles { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}

	public class EpisodeInformation
	{
		[JsonProperty("show_id")]
		public int ShowId { get; set; }

		[JsonProperty("episode_id")]
		public int EpisodeId { get; set; }

		[JsonProperty("season")]
		public int Season { get; set; }

		[JsonProperty("episode")]
		public int Episode { get; set; }
	}

}