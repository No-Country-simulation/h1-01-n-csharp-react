using Core.Behaviors;
using Core.Services;
using Core.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services)
        {
            // FluentValidation configuration
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Services
            services.AddHttpContextAccessor();
            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IClinicalHistoryService, ClinicalHistoryService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IMedicPatientService, MedicPatientService>();
            services.AddScoped<IMedicService, MedicService>();
            services.AddScoped<IMedRecordService, MedRecordService>();
            services.AddScoped<IPathologyService, PathologyService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<ISurgicalHistoryService, SurgicalHistoryService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<IUserService, UserService>();

            // Validation Behavior
            services.AddTransient(typeof(IValidationBehavior<>), typeof(ValidationBehavior<>));

            return services;
        }
    }
}
