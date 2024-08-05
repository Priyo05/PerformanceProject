using Performance.Web.WebBlazor.ViewModels.Auth;

namespace Performance.Web.WebBlazor.Services;
public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AuthService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(LoginViewModel loginViewModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginViewModel);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception(errorMessage);
        }

        var tokenResponse = await response.Content.ReadFromJsonAsync<TokenRespondDto>();
        return tokenResponse?.Token;
    }
}

