using System.Threading.Tasks;
using RestSharp;
using System;


namespace NerdCity.Models
{
    class ApiCallHelper
    {
        public static async Task<string> GameApiCall(string clientId)
        {
            RestClient client = new RestClient("https://www.boardgameatlas.com/api/");
            //tacking on client ID NOT SURE WE CAN DO THIS
            RestRequest request = new RestRequest($"home.json?client_id={clientId}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> PlacesApiCall(string key, string origin)
        {
            RestClient client = new RestClient("https://www.mapquestapi.com/search/v2/radius");
            // NOT SURE WE CAN DO THIS
            RestRequest request = new RestRequest($"?key={key}", Method.GET);
            origin = "Portland, OR";
            request.AddParameter("origin", origin);
            request.AddParameter("radius", "25");
            request.AddParameter("ambiguities", "ignore");
            request.AddParameter("hostedData", "mqap.ntpois|name ILIKE ?|%game% ");
            Console.WriteLine("??????" + client.BuildUri(request));
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        // public static async Task<string> PlacesApiCall(string key, string searchTerm)
        // {
        //     RestClient client = new RestClient("http://open.mapquestapi.com/nominatim/v1/search.php");
        //     // NOT SURE WE CAN DO THIS
        //     RestRequest request = new RestRequest($"home.json?", Method.GET);
        //     request.AddParameter("q", searchTerm + " game");
        //     request.AddParameter("key", key);
        //     request.AddParameter("format", "json");
        //     var response = await client.ExecuteTaskAsync(request);
        //     return response.Content;
        // }
    }
}