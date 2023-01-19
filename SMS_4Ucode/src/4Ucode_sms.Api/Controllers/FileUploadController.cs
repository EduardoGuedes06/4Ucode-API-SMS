using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Business.Interfaces;
using Bussines.Interfaces;
using _4Ucode_sms.Api.VewModel;
using System.ComponentModel.DataAnnotations;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("api/Arquivo")]
    //[ApiController]
    public class FileUploadController : MainController
    {
        private readonly IContatoDocumentoService _contaDocumentoService;
        private readonly IMapper _mapper;


        public FileUploadController(
            INotificador notificador,
            IMapper mapper,
            IContatoDocumentoService baseUploadService) : base(notificador)
        {
            _contaDocumentoService = baseUploadService;
            _mapper = mapper;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Documents(IList<IFormFile> arquivo)
        {


            var size = arquivo.Sum(f => f.Length);
            var filePaths = new List<string>();

            foreach (var item in arquivo)
            {
                if (item.Length > 0)
                {

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Save_Backup" + item.FileName);
                    filePaths.Add(filePath);

                    using var stream = new FileStream(filePath, FileMode.Create);


                    await item.CopyToAsync(stream);


                }
            }





            

            

            return CostumResponse();
        }
    }
}
