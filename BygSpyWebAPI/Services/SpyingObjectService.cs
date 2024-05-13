using BygSpyWebAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using BygSpyWebAPI.Services.Interfaces;
namespace BygSpyServer.Services
{
    public class SpyingObjectService : ISpyingObjectService
    {
        //private readonly DatabaseSettings _databaseSettings;
        private readonly HttpClient _httpClient;
        public SpyingObjectService(HttpClient httpClient)
        {
            //_databaseSettings = databaseSettings;
            _httpClient = httpClient;
        }

        public List<SpyingObject> GetAllSpyingObjects()
        {
            // MongoDB operations to get all users
            return new List<SpyingObject>();
        }

        public List<SpyingObject> CreateSpyObject()
        {
            // MongoDB operations to get all users
            return new List<SpyingObject>();
        }

        public async Task<string> GetAddressId(string address)
        {
            
            try
            {
                string url = "https://services.datafordeler.dk//BBR/BBRPublic/1/rest/grund?jordstykke=1219804&&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";

                using (_httpClient)
                {
                  
                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        JArray jsonArray = JArray.Parse(jsonResponse);

                        foreach (JObject jsonObject in jsonArray)
                        {
                            string bfeNummer = (string)jsonObject["bestemtFastEjendom"]["bfeNummer"];

                            if (!string.IsNullOrEmpty(bfeNummer))
                                return bfeNummer;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Return null if an error occurred or no data found
            return null;


            //string encodedAddress = System.Web.HttpUtility.UrlEncode(address);

            //_httpClient.Timeout = TimeSpan.FromSeconds(30);



            ////string apiUrl = $"https://api.dataforsyningen.dk/adresser?q={encodedAddress}";
            //string apiUrl = $"https://services.datafordeler.dk/DAR/DAR/2.0.0/rest/adresse?id=0a3f50bc-7bb5-32b8-e044-0003ba298018&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
            //try
            //{
            //    var response = await _httpClient.GetAsync(apiUrl);
            //    var responseBody = await response.Content.ReadAsStringAsync();
            //    string id = ParseIdFromResponse(responseBody);
            //    return id;
            //}
            //catch (Exception ex)
            //{
            //    // Log or handle the exception
            //    return null; // or some default value
            //}
        }

        //todo move me to a json handler file
        private string ParseIdFromResponse(string responseBody)
        {
            // Parse the JSON array
            JArray jsonArray = JArray.Parse(responseBody);

            // Check if the array is not empty
            if (jsonArray.Count > 0)
            {
                // Extract the "id" field from the first address object
                return jsonArray[0]["id"].ToString();
            }

            // If the array is empty or doesn't contain the "id" field, return null
            return null;
        }



    }
}

