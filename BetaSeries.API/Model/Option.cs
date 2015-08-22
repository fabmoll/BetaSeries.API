using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Source
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("enabled")]
		public bool Enabled { get; set; }
	}

	public class Option
	{
		[JsonProperty("sources")]
		public List<Source> Sources { get; set; }

		[JsonProperty("downloaded")]
		public bool Downloaded { get; set; }

		[JsonProperty("notation")]
		public bool Notation { get; set; }

		[JsonProperty("timelag")]
		public bool Timelag { get; set; }

		[JsonProperty("global")]
		public bool Global { get; set; }

		[JsonProperty("friendship")]
		public string Friendship { get; set; }
	}


	public class RootOption
	{ 
		[JsonProperty("options")]
		public Option Option { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}

	public class OptionKey
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}

	public class RootOptionKey
	{
		[JsonProperty("option")]
		public OptionKey OptionKey { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}