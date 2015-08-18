using System.Collections.Generic;
using Kulman.WPA81.BaseRestService.Services.Abstract;

namespace BetaSeries.API
{
	public class BaseService : BaseRestService
	{
		public string Token { get; set; }
		public string ApiKey { get; set; }
		public string UserAgent { get; set; }

		protected override string GetBaseUrl()
		{
			return Settings.ApiUrl;
		}

		protected override Dictionary<string, string> GetRequestHeaders(string requestUrl)
		{
			var headers = new Dictionary<string, string>
						{
							{"Accept-Encoding", "gzip, deflate"},
							{"Accept", "application/json"},
							{"X-BetaSeries-Key", ApiKey },
							{"X-BetaSeries-Version", "2.4" }
						};

			if (!string.IsNullOrEmpty(Token))
				headers.Add("X-BetaSeries-Token", Token);

			if (!string.IsNullOrEmpty(UserAgent))
				headers.Add("User-Agent", UserAgent);

			return headers;
		}
	}
}