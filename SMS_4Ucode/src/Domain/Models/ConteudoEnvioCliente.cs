using Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class ConteudoCliente : Entity
    {
        public string Texto { get; set; }
        public Guid IdCliente { get; set; }
        public TextoClienteEnum Ativo { get; set; }
        public DadosCliente DadosCliente { get; set; }
        //public IEnumerable<DadosCliente> DadosCliente { get; set; }
    }
    public class DadosCliente : Entity
    {
        public string NomeCliente { get; set; }
        
        public int CountEnvios { get; set; }


        public IEnumerable<ConteudoCliente> ConteudoCliente { get; set; }

        public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }
    }
    public class ConteudoPaginacao
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int ItensPorPagina { get; set; }
        public TextoClienteEnum ativo { get; set; }
    }
}
