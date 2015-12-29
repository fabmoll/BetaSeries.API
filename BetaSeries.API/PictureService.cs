using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Web.Http;
using BetaSeries.API.Extensions;

namespace BetaSeries.API
{
    public interface IPictureService
    {
        Task<byte[]> GetShowPictureASync(int showId, int width, int height);
        Task<byte[]> GetEpisodePictureASync(int episodeId, int width, int height);
        Task<byte[]> GetBadgePictureASync(int badgeId);
    }

    public class PictureService : BaseService, IPictureService
    {
        private const string ShowUrl = "/pictures/shows";
        private const string EpisodeUrl = "/pictures/episodes";
        private const string BadgeUrl = "/pictures/badges";

        public async Task<byte[]> GetShowPictureASync(int showId, int width, int height)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", showId);

            if (width != 0)
                postData.Add("width", width);

            if (height != 0)
                postData.Add("height", height);

            postData.Add("picked", "show");

            var options = "?" + postData.ToQueryString();

            var response = await Get(ShowUrl + options);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var stream = response.Content.ReadAsBufferAsync().GetResults();

            var byteArray = stream.ToArray();

            return byteArray.Length == 0 ? null : byteArray;
        }

        public async Task<byte[]> GetEpisodePictureASync(int episodeId, int width, int height)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", episodeId);

            if (width != 0)
                postData.Add("width", width);

            if (height != 0)
                postData.Add("height", height);

            postData.Add("picked", "show");

            var options = "?" + postData.ToQueryString();

            var response = await Get(EpisodeUrl + options);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var stream = response.Content.ReadAsBufferAsync().GetResults();

            var byteArray = stream.ToArray();

            return byteArray.Length == 0 ? null : byteArray;
        }

        public async Task<byte[]> GetBadgePictureASync(int badgeId)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", badgeId);

            var options = "?" + postData.ToQueryString();

            var response = await Get(BadgeUrl + options);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var stream = response.Content.ReadAsBufferAsync().GetResults();

            var byteArray = stream.ToArray();

            return byteArray.Length == 0 ? null : byteArray;
        }
    }
}