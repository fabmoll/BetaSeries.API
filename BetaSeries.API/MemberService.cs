using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Attributes;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;
using Kulman.WPA81.BaseRestService.Services.Exceptions;

namespace BetaSeries.API
{
    public enum SortType
    {
        Asc,
        Desc
    }

    public enum Options
    {
        [Description("notation")]
        Notation,
        [Description("downloaded")]
        Downloaded,
        [Description("global")]
        Global,
        [Description("timelag")]
        Timelag,
        [Description("friendship")]
        Friendship
    }

    public enum FriendshipType
    {
        [Description("open")]
        Open,
        [Description("requests")]
        Requests,
        [Description("friends")]
        Friends,
        [Description("nobody")]
        Nobody
    }

    public interface IMemberService : IBaseService
    {
        Task<RootAuth> AuthASync(string login, string password);
        Task<bool> DisconnectASync(string token);
        Task<Member> InfosASync(int id = 0, bool summary = false);

        Task<RootAuth> SignupASync(string login, string password, string email);
        Task<IList<Member>> SearchMembersASync(string login);
        Task<IList<Badge>> FindBadgesASync(int id);

        Task<Option> GetOptions();
        Task<OptionKey> SetOption(Options options, bool value, FriendshipType friendshipType = FriendshipType.Open);

        //Task<IList<Notification>> FindNotificationsASync(int sinceId = 0, int number = 0, SortType sortType = SortType.Desc, bool autoDelete = false);
    }

    public class MemberService : BaseService, IMemberService
    {
        private const string AuthUrl = "/members/auth";
        private const string DisconnectUrl = "/members/destroy";
        private const string InfoUrl = "/members/infos";
        private const string BadgeUrl = "/members/badges";
        private const string SignupUrl = "/members/signup";
        private const string SearchUrl = "/members/search";
        private const string NotificationUrl = "/members/notifications";
        private const string OptionsUrl = "/members/options";
        private const string OptionUrl = "/members/option";

        public async Task<RootAuth> AuthASync(string login, string password)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("login", login);

            var md5Password = MD5CryptoServiceProvider.GetMd5String(password);

            postData.Add("password", md5Password);

            var options = "?" + postData.ToQueryString();

            RootAuth response;

            try
            {
                response = await Post<RootAuth>(AuthUrl + options, null);

                ValidateResponse(response);
            }
            catch (ConnectionException ex)
            {
                if (!string.IsNullOrEmpty(ex.ResponseContent))
                    ValidateResponse(ex.ResponseContent);

                throw;
            }
            
            return response;
        }

        public async Task<bool> DisconnectASync(string token)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("token", token);

            var options = "?" + postData.ToQueryString();

            var response = await Post<RootError>(DisconnectUrl + options, null);

            ValidateResponse(response);

            return true;
        }

        public async Task<Member> InfosASync(int id = 0, bool summary = false)
        {
            var postData = new Dictionary<string, string>();

            if (id != 0)
                postData.Add("id", id);

            if (summary)
                postData.Add("summary", "1");

            var options = "?" + postData.ToQueryString();

            var response = await Get<RootMember>(InfoUrl + options);

            ValidateResponse(response);

            return response.Member;
        }

        public async Task<RootAuth> SignupASync(string login, string password, string email)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("login", login);

            var md5Password = MD5CryptoServiceProvider.GetMd5String(password);

            postData.Add("password", md5Password);
            postData.Add("email", email);

            var options = "?" + postData.ToQueryString();

            var response = await Post<RootAuth>(SignupUrl + options, null);

            ValidateResponse(response);

            return response;
        }

        public async Task<IList<Member>> SearchMembersASync(string login)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("login", login + "%");

            var options = "?" + postData.ToQueryString();

            var response = await Get<MemberList>(SearchUrl + options);

            ValidateResponse(response);

            return response.Members;
        }

        public async Task<IList<Badge>> FindBadgesASync(int id)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", id);

            var options = "?" + postData.ToQueryString();

            var response = await Get<RootBadge>(BadgeUrl + options);

            ValidateResponse(response);

            return response.Badges;
        }

        public async Task<Option> GetOptions()
        {
            var response = await Get<RootOption>(OptionsUrl);

            ValidateResponse(response);

            return response.Option;

        }

        public async Task<OptionKey> SetOption(Options options, bool value, FriendshipType friendshipType = FriendshipType.Open)
        {
            var postData = new Dictionary<string, string>();

            if (options != Options.Friendship)
                postData.Add("value", value ? 1 : 0);
            else
            {
                postData.Add("value", friendshipType.GetDescription().ToLower());
            }

            postData.Add("name", options.GetDescription().ToLower());

            var parameter = "?" + postData.ToQueryString();

            var response = await Post<RootOptionKey>(OptionUrl + parameter, null);

            ValidateResponse(response);

            return response.OptionKey;
        }

        //public async Task<IList<Notification>> FindNotificationsASync(int sinceId = 0, int number = 0, SortType sortType = SortType.Desc, bool autoDelete = false)
        //{
        //	var postData = new Dictionary<string, string>();

        //	if (sinceId != 0)
        //		postData.Add("since_id", sinceId);

        //	if (number != 0)
        //		postData.Add("number", number);

        //	if (sortType != SortType.Desc)
        //		postData.Add("sort", "ASC");

        //	if (autoDelete)
        //		postData.Add("auto_delete", "1");

        //	var options = "?" + postData.ToQueryString();

        //	var response = await Get<RootNotification>(NotificationUrl + options);

        //	ValidateResponse(response);

        //	return response.Notifications;

        //}
    }
}