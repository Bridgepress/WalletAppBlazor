using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WalletApp.Client.DTO.AppUser;

namespace WalletApp.Client.HttpRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly string url = "AppUser";
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AppUserRepository(IHttpClientFactory httpClientFactory, HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<UserDTO> registerUser(RegisterDTO registerDTO)
        {
            var httpClient = CreateNamedHttpClient();
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync<RegisterDTO>($"{url}/register", registerDTO);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();

                UserDTO? result = JsonSerializer.Deserialize<UserDTO>(
                    stringRsponse, _jsonSerializerOptions);
                return result;
            }
            return null;
        }

        public async Task<UserDTO> loginUser(LoginDTO login)
        {
            var httpClient = CreateNamedHttpClient();
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync<LoginDTO>($"{url}/Login", login, _jsonSerializerOptions);
            if (responce.IsSuccessStatusCode)
            {
                string stringRsponse = await responce.Content.ReadAsStringAsync();
                UserDTO? result = JsonSerializer.Deserialize<UserDTO>(
                    stringRsponse, _jsonSerializerOptions);
                if (result is not null)
                {
                    await _localStorage.SetItemAsync("token", result.Token);
                    ((IdentityAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

                }
                return result;
            }
            return null;
        }

        public async Task Logout()
        {
            var httpClient = CreateNamedHttpClient();
            HttpResponseMessage responce =
                await httpClient.PostAsJsonAsync($"{url}/Logout", _jsonSerializerOptions);
        }

        private HttpClient CreateNamedHttpClient()
        {
            return _httpClientFactory.CreateClient("AppUserAPI");
        }
    }
}
