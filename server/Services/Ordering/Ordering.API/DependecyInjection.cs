namespace Ordering.API
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            // register services realted to API layer
            return services;
        }

        public static WebApplication UseAPIServices(this WebApplication app)
        {
            // use services realted to API layer
            return app;
        }
    }
}
