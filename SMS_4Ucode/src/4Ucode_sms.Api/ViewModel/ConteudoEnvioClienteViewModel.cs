using Domain.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Domain.Models
{
    public class ConteudoClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(450, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Texto { get; set; }
        public TextoClienteEnum Ativo { get; set; }

    }
    public class DadosClienteViewModel 
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string NomeCliente { get; set; }

        public int CountEnvios { get; set; }

    }

    public class PostDadosClienteViewModel
    {
  
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(25, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string NomeCliente { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid UserId { get; set; }
    }

    public class ConteudoPaginacaoViewModel
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int ItensPorPagina { get; set; }
        public TextoClienteEnum ativo { get; set; }
    }
}
