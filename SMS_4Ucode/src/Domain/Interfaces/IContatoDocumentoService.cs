

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContatoDocumentoService
    {
        Task Adicionar(ContatoDocumento documento);
        Task Encapsular(string filePath);
    }
}
