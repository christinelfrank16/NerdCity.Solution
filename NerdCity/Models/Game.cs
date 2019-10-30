using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NerdCity.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string[] Names { get; set; }
        public int YearPublished { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlaytime { get; set; }
        public int MaxPlaytime { get; set; }
        public int MinAge { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        // TODO: mechanics & categories
        public double AvgUserRating { get; set; }
        public int NumUserRatings { get; set; }

        public static List<Game> GetGames(string apiKey)
        {
            var apiCallTask = ApiCallHelper.GameApiCall(apiKey);
            var result = apiCallTask.Result;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Game> gameList = JsonConvert.DeserializeObject<List<Game>>(jsonResponse["games"].ToString());

            return gameList;
        }
    }
}