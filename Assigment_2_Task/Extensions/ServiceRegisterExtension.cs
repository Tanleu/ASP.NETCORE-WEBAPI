using Assigment_2_Task.DataContexts;
using Microsoft.EntityFrameworkCore;
using Assigment_2_Task.Services;
using Assigment_2_Task.Interfaces;

namespace Assigment_2_Task.Extensions
{
    public static class ServiceResgiterExtension
    {
        public static void RegisterAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PersonDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefauftConnection")));
            builder.Services.AddScoped<IPersonService, PersonDbService>();
        }
    }
}