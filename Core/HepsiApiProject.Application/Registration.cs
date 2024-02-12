using FluentValidation;
using HepsiApiProject.Application.Bases;
using HepsiApiProject.Application.Behaviors;
using HepsiApiProject.Application.Exceptions;
using HepsiApiProject.Application.Features.Products.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach (var item in types)
            {
                services.AddTransient(item);
            }

            return services;
        }
    }
}
