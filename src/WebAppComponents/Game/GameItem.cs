namespace eShop.WebAppComponents.Game;

public class ProjectItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; }= string.Empty;
    public bool IsIntegrated { get; set; } = false;
    public string Key { get; set; } = default!;
}
