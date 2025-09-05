using Day1;

public static class BuilderExtenstions
{
    public static void RegisterMyServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>(); // single instane of ProductService
        services.AddSingleton<IRepository<Product>, FileStorageRepository<Product>>(); // single instane of ProductService
        services.AddScoped<MessageService>();
    }
}