

using eShop.Ordering.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using OrderingContext dbContext = scope.ServiceProvider.GetRequiredService<OrderingContext>();

        dbContext.Database.Migrate();
    }
}
