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

        public static async Task<string> PlacesApiCall(string searchTerm)
        {
            RestClient client = new RestClient("http://nominatim.openstreetmap.org/search");
            // NOT SURE WE CAN DO THIS
            RestRequest request = new RestRequest($"home.json?", Method.GET);
            request.AddParameter("q", searchTerm + " games");
            request.AddParameter("format", "geojson");
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}