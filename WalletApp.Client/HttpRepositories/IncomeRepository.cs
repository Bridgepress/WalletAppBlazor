using Blazored.LocalStorage;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WalletApp.Client.DTO.Income;

namespace WalletApp.Client.HttpRepositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ILocalStorageService _localStorageService;
        private readonly string url = "Income";

        public IncomeRepository(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _localStorageService = localStorageService;
        }

        public async Task<CreateIncomeDTO> AddIncome(CreateIncomeDTO income)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync<CreateIncomeDTO>($"{url}/AddIncome", income, _jsonSerializerOptions);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();

                CreateIncomeDTO? result = JsonSerializer.Deserialize<CreateIncomeDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<IncomeDTO> DeleteIncome(Guid id)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.DeleteAsync($"{url}/DeleteIncome/{id}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();
                IncomeDTO? result = JsonSerializer.Deserialize<IncomeDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<decimal> GetAllDecimaltoDate(DateTime date)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            decimal response =
                await httpClient.GetFromJsonAsync<decimal>($"{url}/GetAllDecimalToDate/{date.ToString("yyyy-MM-dd")}");
            return response;
        }

        public async Task<decimal> GetAllDecimalToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            decimal response =
                await httpClient.GetFromJsonAsync<decimal>($"{url}/GetAllDecimalToBeginDateEndDate/{beginDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");
            return response;
        }

        public async Task<IEnumerable<IncomeDetailsDTO>> GetListToDate(DateTime date)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            IEnumerable<IncomeDetailsDTO> response =
                await httpClient.GetFromJsonAsync<IEnumerable<IncomeDetailsDTO>>($"{url}/GetListToDate/{date.ToString("yyyy-MM-dd")}");
            return response.ToList();
        }

        public async Task<IEnumerable<IncomeDetailsDTO>> GetAllListToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            IEnumerable<IncomeDetailsDTO> response =
                await httpClient.GetFromJsonAsync<IEnumerable<IncomeDetailsDTO>>($"{url}/GetAllListToBeginDateEndDate/{beginDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");
            return response.ToList();
        }
        private HttpClient CreateNamedHttpClient()
        {
            return _httpClientFactory.CreateClient("IncomeAPI");
        }
    }
}
