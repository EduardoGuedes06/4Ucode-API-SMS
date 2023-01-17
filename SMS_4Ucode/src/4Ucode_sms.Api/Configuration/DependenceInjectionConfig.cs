
using _4Ucode_sms.Bussines.Interfaces;
using _4Ucode_sms.Bussines.Notificacoes;
using _4Ucode_sms.Bussines.Services;
using _4Ucode_sms.Data.Context;
using _4Ucode_sms.Data.Repository;
using Business.Interfaces;

//using Data.Context;
//using Data.Repository;

namespace _4Ucode_sms.Api.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IBaseUploadRepository, BaseUploadRepository>();
            services.AddScoped<IBaseUploadService, BaseUploadService>();
            services.AddScoped<INotificador, Notificador>();

            //services.AddScoped<IContaJuridicaRepository, ContaJuridicaRepository>();
            //services.AddScoped<IContaJuridicaService, ContaJuridicaService>();

            //services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}
