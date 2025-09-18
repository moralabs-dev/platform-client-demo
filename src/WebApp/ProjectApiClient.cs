using System.Text.Json;
using eShop.WebApp.Models;

public class ProjectApiClient
{
    private readonly HttpClient _http;

    public ProjectApiClient(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient("ProjectClient");
    }

    public async Task<List<ProjectDto>> GetProjects()
    {
        var response = await _http.GetAsync("/project/public?RealmName=moragames");
        var success=  response.EnsureSuccessStatusCode();
        if (!success.IsSuccessStatusCode == true)
        {
            throw new Exception("Error");
        }
        else
        {
            var projects = await response.Content.ReadFromJsonAsync<List<ProjectDto>>();
            return projects ?? [];
        }
    }
}
