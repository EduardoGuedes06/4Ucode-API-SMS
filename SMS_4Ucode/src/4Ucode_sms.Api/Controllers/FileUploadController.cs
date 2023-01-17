using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using _4Ucode_sms.Bussines.Interfaces;
using Business.Interfaces;
using _4Ucode_sms.Bussines.Models;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("api/Arquivo")]
    [ApiController]
    public class FileUploadController : BaseController
    {
        private readonly IBaseUploadService _baseUploadService;
        private readonly IMapper _mapper;


        public FileUploadController(
            INotificador notificador,
            IMapper mapper,
            IBaseUploadService baseUploadService) : base(notificador)
        {
            _baseUploadService = baseUploadService;
            _mapper = mapper;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Documents(IList<IFormFile> arquivos)
        {
            IFormFile arquivo = arquivos.FirstOrDefault();


            if (arquivo != null)
            {
                MemoryStream ms = new MemoryStream();
                arquivo.OpenReadStream().CopyTo(ms);

                UploadDocument arq = new UploadDocument()
                {
                    FileName = arquivo.FileName,
                    Dados = ms.ToArray(),
                    ContentType = arquivo.ContentType
                };

                await _baseUploadService.Upload(arq);

            }

            return CustomResponse();
        }
    }
}
