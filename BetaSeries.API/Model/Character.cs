using System.Collections.Generic;
using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("show_id")]
        public int ShowId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("actor")]
        public string Actor { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class RootCharacter
    {
        [JsonProperty("characters")]
        public List<Character> Characters { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}