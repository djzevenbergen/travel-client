namespace TravelClient.ViewModels
{
    public class LoginViewModel
    {
      public string Email {get;set;}
      public string Password {get;set;}
      
      // public static void Post(User user)
      // {
      //   string jsonUser = JsonConvert.SerializeObject(user);
      //   var apiCallTask = ApiHelper.Post(jsonUser);
      // }
    }
}