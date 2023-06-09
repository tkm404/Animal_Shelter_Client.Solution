using System.Threading.Tasks;
using RestSharp;

namespace AnimalShelterClient.Models
{
  public class ApiHelper
  {
    
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetSearch(string category, string searchParam)
    {
      int animalAge;
      bool isValid = int.TryParse(searchParam, out animalAge);
      if (isValid)
      {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals?{category}={animalAge}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;      
      }

      if (searchParam == null)
      {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
      }

      else
      {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals?{category}={searchParam}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
      }


    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals/", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:8492");
      RestRequest request = new RestRequest($"api/animals/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);

    }
  }
}