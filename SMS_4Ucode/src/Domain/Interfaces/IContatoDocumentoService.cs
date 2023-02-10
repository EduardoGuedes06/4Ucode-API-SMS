

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContatoDocumentoService
    {

        Task DeleteAllContatos(ContatoDocumento documento);
        Task Adicionar(ContatoDocumento documento);
        Task Encapsular(string filePath);
    }
}
