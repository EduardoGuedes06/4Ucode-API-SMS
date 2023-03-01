using Domain.Models.Enums;

namespace Domain.Models
{
    public class ConteudoCliente : Entity
    {
        public string Texto { get; set; }
        public Guid ClienteId { get; set; }
        public TextoClienteEnum Ativo { get; set; }
        public DadosCliente DadosCliente { get; set; }
    }
    public class DadosCliente : Entity
    {
        public string NomeCliente { get; set; }
        public Guid UserId { get; set; }
        public int CountEnvios { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<ConteudoCliente> ConteudoCliente { get; set; }

        public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }

        public IEnumerable<ContatoDocumento> ContatoDocumento { get; set; }

    }

    public class ConteudoPaginacao
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int ItensPorPagina { get; set; }
        public TextoClienteEnum ativo { get; set; }
    }

    //public class ApplicationUser : IdentityUser
    //{
    //    public DadosCliente? Cliente { get; set; }
    //}
}
