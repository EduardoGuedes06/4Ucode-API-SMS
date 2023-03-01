
namespace Domain.Models

{
        public class ContatoDocumento : Entity
        {
            public Guid ClienteId { get; set; }
            public string numero { get; set; }

            public DateTime DataCadastro { get; set; }

            public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }

            public DadosCliente DadosCliente { get; set; }

    }
    
}