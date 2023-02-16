using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Service.Services
{
    public class ContatoDocumentoService : BaseService, IContatoDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IContatoDocumentoRepository _contatoloadRepository;

        public ContatoDocumentoService(IContatoDocumentoRepository contato,INotificador notificador, IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _contatoloadRepository = contato;  
        }

        public async Task Adicionar(ContatoDocumento contatoDocumento)
        {
            await _contatoloadRepository.Adicionar(contatoDocumento);
        }

        public async Task AdicionarContatos(List<ContatoDocumento> contatos)
        {

            

            foreach (var contato in contatos)
            {
                await _contatoloadRepository.Adicionar(contato);
            }


        }

        public async Task DeleteAllContatos(ContatoDocumento documento)
        {

            await _contatoloadRepository.ObterTodos();




        }

        public Task Encapsular(string filePath)
        {

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
                    // Adiciona o 55
                    line = String.Concat("55", line);

                    // Tira o 55
                    //string replacement = "";
                    //string pattern = @"^.{2}";
                    //string result = Regex.Replace(line, pattern, replacement);
                    //line = result;
                }


                ContatoDocumento Contato = new ContatoDocumento()
                {
                    numero = line,
                };

                


                Adicionar(Contato);


               
            }

            file.Close();
            return Task.CompletedTask;

            
        }

    }
}
