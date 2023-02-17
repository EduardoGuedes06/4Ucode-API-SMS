using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ConteudoCliente : Entity
    {
        string Texto { get; set; }
        public TextoClienteEnum Ativo { get; set; }
        public DadosCliente DadosCliente { get; set; }
    }
    public class DadosCliente : Entity
    {
        string NomeCliente { get; set; }
        
        public int CountEnvios { get; set; }

        public IEnumerable<ConteudoCliente> ConteudoCliente { get; set; }

        public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }
    }
}
