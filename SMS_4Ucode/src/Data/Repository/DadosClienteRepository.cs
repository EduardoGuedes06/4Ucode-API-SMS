using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;


namespace Data.Repository
{
    public class DadosClienteRepository : Repository<DadosCliente>, IDadosClienteRepository
    {
        public DadosClienteRepository(MeuDbContext context) : base(context) { }
    }
}
