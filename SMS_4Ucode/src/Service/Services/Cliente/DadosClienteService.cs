using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DadosClienteService : BaseService, IDadosClienteService
    {
        private readonly IMapper _mapper;
        private readonly IDadosClienteRepository _dadosClienterepository;
        public DadosClienteService(INotificador notificador, 
                                    IDadosClienteRepository dadosClienterepository,
                                    IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _dadosClienterepository = dadosClienterepository;

        }

        public async Task Adicionar(DadosCliente dadosCliente)
        {
            await _dadosClienterepository.Adicionar(dadosCliente);
        }
    }
}
