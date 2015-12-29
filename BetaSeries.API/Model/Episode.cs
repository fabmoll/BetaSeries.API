using System;
using System.Collections.Generic;
using BetaSeries.API.Converters;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
    public class Episode
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("thetvdb_id")]
        public int ThetvdbId { get; set; }

        [JsonProperty("youtube_id")]
        public object YoutubeId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("season")]
        public int SeasonNumber { get; set; }

        [JsonProperty("episode")]
        public int EpisodeNumber { get; set; }

        [JsonProperty("show")]
        public ShowInformation ShowInformation { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("global")]
        public int Global { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        [JsonConverter(typeof(DateTimeConverterFromString))]
        public DateTime? Date { get; set; }

        [JsonProperty("note")]
        public Note Note { get; set; }

        [JsonProperty("user")]
        public UserInformation UserInformation { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("subtitles")]
        public List<SubTitle> Subtitles { get; set; }
    }

    public class RootEpisode
    {
        [JsonProperty("episode")]
        public Episode Episode { get; set; }

        [JsonProperty("note")]
        public int Note { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }

    public class ShowInformation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("thetvdb_id")]
        public int ThetvdbId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class UserInformation
    {
        [JsonProperty("seen")]
        public bool Seen { get; set; }

        [JsonProperty("downloaded")]
        public bool Downloaded { get; set; }
    }

    public class EpisodeList
    {
        [JsonProperty("episodes")]
        public List<Episode> Episodes { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}