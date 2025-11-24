using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PeNaEstrada.Client.Auth;
using System.Net.Http.Json;

namespace PeNaEstrada.Client.Services
{
    public class LoginRequest { public string Email { get; set; } public string Password { get; set; } }
    public class RegisterRequest { public string Email { get; set; } public string Password { get; set; } public string ConfirmPassword { get; set; } }
    public class AuthResponse { public string Token { get; set; } public string Message { get; set; } }

    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<string?> Login(LoginRequest loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<AuthResponse>();

                await _localStorage.SetItemAsync("authToken", response.Token);

                await _authStateProvider.GetAuthenticationStateAsync();

                return null; // Null significa sucesso
            }

            return "Erro ao fazer login. Verifique suas credenciais.";
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _authStateProvider.GetAuthenticationStateAsync();
        }

        public async Task<string?> Register(RegisterRequest registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);

            if (result.IsSuccessStatusCode) return null; // Sucesso

            return "Erro ao registrar usuário.";
        }
    }
}