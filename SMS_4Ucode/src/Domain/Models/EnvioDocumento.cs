

namespace Domain.Models

{
        public class EnvioDocumento : Entity
        {

            public Guid NumeroId { get; set; }
            public string TextoEnvio { get; set; }
            public ContatoDocumento Numero { get; set; }
            public bool Enviado { get; set; }
    }
    
}