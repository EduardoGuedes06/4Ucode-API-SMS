using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IConteudoClienteRepository : IRepository<ConteudoCliente>
    {
        Task<List<ConteudoCliente>> ObterClientePorId(Guid clienteId);
        Task<List<ConteudoCliente>> ObterConteudoPorCliente(Guid clienteId);
        Task <IEnumerable<ConteudoCliente>> BuscarComFiltroEPaginacao(Guid Cliente,int Pagina, int Tamanhopagina,int itensPorPagina, TextoClienteEnum ativo);
    }
}