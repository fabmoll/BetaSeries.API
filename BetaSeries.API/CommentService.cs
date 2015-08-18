using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
	public interface ICommentService
	{
		Task<RootComment> PostAsync(CommentType commentType, int id, string text, int inReplyTo = 0);
		Task<RootComment> DeleteAsync(int commentId);
		Task<CommentList> GetAsync(CommentType commentType, int id, int numberOfCommentByPage, int sinceId = 0);
	}

	public class CommentService : BaseService, ICommentService
	{
		private const string PostUrl = "/comments/comment";
		private const string GetUrl = "/comments/comments";
		private const string DeleteUrl = "/comments/comment";

		public async Task<RootComment> PostAsync(CommentType commentType, int id, string text, int inReplyTo = 0)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);
			postData.Add("text", text);
			postData.Add("type", commentType);

			if (inReplyTo != 0)
				postData.Add("in_reply_to", inReplyTo);

			var options = "?" + postData.ToQueryString();

			return await Post<RootComment>(PostUrl + options, null);
		}

		public async Task<RootComment> DeleteAsync(int commentId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", commentId);

			var options = "?" + postData.ToQueryString();

			return await Delete<RootComment>(DeleteUrl + options);
		}

		public async Task<CommentList> GetAsync(CommentType commentType, int id, int numberOfCommentByPage, int sinceId = 0)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);
			postData.Add("nbpp", numberOfCommentByPage);
			postData.Add("order", "desc");
			postData.Add("type", commentType);

			if (sinceId != 0)
				postData.Add("since_id", sinceId);

			var options = "?" + postData.ToQueryString();

			return await Get<CommentList>(GetUrl + options);
		}
	}
}