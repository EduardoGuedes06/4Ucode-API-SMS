

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContatoDocumentoService
    {

        Task DeleteAllContatos(ContatoDocumento documento);
        Task AdicionarContatos(List<ContatoDocumento> contatos);

        Task Adicionar(ContatoDocumento contatoDocumento);
        Task Encapsular(string filePath);
    }
}
