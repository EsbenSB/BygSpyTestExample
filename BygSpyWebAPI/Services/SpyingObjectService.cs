using BygSpyWebAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using BygSpyWebAPI.Services.Interfaces;
using System.Net;
using BygSpyWebAPI.Models;
using ZstdSharp;
using BygSpyWebAPI.Repositories.Interfaces;

namespace BygSpyWebAPI.Services
{
    public class SpyingObjectService : ISpyingObjectService
    {
        
        private readonly DatabaseSettings _databaseSettings;
        private readonly HttpClient _httpClient;
        private readonly ISpyingObjectRepository _spyingObjectRepository;
        public SpyingObjectService(DatabaseSettings databaseSettings, HttpClient httpClient, ISpyingObjectRepository spyingObjectRepository)
        {
            _databaseSettings = databaseSettings;
            _httpClient = httpClient;
            _spyingObjectRepository = spyingObjectRepository;
        }

        public List<SpyingObject> CreateSpyObject()
        {
            // MongoDB operations to get all users
            return new List<SpyingObject>();
        }

        // til at lave et spyobject
        public async Task<SpyingObjectTempEntity> GetAddressId(string address)
        {

            try
            {
                SpyingObjectTempEntity spyingObjectTempEntity = new SpyingObjectTempEntity();
                var encoded_address = EncodeingString(address);
                string url = $"https://api.dataforsyningen.dk/adresser?q={encoded_address}";

              

                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        JArray jsonArray = JArray.Parse(jsonResponse);

                        foreach (JObject jsonObject in jsonArray)
                        {
                        spyingObjectTempEntity.addressId = (string)jsonObject["id"];
                        spyingObjectTempEntity.Street = (string)jsonObject["adgangsadresse"]["vejstykke"]["navn"];
                        spyingObjectTempEntity.City = (string)jsonObject["adgangsadresse"]["postnummer"]["navn"];

                        
                        if (spyingObjectTempEntity is not null)
                                return spyingObjectTempEntity;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public async Task<string> GetJordstykkeFromAddressId(string addressId)
        {

            try
            {
                var encoded_addressId = EncodeingString(addressId);
                string url = $"https://services.datafordeler.dk/DAR/DAR/2.0.0/rest/adresse?id={encoded_addressId}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JArray jsonArray = JArray.Parse(jsonResponse);

                    foreach (JObject jsonObject in jsonArray)
                    {

                        string jordstykke = (string)jsonObject["husnummer"]["jordstykke"];

                        if (!string.IsNullOrEmpty(jordstykke))
                            return jordstykke;
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }


        public async Task<int> GetBfeFromJordstykke(string jordstykke)
        {
            int bfeNummer = 0;
            try
            {
                string url = $"https://services.datafordeler.dk//BBR/BBRPublic/1/rest/grund?jordstykke={jordstykke}&&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";
               
                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        JArray jsonArray = JArray.Parse(jsonResponse);

                        foreach (JObject jsonObject in jsonArray)
                        {
                        bfeNummer = Convert.ToInt32((string)jsonObject["bestemtFastEjendom"]["bfeNummer"]);

                            return bfeNummer;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
          
            return bfeNummer;
        }

        public async Task<int> GetGrundFromBfe(int bfe)
        {
            int status = 0;
            try
            {
                string url = $"https://services.datafordeler.dk/BBR/BBRPublic/1/rest/grund?&bfenummer={bfe}&username=QRUSLIHSDE&password=SOFTWAREKval!tet2024";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JArray jsonArray = JArray.Parse(jsonResponse);

                    foreach (JObject jsonObject in jsonArray)
                    {
                        status = (int)jsonObject["status"];
                        
                            return status;
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return status;
        }

        public async Task PostSpyingObject(SpyingObject spyObject)
        {
            try
            {
               await _spyingObjectRepository.CreateSpyingObjectAsync(spyObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task DeleteSpyingObject(string bfe)
        {
            try
            {
                await _spyingObjectRepository.DeleteSpyingObjectAsync(bfe);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<SpyingObject>> GetAllSpyingObjectAsync() 
        {
            try {
                var spies = await _spyingObjectRepository.GetAllSpyingObjectAsync();
                return spies;
            }
            catch(Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }

        public async Task<SpyingObject> GetSpyingObjectByIdAsync(string bfe) 
        {
         var result = await _spyingObjectRepository.GetSpyingObjectByIdAsync(bfe);
            return result;
        }
        public async Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject)
        {
            try
            {
                await _spyingObjectRepository.UpdateSpyingObjectAsync(id, updatedSpyingObject);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        // slutning af at lave et spyobject

        public async Task<SpyingObject> MapToSpyingObject(SpyingObjectTempEntity spyingObjectTempEntity, SpyingObject spyObject)
        {
            try
            {
                spyObject.City = spyingObjectTempEntity.City;
                spyObject.Street = spyingObjectTempEntity.Street;
                return spyObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
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

        private string EncodeingString(string StringToConvert)
        {
            // Parse the JSON array
            var encoded_StringToConvert = StringToConvert.Replace(" ", "%");

          
            // If the array is empty or doesn't contain the "id" field, return null
            return encoded_StringToConvert;
        }

    }
}

