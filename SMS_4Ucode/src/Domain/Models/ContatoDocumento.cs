
namespace Domain.Models

{
        public class ContatoDocumento : Entity
        {
            public string numero { get; set; }
           
            public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }
        }
    
}