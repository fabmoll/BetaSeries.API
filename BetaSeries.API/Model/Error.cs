using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Error
	{
		[JsonProperty("code")]
		public int Code { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}

	public class RootError
	{
		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}