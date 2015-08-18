using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
	public interface ICommentService
	{
		Task<Comment> PostAsync(CommentType commentType, int id, string text, int inReplyTo = 0);
		Task<Comment> DeleteAsync(int commentId);
		Task<IList<Comment>> GetAsync(CommentType commentType, int id, int numberOfCommentByPage, int sinceId = 0);
	}

	public class CommentService : BaseService, ICommentService
	{
		private const string PostUrl = "/comments/comment";
		private const string GetUrl = "/comments/comments";
		private const string DeleteUrl = "/comments/comment";

		public async Task<Comment> PostAsync(CommentType commentType, int id, string text, int inReplyTo = 0)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);
			postData.Add("text", text);
			postData.Add("type", commentType);

			if (inReplyTo != 0)
				postData.Add("in_reply_to", inReplyTo);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootComment>(PostUrl + options, null);

			ValidateResponse(response);

			return response.Comment;
		}

		public async Task<Comment> DeleteAsync(int commentId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", commentId);

			var options = "?" + postData.ToQueryString();

			var response = await Delete<RootComment>(DeleteUrl + options);

			ValidateResponse(response);

			return response.Comment;
		}

		public async Task<IList<Comment>> GetAsync(CommentType commentType, int id, int numberOfCommentByPage, int sinceId = 0)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", id);
			postData.Add("nbpp", numberOfCommentByPage);
			postData.Add("order", "desc");
			postData.Add("type", commentType);

			if (sinceId != 0)
				postData.Add("since_id", sinceId);

			var options = "?" + postData.ToQueryString();

			var response = await Get<CommentList>(GetUrl + options);

			ValidateResponse(response);

			return response.Comments;
		}
	}
}