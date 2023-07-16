using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoApp_N_tier.Business.Interfaces;
using ToDoApp_N_tier.Business.Mappings.AutoMapper;
using ToDoApp_N_tier.Business.Services;
using ToDoApp_N_tier.Business.ValidationRules.Work;
using ToDoApp_N_tier.DataAccess.Contexts;
using ToDoApp_N_tier.DataAccess.UnitOfWork;
using ToDoApp_N_tier.Dtos.WorkDtos;

namespace ToDoApp_N_tier.Business.DependencyResolvers.Microsoft
{
    public static class DependecyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var mapperConfiguration =new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper =mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();

        }
    }
}
