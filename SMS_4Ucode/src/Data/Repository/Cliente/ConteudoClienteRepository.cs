using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace _4Ucode_sms.Domain.Repository.Cliente
{
    public class ConteudoClienteRepository : Repository<ConteudoCliente>, IConteudoClienteRepository
    {
        public ConteudoClienteRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<ConteudoCliente>> BuscarComFiltroEPaginacao(Guid Cliente, int Pagina, int Tamanhopagina, int itensPorPagina, TextoClienteEnum ativo)
        {
            var quary = Db.ConteudoClientes.AsNoTracking()
            .Where(c => c.DadosCliente.Id == Cliente && c.Ativo == ativo)
            .Skip((Pagina - 1) * Tamanhopagina)
            .Take(itensPorPagina);

            return await quary.ToListAsync();
        }


        public async Task<List<ConteudoCliente>> ObterClientePorId(Guid clienteId)
        {
            return await Db.ConteudoClientes.AsNoTracking()
                .Where(c => c.DadosCliente.Id == clienteId)
                .ToListAsync();
        }
    }
}