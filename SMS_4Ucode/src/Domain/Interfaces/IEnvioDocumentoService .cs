

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEnvioDocumentoService
    {
        Task Adicionar(EnvioDocumento documento);
    }
}
