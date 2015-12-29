using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetaSeries.API.Extensions;
using BetaSeries.API.Model;

namespace BetaSeries.API
{
    public interface IPlanningService
    {
        Task<IList<Episode>> GetForMemberAsync(string token, bool onlyUnseen, DateTime? monthPlanning);
        Task<IList<Episode>> GetForMemberAsync(int userId, bool onlyUnseen, DateTime? monthPlanning);
    }

    public class PlanningService : BaseService, IPlanningService
    {
        private const string MemberUrl = "/planning/member";


        public async Task<IList<Episode>> GetForMemberAsync(string token, bool onlyUnseen, DateTime? monthPlanning)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("token", token);

            if (onlyUnseen)
                postData.Add("unseen", "1");

            if (monthPlanning != null)
                postData.Add("month", monthPlanning.Value.ToString("yyyy-MM"));


            var options = "?" + postData.ToQueryString();


            var response = await Get<EpisodeList>(MemberUrl + options);

            ValidateResponse(response);

            return response.Episodes;
        }

        public async Task<IList<Episode>> GetForMemberAsync(int userId, bool onlyUnseen, DateTime? monthPlanning)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("id", userId);

            if (onlyUnseen)
                postData.Add("unseen", "1");

            if (monthPlanning != null)
                postData.Add("month", monthPlanning.Value.ToString("yyyy-MM"));


            var options = "?" + postData.ToQueryString();


            var response = await Get<EpisodeList>(MemberUrl + options);

            ValidateResponse(response);

            return response.Episodes;
        }
    }
}