using _4Ucode_sms.Bussines.Notificacoes;
using _4Ucode_sms.Bussines.Services;
using _4Ucode_sms.Data.Context;
using Business.Interfaces;
using Bussines.Interfaces;
using Data.Repository;

//using Data.Context;
//using Data.Repository;

namespace _4Ucode_sms.Api.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IContatoDocumentoRepository, ContatoDocumentoRepository>();
            services.AddScoped<IContatoDocumentoService, ContatoDocumentoService>();

            services.AddScoped<IEnvioDocumentoRepository, EnvioDocumentoRepository>();
            services.AddScoped<IEnvioDocumentoService, EnvioDocumentoService>();



            services.AddScoped<INotificador, Notificador>();

            //services.AddScoped<IContaJuridicaRepository, ContaJuridicaRepository>();
            //services.AddScoped<IContaJuridicaService, ContaJuridicaService>();

            //services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}
