using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"places", Method.GET);
      request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"places/{id}", Method.GET);
            request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }


    public static async Task Post(string newPlace)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"places", Method.POST);
            request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlace);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newPlace)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"places/{id}", Method.PUT);
            request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlace);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"places/{id}", Method.DELETE);
            request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> GetAllRatings()
        {
          RestClient client = new RestClient("http://localhost:5004/api");
          RestRequest request = new RestRequest($"ratings", Method.GET);
                request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
          var response = await client.ExecuteTaskAsync(request);
          return response.Content;
        }

    public static async Task<string> GetRating(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"ratings/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostRating(string newRating)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"ratings", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRating);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutRating(int id, string newRating)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"ratings/{id}", Method.PUT);
            request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newRating);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteRating(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"ratings/{id}", Method.DELETE);
            request.AddParameter("Authorization", string.Format("Bearer "+ Token.UserToken), ParameterType.HttpHeader);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

  }
}