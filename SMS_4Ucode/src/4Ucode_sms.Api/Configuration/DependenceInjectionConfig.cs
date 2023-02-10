using _4Ucode_sms.Api.Extensions;
using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Notificacoes;
using Service.Services;

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

            services.AddScoped<ITwilloService, TwilloService>();
            services.AddScoped<ITwilloRepository, TwilloRepository>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
