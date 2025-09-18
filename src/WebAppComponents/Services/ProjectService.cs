using eShop.WebAppComponents.Game;
using eShop.WebAppComponents.Services;
using System.Net.Http.Json;

public class ProjectService : IProjectService
{
    private readonly HttpClient httpClient;

    public ProjectService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<ProjectItem>> GetProjects()
    {
        try
        {
            var response = await httpClient.GetAsync("/project/public?RealmName=moragames");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var projects = await response.Content.ReadFromJsonAsync<ResponseListBase<ProjectItem>>();
                return projects?.Data ?? [];
            }
            else
            {
                throw new Exception("asd"); //TODO:
            }
           
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return [];
        }
    }
}
