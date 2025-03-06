using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicaionServices(this IServiceCollection services)
        {
            // register services realted to application layer
            return services;
        }
    }
}
