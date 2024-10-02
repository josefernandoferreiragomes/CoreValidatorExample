using CoreValidatorExample.BusinessLayer.Repository;
using CoreValidatorExample.BusinessLayer.ValidationChainOfResponsibilityConcept;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.ApiLibrary.Tests.Unit
{
    public static class AppBuilder
    {
        // pass string[] args received from Main()
        public static WebApplication Create(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add some services
            builder.Services.AddTransient<IValidatorFacConcept<EmployeeExample>,EmployeeValidatorWithFactory>();
            builder.Services.AddSingleton<IEmployeeExampleRepository, EmployeeExampleRepository>();

            // built in way to validate scopes on Build()
            builder.Host.UseDefaultServiceProvider((_, serviceProviderOptions) =>
            {
                serviceProviderOptions.ValidateScopes = true;
                serviceProviderOptions.ValidateOnBuild = true;
            });

            return builder.Build();
        }
    }
}
