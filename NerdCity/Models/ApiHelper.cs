using System.Threading.Tasks;
using RestSharp;


namespace NerdCity.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall(string clientId)
        {
            RestClient client = new RestClient("https://www.boardgameatlas.com/api/");
            //tacking on client ID NOT SURE WE CAN DO THIS
            RestRequest request = new RestRequest($"home.json?client_id={clientId}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}