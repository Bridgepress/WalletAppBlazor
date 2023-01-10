using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WalletApp.Client.DTO.FlowMoney;
using WalletApp.Client.DTO.TypeOfExpense;
using WalletApp.Domain.DTO.TypeOfExpense;

namespace WalletApp.Client.HttpRepositories
{
    public class TypeOfExpenseRepository : ITypeOfExpenseRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly string url = "TypeOfExpense";
        private readonly ILocalStorageService _localStorageService;

        public TypeOfExpenseRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _localStorageService = localStorageService;
        }

        public async Task<TypeOfExpenseDTO> CreateTypeOfExpense(TypeOfExpenseDTO typeOfExpenseDTO)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync<TypeOfExpenseDTO>($"{url}/CreateTypeOfExpense", typeOfExpenseDTO);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();

                TypeOfExpenseDTO? result = JsonSerializer.Deserialize<TypeOfExpenseDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<TypeOfExpenseDTO> DeleteTypeOfExpense(Guid id)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.DeleteAsync($"{url}/DeleteTypeOfExpense/{id}");
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();
                TypeOfExpenseDTO? result = JsonSerializer.Deserialize<TypeOfExpenseDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<List<TypeOfExpenseDetatilsDTO>> GetAllTypeOfExpense()
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            IEnumerable<TypeOfExpenseDetatilsDTO> response =
                await httpClient.GetFromJsonAsync<IEnumerable<TypeOfExpenseDetatilsDTO>>($"{url}/GetAllTypeOfExpense");
            return response.ToList();
        }

        private HttpClient CreateNamedHttpClient()
        {
            return _httpClientFactory.CreateClient("TypeOfExpenseAPI");
        }
    }
}
