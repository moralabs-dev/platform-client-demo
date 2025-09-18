using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;

public class IdentityApiClient
{
    private readonly HttpClient _http;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityApiClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _http = httpClient;
        _httpContextAccessor = httpContextAccessor;
        Console.WriteLine("Http:");
        Console.WriteLine(JsonSerializer.Serialize(httpClient));
    }

    public async Task<bool> RegisterAsync(string Email, string Password)
    {
        var obj = new
        {
            Email,
            Password
        };
        Console.WriteLine("RegisterRequest", JsonSerializer.Serialize(obj));
        Console.WriteLine("Email", Email);
        Console.WriteLine("Password", Password);
        var response = await _http.PostAsJsonAsync("account/register", obj);

        return response.IsSuccessStatusCode;
    }

    public async Task<string> GetNavigationToken()
    {
        var cookies = _httpContextAccessor.HttpContext?.Request.Cookies;
        if (cookies == null)
            throw new Exception("401");
        var cookieHeader = string.Join("; ", cookies!.Select(c => $"{c.Key}={c.Value}"));

        var request = new HttpRequestMessage(HttpMethod.Get, "account/navigate");
        if (!string.IsNullOrEmpty(cookieHeader))
        {
            request.Headers.Add("Cookie", cookieHeader);
        }

        var response = await _http.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<ResponseBase<string>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return data?.Data ?? "";
        }
        else
        {
            throw new Exception("500");
        }
    }

}
