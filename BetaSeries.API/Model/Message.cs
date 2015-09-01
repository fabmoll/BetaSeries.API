using System;
using System.Collections.Generic;
using BetaSeries.API.Converters;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
	public class Sender
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }
	}

	public class Recipient
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("login")]
		public string Login { get; set; }
	}

	public class Message
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("message_id")]
		public int MessageId { get; set; }

		[JsonProperty("inner_id")]
		public int InnerId { get; set; }

		[JsonProperty("sender")]
		public Sender Sender { get; set; }

		[JsonProperty("recipient")]
		public Recipient Recipient { get; set; }

		[JsonProperty("date")]
		[JsonConverter(typeof(DateTimeConverterFromString))]
		public DateTime Date { get; set; }

		[JsonProperty("title")]
        public string Title { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("unread")]
		public bool Unread { get; set; }

		[JsonProperty("has_unread")]
		public bool HasUnread { get; set; }
	}

	public class MessageList
	{
		[JsonProperty("messages")]
		public List<Message> Messages { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}

	public class RootMessage
	{
		[JsonProperty("message")]
		public Message Message { get; set; }

		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }
	}
}