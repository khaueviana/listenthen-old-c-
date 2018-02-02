using ListenThen.Application.Interfaces;
using ListenThen.Application.Services;
using ListenThen.Domain.Interfaces.Mail;
using ListenThen.Domain.Interfaces.Repository;
using ListenThen.Domain.Interfaces.UoW;
using ListenThen.Infra.CrossCutting.Messaging.Mail;
using ListenThen.Infra.Data.Context;
using ListenThen.Infra.Data.Repository;
using ListenThen.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace ListenThen.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ListenThenContext>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IOneToOneMeetingAppService, OneToOneMeetingAppService>();
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IJobTitleAppService, JobTitleAppService>();

            services.AddScoped<IOneToOneMeetingRepository, OneToOneMeetingRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
        }
    }
}