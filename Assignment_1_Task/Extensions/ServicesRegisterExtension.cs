using Assignment_1_Task.Interfaces;
using Assignment_1_Task.Services;

namespace Assignment_1_Task.Extensions
{
    public static class ServiceRegisterExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskExtensionService, TaskService>();

            return services;
        }
    }
}