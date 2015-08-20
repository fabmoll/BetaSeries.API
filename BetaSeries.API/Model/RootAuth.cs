using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class RootAuth
	{
		[JsonProperty("user")]
		public Member Member { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }

		[JsonProperty("hash")]
		public string Hash { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}