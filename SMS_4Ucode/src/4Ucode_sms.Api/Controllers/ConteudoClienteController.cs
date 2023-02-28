using _4Ucode_sms.Api.VewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("Conteudo-Cliente")]
    [ApiController]
    public class ConteudoClienteController : MainController
    {

        private readonly IEnvioDocumentoService _envioDocumentoService;
        private readonly IEnvioDocumentoRepository _envioDocumentoRepository;

        private readonly IContatoDocumentoService _contatoDocumentoService;
        private readonly IContatoDocumentoRepository _contatoDocumentoRepository;

        private readonly IConteudoClienteService _conteudoClienteService;
        private readonly IConteudoClienteRepository _conteudoClienteRepository;

        private readonly IDadosClienteService _dadosClienteService;
        private readonly IDadosClienteRepository _dadosClienteRepository;

        private readonly ITwilloService _twilloService;
        private readonly IMapper _mapper;


        public ConteudoClienteController(
            INotificador notificador,
            IMapper mapper,
            IUser user,
            ITwilloService twilloService,
            IEnvioDocumentoRepository envioDocumentoRepository,
            IEnvioDocumentoService envioDocumentoService,
            IContatoDocumentoService contatoDocumentoService,
            IContatoDocumentoRepository contatoDocumentoRepository,
            IConteudoClienteService conteudoClienteService,
            IConteudoClienteRepository conteudoClienteRepository,
            IDadosClienteRepository dadosClienteRepository,
            IDadosClienteService dadosClienteService) : base(notificador, user)
        {
            _mapper = mapper;
            _twilloService = twilloService;
            _envioDocumentoService = envioDocumentoService;
            _envioDocumentoRepository = envioDocumentoRepository;
            _contatoDocumentoService = contatoDocumentoService;
            _contatoDocumentoRepository = contatoDocumentoRepository;
            _conteudoClienteService = conteudoClienteService;
            _conteudoClienteRepository = conteudoClienteRepository;
            _dadosClienteRepository = dadosClienteRepository;
            _dadosClienteService = dadosClienteService;
        }


        [HttpGet("conteudo")]
        public async Task<IEnumerable<ConteudoClienteViewModel>> ObterConteudo()
        {
            return _mapper.Map<IEnumerable<ConteudoClienteViewModel>>(await _conteudoClienteRepository.ObterTodos());
        }

        [HttpGet("cliente{id:guid}")]

        public async Task<ConteudoClienteViewModel> ObterConteudo(Guid id)
        {
            return _mapper.Map<ConteudoClienteViewModel>(await _conteudoClienteRepository.ObterPorId(id));
        }

        [HttpPost("conteudo")]
        public async Task<ActionResult<ConteudoClienteViewModel>> AdicionarConteudo(ConteudoClienteViewModel conteudoClienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _conteudoClienteService.Adicionar(_mapper.Map<ConteudoCliente>(conteudoClienteViewModel));

            return CustomResponse(conteudoClienteViewModel);
        }

        [HttpGet("paginacao")]
        public async Task<IActionResult> ObterConteudoCliente(Guid Cliente,int Pagina, int TamanhoPagina, int ItensPorPagina, TextoClienteEnum ativo)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produtos = await _conteudoClienteRepository.BuscarComFiltroEPaginacao(Cliente, Pagina,TamanhoPagina,ItensPorPagina,ativo);

            return Ok(produtos);

        }


        [HttpDelete("conteudo{id:guid}")]
        public async Task<ActionResult<ConteudoClienteViewModel>> ExcluirConteudo(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _conteudoClienteService.Remover(id);
            return CustomResponse(id);
        }


    }
}
