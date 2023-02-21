using _4Ucode_sms.Api.VewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("Cliente")]
    public class ClienteController : MainController
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


        public ClienteController(
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
        public async Task<IEnumerable<ConteudoClienteViewModel>> ObterCliente()
        {
            return _mapper.Map<IEnumerable<ConteudoClienteViewModel>>(await _conteudoClienteRepository.ObterTodos());
        }


        [HttpGet("dados")]
        public async Task<IEnumerable<DadosClienteViewModel>> ObterDadosCliente()
        {
            return _mapper.Map<IEnumerable<DadosClienteViewModel>>(await _dadosClienteRepository.ObterTodos());
        }


        [HttpPost("dados")]
        public async Task<ActionResult<PostDadosClienteViewModel>> Adicionar(PostDadosClienteViewModel dadosClienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _dadosClienteRepository.Adicionar(_mapper.Map<DadosCliente>(dadosClienteViewModel));

            return CustomResponse(dadosClienteViewModel);
        }















    }
}
