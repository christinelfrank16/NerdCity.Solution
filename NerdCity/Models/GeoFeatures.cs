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
        public static FeatureCollection GetFeatures(string key, string searchTerm)
        {
            var results = Result.GetResults(key, searchTerm);
            List<BAMCIS.GeoJSON.Feature> featureList = new List<BAMCIS.GeoJSON.Feature>();
            foreach(Result result in results)
            {
                Dictionary<string, dynamic> properties = new Dictionary<string,dynamic>();
                foreach(var prop in result.GetType().GetProperties())
                {
                    if(prop.Name != "Lat" && prop.Name != "Lng")
                    {
                        var propValue = prop.GetValue(result, null).ToString();
                        if(propValue.Contains("'")){
                            propValue = propValue.Replace("'", "");
                        }
                        properties.Add(prop.Name, propValue);
                    }
                }

                BAMCIS.GeoJSON.Feature feature = new BAMCIS.GeoJSON.Feature(new Point(new Position(result.Lng, result.Lat)), properties);
                featureList.Add(feature);
            }
            
            FeatureCollection list = new FeatureCollection(featureList);

            // JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            //FeatureCollection list = FeatureCollection.FromJson(result);
            return list;
        }
    }

    public class Result
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Group_sic_code_name { get; set; }

        public static List<Result> GetResults(string key, string searchTerm)
        {
            var apiCallTask = ApiCallHelper.PlacesApiCall(key, searchTerm);
            var result = apiCallTask.Result;
            Console.WriteLine(">>>>>>>>>>>>>" + result);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            var results = jsonResponse["searchResults"].Children().ToList();

            List<Result> resultList = new List<Result>();
            foreach(var resultItem in results)
            {
                JObject jtok = JsonConvert.DeserializeObject<JObject>(resultItem.ToString());

                Result rItem = JsonConvert.DeserializeObject<Result>(jtok["fields"].ToString());
                resultList.Add(rItem);
            }
            // List<Result> resultList = JsonConvert.DeserializeObject<List<Result>>(jsonResponse["searchResults/fields"].ToString());

            return resultList;

        }

    }
}