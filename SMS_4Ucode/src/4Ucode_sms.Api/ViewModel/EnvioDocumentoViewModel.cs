
using Domain.Models.Enums;

namespace _4Ucode_sms.Api.VewModel

{
    public class EnvioDocumentoViewModel
    {
        public Guid Id { get; set; }

        //public IEnumerable<ContatoViewModel>? Numeros { get; set; }

        public Guid NumeroId { get; set; }
        public string TextoEnvio { get; set; }

        public EnvioEnum Enviado { get; set; }


        public DateTime DataCadastro { get; set; }
    }
    public class PostDocumentoViewModel
    {
        public string TextoEnvio { get; set; }
        public Guid NumeroId { get; set; }


    }
}