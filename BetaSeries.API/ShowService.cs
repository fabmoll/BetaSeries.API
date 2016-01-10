using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
    public interface IShowService : IBaseService
    {
        Task<IList<Show>> SearchASync(string title);
        Task<Show> DisplayASync(int showId, string user = "");
        Task<bool> ArchiveASync(int showId);
        Task<bool> UnArchiveASync(int showId);
        Task<IList<Episode>> FindEpisodesASync(int showId, int season = 0, int episode = 0, bool getSubTitles = false);
        Task<bool> AddShowASync(int showId);
        Task<bool> DeleteShowASync(int showId);
        Task<bool> NoteShowASync(int showId, int note);
        Task<IList<Character>> FindCharacters(int showId);
    }

    public class ShowService : BaseService, IShowService
    {
        private const string SearchUrl = "/shows/search";
        private const string DisplayUrl = "/shows/display";
        private const string ArchiveUrl = "/shows/archive";
        private const string EpisodesUrl = "/shows/episodes";
        private const string AddShowUrl = "/shows/show";
        private const string NoteUrl = "/shows/note";
        private const string CharacterUrl = "/shows/characters";

        public async Task<IList<Show>> SearchASync(string title)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("title", title);

            var options = "?" + postData.ToQueryString();

            var response = await Get<ShowList>(SearchUrl + options);

            ValidateResponse(response);

            return response.Shows;
        }

        public async Task<Show> DisplayASync(int showId, string user = "")
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            if (!string.IsNullOrEmpty(user))
                postData.Add("user", user);

            var options = "?" + postData.ToQueryString();

            var response = await Get<RootShow>(DisplayUrl + options);

            ValidateResponse(response);

            return response.Show;
        }

        public async Task<bool> ArchiveASync(int showId)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            var options = "?" + postData.ToQueryString();

            await Post(ArchiveUrl + options, null);

            return true;
        }

        public async Task<bool> UnArchiveASync(int showId)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            var options = "?" + postData.ToQueryString();

            await Delete(ArchiveUrl + options);

            return true;
        }

        public async Task<IList<Episode>> FindEpisodesASync(int showId, int season = 0, int episode = 0, bool getSubTitles = false)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            if (season != 0 && episode != 0)
            {
                postData.Add("season", season);
                postData.Add("episode", episode);
            }

            if (getSubTitles)
                postData.Add("subtitles", 1);

            var options = "?" + postData.ToQueryString();

            var response = await Get<EpisodeList>(EpisodesUrl + options);

            ValidateResponse(response);

            return response.Episodes;

        }

        public async Task<bool> AddShowASync(int showId)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            var options = "?" + postData.ToQueryString();

            var respoonse = await Post<RootShow>(AddShowUrl + options, null);

            ValidateResponse(respoonse);

            return true;
        }

        public async Task<bool> DeleteShowASync(int showId)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            var options = "?" + postData.ToQueryString();

            var respoonse = await Delete<RootShow>(AddShowUrl + options);

            ValidateResponse(respoonse);

            return true;
        }

        public async Task<bool> NoteShowASync(int showId, int note)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);
            postData.Add("note", note);

            var options = "?" + postData.ToQueryString();

            await Post(NoteUrl + options, null);

            return true;
        }

        public async Task<IList<Character>> FindCharacters(int showId)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            var options = "?" + postData.ToQueryString();

            var response = await Get<RootCharacter>(CharacterUrl + options);

            ValidateResponse(response);

            return response.Characters;
        }
    }
}