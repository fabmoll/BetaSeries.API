using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
	public interface IFriendsService
	{
		Task<Member> AddASync(int memberId);
		Task<Member> RemoveASync(int memberId);
		Task<IList<User>> ListASync(bool blocked = false);
		Task<Member> BlockASync(int memberId);
		Task<Member> UnblockASync(int memberId);
	}

	public class FriendsService : BaseService, IFriendsService
	{
		private const string AddRemoveUrl = "/friends/friend";
		private const string ListUrl = "/friends/list";
		private const string BlockUnblockUrl = "/friends/block";

		public async Task<Member> AddASync(int memberId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", memberId);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootMember>(AddRemoveUrl + options, null);

			ValidateResponse(response);

			return response.Member;
		}

		public async Task<Member> RemoveASync(int memberId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", memberId);

			var options = "?" + postData.ToQueryString();

			var response = await Delete<RootMember>(AddRemoveUrl + options);

			ValidateResponse(response);

			return response.Member;
		}

		public async Task<IList<User>> ListASync(bool blocked = false)
		{
			var postData = new Dictionary<string, string>();

			if (blocked)
				postData.Add("blocked", 1);

			var options = "?" + postData.ToQueryString();

			var response = await Get<UserList>(ListUrl + options);

			ValidateResponse(response);

			return response.Users;
		}

		public async Task<Member> BlockASync(int memberId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", memberId);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootMember>(BlockUnblockUrl + options, null);

			ValidateResponse(response);

			return response.Member;
		}

		public async Task<Member> UnblockASync(int memberId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", memberId);

			var options = "?" + postData.ToQueryString();

			var response = await Delete<RootMember>(BlockUnblockUrl + options);

			ValidateResponse(response);

			return response.Member;
		}
	}
}