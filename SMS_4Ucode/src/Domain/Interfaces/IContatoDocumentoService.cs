

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContatoDocumentoService
    {
        Task Adicionar (ContatoDocumento contatoDocumento, Guid cliente);
        Task AdicionarContatos(List<ContatoDocumento> contatos);
        Task Encapsular(string filePath, Guid cliente);
    }
}
