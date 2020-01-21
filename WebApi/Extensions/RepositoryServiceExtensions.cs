

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiRepository.Contracts;
using WebApiRepository.Repositories;

namespace WebApi.Extensions
{
    /// <summary>
    /// Repository Service Extensions
    /// </summary>
    public static class RepositoryServiceExtensions
    {
        /// <summary>
        /// Configures all the respository services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IAdminDashboardRepository, AdminDashboardRepository>();
            //services.AddTransient<IDataCorrectionRepository, DataCorrectionRepository>();
            services.AddTransient<IGeochemSearchRepository, GeochemSearchRepository>();
            //services.AddTransient<IReviewDashboardRepository, ReviewDashboardRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            return services;
        }
    }
}
