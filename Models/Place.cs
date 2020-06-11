using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Place
  {
    public int PlaceId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Rating> Ratings { get; set; } 

    public static List<Place> GetPlaces()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Place> PlaceList = JsonConvert.DeserializeObject<List<Place>>(jsonResponse.ToString());

      return PlaceList;
    }

    public static Place GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Place place = JsonConvert.DeserializeObject<Place>(jsonResponse.ToString());

      return place;
    }
    public static void Post(Place place)
    {
      string jsonPlace = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.Post(jsonPlace);
    }

    public static void Put(Place place)
    {
      string jsonPlace = JsonConvert.SerializeObject(place);
      var apiCallTask = ApiHelper.Put(place.PlaceId, jsonPlace);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}