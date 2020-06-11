using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Rating
  {
    public int RatingId { get; set; }
    public int Stars { get; set; }
    public int PlaceId { get; set; }
    public int UserId { get; set; }
    public string Comments { get; set; }

    public static List<Rating> GetAll()
    {
      var apiCallTask = ApiHelper.GetAllRatings();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Rating> RatingList = JsonConvert.DeserializeObject<List<Rating>>(jsonResponse.ToString());

      return RatingList;
    }
    public static Rating GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetRating(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Rating rating = JsonConvert.DeserializeObject<Rating>(jsonResponse.ToString());

      return rating;
    }
    public static void Post(Rating rating)
    {
      string jsonRating = JsonConvert.SerializeObject(rating);
      var apiCallTask = ApiHelper.PostRating(jsonRating);
    }

    public static void Put(Rating rating)
    {
      string jsonRating = JsonConvert.SerializeObject(rating);
      var apiCallTask = ApiHelper.Put(rating.RatingId, jsonRating);
    }

    public static void DeleteRating(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}