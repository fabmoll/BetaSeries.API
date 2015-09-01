using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
	public interface IMessageService
	{
		Task<IList<Message>> FindMessagesASync(int page = 0);
		Task<IList<Message>> GetDiscussionASync(int id);
		Task<Message> DeleteASync(int id);
		Task<Message> SendASync(int toId, string message, string title, int parentMessageId);
		Task<Message> MarkAsReadASync(int id);
	}

	public class MessageService : BaseService, IMessageService
	{
		private const string InboxUrl = "/messages/inbox";
		private const string DiscussionUrl = "/messages/discussion";
		private const string SendDeleteUrl = "/messages/message";
		private const string ReadUrl = "/messages/read";

		public async Task<IList<Message>> FindMessagesASync(int page = 0)
		{
			var postData = new Dictionary<string, string>();

			if (page > 0)
				postData.Add("page", page);

			var options = "?" + postData.ToQueryString();

			var response = await Get<MessageList>(InboxUrl + options);

			ValidateResponse(response);

			return response.Messages;

		}

		public async Task<IList<Message>> GetDiscussionASync(int id)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);

			var options = "?" + postData.ToQueryString();

			var response = await Get<MessageList>(DiscussionUrl + options);

			ValidateResponse(response);

			return response.Messages;
		}

		public async Task<Message> DeleteASync(int id)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);

			var options = "?" + postData.ToQueryString();

			var response = await Delete<RootMessage>(SendDeleteUrl + options);

			ValidateResponse(response);

			return response.Message;
		}

		public async Task<Message> SendASync(int toId, string message, string title, int parentMessageId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("to", toId);

			postData.Add("text", message);

			postData.Add("title", title);

			if (parentMessageId > 0)
				postData.Add("id", parentMessageId);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootMessage>(SendDeleteUrl + options, null);

			ValidateResponse(response);

			return response.Message;
		}

		public async Task<Message> MarkAsReadASync(int id)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootMessage>(ReadUrl + options, null);

			ValidateResponse(response);

			return response.Message;
		}
	}
}