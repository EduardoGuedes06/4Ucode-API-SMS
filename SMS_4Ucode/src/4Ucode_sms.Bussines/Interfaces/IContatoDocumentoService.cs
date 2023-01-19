

using Business.Models;

namespace Bussines.Interfaces
{
    public interface IContatoDocumentoService
    {
        Task Adicionar(ContatoDocumento documento);
    }
}
