using System;
using System.Collections.Generic;
using BetaSeries.API.Converters;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Comment
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("user_id")]
		public int UserId { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }

		[JsonProperty("avatar")]
		public object Avatar { get; set; }

		[JsonProperty("date")]
		[JsonConverter(typeof(DateTimeConverterFromString))]
		public DateTime? Date { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("inner_id")]
		public int InnerId { get; set; }

		[JsonProperty("in_reply_to")]
		public string InReplyTo { get; set; }

		[JsonProperty("replies")]
		public int Replies { get; set; }
	}

	public class RootComment
	{
		[JsonProperty("comment")]
		public Comment Comment { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}

	public class CommentList
	{
		[JsonProperty("comments")]
		public List<Comment> Comments { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}