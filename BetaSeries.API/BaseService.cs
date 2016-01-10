using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BetaSeries.API.Exceptions;
using BetaSeries.API.Model;
using Kulman.WPA81.BaseRestService.Services.Abstract;
using Newtonsoft.Json;

namespace BetaSeries.API
{
    public interface IBaseService
    {
        string Token { get; set; }
    }

    public class BaseService : BaseRestService, IBaseService
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

        protected void ValidateResponse<T>(T response)
        {
            var propertyInfo = response.GetType().GetProperty("Errors");

            if (propertyInfo != null)
            {
                var errors = (List<Error>)propertyInfo.GetValue(response, null);

                if (errors.Any())
                    throw new BetaSeriesErrorsException(errors);
            }

        }

        protected void ValidateResponse(string response)
        {
            var errors = JsonConvert.DeserializeObject<RootError>(response);

            ValidateResponse(errors);
        }
    }
}