using AutoMapper;
using Data.Repository;
using Domain.Interfaces;
using Domain.Models;
using NPOI.SS.Formula.Functions;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Service.Services
{
    public class ContatoDocumentoService : BaseService, IContatoDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IContatoDocumentoRepository _contatoloadRepository;
        private readonly IDadosClienteRepository _dadosClienteRepository;

        public ContatoDocumentoService(IContatoDocumentoRepository contato,
                                                INotificador notificador, 
                                                IMapper mapper,
                                                IDadosClienteRepository dadosClienteRepository) : base(notificador)
        {
            _mapper = mapper;
            _contatoloadRepository = contato;
            _dadosClienteRepository = dadosClienteRepository;
        }

        public async Task Adicionar(ContatoDocumento contatoDocumento, Guid cliente)
        {
            contatoDocumento.ClienteId = cliente;
            await _contatoloadRepository.Adicionar(contatoDocumento);
        }

        public async Task AdicionarContatos(List<ContatoDocumento> contatos)
        {

            foreach (var contato in contatos)
            {
                var clienteVerificacao = await _dadosClienteRepository.ObterPorId(contato.ClienteId);
                if (clienteVerificacao == null)
                {
                    Notificar("Cliente não encontrado");
                    return;

                }
                var count = 0;
                foreach (char item in contato.numero)
                {
                    count++;
                }
                if (count == 11)
                {
                    contato.numero = String.Concat("55", contato.numero);
                }
                await _contatoloadRepository.Adicionar(contato);
            }


        }

        public async Task Encapsular(string filePath, Guid cliente)
        {
            var clienteVerificacao = await _dadosClienteRepository.ObterPorId(cliente);
            if (clienteVerificacao == null)
            {
                Notificar("Cliente não encontrado");
                return;
            }

            ArrayList array = new ArrayList();
            var file = new StreamReader(filePath);
            string? line;
            while ((line = file.ReadLine()) != null)
            {
                int count = 0;
                foreach (char item in line)
                {
                    count++;
                }
                if (count == 11)
                {
                    line = String.Concat("55", line);
                }


                ContatoDocumento Contato = new ContatoDocumento()
                {
                    numero = line,
                };

                


                Adicionar(Contato, cliente);


               
            }

            file.Close();


        
            
        }

    }
}
