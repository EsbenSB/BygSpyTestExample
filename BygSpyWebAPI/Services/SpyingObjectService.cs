using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services.Interfaces;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace BygSpyWebAPI.Services
{
    public class SpyingObjectService : ISpyingObjectService
    {
        private readonly HttpClient _httpClient;
        private readonly ISpyingObjectRepository _spyingObjectRepository;
        public SpyingObjectService(HttpClient httpClient, ISpyingObjectRepository spyingObjectRepository)
        {
            _httpClient = httpClient;
            _spyingObjectRepository = spyingObjectRepository;
        }

        public async Task<List<SpyingObject>> GetAllSpyingObjectAsync()
        {
            try
            {
                var spyingObjects = await _spyingObjectRepository.GetAllSpyingObjectsAsync();
                return spyingObjects;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }

        public async Task<SpyingObject> GetSpyingObjectByIdAsync(string id)
        {
            var result = await _spyingObjectRepository.GetSpyingObjectAsync(id);
            return result;
        }

        public async Task<List<SpyingObject>> GetAllSpyingObjectsBySpyId(string spyId)
        {
            try
            {
                var spyingObjects = await _spyingObjectRepository.GetAllSpyingObjectsBySpyId(spyId);
                return spyingObjects;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }

        public async Task<SpyingObjectTempEntity> GetAddressIdAsync(string address)
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
                        spyingObjectTempEntity.AddressId = (string)jsonObject["id"];
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

        public async Task<string> GetJordstykkeFromAddressIdAsync(string addressId)
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


        public async Task<int> GetBfeFromJordstykkeAsync(string jordstykke)
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

        public async Task<int> GetGrundFromBfeAsync(int bfe)
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

        public async Task<SpyingObject> MapToSpyingObjectAsync(SpyingObjectTempEntity spyingObjectTempEntity, SpyingObject spyObject)
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

        public async Task CreateSpyObjectAsync(SpyingObject newSpyingObject)
        {
            try
            {
                newSpyingObject.Id = ObjectId.GenerateNewId().ToString();
                await _spyingObjectRepository.CreateSpyingObjectAsync(newSpyingObject);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
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

        public async Task DeleteSpyingObjectAsync(string id)
        {
            try
            {
                await _spyingObjectRepository.DeleteSpyingObjectAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private string EncodeingString(string StringToConvert)
        {
            var encoded_StringToConvert = StringToConvert.Replace(" ", "%");

            return encoded_StringToConvert;
        }

    }
}

