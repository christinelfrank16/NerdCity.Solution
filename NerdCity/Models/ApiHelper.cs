using System.Threading.Tasks;
using RestSharp;


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

        public static async Task<string> PlacesApiCall()
        {
            RestClient client = new RestClient("http://nominatim.openstreetmap.org/");
            // NOT SURE WE CAN DO THIS
            RestRequest request = new RestRequest($"home.json?format=geojson", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}