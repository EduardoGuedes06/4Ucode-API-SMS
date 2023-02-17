

using Domain.Models.Enums;

namespace Domain.Models

{
        public class EnvioDocumento : Entity
        {

            public Guid NumeroId { get; set; }
            public string TextoEnvio { get; set; }
            public ContatoDocumento Numero { get; set; }
            public DadosCliente Cliente { get; set; }
            public EnvioEnum Enviado { get; set; }
    }
    
}