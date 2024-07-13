using JustinaBack.Models.Utilities.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddModelsProfiles(this IServiceCollection services)
        {
            //Add Automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
