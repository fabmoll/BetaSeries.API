using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
	public interface IEpisodeService : IBaseService
	{
		Task<Episode> GetASync(int episodeId, bool getSubTitles = false);
		Task<IList<Show>> FindEpisodesToWatchASync(int showId = 0, int limit = 0, Language language = Language.None);
		Task<Episode> NoteASync(int episodeId, int note);
		Task<Episode> RemoveNoteASync(int episodeId);
		Task<Episode> MarkAsWatchedASync(int episodeId, bool bulk = false);
		Task<Episode> MarkAsWatchedASync(int episodeId, int score, bool bulk = false);
		Task<Episode> GetASync(int showId, int globalEpisodeNumber);
		Task<Episode> MarkAsUnwatchedASync(int episodeId);
	}

	public class EpisodeService : BaseService, IEpisodeService
	{

		private const string DisplayUrl = "/episodes/display";
		private const string EpisodeToWatchUrl = "/episodes/list";
		private const string NoteUrl = "/episodes/note";
		private const string WatchedUrl = "/episodes/watched";
		private const string SearchUrl = "/episodes/search";

		public async Task<Episode> GetASync(int episodeId, bool getSubTitles = false)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", episodeId);

			if (getSubTitles)
				postData.Add("subtitles", 1);

			var options = "?" + postData.ToQueryString();

			var response = await Get<RootEpisode>(DisplayUrl + options);

			ValidateResponse(response);

			return response.Episode;
		}

		public async Task<IList<Show>> FindEpisodesToWatchASync(int showId = 0, int limit = 0, Language language = Language.None)
		{
			var postData = new Dictionary<string, string>();

			if (showId != 0)
				postData.Add("id", showId);
			if (limit != 0)
				postData.Add("limit", limit);
			if (language != Language.None)
				postData.Add("subtitles", language);

			var options = "?" + postData.ToQueryString();

			var response = await Get<ShowList>(EpisodeToWatchUrl + options);

			ValidateResponse(response);

			return response.Shows;
		}

		public async Task<Episode> NoteASync(int episodeId, int note)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", episodeId);
			postData.Add("note", note);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootEpisode>(NoteUrl + options, null);

			ValidateResponse(response);

			return response.Episode;
		}

		public async Task<Episode> RemoveNoteASync(int episodeId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", episodeId);

			var options = "?" + postData.ToQueryString();

			var response = await Delete<RootEpisode>(NoteUrl + options);

			ValidateResponse(response);

			return response.Episode;
		}

		public async Task<Episode> MarkAsWatchedASync(int episodeId, bool bulk = false)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", episodeId);

			if (bulk)
				postData.Add("bulk", 1);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootEpisode>(WatchedUrl + options, null);

			ValidateResponse(response);

			return response.Episode;
		}

		public async Task<Episode> MarkAsWatchedASync(int episodeId, int score, bool bulk = false)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", episodeId);
			postData.Add("note", score);

			if (bulk)
				postData.Add("bulk", 1);

			var options = "?" + postData.ToQueryString();

			var response = await Post<RootEpisode>(WatchedUrl + options, null);

			ValidateResponse(response);

			return response.Episode;
		}

		public async Task<Episode> GetASync(int showId, int globalEpisodeNumber)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("show_id", showId);
			postData.Add("number", globalEpisodeNumber);

			var options = "?" + postData.ToQueryString();

			var response = await Get<RootEpisode>(SearchUrl + options);

			ValidateResponse(response);

			return response.Episode;
		}

		public async Task<Episode> MarkAsUnwatchedASync(int episodeId)
		{
			var postData = new Dictionary<string, string>();

			postData.Add("id", episodeId);

			var options = "?" + postData.ToQueryString();

			var response = await Delete<RootEpisode>(WatchedUrl + options);

			ValidateResponse(response);

			return response.Episode;
		}
	}
}