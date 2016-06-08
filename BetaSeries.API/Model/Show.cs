using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
    public class Show
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("thetvdb_id")]
        public int ThetvdbId { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("remaining")]
        public int Remaining { get; set; }

        [JsonProperty("unseen")]
        public List<Episode> UnseenEpisodes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("seasons")]
        public string Seasons { get; set; }

        [JsonProperty("seasons_details")]
        public List<SeasonsDetail> SeasonsDetails { get; set; }

        [JsonProperty("episodes")]
        public string Episodes { get; set; }

        [JsonProperty("images")]
        public Image Image { get; set; }

        [JsonProperty("followers")]
        public string Followers { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("similars")]
        public string Similars { get; set; }

        [JsonProperty("characters")]
        public string Characters { get; set; }

        [JsonProperty("creation")]
        public string Creation { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("notes")]
        public Note Notes { get; set; }

        [JsonProperty("in_account")]
        public bool InAccount { get; set; }

        [JsonProperty("aliases")]
        public List<string> Aliases { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("resource_url")]
        public string ResourceUrl { get; set; }
    }

    public class ShowList
    {
        [JsonProperty("shows")]
        public List<Show> Shows { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public class SeasonsDetail
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("episodes")]
        public int Episodes { get; set; }
    }

    public class User
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("remaining")]
        public string Remaining { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }
    }

    public class RootShow
    {
        [JsonProperty("show")]
        public Show Show { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public class Image
    {
        [JsonProperty("show")]
        public string Show { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("box")]
        public string Box { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }
    }
}