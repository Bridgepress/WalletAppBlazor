using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WalletApp.Client.DTO.FlowMoney;

namespace WalletApp.Client.HttpRepositories
{
    public class FlowMoneyReposytory : IFlowMoneyReposytory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ILocalStorageService _localStorageService;
        private readonly string url = "FlowMoney";

        public FlowMoneyReposytory(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _localStorageService = localStorageService;
        }

        public async Task<CreateFlowMoneyDTO> AddFlowMoney(CreateFlowMoneyDTO flowMoney)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync<CreateFlowMoneyDTO>($"{url}/AddFlowMoney", flowMoney, _jsonSerializerOptions);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();

                CreateFlowMoneyDTO? result = JsonSerializer.Deserialize<CreateFlowMoneyDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<FlowMoneyDTO> DeleteFlowMoney(Guid id)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responce =
                await httpClient.DeleteAsync($"{url}/DeleteFlowMoney/{id}");
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();
                FlowMoneyDTO? result = JsonSerializer.Deserialize<FlowMoneyDTO>(
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

        public async Task<IEnumerable<FlowMoneyDetailsDTO>> GetListToDate(DateTime date)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            IEnumerable<FlowMoneyDetailsDTO> response =
                await httpClient.GetFromJsonAsync<IEnumerable<FlowMoneyDetailsDTO>>($"{url}/GetListToDate/{date.ToString("yyyy-MM-dd")}");
            return response.ToList();
        }

        public async Task<IEnumerable<FlowMoneyDetailsDTO>> GetAllListToBeginDateEndDate(DateTime beginDate, DateTime endDate)
        {
            var httpClient = CreateNamedHttpClient();
            var token = await _localStorageService.GetItemAsync<string>("token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            IEnumerable<FlowMoneyDetailsDTO> response =
                await httpClient.GetFromJsonAsync<IEnumerable<FlowMoneyDetailsDTO>>($"{url}/GetAllListToBeginDateEndDate/{beginDate.ToString("yyyy-MM-dd")}/{endDate.ToString("yyyy-MM-dd")}");
            return response.ToList();
        }
        private HttpClient CreateNamedHttpClient()
        {
            return _httpClientFactory.CreateClient("FlowMoneyAPI");
        }
    }
}
