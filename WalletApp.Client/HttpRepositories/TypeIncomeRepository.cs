using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WalletApp.Client.DTO.TypeIncome;

namespace WalletApp.Client.HttpRepositories
{
    public class TypeIncomeRepository : ITypeIncomeRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ILocalStorageService _localStorageService;
        private readonly string url = "TypeIncome";

        public TypeIncomeRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _localStorageService = localStorageService;
        }

        public async Task<TypeIncomeDTO> CreateTypeIncome(TypeIncomeDTO typeIncomeDTO)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync<TypeIncomeDTO>($"{url}/CreateTypeIncome", typeIncomeDTO);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();

                TypeIncomeDTO? result = JsonSerializer.Deserialize<TypeIncomeDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<TypeIncomeDTO> DeleteTypeIncome(Guid id)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.DeleteAsync($"{url}/DeleteTypeIncome/{id}");
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();
                TypeIncomeDTO? result = JsonSerializer.Deserialize<TypeIncomeDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<List<TypeIncomeDetailsDTO>> GetAllTypeIncome()
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            IEnumerable<TypeIncomeDetailsDTO> response =
                await httpClient.GetFromJsonAsync<IEnumerable<TypeIncomeDetailsDTO>>($"{url}/GetAllTypeIncome");
            return response.ToList();
        }

        private HttpClient CreateNamedHttpClient()
        {
            return _httpClientFactory.CreateClient("TypeIncomeAPI");
        }
    }
}
