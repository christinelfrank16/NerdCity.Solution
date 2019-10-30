using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BAMCIS.GeoJSON;
using System;
using System.Linq;


namespace NerdCity.Models
{
    public class Feature
    {
        public static FeatureCollection GetFeatures(string searchTerm)
        {
            var apiCallTask = ApiCallHelper.PlacesApiCall(searchTerm);
            var result = apiCallTask.Result;
            Console.WriteLine(">>>>>>>>>>>>>" + result);
            // JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            FeatureCollection list = FeatureCollection.FromJson(result);
            return list;
        }
    }
}