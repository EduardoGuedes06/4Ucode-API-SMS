

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContatoDocumentoService
    {

        Task AdicionarContatos(List<ContatoDocumento> contatos);

        Task Adicionar(ContatoDocumento contatoDocumento);
        Task Encapsular(string filePath);
    }
}
