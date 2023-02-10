using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Interfaces;
using _4Ucode_sms.Api.VewModel;
using Data.Repository;
using _4Ucode_sms.Api.ViewModel.ViewModelTwilio;
using Twilio.TwiML.Messaging;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using Domain.Models.ModelTwillo;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("api/Arquivo")]
    //[ApiController]
    public class FileUploadController : MainController
    {
        private readonly IContatoDocumentoService _contatoDocumentoService;
        private readonly IContatoDocumentoRepository _contatoDocumentoRepository;
        private readonly ITwilloService _twilloService;
        private readonly IMapper _mapper;


        public FileUploadController(
            INotificador notificador,
            IMapper mapper,
            IUser user,
            ITwilloService twilloService,
            IContatoDocumentoRepository contatoDocumentoRepository,
            IContatoDocumentoService baseUploadService) : base(notificador,user)
        {
            _contatoDocumentoService = baseUploadService;
            _mapper = mapper;
            _contatoDocumentoRepository = contatoDocumentoRepository;
            _twilloService = twilloService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Documento(IFormFile arquivo)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Save_Backup_" + arquivo.FileName);
                if (arquivo.Length > 0)
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await arquivo.CopyToAsync(stream);
                }         
            await _contatoDocumentoService.Encapsular(filePath);
            return CustomResponse();
        }


        [HttpGet("get/all")]
        public async Task<IEnumerable<ContatoDocumentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContatoDocumentoViewModel>>(await _contatoDocumentoRepository.ObterTodos());
        }
    }
}
