using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;

namespace Performance.Web.Blazorwasm.Shared.Providers;

public class CustomHttpHandler : DelegatingHandler
{

    private ILocalStorageService _localStorageService;

    public CustomHttpHandler(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        if (request.RequestUri.AbsolutePath.ToLower().Contains("login"))
        {
            return await base.SendAsync(request, cancellationToken);
        }

        var token = await _localStorageService.GetItemAsync<string>("AuthToken");

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", $"Bearer {token}");
        }

        return await base.SendAsync(request, cancellationToken);

    }
}
