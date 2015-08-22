using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Badge
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
        public string Description { get; set; }

		[JsonProperty("date")]
		public string Date { get; set; }
	}

	public class RootBadge
	{
		[JsonProperty("badges")]
		public List<Badge> Badges { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}