using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class User
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("in_account")]
		public bool InAccount { get; set; }
	}

	public class UserList
	{
		[JsonProperty("users")]
		public List<User> Users { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}